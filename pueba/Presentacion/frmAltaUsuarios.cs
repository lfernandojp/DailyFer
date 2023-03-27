using pueba.Models.cat_productos;
using pueba.Models.Usuarios;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace pueba.Presentacion
{
    public partial class frmAltaUsuarios : Form
    {
        
        User oPersonal = null;
        
        public frmAltaUsuarios()
        {
            InitializeComponent();
            
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (EmpleadosEntities3 db = new EmpleadosEntities3())
                {
                    int validacio = 0;
                    string Nombre = txtUsuario.Text.ToString();
                    string Pass = txtContrasena.Text.ToString();

                    IEnumerable<string> lst = from d in db.User
                                              where d.Pass == @Pass
                                              where d.Usuario == @Nombre
                                              select d.Usuario;

                    foreach (var a in lst)
                    {
                        validacio = 1;
                    }

                    if (validacio == 1)
                    {
                        AutoClosingMessageBox.Show("User already taken", "Go and fuck yourself!", 1000);
                    }
                    else
                    {
                        using (EmpleadosEntities3 dbe = new EmpleadosEntities3())
                        {
                            oPersonal = new User();
                            oPersonal.Usuario = txtUsuario.Text.ToString();
                            oPersonal.Pass = txtContrasena.Text.ToString();

                            dbe.User.Find();
                            dbe.User.Add(oPersonal);
                            dbe.SaveChanges();
                            this.Close();
                        }
                    }
                }
            }
            
            catch (Exception)
            {
                this.Close();
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void frmAltaUsuarios_Load(object sender, EventArgs e)
        {
            this.btnSalir.Focus();
        }
       
    }
}
