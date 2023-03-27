using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace pueba
{
    public class CConexion
    {
        public string IP, DB, USER, PASS;
        private int CONT;
        FileInfo fXml = new FileInfo(@"C:\sys\exe\CONEXION\XmlConexion.xml");
        String[] consultaSql = new String[] { "IP", "User", "Password", "Database" };
        public SqlConnectionStringBuilder connstring;
        String[] datosSql = new String[4];

        /// <summary>
        /// Metodo que retorna una cadena de conexion para sql server
        /// </summary>
        /// <param name="nombreConexion">nombre de la conexion o nodo a buscar</param>
        /// <returns></returns>

        public string GenerarCadenaSql(string nombreConexion)
        {
            string cadenaConexion = string.Empty;

            try
            {
                ///<Validando que el archivo xml exista>
                if (!fXml.Exists)
                {
                    throw new Exception("No existe el archivo " + fXml.FullName);
                }
                ///<Cargando el documento xml>

                XDocument miXML = XDocument.Load(fXml.FullName);
                ///<leyendo los atributos de la conexion>
                for (int i = 0; i < datosSql.Length; i++)
                {
                    var varDatos = from nombre in miXML.Elements("XmlConfiguracion").Elements("SqlServer")
                                   where nombre.Attribute("NombreConexion").Value == nombreConexion //Consultamos por el atributo
                                   select nombre.Element(consultaSql[i]).Value; //Seleccionamos el nombre
                    foreach (string item in varDatos)
                    {
                        datosSql[i] = item;
                        break;
                    }
                }

                this.connstring = new SqlConnectionStringBuilder();
                this.connstring.DataSource = datosSql[0].ToString();
                this.connstring.InitialCatalog = datosSql[3].ToString();
                this.connstring.UserID = datosSql[1].ToString();
                this.connstring.Password = datosSql[2].ToString();
                this.connstring.MultipleActiveResultSets = true;
                this.connstring.IntegratedSecurity = false;
                return connstring.ConnectionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LeeArchivo(string archivo)
        {
            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    String linea;
                    CONT = 0;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        CONT += 1;
                        switch (CONT)
                        {
                            case 1:
                                IP = linea;
                                break;
                            case 2:
                                DB = linea;
                                break;
                            case 3:
                                USER = linea;
                                break;
                            case 4:
                                PASS = linea;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static DataTable fEjecutarConsultaDT(string sConsulta)
        {
            return fEjecutarConsultaDT(sConsulta, new List<ParametroSQL>());
        }

        public static DataTable fEjecutarConsultaDT(string sConsulta, List<ParametroSQL> paramSQL)
        {
            DataTable Dt = new DataTable();
            try
            {
                using (SqlConnection Con = new SqlConnection(new CConexion().GenerarCadenaSql("ConexionCarteras")))
                {
                    using (SqlCommand Cm = new SqlCommand(sConsulta, Con))
                    using (SqlDataAdapter Da = new SqlDataAdapter())
                    {
                        foreach (ParametroSQL param in paramSQL)
                        {
                            Cm.Parameters.Add(param.nombreParametro, param.tipo);
                            Cm.Parameters[param.nombreParametro].Value = param.valor;
                        }
                        Cm.CommandTimeout = 0;
                        Da.SelectCommand = Cm;
                        Dt.Clear();
                        Da.Fill(Dt);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            return Dt;
        }

        public DataTable EjecutarConsultaSql(string consulta, string cadenaSql)
        {
            return fEjecutarConsultaDT(consulta);
        }
    }
}

