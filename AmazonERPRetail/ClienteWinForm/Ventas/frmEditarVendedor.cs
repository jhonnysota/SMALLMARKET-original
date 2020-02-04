using ClienteWinForm.Busquedas;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Ventas;
using Infraestructura;
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

namespace ClienteWinForm.Ventas
{
    public partial class frmEditarVendedor : frmResponseBase
    {
        public frmEditarVendedor()
        {
            InitializeComponent();
        }

        public frmEditarVendedor(EmisionDocumentoE Emidoctmp,String TipoFrm_)
       : this()
        {
            EmiDoc = Emidoctmp;
            TipoFrm = TipoFrm_;
        }

        public EmisionDocumentoE EmiDoc = new EmisionDocumentoE();
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        String TipoFrm = String.Empty;
        void LlenarCombos()
        {
            //Establecimientos
            List<EstablecimientosE> oListaEstablecimientos = AgenteMaestro.Proxy.ListarEstablecimientos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);
            oListaEstablecimientos.Add(new EstablecimientosE() { idEstablecimiento = Variables.Cero, Descripcion = Variables.Seleccione });
            ComboHelper.LlenarCombos<EstablecimientosE>(cboEstablecimiento, (from x in oListaEstablecimientos orderby x.idEstablecimiento select x).ToList(), "idEstablecimiento", "Descripcion");

            if (TipoFrm != "Vendedor")
            {
                //Divisiones
                List<ParTabla> oListaDivisiones = AgenteGeneral.Proxy.ListarParTablaPorNemo("DIVI");
                oListaDivisiones.Add(new ParTabla() { IdParTabla = 0, Nombre = Variables.Seleccione });
                ComboHelper.LlenarCombos<ParTabla>(cboDivision, (from x in oListaDivisiones orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre");
                oListaDivisiones = null;
            }
            else
            {
                cboDivision.Enabled = false;
            }
            oListaEstablecimientos = null;
        }

        void DatosEntrada()
        {
            txtIdVendedor.Text = EmiDoc.idVendedor == 0 ? String.Empty : EmiDoc.idVendedor.ToString();
            txtVendedor.Text = EmiDoc.Vendedor;
            if (TipoFrm != "Vendedor")
            {
                cboDivision.SelectedValue = Convert.ToInt32(EmiDoc.idDivision);
            }
            cboEstablecimiento.SelectedValue = EmiDoc.idEstablecimiento;
            cboEstablecimiento_SelectionChangeCommitted(new Object(), new EventArgs());
            cboZona.SelectedValue = EmiDoc.idZona;
        }

        public override void Aceptar()
        {
            try
            {
                if (ValidarGrabacion())
                {

                    EmiDoc.idVendedor = String.IsNullOrEmpty(txtIdVendedor.Text.Trim()) ? 0 : Convert.ToInt32(txtIdVendedor.Text);

                    if (VariablesLocales.oVenParametros.indZona)
                    {
                        EmiDoc.idEstablecimiento = Convert.ToInt32(cboEstablecimiento.SelectedValue);
                        EmiDoc.idZona = cboZona.SelectedValue != null ? Convert.ToInt32(cboZona.SelectedValue) : (Int32?)null;

                        if (TipoFrm != "Vendedor")
                        {
                            EmiDoc.idDivision = Convert.ToInt32(cboDivision.SelectedValue);
                        }
                    }
                    else
                    {
                        EmiDoc.idEstablecimiento = (Int32?)null;
                        EmiDoc.idZona = (Int32?)null;
                        if (TipoFrm != "Vendedor")
                        {
                            EmiDoc.idDivision = (Int32?)null;
                        }
                    }

                    base.Aceptar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #region Eventos

        private void btBuscarVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarVendedor oFrm = new frmBuscarVendedor();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oVendedor != null)
                {
                    txtIdVendedor.Text = oFrm.oVendedor.idPersona.ToString();
                    txtVendedor.Text = oFrm.oVendedor.RazonSocial;
                    if (TipoFrm != "Vendedor")
                    {
                        cboDivision.SelectedValue = Convert.ToInt32(oFrm.oVendedor.idDivision);
                    }
                    cboEstablecimiento.Focus();
                    cboEstablecimiento.SelectedValue = Convert.ToInt32(oFrm.oVendedor.idEstablecimiento);

                    if (cboEstablecimiento.SelectedValue != null)
                    {
                        cboEstablecimiento_SelectionChangeCommitted(new Object(), new EventArgs());
                        cboZona.SelectedValue = Convert.ToInt32(oFrm.oVendedor.idZona);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboEstablecimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboEstablecimiento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (VariablesLocales.oVenParametros.indZona)
                {
                    List<ZonaTrabajoE> oListaZonas = AgenteVentas.Proxy.ListarZonasPorIdEstablecimiento(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, Convert.ToInt32(cboEstablecimiento.SelectedValue));
                    ComboHelper.LlenarCombos<ZonaTrabajoE>(cboZona, oListaZonas, "idZona", "Descripcion");

                    if (oListaZonas.Count > Variables.Cero && oListaZonas != null)
                    {
                        //int idZona = (oListaZonas.Where(x => x.Principal == true).Select(s => s.idZona).Single());
                        ZonaTrabajoE oZona = (oListaZonas.Where(x => x.Principal == true).SingleOrDefault());

                        if (oZona != null)
                        {
                            cboZona.SelectedValue = oZona.idZona;
                        }

                        cboZona.Enabled = true;
                    }
                    else
                    {
                        cboZona.DataSource = null;
                        cboZona.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void frmEditarVendedor_Load(object sender, EventArgs e)
        {
            LlenarCombos();
            DatosEntrada();
        }

        #endregion

    }
}
