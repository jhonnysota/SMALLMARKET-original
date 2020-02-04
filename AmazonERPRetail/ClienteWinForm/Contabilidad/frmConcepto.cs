using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Maestros;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmConcepto : FrmMantenimientoBase
    {
        public frmConcepto()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        public frmConcepto(Int32 idConcepto, Int32 idEmpresa)
            : this()
        {
            oConceptoGasto = AgenteContabilidad.Proxy.ObtenerConceptoGasto(idConcepto, idEmpresa);
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        ConceptoGastoE oConceptoGasto = null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        void EsNuevoRegistro()
        {
            if (oConceptoGasto == null)
            {
                oConceptoGasto = new ConceptoGastoE();



                oConceptoGasto.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;


                txtUsuRegistra.Text = oConceptoGasto.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oConceptoGasto.FechaRegistro = VariablesLocales.FechaHoy;
                txtRegistro.Text = oConceptoGasto.FechaRegistro.ToString();
                txtUsuModifica.Text = oConceptoGasto.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oConceptoGasto.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oConceptoGasto.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;

            }
            else
            {


                txtConcepto.Text = Convert.ToString(oConceptoGasto.idConcepto);
                txtCodConcepto.Text = oConceptoGasto.codConcepto;
                txtDes.Text = oConceptoGasto.desConcepto;

                txtUsuRegistra.Text = oConceptoGasto.UsuarioRegistro;
                txtRegistro.Text = oConceptoGasto.FechaRegistro.ToString();
                txtUsuModifica.Text = oConceptoGasto.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oConceptoGasto.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oConceptoGasto.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;

            }

            base.Nuevo();
        }

        void GuardarDatos()
        {
            oConceptoGasto.desConcepto = txtDes.Text;
            oConceptoGasto.codConcepto = txtCodConcepto.Text;
        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlDatos.Enabled = Flag;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            BloquearPaneles(true);
            oConceptoGasto = new ConceptoGastoE();

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oConceptoGasto != null)
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
                            oConceptoGasto = AgenteContabilidad.Proxy.InsertarConceptoGasto(oConceptoGasto);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oConceptoGasto = AgenteContabilidad.Proxy.ActualizarConceptoGasto(oConceptoGasto);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                }
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
            String Respuesta = ValidarEntidad<ConceptoGastoE>(oConceptoGasto);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmConcepto_Load(object sender, EventArgs e)
        {
            Grid = false;
            EsNuevoRegistro();
        } 

        #endregion
    }
}
