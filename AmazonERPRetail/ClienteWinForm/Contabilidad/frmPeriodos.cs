using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Extensores;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmPeriodos : FrmMantenimientoBase
    {

        #region Constructores

        //Nuevo
        public frmPeriodos()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            InitializeComponent();
        }

        //Edición
        public frmPeriodos(PeriodosE Periodo_)
            : this()
        {
            periodo = Periodo_;
        } 

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        PeriodosE periodo = null;
        Int32 Opcion = 0;

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (periodo == null)
            {
                periodo = new PeriodosE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    AnioPeriodo = VariablesLocales.PeriodoContable.AnioPeriodo,
                    indCierre = false,
                    indApertura = true,
                    indReapertura = false,
                    indAjusteDifCambio = false,
                    indAaFinMes = false,
                    indEfectivoAsientos = false,
                    indAjustePorDocFinMes = false,
                    indEfectivoAjusteFinMes = false,
                    fecInicio = VariablesLocales.FechaHoy,
                    fecFinal = VariablesLocales.FechaHoy,
                    UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                    UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                    FechaRegistro = DateTime.Now,
                    FechaModificacion = DateTime.Now
                };

                Extensores.CambiaColorFondo(txtMes, EnumTipoEdicionCuadros.Desbloquear);
                Opcion = (Int32)EnumOpcionGrabar.Insertar;

                txtMes.Focus();
            }
            else
            {
                periodo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                periodo.FechaModificacion = VariablesLocales.FechaHoy;
                Extensores.CambiaColorFondo(txtMes, EnumTipoEdicionCuadros.Bloquear);
                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                txtDesMes.Focus();
            }

            bsPeriodos.DataSource = periodo;
            bsPeriodos.ResetBindings(false);

            base.Nuevo();
        }

        public override void Editar()
        {
            panel1.Enabled = true;
            bFlag = true;
            Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            txtDesMes.Focus();

            base.Editar();
        }

        public override void Grabar()
        {
            try
            {
                bsPeriodos.EndEdit();

                if (!ValidarGrabacion()) { return; }

                periodo = (PeriodosE)bsPeriodos.Current;

                //periodo.TCCompra =  (txtTCCompra.Text.Length>0?Convert.ToDecimal(txtTCCompra.Text):0);
                //periodo.TCVenta = (txtTCVenta.Text.Length > 0 ? Convert.ToDecimal(txtTCVenta.Text) : 0);

                if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        periodo = AgenteContabilidad.Proxy.InsertarPeriodos(periodo);                        
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        periodo = AgenteContabilidad.Proxy.ActualizarPeriodos(periodo);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }
                
                Opcion = 0;
                bsPeriodos.DataSource = periodo;
                bsPeriodos.ResetBindings(false);
                pnlAuditoria.Focus();
                base.Grabar();
                panel1.Enabled = false;
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            string resultado = ValidarEntidad<PeriodosE>(periodo);
            DateTime fecTmp;

            if (!string.IsNullOrEmpty(resultado))
            {
                Global.MensajeComunicacion(resultado);
                return false;
            }

            if (periodo.fecInicio > periodo.fecFinal)
            {
                Global.MensajeComunicacion("La fecha inicial no puede ser mayor que la fecha final.");
                return false;
            }

            fecTmp = Convert.ToDateTime(periodo.fecInicio);
            if (periodo.MesPeriodo != fecTmp.ToString("MM"))
            {
                Global.MensajeComunicacion("El mes de la Fecha Inicial no puede ser diferente que el campo Mes.");
                return false;
            }

            fecTmp = Convert.ToDateTime(periodo.fecFinal);
            if (periodo.MesPeriodo != fecTmp.ToString("MM"))
            {
                Global.MensajeComunicacion("El mes de la Fecha Final no puede ser diferente que el campo Mes.");
                return false;
            }

            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                PeriodosE perTemporal = AgenteContabilidad.Proxy.ObtenerPeriodoPorMes(periodo.idEmpresa, periodo.AnioPeriodo, periodo.MesPeriodo);
                if (perTemporal != null)
                {
                    Global.MensajeComunicacion("El Periodo ya ha sido ingresado. Intente nuevamente");
                    return false;
                }
            }
            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmPeriodos_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }


        #endregion

    }
}
