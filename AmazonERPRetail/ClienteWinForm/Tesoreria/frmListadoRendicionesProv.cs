using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.Maestros;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using ClienteWinForm.Busquedas;
using ClienteWinForm.Contabilidad.Reportes;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmListadoRendicionesProv : FrmMantenimientoBase
    {

        public frmListadoRendicionesProv()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvRendiciones, true);
        }

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmSolicitudProvRendicion);

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
                oFrm = new frmSolicitudProvRendicion()
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
                if (bsRendiciones.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmSolicitudProvRendicion);

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
                    oFrm = new frmSolicitudProvRendicion(((SolicitudProveedorRendicionE)bsRendiciones.Current).idRendicion)
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
                bsRendiciones.DataSource = AgenteTesoreria.Proxy.ListarSolicitudProveedorRendicion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idProveedor, dtpFecIni.Value.Date, dtpFecFin.Value.Date);
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
                if (bsRendiciones.Count > 0)
                {
                    List<SolicitudProveedorRendicionDetE> oRendiciones = AgenteTesoreria.Proxy.RendicionImpresion(idRendicion: ((SolicitudProveedorRendicionE)bsRendiciones.Current).idRendicion);

                    if (oRendiciones.Count > 0)
                    {
                        frmImpresionBase oFrm = new frmImpresionBase(oRendiciones, "Vista Previa de la Rendición de Adelanto a Proveedor")
                        {
                            MdiParent = MdiParent
                        };

                        oFrm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                if (bsRendiciones.Count > Variables.Cero)
                {
                    Int32 resp = 0;

                    if (((SolicitudProveedorRendicionE)bsRendiciones.Current).Estado == false)
                    {
                        if (Global.MensajeConfirmacion("Desea eliminar la rendición escogida?") == DialogResult.Yes)
                        {
                            resp = AgenteTesoreria.Proxy.EliminarSolicitudProveedorRendicion(((SolicitudProveedorRendicionE)bsRendiciones.Current).idRendicion);

                            if (resp > 0)
                            {
                                Buscar();
                                Global.MensajeComunicacion("Se eliminó la Rendición");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmSolicitudProvRendicion oFrm = sender as frmSolicitudProvRendicion;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoRendicionesProv_Load(object sender, EventArgs e)
        {
            Grid = true;
            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);

            if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
            {
                dgvRendiciones.Columns[0].Visible = false;
            }
        }

        private void bsRendiciones_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = String.Format("Registros {0}", bsRendiciones.Count.ToString());
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvRendiciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                            dgvRendiciones.Focus();
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

        private void tsmiGenerarAsiento_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsRendiciones.Current != null)
                {
                    SolicitudProveedorRendicionE current = (SolicitudProveedorRendicionE)bsRendiciones.Current;
                    String Anio = current.AnioPeriodo;
                    String Mes = current.MesPeriodo;
                    String Libro = current.idComprobante;
                    String File = current.numFile;
                    String Voucher = current.numVoucher;

                    if (current.Estado)
                    {
                        Global.MensajeComunicacion("La rendición se encuentra cerrada, tiene que abrirla antes de volver a generar el asiento.");
                        return;
                    }

                    if (!String.IsNullOrWhiteSpace(Voucher) && !String.IsNullOrWhiteSpace(File) && !String.IsNullOrWhiteSpace(Libro))
                    {
                        VoucherE oVoucher = AgenteContabilidad.Proxy.ObtenerVoucherPorCodigo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, Anio, Mes, Voucher, Libro, File, "N");

                        if (oVoucher != null)
                        {
                            Global.MensajeComunicacion("El N° de voucher existe, si el registro se encuentra Abierto, limpie el N° de Voucher con la opción correspondiente.");
                            return;
                        } 
                    }

                    if (current.indDeposito)
                    {
                        if ((current.MontoAplicado + current.ImporteDepo) != current.impSolicitud)
                        {
                            Global.MensajeComunicacion("Tiene que cuadrar la rendición antes de Cerrarla.");
                            return;
                        }
                    }

                    if ((current.idMonedaSol == "01" ? current.totSoles : current.totDolares) >= current.MontoAplicado)
                    {
                        if (!current.Estado)
                        {
                            String Mensaje = AgenteTesoreria.Proxy.GenerarAsientoRendicion(current.idRendicion, VariablesLocales.SesionUsuario.Credencial);

                            if (!String.IsNullOrWhiteSpace(Mensaje))
                            {
                                Buscar();
                                Global.MensajeComunicacion(Mensaje);
                            }
                        }
                    }
                    else
                    {
                        Global.MensajeAdvertencia("No se puede cerrar la rendición porque el monto a rendir es menor al Total " + (current.idMonedaSol == "01" ? "Soles" : "Dólares"));
                    }

                    current = null;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsRendiciones.Current != null)
                {
                    SolicitudProveedorRendicionE current = (SolicitudProveedorRendicionE)bsRendiciones.Current;
                    VoucherE oVoucher = AgenteContabilidad.Proxy.ObtenerVoucherPorCodigo(current.idEmpresa, current.idLocal, current.AnioPeriodo, current.MesPeriodo, current.numVoucher, current.idComprobante, current.numFile);

                    if (oVoucher != null)
                    {
                        Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpresionVoucher);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Maximized;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmImpresionVoucher("N", oVoucher)
                        {
                            MdiParent = MdiParent
                        };

                        oFrm.Show();
                    }
                    else
                    {
                        Global.MensajeComunicacion("No existe voucher en Contabilidad.");
                    }

                    oVoucher = null;
                    current = null;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsRendiciones.Current != null)
                {
                    SolicitudProveedorRendicionE current = (SolicitudProveedorRendicionE)bsRendiciones.Current;

                    if (current.Estado)
                    {
                        Int32 resp = AgenteTesoreria.Proxy.EliminarAsientoRendicion(current, VariablesLocales.SesionUsuario.Credencial);

                        if (resp > 0)
                        {
                            Buscar();
                            Global.MensajeComunicacion("Voucher eliminado del módulo de contabilidad.");
                        }
                    }
                    else
                    {
                        Global.MensajeAdvertencia("El registro ya se encuentra Abierto.");
                    }

                    current = null;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsRendiciones.Current != null)
                {
                    SolicitudProveedorRendicionE current = (SolicitudProveedorRendicionE)bsRendiciones.Current;

                    if (!current.Estado)
                    {
                        SolicitudProveedorRendicionE oRendicionConta = new SolicitudProveedorRendicionE()
                        {
                            idRendicion = current.idRendicion,
                            AnioPeriodo = String.Empty,
                            MesPeriodo = String.Empty,
                            idComprobante = String.Empty,
                            numFile = String.Empty,
                            numVoucher = String.Empty,
                            UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial
                        };

                        Int32 resp = AgenteTesoreria.Proxy.ActualizarRendicionConta(oRendicionConta);

                        if (resp > 0)
                        {
                            Buscar();
                            Global.MensajeComunicacion("Se ha limpiado el N° de Voucher.");
                        }
                    }
                    else
                    {
                        Global.MensajeFault("Antes de limpiar el número del voucher tiene que abrir la rendición.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvRendiciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((Boolean)dgvRendiciones.Rows[e.RowIndex].Cells["Estado"].Value == true)
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

        private void btActualizarTot_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsRendiciones.Count > 0)
                {
                    List<SolicitudProveedorRendicionE> oListaRendiciones = new List<SolicitudProveedorRendicionE>();

                    foreach (SolicitudProveedorRendicionE item in bsRendiciones.List)
                    {
                        if (item.totSoles == 0 && item.totDolares == 0)
                        {
                            oListaRendiciones.Add(item);
                        }
                    }

                    if (oListaRendiciones.Count > 0)
                    {
                        Int32 resp = AgenteTesoreria.Proxy.ActualizarTotales(oListaRendiciones);

                        if (resp > 0)
                        {
                            Buscar();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiVoucherDep_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsRendiciones.Current is SolicitudProveedorRendicionE current)
                {
                    if (current.indDeposito && !String.IsNullOrWhiteSpace(current.numVoucher))
                    {
                        VoucherE oVoucher = AgenteContabilidad.Proxy.ObtenerVoucherPorCodigo(current.idEmpresa, current.idLocal, current.AnioDepo, current.MesDepo, current.numVoucherDepo, current.DiarioDepo, current.FileDepo);

                        if (oVoucher != null)
                        {
                            Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpresionVoucher);

                            if (oFrm != null)
                            {
                                if (oFrm.WindowState == FormWindowState.Minimized)
                                {
                                    oFrm.WindowState = FormWindowState.Maximized;
                                }

                                oFrm.BringToFront();
                                return;
                            }

                            oFrm = new frmImpresionVoucher("N", oVoucher)
                            {
                                MdiParent = MdiParent
                            };

                            oFrm.Show();
                        }
                        else
                        {
                            Global.MensajeComunicacion("No existe voucher del depósito en Contabilidad.");
                        }

                        oVoucher = null;
                        current = null; 
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiLimpiarDep_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsRendiciones.Current is SolicitudProveedorRendicionE current)
                {
                    if (!current.Estado)
                    {
                        SolicitudProveedorRendicionE oRendicionConta = new SolicitudProveedorRendicionE()
                        {
                            idRendicion = current.idRendicion,
                            AnioDepo = String.Empty,
                            MesDepo = String.Empty,
                            DiarioDepo = String.Empty,
                            FileDepo = String.Empty,
                            numVoucherDepo = String.Empty,
                            UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial
                        };

                        Int32 resp = AgenteTesoreria.Proxy.ActualizarRendicionContaDepo(oRendicionConta);

                        if (resp > 0)
                        {
                            Buscar();
                            Global.MensajeComunicacion("Se ha limpiado el N° de Voucher del depósito.");
                        }
                    }
                    else
                    {
                        Global.MensajeFault("Antes de limpiar el número del voucher del depósito, tiene que abrir la rendición.");
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
