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
using pueba.Models.Usuarios;

namespace pueba.Presentacion
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
            Refrescar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Refrescar()
        {
            using (EmpleadosEntities3 db = new EmpleadosEntities3())
            {
                var lst = from d in db.User
                          orderby d.Id descending
                          select d;
                dataGridView1.DataSource = lst.ToList();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Presentacion.frmAltaUsuarios ofrmAlta = new Presentacion.frmAltaUsuarios();
            ofrmAlta.ShowDialog();
            this.Refrescar();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {

        }
    }
}
