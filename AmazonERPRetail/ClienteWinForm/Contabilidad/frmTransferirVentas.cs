using System;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmTransferirVentas : FrmMantenimientoBase
    {
        public frmTransferirVentas()
        {
            InitializeComponent();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }

        #endregion

        #region Procedimientos de Usuario

        void Aceptar(DateTime fecInicial, DateTime fecFinal)
        {
            try
            {
                String MesInicial = fecInicial.ToString("MM"); ; 
                String MesFinal = fecFinal.ToString("MM");
                String AnioInicio = fecInicial.ToString("yyyy");
                String AnioFinal = fecFinal.ToString("yyyy");

                if (RevisarMesAnio(MesInicial, MesFinal, AnioInicio, AnioFinal))
                {
                    PeriodosE oPeriodoContable = AgenteContabilidad.Proxy.ObtenerPeriodoPorMes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, AnioInicio, MesInicial);

                    if (oPeriodoContable.indCierre)
                    {
                        Global.MensajeComunicacion("El mes se encuentra cerrado. No podra hacer hacer transferencias.");
                    }
                    else
                    {
                        Int32 RegistrosAfectados = AgenteContabilidad.Proxy.TransferirVentasVoucher(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, fecInicial, fecFinal, VariablesLocales.SesionUsuario.Credencial);

                        if (RegistrosAfectados > Variables.Cero)
                        {
                            Global.MensajeComunicacion("Las ventas se han transferido correctamente");
                        }
                        else
                        {
                            Global.MensajeComunicacion("No existe ninguna venta para el mes seleccionado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        Boolean RevisarMesAnio(String MesIni, String MesFin, String AnioIni, String AnioFin)
        {
            if (MesIni != MesFin)
            {
                Global.MensajeError("Debe ser el mismo mes para el periodo.");
                return false;
            }

            if (AnioIni != AnioFin)
            {
                Global.MensajeError("Debe ser el mismo año para el periodo.");
                return false;
            }

            return true;
        }

        #endregion

        #region Eventos de Usuario

        void mcFinal_ValueChanged(object sender, CalanderControl.Design.Generics.GenericEventArgs<DateTime> tArgs)
        {
            txtFecFinal.Text = "Fecha: " + tArgs.Value.ToString("d");
        }

        void mcInicio_ValueChanged(object sender, CalanderControl.Design.Generics.GenericEventArgs<DateTime> tArgs)
        {
            txtFecInicio.Text = "Fecha: " + tArgs.Value.ToString("d");
        }

        #endregion

        #region Eventos
        
        private void frmTransferirVentas_Load(object sender, EventArgs e)
        {
            Grid = false;
            mcInicio.SelectedDate = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            txtFecInicio.Text = "Fecha: " + mcInicio.SelectedDate.ToString("d");
            txtFecFinal.Text = "Fecha: " + mcFinal.SelectedDate.ToString("d");
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            mcInicio.ValueChanged += mcInicio_ValueChanged;
            mcFinal.ValueChanged += mcFinal_ValueChanged;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Aceptar(Convert.ToDateTime(Global.Derecha(txtFecInicio.Text, 10)), Convert.ToDateTime(Global.Derecha(txtFecFinal.Text, 10)));
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        } 

        #endregion

    }
}
