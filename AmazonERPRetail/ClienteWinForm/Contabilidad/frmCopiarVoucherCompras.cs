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
    public partial class frmCopiarVoucherCompras : frmResponseBase
    {
        public frmCopiarVoucherCompras()
        {
            InitializeComponent();
        }

        public frmCopiarVoucherCompras(VoucherE Voucher_)
            : this()
        {
            Voucher = Voucher_;
        }
        
        VoucherE Voucher = new VoucherE();
        public VoucherItemE oVoucherItem = new VoucherItemE();

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

            /////PERIODO////
            DataTable oDt = FechasHelper.CargarMesesContable("MA");
            DataRow Fila = oDt.NewRow();
            Fila["MesId"] = "0";
            Fila["MesDes"] = Variables.Todos;
            oDt.Rows.Add(Fila);

            oDt.DefaultView.Sort = "MesId";
            cboPeriodo.DataSource = oDt;
            cboPeriodo.ValueMember = "MesId";
            cboPeriodo.DisplayMember = "MesDes";
            cboPeriodo.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

        }
        
        public override bool ValidarGrabacion()
        {
            String Mes = dtpProceso.Value.ToString("MM");
            String mesper = cboPeriodo.SelectedValue.ToString();

            if (Mes != cboPeriodo.SelectedValue.ToString())
            {
                if (mesper == "13" && Mes != "12")
                {
                    Global.MensajeComunicacion("Los meses no coinciden");
                    return false;
                }
                else if( mesper == "00" && Mes != "01")
                {
                    Global.MensajeComunicacion("Los meses no coinciden");
                    return false;
                }
                else if(mesper == "13" && Mes != "12" || mesper == "00" && Mes != "01")
                {

                    if (mesper != Mes)
                    {
                        Global.MensajeComunicacion("Los meses no coinciden");
                        return false;
                    }
                }
             
            }

            return base.ValidarGrabacion();
        }

        public override void Aceptar()
        {
            try
            {
                if (ValidarGrabacion())
                {

                    oVoucherItem.idComprobante = cboLibro.SelectedValue.ToString();
                    oVoucherItem.numFile = cboFile.SelectedValue.ToString();
                    oVoucherItem.MesPeriodo = cboPeriodo.SelectedValue.ToString();
                    oVoucherItem.fecDocumento = Convert.ToDateTime(dtpProceso.Value.Date);
                   

                    base.Aceptar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void frmCancelacionVoucherCompras_Load(object sender, EventArgs e)
        {
            LlenarCombos();
            cboLibro.SelectedValue = Voucher.idComprobante;
            cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
            cboFile.SelectedValue = Voucher.numFile;
            cboPeriodo.SelectedValue = Voucher.MesPeriodo;
            dtpProceso.Value = Voucher.fecOperacion.Value;

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

 
    }
}
