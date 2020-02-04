using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClienteWinForm.Busquedas;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Presentadora.AgenteServicio;

namespace ClienteWinForm.Contabilidad
{
    public partial class FrmEmpresaConcar : FrmMantenimientoBase
    {
        #region Constructor

        public FrmEmpresaConcar()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        public FrmEmpresaConcar(EmpresaConcarE oListaEmpresaConcar)
            : this()
        {
            oEmpresaConcar = oListaEmpresaConcar;
        }

        public FrmEmpresaConcar(Int32 idEmpresa)
            : this()
        {
            oEmpresaConcar = AgenteContabilidad.Proxy.ObtenerEmpresaConcar(idEmpresa);
        }

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        EmpresaConcarE oEmpresaConcar = null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        void EsNuevoRegistro()
        {
            if (oEmpresaConcar == null)
            {
                oEmpresaConcar = new EmpresaConcarE();
                oEmpresaConcar.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;

                txtUsuRegistra.Text = oEmpresaConcar.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oEmpresaConcar.FechaRegistro = VariablesLocales.FechaHoy;
                txtRegistro.Text = oEmpresaConcar.FechaRegistro.ToString();
                txtUsuModifica.Text = oEmpresaConcar.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oEmpresaConcar.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oEmpresaConcar.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtNomemep.Text = oEmpresaConcar.EmpresaDescripcion;
                txtIdEmpresa.Text = Convert.ToString(oEmpresaConcar.idEmpresa);
                txtCodEmpresa.Enabled = false;
                txtNomEmpresa.Enabled = false;
                txtCodEmpresa.Text = oEmpresaConcar.CodEmpresa;
                txtNomEmpresa.Text = oEmpresaConcar.NomEmpresa;

                txtUsuRegistra.Text = oEmpresaConcar.UsuarioRegistro;
                txtRegistro.Text = oEmpresaConcar.FechaRegistro.ToString();
                txtUsuModifica.Text = oEmpresaConcar.UsuarioModificacion;
                txtModifica.Text = oEmpresaConcar.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        void GuardarDatos()
        {
            oEmpresaConcar.idEmpresa = Convert.ToInt32(txtIdEmpresa.Text);
            oEmpresaConcar.CodEmpresa = txtCodEmpresa.Text;
            oEmpresaConcar.NomEmpresa = txtNomEmpresa.Text;
        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlDatos.Enabled = Flag;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Grabar()
        {
            try
            {
                if (oEmpresaConcar != null)
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
                            oEmpresaConcar = AgenteContabilidad.Proxy.InsertarEmpresaConcar(oEmpresaConcar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oEmpresaConcar = AgenteContabilidad.Proxy.ActualizarEmpresaConcar(oEmpresaConcar);
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

        public override Boolean ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<EmpresaConcarE>(oEmpresaConcar);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos
        
        private void FrmEmpresaConcar_Load(object sender, EventArgs e)
        {
            Grid = false;
            EsNuevoRegistro();
        }

        private void btEmpresa_Click(object sender, EventArgs e)
        {
            FrmBusquedaEmpresa oFrm = new FrmBusquedaEmpresa();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.empresa != null)
            {
                txtIdEmpresa.Text = oFrm.empresa.IdEmpresa.ToString();
                txtNomemep.Text = oFrm.empresa.NombreComercial;
            }
        } 

        #endregion

    }
}
