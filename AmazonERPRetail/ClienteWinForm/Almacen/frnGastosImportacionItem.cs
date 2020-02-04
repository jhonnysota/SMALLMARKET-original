using Entidades.Almacen;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
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
using Entidades.Maestros;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Almacen
{
    public partial class frnGastosImportacionItem : frmResponseBase
    {
        #region Constructor

        public frnGastosImportacionItem()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            LlenarCombos();
        }

        //Nuevo
        public frnGastosImportacionItem(List<HojaCostoItemE> ListaItem_ )
            : this()
        {
            ListaHojaCostositem = ListaItem_;
        }

        //Editar
        public frnGastosImportacionItem(GastosImportacionE oPrecioTemp_, List<HojaCostoItemE> oLista_ )
            : this()
        {
            GastosImportacionItem = oPrecioTemp_;
            ListaHojaCostositem =  oLista_;
        }

        #endregion

        #region Variables

        public GastosImportacionE GastosImportacionItem = null;
        List<HojaCostoItemE> ListaHojaCostositem = null;
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        List<DocumentosE> ListaDocumentos;
        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //////Moneda///////
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListaMoneda
                                                             orderby x.idMoneda
                                                             select x).ToList(), "idMoneda", "desMoneda", false);
            // Documentos
            ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral where x.indBaja == false select x).ToList();//AgenteMaestro.Proxy.ListarDocumentos();            
            DocumentosE Fila = new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione };
            ListaDocumentos.Add(Fila);

            ComboHelper.RellenarCombos<DocumentosE>(cboDocumento, (from x in ListaDocumentos
                                                                   where x.indDocumentoCompras == true || x.idDocumento == "0"
                                                                   orderby x.desDocumento
                                                                   select x).ToList(), "idDocumento", "desDocumento", false);

        }

        void Mon()
        {
            try
            {
                DateTime Fecha = dtpFecha.Value.Date;
                TipoCambioE Tica = VariablesLocales.RetornaTipoCambio(cboMoneda.SelectedValue.ToString(), Fecha);

                if (Tica != null)
                {
                    txtTipCambio.Text = Tica.valVenta.ToString("N3");
                }
                else
                {
                    txtTipCambio.Text = Variables.ValorCeroDecimal.ToString("N3");
                    dtpFecha.Focus();
                    Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void CalcularMontos()
        {
            Decimal MontoTotal = 0;

            if (txtMonto.Text != "")
            {
                if (cboMoneda.SelectedIndex == 0)
                {
                    MontoTotal = Math.Round(Convert.ToDecimal(txtMonto.Text) / Convert.ToDecimal(txtTipCambio.Text),2);
                    txtMontoDolares.Text = Convert.ToString(MontoTotal);

                }

                if (cboMoneda.SelectedIndex == 1)
                {
                    txtMontoDolares.Text = txtMonto.Text;
                }

            }
        }

        void CambioCheck()
        {
            if (chkItem.Checked == true)
            {
                txtItemADis.Enabled = true;
            }
            else
            {
                txtItemADis.Clear();
                txtItemADis.Enabled = false;               
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            txtRuc.TextChanged -= txtRuc_TextChanged;
            txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
            if (GastosImportacionItem == null)
            {
                GastosImportacionItem = new GastosImportacionE();

                GastosImportacionItem.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                GastosImportacionItem.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                GastosImportacionItem.idLocal = VariablesLocales.SesionLocal.IdLocal;
                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                if (GastosImportacionItem.Opcion == 0)
                {
                    GastosImportacionItem.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }

                txtDescipcion.Text = GastosImportacionItem.Descripcion;
                dtpFecha.Value = Convert.ToDateTime(GastosImportacionItem.Fecha);
                txtTipCambio.Text = Convert.ToString(GastosImportacionItem.TipoCambio);
                cboMoneda.SelectedValue = GastosImportacionItem.idMoneda;
                txtMonto.Text = Convert.ToString(GastosImportacionItem.Monto);
                txtMontoDolares.Text = Convert.ToString(GastosImportacionItem.MontoDolares);
                if (GastosImportacionItem.DistribuirItem == 1)
                {
                    chkItem.Checked = true;
                    txtItemADis.Text = GastosImportacionItem.ItemADistribuir;
                }
                else
                {
                    chkItem.Checked = false;
                }
                cboDocumento.SelectedValue = GastosImportacionItem.idDocumento;
                txtRuc.Text = GastosImportacionItem.Ruc;
                txtUsuarioRegistro.Text = GastosImportacionItem.UsuarioRegistro;
                txtFechaRegistro.Text = Convert.ToString(GastosImportacionItem.FechaRegistro);
                txtUsuarioModificacion.Text = GastosImportacionItem.UsuarioModificacion;
                txtFechaModificacion.Text = Convert.ToString(GastosImportacionItem.FechaModificacion);
                txtRazonSocial.Text = GastosImportacionItem.RazonSocial;
                txtSerie.Text = GastosImportacionItem.serDocumento;
                txtNumDoc.Text = GastosImportacionItem.numDocumento;
            }
            txtRuc.TextChanged += txtRuc_TextChanged;
            txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;

            base.Nuevo();
        }

        public override void Aceptar()
        {
            try
            {

                if (GastosImportacionItem != null)
                {
                    GastosImportacionItem.Descripcion = txtDescipcion.Text;
                    GastosImportacionItem.Fecha = dtpFecha.Value;
                    GastosImportacionItem.TipoCambio = Convert.ToDecimal(txtTipCambio.Text);
                    GastosImportacionItem.idMoneda = Convert.ToString(cboMoneda.SelectedValue);
                    GastosImportacionItem.Monto = Convert.ToDecimal(txtMonto.Text);
                    GastosImportacionItem.MontoDolares = Convert.ToDecimal(txtMontoDolares.Text);
                    if (chkItem.Checked == true)
                    {
                        GastosImportacionItem.DistribuirItem = 1;
                        GastosImportacionItem.ItemADistribuir = txtItemADis.Text;
                    }
                    else
                    {
                        GastosImportacionItem.DistribuirItem = 0;
                    }
                
                    GastosImportacionItem.Opcion = GastosImportacionItem.Opcion;
                    GastosImportacionItem.idDocumento = Convert.ToString(cboDocumento.SelectedValue);
                    GastosImportacionItem.Ruc = txtRuc.Text;
                    GastosImportacionItem.RazonSocial = txtRazonSocial.Text;
                    GastosImportacionItem.serDocumento = txtSerie.Text;
                    GastosImportacionItem.numDocumento = txtNumDoc.Text;
                    if (GastosImportacionItem.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        GastosImportacionItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        GastosImportacionItem.FechaRegistro = VariablesLocales.FechaHoy;
                        GastosImportacionItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        GastosImportacionItem.FechaModificacion = VariablesLocales.FechaHoy;
                    }
                    else
                    {
                        GastosImportacionItem.UsuarioModificacion = txtUsuarioModificacion.Text;
                        GastosImportacionItem.FechaModificacion = Convert.ToDateTime(txtFechaModificacion.Text);
                    }

                    String Linea = txtItemADis.Text;
                    if (Linea != "")
                    {
                        List<String> oLista = new List<String>(Linea.Split(','));
                        if (!ValidarGrabacion(oLista))
                        {
                            return;
                        }

                    }
                   

                    base.Aceptar();
                }

            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        bool ValidarGrabacion(List<String> Lista)
        {
            List<HojaCostoItemE> Items = ListaHojaCostositem;
            String NumHallado = "N";
            String Numero = String.Empty;

            foreach (String item in Lista)
            {
                NumHallado = "N";

                foreach (HojaCostoItemE itemCosto in Items)
                {
                    Numero = item;
                    if (item == itemCosto.idItemOC.ToString())
                    {
                        NumHallado = "S";
                    }   
                }

                if (NumHallado == "N")
                {
                    Global.MensajeComunicacion("El Item " + Numero + " no se encuentra como registro");
                    return false;
                }
            }


            DateTime Fecha = dtpFecha.Value.Date;
            TipoCambioE Tica = VariablesLocales.RetornaTipoCambio(cboMoneda.SelectedValue.ToString(), Fecha);

            if (Tica != null)
            {
                txtTipCambio.Text = Tica.valVenta.ToString("N3");
            }
            else
            {
                txtTipCambio.Text = Variables.ValorCeroDecimal.ToString("N3");
                dtpFecha.Focus();
                Global.MensajeComunicacion("Esta Fecha no contiene un Tipo De Cambio");
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frnGastosImportacionItem_Load(object sender, EventArgs e)
        {
            Nuevo();
            Mon();
            CambioCheck();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

            try
            {
                DateTime Fecha = dtpFecha.Value.Date;
                TipoCambioE Tica = VariablesLocales.RetornaTipoCambio(cboMoneda.SelectedValue.ToString(), Fecha);

                if (Tica != null)
                {
                    txtTipCambio.Text = Tica.valVenta.ToString("N3");
                }
                else
                {
                    txtTipCambio.Text = Variables.ValorCeroDecimal.ToString("N3");
                    dtpFecha.Focus();
                    Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        private void cboMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CalcularMontos();
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            CalcularMontos();
        }

        private void btRuc_Click(object sender, EventArgs e)
        {
            FrmBusquedaPersona oFrm = new FrmBusquedaPersona();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
            {
                txtRuc.Text = oFrm.oPersona.RUC;
                txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                GastosImportacionItem.idPersona = oFrm.oPersona.IdPersona;
            }
        }

        private void txtSerie_Leave(object sender, EventArgs e)
        {
            if (cboDocumento.SelectedValue.ToString() == "FV" || cboDocumento.SelectedValue.ToString() == "BV" || cboDocumento.SelectedValue.ToString() == "NC" || cboDocumento.SelectedValue.ToString() == "ND")
            {
                if (!String.IsNullOrEmpty(txtSerie.Text.Trim()))
                {
                    if (txtSerie.TextLength < txtSerie.MaxLength && Global.EsNumero(txtSerie.Text))
                    {
                        txtSerie.Text = txtSerie.Text.PadLeft(4, '0');
                    }
                }
            }
            else if (cboDocumento.SelectedValue.ToString() == "FC" || cboDocumento.SelectedValue.ToString() == "BR" || cboDocumento.SelectedValue.ToString() == "CR" || cboDocumento.SelectedValue.ToString() == "DR")
            {
                if (!String.IsNullOrEmpty(txtSerie.Text.Trim()))
                {
                    if (txtSerie.TextLength < txtSerie.MaxLength && Global.EsNumero(txtSerie.Text))
                    {
                        txtSerie.Text = txtSerie.Text.PadLeft(4, '0');
                    }
                }
            }
        }

        private void txtNumDoc_Leave(object sender, EventArgs e)
        {
            if (cboDocumento.SelectedValue.ToString() == "FV" || cboDocumento.SelectedValue.ToString() == "BV" || cboDocumento.SelectedValue.ToString() == "NC" || cboDocumento.SelectedValue.ToString() == "ND")
            {
                if (!String.IsNullOrEmpty(txtNumDoc.Text.Trim()))
                {
                    if (txtNumDoc.TextLength < txtNumDoc.MaxLength && Global.EsNumero(txtNumDoc.Text))
                    {
                        txtNumDoc.Text = txtNumDoc.Text.PadLeft(8, '0');
                    }
                }
            }
            else if (cboDocumento.SelectedValue.ToString() == "FC" || cboDocumento.SelectedValue.ToString() == "BR" || cboDocumento.SelectedValue.ToString() == "CR" || cboDocumento.SelectedValue.ToString() == "DR")
            {
                if (!String.IsNullOrEmpty(txtSerie.Text.Trim()))
                {
                    if (txtNumDoc.TextLength < txtNumDoc.MaxLength && Global.EsNumero(txtNumDoc.Text))
                    {
                        txtNumDoc.Text = txtNumDoc.Text.PadLeft(8, '0');
                    }
                }
            }
        }

        private void txtRazonSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Text = String.Empty;
        }

        private void txtRazonSocial_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtRazonSocial.Text = String.Empty;
        }

        private void txtRuc_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtRazonSocial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && String.IsNullOrEmpty(txtRuc.Text.Trim()))
            {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.TextChanged -= new EventHandler(txtRuc_TextChanged);
                            txtRazonSocial.TextChanged -= new EventHandler(txtRazonSocial_TextChanged);
                            GastosImportacionItem.idPersona = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                            txtRuc.TextChanged += new EventHandler(txtRuc_TextChanged);
                            txtRazonSocial.TextChanged += new EventHandler(txtRazonSocial_TextChanged);



                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.TextChanged -= new EventHandler(txtRuc_TextChanged);
                        txtRazonSocial.TextChanged -= new EventHandler(txtRazonSocial_TextChanged);
                        GastosImportacionItem.idPersona = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        txtRuc.TextChanged += new EventHandler(txtRuc_TextChanged);
                        txtRazonSocial.TextChanged += new EventHandler(txtRazonSocial_TextChanged);
                    }
                    else
                    {
                        txtRazonSocial.Text = String.Empty;
                        Global.MensajeFault("EL Ruc ingresado no existe");
                        btRuc.PerformClick();
                    }
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
            }
        }

        private void txtRuc_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                        txtRuc.TextChanged -= txtRuc_TextChanged;
                        txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                        List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                        if (oListaPersonas.Count > Variables.ValorUno)
                        {
                            frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                            {
                                txtRuc.TextChanged -= new EventHandler(txtRuc_TextChanged);
                                txtRazonSocial.TextChanged -= new EventHandler(txtRazonSocial_TextChanged);
                                GastosImportacionItem.idPersona = oFrm.oPersona.IdPersona;
                                txtRuc.Text = oFrm.oPersona.RUC;
                                txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                                txtRuc.TextChanged += new EventHandler(txtRuc_TextChanged);
                                txtRazonSocial.TextChanged += new EventHandler(txtRazonSocial_TextChanged);
                            }
                            else
                            {
                                txtRazonSocial.Focus();
                            }
                        }
                        else if (oListaPersonas.Count == 1)
                        {
                            txtRuc.TextChanged -= new EventHandler(txtRuc_TextChanged);
                            txtRazonSocial.TextChanged -= new EventHandler(txtRazonSocial_TextChanged);
                            GastosImportacionItem.idPersona = oListaPersonas[0].IdPersona;
                            txtRuc.Text = oListaPersonas[0].RUC;
                            txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                            txtRuc.TextChanged += new EventHandler(txtRuc_TextChanged);
                            txtRazonSocial.TextChanged += new EventHandler(txtRazonSocial_TextChanged);
                        }
                        else
                        {
                            txtRazonSocial.Text = String.Empty;
                            Global.MensajeFault("EL Ruc ingresado no existe");
                            btRuc.PerformClick();
                        }
                        txtRuc.TextChanged += txtRuc_TextChanged;
                        txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkItem_CheckedChanged(object sender, EventArgs e)
        {
            CambioCheck();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}
