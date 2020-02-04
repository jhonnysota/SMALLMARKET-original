using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
//using Entidades.Asistencia;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Maestros;

namespace ClienteWinForm.Ventas
{
    public partial class frmPeriodoComision : FrmMantenimientoBase
    {
        #region Constructores
        
        public frmPeriodoComision()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();
        }

        public frmPeriodoComision(Int32 idEmpresa, Int32 idPeriodo)
            : this()
        {
            oComision = AgenteVentas.Proxy.ObtenerPeriodoComision(idEmpresa, idPeriodo);
        }

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        PeriodoComisionE oComision = null;
        Int32 opcion;
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;

        #endregion

        #region Procedimientos de Usuario

        void EsNuevoRegistro()
        {
            if (oComision == null)
            {
                oComision = new PeriodoComisionE();
                oComision.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                oComision.FechaInicial = VariablesLocales.FechaHoy;
                oComision.FechaFinal = VariablesLocales.FechaHoy;

                txtUsuRegistra.Text = oComision.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oComision.FechaRegistro = VariablesLocales.FechaHoy;
                txtRegistro.Text = oComision.FechaRegistro.ToString();
                txtUsuModifica.Text = oComision.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oComision.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oComision.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtPeriodo.Text = Convert.ToString(oComision.idPeriodo);

                cboAnio.SelectedValue = Convert.ToInt32(oComision.Anio);

                cboMes.SelectedValue = Convert.ToString(oComision.Mes);
             

                if (chkEstado.Checked == true)
                {
                  
                    chkEstado.Text = "Abierto";

                }
                else
                {                    
                    chkEstado.Text = "Cerrado";
                }

                dtpInicio.Value = Convert.ToDateTime(oComision.FechaInicial);
                dtpFin.Value = Convert.ToDateTime(oComision.FechaFinal);

                txtUsuRegistra.Text = oComision.UsuarioRegistro;
                txtRegistro.Text = oComision.FechaRegistro.ToString();
                txtUsuModifica.Text = oComision.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oComision.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oComision.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;

            }

            base.Nuevo();
        }

        void LlenarCombos()
        {
            /////MES////
            DataTable oDt = FechasHelper.CargarMesesContable("MA");
            DataRow Fila = oDt.NewRow();
            Fila["MesId"] = "0";
            Fila["MesDes"] = Variables.Todos;
            oDt.Rows.Add(Fila);

            oDt.DefaultView.Sort = "MesId";
            cboMes.DataSource = oDt;
            cboMes.ValueMember = "MesId";
            cboMes.DisplayMember = "MesDes";
            cboMes.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;


            /////ANIOS/////
            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 10;


            cboAnio.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboAnio.ValueMember = "AnioId";
            cboAnio.DisplayMember = "AnioDes";            
        }

        void GuardarDatos()
        {
            oComision.FechaInicial = Convert.ToDateTime(dtpInicio.Value.Date);
            oComision.FechaFinal = Convert.ToDateTime(dtpFin.Value.Date);

            if (chkEstado.Checked == true)
            {
                oComision.Estado = true;
            }
            else
            {
                oComision.Estado = false;
            }



            oComision.Anio = cboAnio.SelectedValue.ToString();
            oComision.Mes = cboMes.SelectedValue.ToString();

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
            oComision = new PeriodoComisionE();

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oComision != null)
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
                            oComision = AgenteVentas.Proxy.InsertarPeriodoComision(oComision);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oComision = AgenteVentas.Proxy.ActualizarPeriodoComision(oComision);
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

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<PeriodoComisionE>(oComision);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmPeriodoComision_Load(object sender, EventArgs e)
        {
            Grid = false;
            EsNuevoRegistro();
        }
          #endregion
    }
}
