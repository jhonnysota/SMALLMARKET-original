using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmListadoSolicitudProv : FrmMantenimientoBase
    {

        public frmListadoSolicitudProv()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvSolicitudes, true);
        }

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombo()
        {
            cboEstados.DataSource = Global.CargarEstados("N");
            cboEstados.DisplayMember = "Nombre";
            cboEstados.ValueMember = "id";

            cboEstados.SelectedValue = "P";
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmSolicitudProv);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    //si la instancia existe la pongo en primer plano
                    oFrm.BringToFront();
                    return;
                }

                //sino existe la instancia se crea una nueva
                oFrm = new frmSolicitudProv()
                {
                    MdiParent = MdiParent
                };

                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Editar()
        {
            try
            {
                if (bsSolicitudes.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmSolicitudProv);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        //si la instancia existe la pongo en primer plano
                        oFrm.BringToFront();
                        return;
                    }

                    //sino existe la instancia se crea una nueva
                    oFrm = new frmSolicitudProv(((SolicitudProveedorE)bsSolicitudes.Current).idSolicitud)
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Buscar()
        {
            try
            {
                Int32 idProveedor = String.IsNullOrWhiteSpace(txtIdAuxiliar.Text.Trim()) ? 0 : Convert.ToInt32(txtIdAuxiliar.Text);
                String Estado = cboEstados.SelectedValue.ToString();

                if (Estado == "0")
                {
                    Estado = "%";
                }

                bsSolicitudes.DataSource = AgenteTesoreria.Proxy.ListarSolicitudProveedor(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal,
                                            idProveedor, dtpFecIni.Value, dtpFecFin.Value, Estado);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Imprimir()
        {
            try
            {
                if (bsSolicitudes.Count > 0)
                {
                    SolicitudProveedorE oSolicitudAdelanto = AgenteTesoreria.Proxy.SolicitudProvImpresion(((SolicitudProveedorE)bsSolicitudes.Current).idSolicitud);
                    frmImpresionBase oFrm = new frmImpresionBase(oSolicitudAdelanto, "Vista Previa de la Solicitud");
                    oFrm.MdiParent = MdiParent;
                    oFrm.Show();
                }
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
                //if (((SolicitudProveedorE)bsSolicitudes.Current).indGenerado)
                //{
                //    Global.MensajeComunicacion("La solicitud tiene rendición y se ha generado el voucher respectivo. Elimine el voucher antes de eliminar la solicitud.");
                //    return;
                //}

                if (((SolicitudProveedorE)bsSolicitudes.Current).indEstado == "PENDIENTE")
                {
                    Int32 resp = AgenteTesoreria.Proxy.EliminarSolicitudProveedor((SolicitudProveedorE)bsSolicitudes.Current);

                    if (resp > 0)
                    {
                        Global.MensajeFault("Registro eliminado.");
                    }
                }
                else
                {
                    Global.MensajeFault("Solo se pueden eliminar los registros Pendientes.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmSolicitudProv oFrm = sender as frmSolicitudProv;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoSolicitudProv_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);

            if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
            {
                dgvSolicitudes.Columns[0].Visible = false;
            }

            LlenarCombo();
        }

        private void bsSolicitudes_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = String.Format("Registros {0}", bsSolicitudes.Count.ToString());
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvSolicitudes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtIdAuxiliar.Text = String.Empty;
            txtRazonSocial.Text = String.Empty;
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtIdAuxiliar.Text = String.Empty;
            txtRuc.Text = String.Empty;
        }

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(txtRuc.Text.Trim()) && String.IsNullOrWhiteSpace(txtRazonSocial.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtIdAuxiliar.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                        return;
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && String.IsNullOrWhiteSpace(txtRuc.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            dgvSolicitudes.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtIdAuxiliar.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRazonSocial.Focus();
                        return;
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void tsmiGenerarOp_Click(object sender, EventArgs e)
        {
            try
            {
                SolicitudProveedorE current = (SolicitudProveedorE)bsSolicitudes.Current;

                if (current != null)
                {
                    if (current.indEstado == "CERRADO")
                    {
                        Global.MensajeComunicacion("Esta solicitud ya se encuentra cerrada.");
                        return;
                    }

                    String resp = AgenteTesoreria.Proxy.GenerarOrdenPago(current.idSolicitud, VariablesLocales.SesionUsuario.Credencial);

                    if (resp == "Ok")
                    {
                        Buscar();
                        Global.MensajeComunicacion("La solicitud se cerró correctamente.");
                    } 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                if (((SolicitudProveedorE)bsSolicitudes.Current).indEstado == "PENDIENTE")
                {
                    Global.MensajeFault("Esta solicitud se encuentra abierta porque esta como pendiente.");
                    return;
                }

                String Resp = AgenteTesoreria.Proxy.AbrirSolicitudProveedor((SolicitudProveedorE)bsSolicitudes.Current, VariablesLocales.SesionUsuario.Credencial);

                if (Resp == "ok")
                {
                    Global.MensajeComunicacion("Se abrió la solicitud.");
                    Buscar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboEstados_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Buscar();

            if (cboEstados.SelectedValue.ToString() == "0")
            {
                tsmiAbrir.Enabled = true;
                tsmiGenerarOp.Enabled = true;
            }
            else if (cboEstados.SelectedValue.ToString() == "P")
            {
                tsmiAbrir.Enabled = false;
                tsmiGenerarOp.Enabled = true;
            }
            else
            {
                tsmiAbrir.Enabled = true;
                tsmiGenerarOp.Enabled = false;
            }
        }

        private void dgvSolicitudes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((String)dgvSolicitudes.Rows[e.RowIndex].Cells["indEstado"].Value == "CERRADO")
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Valores.ColorCerrado;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
