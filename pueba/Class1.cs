//using System;
//using System.Data;
//using System.Windows.Forms;
//using clsMetodos;
//using Entidades;
//using clsEnumeradores;
//using clsReportes;

//namespace clsClientes
//{

//    public partial class frmClientes : Form
//    {

//        public frmClientes()
//        {
//            InitializeComponent();
//            this.gridDatos._grid.ReadOnly = true;
//            this.metodo = new Metodos();
//        }



//        #region Variables



//        const string cNuevo = "NUEVO";
//        const string cActivo = "ACTIVO";
//        const string cCancelado = "CANCELADO";

//        const int cColClave = 0;
//        const int cColDescripcion = 1;
//        const int cColOrigen = 2;
//        const int cColGlid = 3;
//        const int cColEstatus = 4;
//        const int cColUltimaAct = 5;



//        private ListaDeEntidades<Entidad.Negocio.Scacliente> listaObjeto;
//        private Entidad.Negocio.Scacliente objeto;
//        private Metodos metodo;



//        #endregion



//        #region Funciones



//        private void Inicializar()
//        {

//            this.metodo = new Metodos();
//            this.Limpiar();
//            this.gridDatos.Size = new System.Drawing.Size(556, 260);

//        }



//        private void EstadoControles(bool editar)
//        {

//            this.txtClave.ReadOnly = editar;
//            this.txtDescripcion.ReadOnly = !editar;
//            this.txtGlid.ReadOnly = !editar;
//            this.txtOrigen.ReadOnly = !editar;
//            if (editar)
//            {

//                if (new mobileBO.Negocio.Fachada().TraerScausuarioAdministradorFuncionalidad(UsuarioLogin.usuario.Usuarioid, "frmClientes"))
//                    this.tsbGuardar.Enabled = editar;

//            }

//            else
//                this.tsbGuardar.Enabled = editar;
//        }



//        private void Limpiar()
//        {

//            this.txtClave.Text = string.Empty;
//            this.txtDescripcion.Text = string.Empty;
//            this.txtGlid.Text = string.Empty;
//            this.txtOrigen.Text = string.Empty;
//            this.checkEstatus.Checked = false;
//            this.EstadoControlesEstatus(-1);
//            this.EstadoControles(false);
//            this.gridDatos.ClearFilters();
//            listaObjeto = null;

//            objeto = null;
//            this.gridDatos.DataSource = null;
//            this.txtClave.Focus();

//        }



//        private void EstadoControlesEstatus(int estatus)
//        {

//            switch (estatus)
//            {

//                case -1:
//                    this.lblEstatus.Text = cNuevo;
//                    this.lblEstatus.ForeColor = System.Drawing.Color.Blue;
//                    this.checkEstatus.Checked = true;
//                    this.checkEstatus.Enabled = false;
//                    break;

//                case 0:

//                    this.lblEstatus.Text = cCancelado;
//                    this.lblEstatus.ForeColor = System.Drawing.Color.Red;
//                    this.checkEstatus.Checked = false;
//                    this.checkEstatus.Enabled = true;
//                    break;



//                case 1:

//                    this.lblEstatus.Text = cActivo;
//                    this.lblEstatus.ForeColor = System.Drawing.Color.Blue;
//                    this.checkEstatus.Checked = true;
//                    this.checkEstatus.Enabled = true;
//                    break;

//            }

//        }



//        public DataGridTableStyle CrearEstilo(string Nombre)
//        {

//            DataGridTableStyle result = new DataGridTableStyle();
//            result.GridColumnStyles.Add(metodo.CreateTextColumn("ClienteId", 60));
//            result.GridColumnStyles.Add(metodo.CreateTextColumn("Descripcion", 205));
//            result.GridColumnStyles.Add(metodo.CreateTextColumn("Glid", 63));
//            result.GridColumnStyles.Add(metodo.CreateTextColumn("Origen", 63));
//            result.GridColumnStyles.Add(metodo.CreateTextColumn("Estatus", 50));
//            result.MappingName = Nombre;
//            return result;
//        }

//        private bool ValidarGuardar()
//        {

//            if (this.txtClave.Text == string.Empty)
//            {
//                MessageBox.Show("Debe capturar la clave");
//                this.txtClave.Focus();
//                return false;
//            }

//            if (this.txtDescripcion.Text == string.Empty)
//            {
//                MessageBox.Show("Debe capturar la descripcion");
//                this.txtDescripcion.Focus();
//                return false;
//            }

//            if (this.txtGlid.Text == string.Empty)
//            {
//                MessageBox.Show("Debe capturar un glid");
//                this.txtGlid.Focus();
//                return false;
//            }

//            if (this.txtOrigen.Text == string.Empty)
//            {
//                MessageBox.Show("Debe capturar un origen");
//                this.txtOrigen.Focus();
//                return false;

//            }

//            return true;

//        }

//        #endregion



//        #region Eventos



//        private void frmClientes_Load(object sender, EventArgs e)
//        {

//            this.Inicializar();

//        }



//        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
//        {

//            try
//            {

    //                if (e.KeyChar == (char)Keys.Enter)
    //                {

//                    if (this.txtClave.Text.Trim() != string.Empty)
//                    {

//                        objeto = new mobileBO.Negocio.Fachada().TraerScaclientes(Int32.Parse(this.txtClave.Text));

//                        if (objeto != null)
//                        {

//                            this.txtDescripcion.Text = objeto.Descripcion.ToString().Trim();

//                            this.txtGlid.Text = objeto.Glid.ToString().Trim();

//                            this.txtOrigen.Text = objeto.Origen.ToString().Trim();

//                            this.EstadoControlesEstatus(objeto.Estatus);

//                        }

//                        this.EstadoControles(true);

//                        this.gridDatos.ClearFilters();

//                        this.gridDatos.DataSource = null;

//                        this.txtDescripcion.Focus();

//                    }

//                }

//                else
//                {

//                    metodo.ValidaCaracter(e);

//                }

//            }

//            catch (Exception ex)
//            {

//                this.metodo.Mensaje(ex.Message.ToString(), true); ;

//            }

//        }

//        private void btnBuscar_Click(object sender, EventArgs e)
//        {

//            DataSet ds = null;
//            try
//            {
//                this.gridDatos.ClearFilters();
//                this.gridDatos.DataSource = null;

//                ds = new mobileBO.Negocio.Fachada().TraerScaclientesDS();
//                if (metodo.DataSetValido(ref ds) == true)
//                {

//                    ds.Tables[0].TableName = "Consulta";
//                    this.gridDatos.DataSource = ds.Tables[0].AsDataView();
//                    this.gridDatos._grid.TableStyles.Clear();
//                    this.gridDatos._grid.TableStyles.Add(this.CrearEstilo(ds.Tables[0].TableName));

//                }

//            }

//            catch (Exception ex)
//            {

//                this.metodo.Mensaje(ex.Message.ToString(), true); ;

//            }

//            finally
//            {

//                ds = null;

//            }

//        }



//        private void btnImprimir_Click(object sender, EventArgs e)
//        {

//            DataSet ds;
//            ds = new mobileBO.Negocio.Fachada().TraerImpresionScaclientesDS();
//            if (metodo.DataSetValido(ref ds))
//            {
//                metodo.agregarImagenSucursal(ref ds, UsuarioLogin.ImagenSucursal);
//                //ds.WriteXml("C:\\Reportes\\ReporteClientess.xml", XmlWriteMode.WriteSchema);
//                MostrarReporte forma = new MostrarReporte(ds, "Catalogo de Clientes", "rptClientes");
//                forma.Owner = this;
//                forma.Show();
//            }

//            ds = null;

//        }



//        private void btnGuardar_Click(object sender, EventArgs e)
//        {

//            if (this.ValidarGuardar() == false)

//                return;

//            this.Guardar();

//        }

//        private void btnNuevo_Click(object sender, EventArgs e)
//        {
//            this.Limpiar();
//        }



//        private void gridDatos_DoubleClick(object sender, EventArgs e)
//        {
//            DataTable dt = new DataTable();
//            try
//            {

//                if (((GridExtensions.FilterableDataGrid)(sender)).EmbeddedDataGrid.CurrentView != null)
//                {
//                    dt = ((GridExtensions.FilterableDataGrid)(sender)).EmbeddedDataGrid.CurrentView.ToTable();

//                    if (dt.Rows.Count > 0)
//                    {
//                        this.txtClave.Text = dt.Rows[gridDatos._grid.Grid.CurrentCell.RowNumber][cColClave].ToString();
//                        this.txtDescripcion.Text = dt.Rows[gridDatos._grid.Grid.CurrentCell.RowNumber][cColDescripcion].ToString();
//                        this.txtGlid.Text = dt.Rows[gridDatos._grid.Grid.CurrentCell.RowNumber][cColGlid].ToString();
//                        this.txtOrigen.Text = dt.Rows[gridDatos._grid.Grid.CurrentCell.RowNumber][cColOrigen].ToString();

//                        objeto = new Entidad.Negocio.Scacliente();
//                        objeto.Clienteid = int.Parse(dt.Rows[gridDatos._grid.Grid.CurrentCell.RowNumber][cColClave].ToString());
//                        objeto.Descripcion = dt.Rows[gridDatos._grid.Grid.CurrentCell.RowNumber][cColDescripcion].ToString();
//                        objeto.Glid = dt.Rows[gridDatos._grid.Grid.CurrentCell.RowNumber][cColGlid].ToString();
//                        objeto.Origen = dt.Rows[gridDatos._grid.Grid.CurrentCell.RowNumber][cColOrigen].ToString();
//                        objeto.Estatus = Convert.ToInt32(dt.Rows[gridDatos._grid.Grid.CurrentCell.RowNumber][cColEstatus]);
//                        objeto.UltimaAct = Convert.ToInt32(dt.Rows[gridDatos._grid.Grid.CurrentCell.RowNumber][cColUltimaAct]);
//                        this.EstadoControlesEstatus(Convert.ToInt32(dt.Rows[gridDatos._grid.Grid.CurrentCell.RowNumber][cColEstatus]));
//                        this.EstadoControles(true);
//                        this.txtDescripcion.Focus();
//                    }

//                }

//            }

//            catch (Exception ex)
//            {

//                this.metodo.Mensaje(ex.ToString(), true);

//            }

//            finally
//            {

//                dt = null;

//            }

//        }

//        #endregion

//        #region Guardar

//        private void Guardar()
//        {
//            try
//            {
//                if (objeto == null)
//                {
//                    objeto = new Entidad.Negocio.Scacliente();
//                    objeto.Clienteid = int.Parse(txtClave.Text);
//                    objeto.Estatus = 1;
//                    objeto.Estatus = (this.checkEstatus.Checked == true ? 1 : 0);
//                }

//                else
//                {

//                    objeto.Estatus = (this.checkEstatus.Checked == true ? 1 : 0);

//                }
//                objeto.Descripcion = txtDescripcion.Text;
//                objeto.Glid = txtGlid.Text;
//                objeto.Origen = txtOrigen.Text;

//                listaObjeto = new ListaDeEntidades<Entidad.Negocio.Scacliente>();
//                listaObjeto.Add(objeto);
//                new mobileBO.Negocio.Fachada().GuardarScaCliente(listaObjeto);
//                this.Limpiar();

//                metodo.Mensaje("Registro guardado", false);

//            }

//            catch (Entidad.Negocio.ExcepcionReglaDeNegocios exNeg)
//            {

//                this.metodo.Mensaje(exNeg.Message.ToString(), false);

//                this.txtDescripcion.Focus();

//            }

//            catch (Exception ex)
//            {

//                this.metodo.Mensaje(ex.Message.ToString(), true);

//            }

//            finally
//            {

//                listaObjeto = null;

//            }

//        }



//        #endregion



//        private void frmClientes_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
//        {

//            //Help.ShowHelp(this, UsuarioLogin.DirectorioAyuda, HelpNavigator.Topic, "Insumos.html");              



//        }



//        private void frmClientes_KeyDown(object sender, KeyEventArgs e)
//        {

//            if (e.KeyData == Keys.Escape)

//                this.Close();

//        }



//        private void tsbSalir_Click(object sender, EventArgs e)
//        {

//            this.Close();

//        }

//    }

//}