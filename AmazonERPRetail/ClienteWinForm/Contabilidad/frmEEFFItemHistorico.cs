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
    public partial class frmEEFFItemHistorico : FrmMantenimientoBase
    {
        public frmEEFFItemHistorico()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
     
        }

        public frmEEFFItemHistorico(EEFFItemHistoricoE oEEFFHist)
           : this()
        {
            oEEFFITEMHist = oEEFFHist;
        }


        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        EEFFItemHistoricoE oEEFFITEMHist = null;
        Int32 opcion;
        String RazonSocial = String.Empty;
        String Anio = String.Empty;
        String Mes = String.Empty;

        #endregion


        void LlenarCombos()
        {

            /////EEFF////
            List<EEFFE> oListaEEFF = AgenteContabilidad.Proxy.ListarEEFF(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 0, "", true);
            oListaEEFF.Add(new EEFFE { idEEFF = 0, desSeccion = "<SELECCIONE>" });
            ComboHelper.LlenarCombos<EEFFE>(cboeeffid, oListaEEFF.OrderBy(x => x.idEEFF).ToList(), "idEEFF", "desSeccion");

            /////EEFF////
            List<EEFFItemE> oListaEEFFiem = AgenteContabilidad.Proxy.ListarEEFFItem(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, oEEFFITEMHist.idEEFF);
            oListaEEFFiem.Add(new EEFFItemE { idEEFFItem = 0, desItem = "<SELECCIONE>" });
            ComboHelper.LlenarCombos<EEFFItemE>(cboeeffItem, oListaEEFFiem.OrderBy(x => x.idEEFFItem).ToList(), "idEEFFItem", "desItem");

            //Cargando Años
            cboAnio.DataSource = FechasHelper.CargarAnios((VariablesLocales.FechaHoy.Year - 10), VariablesLocales.FechaHoy.Year);
            cboAnio.ValueMember = "AnioId";
            cboAnio.DisplayMember = "AnioDes";
            cboAnio.SelectedValue = VariablesLocales.PeriodoContable.AnioPeriodo;        
        }

        void GuardarDatos()
        {
            oEEFFITEMHist.idEEFF = Convert.ToInt32(cboeeffid.SelectedValue);
            oEEFFITEMHist.idEEFFItem = Convert.ToInt32(cboeeffItem.SelectedValue);
            oEEFFITEMHist.AnioPeriodo = cboAnio.SelectedValue.ToString();
            oEEFFITEMHist.saldo_dol = Convert.ToDecimal(txtSaldoDol.Text);
            oEEFFITEMHist.saldo_sol = Convert.ToDecimal(txtSaldosol.Text);
        }


        #region Procedimientos Heredados

        public override void Nuevo()
        {

            if (oEEFFITEMHist != null)
            {

                cboeeffid.SelectedValue = oEEFFITEMHist.idEEFF;
                cboeeffItem.SelectedValue = oEEFFITEMHist.idEEFFItem;
                cboAnio.SelectedValue = oEEFFITEMHist.AnioPeriodo;
                txtSaldosol.Text = oEEFFITEMHist.saldo_sol.Value.ToString();
                txtSaldoDol.Text = oEEFFITEMHist.saldo_dol.Value.ToString();

                if (oEEFFITEMHist.UsuarioRegistro != null)
                {
                    txtUsuRegistra.Text = oEEFFITEMHist.UsuarioRegistro;
                    txtRegistro.Text = oEEFFITEMHist.FechaRegistro.ToString();
                    txtUsuModifica.Text = oEEFFITEMHist.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oEEFFITEMHist.FechaModificacion = VariablesLocales.FechaHoy;
                    txtModifica.Text = oEEFFITEMHist.FechaModificacion.ToString();
                    opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }
                else
                {
                    txtUsuRegistra.Text = oEEFFITEMHist.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    oEEFFITEMHist.FechaRegistro = VariablesLocales.FechaHoy;
                    txtRegistro.Text = oEEFFITEMHist.FechaRegistro.ToString();
                    txtUsuModifica.Text = oEEFFITEMHist.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oEEFFITEMHist.FechaModificacion = VariablesLocales.FechaHoy;
                    txtModifica.Text = oEEFFITEMHist.FechaModificacion.ToString();
                    opcion = (Int32)EnumOpcionGrabar.Insertar;
                }

              

  
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oEEFFITEMHist != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }


                    if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oEEFFITEMHist = AgenteContabilidad.Proxy.InsertarEEFFItemHistorico(oEEFFITEMHist);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }

                    if (opcion == (Int32)EnumOpcionGrabar.Actualizar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oEEFFITEMHist = AgenteContabilidad.Proxy.ActualizarEEFFItemHistorico(oEEFFITEMHist);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
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

        public override void Cancelar()
        {
            pnlAuditoria.Focus();
            base.Cancelar();
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<EEFFItemHistoricoE>(oEEFFITEMHist);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }


            return base.ValidarGrabacion();
        }




        #endregion

        private void frmEEFFItemHistorico_Load(object sender, EventArgs e)
        {
            Grid = false;
            LlenarCombos();
            Nuevo();
        }
    }
}
