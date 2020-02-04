using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Entidades.Almacen;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Presentadora.AgenteServicio;

namespace ClienteWinForm.Almacen
{
    public partial class frmCorrelativo : FrmMantenimientoBase
    {

        #region Constructor

        public frmCorrelativo()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();
        }

        

        public frmCorrelativo(Int32 idEmpresa, Int32 idCorrelativo)
            : this()
        {
            oCorrelativo = AgenteAlmacen.Proxy.ObtenerCorrelativo(idEmpresa, idCorrelativo);

        }
        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        CorrelativoE oCorrelativo= null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        void EsNuevoRegistro()
        {
            if (oCorrelativo == null)
            {
                oCorrelativo = new CorrelativoE();

                oCorrelativo.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;


                txtUsuRegistra.Text = oCorrelativo.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oCorrelativo.FechaRegistro = VariablesLocales.FechaHoy;
                txtRegistro.Text = oCorrelativo.FechaRegistro.ToString();
                txtUsuModifica.Text = oCorrelativo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oCorrelativo.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oCorrelativo.FechaModificacion.ToString();
                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtDes.Text = oCorrelativo.Descripción;
                txtSer.Text = oCorrelativo.numSerie;
                txtCorre.Text = oCorrelativo.numCorrelativo;
                cboTipo.SelectedValue = Convert.ToInt32(oCorrelativo.idTipo);
                txtFor.Text = oCorrelativo.formato;


                txtUsuRegistra.Text = oCorrelativo.UsuarioRegistro;
                txtRegistro.Text = oCorrelativo.FechaRegistro.ToString();
                txtUsuModifica.Text = oCorrelativo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oCorrelativo.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oCorrelativo.FechaModificacion.ToString();
                opcion = (Int32)EnumOpcionGrabar.Actualizar;

            }

            base.Nuevo();
        }

        void LlenarCombos()
        {
            List<ParTabla> ListaCorrelativo = AgenteGenerales.Proxy.ListarParTablaPorGrupo(327000, string.Empty);
            ListaCorrelativo.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione });
            ComboHelper.RellenarCombos<ParTabla>(cboTipo, (from x in ListaCorrelativo orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
        }

        void GuardarDatos()
        {
            oCorrelativo.Descripción = txtDes.Text;
            oCorrelativo.numSerie = txtSer.Text;
            oCorrelativo.numCorrelativo = txtCorre.Text;
            oCorrelativo.idTipo = Convert.ToInt32(cboTipo.SelectedValue.ToString());
            oCorrelativo.formato = txtFor.Text;
        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlDatos.Enabled = Flag;
            //pnlOtros.Enabled = Flag;
            //pnlContacto.Enabled = Flag;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            BloquearPaneles(true);
            oCorrelativo = new CorrelativoE();
            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oCorrelativo != null)
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
                            oCorrelativo = AgenteAlmacen.Proxy.InsertarCorrelativo(oCorrelativo);
                            //txtIdAlmacen.Text = oDocumentos.idAlmacen.ToString("000");
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oCorrelativo = AgenteAlmacen.Proxy.ActualizarCorrelativo(oCorrelativo);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                }
                base.Grabar();
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
            String Respuesta = ValidarEntidad<CorrelativoE>(oCorrelativo);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmCorrelativo_Load(object sender, EventArgs e)
        {
            Grid = false;
            EsNuevoRegistro();
        }

        #endregion
    }
}
