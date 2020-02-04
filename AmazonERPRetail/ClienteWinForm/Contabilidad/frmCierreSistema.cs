using Entidades.Almacen;
using Entidades.Contabilidad;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmCierreSistema : FrmMantenimientoBase
    {
        public frmCierreSistema()
        {
            Global.AjustarResolucion(this);
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombo();
        }

        public frmCierreSistema(CierreSistemaE CierreSistema)
            : this()
        {
            oCierreSis = AgenteContabilidad.Proxy.ObtenerCierreSistema(CierreSistema.idEmpresa, CierreSistema.AnioPeriodo, CierreSistema.MesPeriodo, CierreSistema.idSistema);
            MesEditar = CierreSistema.MesPeriodo;
            AnioEditar = CierreSistema.AnioPeriodo;

        }

        public frmCierreSistema(String Anio, String Mes)
            : this()
        {
            AnioNuevo = Anio;
            MesNuevo = Mes;

        }

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        CierreSistemaE oCierreSis = null;
        String AnioNuevo = String.Empty;
        String MesNuevo = String.Empty;
        String MesEditar = string.Empty;
        String AnioEditar = String.Empty;     
        Int32 opcion;

        #endregion



        void LlenarCombo()
        {
            List<SistemasE> oListaSistemas = AgenteGeneral.Proxy.ListarSistemas();

            ComboHelper.RellenarCombos<SistemasE>(cboSistema, (from x in oListaSistemas
                                                               where x.idSistema == 0 || x.idSistema == 2 || x.idSistema == 5
                                                               orderby x.idSistema
                                                               select x).ToList(), "idSistema", "descripcion");
            oListaSistemas = null;
        }

        void GuardarDatos()
        {
            oCierreSis.idSistema = Convert.ToInt32(cboSistema.SelectedValue);
            oCierreSis.indCierre = chkIndCierre.Checked ;
            oCierreSis.FechaCierre = tpFechaCierre.Value;

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oCierreSis.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oCierreSis.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oCierreSis == null)
            {
                oCierreSis = new CierreSistemaE();

                oCierreSis.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                oCierreSis.AnioPeriodo = AnioNuevo;
                oCierreSis.MesPeriodo = MesNuevo;
                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                cboSistema.Enabled = false;
                cboSistema.SelectedValue = oCierreSis.idSistema;
                chkIndCierre.Checked = oCierreSis.indCierre;
                tpFechaCierre.Value = oCierreSis.FechaCierre.Value;

                txtUsuRegistra.Text = oCierreSis.UsuarioRegistro;
                txtRegistro.Text = oCierreSis.FechaRegistro.ToString();
                txtUsuModifica.Text = oCierreSis.UsuarioModificacion;
                txtModifica.Text = oCierreSis.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }            

            base.Nuevo();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
            BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
        }

        public override bool ValidarGrabacion()
        {
            String Anio = Convert.ToString(tpFechaCierre.Value.Year);
            String Mes = String.Empty;

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {               

                if (tpFechaCierre.Value.Month>=10)
                {
                    Mes = Convert.ToString(tpFechaCierre.Value.Month);
                }
                else if (tpFechaCierre.Value.Month <= 9)
                {
                    Mes = "0" + Convert.ToString(tpFechaCierre.Value.Month);
                }

                if (AnioNuevo != Anio)
                {
                    Global.MensajeFault("La Fecha Cierre Debe Contener El Año Periodo");
                    return false;
                }

                if (MesNuevo != Mes)
                {
                    Global.MensajeFault("La Fecha Cierre Debe Contener El Mes Periodo");
                    return false;
                }
            }

            if (opcion == (Int32)EnumOpcionGrabar.Actualizar)
            {
                if (tpFechaCierre.Value.Month >= 10)
                {
                    Mes = Convert.ToString(tpFechaCierre.Value.Month);
                }
                else if (tpFechaCierre.Value.Month <= 9)
                {
                    Mes = "0" + Convert.ToString(tpFechaCierre.Value.Month);
                }

                if (AnioEditar != Anio)
                {
                    Global.MensajeFault("La Fecha Cierre Debe Contener El Año Periodo");
                    return false;
                }

                if (MesEditar != Mes)
                {
                    Global.MensajeFault("La Fecha Cierre Debe Contener El Mes Periodo");
                    return false;
                }
            }

            return base.ValidarGrabacion();
        }

        public override void Grabar()
        {
            try
            {
                GuardarDatos();

                if (!ValidarGrabacion()) { return; }

                if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        oCierreSis = AgenteContabilidad.Proxy.InsertarCierreSistema(oCierreSis);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        oCierreSis = AgenteContabilidad.Proxy.ActualizarCierreSistema(oCierreSis);
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

        public override void Cerrar()
        {
            base.Cerrar();
        }

        private void frmCierreSistema_Load(object sender, EventArgs e)
        {
            Nuevo();
   
        }

        #endregion


    }
}
