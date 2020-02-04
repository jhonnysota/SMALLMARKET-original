using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Generales;

namespace ClienteWinForm.Maestros
{
    public partial class frmDocumentos : FrmMantenimientoBase
    {

        #region Constructores

        public frmDocumentos()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
            FormatoGrid(dgvImpuestos, false);
            Global.CrearToolTip(btActivar, "Activar el registro nuevamente");
        }

        public frmDocumentos(String idDocumentos)
            : this()
        {
            oDocumentos = AgenteMaestros.Proxy.ObtenerDocumentos(idDocumentos);

            if (oDocumentos.indBaja)
            {
                pnlDatos.Enabled = false;
                lblBaja.Text = "Dado de baja el dia " + oDocumentos.fecBaja.ToString();
            }
        }

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        DocumentosE oDocumentos = null;
        Int32  opcion ;
        public bool Avisar = false;
        public String RazonSocial;
        public ImpuestosDocumentosE Detalle = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            cboDebeHaber.DataSource = Global.CargarDH();
            cboDebeHaber.ValueMember = "id";
            cboDebeHaber.DisplayMember = "Nombre";

            List<ParTabla> oListaMedioPago = AgenteGenerales.Proxy.ListarParTablaPorNemo("MEDPAG");
            oListaMedioPago.Add(new ParTabla { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione });
            ComboHelper.RellenarCombos<List<ParTabla>>(cboMedioPago, (from x in oListaMedioPago orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre");

            //Dependencias aduaneras
            List<ParTabla> ListarDependencias = AgenteGenerales.Proxy.ListarParTablaPorNemo("DEAD");
            ListarDependencias.Add(new ParTabla() { IdParTabla = Variables.Cero, desTemporal = Variables.Seleccione });
            ComboHelper.LlenarCombos<ParTabla>(cboAduanas, (from x in ListarDependencias orderby x.IdParTabla select x).ToList(), "IdParTabla", "desTemporal");
        }

        void GuardarDatos()
        {
            oDocumentos.idDocumento = txtCodDoc.Text;
            oDocumentos.desDocumento = txtDescripcion.Text;
            oDocumentos.desCorta = txtDesCorta.Text;
            oDocumentos.indDebeHaber = cboDebeHaber.SelectedValue.ToString();
            oDocumentos.CodigoSunat = txtCodSunat.Text;
            oDocumentos.codMedioPago = Convert.ToInt32(cboMedioPago.SelectedValue.ToString());
            oDocumentos.indFecVencimiento = chkFecVencimiento.Checked;
            oDocumentos.indReferencia = chkIndReferencia.Checked;
            oDocumentos.indRecepcionDcmto = chkReDoc.Checked;
            oDocumentos.EsReferencia = chkDocReferencia.Checked;
            oDocumentos.indDocumentoVentas = chbDocumentoVentas.Checked;
            oDocumentos.indAduanera = chkIndDepAduanera.Checked;
            oDocumentos.depAduanera = oDocumentos.indAduanera ? Convert.ToInt32(cboAduanas.SelectedValue) : (int?)null;
            oDocumentos.indDocumentoCompras = chkRegCompras.Checked;
            oDocumentos.indDocNoDom = chkNoDom.Checked;
            oDocumentos.indCreditoFiscal = chkCreditoFiscal.Checked;
            oDocumentos.indTesoreria = chkTesoreria.Checked;
            oDocumentos.indViaticos = chkViaticos.Checked;
            oDocumentos.indAlmacen = chkAlmacen.Checked;

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oDocumentos.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oDocumentos.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlDatos.Enabled = Flag;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oDocumentos == null)
            {
                oDocumentos = new DocumentosE();

                txtCodDoc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                chkDocReferencia.Checked = true;

                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtCodDoc.Text = oDocumentos.idDocumento;
                txtDescripcion.Text = oDocumentos.desDocumento;
                txtDesCorta.Text = oDocumentos.desCorta;
                cboDebeHaber.SelectedValue = oDocumentos.indDebeHaber.ToString();
                txtCodDoc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);

                chkFecVencimiento.Checked = oDocumentos.indFecVencimiento;
                chkIndReferencia.Checked = oDocumentos.indReferencia;
                chkDocReferencia.Checked = oDocumentos.EsReferencia;
                chkReDoc.Checked = oDocumentos.indRecepcionDcmto;
                chbDocumentoVentas.Checked = oDocumentos.indDocumentoVentas;
                txtCodSunat.Text = oDocumentos.CodigoSunat;
                cboMedioPago.SelectedValue = oDocumentos.codMedioPago;
                chkIndDepAduanera.Checked = oDocumentos.indAduanera;
                cboAduanas.SelectedValue = oDocumentos.depAduanera == null ? 0 : oDocumentos.depAduanera;
                chkRegCompras.Checked = oDocumentos.indDocumentoCompras;
                chkNoDom.Checked = oDocumentos.indDocNoDom;
                chkCreditoFiscal.Checked = oDocumentos.indCreditoFiscal;
                chkTesoreria.Checked = oDocumentos.indTesoreria;
                chkViaticos.Checked = oDocumentos.indViaticos;
                chkAlmacen.Checked = oDocumentos.indAlmacen;

                txtUsuRegistra.Text = oDocumentos.UsuarioRegistro;
                txtRegistro.Text = oDocumentos.FechaRegistro.ToString();
                txtUsuModifica.Text = oDocumentos.UsuarioModificacion;
                txtModifica.Text = oDocumentos.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsListaImpuestos.DataSource = oDocumentos.ListaImpuestosDocumentos;
            bsListaImpuestos.ResetBindings(false);
            lblTitulo.Text = "Registros " + bsListaImpuestos.List.Count.ToString();

            if (!oDocumentos.indBaja)
            {
                base.Nuevo();
            }
            else
            {
                BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
                BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            }
        }

        public override void Grabar()
        {
            try
            {
                bsListaImpuestos.EndEdit();                
                GuardarDatos();

                if (!ValidarGrabacion()) { return; }

                if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        oDocumentos = AgenteMaestros.Proxy.GrabarImpuestosDocumentos(oDocumentos, EnumOpcionGrabar.Insertar);
                        //Agregando el documento a la variable global...
                        VariablesLocales.ListarDocumentoGeneral.Add(oDocumentos);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        oDocumentos = AgenteMaestros.Proxy.GrabarImpuestosDocumentos(oDocumentos, EnumOpcionGrabar.Actualizar);
                        //Actualizando la Variable Global
                        for (Int32 i = 0; i < VariablesLocales.ListarDocumentoGeneral.Count; i++)
                        {
                            if (VariablesLocales.ListarDocumentoGeneral[i].idDocumento == oDocumentos.idDocumento)
                            {
                                VariablesLocales.ListarDocumentoGeneral[i] = oDocumentos;
                                i = VariablesLocales.ListarDocumentoGeneral.Count;
                            }
                        }

                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }

                bsListaImpuestos.DataSource = oDocumentos;
                bsListaImpuestos.ResetBindings(false);

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void AgregarDetalle()
        {
            bsListaImpuestos.EndEdit();

            if (String.IsNullOrEmpty(txtCodDoc.Text))
            {
                Global.MensajeFault("Debe ingresar la descripción del documento.");
                txtCodDoc.Focus();
                return;
            }

            frmDocumentosImpuestos oFrm = new frmDocumentosImpuestos(txtCodDoc.Text, txtDescripcion.Text);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Detalle != null)
            {
                ImpuestosDocumentosE detItem = oFrm.Detalle;

                if (oDocumentos.ListaImpuestosDocumentos == null)
                    oDocumentos.ListaImpuestosDocumentos = new List<ImpuestosDocumentosE>();

                oDocumentos.ListaImpuestosDocumentos.Add(detItem);

                bsListaImpuestos.DataSource = oDocumentos.ListaImpuestosDocumentos;
                bsListaImpuestos.ResetBindings(false);
            }

            base.AgregarDetalle();
        }

        public override void QuitarDetalle()
        {
            try
            {
                Anular();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                if (bsListaImpuestos.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        oDocumentos.ListaImpuestosDocumentos.RemoveAt(bsListaImpuestos.Position);
                        bsListaImpuestos.DataSource = oDocumentos.ListaImpuestosDocumentos;
                        bsListaImpuestos.ResetBindings(false);

                        base.Anular();

                        BloquearOpcion(EnumOpcionMenuBarra.Grabar, true);
                        BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
                        BloquearOpcion(EnumOpcionMenuBarra.Editar, false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }      

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<DocumentosE>(oDocumentos);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            if (chkIndDepAduanera.Checked)
            {
                if (Convert.ToInt32(cboAduanas.SelectedValue) == 0)
                {
                    Global.MensajeComunicacion("El check de Ind. Depedencia Aduanera esta habilitado, tiene que escoger uno.");
                    return false;
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmDocumentos_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                Nuevo();
                dgvImpuestos.ClearSelection();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvImpuestos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (bsListaImpuestos.Current != null)
                {
                    ImpuestosDocumentosE oID = new ImpuestosDocumentosE();
                    oID = (ImpuestosDocumentosE)bsListaImpuestos.Current;

                    frmDocumentosImpuestos oFrm = new frmDocumentosImpuestos(oID);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Detalle != null)
                    {
                        oDocumentos.ListaImpuestosDocumentos[e.RowIndex] = oFrm.Detalle;
                        bsListaImpuestos.ResetBindings(false);
                    }
                }
            }
        }

        private void bsListaImpuestos_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType.ToString() == "ItemChanged")
            {
                Modificacion = true;
            }
        }

        private void btActivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.MensajeConfirmacion("Desea volver activar este documento") == DialogResult.Yes)
                {
                    AgenteMaestros.Proxy.AnularActivarDocumento(txtCodDoc.Text, false);

                    //Actualizando la Variable Global
                    for (Int32 i = 0; i < VariablesLocales.ListarDocumentoGeneral.Count; i++)
                    {
                        if (VariablesLocales.ListarDocumentoGeneral[i].idDocumento == oDocumentos.idDocumento)
                        {
                            VariablesLocales.ListarDocumentoGeneral[i].indBaja = false;
                            VariablesLocales.ListarDocumentoGeneral[i].fecBaja = (Nullable<DateTime>)null;
                            i = VariablesLocales.ListarDocumentoGeneral.Count;
                        }
                    }

                    Global.MensajeComunicacion("El documento se activó correctamente...");
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkIndDepAduanera_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIndDepAduanera.Checked)
            {
                cboAduanas.Enabled = true;
            }
            else
            {
                cboAduanas.Enabled = false;
                cboAduanas.SelectedValue = 0;
            }
        }

        #endregion

    }
}
