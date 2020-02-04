using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using Infraestructura.Recursos;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Almacen
{
    public partial class frmOrdenDeCompra : FrmMantenimientoBase
    {

        #region Constructores

        public frmOrdenDeCompra()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            Global.AjustarResolucion(this);
            FormatoGrid(dgvDetalleOrden, true, false, 28);
            LlenarCombos();
        }

        //Nuevo
        public frmOrdenDeCompra(String TipoOrden_)
            : this()
        {
            Orden = TipoOrden_;
        }

        //Edición
        public frmOrdenDeCompra(OrdenCompraE oOrdenCompraTmp)
            : this()
        {
            oOrdenCompra = AgenteAlmacen.Proxy.ObtenerOrdenDeCompraCompleto(oOrdenCompraTmp.idEmpresa, oOrdenCompraTmp.idOrdenCompra);
        }

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        String Orden = String.Empty;
        OrdenCompraParametrosE oOrdenCompraParam = new AlmacenServiceAgent().Proxy.ObtenerOrdenCompraParam(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
        OrdenCompraE oOrdenCompra = null;
        String TipoPartida = String.Empty;
        Int32 Opcion = 0;
        Boolean BloquearDet = false;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //Monedas
            List<MonedasE> listaMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.LlenarCombos<MonedasE>(cboMonedas, (from x in listaMonedas orderby x.idMoneda select x).ToList(), "idMoneda", "desMoneda");

            //Origen
            List<ParTabla> ListarOrigen = AgenteGeneral.Proxy.ListarParTablaPorGrupo((Int32)EnumParTabla.OrigenOrdenCompra, "");
            ListarOrigen.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione });
            ComboHelper.RellenarCombos<ParTabla>(cboOrigen, (from x in ListarOrigen orderby x.IdParTabla select x).ToList(), "idParTabla", "Nombre", false);

            //Modalidad
            List<ParTabla> ListarModalidad = AgenteGeneral.Proxy.ListarParTablaPorGrupo((Int32)EnumParTabla.ModalidadOrdenCompra, "");
            ListarModalidad.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione });
            ComboHelper.RellenarCombos<ParTabla>(cboModalidad, (from x in ListarModalidad orderby x.IdParTabla select x).ToList(), "idParTabla", "Nombre", false);

            //Tipo Compra Nacional o Extranjero
            cboTipoCompra.DataSource = Global.CargarTipoCompra();
            cboTipoCompra.ValueMember = "id";
            cboTipoCompra.DisplayMember = "Nombre";

            //Modo de Compra
            cboModoCompra.DataSource = Global.CargarModoCompra();
            cboModoCompra.ValueMember = "id";
            cboModoCompra.DisplayMember = "Nombre";

            //Tipo de Compra
            cboTipoOrdenCompra.DataSource = Global.CargarTipoOrdenCompra();
            cboTipoOrdenCompra.ValueMember = "id";
            cboTipoOrdenCompra.DisplayMember = "Nombre";
        }

        void LLenaComboTipoArticulo()
        {   
            if (cboTipoOrdenCompra.SelectedValue.ToString() == "9")
            {
                //Tipo de Articulo
                List<ParTabla> ListarTipos1 = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
                ComboHelper.RellenarCombos<ParTabla>(cboTipoArticulo, (from x in ListarTipos1
                                                                       where (x.NemoTecnico == "O10")
                                                                       orderby x.IdParTabla
                                                                       select x).ToList(), "idParTabla", "Nombre", false);
                cboTipoArticulo.Enabled = false;
            }
            else
            {
                List<ParTabla> ListarTipos = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
                ComboHelper.RellenarCombos<ParTabla>(cboTipoArticulo, (from x in ListarTipos
                                                                       where (x.NemoTecnico == "MER" || x.NemoTecnico == "PT") ||
                                                                       (x.NemoTecnico == "MAPRI" || x.NemoTecnico == "ENV") ||
                                                                       (x.NemoTecnico == "MAAUX" || x.NemoTecnico == "SUM") ||
                                                                       (x.NemoTecnico == "REP" || x.NemoTecnico == "EMB") ||
                                                                       (x.NemoTecnico == "SUBP" || x.NemoTecnico == "DEDE") ||
                                                                       (x.NemoTecnico == "O1" || x.NemoTecnico == "O2") ||
                                                                       (x.NemoTecnico == "O3" || x.NemoTecnico == "O4") ||
                                                                       (x.NemoTecnico == "O5")
                                                                       orderby x.IdParTabla
                                                                       select x).ToList(), "idParTabla", "Nombre", false);
                cboTipoArticulo.Enabled = true;
            }
        }

        void DatosGrabacion()
        {
            if (!String.IsNullOrEmpty(txtNroRequisicion.Text))
            {
                oOrdenCompra.numRequisicion = txtNroRequisicion.Text;
            }
            else
            {
                oOrdenCompra.numRequisicion = String.Empty;
            }

            if (!String.IsNullOrEmpty(txtNroCotizacion.Text))
            {
                oOrdenCompra.numCotizacion = txtNroCotizacion.Text;
            }
            else
            {
                oOrdenCompra.numCotizacion = String.Empty;
            }

            if (!String.IsNullOrEmpty(txtRazonSocial.Text))
            {
                oOrdenCompra.idProveedor = Convert.ToInt32(txtIdProveedor.Text);
                oOrdenCompra.RUC = txtRuc.Text;
                oOrdenCompra.RazonSocial = txtRazonSocial.Text;
            }
            else
            {
                oOrdenCompra.idProveedor = Variables.Cero;
                oOrdenCompra.RUC = String.Empty;
                oOrdenCompra.RazonSocial = String.Empty;
            }

            oOrdenCompra.TipoOrdenCompra = Convert.ToString(cboTipoOrdenCompra.SelectedValue);
            oOrdenCompra.tipOrdenCompra = Convert.ToInt32(cboTipoArticulo.SelectedValue);
            oOrdenCompra.tipSecuenciaFlujo = Convert.ToInt32(cboOrigen.SelectedValue);
            oOrdenCompra.tipModalCompra = Convert.ToInt32(cboModalidad.SelectedValue);

            if (!String.IsNullOrEmpty(txtDesSolicitante.Text))
            {
                oOrdenCompra.idCCostos = txtCodSolicitante.Text;
            }
            else
            {
                oOrdenCompra.idCCostos = String.Empty;
            }

            oOrdenCompra.fecEmision = dtpFecEmision.Value.Date;

            if (!String.IsNullOrEmpty(txtDesPresupuesto.Text))
            {
                oOrdenCompra.tipPartidaPresu = TipoPartida;
                oOrdenCompra.codPartidaPresu = txtCodPresupuesto.Text;
                oOrdenCompra.indConPresu = true;
            }
            else
            {
                oOrdenCompra.tipPartidaPresu = String.Empty;
                oOrdenCompra.codPartidaPresu = String.Empty;
                oOrdenCompra.indConPresu = false;
            }

            oOrdenCompra.idMoneda = cboMonedas.SelectedValue.ToString();
            oOrdenCompra.fecRequerida = dtFecRequerida.Value.Date;

            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                if (Convert.ToInt32(cboOrigen.SelectedValue) == (Int32)EnumOrigenCompras.ConRequision)
                {
                    oOrdenCompra.tipEstado = EnumEstadoOC.PN.ToString();
                }
                else if (Convert.ToInt32(cboOrigen.SelectedValue) == (Int32)EnumOrigenCompras.ConAdjudicacion)
                {
                    oOrdenCompra.tipEstado = EnumEstadoOC.PN.ToString();
                }
                else if (Convert.ToInt32(cboOrigen.SelectedValue) == (Int32)EnumOrigenCompras.SinRequesicion)
                {
                    oOrdenCompra.tipEstado = EnumEstadoOC.PN.ToString();
                }

                oOrdenCompra.tipEstadoAtencion = EnumEstadoAtencionOC.PN.ToString();
                oOrdenCompra.tipEstadoPorFacturar = EnumEstadoAtencionOC.PN.ToString(); 
            }

            oOrdenCompra.MontoRecepFactura = 0;
            oOrdenCompra.numPlazoPago = Convert.ToInt32(txtPlazoPago.Text);
            oOrdenCompra.numPlazoEntrega = Convert.ToInt32(txtPlazoEntrega.Text);
            
            if (!String.IsNullOrEmpty(txtDesFormaPago.Text))
            {
                oOrdenCompra.tipFormaPago = Convert.ToInt32(txtIdFormaPago.Text);
                oOrdenCompra.desFormaPago = txtDesFormaPago.Text; 
            }
            else
            {
                oOrdenCompra.tipFormaPago = Variables.Cero;
                oOrdenCompra.desFormaPago = String.Empty; 
            }

            oOrdenCompra.impVenta = Convert.ToDecimal(txtSubTotal.Text);
            oOrdenCompra.porIsc = Convert.ToDecimal(txtPorIsc.Text);
            oOrdenCompra.impIsc = Convert.ToDecimal(txtIsc.Text);
            oOrdenCompra.porIgv = Convert.ToDecimal(txtPorIgv.Text);
            oOrdenCompra.impIgv = Convert.ToDecimal(txtIgv.Text);
            oOrdenCompra.impTotal = Convert.ToDecimal(txtTotal.Text);
            oOrdenCompra.Observacion = txtObservacion.Text;

            if (Convert.ToInt32(cboModalidad.SelectedValue) == (Int32)EnumModalidadOC.ComprasCS && !String.IsNullOrEmpty(txtNroLicitacion.Text))
            {
                oOrdenCompra.numLicitacion = txtNroLicitacion.Text;
                oOrdenCompra.indLicitacion = true;
            }
            else
            {
                oOrdenCompra.numLicitacion = String.Empty;
                oOrdenCompra.indLicitacion = false;
            }

            oOrdenCompra.UsuarioAprobacion = String.Empty;
            oOrdenCompra.fecAprobacion = (Nullable<DateTime>)null;
            oOrdenCompra.tipCompra = cboTipoCompra.SelectedValue.ToString();
            oOrdenCompra.indIngAlm = chkIndAlmacen.Checked;

            if (chkIndCampana.Checked)
            {
                oOrdenCompra.indCampana = true;
                oOrdenCompra.codCampana = Convert.ToInt32(txtIdCampana.Text);
            }
            else
            {
                oOrdenCompra.indCampana = false;
                oOrdenCompra.codCampana = Variables.Cero;
            }

            oOrdenCompra.ModoCompra = cboModoCompra.SelectedValue.ToString();
            oOrdenCompra.idAlmacenEntrega = Convert.ToInt32(cboAlmacen.SelectedValue);
            oOrdenCompra.LugarEntrega = txtLugarEntrega.Text;

            oOrdenCompra.Via = String.Empty;
            oOrdenCompra.Seguro = String.Empty;
            oOrdenCompra.SemanaEmbarqueA = Variables.Cero;
            oOrdenCompra.SemanaEmbarqueDe = Variables.Cero;
            oOrdenCompra.PuertoDescarga = String.Empty;
            oOrdenCompra.CondicionEntrega = String.Empty;
            oOrdenCompra.CondicionEntrega = String.Empty;
            oOrdenCompra.codAgencia = String.Empty;
            oOrdenCompra.codContacto = string.IsNullOrEmpty(txtIdContacto.Text.Trim()) ? 0 : Convert.ToInt32(txtIdContacto.Text);
            oOrdenCompra.desResponsable = txtContactoEntrega.Text;
            oOrdenCompra.indDistribucion = chkDistribucion.Checked;

            if (!String.IsNullOrEmpty(txtNroRequerimiento.Text))
            {
                oOrdenCompra.AnioRequerimiento = dtpFecEmision.Value.ToString("yyyy");
                oOrdenCompra.PeriodoRequerimiento = dtpFecEmision.Value.ToString("MM");
                //oOrdenCompra.tipRequerimiento
                oOrdenCompra.numRequerimiento = txtNroRequerimiento.Text;
            }
            else
            {
                oOrdenCompra.AnioRequerimiento = String.Empty;
                oOrdenCompra.PeriodoRequerimiento = String.Empty;
                oOrdenCompra.tipRequerimiento = String.Empty;
                oOrdenCompra.numRequerimiento = String.Empty;
            }

            oOrdenCompra.fecAnulacion = (Nullable<DateTime>)null;

            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oOrdenCompra.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oOrdenCompra.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void SumarTotales()
        {
            if (oOrdenCompra != null && oOrdenCompra.ListaOrdenesCompras != null)
            {
                Decimal ValorVenta = Decimal.Round((from x in oOrdenCompra.ListaOrdenesCompras select x.impVentaItem).Sum(), 2);
                Decimal Dscto = Decimal.Round((from x in oOrdenCompra.ListaOrdenesCompras select x.impDscto).Sum(), 2);
                Decimal ValorIsc = Decimal.Round((from x in oOrdenCompra.ListaOrdenesCompras select x.impIsc).Sum(), 2);
                Decimal ValorIgv = Decimal.Round((from x in oOrdenCompra.ListaOrdenesCompras select x.impIgv).Sum(), 2);
                Decimal ValorTotal = Decimal.Round((from x in oOrdenCompra.ListaOrdenesCompras select x.impTotalItem).Sum(), 2);
                
                txtSubTotal.Text = ValorVenta.ToString("N2");
                txtDescuento.Text = Dscto.ToString("N2");
                txtIsc.Text = ValorIsc.ToString("N2");
                txtIgv.Text = ValorIgv.ToString("N2");
                txtTotal.Text = ValorTotal.ToString("N2");
            }
            else
            {
                txtSubTotal.Text = "0.00";
                txtDescuento.Text = "0.00";
                txtIsc.Text = "0.00";
                txtIgv.Text = "0.00";
                txtTotal.Text = "0.00";
            }
        }

        void EditarDetalle(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                frmDetalleOrdenDeCompra oFrm = new frmDetalleOrdenDeCompra(oOrdenCompra.ListaOrdenesCompras[e.RowIndex], txtNroCompra.Text, 
                                                                            Convert.ToInt32(cboTipoArticulo.SelectedValue), cboTipoCompra.SelectedValue.ToString(), BloquearDet);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oOrdenCompraDetalle != null)
                {
                    oOrdenCompra.ListaOrdenesCompras[e.RowIndex] = oFrm.oOrdenCompraDetalle;
                    //bsDetalle.List[e.RowIndex] = oFrm.oOrdenCompraDetalle; //Otra manera...

                    //if (Convert.ToDecimal(txtPorIgv.Text) != Variables.Cero)
                    //{
                    //    oOrdenCompra.ListaOrdenesCompras[e.RowIndex].porIgv = Convert.ToDecimal(txtPorIgv.Text);
                    //    oOrdenCompra.ListaOrdenesCompras[e.RowIndex].impIgv = Decimal.Round((oOrdenCompra.ListaOrdenesCompras[e.RowIndex].impVentaItem + oOrdenCompra.ListaOrdenesCompras[e.RowIndex].impIsc) * (oOrdenCompra.ListaOrdenesCompras[e.RowIndex].porIgv / 100), 2);
                    //}

                    oOrdenCompra.ListaOrdenesCompras[e.RowIndex].impTotalItem = Decimal.Round(oOrdenCompra.ListaOrdenesCompras[e.RowIndex].impVentaItem + oOrdenCompra.ListaOrdenesCompras[e.RowIndex].impIsc + oOrdenCompra.ListaOrdenesCompras[e.RowIndex].impIgv, 2);

                    bsDetalle.DataSource = oOrdenCompra.ListaOrdenesCompras;
                    bsDetalle.ResetBindings(false);

                    SumarTotales();
                }
            }
        }

        void ValidarAuxiliar(List<Persona> oListaPersonasTmp)
        {
            if (!oListaPersonasTmp[0].Pro)
            {
                if (Global.MensajeConfirmacion("Este auxiliar no esta ingresado como Proveedor. Desea agregarlo ?") == DialogResult.Yes)
                {
                    ProveedorE oProveedor = new ProveedorE()
                    {
                        IdPersona = oListaPersonasTmp[0].IdPersona,
                        IdEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        SiglaComercial = oListaPersonasTmp[0].RazonSocial,
                        TipoProveedor = 0,
                        fecInscripcion = (Nullable<DateTime>)null,
                        fecInicioActividad = (Nullable<DateTime>)null,
                        tipConstitucion = 0,
                        tipRegimen = 0,
                        catProveedor = 0,
                        indBaja = Variables.NO,
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                    };

                    AgenteMaestro.Proxy.InsertarProveedor(oProveedor);
                }
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (oOrdenCompra == null)
                {
                    oOrdenCompra = new OrdenCompraE()
                    {
                        ListaOrdenesCompras = new List<OrdenCompraItemE>(),

                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        idLocal = VariablesLocales.SesionLocal.IdLocal,
                        UsuarioRegistro = txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial,
                        UsuarioModificacion = txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial
                    };

                    txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                    txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
                    txtPlazoPago.Text = Variables.Cero.ToString();
                    txtPlazoEntrega.Text = Variables.Cero.ToString();

                    if (VariablesLocales.oListaImpuestos != null && VariablesLocales.oListaImpuestos.Count > 0)
                    {
                        ImpuestosPeriodoE oImpuesto = VariablesLocales.oListaImpuestos.Find
                        (
                            delegate (ImpuestosPeriodoE imp)
                            {
                                return imp.idImpuesto == 1;
                            }
                        );

                        if (oImpuesto != null)
                        {
                            txtPorIgv.Text = oImpuesto.Porcentaje.ToString("N2");
                        }
                    }
                    
                    txtPorIsc.Text = Variables.ValorCeroDecimal.ToString("N2");
                    txtSubTotal.Text = Variables.ValorCeroDecimal.ToString("N2");
                    txtTotal.Text = Variables.ValorCeroDecimal.ToString("N2");
                    txtIgv.Text = Variables.ValorCeroDecimal.ToString("N2");
                    txtIsc.Text = Variables.ValorCeroDecimal.ToString("N2");

                    if (Orden == "0")
                    {
                        cboTipoOrdenCompra.Enabled = false;
                        cboTipoOrdenCompra.SelectedIndex = 0;
                    }

                    if (Orden == "1")
                    {
                        cboTipoOrdenCompra.Enabled = false;
                        cboTipoOrdenCompra.SelectedIndex = 1;
                    }

                    cboTipoOrdenCompra_SelectionChangeCommitted(new Object(), new EventArgs());

                    if (oOrdenCompraParam != null)
                    {
                        if (oOrdenCompraParam.idEmpresa != 0)
                        {
                            if (Orden == "0")
                            {
                                cboTipoArticulo.SelectedIndex = oOrdenCompraParam.tipOrdenCompra;
                            }
                            cboOrigen.SelectedIndex = oOrdenCompraParam.tipSecuenciaFlujo;
                            cboMonedas.SelectedIndex = oOrdenCompraParam.idMoneda;
                            cboModalidad.SelectedIndex = oOrdenCompraParam.tipModalCompra;
                            cboModalidad_SelectionChangeCommitted(new Object(), new EventArgs());
                        }
                    }

                    cboTipoArticulo_SelectionChangeCommitted(new Object(), new EventArgs());
                    Opcion = (Int32)EnumOpcionGrabar.Insertar;
                }
                else
                {
                    if (oOrdenCompra.ListaOrdenesCompras == null)
                    {
                        oOrdenCompra.ListaOrdenesCompras = new List<OrdenCompraItemE>();
                    }

                    chkDistribucion.CheckedChanged -= chkDistribucion_CheckedChanged;
                    txtCodSolicitante.TextChanged -= txtCodSolicitante_TextChanged;
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    txtNroCompra.Text = oOrdenCompra.numOrdenCompra;
                    chkIndCampana.Checked = oOrdenCompra.indCampana;

                    if (oOrdenCompra.indCampana)
                    {
                        txtIdCampana.Text = oOrdenCompra.codCampana.ToString();
                        txtDesCampana.Text = oOrdenCompra.desCampana;
                    }
                    else
                    {
                        txtIdCampana.Text = String.Empty;
                        txtDesCampana.Text = String.Empty;
                    }

                    if (oOrdenCompra.tipEstado == EnumEstadoOC.PN.ToString())
                    {
                        txtEstado.Text = "PENDIENTE";
                    }
                    else if (oOrdenCompra.tipEstado == EnumEstadoOC.AT.ToString())
                    {
                        txtEstado.Text = "APROBADO";
                    }
                    else if (oOrdenCompra.tipEstado == EnumEstadoOC.CE.ToString())
                    {
                        txtEstado.Text = "CERRADO";
                    }
                    else
                    {
                        txtEstado.Text = "ANULADO";
                    }

                    cboTipoOrdenCompra.SelectedValue = oOrdenCompra.TipoOrdenCompra;
                    cboTipoOrdenCompra_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboOrigen.SelectedValue = oOrdenCompra.tipSecuenciaFlujo;
                    cboModalidad.SelectedValue = oOrdenCompra.tipModalCompra;
                    cboModalidad_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboTipoCompra.SelectedValue = oOrdenCompra.tipCompra.ToString();
                    cboTipoArticulo.SelectedValue = oOrdenCompra.tipOrdenCompra;
                    cboTipoArticulo_SelectionChangeCommitted(new Object(), new EventArgs());
                    dtpFecEmision.Value = Convert.ToDateTime(oOrdenCompra.fecEmision);
                    cboMonedas.SelectedValue = oOrdenCompra.idMoneda.ToString();
                    cboModoCompra.SelectedValue = oOrdenCompra.ModoCompra.ToString();
                    txtNroCotizacion.Text = oOrdenCompra.numCotizacion;
                    txtNroRequisicion.Text = oOrdenCompra.numRequisicion;
                    txtNroRequerimiento.Text = oOrdenCompra.numRequerimiento;
                    txtNroLicitacion.Text = oOrdenCompra.numLicitacion;
                    chkDistribucion.Checked = oOrdenCompra.indDistribucion;
                    chkDistribucion_CheckedChanged(null, null);
                    txttipoCCosto.Text = oOrdenCompra.tipoCCosto;
                    txtCodSolicitante.Text = oOrdenCompra.idCCostos;
                    txtDesSolicitante.Text = oOrdenCompra.desCCostos;
                    
                    if (oOrdenCompra.idProveedor != Variables.Cero)
                    {
                        txtIdProveedor.Text = oOrdenCompra.idProveedor.ToString();
                        txtRuc.Text = oOrdenCompra.RUC;
                        txtRazonSocial.Text = oOrdenCompra.RazonSocial;
                    }
                    else
                    {
                        txtIdProveedor.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                    }

                    if (oOrdenCompra.codContacto != 0)
                    {
                        txtIdContacto.Text = Convert.ToString(oOrdenCompra.codContacto);
                        txtEmailContacto.Text = oOrdenCompra.CorreoContacto;
                        txtNomContacto.Text = oOrdenCompra.NomContacto;
                    }
                    else
                    {
                        txtIdContacto.Text = String.Empty;
                        txtEmailContacto.Text = String.Empty;
                        txtNomContacto.Text = String.Empty;
                    }

                    dtFecRequerida.Value = Convert.ToDateTime(oOrdenCompra.fecRequerida);

                    if (!String.IsNullOrEmpty(oOrdenCompra.desFormaPago) && oOrdenCompra.tipFormaPago != Variables.Cero)
                    {
                        txtIdFormaPago.Text = oOrdenCompra.tipFormaPago.ToString();
                        txtDesFormaPago.Text = oOrdenCompra.desFormaPago;
                    }
                    else
                    {
                        txtIdFormaPago.Text = String.Empty;
                        txtDesFormaPago.Text = String.Empty;
                    }

                    txtPlazoPago.Text = oOrdenCompra.numPlazoPago.ToString();
                    txtPlazoEntrega.Text = oOrdenCompra.numPlazoEntrega.ToString();

                    if (oOrdenCompra.indConPresu)
                    {
                        TipoPartida = oOrdenCompra.tipPartidaPresu;
                        txtCodPresupuesto.Text = oOrdenCompra.codPartidaPresu;
                        txtDesPresupuesto.Text = oOrdenCompra.desPartidaPresu;
                        chkIndPresupuesto.Checked = oOrdenCompra.indConPresu;
                    }

                    cboAlmacen.SelectedValue = Convert.ToInt32(oOrdenCompra.idAlmacenEntrega);
                    chkIndAlmacen.Checked = oOrdenCompra.indIngAlm;
                    txtLugarEntrega.Text = oOrdenCompra.LugarEntrega;
                    txtContactoEntrega.Text = oOrdenCompra.desResponsable;
                    txtObservacion.Text = oOrdenCompra.Observacion;

                    txtPorIgv.Text = oOrdenCompra.porIgv.ToString("N2");
                    txtPorIsc.Text = oOrdenCompra.porIsc.ToString("N2");
                    txtSubTotal.Text = oOrdenCompra.impVenta.ToString("N2");
                    txtIgv.Text = oOrdenCompra.impIgv.ToString("N2");
                    txtIsc.Text = oOrdenCompra.impIsc.ToString("N2");
                    txtTotal.Text = oOrdenCompra.impTotal.ToString("N2");

                    txtUsuarioRegistro.Text = oOrdenCompra.UsuarioRegistro;
                    txtUsuarioModificacion.Text = oOrdenCompra.UsuarioModificacion;
                    txtFechaRegistro.Text = oOrdenCompra.FechaRegistro.ToString();
                    txtFechaModificacion.Text = oOrdenCompra.FechaModificacion.ToString();

                    Opcion = (Int32)EnumOpcionGrabar.Actualizar;

                    chkDistribucion.CheckedChanged += chkDistribucion_CheckedChanged;
                    txtCodSolicitante.TextChanged += txtCodSolicitante_TextChanged;
                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }

                bsDetalle.DataSource = oOrdenCompra.ListaOrdenesCompras;
                bsDetalle.ResetBindings(false);

                if (oOrdenCompra.tipEstado == "CE")
                {
                    Global.MensajeComunicacion("La O.C. se encuentra cerrada no podra hacer ninguna modificación.");
                    pnlDatos.Enabled = false;
                    BloquearDet = true;
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                }
                else if (oOrdenCompra.tipEstado == EnumEstadoOC.AN.ToString())
                {
                    Global.MensajeComunicacion("La O.C. se encuentra anulada no podra hacer ninguna modificación.");
                    pnlDatos.Enabled = false;
                    BloquearDet = true;
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                }
                else
                {
                    base.Nuevo();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Grabar()
        {
            try
            {
                bsDetalle.EndEdit();
                DatosGrabacion();

                if (!ValidarGrabacion())
                {
                    return;
                }

                if (String.IsNullOrEmpty(txtNroCompra.Text))
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        oOrdenCompra = AgenteAlmacen.Proxy.GrabarOrdenDeCompra(oOrdenCompra, EnumOpcionGrabar.Insertar);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        oOrdenCompra = AgenteAlmacen.Proxy.GrabarOrdenDeCompra(oOrdenCompra, EnumOpcionGrabar.Actualizar);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            if (chkIndCampana.Checked)
            {
                if (String.IsNullOrEmpty(txtIdCampana.Text))
                {
                    Global.MensajeFault("El check de Campaña esta habilitado, debe escoger una Campaña.");
                    return false;
                }
            }

            if (Convert.ToInt32(cboTipoArticulo.SelectedValue) == Variables.Cero)
            {
                Global.MensajeFault("Tiene que escoger el tipo de O.C.");
                cboTipoArticulo.Focus();
                return false;
            }

            if (Convert.ToInt32(cboOrigen.SelectedValue) == Variables.Cero)
            {
                Global.MensajeFault("Tiene que escoger el origen de la O.C.");
                cboOrigen.Focus();
                return false;
            }

            if (Convert.ToInt32(cboModalidad.SelectedValue) == Variables.Cero)
            {
                Global.MensajeFault("Tiene que escoger la modalidad de la O.C.");
                cboModalidad.Focus();
                return false;
            }

            if (Convert.ToInt32(cboOrigen.SelectedValue) == (Int32)EnumOrigenCompras.ConRequision)
            {
                if (String.IsNullOrEmpty(txtNroRequisicion.Text))
                {
                    Global.MensajeFault("La origen escogido te exige Nro. de Requisición.");
                    cboOrigen.Focus();
                    return false;
                }
            }

            if (Convert.ToInt32(cboModalidad.SelectedValue) == (Int32)EnumModalidadOC.ComprasCS)
            {
                if (String.IsNullOrEmpty(txtNroLicitacion.Text))
                {
                    Global.MensajeFault("La modalidad escogida te exige Nro. de Licitación.");
                    cboModalidad.Focus();
                    return false;
                }
            }

            if (chkIndPresupuesto.Checked)
            {
                if (String.IsNullOrEmpty(txtCodPresupuesto.Text))
                {
                    Global.MensajeFault("El check de Presupuesto esta habilitado, debe escoger un Presupuesto.");
                    btPresupuesto.Focus();
                    return false;
                }
            }

            if (String.IsNullOrEmpty(txtRazonSocial.Text))
            {
                Global.MensajeFault("Debe ingresar un Proveedor.");
                txtRuc.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtDesFormaPago.Text))
            {
                Global.MensajeFault("Debe colocar la forma de pago.");
                btFormaPago.Focus();
                return false;
            }

            if (cboMonedas.SelectedValue.ToString() == Variables.Cero.ToString())
            {
                Global.MensajeFault("Debe escoger una moneda.");
                cboMonedas.Focus();
                return false;
            }

            if (dtFecRequerida.Value.Date < dtpFecEmision.Value.Date)
            {
                Global.MensajeFault("La fecha requerida debe ser igual o posterior a la fecha de emisión.");
                dtFecRequerida.Focus();
                return false;
            }

            //if (Convert.ToInt32(cboAlmacen.SelectedValue) == Variables.Cero)
            //{
            //    Global.MensajeFault("Falta escoger el almacen.");
            //    cboAlmacen.Focus();
            //    return false;
            //}

            if (oOrdenCompra.ListaOrdenesCompras == null || oOrdenCompra.ListaOrdenesCompras.Count == 0)
            {
                Global.MensajeFault("No hay registros en el detalle");
                return false;
            }

            if (cboTipoOrdenCompra.SelectedValue.ToString() == "9" && !chkDistribucion.Checked)
            {
                if (String.IsNullOrEmpty(txttipoCCosto.Text))
                {
                    Global.MensajeFault("Debe ingresar un Solicitante o No Identifica tipo de CCosto.");
                    //btSolicitante.Focus();
                    return false;
                }
            }

            if (chkDistribucion.Checked)
            {
                if (oOrdenCompra.ListaDistribucion == null || oOrdenCompra.ListaDistribucion.Count == 0)
                {
                    Global.MensajeFault("El check de distribución esta habilitado, tiene que tener un Listado de Distribución");
                    return false;
                }
            }

            if (!chkDistribucion.Checked)
            {
                if (oOrdenCompra.ListaDistribucion != null)
                {
                     if (oOrdenCompra.ListaDistribucion.Count > 0)
                     {
                        Global.MensajeFault("El check de distribución esta deshabilitado pero con Registros, debe eliminarlos");
                        return false;
                     }
                }
            }

            return base.ValidarGrabacion();
        }

        public override void AgregarDetalle()
        {
            try
            {
                frmDetalleOrdenDeCompra oFrm = new frmDetalleOrdenDeCompra(Convert.ToInt32(cboTipoArticulo.SelectedValue), Convert.ToString(cboTipoCompra.SelectedValue), BloquearDet);

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    OrdenCompraItemE oItemDetalle = oFrm.oOrdenCompraDetalle;
                    Int32 numItem = Variables.ValorUno;

                    if (oOrdenCompra.ListaOrdenesCompras.Count > Variables.Cero)
                    {
                        numItem = Convert.ToInt32(oOrdenCompra.ListaOrdenesCompras.Max(mx => mx.numItem)) + 1;
                    }

                    oItemDetalle.numItem = String.Format("{0:0000}", numItem);

                    oOrdenCompra.ListaOrdenesCompras.Add(oItemDetalle);
                    bsDetalle.DataSource = oOrdenCompra.ListaOrdenesCompras;
                    bsDetalle.ResetBindings(false);

                    SumarTotales();
                    base.AgregarDetalle();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (bsDetalle.Current != null)
                {
                    if (oOrdenCompra.ListaOrdenesCompras != null && oOrdenCompra.ListaOrdenesCompras.Count > Variables.Cero)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) != DialogResult.Yes)
                            return;

                        bsDetalle.EndEdit();

                        oOrdenCompra.ListaOrdenesCompras.RemoveAt(bsDetalle.Position);
                        bsDetalle.DataSource = oOrdenCompra.ListaOrdenesCompras;
                        bsDetalle.ResetBindings(false);

                        base.QuitarDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmOrdenDeCompra_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                Nuevo();

                if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
                {
                    dgvDetalleOrden.Columns[1].Visible = true;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btFormaPago_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCondicionCompra oFrm = new frmBuscarCondicionCompra();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCondicionCompra != null)
                {
                    txtIdFormaPago.Text = oFrm.oCondicionCompra.IdParTabla.ToString();
                    txtDesFormaPago.Text = oFrm.oCondicionCompra.Nombre;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboModalidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboModalidad.SelectedValue) == (Int32)EnumModalidadOC.ComprasSS || Convert.ToInt32(cboModalidad.SelectedValue) == Variables.Cero)
            {
                txtNroLicitacion.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
            }
            else
            {
                txtNroLicitacion.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
        }

        private void cboOrigen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboOrigen.SelectedValue) != (Int32)EnumOrigenCompras.ConRequision)
            {
                txtNroRequisicion.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                btnRequisicion.Enabled = false;
            }
            else
            {
                txtNroRequisicion.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                btnRequisicion.Enabled = true;
            }
        }

        private void btPresupuesto_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarPartida oFrm = new frmBuscarPartida();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPartidaPresupuestal != null)
                {
                    TipoPartida = oFrm.oPartidaPresupuestal.tipPartidaPresu;
                    txtCodPresupuesto.Text = oFrm.oPartidaPresupuestal.codPartidaPresu;
                    txtDesPresupuesto.Text = oFrm.oPartidaPresupuestal.desPartidaPresu;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkIndPresupuesto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIndPresupuesto.Checked)
            {
                btPresupuesto.Enabled = true;
            }
            else
            {
                btPresupuesto.Enabled = false;
                txtCodPresupuesto.Text = String.Empty;
                txtDesPresupuesto.Text = String.Empty;
            }
        }

        private void chkIndCampana_CheckedChanged(object sender, EventArgs e)
        {
            btCampana.Enabled = chkIndCampana.Checked;
        }

        private void txtCodSolicitante_TextChanged(object sender, EventArgs e)
        {
            if (txtCodSolicitante.TextLength == Variables.Cero)
            {
                txttipoCCosto.Text = String.Empty;
                txtDesSolicitante.Text = String.Empty;
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            //if (txtRuc.TextLength == Variables.Cero)
            //{
                txtRazonSocial.Text = String.Empty;
                txtIdProveedor.Text = String.Empty;
            //}
        }

        private void dgvDetalleOrden_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (bsDetalle.Count > Variables.Cero)
                {
                    EditarDetalle(e);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btRequisicion_Click(object sender, EventArgs e)
        {
            frmBuscarRequisicion oFrm = new frmBuscarRequisicion();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oReq != null)
            {
                txtNroRequisicion.Text = oFrm.oReq.numRequisicion;
                List<RequisicionItemE> oReqItems = new List<RequisicionItemE>();
                oReqItems = AgenteAlmacen.Proxy.ListarRequisicionItem(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,oFrm.oReq.idRequisicion);

                RequisicionE oReq = new RequisicionE();
                oReq = AgenteAlmacen.Proxy.ObtenerRequisicion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, oFrm.oReq.idRequisicion);

                OrdenCompraItemE oRequisicionItem = new OrdenCompraItemE();
                Int32 numItem = Variables.ValorUno;

                foreach (RequisicionItemE item in oReqItems)
                {
                    if (oOrdenCompra.ListaOrdenesCompras.Count > Variables.Cero)
                    {
                        numItem = Convert.ToInt32(oOrdenCompra.ListaOrdenesCompras.Max(mx => mx.numItem)) + 1;
                    }

                    oRequisicionItem.numItem = String.Format("{0:0000}", numItem);
                    oRequisicionItem.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    oRequisicionItem.CanOrdenada = item.CantidadRequerida;
                    oRequisicionItem.impPrecioUnitario = item.MontoEstimado.Value;
                    oRequisicionItem.desLarga = item.Especificacion;
                    oRequisicionItem.idArticuloServ = item.idArticulo;
                    oRequisicionItem.Lote = "0000000";
                    oRequisicionItem.porIgv = 18;
                    oRequisicionItem.impIgv = Decimal.Round((oRequisicionItem.CanOrdenada * oRequisicionItem.impPrecioUnitario) * (oRequisicionItem.porIgv / 100), 2);
                    oRequisicionItem.impVentaItem = item.MontoTotal.Value;
                    oRequisicionItem.impTotalItem = oRequisicionItem.impIgv + oRequisicionItem.impVentaItem;

                    oRequisicionItem.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                    oRequisicionItem.FechaEntrega = VariablesLocales.FechaHoy;
                    oRequisicionItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    oRequisicionItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oRequisicionItem.FechaRegistro = VariablesLocales.FechaHoy;
                    oRequisicionItem.FechaModificacion = VariablesLocales.FechaHoy;
                    oRequisicionItem.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;

                    oRequisicionItem.desArticulo = item.DesArticulo;

                    //Debe o Haber
                    txtSubTotal.Text = oRequisicionItem.impVentaItem.ToString("N2");
                    txtIsc.Text = oRequisicionItem.impIsc.ToString("N2");
                    txtIgv.Text = oRequisicionItem.impIgv.ToString("N2");
                    txtTotal.Text = oRequisicionItem.impTotalItem.ToString("N2");

                    cboMonedas.SelectedValue = oReq.idMoneda;
                    txtCodSolicitante.Text = oReq.idCCostos;
                    txtDesSolicitante.Text = oReq.desCCostos;
                    cboTipoArticulo.SelectedValue = oReq.tipRequisicion;

                    List<AlmacenE> ListarAlmacenes = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboTipoArticulo.SelectedValue));
                    AlmacenE iniAlmacen = new AlmacenE() { idAlmacen = Variables.Cero, desAlmacen = Variables.Seleccione };
                    ListarAlmacenes.Add(iniAlmacen);
                    ComboHelper.RellenarCombos(cboAlmacen, (from x in ListarAlmacenes orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen", false);

                    cboAlmacen.SelectedValue = oReq.idAlmacenEntrega;

                    cboAlmacen_SelectionChangeCommitted(new Object(), new EventArgs());

                    txttipoCCosto.Text = Convert.ToString(oReq.tipoCCosto);
                    
                    oRequisicionItem.idUMedidaCompra = 0;
                    oRequisicionItem.porIsc = 0;
                    oRequisicionItem.impIsc = 0;
                    oRequisicionItem.porDescuento = 0;
                    oRequisicionItem.CanIngresada = 0;
                    oRequisicionItem.PartidaArancelaria = "";
                    oRequisicionItem.FechaRecepcionFinal = VariablesLocales.FechaHoy;
                    oRequisicionItem.tipEstadoAtencion = "PN";
                    oRequisicionItem.impPrecioUltimaCompra = 0;
                    oRequisicionItem.numItemRequerimiento = "";
                    oRequisicionItem.nroParteProduccion = "";

                    Int32 Articuloserv = Convert.ToInt32(oRequisicionItem.idArticuloServ);
                    //oRequisicionItem.idArticuloServ 

                    List<ArticuloServE> oListaArticulos = new List<ArticuloServE>();
                    ArticuloServE oEntidad = new ArticuloServE();
                    oEntidad = AgenteMaestro.Proxy.ObtenerArticuloServ(VariablesLocales.SesionLocal.IdEmpresa, Articuloserv);

                    //oEntidad = (from x in oListaArticulos where x.idArticulo == Articuloserv select x).FirstOrDefault();

                    if (oReq.tipoCCosto == "1")
                    {
                        oRequisicionItem.codCuenta = oEntidad.codCuentaAdm;
                    }
                    if (oReq.tipoCCosto == "2")
                    {
                        oRequisicionItem.codCuenta = oEntidad.codCuentaVta;
                    }
                    if (oReq.tipoCCosto == "3")
                    {
                        oRequisicionItem.codCuenta = oEntidad.codCuentaPro;
                    }

                    oRequisicionItem.idUMedidaCompra = oEntidad.codUniMedAlmacen;

                    oOrdenCompra.ListaOrdenesCompras.Add(oRequisicionItem);
                }

                bsDetalle.DataSource = oOrdenCompra.ListaOrdenesCompras;
                bsDetalle.ResetBindings(false);
            }
        }

        private void btContacto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtIdProveedor.Text) && txtIdProveedor.Text != "0")
                {
                    frmBuscarContacto oFrm = new frmBuscarContacto(Convert.ToInt32(txtIdProveedor.Text));

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oContactos != null)
                    {
                        txtIdContacto.Text = Convert.ToString(oFrm.oContactos.idPersona);
                        txtNomContacto.Text = oFrm.oContactos.Nombres + " " + oFrm.oContactos.ApePaterno + " " + oFrm.oContactos.ApeMaterno;
                        txtEmailContacto.Text = oFrm.oContactos.Correo1;
                    } 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btCotizacion_Click(object sender, EventArgs e)
        {

        }

        private void txtRuc_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRuc.Text.Trim()) && string.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtIdProveedor.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdProveedor.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        btContacto.Focus();
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtIdProveedor.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtIdProveedor.Text = string.Empty;
            txtRuc.Text = string.Empty;
        }

        private void txtRazonSocial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && string.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtIdProveedor.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdProveedor.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        btContacto.Focus();
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtIdProveedor.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboTipoArticulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //Almacenes
                List<AlmacenE> ListarAlmacenes = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboTipoArticulo.SelectedValue));
                AlmacenE iniAlmacen = new AlmacenE() { idAlmacen = Variables.Cero, desAlmacen = Variables.Seleccione };
                ListarAlmacenes.Add(iniAlmacen);
                ComboHelper.RellenarCombos(cboAlmacen, (from x in ListarAlmacenes orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen", false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboTipoCompra_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboTipoCompra.SelectedIndex == 1)
            {
                txtPorIgv.Text = "0.00";

                foreach (OrdenCompraItemE item in oOrdenCompra.ListaOrdenesCompras)
                {
                    item.porIgv = 0;
                    item.impIgv = 0;
                    item.impTotalItem = Decimal.Round(item.impVentaItem + item.impIsc + item.impIgv, 2);
                }

                bsDetalle.DataSource = oOrdenCompra.ListaOrdenesCompras;
                bsDetalle.ResetBindings(false);
                SumarTotales();
            }

            if (cboTipoCompra.SelectedIndex == 0)
            {
                ImpuestosPeriodoE oImpuestoIgv = (from x in VariablesLocales.oListaImpuestos where x.idImpuesto == 1 select x).SingleOrDefault();
                txtPorIgv.Text = oImpuestoIgv.Porcentaje.ToString("N2");

                foreach (OrdenCompraItemE item in oOrdenCompra.ListaOrdenesCompras)
                {
                    item.porIgv = Convert.ToDecimal(txtPorIgv.Text);
                    item.impIgv = item.indIgv ? Decimal.Round((item.impVentaItem + item.impIsc) * (item.porIgv / 100), 2) : 0;
                    item.impTotalItem = Decimal.Round(item.impVentaItem + item.impIsc + item.impIgv, 2);
                }

                bsDetalle.DataSource = oOrdenCompra.ListaOrdenesCompras;
                bsDetalle.ResetBindings(false);
                SumarTotales();
            }
        }

        private void cboTipoOrdenCompra_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LLenaComboTipoArticulo();

            if (cboTipoOrdenCompra.SelectedValue.ToString() == "9")
            {
                cboTipoArticulo.Enabled = false;
                chkIndAlmacen.Enabled = false;
                cboAlmacen.Enabled = false;

                chkDistribucion.Enabled = true;
                txtCodSolicitante.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                btDistribucion.Enabled = true;
            }

            if (cboTipoOrdenCompra.SelectedValue.ToString() == "1")
            {
                cboTipoArticulo.Enabled = true;
                chkIndAlmacen.Enabled = true;
                cboAlmacen.Enabled = true;

                chkDistribucion.Enabled = false;
                //txtCodSolicitante.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                //btDistribucion.Enabled = false;
                txtCodSolicitante.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                btDistribucion.Enabled = true;
            }
        }

        private void cboAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AlmacenE Almacen = AgenteAlmacen.Proxy.ObtenerAlmacen(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboAlmacen.SelectedValue));

            if (Almacen != null)
            {
                txtLugarEntrega.Text = Almacen.Direccion;

            }
            else
            {
                txtLugarEntrega.Text = "";
            }
        }

        private void btCampana_Click(object sender, EventArgs e)
        {

        }

        private void chkDistribucion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDistribucion.Checked)
            {
                txtCodSolicitante.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
            else
            {
                txtCodSolicitante.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
        }

        private void btDistribucion_Click(object sender, EventArgs e)
        {
            if (chkDistribucion.Checked)
            {
                if (Convert.ToDecimal(txtSubTotal.Text) <= 0)
                {
                    chkDistribucion.Checked = false;
                    Global.MensajeFault("Tiene que tener al menos un monto para hacer la distribución.");
                    return;
                }

                if (chkDistribucion.Checked)
                {
                    frmOrdenCompraDistrib oFrm = new frmOrdenCompraDistrib(Convert.ToDecimal(txtSubTotal.Text), oOrdenCompra.ListaDistribucion);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        chkDistribucion.Checked = true;
                        oOrdenCompra.ListaDistribucion = new List<OrdenCompraDistriE>(oFrm.oListaDistribucion);
                    }
                } 
            }
            else
            {
                FrmBusquedaCentroDeCosto oFrm = new FrmBusquedaCentroDeCosto();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.CentroCosto != null)
                {
                    txtCodSolicitante.Text = oFrm.CentroCosto.idCCostos;
                    txtDesSolicitante.Text = oFrm.CentroCosto.desCCostos;
                    txttipoCCosto.Text = oFrm.CentroCosto.tipoCCosto;
                }
            }
        }

        #endregion

    }
}
