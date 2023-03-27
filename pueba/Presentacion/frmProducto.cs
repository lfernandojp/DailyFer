using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using pueba.Models.cat_productos;

namespace pueba.Presentacion
{
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            Refrescar();
            this.rbProducto.Checked = true;
        }
        private void Refrescar()
        {
            using (carteras db = new carteras())
            {
                var lst = from d in db.cat_productos
                          orderby d.idu_producto descending
                          select d;
                dataGridView1.DataSource = lst.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presentacion.frmTabla ofrmTabla = new Presentacion.frmTabla();
            ofrmTabla.ShowDialog();
            Refrescar();
        }
        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (key)
            int? id = GetId();
            if (id != null)
            {
                Presentacion.frmTabla ofrmTabla = new Presentacion.frmTabla(id);
                ofrmTabla.ShowDialog();
                Refrescar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbDescripcion.Checked == true)
                {
                    using (carteras db = new carteras())
                    {
                        string vNombre = txtNombre.Text.ToString();

                        var lst = from d in db.cat_productos
                                  where d.des_aplicacion.Contains(@vNombre)
                                  where d.des_producto.Contains(@vNombre)
                                  orderby d.idu_producto descending
                                  select d;

                        dataGridView1.DataSource = lst.ToList();
                        this.txtNombre.Text = string.Empty;
                    }
                }
                else
                {
                    try
                    {
                        using (carteras db = new carteras())
                        {
                            var vNombre = int.Parse(txtNombre.Text.ToString());

                            var lst = from d in db.cat_productos
                                      where d.idu_producto == @vNombre
                                      orderby d.idu_producto descending
                                      select d;

                            dataGridView1.DataSource = lst.ToList();
                            this.txtNombre.Text = string.Empty;
                        }
                    }
                    catch (Exception)
                    {

                        AutoClosingMessageBox.Show("Solo numeros", "ERROR", 500);
                    }
                    
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            this.Refrescar();
        }

        private int? GetIdRdlc()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch (Exception)
            {
                return null;
            }
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int? id = GetIdRdlc();
            if (id != null)
            {
                Presentacion.frmMagic ofrmTabla = new Presentacion.frmMagic(id);
                ofrmTabla.ShowDialog();
                Refrescar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
