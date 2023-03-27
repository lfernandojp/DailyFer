using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pueba.Models.cat_productos;
using System.Data.Entity;



namespace pueba.Presentacion
{
    public partial class frmTabla : Form
    {
        public int? id;
        cat_productos oocat_productos = null;
        public frmTabla(int? id =null)
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
                txtProducto.Text = oocat_productos.idu_producto.ToString();
                txtDescripcion.Text = oocat_productos.des_producto.ToString();
                txtAplicacion.Text = oocat_productos.des_aplicacion.ToString();
            }
        }

        private void frmTabla_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (carteras db = new carteras())               
            {
                if (id == null)                                           
                 oocat_productos = new cat_productos();
                oocat_productos.idu_producto = int.Parse(txtProducto.Text);
                oocat_productos.des_producto = txtDescripcion.Text;
                oocat_productos.des_aplicacion = txtAplicacion.Text;        

                if (id == null)                                 

                    db.cat_productos.Add(oocat_productos);
                else                                             
                {
                    db.Entry(oocat_productos).State = EntityState.Modified;
                }

                db.SaveChanges();                                                          
                this.Close();                                       
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
