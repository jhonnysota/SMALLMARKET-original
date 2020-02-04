using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;
using Entidades.Maestros;
using Entidades.Generales;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmAperturaCtaCte : FrmMantenimientoBase
    {
        public frmAperturaCtaCte()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
               LlenarCombos();
        }

         public frmAperturaCtaCte(Int32 idEmpresa, Int32 idRegistro)
            : this()
        {
            oCtaCte = AgenteTesoreria.Proxy.ObtenerAperturaCtaCte(idEmpresa, idRegistro);
        }

         #region Variables

         TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
         GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
         AperturaCtaCteE oCtaCte = null;
         String TipoPartida = String.Empty;
         Int32 opcion;

         #endregion

         #region Procedimientos de Usuario

         void EsNuevoRegistro()
         {
             if (oCtaCte == null)
             {
                 oCtaCte = new AperturaCtaCteE();

                 oCtaCte.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                 oCtaCte.numVerPlanCuenta = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                 this.Text = "N° " + oCtaCte.idRegistro.ToString() + " - Apertura Cta Cte";


                 txtUsuRegistra.Text = oCtaCte.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                 oCtaCte.FechaRegistro = VariablesLocales.FechaHoy;
                 txtRegistro.Text = oCtaCte.FechaRegistro.ToString();
                 txtUsuModifica.Text = oCtaCte.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                 oCtaCte.FechaModificacion = VariablesLocales.FechaHoy;
                 txtModifica.Text = oCtaCte.FechaModificacion.ToString();

                 opcion = (Int32)EnumOpcionGrabar.Insertar;

             }
             else
             {

                 dtpFecOp.Value = Convert.ToDateTime(oCtaCte.FechaOperacion);
                 dtpFecEm.Value = Convert.ToDateTime(oCtaCte.FechaEmision);
                 txtCodCuenta.Text = oCtaCte.CodCuenta;
                 txtidpersona.Text = Convert.ToString(oCtaCte.idPersona);
                 cboDebHab.SelectedValue = oCtaCte.indDebeHaber;
                 txtTipPartida.Text = oCtaCte.tipPartidaPresu;
                 txtCodPartida.Text = oCtaCte.codPartidaPresu;
                 txtGlosa.Text = oCtaCte.Glosa;
                 cboDocumento.SelectedValue = oCtaCte.idDocumento;
                 txtSerie.Text = oCtaCte.Serie;
                 txtNumero.Text = oCtaCte.Numero;
                 txtTica.Text = Convert.ToString(oCtaCte.TipoCambio);
                 cboMoneda.SelectedValue = oCtaCte.idMoneda;
                 txtImporte.Text = Convert.ToString(oCtaCte.importe);

                 txtUsuRegistra.Text = oCtaCte.UsuarioRegistro;
                 txtRegistro.Text = oCtaCte.FechaRegistro.ToString();
                 txtUsuModifica.Text = oCtaCte.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                 oCtaCte.FechaModificacion = VariablesLocales.FechaHoy;
                 txtModifica.Text = oCtaCte.FechaModificacion.ToString();
                 opcion = (Int32)EnumOpcionGrabar.Actualizar;

             }

             base.Nuevo();
         }

         void LlenarCombos()
         {
             // Documentos
             List<DocumentosE> ListaDocumentos = new List<DocumentosE>(VariablesLocales.ListarDocumentoGeneral);//AgenteMaestro.Proxy.ListarDocumentos();
             DocumentosE Fila = new DocumentosE();
             Fila.idDocumento = Variables.Cero.ToString();
             Fila.desDocumento = " " + Variables.Seleccione;
             ListaDocumentos.Add(Fila);
             ComboHelper.RellenarCombos<DocumentosE>(cboDocumento, (from x in ListaDocumentos orderby x.desDocumento select x).ToList(), "idDocumento", "desDocumento", false);
             //ComboHelper.RellenarCombos<DocumentosE>(cboReferencia, (from x in ListaDocumentos orderby x.desDocumento select x).ToList(), "idDocumento", "desDocumento", false);

             //debe/haber
             cboDebHab.DataSource = Global.CargarDH();
             cboDebHab.ValueMember = "id";
             cboDebHab.DisplayMember = "Nombre";

             //////Moneda///////
             List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
             MonedasE CampoInicial = new MonedasE();
             CampoInicial.idMoneda = Variables.Cero.ToString();
             CampoInicial.desMoneda = Variables.Seleccione;
             ListaMoneda.Add(CampoInicial);
             ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListaMoneda
                                                              where (x.idMoneda == Variables.Soles) ||
                                                                    (x.idMoneda == Variables.Dolares) ||
                                                                    (x.idMoneda == Variables.Cero.ToString())
                                                              orderby x.idMoneda
                                                              select x).ToList(), "idMoneda", "desMoneda", false);


         }

         void GuardarDatos()
         {
             oCtaCte.FechaOperacion = Convert.ToDateTime(dtpFecOp.Value.Date);
             oCtaCte.CodCuenta = txtCodCuenta.Text;
             oCtaCte.idPersona = Convert.ToInt32(txtidpersona.Text);
             oCtaCte.indDebeHaber = cboDebHab.SelectedValue.ToString();
             oCtaCte.tipPartidaPresu = txtTipPartida.Text;
             oCtaCte.Glosa = txtGlosa.Text;
             oCtaCte.idDocumento = cboDocumento.SelectedValue.ToString();
             oCtaCte.Serie = txtSerie.Text;
             oCtaCte.Numero = txtNumero.Text;
             oCtaCte.codPartidaPresu = txtCodPartida.Text;
             oCtaCte.FechaEmision = Convert.ToDateTime(dtpFecEm.Value.Date);
             oCtaCte.TipoCambio = Convert.ToDecimal(txtTica.Text);
             oCtaCte.idMoneda = cboMoneda.SelectedValue.ToString();
             oCtaCte.importe = Convert.ToDecimal(txtImporte.Text);



         }

         void BloquearPaneles(Boolean Flag)
         {
             pnlDatos.Enabled = Flag;
             //pnlOtros.Enabled = Flag;
             //pnlContacto.Enabled = Flag;
         }

         #endregion

         #region Procedimientos Heredados

         public override void Nuevo()
         {
             BloquearPaneles(true);
             oCtaCte = new AperturaCtaCteE();

             base.Nuevo();
         }

         public override void Grabar()
         {
             try
             {
                 if (oCtaCte != null)
                 {
                     GuardarDatos();

                     if (!ValidarGrabacion())
                     {
                         return;
                     }

                     if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                     {
                         if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                         {
                             oCtaCte = AgenteTesoreria.Proxy.InsertarAperturaCtaCte(oCtaCte);
                             Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                         }
                     }
                     else
                     {
                         if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                         {
                             oCtaCte = AgenteTesoreria.Proxy.ActualizarAperturaCtaCte(oCtaCte);
                             Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                         }
                     }
                 }
                 //base.Grabar();
                 this.DialogResult = DialogResult.OK;
                 this.Close();
             }
             catch (Exception ex)
             {
                 Global.MensajeError(ex.Message);
             }
         }

         public override void Editar()
         {
             BloquearPaneles(true);
             base.Editar();
         }

         public override void Cancelar()
         {
             BloquearPaneles(false);
             pnlAuditoria.Focus();
             base.Cancelar();
         }

         public override void Cerrar()
         {
             base.Cerrar();
         }

         public override bool ValidarGrabacion()
         {
             String Respuesta = ValidarEntidad<AperturaCtaCteE>(oCtaCte);

             if (!String.IsNullOrEmpty(Respuesta))
             {
                 Global.MensajeComunicacion(Respuesta);
                 return false;
             }

             return base.ValidarGrabacion();
         }

         #endregion

         #region Eventos

         private void frmAperturaCtaCte_Load(object sender, EventArgs e)
         {
             Grid = false;
             EsNuevoRegistro();
         }

         private void btBuscaPartida_Click(object sender, EventArgs e)
         {
             frmBuscarPartida oFrm = new frmBuscarPartida();

             if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPartidaPresupuestal != null)
             {
                 TipoPartida = oFrm.oPartidaPresupuestal.tipPartidaPresu;
                 txtTipPartida.Text = oFrm.oPartidaPresupuestal.tipPartidaPresu;
                 txtCodPartida.Text = oFrm.oPartidaPresupuestal.codPartidaPresu;
             }
         }

         private void dtpFecOp_ValueChanged(object sender, EventArgs e)
         {
             try
             {

                 if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                 {
                     DateTime Fecha = ((DateTimePicker)sender).Value;
                     TipoCambioE Tica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, Fecha.ToString("yyyyMMdd"));

                     if (Tica != null)
                     {
                         txtTica.Text = Tica.valVenta.ToString("N3");
                     }
                     else
                     {
                         txtTica.Text = Variables.ValorCeroDecimal.ToString("N3");
                         dtpFecOp.Focus();
                         Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                     }
                 }
             }
             catch (Exception ex)
             {
                 Global.MensajeError(ex.Message);
             }
         }

         private void btCuenta_Click(object sender, EventArgs e)
         {
             try
             {
                 frmBuscarCuentas oFrm = new frmBuscarCuentas();

                 if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Cuentas != null)
                 {
                     txtCodCuenta.Text = oFrm.Cuentas.codCuenta;
                 }
             }
             catch (Exception ex)
             {
                 Global.MensajeError(ex.Message);
             }
         }

         private void btPersona_Click(object sender, EventArgs e)
         {
             try
             {
                 FrmBusquedaPersona oFrm = new FrmBusquedaPersona();

                 if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                 {
                     txtidpersona.Text = Convert.ToString(oFrm.oPersona.IdPersona);
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
