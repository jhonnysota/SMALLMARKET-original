using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmEEFFItem :   frmResponseBase
    {

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        EEFFItemE entidad = null;

        public EEFFItemE oEEFFItem = new EEFFItemE();

        public frmEEFFItem()
        {
            InitializeComponent();

        }

        public frmEEFFItem(List<EEFFItemE> oListaItem)
            :this()
        {
 
            entidad = new EEFFItemE();
            entidad.idEEFFItem = 0;
            entidad.idEEFF = 0;
            entidad.idEmpresa = 0;

            int valorMax=0;
                
            if (oListaItem.Count == Variables.Cero)
            {
                valorMax = 10;
            }
            else
            {
                valorMax = Convert.ToInt32(oListaItem.Max(mx => mx.secItem)) ;
                valorMax = Convert.ToInt32(valorMax.ToString().Substring(0, valorMax.ToString().Length - 1) + "0") + 10;
            }
                        
            entidad.secItem = valorMax.ToString();
            
        }

        public frmEEFFItem(EEFFItemE oEEFFItemE)
            : this()
        {
            try
            {
                entidad = oEEFFItemE;

                //DATOS
                txtSecItem.Text = entidad.secItem;
                txtDescrip.Text = entidad.desItem;
                txtCodSunat.Text = entidad.codSunat;

                //CHECKBOX
                chbImprimir.Checked = (entidad.indImprimir == "True" ? true : false);
                chbPorcentaje.Checked = (entidad.indPorcentaje == "True" ? true : false);
                chbEnviaExcel.Checked = (entidad.indEnviaExcel == "True" ? true : false);
                chkMostrarValor.Checked = entidad.indMostrar;
                
                // AUDITORIA
                txtUsuRegistro.Text = entidad.UsuarioRegistro;
                txtFechaRegistro.Text = entidad.FechaRegistro.ToString();
                txtUsuModificacion.Text = entidad.UsuarioModificacion;
                txtFechaModificacion.Text = entidad.FechaModificacion.ToString();

                txtSecItem.Focus();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }

        }

        public override void Aceptar()
        {
            try
            {
                // VALIDAMOS
                if (txtSecItem.Text.Trim().Length == 0)
                {
                    Global.MensajeAdvertencia("Debe de ingresar el Item");
                    txtSecItem.Focus();
                }
                else if (txtDescrip.Text.Trim().Length == 0)
                {
                    Global.MensajeAdvertencia("Debe de ingresar la descripción del Item");
                    txtDescrip.Focus();
                }
                else                
                {
                    //CARGAMOS VARIABLES
                    oEEFFItem.idEEFFItem = Convert.ToInt32(txtidItem.Text);
                    oEEFFItem.secItem = ("000000" + txtSecItem.Text).Substring(txtSecItem.Text.Length+1, 5);
                    oEEFFItem.desItem = txtDescrip.Text;

                    
                    oEEFFItem.TipoTabla = cboTipoTabla.SelectedValue.ToString();
                    oEEFFItem.TipoCaracteristica = cboTipoCaracteristica.SelectedValue.ToString();

                    oEEFFItem.TipoItem = cboTipoItem.SelectedValue.ToString();
                    oEEFFItem.TipoColumna = cboTipoColumna.SelectedValue.ToString();

                    oEEFFItem.desTabla = cboTipoTabla.Text;
                    oEEFFItem.desCaracteristica = cboTipoCaracteristica.Text;
                    oEEFFItem.codSunat = txtCodSunat.Text;

                    oEEFFItem.indImprimir = (chbImprimir.Checked? "True" : "False");
                    oEEFFItem.indPorcentaje = (chbPorcentaje.Checked ? "True" : "False");
                    oEEFFItem.indEnviaExcel = (chbEnviaExcel.Checked ? "True" : "False");
                    oEEFFItem.indMostrar = chkMostrarValor.Checked;

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtSecItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void frmEEFFItem_Load(object sender, EventArgs e)
        {
            CargarCombos();

            if (entidad.idEEFFItem != 0)
            {
                txtidItem.Text = Convert.ToString(entidad.idEEFFItem);
                cboTipoTabla.SelectedValue = entidad.TipoTabla.Trim();
                cboTipoCaracteristica.SelectedValue = entidad.TipoCaracteristica.Trim();

                cboTipoItem.SelectedValue = entidad.TipoItem.Trim();
                cboTipoColumna.SelectedValue = entidad.TipoColumna.Trim();
            }
            else 
            {
                txtidItem.Text = "0";
                txtSecItem.Text = entidad.secItem;

                txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }
        }

        void CargarCombos()
        {
            ComboHelper.RellenarCombos<DataTable>(cboTipoItem, Global.CargarTipoItemEEFF(), "IdTipoItem", "TipoItem", false);
            ComboHelper.RellenarCombos<DataTable>(cboTipoColumna, Global.CargarTipoColumnaEEFFItem(), "IdColumna", "Columna", false);
            ComboHelper.RellenarCombos<DataTable>(cboTipoTabla, Global.CargarTipoTablaEEFFItem(), "IdTipoTabla", "TipoTabla", false);
            ComboHelper.RellenarCombos<DataTable>(cboTipoCaracteristica, Global.CargarTipoCaracteristicaEEFFItem(), "IdCaracteristica", "Caracteristica", false);
        }

        private void frmEEFFItem_Shown(object sender, EventArgs e)
        {
            txtDescrip.Focus();
        }

    }
}
