using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pueba.Models.cat_productos;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;

namespace pueba.Presentacion
{
    public partial class frmMagic : Form
    {
        

        public int? id;
        cat_productos oocat_productos = null;
        public frmMagic(int? id =null)
        {
            InitializeComponent();

            this.id = id;
            if (id != null)
            {
                CargaDatos();
            }
        }

        private void CargaDatos()
        {
            using (carteras db = new carteras())
            {
                oocat_productos = db.cat_productos.Find(id);
                txtId.Text = oocat_productos.idu_producto.ToString();
            }
        }

        private bool ValidarGuardar()
        {
            if (this.txtId.Text == string.Empty)
            {
                MessageBox.Show("Faltó el producto we");
                this.txtId.Focus();
                return false;
            }
            if (this.txtReporte.Text == string.Empty)
            {
                MessageBox.Show("Cual es el reporte???? ");
                this.txtReporte.Focus();
                return false;
            }
            return true;
        }

        public frmMagic()
        {
            InitializeComponent();
        }

        private void frmMagic_Load(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (this.ValidarGuardar() == true)
            {
                int vId = int.Parse(txtId.Text.ToString().Trim());
                int vReporte = int.Parse(txtReporte.Text.ToString().Trim());
                string rNombre = "";
                string rReporte = "";
                string startFolder = @"C:\sys\reportes\";
                string nRdlc = "";

                var dsRldlc = CConexion.fEjecutarConsultaDT("exec proc_checkmagic " + @vReporte + "," + @vId);
                DirectoryInfo dir = new DirectoryInfo(startFolder);
                nRdlc = dsRldlc.Rows[0]["des_reporte"].ToString().Trim();
                FileInfo[] pname = dir.GetFiles(nRdlc, SearchOption.AllDirectories);

                
                try
                {
                    if (pname.Length == 0)
                    {
                        AutoClosingMessageBox.Show("No existe el RDLC en la carpeta", "", 500);
                    }
                    else
                    {
                        ReportePorMagic.GenerarReporteMagic(1, vId, vReporte);
                        var dsReporte = CConexion.fEjecutarConsultaDT("exec nom_Reporte " + @vId + "," + @vReporte);
                        rReporte = dsReporte.Rows[0]["NombreArchivo"].ToString().Trim();
                        txtNomReporte.Text = rReporte.ToString().Trim();
                        this.Refresh();

                        var dsNombre = CConexion.fEjecutarConsultaDT("exec nombremagick " + @vId + "," + @vReporte);
                        rNombre = dsNombre.Rows[0]["NombreArchivo"].ToString().Trim();

                        try
                        {
                            System.Diagnostics.Process.Start(@rNombre);
                        }

                        catch (Exception)
                        {
                            this.Close();
                        }
                    }
                }
                catch (Exception)
                {
                    this.Close();
                }
            }
        }

        private void btnRDLC_Click(object sender, EventArgs e)
        {
            int vId = int.Parse(txtId.Text.ToString().Trim());
            int vReporte = int.Parse(txtReporte.Text.ToString().Trim());

            var dsRldlc = CConexion.fEjecutarConsultaDT("exec proc_checkmagic " + @vReporte + "," + @vId);
            string nRdlc = dsRldlc.Rows[0]["des_reporte"].ToString().Trim();

            string fileName = @nRdlc;
            string sourcePath = @"C:\Users\luis.apinterfaces\Documents\Visual Studio 2012\Projects\RDLC\";
            string targetPath = @"C:\sys\reportes\";

            string sourceFile = Path.Combine(sourcePath, fileName);
            string destFile = Path.Combine(targetPath, fileName);

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            File.Copy(sourceFile, destFile, true);
            AutoClosingMessageBox.Show("Archivo copiado", "", 2000);
            
            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                foreach (string s in files)
                {
                    fileName = Path.GetFileName(s);
                    destFile = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFile, true);
                }
            }
            else
            {
                AutoClosingMessageBox.Show("Source path does not exist!", "", 1000);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
