using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Recursos;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Almacen
{
    public partial class frmOperacion : FrmMantenimientoBase
    {          

        #region Contructores
        
        public frmOperacion()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        public frmOperacion(Int32 idEmpresa, Int32 idOperacion)
            :this()
        {
            oOperacion = AgenteAlmacen.Proxy.ObtenerOperacion(idEmpresa, idOperacion);
        }

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        OperacionE oOperacion = null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario
        
        void LlenarCombos()
        {
            List<ParTabla> ListaTipoAlmacen = AgenteGenerales.Proxy.ListarParTablaPorNemo("TIPART");//ListarParTablaPorGrupo(Convert.ToInt32(EnumParTabla.TipoAlmacen), "");
            ParTabla p = new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione };
            ListaTipoAlmacen.Add(p);
            ComboHelper.RellenarCombos<ParTabla>(cboTipoAlmacen, (from x in ListaTipoAlmacen orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);

            List<ParTabla> ListarTipoMovimiento = AgenteGenerales.Proxy.ListarParTablaPorNemo("TIPMOVALM");
            ComboHelper.RellenarCombos<ParTabla>(cboTipoMovimiento, (from x in ListarTipoMovimiento
                                                                     where (x.NemoTecnico == "ING") ||
                                                                           (x.NemoTecnico == "EGR")
                                                                     orderby x.IdParTabla
                                                                     select x).ToList(), "IdParTabla", "Nombre", false);
        }

        void GuardarDatos()
        {
            oOperacion.tipAlmacen = Convert.ToInt32(cboTipoAlmacen.SelectedValue);
            oOperacion.tipMovimiento = Convert.ToInt32(cboTipoMovimiento.SelectedValue);
            oOperacion.codSunat = txtCodSunat.Text;
            oOperacion.orden = txtOrd.Text;
            oOperacion.desOperacion = txtDesOperacion.Text;
            oOperacion.desDetalle = txtDesDetalle.Text;

            oOperacion.indValorizar = chkManual.Checked;
            oOperacion.indServicio = chkServicio.Checked;
            oOperacion.automatico = chkAutomatico.Checked;
            oOperacion.indOrdentrabajo = chkOT.Checked;
            oOperacion.indTransferencia = chkTransferencia.Checked;
            oOperacion.indConsumo = chkConsumo.Checked;
            oOperacion.indDocumentoAutomatico = chkDocTrans.Checked;
            oOperacion.indProveedor = chkProveedor.Checked;
            oOperacion.indCliente = chkCliente.Checked;
            oOperacion.indEstadistico = chkEstadistico.Checked;
            oOperacion.indOrdenCompra = chkOrden.Checked;
            oOperacion.indConversion = chkConversion.Checked;
            oOperacion.indDevolucion = chkDevolucion.Checked;
            oOperacion.indDocumento = chkDocumento.Checked;
            oOperacion.indReferencia = chkReferencia.Checked;
            oOperacion.indCostoVenta = chkCostoVenta.Checked;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oOperacion == null)
            {
                oOperacion = new OperacionE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                };

                cboTipoAlmacen.SelectedValue = Convert.ToInt32(oOperacion.idOperacion);
                cboTipoMovimiento.SelectedValue = Convert.ToInt32(oOperacion.tipAlmacen);
                txtUsuRegistra.Text = oOperacion.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oOperacion.FechaRegistro = VariablesLocales.FechaHoy;
                txtRegistro.Text = oOperacion.FechaRegistro.ToString();
                txtUsuModifica.Text = oOperacion.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oOperacion.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oOperacion.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                cboTipoAlmacen.SelectedValue = Convert.ToInt32(oOperacion.tipAlmacen);
                cboTipoMovimiento.SelectedValue = Convert.ToInt32(oOperacion.tipMovimiento);
                txtIdOperacion.Text = Convert.ToString(oOperacion.idOperacion);

                txtDesDetalle.Text = oOperacion.desDetalle;
                txtDesOperacion.Text = oOperacion.desOperacion;
                txtOrd.Text = oOperacion.orden;
                txtCodSunat.Text = oOperacion.codSunat;

                chkManual.Checked = oOperacion.indValorizar;
                chkServicio.Checked = oOperacion.indServicio;
                chkAutomatico.Checked = oOperacion.automatico;
                chkOT.Checked = oOperacion.indOrdentrabajo;
                chkTransferencia.Checked = oOperacion.indTransferencia;
                chkConsumo.Checked = oOperacion.indConsumo;
                chkDocTrans.Checked = oOperacion.indDocumentoAutomatico;
                chkProveedor.Checked = oOperacion.indProveedor;
                chkCliente.Checked = oOperacion.indCliente;
                chkEstadistico.Checked = oOperacion.indEstadistico;
                chkOrden.Checked = oOperacion.indOrdenCompra;
                chkConversion.Checked = oOperacion.indConversion;
                chkDevolucion.Checked = oOperacion.indDevolucion;
                chkDocumento.Checked = oOperacion.indDocumento;
                chkReferencia.Checked = oOperacion.indReferencia;
                chkCostoVenta.Checked = oOperacion.indCostoVenta;

                txtUsuRegistra.Text = oOperacion.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = oOperacion.FechaRegistro.ToString();
                txtUsuModifica.Text = oOperacion.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oOperacion.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oOperacion.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oOperacion != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        oOperacion = AgenteAlmacen.Proxy.InsertarOperacion(oOperacion);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                    else
                    {
                        oOperacion = AgenteAlmacen.Proxy.ActualizarOperacion(oOperacion);
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
            String Respuesta = ValidarEntidad<OperacionE>(oOperacion);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmOperacion_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        private void btSunat_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCodigoSunat oFrm = new frmBuscarCodigoSunat();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oOperacionSunat != null)
                {
                    txtCodSunat.Text = oFrm.oOperacionSunat.EquivalenciaSunat;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

    }
}
