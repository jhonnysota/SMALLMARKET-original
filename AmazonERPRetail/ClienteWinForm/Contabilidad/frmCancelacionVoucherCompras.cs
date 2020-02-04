using ClienteWinForm.Busquedas;
using Entidades.Contabilidad;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmCancelacionVoucherCompras : frmResponseBase
    {
        public frmCancelacionVoucherCompras()
        {
            InitializeComponent();
        }

        public frmCancelacionVoucherCompras(VoucherE Voucher_)
            : this()
        {
            Voucher = Voucher_;
        }

        String indCtaGasto = String.Empty;
        VoucherE Voucher = new VoucherE();
        public VoucherItemE oVoucherItem = new VoucherItemE();
        PlanCuentasE oPlanCuentasGenerado = null;

        void LlenarCombos()
        {

            ///LIBROS///
            List<ComprobantesE> ListaTipoComprobante = new List<ComprobantesE>(VariablesLocales.oListaComprobantes);//AgenteContabilidad.Proxy.ListarComprobantes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ComprobantesE p = new ComprobantesE() { idComprobante = Variables.Cero.ToString(), desComprobanteComp = Variables.Todos };
            ListaTipoComprobante.Add(p);
            ComboHelper.RellenarCombos<ComprobantesE>(cboLibro, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp", false);
            cboLibro.SelectedValue = Variables.Cero.ToString();
            cboLibro.SelectedIndex = 5;
            cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
            ListaTipoComprobante = null;
        }

        public override void Aceptar()
        {
            try
            {
                if (ValidarGrabacion())
                {
                    if (!String.IsNullOrEmpty(txtDesCuentaIG.Text))
                    {
                        
                     oVoucherItem.idComprobante = cboLibro.SelectedValue.ToString();
                     oVoucherItem.numFile = cboFile.SelectedValue.ToString();
                     oVoucherItem.codCuenta = txtCuentaIG.Text;
                     oVoucherItem.fecDocumento = Convert.ToDateTime(dtpProceso.Value.Date);
                     oVoucherItem.tipCambio = Convert.ToDecimal(txtCambio.Text);

                    base.Aceptar();

                    }
                    else
                    {
                        Global.MensajeFault("No hay datos. Presione Cancelar por favor");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void frmCancelacionVoucherCompras_Load(object sender, EventArgs e)
        {
            //txtCambio.Text = Variables.ValorCeroDecimal.ToString("N3");
            //txtCambio.Text = Voucher.tipCambio);
            LlenarCombos();
            dtpProceso.Text = Voucher.fecDocumento.ToString();
        }

        private void cboLibro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboLibro.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles = new List<ComprobantesFileE>(((ComprobantesE)cboLibro.SelectedItem).ListaComprobantesFiles);//AgenteContabilidad.Proxy.ObtenerFilesPorIdComprobante(VariablesLocales.SesionLocal.IdEmpresa, cboLibro.SelectedValue.ToString());
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

        private void dtpProceso_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime Fecha = ((DateTimePicker)sender).Value;
                Decimal Monto = VariablesLocales.MontoTicaConta(Fecha.Date, "01", cboLibro.SelectedValue.ToString());

                if (Monto == 0)
                {
                    Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                }

                txtCambio.Text = Monto.ToString("N3");
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btCuentaIG_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCuentas oFrm = new frmBuscarCuentas();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Cuentas != null)
                {
                    oVoucherItem.PlanCuenta = VariablesLocales.ObtenerPlanCuenta(oFrm.Cuentas.codCuenta);

                    oVoucherItem.codCuenta = txtCuentaIG.Text = oVoucherItem.PlanCuenta.codCuenta;
                    txtDesCuentaIG.Text = oVoucherItem.PlanCuenta.Descripcion;


                    
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtCuentaIG_TextChanged(object sender, EventArgs e)
        {
            txtDesCuentaIG.Text = String.Empty;
        }

        private void txtCuentaIG_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCuentaIG.Text.Trim()) || String.IsNullOrEmpty(txtDesCuentaIG.Text.Trim()))
                {
                    if (!String.IsNullOrEmpty(txtCuentaIG.Text.Trim()))
                    {
                        oPlanCuentasGenerado = VariablesLocales.ObtenerPlanCuenta(txtCuentaIG.Text.Trim());

                        if (oPlanCuentasGenerado != null)
                        {
                            txtDesCuentaIG.Text = oPlanCuentasGenerado.Descripcion;
                            indCtaGasto = oPlanCuentasGenerado.indCuentaGastos;

                            if (oPlanCuentasGenerado.codColumnaCoven != (Int32)EnumTipoConceptosCompraVentas.BaseImponible)
                            {
                                Global.MensajeFault("La cuenta seleccionada no pertenece a la columna de Bases Imponibles definida en el Plan Contable");
                            }
                        }
                        else
                        {
                            Global.MensajeComunicacion("La cuenta ingresada no existe, vuelva a digitar.");
                            txtDesCuentaIG.Text = String.Empty;
                            btCuentaIG.PerformClick();
                        }

                        oPlanCuentasGenerado = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }
    }
}
