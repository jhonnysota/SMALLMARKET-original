using Entidades.Almacen;
using Entidades.Contabilidad;
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
    public partial class frmCierreAlmacen : FrmMantenimientoBase
    {
        public frmCierreAlmacen()
        {
            Global.AjustarResolucion(this);
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        public frmCierreAlmacen(CierreAlmacenE CierreAlmacen)
            : this()
        {
            oCierreAlm = AgenteContabilidad.Proxy.ObtenerCierreAlmacen(CierreAlmacen.idEmpresa, CierreAlmacen.AnioPeriodo, CierreAlmacen.MesPeriodo, CierreAlmacen.idAlmacen);
            MesEditar = CierreAlmacen.MesPeriodo;
            AnioEditar = CierreAlmacen.AnioPeriodo;

        }

        public frmCierreAlmacen(String Anio, String Mes)
            : this()
        {
            AnioNuevo = Anio;
            MesNuevo = Mes;

        }


        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        CierreAlmacenE oCierreAlm = null;
        String AnioNuevo = String.Empty;
        String MesNuevo = String.Empty;
        Int32 opcion;
        String MesEditar = string.Empty;
        String AnioEditar = String.Empty;
        List<AlmacenE> ListarTipoAlmacen = null;

        #endregion

        void LlenarCombos()
        {
            ListarTipoAlmacen = AgenteAlmacen.Proxy.ListarAlmacen(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "", 0, false, false);
            ComboHelper.RellenarCombos<AlmacenE>(cboalmacen, (from x in ListarTipoAlmacen orderby x.desAlmacen select x).ToList(), "idAlmacen", "desAlmacen", false);

         
        }

        void GuardarDatos()
        {
            oCierreAlm.idAlmacen = Convert.ToInt32(cboalmacen.SelectedValue);
            oCierreAlm.indCierre = chkIndCierre.Checked;
            oCierreAlm.FechaCierre = tpFechaCierre.Value;

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oCierreAlm.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oCierreAlm.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }


        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oCierreAlm == null)
            {
                oCierreAlm = new CierreAlmacenE();

                oCierreAlm.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                oCierreAlm.AnioPeriodo = AnioNuevo;
                oCierreAlm.MesPeriodo = MesNuevo;
                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {

                cboalmacen.Enabled = false;
                cboalmacen.SelectedValue = oCierreAlm.idAlmacen;
                chkIndCierre.Checked = oCierreAlm.indCierre;
                tpFechaCierre.Value = oCierreAlm.FechaCierre.Value;

                txtUsuRegistra.Text = oCierreAlm.UsuarioRegistro;
                txtRegistro.Text = oCierreAlm.FechaRegistro.ToString();
                txtUsuModifica.Text = oCierreAlm.UsuarioModificacion;
                txtModifica.Text = oCierreAlm.FechaModificacion.ToString();

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

                if (tpFechaCierre.Value.Month >= 10)
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
                        oCierreAlm = AgenteContabilidad.Proxy.InsertarCierreAlmacen(oCierreAlm);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        oCierreAlm = AgenteContabilidad.Proxy.ActualizarCierreAlmacen(oCierreAlm);
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

        #endregion



        private void frmCierreAlmacen_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }
    }
}
