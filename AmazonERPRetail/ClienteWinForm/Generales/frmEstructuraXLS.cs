using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Generales
{
    public partial class frmEstructuraXLS : FrmMantenimientoBase
    {

        #region Constructores

        public frmEstructuraXLS()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            LlenarCombo();
        }

        public frmEstructuraXLS(List<EstructuraXLSE> oLista)
            : this()
        {
            oListaEstructuras = oLista;
        }

        public frmEstructuraXLS(EstructuraXLSE oEstru)
            : this()
        {
            oEstructura = oEstru;
        } 

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<EstructuraXLSE> oListaEstructuras = null;
        EstructuraXLSE oEstructura = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombo()
        {
            List<ParTabla> ListaTipos = AgenteGeneral.Proxy.ListarParTablaPorNemo("STREX");
            ParTabla oItem = new ParTabla() { IdParTabla = 0, Nombre = Variables.Escoger };
            ListaTipos.Add(oItem);
            ComboHelper.RellenarCombos<ParTabla>(cboTipo, (from x in ListaTipos orderby x.IdParTabla select x).ToList());
            ListaTipos = null;
            oItem = null;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (oEstructura == null)
                {
                    oEstructura = new EstructuraXLSE();

                    oEstructura.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    oEstructura.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                }
                else
                {
                    cboTipo.Enabled = false;
                    //cboCampos.Enabled = false;

                    //if (String.IsNullOrWhiteSpace(oEstructura.Tipo))
                    //{
                    //    cboTipo.Enabled = true;
                    //    cboCampos.Enabled = true;
                    //}

                    cboTipo.SelectedValue = Convert.ToInt32(oEstructura.Tipo);
                    cboTipo_SelectionChangeCommitted(new object(), new EventArgs());
                    cboCampos.SelectedValue = oEstructura.NombreCampo;
                    chkLectura.Checked = oEstructura.EsLineal;

                    if (chkLectura.Checked)
                    {
                        lblTitulo.Text = "Inicio Lectura";
                        txtFila.Text = oEstructura.FilaInicio.ToString();
                    }
                    else
                    {
                        lblTitulo.Text = "Fila Excel";
                        txtFila.Text = oEstructura.Fila.ToString();
                    }

                    chkIncluir.Checked = oEstructura.Incluir;
                    txtColumna.Text = oEstructura.Columna.ToString();

                    oEstructura.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                }

                base.Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Grabar()
        {
            try
            {
                Int32 Fila = 0;
                Int32 Columna = 0;
                Int32.TryParse(txtFila.Text, out Fila);
                Int32.TryParse(txtColumna.Text, out Columna);

                oEstructura.Tipo = Convert.ToInt32(cboTipo.SelectedValue); //cboTipo.SelectedItem.ToString();
                oEstructura.NombreCampo = cboCampos.SelectedValue.ToString();
                oEstructura.EsLineal = chkLectura.Checked;

                if (chkLectura.Checked)
                {
                    oEstructura.Fila = 0;
                    oEstructura.FilaInicio = Fila;
                }
                else
                {
                    oEstructura.Fila = Fila;
                    oEstructura.FilaInicio = 0;
                }

                oEstructura.Incluir = chkIncluir.Checked;
                oEstructura.Columna = Columna;

                if (oEstructura.Item == 0)
                {
                    if (Global.MensajeConfirmacion("Desea guardar la columna?") == DialogResult.Yes)
                    {
                        oEstructura = AgenteGeneral.Proxy.InsertarEstructuraXLS(oEstructura);
                    }
                }
                else
                {
                    oEstructura = AgenteGeneral.Proxy.ActualizarEstructuraXLS(oEstructura);
                    Global.MensajeComunicacion("Registro Actualizado.");
                }

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmEstructuraXLS_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
        }

        private void cboTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboTipo.SelectedValue) != 0)
                {
                    List<EstructuraXLSE> oLista1 = null;
                    List<EstructuraXLSE> oLista2 = null;
                    Int32 Indice = -1;

                    oLista2 = oLista1 = AgenteGeneral.Proxy.NombreColumnasTabla(((ParTabla)cboTipo.SelectedItem).ValorCadena);
                    //if (cboTipo.SelectedIndex == 0)
                    //{
                    //    oLista2 = oLista1 = AgenteGeneral.Proxy.NombreColumnasTabla("ArticuloServXLS");
                    //}
                    //else
                    //{
                    //    oLista2 = oLista1 = AgenteGeneral.Proxy.NombreColumnasTabla("VoucherXLS");
                    //}

                    if (oListaEstructuras != null && oListaEstructuras.Count > 0)
                    {
                        foreach (EstructuraXLSE item1 in oListaEstructuras)
                        {
                            foreach (EstructuraXLSE item2 in oLista2)
                            {
                                Indice++;

                                if (item1.NombreCampo == item2.NombreCampo)
                                {
                                    oLista1.RemoveAt(Indice);
                                    Indice = -1;
                                    break;
                                }
                            }
                        }
                    }

                    cboCampos.DataSource = oLista1;
                    cboCampos.DisplayMember = "Nombrecampo";
                    cboCampos.ValueMember = "Nombrecampo";

                    oLista1 = null;
                    oLista2 = null;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboCampos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void chkLectura_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLectura.Checked)
            {
                lblTitulo.Text = "Inicio Lectura";
            }
            else
            {
                lblTitulo.Text = "Fila Excel";
            }

            txtFila.Focus();
        }

        private void chkIncluir_CheckedChanged(object sender, EventArgs e)
        {
            txtColumna.Focus();
        } 

        #endregion

    }
}
