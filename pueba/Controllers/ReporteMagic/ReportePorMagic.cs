using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace pueba
{
    class ReportePorMagic
    {
        const string MagicReportexe = @"\Sys\reportes\MagicReports.exe";
        const string MagicReportdll = @"\Sys\reportes\MagicReport.dll";

        public static bool ExisteMagicYDll()
        {
            if (!File.Exists(MagicReportexe))
            {
                MessageBox.Show(@"No se encuentra MagicReports.exe en la ruta " + MagicReportexe, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!File.Exists(MagicReportdll))
            {
                MessageBox.Show(@"No se encuentra  MagicReports.dll en la ruta " + MagicReportdll, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public static void GenerarReporteMagic(int idConexion, int idProducto, int idReporte)
        {
            try
            {
                Process programa = new Process();
                programa.StartInfo = new ProcessStartInfo(MagicReportexe, string.Format("{0} {1} {2}", idConexion, idProducto, idReporte));
                programa.Start();
                programa.WaitForExit();

            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error al generar el reporte " + ex);
            }
        }
    }
}
