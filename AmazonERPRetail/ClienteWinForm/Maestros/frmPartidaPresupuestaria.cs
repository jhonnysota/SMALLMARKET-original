using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Maestros
{
    public partial class frmPartidaPresupuestaria : FrmMantenimientoBase
    {
        #region Constructores
        
        public frmPartidaPresupuestaria()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        public frmPartidaPresupuestaria(PartidaPresupuestariaE oPP)
            : this()
        {
            oPresupuesto = oPP;
        } 

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteGeneral { get { return new MaestrosServiceAgent(); } }
        PartidaPresupuestariaE oPresupuesto = null;
        Int32 Opcion;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            cboIndicaUltimo.DataSource = Global.CargarSN();
            cboIndicaUltimo.ValueMember = "id";
            cboIndicaUltimo.DisplayMember = "Nombre";

            cboTitulo.DataSource = Global.CargarTitDet();
            cboTitulo.ValueMember = "id";
            cboTitulo.DisplayMember = "Nombre";

            cboTipoPartida.DataSource = Global.CargarTipoPartida();
            cboTipoPartida.ValueMember = "id";
            cboTipoPartida.DisplayMember = "Nombre";
        }

        void DatosPorGrabar()
        {
            oPresupuesto.codPartidaPresuSup = txtCodSuperior.Text;
            oPresupuesto.tipPartidaPresu = cboTipoPartida.SelectedValue.ToString();
            oPresupuesto.codPartidaPresu = txtCodPartida.Text;
            oPresupuesto.desPartidaPresu = txtDescripcion.Text;
            oPresupuesto.abrevPartidaPresu = txtAbreviatura.Text;
            oPresupuesto.indUltNodo = cboIndicaUltimo.SelectedValue.ToString();
            oPresupuesto.numNivel = Convert.ToInt32(nudNivel.Value);
            oPresupuesto.tipTituloNodo = cboTitulo.SelectedValue.ToString();
            oPresupuesto.indBaja = chkIndicaBaja.Checked;

            if (oPresupuesto.indBaja)
            {
                oPresupuesto.FechaBaja = dtpFecBaja.Value.Date;
            }

            txtUsuRegistra.Text = oPresupuesto.UsuarioRegistro;
            txtRegistro.Text = Convert.ToDateTime(oPresupuesto.fechaRegistro).ToString("dd/MM/yyyy");
            txtUsuModifica.Text = oPresupuesto.UsuarioModificacion;
            txtModifica.Text = Convert.ToDateTime(oPresupuesto.fechaModificacion).ToString("dd/MM/yyyy");
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oPresupuesto == null)
            {
                oPresupuesto = new PartidaPresupuestariaE();

                oPresupuesto.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                txtUsuRegistra.Text = oPresupuesto.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                txtUsuModifica.Text = oPresupuesto.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtCodSuperior.Text = oPresupuesto.codPartidaPresuSup;
                btBuscarCodigo.Enabled = false;
                cboTipoPartida.SelectedValue = oPresupuesto.tipPartidaPresu;
                cboTipoPartida.Enabled = false;
                txtCodPartida.Text = oPresupuesto.codPartidaPresu;
                txtCodPartida.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtDescripcion.Text = oPresupuesto.desPartidaPresu;
                txtAbreviatura.Text = oPresupuesto.abrevPartidaPresu;
                cboIndicaUltimo.SelectedValue = oPresupuesto.indUltNodo;
                nudNivel.Value = Convert.ToInt32(oPresupuesto.numNivel);
                cboTitulo.SelectedValue = oPresupuesto.tipTituloNodo;
                chkIndicaBaja.Checked = oPresupuesto.indBaja;

                if (oPresupuesto.indBaja)
                {
                    dtpFecBaja.Value = Convert.ToDateTime(oPresupuesto.FechaBaja);
                }

                txtUsuRegistra.Text = oPresupuesto.UsuarioRegistro;
                txtRegistro.Text = Convert.ToDateTime(oPresupuesto.fechaRegistro).ToString("dd/MM/yyyy");
                txtUsuModifica.Text = oPresupuesto.UsuarioModificacion;
                txtModifica.Text = Convert.ToDateTime(oPresupuesto.fechaModificacion).ToString("dd/MM/yyyy");

                oPresupuesto.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oPresupuesto != null)
                {
                    DatosPorGrabar();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (Opcion == Convert.ToInt32(EnumOpcionGrabar.Insertar))
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oPresupuesto = AgenteGeneral.Proxy.InsertarPartidaPresupuestaria(oPresupuesto);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oPresupuesto = AgenteGeneral.Proxy.ActualizarPartidaPresupuestaria(oPresupuesto);
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

        #endregion

        #region Eventos

        private void frmPartidaPresupuestaria_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        private void chkIndicaBaja_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIndicaBaja.Checked)
            {
                dtpFecBaja.Enabled = true;
            }
            else
            {
                dtpFecBaja.Enabled = false;
            }
        }

        private void btBuscarCodigo_Click(object sender, EventArgs e)
        {
            frmBuscarPartidaOpcionArbol oFrm = new frmBuscarPartidaOpcionArbol(cboTipoPartida.SelectedValue.ToString());

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPresupuesto != null)
            {
                txtCodPartida.Text = oFrm.oPresupuesto.codPartidaPresu;
                txtCodSuperior.Text = oFrm.oPresupuesto.codPartidaPresu;
                nudNivel.Value = Convert.ToInt32(oFrm.oPresupuesto.numNivel);

                nudNivel.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                nudNivel.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }
        } 

        #endregion
    }
}
