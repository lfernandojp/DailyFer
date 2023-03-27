using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pueba.Models;
using System.Diagnostics;
using Microsoft.VisualBasic.Devices;


namespace pueba
{
    public partial class Form1 : Form
    {
        public string name;
     
        public Form1(string name = null)
        {
            this.name = name;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var saludo = greetings();



            AutoClosingMessageBox.Show("        ⚜  Welcome MASTER  "  + @name  + "     ⚜    "     , "  " + @saludo+"  ", 1500 );
            //System.Diagnostics.Process.Start(@"https://calendar.google.com/calendar/u/0/r");
            //System.Diagnostics.Process.Start(@"https://mail.google.com/chat/u/0/#chat/welcome");


            Process[] pname = Process.GetProcessesByName("Spotify");
            if (pname.Length == 0)
            {
                if (MessageBox.Show("Quieres Spotify?", " " + @saludo + " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(@"C:\Users\User\AppData\Roaming\Spotify\Spotify.exe");
                }
                
            
            }

        }
        public string greetings()
        {
            var hour = DateTime.Now.TimeOfDay.Hours;

            if (hour <= 12)
            {
                return "Buenos dias";
            }
            else if (hour <= 17)
            {
                return "Buenas tardes ";
            }
            return "Buenas noches";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Presentacion.frmTabla ofrmTabla = new Presentacion.frmTabla();
            ofrmTabla.ShowDialog();
            Refresh();
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
      
                System.Diagnostics.Process.Start(@"https://docs.google.com/spreadsheets/d/1vjz7DE5z8OWeN1TaIEdQoIk_ASe0ymGB6TGBo_Aez6M/edit#gid=451418335");
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
               
                System.Diagnostics.Process.Start(@"https://calendar.google.com/calendar/u/0/r");
        
        }

        private void button3_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start(@"https://mail.google.com/mail/u/0/#inbox");
 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                 System.Diagnostics.Process.Start(@"https://drive.google.com/drive/folders/1JVeFD9PAsZg7wn2K8K17HomyUtk5vDQK");

            }
            catch (Exception ex )
            {

                MessageBox.Show("Valio pene, no hay internet ", ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           System.Diagnostics.Process.Start(@"https://drive.google.com/drive/u/0/folders/1ABCCwgsgoJivANCrd_BTGWSm99WZrdvC");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://docs.google.com/presentation/d/1F0-6iewSOgCEAKqncOGJnHNR9tXGt6dVG_eh_MPPPMo/edit#slide=id.g21b338a15fd_0_10");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Program Files\Microsoft VS Code\code.exe");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://docs.google.com/spreadsheets/d/1J15hBxFUT8OBfW9udlPuc1II4HTmA2saZgsOIOSRfSU/edit#gid=1059477555");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
                DialogResult result = MessageBox.Show("Seguro que dese salir?", "Salir", MessageBoxButtons.YesNo);

            switch (result)
            {
                case DialogResult.Yes:
                    this.Close();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void btnGit_Click(object sender, EventArgs e)
        {

                System.Diagnostics.Process.Start(@"https://docs.google.com/spreadsheets/d/1UWUBns_JwXIsTmn2rWZGU-oX99VrGxElZJGel2X5F4Y/edit#gid=1859685963");
            
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Presentacion.frmUsuarios ofrmUsuarios = new Presentacion.frmUsuarios();
            ofrmUsuarios.ShowDialog();
            Refresh();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://asistencia.coppel.com/");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
        
            System.Diagnostics.Process.Start(@"https://sites.google.com/coppel.com/developers/frameworks/webclient/tutoriales-webclient#h.rbysftep3l4v");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://sites.google.com/coppel.com/developers/frameworks/webclient/chk-estandares");
        
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://angular.io/cli");
        
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://sites.google.com/coppel.com/developers/frameworks/webclient?authuser=0");
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\devenv.exe");
       
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\User\AppData\Roaming\Spotify\Spotify.exe");
        }
    }
}
