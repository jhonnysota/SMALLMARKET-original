using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmComprasFile : FrmMantenimientoBase
    {

        #region Constructores

        public frmComprasFile()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombo();
        }

        public frmComprasFile(ComprasFileE oComprasFileTmp)
            :this()
        {
            oComprasFile = oComprasFileTmp;
        }

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        ComprasFileE oComprasFile = null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        void GuardarDatos()
        {
            oComprasFile.Descripcion = txtDescripcion.Text;
            oComprasFile.idComprobante = Convert.ToString(cboLibro.SelectedValue);
            oComprasFile.numFile = Convert.ToString(cboFile.SelectedValue);  
            oComprasFile.codColumnaCoven = Convert.ToInt32(cboCoVen.SelectedValue);
            oComprasFile.indColumnaIgv = Convert.ToBoolean(chkIgv.Checked);
            oComprasFile.codColumnaIgv = Convert.ToInt32(cboCoIgv.SelectedValue);
            oComprasFile.indCtaCorriente = Convert.ToBoolean(chkCtaCte.Checked);
            oComprasFile.AfectaOc = chkOc.Checked;
            oComprasFile.MostrarOp = chkOp.Checked;

            if (opcion == (Int32)EnumOpcionGrabar.Actualizar)
            {
                oComprasFile.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oComprasFile.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void LlenarCombo()
        {
            //Libros
            List<ComprobantesE> ListaTipoComprobante = new List<ComprobantesE>(VariablesLocales.oListaComprobantes);
            ListaTipoComprobante.Add(new ComprobantesE() { idComprobante = Variables.Cero.ToString(), desComprobanteComp = Variables.Todos });
            ComboHelper.RellenarCombos<ComprobantesE>(cboLibro, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp", false);
            cboLibro.SelectedValue = Variables.Cero.ToString();

            //Columna Compra y Venta
            List<ParTabla> TipoBases = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPBA");
            TipoBases.Add(new ParTabla() { IdParTabla = Variables.Cero, Descripcion = Variables.Todos });
            ComboHelper.RellenarCombos<ParTabla>(cboCoVen, (from x in TipoBases orderby x.IdParTabla select x).ToList(), "IdParTabla", "Descripcion", false);

            //Columna Igv
            List<ParTabla> TipoIgv = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPIGV");
            TipoIgv.Add(new ParTabla() { IdParTabla = Variables.Cero, Descripcion = Variables.Todos });
            ComboHelper.RellenarCombos<ParTabla>(cboCoIgv, (from x in TipoIgv orderby x.IdParTabla select x).ToList(), "IdParTabla", "Descripcion", false);
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oComprasFile == null)
            {
                oComprasFile = new ComprasFileE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                };

                cboLibro.SelectedValue = Variables.RegistroCompra;
                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtDescripcion.Text = oComprasFile.Descripcion;
                cboLibro.SelectedValue = oComprasFile.idComprobante.ToString();
                cboLibro_SelectionChangeCommitted(new Object(), new EventArgs());
                cboFile.SelectedValue = oComprasFile.numFile.ToString();
                cboCoVen.SelectedValue = Convert.ToInt32(oComprasFile.codColumnaCoven);
                chkIgv.Checked = oComprasFile.indColumnaIgv;
                cboCoIgv.SelectedValue = Convert.ToInt32(oComprasFile.codColumnaIgv);
                chkCtaCte.Checked = oComprasFile.indCtaCorriente;
                chkOc.Checked = oComprasFile.AfectaOc;
                chkOp.Checked = oComprasFile.MostrarOp;

                txtUsuRegistra.Text = oComprasFile.UsuarioRegistro;
                txtRegistro.Text = oComprasFile.FechaRegistro.ToString();
                txtUsuModifica.Text = oComprasFile.UsuarioModificacion;
                txtModifica.Text = oComprasFile.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oComprasFile != null)
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
                            oComprasFile = AgenteContabilidad.Proxy.InsertarComprasFile(oComprasFile);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oComprasFile = AgenteContabilidad.Proxy.ActualizarComprasFile(oComprasFile);
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

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<ComprasFileE>(oComprasFile);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void cboLibro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboLibro.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles = AgenteContabilidad.Proxy.ObtenerFilesPorIdComprobante(VariablesLocales.SesionLocal.IdEmpresa, cboLibro.SelectedValue.ToString());
                    ComprobantesFileE File = new ComprobantesFileE();
                    File.numFile = Variables.Cero.ToString();
                    File.Descripcion = Variables.Todos;
                    ListaFiles.Add(File);
                    ComboHelper.RellenarCombos<ComprobantesFileE>(cboFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "Descripcion", false);

                    if (cboLibro.SelectedValue.ToString() == Variables.Cero.ToString())
                    {
                        cboFile.Enabled = false;
                    }
                    else
                    {
                        cboFile.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmComprasFile_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        private void chkIgv_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIgv.Checked)
            {
                cboCoIgv.Enabled = true;
            }
            else
            {
                cboCoIgv.Enabled = false;
                cboCoIgv.SelectedValue = Variables.Cero;
            }
        }

        #endregion

    }
}
