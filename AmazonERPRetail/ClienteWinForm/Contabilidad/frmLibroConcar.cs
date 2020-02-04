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
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmLibroConcar : FrmMantenimientoBase
    {
        public frmLibroConcar()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();
        }
        public frmLibroConcar(Int32 idEmpresa, String csubdia)
            : this()
        {
            oLibroConcar = AgenteContabilidad.Proxy.Obtenerlibroconcar(idEmpresa, csubdia);
        }


        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        LibroConcarE oLibroConcar = null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            ///LIBROS///
            List<ComprobantesE> ListaTipoComprobante = new List<ComprobantesE>(VariablesLocales.oListaComprobantes);
            ComprobantesE p = new ComprobantesE() { idComprobante = Variables.Cero.ToString(), desComprobanteComp = Variables.Todos };
            ListaTipoComprobante.Add(p);
            ComboHelper.RellenarCombos<ComprobantesE>(cboLibro, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp", false);
            cboLibro.SelectedValue = Variables.Cero.ToString();


            
        }

        void EsNuevoRegistro()
        {
            if (oLibroConcar == null)
            {
                oLibroConcar = new LibroConcarE();



                oLibroConcar.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;


                txtUsuRegistra.Text = oLibroConcar.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oLibroConcar.FechaRegistro = VariablesLocales.FechaHoy;
                txtRegistro.Text = oLibroConcar.FechaRegistro.ToString();
                txtUsuModifica.Text = oLibroConcar.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oLibroConcar.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oLibroConcar.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;

            }
            else
            {


               
                txtDiario.Text = oLibroConcar.csubdia;
                txtNombre.Text = oLibroConcar.nombre;
                cboLibro.SelectedValue = oLibroConcar.idComprobante;
                if (cboLibro.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles = new List<ComprobantesFileE>(((ComprobantesE)cboLibro.SelectedItem).ListaComprobantesFiles);
                    ComprobantesFileE File = new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Todos };
                    ListaFiles.Add(File);
                    ComboHelper.RellenarCombos<ComprobantesFileE>(cboFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);
                }
                cboFile.SelectedValue = oLibroConcar.numFile;


                txtUsuRegistra.Text = oLibroConcar.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = oLibroConcar.FechaRegistro.ToString();
                txtUsuModifica.Text = oLibroConcar.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oLibroConcar.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oLibroConcar.FechaModificacion.ToString();
                if (cboFile.SelectedValue != null)
                {
                    cboFile.Enabled = true;
                }
                else
                {
                    cboFile.Enabled = false;
                }

                opcion = (Int32)EnumOpcionGrabar.Actualizar;

            }

            base.Nuevo();
        }

        void GuardarDatos()
        {
            oLibroConcar.csubdia = txtDiario.Text;
            oLibroConcar.nombre = txtNombre.Text;
            oLibroConcar.numFile = Convert.ToString(cboFile.SelectedValue);
            oLibroConcar.idComprobante = Convert.ToString(cboLibro.SelectedValue);

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
            oLibroConcar = new LibroConcarE();

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oLibroConcar != null)
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
                            oLibroConcar = AgenteContabilidad.Proxy.Insertarlibroconcar(oLibroConcar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oLibroConcar = AgenteContabilidad.Proxy.Actualizarlibroconcar(oLibroConcar);
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

        public override void Cerrar()
        {
            base.Cerrar();
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<LibroConcarE>(oLibroConcar);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmLibroConcar_Load(object sender, EventArgs e)
        {
            Grid = false;
            EsNuevoRegistro();
        }            

        private void cboLibro_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
            SendKeys.Send("{F4}");
        }

        private void cboFile_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
            SendKeys.Send("{F4}");
        }

        private void cboLibro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboLibro.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles = new List<ComprobantesFileE>(((ComprobantesE)cboLibro.SelectedItem).ListaComprobantesFiles);
                    ComprobantesFileE File = new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Todos };
                    ListaFiles.Add(File);
                    ComboHelper.RellenarCombos<ComprobantesFileE>(cboFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);

                    if (cboLibro.SelectedValue.ToString() == Variables.Cero.ToString())
                    {
                        cboFile.Enabled = false;
                    }
                    else
                    {
                        cboFile.Enabled = true;
                    }

                    if (ListaFiles.Count == 2)
                    {
                        cboFile.SelectedValue = ListaFiles[0].numFile;
                    }
                    else
                    {
                        cboFile.SelectedValue = Variables.Cero.ToString();
                    }
                    ListaFiles = null;
                    Buscar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboFile_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        #endregion
    }
}
