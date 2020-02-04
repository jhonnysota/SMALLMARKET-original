using Entidades.CtasPorPagar;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
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

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmNumControlCompraDet : frmResponseBase
    {
        public frmNumControlCompraDet()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            ToolTipAyudas();
            LlenarCombos();
        }

        public frmNumControlCompraDet(NumControlCompraDetE oDet)
            :this()
        {

            if (oDet.idControl > Variables.Cero && oDet.Opcion != (Int32)EnumOpcionGrabar.Actualizar)
            {
                Detalle = AgenteCtasPorPagar.Proxy.ObtenerNumControlCompraDet(oDet.idEmpresa, oDet.idLocal, oDet.idControl, oDet.item);
            }
            else
            {
                Detalle = oDet;
            }
        }

        #region Variables

        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        public NumControlCompraDetE Detalle = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //Documentos...
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(VariablesLocales.ListarDocumentoGeneral);
            DocumentosE pd = new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = " " + Variables.Seleccione };
            ListaDocumentos.Add(pd);
            ComboHelper.RellenarCombos<DocumentosE>(cboDocumentos, (from x in ListaDocumentos orderby x.desDocumento select x).ToList(), "idDocumento", "desDocumento", false);
            
        }

        void ToolTipAyudas()
        {
            Global.CrearToolTip(txtCorrelativo, "N° de documento (Correlativo).");
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (Detalle == null)
            {
                Detalle = new NumControlCompraDetE();

                Detalle.idDocumento = Variables.Cero.ToString();
                Detalle.cantDigSerie = Variables.Cero;
                Detalle.cantDigNumero = Variables.Cero;
                usuarioRegistroTextBox.Text = Detalle.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                Detalle.FechaRegistro = VariablesLocales.FechaHoy;
                textBox2.Text = Convert.ToString(Detalle.FechaRegistro);
                usuarioModificacionTextBox.Text = Detalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                Detalle.FechaModificacion = VariablesLocales.FechaHoy;
                textBox1.Text = Convert.ToString(Detalle.FechaModificacion);
                Detalle.Opcion = (Int32)EnumOpcionGrabar.Insertar;


            }
            else
            {
                Detalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                Detalle.FechaModificacion = VariablesLocales.FechaHoy;

                if (Detalle.idControl > Variables.Cero)
                {
                    Detalle.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }
                else
                {
                    Detalle.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                }


            }

            bsBase.DataSource = Detalle;
            bsBase.ResetBindings(false);
            base.Nuevo();
        }

        public override void Aceptar()
        {
            bsBase.EndEdit();

            //if (String.IsNullOrEmpty(Detalle.numCorrelativo))
            //{
            //    Detalle.numCorrelativo = Detalle.numInicial;
            //}

            if (!ValidarGrabacion())
            {
                return;
            }

            base.Aceptar();
        }

        public override bool ValidarGrabacion()
        {
            String resp = ValidarEntidad<NumControlCompraDetE>(Detalle);

            if (!String.IsNullOrEmpty(resp))
            {
                Global.MensajeComunicacion(resp);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmNumControlCompraDet_Load(object sender, EventArgs e)
        {
            LlenarCombos();
            Nuevo();
        }

        private void txtCantSerie_TextChanged(object sender, EventArgs e)
        {
            if (txtCantSerie.Text.Length > 0 && txtCantSerie.Text != Variables.Cero.ToString())
            {
                txtSerie.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);

                if (txtSerie.Text.Length > Convert.ToInt32(txtCantSerie.Text))
                {
                    txtSerie.Text = txtSerie.Text.Substring(0, Convert.ToInt32(txtCantSerie.Text));
                }
            }
            else
            {
                txtSerie.Text = String.Empty;
                txtSerie.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }
        }

        private void txtCantNumero_TextChanged(object sender, EventArgs e)
        {
            if (txtCantNumero.Text.Length > 0 && txtCantNumero.Text != Variables.Cero.ToString())
            {
                txtNumInicial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtNumFinal.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtCorrelativo.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);

                if (txtNumInicial.Text.Length > Convert.ToInt32(txtCantNumero.Text))
                {
                    txtNumInicial.Text = txtNumInicial.Text.Substring(0, Convert.ToInt32(txtCantNumero.Text));
                }

                if (txtNumFinal.Text.Length > Convert.ToInt32(txtCantNumero.Text))
                {
                    txtNumFinal.Text = txtNumFinal.Text.Substring(0, Convert.ToInt32(txtCantNumero.Text));
                }

                if (txtCorrelativo.Text.Length > Convert.ToInt32(txtCantNumero.Text))
                {
                    txtCorrelativo.Text = txtCorrelativo.Text.Substring(0, Convert.ToInt32(txtCantNumero.Text));
                }
            }
            else
            {
                txtNumInicial.Text = String.Empty;
                txtNumFinal.Text = String.Empty;
                txtNumInicial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtNumFinal.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtCorrelativo.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }
        }

        private void txtSerie_Enter(object sender, EventArgs e)
        {
            txtSerie.MaxLength = Convert.ToInt32(txtCantSerie.Text);
        }

        private void txtNumInicial_Enter(object sender, EventArgs e)
        {
            txtNumInicial.MaxLength = Convert.ToInt32(txtCantNumero.Text);
        }

        private void txtNumFinal_Enter(object sender, EventArgs e)
        {
            txtNumFinal.MaxLength = Convert.ToInt32(txtCantNumero.Text);
        }

        private void cboDocumentos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        #endregion

    }
}
