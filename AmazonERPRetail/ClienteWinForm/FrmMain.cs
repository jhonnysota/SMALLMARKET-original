using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;

using Presentadora.AgenteServicio;
using Entidades.Seguridad;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Tools;
using ClienteWinForm.Seguridad;
using ClienteWinForm.Busquedas;
using ClienteWinForm.Ventas;
using ConsultasOnline;
//using HelperSql;

namespace ClienteWinForm
{
    public partial class FrmMain : Form
    {

        public FrmMain()
        {
            FrmLogin f = new FrmLogin();

            if (f.ShowDialog() != DialogResult.OK)
            {
                Environment.Exit(0);
            }

            if (VariablesLocales.SesionUsuario.Reset)
            {
                FrmCambiarContraseña frm = new FrmCambiarContraseña();

                if (frm.ShowDialog() != DialogResult.OK)
                {
                    Environment.Exit(0);
                }
            }

            Global.AjustarResolucion(this);
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            msPrincipal.Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            _bw.WorkerReportsProgress = true;
            _bw.WorkerSupportsCancellation = true;
            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.ProgressChanged += new ProgressChangedEventHandler(_bw_ProgressChanged);
        }

        #region Variables

        public ToolStripMenuItem mnuItemRecientes = new ToolStripMenuItem("RECIENTES");
        private readonly BackgroundWorker _bw = new BackgroundWorker();
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }

        #endregion

        #region ToolStrip

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            Form f = this.ActiveMdiChild;
            if (f != null)
            {
                IMantenimiento i = f as IMantenimiento;
                i.Nuevo();
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            Form f = this.ActiveMdiChild;
            if (f != null)
            {
                IMantenimiento i = f as IMantenimiento;
                i.Editar();
            }
        }

        private void tsbGrabar_Click(object sender, EventArgs e)
        {
            Form f = this.ActiveMdiChild;
            if (f != null)
            {
                IMantenimiento i = f as IMantenimiento;

                i.Grabar();
            }
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            Form f = this.ActiveMdiChild;
            if (f != null)
            {
                IMantenimiento i = f as IMantenimiento;
                i.Buscar();
            }
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            Form f = this.ActiveMdiChild;
            if (f != null)
            {
                IMantenimiento i = f as IMantenimiento;
                i.Cancelar();
            }
        }

        private void tsbAnular_Click(object sender, EventArgs e)
        {
            Form f = this.ActiveMdiChild;
            if (f != null)
            {
                IMantenimiento i = f as IMantenimiento;
                i.Anular();
            }
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Form f = this.ActiveMdiChild;
            if (f != null)
            {
                IMantenimiento i = f as IMantenimiento;
                i.QuitarDetalle();
            }
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Form f = this.ActiveMdiChild;
            if (f != null)
            {
                IMantenimiento i = f as IMantenimiento;
                i.AgregarDetalle();
            }
        }

        private void tsbExportar_Click(object sender, EventArgs e)
        {
            Form f = this.ActiveMdiChild;
            if (f != null)
            {
                IMantenimiento i = f as IMantenimiento;
                i.Exportar();
            }
        }

        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            Form f = this.ActiveMdiChild;
            if (f != null)
            {
                IMantenimiento i = f as IMantenimiento;
                i.Imprimir();
            }
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Form f = this.ActiveMdiChild;
            if (f != null)
            {
                IMantenimiento i = f as IMantenimiento;
                i.Cerrar();
            }
        }

        #endregion

        #region Procedimientos de Usuario

        private void CrearArchivoTexto()
        {
            try
            {
                String Path = @"C:\AmazonErp\Reporting";
                String NombreArchivo = @"\Cnx.ini";

                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }

                Path += NombreArchivo;

                if (File.Exists(Path))
                {
                    File.Delete(Path);
                }

                String Usuario = VariablesLocales.SesionUsuario.Credencial;
                String Clave = EncryptHelper.Decrypt(VariablesLocales.SesionUsuario.Clave);

                if (Usuario != "SISTEMAS")
                {
                    using (StreamWriter oSw = new StreamWriter(Path, true, Encoding.Default))
                    {
                        oSw.WriteLine("[Cnx]");
                        oSw.WriteLine("usuario = " + Usuario);
                        oSw.WriteLine("contraseña = " + Clave);
                        oSw.WriteLine("empresa = " + VariablesLocales.SesionUsuario.Empresa.IdEmpresa.ToString());
                        oSw.WriteLine("local = " + VariablesLocales.SesionLocal.IdLocal.ToString());
                    }
                }
                else
                {
                    using (StreamWriter oSw = new StreamWriter(Path, true, Encoding.Default))
                    {
                        oSw.WriteLine("[Cnx]");
                        oSw.WriteLine("usuario = " + Usuario);
                        oSw.WriteLine("contraseña = 873249");
                        oSw.WriteLine("empresa = " + VariablesLocales.SesionUsuario.Empresa.IdEmpresa.ToString());
                        oSw.WriteLine("local = " + VariablesLocales.SesionLocal.IdLocal.ToString());
                    }
                }

                Process.Start(@"C:\AmazonErp\Reporting\indusoftNet.exe");
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void CargarFondo()
        {
            try
            {
                if (VariablesLocales.ListaParametros != null && VariablesLocales.ListaParametros.Count > Variables.Cero)
                {
                    String Ruta = @"C:\AmazonErp\Fondo\";
                    ParametroE oParametros = (from x in VariablesLocales.ListaParametros where x.IdParametro == 1 select x).FirstOrDefault();

                    if (oParametros != null)
                    {
                        //Creando el directorio si no existe...
                        if (!Directory.Exists(Ruta))
                        {
                            Directory.CreateDirectory(Ruta);
                        }

                        Ruta += oParametros.ValorCadena;

                        if (File.Exists(Ruta))
                        {
                            switch (Convert.ToInt32(oParametros.ValorDecimal))
                            {
                                case 0:
                                    BackgroundImageLayout = ImageLayout.None; //Sin Fondo
                                    break;
                                case 1:
                                    BackgroundImageLayout = ImageLayout.Tile; //Imagen en Mosaico
                                    break;
                                case 2:
                                    BackgroundImageLayout = ImageLayout.Center; //Imagen centrada con tamaño real
                                    break;
                                case 3:
                                    BackgroundImageLayout = ImageLayout.Stretch; //Imagen Estirada
                                    break;
                                case 4:
                                    BackgroundImageLayout = ImageLayout.Zoom; //Imagen...
                                    break;

                                default:
                                    break;
                            }

                            BackgroundImage = Image.FromFile(Ruta);
                        }
                        else
                        {
                            BackgroundImageLayout = ImageLayout.Stretch; //Imagen Estirada
                            //BackgroundImage = ClienteWinForm.Properties.Resources.Fondo_Prueba;
                        } 
                    }
                }
                else
                {
                    BackgroundImageLayout = ImageLayout.Stretch; //Imagen Estirada
                    //BackgroundImage = ClienteWinForm.Properties.Resources.Fondo_Prueba;
                }
                
                Refresh();
            }
            catch (FileNotFoundException ex)
            {
                Global.MensajeFault("No se encuentra o no existe el archivo en la siguiente ruta: " + ex.Message);
            }
            catch (Exception ex)
            {
                Global.MensajeError("\n\r" + ex.Message);
            }
        }

        private void CargaVariables()
        {
            try
            {
                //Fecha del Servidor
                VariablesLocales.FechaHoy = new MaestrosServiceAgent().Proxy.RecuperarFechaServidor();
                //Periodo Contable
                //VariablesLocales.PeriodoContable = new ContabilidadServiceAgent().Proxy.ObtenerPeriodoPorMes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.FechaHoy.ToString("yyyy"), VariablesLocales.FechaHoy.ToString("MM"));
                //Version del Plan Contable Actual
                //VariablesLocales.VersionPlanCuentasActual = new ContabilidadServiceAgent().Proxy.VersionPlanCuentasActual(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                //Listar los Centros de Costos
                VariablesLocales.ListarCCostosPorSistema = new MaestrosServiceAgent().Proxy.ListarCCostosPorSistema(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 1);
                //Lista de las monedas
                VariablesLocales.ListaMonedas = new GeneralesServiceAgent().Proxy.ListarMonedas();
                //Tipo de Cambio del dia
                VariablesLocales.TipoCambioDelDia = new GeneralesServiceAgent().Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, VariablesLocales.FechaHoy.ToString("yyyyMMdd"));
                //Cuentas que van por defecto al generar los vouchers...
                //VariablesLocales.ListaCuentasPorDefecto = new GeneralesServiceAgent().Proxy.ListarParTablaPorGrupo(Convert.ToInt32(EnumParTabla.CuentasDiferenciaCambio), "");
                //Tamaño maximo de los archivos antes de guardar...
                //VariablesLocales.PesoArchivos = new GeneralesServiceAgent().Proxy.RecuperarParametroPorID(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Variables.ValorUno);
                //Para el control de documentos....
                VariablesLocales.ListaDetalleNumControl = new VentasServiceAgent().Proxy.ListarNumControlDetPorEmpresa(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);
                //Para los comprobantes y files de contabilidad...
                //VariablesLocales.oListaComprobantes = new ContabilidadServiceAgent().Proxy.ListarComprobantesGeneral(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                //Lista de las cuentas que tengan su Centro de Costo...
                //VariablesLocales.oListaCuentaCC = new ContabilidadServiceAgent().Proxy.ListarCuentaCCosto(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                //Obtener la lista de impuesto vigente a la fecha
                VariablesLocales.oListaImpuestos = new GeneralesServiceAgent().Proxy.ListarPorcentajeImpuesto(VariablesLocales.FechaHoy.Date);
                //Lista de Tipo de Bases Imponibles para el módulo de contabilidad
                //VariablesLocales.oListaBasesImponibles = new GeneralesServiceAgent().Proxy.ListarParTablaPorNemo("TIPBA");
                //Documento de Ventas
                VariablesLocales.ListarDocumentoGeneral = new MaestrosServiceAgent().Proxy.ListarDocumentosGeneral();
                //Obtener la campaña agricola vigente
                //VariablesLocales.CampanaVigente = new ProduccionServiceAgent().Proxy.ObtenerCampanaAgriVigente(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                VariablesLocales.EsLiquidacion = Variables.NO;
                VariablesLocales.oListaSistemas = new GeneralesServiceAgent().Proxy.ListarSistemas();

                //Paramestros para contabilidad
                //VariablesLocales.oConParametros = new ContabilidadServiceAgent().Proxy.ObtenerParametrosConta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                //Parametros para el módulo de ventas
                VariablesLocales.oVenParametros = new VentasServiceAgent().Proxy.ObtenerVenParametros(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                //Parametros para el módulo de tesoreria
                //VariablesLocales.oTesParametros = new TesoreriaServiceAgent().Proxy.ObtenerTesParametros(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                //Parámetros para el módulo de compras
                //VariablesLocales.oComprasParametros = new AlmacenServiceAgent().Proxy.ObtenerOrdenCompraParam(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                VariablesLocales.oSalesPoint = new VentasServiceAgent().Proxy.CargarSalesPoint(System.Net.Dns.GetHostName());
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void CargaMenu()
        {
            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                VariablesLocales.listaOpciones = new SeguridadServiceAgent().Proxy.RecuperarOpcionTotal().OrderBy(X => X.Orden).ToList();
            }
            else
            {
                VariablesLocales.listaOpciones = new SeguridadServiceAgent().Proxy.RecuperaOpcionesUsuarioEmpresa(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionUsuario.IdPersona).OrderBy(X => X.IdOpcion).ToList();
            }

            msPrincipal.Items.Clear();

            foreach (Opcion itemGrupo in (from x in VariablesLocales.listaOpciones where x.GrupoOpcion == 0 orderby x.Orden select x).ToList())
            {
                ToolStripMenuItem menu = new ToolStripMenuItem(itemGrupo.Nombre)
                {
                    Tag = itemGrupo.IdOpcion
                };

                LlenaOpciones(menu);
                msPrincipal.Items.Add(menu);
            }

            //MenuOrganizarVentanas();
        }

        public void LlenaOpciones(ToolStripMenuItem menu)
        {
            ToolStripMenuItem opcionNegocio = null;

            if ((from x in VariablesLocales.listaOpciones where x.GrupoOpcion == (Int32)menu.Tag select x).Count() > 0)
            {
                foreach (Opcion item in (from x in VariablesLocales.listaOpciones where x.GrupoOpcion == (Int32)menu.Tag orderby x.Orden select x).ToList())
                {
                    opcionNegocio = new ToolStripMenuItem(item.Nombre)
                    {
                        AccessibleName = item.Ubicacion,
                        Tag = item.IdOpcion
                    };

                    if (opcionNegocio.AccessibleName != "")
                    {
                        opcionNegocio.Click += new EventHandler(EjecutarMenu);
                    }

                    if (item.Nombre == "-")
                    {
                        menu.DropDownItems.Add(new ToolStripSeparator());
                    }
                    else
                    {
                        LlenaOpciones(opcionNegocio);
                        menu.DropDownItems.Add(opcionNegocio);
                    }
                }
            }
        }

        public void EjecutarMenu(object sender, EventArgs e)
        {
            FrmMantenimientoBase y;
            String nombreMenu = ((ToolStripItem)(sender)).AccessibleName;
            String MenuPadre = ((ToolStripItem)(sender)).AccessibilityObject.Parent.Parent.Name;
            Type tipo = (from x in Assembly.GetExecutingAssembly().GetTypes()
                         where x.Name.ToUpper() == nombreMenu.ToUpper()
                         select x).FirstOrDefault();

            //if (tipo == null)
            //{
            //    if (nombreMenu == "FRMCONTA")
            //    {
            //        CrearArchivoTexto();
            //    }
            //    else
            //    {
            //        MessageBox.Show("No se pudo mostrar la ventana requerida. Comuniquese con el Administrador del Sistema");
            //    }
            //}
            //else
            //{
            try
            {
                y = (FrmMantenimientoBase)Activator.CreateInstance(tipo);
                Int32 nroInstancias = (from x in this.MdiChildren where x.Name.ToUpper() == nombreMenu.ToUpper() select x).Count();

                if (nombreMenu == "FRMLISTADOCONCEPTOS")
                {
                    SistemasE Sis = null;

                    if (MenuPadre == "COMPRAS")
                    {
                        Sis = VariablesLocales.oListaSistemas.Find
                        (
                            delegate (SistemasE cc) { return cc.idSistema == 5; }//Compras
                        );
                    }
                    else if (MenuPadre == "TESORERIA")
                    {
                        Sis = VariablesLocales.oListaSistemas.Find
                        (
                            delegate (SistemasE cc) { return cc.idSistema == 6; }//Tesoreria
                        );
                    }
                    else
                    {
                        Sis = VariablesLocales.oListaSistemas.Find
                        (
                            delegate (SistemasE cc) { return cc.idSistema == 7; }//Cobranzas
                        );
                    }

                    if (Sis != null)
                    {
                        y.idSistemaForm = Sis.idSistema;
                    }

                    y.NroSesiones = 3;
                }

                if (nombreMenu == "FRMREPORTE_CTACTE")
                {
                    SistemasE Sis = null;

                    if (MenuPadre == "COBRANZAS")
                    {
                        Sis = VariablesLocales.oListaSistemas.Find
                        (
                            delegate (SistemasE cc) { return cc.idSistema == 2; }//Ventas
                        );
                    }
                    else if (MenuPadre == "TESORERIA")
                    {
                        Sis = VariablesLocales.oListaSistemas.Find
                        (
                            delegate (SistemasE cc) { return cc.idSistema == 5; }//Compras
                        );
                    }

                    if (Sis != null)
                    {
                        y.idSistemaForm = Sis.idSistema;
                    }

                    y.NroSesiones = 2;
                }

                if (nroInstancias == 1 && y.NroSesiones == 1)
                {
                    var vent = (from x in this.MdiChildren where x.Name.ToUpper() == nombreMenu.ToUpper() select x).FirstOrDefault();
                    vent.WindowState = FormWindowState.Normal;
                    vent.BringToFront();
                    vent.Show();
                    return;
                }

                //if (nroInstancias == 2 && y.NroSesiones == 3)
                //{
                //    var vent = (from x in this.MdiChildren where x.Name.ToUpper() == nombreMenu.ToUpper() select x).FirstOrDefault();
                //    vent.WindowState = FormWindowState.Normal;
                //    vent.BringToFront();
                //    vent.Show();
                //    return;
                //}

                if (nroInstancias < y.NroSesiones)
                {
                    y.MdiParent = this;
                    y.Show();
                }

                //if (y.ValidarIngresoVentana() && nroInstancias < y.NroSesiones)

                //if (nroInstancias < y.NroSesiones)
                //{
                //    y.MdiParent = this;
                //    y.Show();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general " + ex.Message);
            }
            //}
        }

        public void MenuOrganizarVentanas()
        {
            //Principal
            ToolStripMenuItem MenuVentana = new ToolStripMenuItem("VENTANAS");
            msPrincipal.Items.Add(MenuVentana);
            
            //Sub Items
            //ToolStripMenuItem mnuItemMosaicoVertical = new ToolStripMenuItem("MOSAICO VERTICAL");
            //ToolStripMenuItem mnuItemMosaicoHorizontal = new ToolStripMenuItem("MOSAICO HORIZONTAL");
            //ToolStripMenuItem mnuItemCascada = new ToolStripMenuItem("CASCADA");
            //ToolStripSeparator Linea = new ToolStripSeparator();

            MenuVentana.DropDownItems.Add(new ToolStripMenuItem("MOSAICO VERTICAL", null, new EventHandler(mnuItemMosaicoVertical_click)));
            MenuVentana.DropDownItems.Add(new ToolStripMenuItem("MOSAICO HORIZONTAL", null, new EventHandler(mnuItemMosaicoHorizontal_click)));
            MenuVentana.DropDownItems.Add(new ToolStripMenuItem("CASCADA", null, new EventHandler(mnuItemCascada_click)));
            MenuVentana.DropDownItems.Add(new ToolStripSeparator());
            MenuVentana.DropDownItems.Add(mnuItemRecientes);
            
            //mnuItemMosaicoVertical.Click += new EventHandler(mnuItemMosaicoVertical_click);
            //mnuItemMosaicoHorizontal.Click += new EventHandler(mnuItemMosaicoHorizontal_click);
            //mnuItemCascada.Click += new EventHandler(mnuItemCascada_click);
            mnuItemRecientes.Enabled = false;
        }

        void CerrarTodos()
        {
            if (this.MdiChildren.Count() > 0)
            {
                foreach (Form item in this.MdiChildren)
                {
                    item.Close();
                }
            }
        }

        void BorrarTemporales()
        {
            try
            {
                if (Directory.Exists(@"C:\AmazonErp\ArchivosTemporales"))
                {
                    List<String> ListaArchivos = new List<String>(Directory.GetFiles(@"C:\AmazonErp\ArchivosTemporales"));//, "*.pdf"));

                    if (ListaArchivos.Count > Variables.Cero)
                    {
                        foreach (String filePath in ListaArchivos)
                        {
                            Global.EliminarTemporal(filePath);
                            //File.Delete(filePath);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AgregarMenuItemReciente(String Titulo, String Nombre)
        {
            mnuItemRecientes.Enabled = true;
            ToolStripMenuItem ItemReciente = new ToolStripMenuItem(Titulo)
            {
                Name = Titulo,
                AccessibleName = Nombre
            };

            mnuItemRecientes.DropDownItems.Add(ItemReciente);

            //Agregando el Evento click...
            ItemReciente.Click += new EventHandler(EjecutarMenu);
        }

        public void QuitarMenuItemReciente(String Titulo)
        {
            mnuItemRecientes.DropDownItems.RemoveByKey(Titulo);
            
            if (mnuItemRecientes.DropDownItems.Count == Variables.Cero)
            {
                mnuItemRecientes.Enabled = false;
            }
        }

        #endregion

        #region Eventos de Usuario

        void mnuItemMosaicoVertical_click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        void mnuItemMosaicoHorizontal_click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        void mnuItemCascada_click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else if (e.Cancelled == true)
            {
                Global.MensajeComunicacion("La operación ha sido cancelada.");
            }
            else
            {
                msPrincipal.Refresh();
            }

            _bw.Dispose();
            TsslCarga.Visible = false;
            TspbProgreso.Visible = false;
            toolStrip1.Enabled = true;
            msPrincipal.Enabled = true;
            UseWaitCursor = false;
            Cursor = Cursors.Default;
        }

        private void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                UseWaitCursor = true;
                TsslCarga.Visible = true;
                toolStrip1.Enabled = false;
                msPrincipal.Enabled = false;

                for (int i = 1; i <= 100; i++)
                {
                    Thread.Sleep(40);
                    _bw.ReportProgress(i);

                    if (i == 25)
                    {
                        CargaVariables();
                    }
                    else if (i == 50)
                    {
                        CargaMenu();
                    }
                    else if (i == 75)
                    {
                        CargarFondo();
                    }
                    else if (i == 98)
                    {
                        DateTime fechaActual = VariablesLocales.FechaHoy;

                        if (fechaActual.Day == 1 || fechaActual.Day == 2 || fechaActual.Day == 3 || fechaActual.Day == 4 || fechaActual.Day == 5)
                        {
                            int mesActual = fechaActual.Month;
                            int anioActual = fechaActual.Year;
                            int mesAnterior = fechaActual.Month - 1;
                            int anioAnterior = fechaActual.Year;

                            if (mesActual == 1)
                            {
                                mesAnterior = 12;
                                anioAnterior = anioActual - 1;
                            }

                            if (anioActual == anioAnterior)
                            {
                                AgenteAlmacen.Proxy.PasarStock(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, anioAnterior.ToString(), mesAnterior.ToString("00"), anioActual.ToString(), mesActual.ToString("00")); 
                            }
                        }
                    }

                    if (_bw.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                }

                //if (VariablesLocales.PeriodoContable != null)
                //{
                //    tsslUsuario.Text = "Usuario: " + VariablesLocales.SesionUsuario.Credencial + "      Empresa: " + VariablesLocales.SesionUsuario.Empresa.NombreComercial + " - Local: " + VariablesLocales.SesionLocal.Nombre + "      Periodo: " + VariablesLocales.PeriodoContable.AnioPeriodo + " - " + VariablesLocales.PeriodoContable.MesPeriodo;
                //}
                //else
                //{
                tsslUsuario.Text = "Usuario: " + VariablesLocales.SesionUsuario.Credencial + "      Empresa: " + VariablesLocales.SesionUsuario.Empresa.NombreComercial + " - Local: " + VariablesLocales.SesionLocal.Nombre;// + "      Periodo: No se aperturado.";
                //    Global.MensajeAdvertencia("No Existe Apertura en Esta Fecha");
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void _bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TsslCarga.Text = "Cargando " + e.ProgressPercentage.ToString() + "%";
            TspbProgreso.Value = e.ProgressPercentage;
        }

        #endregion

        #region Eventos

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Cerrará la Aplicacion?", "¿Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    //CerrarTodos();
                    BorrarTemporales();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void tssbSalir_Click(object sender, EventArgs e)
        {
            try
            {
                CerrarTodos();
                BorrarTemporales();
                Application.Exit();
            }
            catch (IOException)
            {
                throw;
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                //CargaVariables();
                //CargaMenu();
                //CargarFondo();

                //if (VariablesLocales.PeriodoContable != null)
                //{
                //    tsslUsuario.Text = "Usuario: " + VariablesLocales.SesionUsuario.Credencial + "      Empresa: " + VariablesLocales.SesionUsuario.Empresa.NombreComercial + " - Local: " + VariablesLocales.SesionLocal.Nombre + "      Periodo: " + VariablesLocales.PeriodoContable.AnioPeriodo + " - " + VariablesLocales.PeriodoContable.MesPeriodo;
                //}
                //else
                //{
                //    tsslUsuario.Text = "Usuario: " + VariablesLocales.SesionUsuario.Credencial + "      Empresa: " + VariablesLocales.SesionUsuario.Empresa.NombreComercial + " - Local: " + VariablesLocales.SesionLocal.Nombre + "      Periodo: No se aperturado.";
                //    Global.MensajeAdvertencia("No Existe Apertura en Esta Fecha");
                //}
                _bw.RunWorkerAsync();
                VariablesLocales.AnchoMdi = this.Width;
                VariablesLocales.AltoMdi = this.Height;
                
                Text = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - Sistema Integrado de Gestión y Soporte";
                
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsbTipoCambio_Click(object sender, EventArgs e)
        {
            try
            {
                SunatTica oTicaPorDia = new SunatTica();
                List<TipoCambioE> oListaTipoCambios = new List<TipoCambioE>();
                DateTime FechaActual = VariablesLocales.FechaHoy;
                String sDia = FechaActual.ToString("dd");
                String sCompra = String.Empty;
                String sVenta = String.Empty;

                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTipoCambioDiario);

                if (oFrm != null)
                {
                    Global.MensajeComunicacion("La ventana se encuentra abierta");

                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                if (oTicaPorDia.ObtenerPorFecha(FechaActual.Day, FechaActual.Month, FechaActual.Year))
                {
                    sCompra = oTicaPorDia.Compra.ToString();
                    sVenta = oTicaPorDia.Venta.ToString();

                    oFrm = new frmTipoCambioDiario(sCompra, sVenta);
                    oFrm.ShowDialog();
                }
                else
                {
                    if (Global.MensajeConfirmacion(String.Format("Aun no existe Tipo de Cambio para esta fecha {0} en Sunat.\n\rDesea buscar el Tipo de Cambio de la fecha anterior", FechaActual.ToString("dd/MM/yyyy"))) == DialogResult.No)
                    {
                        return;
                    }

                    TipoCambioE oTicaBd = null;

                    for (Int32 i = 0; i < 4; i++)
                    {
                        FechaActual = FechaActual.AddDays(-i);
                        oTicaBd = new GeneralesServiceAgent().Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, FechaActual.ToString("yyyyMMdd"));

                        if (oTicaBd != null && oTicaBd.valVenta != Variables.Cero && oTicaBd.valCompra != Variables.Cero)
                        {
                            Global.MensajeComunicacion(String.Format("El Tipo de Cambio ingresado es de la fecha {0}.", FechaActual.ToString("dd/MM/yyyy")));

                            oTicaBd.idMoneda = Variables.Dolares;
                            oTicaBd.fecCambio = FechaActual.ToString("yyyyMMdd");

                            oListaTipoCambios.Add(oTicaBd);
                            break;
                        }
                        else
                        {
                            oTicaBd = new TipoCambioE();
                            oTicaBd.idMoneda = Variables.Dolares;
                            oTicaBd.fecCambio = FechaActual.ToString("yyyyMMdd");

                            oListaTipoCambios.Add(oTicaBd);
                            FechaActual = VariablesLocales.FechaHoy.Date;
                        }
                    }

                    foreach (TipoCambioE item in oListaTipoCambios)
                    {
                        item.valVenta = oTicaBd.valVenta;
                        item.valCompra = oTicaBd.valCompra;
                        item.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        item.valVentaCaja = Variables.ValorCeroDecimal;
                        item.valCompraCaja = Variables.ValorCeroDecimal;
                    }

                    if (oListaTipoCambios.Count > Variables.Cero)
                    {
                        new GeneralesServiceAgent().Proxy.GrabarTipoCambioMasivo(oListaTipoCambios);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message != "Referencia a objeto no establecida como instancia de un objeto.")
                {
                    Global.MensajeError(ex.Message);
                }
                else
                {
                    Global.MensajeError(ex.Message);
                }
            }
        }

        private void tsbConsultaRuc_Click(object sender, EventArgs e)
        {
            Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmBuscarRuc);

            if (oFrm != null)
            {
                Global.MensajeComunicacion("La ventana se encuentra abierta.");

                if (oFrm.WindowState == FormWindowState.Minimized)
                {
                    oFrm.WindowState = FormWindowState.Normal;
                }

                oFrm.BringToFront();
                return;
            }

            oFrm = new frmBuscarRuc("Menu")
            {
                MdiParent = (FrmMain)this.MdiParent
            };
            oFrm.Show();
        }

        private void tsbActualizarVariables_Click(object sender, EventArgs e)
        {
            try
            {
                CargaVariables();
                Global.MensajeComunicacion("Se cargaron correctamente...");
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void TsbPtoVta_Click(object sender, EventArgs e)
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPuntoVentas);

                if (oFrm != null)
                {
                    Global.MensajeComunicacion("La ventana se encuentra abierta.");

                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmPuntoVentas()
                {
                    MdiParent = this
                };
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void TsmiSubFactura_Click(object sender, EventArgs e)
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmListadoFacturasUf);

                if (oFrm != null)
                {
                    Global.MensajeComunicacion("La ventana se encuentra abierta.");

                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmListadoFacturasUf()
                {
                    MdiParent = this
                };
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void TsmiSubBoletas_Click(object sender, EventArgs e)
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmListadoBoletasUf);

                if (oFrm != null)
                {
                    Global.MensajeComunicacion("La ventana se encuentra abierta.");

                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmListadoBoletasUf()
                {
                    MdiParent = this
                };
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
