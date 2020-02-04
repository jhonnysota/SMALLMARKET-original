using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClienteWinForm.Busquedas;
using Entidades.CtasPorPagar;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Presentadora.AgenteServicio;

namespace ClienteWinForm.CtasPorPagar
{
    public partial class frmProvisionPartida : frmResponseBase
    {
        #region Constructores

        public frmProvisionPartida()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

         public frmProvisionPartida(Provisiones_PorPartidaE MiEntidad)
            :this()
        {
            Detalle = MiEntidad; //AgenteCtasPorPagar.Proxy.ObtenerProvisiones_PorPartida(idEmpresa, idLocal, IdProvision, Item);
        }

        #endregion

        #region Variables

         CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
         GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
         MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
         public Provisiones_PorPartidaE Detalle = null;

         #endregion

        #region Procedimientos de Usuario

         void LlenarCombo()
         {            
             // Monedas
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
             //// Partida
             //List<Partida_PresupuestariaE> ListaPartida = AgenteMaestro.Proxy.ListarPartida_Presupuestaria();
             //Partida_PresupuestariaE Partida = new Partida_PresupuestariaE();
             //Partida.codPartidaPresu = "0";
             //Partida.DesPartidaPresu = "[Escoger Partida]";
             //ListaPartida.Add(Partida);

             //ComboHelper.RellenarCombos<CCostosE>(cboCCostos, ListaCostos, "idCCostos", "desCCostos", false);
             //cboCCostos.SelectedValue = "0";

             //// Tipo de Detraccion
             //List<TasasDetraccionesE> ListaTipoDetraccion = AgenteGenerales.Proxy.ListarTasasDetracciones();
             //TasasDetraccionesE TipoDetraccion = new TasasDetraccionesE();
             //TipoDetraccion.idtipo_detraccion = Variables.ValorCero.ToString();
             //TipoDetraccion.Nombre = "[Escoger Tasa ]";
             //ListaTipoDetraccion.Add(TipoDetraccion);
             //ComboHelper.RellenarCombos<TasasDetraccionesE>(cbotipodetraccion, (from x in ListaTipoDetraccion orderby x.idtipo_detraccion select x).ToList(), "idtipo_detraccion", "Nombre", false);
             //cbotipodetraccion.SelectedValue = Variables.ValorCero.ToString();

         }

        #endregion

        #region Procedimientos Heredados

         public override void Nuevo()
         {
             if (Detalle == null)
             {
                 Detalle = new Provisiones_PorPartidaE();

                 Detalle.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;

                 //Detalle.Cantidad = Variables.ValorCeroDecimal;
                 //Detalle.PrecioUnitario = Variables.ValorCeroDecimal;

                 Detalle.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial; ;
                 Detalle.FechaRegistro = VariablesLocales.FechaHoy;
                 Detalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial; ;
                 Detalle.FechaModificacion = VariablesLocales.FechaHoy;

                 Detalle.Opcion = (Int32)EnumOpcionGrabar.Insertar;
             }
             else
             {
                 //txtIdArticulo.Text = Detalle.idArticulo.ToString("000000");
                 //txtDesArticulo.Text = Detalle.desArticulo;

                 Detalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                 Detalle.FechaModificacion = VariablesLocales.FechaHoy;

                 Detalle.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
             }

             bsBase.DataSource = Detalle;
             bsBase.ResetBindings(false);
             base.Nuevo();
         }

         public override void Aceptar()
         {
             bsBase.EndEdit();

             if (!ValidarGrabacion())
             {
                 return;
             }

             //Detalle.desCalibre = cboCalibre.Text;
             //Detalle.desCategoria = cboCategoria.Text;
             //Detalle.desPresentacion = cboPresentacion.Text;

             base.Aceptar();
         }

         public override bool ValidarGrabacion()
         {
             String resp = ValidarEntidad<Provisiones_PorPartidaE>(Detalle);

             if (!String.IsNullOrEmpty(resp))
             {
                 Global.MensajeComunicacion(resp);
                 return false;
             }

             return base.ValidarGrabacion();
         }

         #endregion

        private void frmProvisionPartida_Load(object sender, EventArgs e)
        {
            LlenarCombo();
            Nuevo();
        }

        private void lblTituloPrincipal_Click(object sender, EventArgs e)
        {

        }

        private void btPartida_Click(object sender, EventArgs e)
        {
            frmBuscarPartida oFrm = new frmBuscarPartida();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPartidaPresupuestal != null)
            {
                Detalle.numVerPartida = "001";
                Detalle.TipPartidaPresu = oFrm.oPartidaPresupuestal.tipPartidaPresu;
                Detalle.CodPartidaPresu = oFrm.oPartidaPresupuestal.codPartidaPresu;
                Detalle.DesPartidaPresu = oFrm.oPartidaPresupuestal.desPartidaPresu;

                bsBase.DataSource = Detalle;
                bsBase.ResetBindings(false);

            }
        }
    }
}
