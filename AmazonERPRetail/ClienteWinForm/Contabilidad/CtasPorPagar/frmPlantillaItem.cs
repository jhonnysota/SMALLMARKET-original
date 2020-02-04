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
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

using Presentadora.AgenteServicio;
namespace ClienteWinForm.CtasPorPagar
{
    public partial class frmPlantillaItem : frmResponseBase
    {
        #region Constructores

        public frmPlantillaItem()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombo();
        }

        public frmPlantillaItem(Plantilla_Concepto_itemE MiEntidad)
            :this()
        {
            Detalle = MiEntidad; // AgenteCtasPorPagar.Proxy.ObtenerProvisiones_PorCCosto(idEmpresa, idLocal, IdProvision, Item);
        }

        #endregion

        #region Variables

        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        public Plantilla_Concepto_itemE Detalle = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombo()
        {

            cboDebeHaber.DataSource = Global.CargarDH();
            cboDebeHaber.ValueMember = "id";
            cboDebeHaber.DisplayMember = "Nombre";

            List<EnumParTabla> ListaParTabla = new List<EnumParTabla>();
            ListaParTabla.Add(EnumParTabla.ConceptosCoVen);

            Dictionary<EnumParTabla, List<ParTabla>> ListaParametros = AgenteGeneral.Proxy.ListarParTablaPorListaGrupo(ListaParTabla);

            ParTabla addNew = new ParTabla();
            addNew.IdParTabla = 0;
            addNew.Nombre = Variables.Seleccione;
            ListaParametros[EnumParTabla.ConceptosCoVen].Add(addNew);

            ComboHelper.RellenarCombos<List<ParTabla>>(cboColumnaCoVen, (from x in ListaParametros[EnumParTabla.ConceptosCoVen] orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre");
       
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (Detalle == null)
            {
                Detalle = new Plantilla_Concepto_itemE();

                Detalle.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;

                //Detalle.Cantidad = Variables.ValorCeroDecimal;
                //Detalle.PrecioUnitario = Variables.ValorCeroDecimal;

                Detalle.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial; ;
                Detalle.fechaRegistro = VariablesLocales.FechaHoy;
                Detalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial; ;
                Detalle.fechaModificacion = VariablesLocales.FechaHoy;

                Detalle.Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                //txtIdArticulo.Text = Detalle.idArticulo.ToString("000000");
                //txtDesArticulo.Text = Detalle.desArticulo;

                Detalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                Detalle.fechaModificacion = VariablesLocales.FechaHoy;

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
            String resp = ValidarEntidad<Plantilla_Concepto_itemE>(Detalle);

            if (!String.IsNullOrEmpty(resp))
            {
                Global.MensajeComunicacion(resp);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmPlantillaItem_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void lblTituloPrincipal_Click(object sender, EventArgs e)
        {

        }


        private void btn_Cuenta_Click(object sender, EventArgs e)
        {
            frmBuscarCuentas oFrm = new frmBuscarCuentas();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Cuentas != null)
            {
                Detalle.numVerPlanCuentas = oFrm.Cuentas.numVerPlanCuentas;
                Detalle.codCuenta = oFrm.Cuentas.codCuenta;
                Detalle.DesCuenta = oFrm.Cuentas.Descripcion;

                bsBase.DataSource = Detalle;
                bsBase.ResetBindings(false);
            }
        }

        #endregion

    }
}
