using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Maestros;
using Entidades.Generales;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Ventas
{
    public partial class frmDetalleNumControl : frmResponseBase
    {

        #region Constructores

        public frmDetalleNumControl()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.AjustarResolucion(this);

            ToolTipAyudas();
        }

        //Nuevo
        public frmDetalleNumControl(Int32 TipoCondicion)
            :this()
        {
            idTipoCondicion = TipoCondicion;
        }

        //Edición
        public frmDetalleNumControl(NumControlDetE oDet, Int32 TipoCondicion)
            :this()
        {
            idTipoCondicion = TipoCondicion;

            if (oDet.idControl > Variables.Cero && oDet.Opcion != (Int32)EnumOpcionGrabar.Actualizar)
            {
                Detalle = AgenteVentas.Proxy.ObtenerNumControlDet(oDet.idEmpresa, oDet.idLocal, oDet.idControl, oDet.item);
            }
            else
            {
                Detalle = oDet;
            }
        }

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        public NumControlDetE Detalle = null;
        Int32 idTipoCondicion = 0;

        #endregion

        #region Procedimientos de Usuario
        
        void LlenarCombos()
        {
            //Documentos...
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(VariablesLocales.ListarDocumentoGeneral)
            {
                new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = " " + Variables.Seleccione }
            };

            ComboHelper.RellenarCombos<DocumentosE>(cboDocumentos, (from x in ListaDocumentos where x.indDocumentoVentas == true 
                                                                    || x.CodigoSunat == "09"
                                                                    orderby x.desDocumento
                                                                    select x).ToList(), "idDocumento", "desDocumento", false);
            //Estado de la serie
            cboEstadoSerie.DataSource = Global.CargarEstadoSerie();
            cboEstadoSerie.DisplayMember = "Nombre";
            cboEstadoSerie.ValueMember = "id";

            //Estado inicial del documento
            cboEstadoInicial.DataSource = Global.CargarEstadoDocumento();
            cboEstadoInicial.DisplayMember = "Nombre";
            cboEstadoInicial.ValueMember = "id";

            //Es guia
            cboEsGuia.DataSource = Global.CargarEsGuia();
            cboEsGuia.DisplayMember = "Nombre";
            cboEsGuia.ValueMember = "id";

            //Monedas
            ComboHelper.LlenarCombos<MonedasE>(cboMonedas, VariablesLocales.ListaMonedas, "idMoneda", "desMoneda");
            
            //Condiciones de acuerdo al tipo...
            List<CondicionE> ListaCondiciones = AgenteVentas.Proxy.ListarCondicionPorTipo(idTipoCondicion);
            ListaCondiciones.Add(new CondicionE() { idCondicion = Variables.Cero, desCondicion = Global.PrimeraMayuscula(Variables.Seleccione) });
            ComboHelper.LlenarCombos<CondicionE>(cboCondicion, ListaCondiciones, "idCondicion", "desCondicion");

            //Es al contado
            cboEsContado.DataSource = Global.CargarContadoCredito();
            cboEsContado.DisplayMember = "Nombre";
            cboEsContado.ValueMember = "id";

            //Transporte
            List<TransporteE> ListaTransporte = AgenteVentas.Proxy.ListarTransporteBusqueda("", "");
            ListaTransporte.Add(new TransporteE() { idTransporte = Variables.Cero, RazonSocial = Global.PrimeraMayuscula(Variables.Seleccione) });
            ComboHelper.LlenarCombos<TransporteE>(cboTransporte, ListaTransporte, "idTransporte", "RazonSocial");

            //Tipo Traslado
            List<TipoTrasladoE> ListaTipoTraslado = AgenteVentas.Proxy.ListarTipoTraslado();
            ListaTipoTraslado.Add(new TipoTrasladoE() { idTraslado = Variables.Cero, desTraslado = Global.PrimeraMayuscula(Variables.Seleccione) });
            ComboHelper.LlenarCombos<TipoTrasladoE>(cboTipoTraslado, ListaTipoTraslado, "idTraslado", "desTraslado");

            //Almacenes
            List<AlmacenE> ListaAlmacenes = new AlmacenServiceAgent().Proxy.ListarAlmacen(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, String.Empty, Variables.Cero, false, false);
            ListaAlmacenes.Add(new AlmacenE() { idAlmacen = 0, desAlmacen = Variables.Seleccione });
            ComboHelper.LlenarCombos<AlmacenE>(cboIdAlmacen, ListaAlmacenes, "idAlmacen", "desAlmacen");

            //Grupos
            cboGrupo.DataSource = Global.CargarGrupoDocumentos();
            cboGrupo.DisplayMember = "Nombre";
            cboGrupo.ValueMember = "id";

            //Lista de Precios
            List<ListaPrecioE> oListaPrecio = AgenteVentas.Proxy.ListarPrecioPorTipo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, false);
            oListaPrecio.Add(new ListaPrecioE() { idListaPrecio = Variables.Cero, Nombre = Variables.Escoger });
            ComboHelper.LlenarCombos<ListaPrecioE>(cboListaPrecio, (from x in oListaPrecio
                                                                    orderby x.idListaPrecio
                                                                    select x).ToList(), "idListaPrecio", "Nombre");

            oListaPrecio = null;
            ListaAlmacenes = null;
            ListaTipoTraslado = null;
            ListaTransporte = null;
            ListaCondiciones = null;
            ListaDocumentos = null;
        }

        void ToolTipAyudas()
        {
            Global.CrearToolTip(txtCorrelativo, "N° de documento (Correlativo).");
            Global.CrearToolTip(btBuscarCliente, "Buscar Cliente.");
            Global.CrearToolTip(btBuscarVendedor, "Buscar Vendedor.");
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (Detalle == null)
            {
                Detalle = new NumControlDetE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                    Opcion = (Int32)EnumOpcionGrabar.Insertar
                };

                cboEsGuia.SelectedValue = EnumEsGuia.N.ToString();
                txtUsuarioReg.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModi.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                dtpFecFin.Checked = false;
                dtpFecInicio.Checked = false;
            }
            else
            {
                cboDocumentos.SelectedValue = Detalle.idDocumento;
                txtSerie.Text = Detalle.Serie;
                txtCantSerie.Text = Detalle.cantDigSerie.ToString();
                txtNumInicial.Text = Detalle.numInicial;
                txtNumFinal.Text = Detalle.numFinal;
                txtCorrelativo.Text = Detalle.numCorrelativo;
                txtCantNumero.Text = Detalle.cantDigNumero.ToString();
                dtpFecInicio.Value = Detalle.fecInicio.Value;

                if (Detalle.fecFinal != null)
                {
                    dtpFecFin.Value = Detalle.fecFinal.Value;
                }
                else
                {
                    dtpFecFin.Checked = false;
                }

                cboEstadoInicial.SelectedValue = Detalle.indEstadoInicial;
                cboCondicion.SelectedValue = Detalle.idCondicion;
                txtIdVendedor.Text = Detalle.idVendedor != null ? Detalle.idVendedor != 0 ? Detalle.idVendedor.ToString() : String.Empty : String.Empty; //Detalle.idVendedor.Value.ToString();
                txtDesVendedor.Text = Detalle.nomVendedor;
                cboTransporte.SelectedValue = Convert.ToInt32(Detalle.idTransporte);
                cboMonedas.SelectedValue = Detalle.idMoneda.ToString();
                cboTipoTraslado.SelectedValue = Convert.ToInt32(Detalle.idTipTraslado);
                cboEstadoSerie.SelectedValue = Detalle.indEstadoDocu.ToString();
                cboIdAlmacen.SelectedValue = Convert.ToInt32(Detalle.idAlmacen);
                chkFlagCantUnit.Checked = Detalle.FlagCantUnit;
                cboListaPrecio.SelectedValue = Detalle.ListaPrecio;
                txtIdCliente.Text = Detalle.idCliente != null ? Detalle.idCliente != 0 ? Detalle.idCliente.ToString() : String.Empty : String.Empty;
                //txtFormato.Text = Detalle.Formato;
                cboEsGuia.SelectedValue = Detalle.EsGuia.ToString();
                txtPuntoPartida.Text = Detalle.PuntoPartida;
                txtLlegada.Text = Detalle.PuntoLlegada;
                //cboPuntoVenta.SelectedValue = Detalle.PuntoVenta.ToString(); falta agregar...
                //cboTipoAsiento.SelectedValue = Detalle.TipoAsiento.ToString(); falta agregar...
                txtCantCopias.Text = Detalle.cantCopias.ToString();
                txtCantItems.Text = Detalle.cantItems.ToString();
                txtNroCaja.Text = Detalle.numCaja;
                txtSerieCaja.Text = Detalle.numSerieCaja;
                cboEsContado.SelectedValue = Detalle.EsContado.ToString();
                chkExigirGuia.Checked = Detalle.ExigirGuia;
                chkExigirDatos.Checked = Detalle.ExigirDatos;
                cboGrupo.SelectedValue = Detalle.Grupo.ToString();
                txtCantDigitos.Text = Detalle.cantDigDecimales.ToString();
                txtCantCaracteres.Text = Detalle.cantCaracteres.ToString();
                txtOrden.Text = Detalle.Orden.ToString();

                txtUsuarioReg.Text = Detalle.UsuarioRegistro;
                txtFechaRegistro.Text = Detalle.FechaRegistro.ToString();
                txtUsuarioModi.Text = Detalle.UsuarioModificacion;
                txtFechaModificacion.Text = Detalle.FechaModificacion.ToString();

                Detalle.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        public override void Aceptar()
        {
            try
            {
                //bsBase.EndEdit();
                Detalle.idDocumento = cboDocumentos.SelectedValue.ToString();
                Detalle.Serie = txtSerie.Text;
                Detalle.cantDigSerie = Convert.ToInt32(txtCantSerie.Text);
                Detalle.numInicial = txtNumInicial.Text;
                Detalle.numFinal = txtNumFinal.Text;
                Detalle.numCorrelativo = txtCorrelativo.Text;
                Detalle.cantDigNumero = Convert.ToInt32(txtCantNumero.Text);
                Detalle.fecInicio = dtpFecInicio.Checked == true ? dtpFecInicio.Value.Date : (DateTime?)null;
                Detalle.fecFinal = dtpFecFin.Checked == true ? dtpFecFin.Value.Date : (DateTime?)null;
                Detalle.indEstadoInicial = cboEstadoInicial.SelectedValue.ToString();
                Detalle.idCondicion = Convert.ToInt32(cboCondicion.SelectedValue);
                Detalle.idVendedor = !String.IsNullOrEmpty(txtIdVendedor.Text) ? Convert.ToInt32(txtIdVendedor.Text) : (int?)null;
                Detalle.nomVendedor = txtDesVendedor.Text.Trim();
                Detalle.idTransporte = Convert.ToInt32(cboTransporte.SelectedValue) != Variables.Cero ? Convert.ToInt32(cboTransporte.SelectedValue) : (int?)null;
                Detalle.idMoneda = cboMonedas.SelectedValue.ToString();
                Detalle.idTipTraslado = Convert.ToInt32(cboTipoTraslado.SelectedValue) != Variables.Cero ? Convert.ToInt32(cboTipoTraslado.SelectedValue) : (int?)null;
                Detalle.indEstadoDocu = cboEstadoSerie.SelectedValue.ToString();
                Detalle.idAlmacen = Convert.ToInt32(cboIdAlmacen.SelectedValue) != Variables.Cero ? Convert.ToInt32(cboIdAlmacen.SelectedValue) : (int?)null;
                Detalle.FlagCantUnit = chkFlagCantUnit.Checked;
                Detalle.ListaPrecio = Convert.ToInt32(cboListaPrecio.SelectedValue) == 0 ? (int?)null : Convert.ToInt32(cboListaPrecio.SelectedValue);
                Detalle.idCliente = !String.IsNullOrEmpty(txtIdCliente.Text) ? Convert.ToInt32(txtIdCliente.Text) : (int?)null;
                Detalle.Formato = string.Empty;
                Detalle.EsGuia = cboEsGuia.SelectedValue.ToString();
                Detalle.PuntoPartida = txtPuntoPartida.Text.Trim();
                Detalle.PuntoLlegada = txtLlegada.Text.Trim();
                Detalle.PuntoVenta = String.Empty; //falta agregar...
                Detalle.TipoAsiento = String.Empty; // falta agregar...
                Detalle.cantCopias = Convert.ToInt32(txtCantCopias.Text);
                Detalle.cantItems = Convert.ToInt32(txtCantItems.Text);
                Detalle.numCaja = txtNroCaja.Text;
                Detalle.numSerieCaja = txtSerieCaja.Text;
                Detalle.EsContado = cboEsContado.SelectedValue.ToString();
                Detalle.ExigirGuia = chkExigirGuia.Checked;
                Detalle.ExigirDatos = chkExigirDatos.Checked;
                Detalle.Grupo = cboGrupo.SelectedValue.ToString();
                Detalle.cantDigDecimales = Convert.ToInt32(txtCantDigitos.Text);
                Detalle.cantCaracteres = Convert.ToInt32(txtCantCaracteres.Text);

                Detalle.desDocumento = cboDocumentos.Text;

                if (String.IsNullOrEmpty(Detalle.numCorrelativo))
                {
                    Detalle.numCorrelativo = Detalle.numInicial;
                }

                switch (Detalle.EsGuia)
                {
                    case "F":
                        Detalle.Tipo = "FACT";
                        break;

                    case "G":
                        Detalle.Tipo = "GUIA";
                        break;

                    case "E":
                        Detalle.Tipo = "EXPORT";
                        break;

                    case "S":
                        Detalle.Tipo = "SERVICIOS";
                        break;

                    default:
                        Detalle.Tipo = "OTROS";
                        break;
                }

                Int32.TryParse(txtOrden.Text, out Int32 Orden);
                Detalle.Orden = Orden;

                if (Detalle.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    Detalle.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                }
                else
                {
                    Detalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                }

                if (!ValidarGrabacion())
                {
                    return;
                }

                base.Aceptar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            String resp = ValidarEntidad<NumControlDetE>(Detalle);

            if (!String.IsNullOrEmpty(resp))
            {
                Global.MensajeComunicacion(resp);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmDetalleNumControl_Load(object sender, EventArgs e)
        {
            try
            {
                LlenarCombos();
                Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCantSerie_TextChanged(object sender, EventArgs e)
        {
            if (txtCantSerie.Text.Length > 0 && txtCantSerie.Text != Variables.Cero.ToString())
            {
                txtSerie.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);

                if (txtSerie.Text.Length > Convert.ToInt32(txtCantSerie.Text))
                {
                    txtSerie.Text = txtSerie.Text.Substring(0, Convert.ToInt32(txtCantSerie.Text));
                }
            }
            else
            {
                txtSerie.Text = String.Empty;
                txtSerie.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }
        }

        private void txtCantNumero_TextChanged(object sender, EventArgs e)
        {
            if (txtCantNumero.Text.Length > 0 && txtCantNumero.Text != Variables.Cero.ToString())
            {
                txtNumInicial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtNumFinal.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtCorrelativo.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);

                if (txtNumInicial.Text.Length > Convert.ToInt32(txtCantNumero.Text))
                {
                    txtNumInicial.Text = txtNumInicial.Text.Substring(0, Convert.ToInt32(txtCantNumero.Text));
                }

                if (txtNumFinal.Text.Length > Convert.ToInt32(txtCantNumero.Text))
                {
                    txtNumFinal.Text = txtNumFinal.Text.Substring(0, Convert.ToInt32(txtCantNumero.Text));
                }

                if (txtCorrelativo.Text.Length > Convert.ToInt32(txtCantNumero.Text))
                {
                    txtCorrelativo.Text = txtCorrelativo.Text.Substring(0, Convert.ToInt32(txtCantNumero.Text));
                }
            }
            else
            {
                txtNumInicial.Text = String.Empty;
                txtNumFinal.Text = String.Empty;
                txtNumInicial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtNumFinal.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtCorrelativo.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }
        }

        private void txtSerie_Enter(object sender, EventArgs e)
        {
            txtSerie.MaxLength = Convert.ToInt32(txtCantSerie.Text);
        }

        private void txtNumInicial_Enter(object sender, EventArgs e)
        {
            txtNumInicial.MaxLength = Convert.ToInt32(txtCantNumero.Text);
        }

        private void txtNumFinal_Enter(object sender, EventArgs e)
        {
            txtNumFinal.MaxLength = Convert.ToInt32(txtCantNumero.Text);
        }

        private void btBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBuscarClientes oFrm = new frmBuscarClientes();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCliente != null)
            {
                txtIdCliente.Text = oFrm.oCliente.idPersona.ToString();
                txtRazonSocial.Text = oFrm.oCliente.RazonSocial;
            }
        }

        private void cboDocumentos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void txtNumInicial_TextChanged(object sender, EventArgs e)
        {
            if (Detalle.Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                txtCorrelativo.Text = txtNumInicial.Text;
            }
        }

        private void btBuscarVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarVendedor oFrm = new frmBuscarVendedor();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oVendedor != null)
                {
                    txtIdVendedor.Text = oFrm.oVendedor.idPersona.ToString();
                    txtDesVendedor.Text = oFrm.oVendedor.RazonSocial;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dtpFecInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboEstadoSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void dtpFecFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        #endregion

    }
}
