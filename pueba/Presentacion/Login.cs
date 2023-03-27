using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using pueba.Presentacion;
using System.Configuration;
using System.Data.SqlClient;
using pueba.Models.cat_productos;
using pueba.Models.Usuarios;
using System.Diagnostics;


namespace pueba.Presentacion
{
    public partial class Login : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            using (EmpleadosEntities3 db = new EmpleadosEntities3())
            {
                string Nombre = txtName.Text.ToString();
                string Pass = txtPass.Text.ToString();

                IEnumerable<string> lst = from d in db.User
                                          where d.Pass == @Pass
                                          where d.Usuario == @Nombre
                                          select d.Usuario;
                foreach (var a in lst)
                {
                    string nombre = Nombre;

                    Process[] pname = Process.GetProcessesByName("f5vpn");
                    //if (pname.Length == 0)
                    //{
                    //    MessageBox.Show("Encendiendo F5");
                    //    //System.Diagnostics.Process.Start(@"https://movilidad.coppel.com/");
                    //}
                    //else
                    {
                        Form1 ofrmform1 = new Form1(nombre);
                        ofrmform1.ShowDialog();
                    }
                    this.Close();
                }
                AutoClosingMessageBox.Show(" Usuario o contraseña incrrecta", "", 800);
                this.txtName.Text = null;
                this.txtPass.Text = null;
                this.txtName.Focus();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "USUARIO")
            {
                txtName.Text = "";
                txtName.ForeColor = Color.LightGray;
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.Text = "USUARIO";
                txtName.ForeColor = Color.Silver;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.Silver;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                using ( EmpleadosEntities3  db = new EmpleadosEntities3())
                {
                    string Nombre = txtName.Text.ToString();
                    string Pass = txtPass.Text.ToString();

                    IEnumerable<string> lst = from d in db.User
                                              where d.Pass == @Pass
                                              where d.Usuario == @Nombre
                                              select d.Usuario;
                    foreach (var a in lst)
                    {
                        string nombre = Nombre;

                        //Process[] pname = Process.GetProcessesByName("f5vpn");
                        //if (pname.Length == 0)
                        //{
                        //    MessageBox.Show("Encendiendo F5");
                        //    System.Diagnostics.Process.Start(@"https://movilidad.coppel.com/");
                        //}
                        //else
                        {
                            Form1 ofrmform1 = new Form1(nombre);
                            ofrmform1.ShowDialog();
                        }
                        this.Close();
                    }
                    AutoClosingMessageBox.Show(" Usuario o contraseña incrrecta", "", 800);
                    this.txtName.Text = null;
                    this.txtPass.Text = null;
                     this.txtName.Focus();
                }
            }
        }

        private void shapeContainer1_Load(object sender, EventArgs e)
        {

        }

       
    }
}




//try
//{
//    Boolean respda = C.inteconec(bsconec);

//    if (respda)
//    {
//        this.Refresh();
//        lblconexion.ForeColor = Color.Green;
//        this.Refresh();
//        lbllisto.Text = "Listo...";
//        this.Refresh();
//        lbllisto.ForeColor = Color.Green;
//        button1.Enabled = true;
//        this.Refresh();
//        lbl1.Text = "DRE_0421.TXT";
//        this.Refresh();

//    }