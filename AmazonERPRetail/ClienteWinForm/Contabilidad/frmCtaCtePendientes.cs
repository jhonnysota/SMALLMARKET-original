using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmCtaCtePendientes : frmResponseBase
    {

        public frmCtaCtePendientes(List<conCtaCteItemE> oListaTmp, String verPlanCuentas_, String Cuenta_, Int32 Auxiliar_, String RazonSocial_, DateTime fecOperacion_)
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            lblTituloPrincipal.Text = "Documentos Pendientes de " + RazonSocial_;
            verPlanCuentas = verPlanCuentas_;
            Cuenta = Cuenta_;
            Auxiliar = Auxiliar_;
            RazonSocial = RazonSocial_;
            fecOperacion = fecOperacion_;
            pFormatoGrid(dgvDetalleCtaCte);
            ListaCtaCte = oListaTmp;
            Buscar();

            lblPendiente.Text = "Pendientes al " + fecOperacion.Date.ToString("d");

            PlanCuentasE oCuenta = AgenteContabilidad.Proxy.ObtenerPlanCuentasPorCodigo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, verPlanCuentas_, Cuenta_);

            if (oCuenta != null)
            {
                if (oCuenta.indNaturalezaCta == Variables.Debe)
                {
                    lblNaturaleza.Text = "Naturaleza de la Cta " + Cuenta_ + " DEUDORA.";
                }
                else
                {
                    lblNaturaleza.Text = "Naturaleza de la Cta " + Cuenta_ + " ACREEDORA.";
                }
            } 

            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                dgvDetalleCtaCte.Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            }
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<conCtaCteItemE> ListaCtaCte = null;
        String verPlanCuentas; 
        String Cuenta;
        String RazonSocial;
        Int32 Auxiliar;
        DateTime fecOperacion;
        Boolean Ordenar = false;
        Int32 TotalChecks = Variables.Cero;
        Int32 TotalCheckeados = Variables.Cero;
        CheckBox CheckBoxCab = null;
        bool ClickCab = false;

        public List<conCtaCteItemE> oListaItemCtacte = null;

        #endregion

        #region Eventos y procedimientos checkBox

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            ClickCab = true;

            foreach (DataGridViewRow Row in dgvDetalleCtaCte.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["dgvChk"]).Value = HCheckBox.Checked;
            }

            dgvDetalleCtaCte.RefreshEdit();
            TotalCheckeados = HCheckBox.Checked ? TotalChecks : 0;
            ClickCab = false;
        }

        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender);
        }

        private void AñadirCheckBox()
        {
            CheckBoxCab = new CheckBox();
            CheckBoxCab.Size = new Size(15, 15);

            // Añadiendo el CheckBox dentro de la cabecera del datagridview
            dgvDetalleCtaCte.Controls.Add(CheckBoxCab);
        }

        private void CambiarUbicacionCheckBox(Int32 ColumnIndex, Int32 RowIndex)
        {
            //Obtener limites de la celda de la cabecera que va a contener el checkbox
            Rectangle oRectangle = dgvDetalleCtaCte.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - CheckBoxCab.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - CheckBoxCab.Height) / 2 + 1;

            //Cambiar la ubicacion del checkbox para que se quede en la cabecera
            CheckBoxCab.Location = oPoint;
        }

        private void FilaCheckBoxClick(DataGridViewCheckBoxCell RCheckBox)
        {
            if (RCheckBox != null)
            {
                //Modificando el contador de los check
                if ((Boolean)RCheckBox.Value && TotalCheckeados < TotalChecks)
                {
                    TotalCheckeados++;
                }
                else if (TotalCheckeados > 0)
                {
                    TotalCheckeados--;
                }

                //Cambiar estado de la casilla de la cabecera si es que se llenan todas las filas o viceversa.
                if (TotalCheckeados < TotalChecks)
                {
                    CheckBoxCab.Checked = false;
                }
                else if (TotalCheckeados == TotalChecks)
                {
                    CheckBoxCab.Checked = true;
                }
            }
        }

        #endregion

        #region Procedimientos de Usuario
        
        void OtroFormato()
        {
            //Ancho Columnas
            dgvDetalleCtaCte.Columns[0].Width = 75;
            dgvDetalleCtaCte.Columns[1].Width = 30; //Tipo de Documento
            dgvDetalleCtaCte.Columns[2].Width = 50; //Serie
            dgvDetalleCtaCte.Columns[3].Width = 80; //Numero
            dgvDetalleCtaCte.Columns[4].Width = 75; //Fecha de documento
            dgvDetalleCtaCte.Columns[5].Width = 32; //Moneda
            dgvDetalleCtaCte.Columns[6].Width = 90; //Saldo Soles
            dgvDetalleCtaCte.Columns[7].Width = 90; //Saldo Dólares
            dgvDetalleCtaCte.Columns[8].Width = 30;//Check
            dgvDetalleCtaCte.Columns[9].Width = 50;// Centro de Costos
            dgvDetalleCtaCte.Columns[10].Width = 30;// Tipo de Partida
            dgvDetalleCtaCte.Columns[11].Width = 70;// Partida
        }

        void SumarTotales()
        {
            if (ListaCtaCte != null && ListaCtaCte.Count > Variables.Cero)
            {
                Decimal SaldoSoles = Decimal.Round((from x in ListaCtaCte select x.SaldoSoles).Sum(), 2);
                Decimal SaldoDolares = Decimal.Round((from x in ListaCtaCte select x.SaldoDolares).Sum(), 2);

                txtSaldoSoles.Text = SaldoSoles.ToString("N2");
                txtSaldoDolares.Text = SaldoDolares.ToString("N2");
            }
        }

        void pFormatoGrid(DataGridView oDgv, int AltoCabecera = 25, Boolean MostrarColor = true)
        {
            ////Para que la primera columan no aparesca
            oDgv.RowHeadersVisible = false;
            oDgv.RowHeadersWidth = 20;

            //Inicializar propiedades básicas DataGridView.
            oDgv.BackgroundColor = Color.LightSteelBlue;
            oDgv.BorderStyle = BorderStyle.None;

            //Establecer el estilo de las filas y columnas del encabezado
            //oDgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point);
            oDgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8.25f * 96f / CreateGraphics().DpiX, FontStyle.Bold, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            oDgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;
            oDgv.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            oDgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            oDgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //Alternando colores en las filas
            oDgv.RowsDefaultCellStyle.BackColor = Color.White;
            if (MostrarColor)
            {
                oDgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            }

            //oDgv.RowsDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            oDgv.RowsDefaultCellStyle.Font = new Font("Tahoma", 8f * 96f / CreateGraphics().DpiX, FontStyle.Regular, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            //Valores de propiedad, conjunto adecuado para la visualización.
            oDgv.AllowUserToAddRows = false;
            oDgv.AllowUserToDeleteRows = false;
            oDgv.AllowUserToOrderColumns = false;
            oDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            oDgv.MultiSelect = false;

            oDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            oDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            ////Estableciendo el el alto de los titulos
            oDgv.ColumnHeadersHeight = AltoCabecera;
            
            oDgv.Refresh();
        }

        #endregion

        #region Procedimientos Heredados
        
        public override void Buscar()
        {
            try
            {
                //ListaCtaCte = AgenteContabilidad.Proxy.ListarConCtaCtePendientes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, verPlanCuentas, Cuenta, Auxiliar, fecOperacion.Date);

                bsBase.DataSource = ListaCtaCte;
                TotalChecks = dgvDetalleCtaCte.RowCount;
                TotalCheckeados = 0;
                OtroFormato();

                //if (ListaCtaCte.Count == Variables.ValorCero)
                //{
                //    Global.MensajeComunicacion(String.Format("No hay documentos pendientes de {0}", RazonSocial));
                //    pnlBusqueda.Enabled = false;
                //    pnlBase.Enabled = false;
                //    btAceptar.Enabled = false;
                //}
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Aceptar()
        {
            try
            {
                Int32 Contador = Variables.Cero;
                oListaItemCtacte = new List<conCtaCteItemE>();

                foreach (conCtaCteItemE item in ListaCtaCte)
                {
                    if (item.Check)
                    {
                        oListaItemCtacte.Add(item);
                        Contador++;
                    }
                }

                if (Contador == Variables.Cero)
                {
                    Global.MensajeFault("No hay ninguna fila con check, debe escoger al menos uno. De lo contrario presione Cancelar.");
                }
                else
                {
                    base.Aceptar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos
        
        private void frmCtaCtePendientes_Load(object sender, EventArgs e)
        {
            ClickCab = false;
            AñadirCheckBox();
            CheckBoxCab.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            CheckBoxCab.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
            SumarTotales();
            dgvDetalleCtaCte.Focus();
            dgvDetalleCtaCte.CurrentRow.Cells["dgvChk"].Selected = true;
        }

        private void dgvDetalleCtaCte_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 8)
            {
                CambiarUbicacionCheckBox(e.ColumnIndex, e.RowIndex);
            }
        }

        private void dgvDetalleCtaCte_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleCtaCte.Rows.Count != 0)
            {
                if (!ClickCab)
                {
                    FilaCheckBoxClick((DataGridViewCheckBoxCell)dgvDetalleCtaCte[e.ColumnIndex, e.RowIndex]);
                }
            }
        }

        private void dgvDetalleCtaCte_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDetalleCtaCte.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvDetalleCtaCte.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        } 

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            bsBase.DataSource = (from x in ListaCtaCte
                                 where (x.serDocumento + "-" + x.numDocumento).Contains(txtDocumento.Text)
                                 select x).ToList();
        }

        private void dgvDetalleCtaCte_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (ListaCtaCte != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // POR CODCUENTA
                    if (e.ColumnIndex == dgvDetalleCtaCte.Columns["codCuenta"].Index)
                    {
                        if (Ordenar)
                        {
                            ListaCtaCte = (from x in ListaCtaCte orderby x.codCuenta ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListaCtaCte = (from x in ListaCtaCte orderby x.codCuenta descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR idDocumento
                    if (e.ColumnIndex == dgvDetalleCtaCte.Columns["idDocumentoDataGridViewTextBoxColumn"].Index)
                    {
                        if (Ordenar)
                        {
                            ListaCtaCte = (from x in ListaCtaCte orderby x.idDocumento ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListaCtaCte = (from x in ListaCtaCte orderby x.idDocumento descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR SERIEDocumento
                    if (e.ColumnIndex == dgvDetalleCtaCte.Columns["serDocumentoDataGridViewTextBoxColumn"].Index)
                    {
                        if (Ordenar)
                        {
                            ListaCtaCte = (from x in ListaCtaCte orderby x.serDocumento ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListaCtaCte = (from x in ListaCtaCte orderby x.serDocumento descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR numDocumento
                    if (e.ColumnIndex == dgvDetalleCtaCte.Columns["numDocumentoDataGridViewTextBoxColumn"].Index)
                    {
                        if (Ordenar)
                        {
                            ListaCtaCte = (from x in ListaCtaCte orderby x.numDocumento ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListaCtaCte = (from x in ListaCtaCte orderby x.numDocumento descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR fecDocumento
                    if (e.ColumnIndex == dgvDetalleCtaCte.Columns["fecDocumentoDataGridViewTextBoxColumn"].Index)
                    {
                        if (Ordenar)
                        {
                            ListaCtaCte = (from x in ListaCtaCte orderby x.fecDocumento ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListaCtaCte = (from x in ListaCtaCte orderby x.fecDocumento descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // desMoneda
                    if (e.ColumnIndex == dgvDetalleCtaCte.Columns["idMonedaDataGridViewTextBoxColumn"].Index)
                    {
                        if (Ordenar)
                        {
                            ListaCtaCte = (from x in ListaCtaCte orderby x.desMoneda ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListaCtaCte = (from x in ListaCtaCte orderby x.desMoneda descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // saldo soles
                    if (e.ColumnIndex == dgvDetalleCtaCte.Columns["saldoSolesDataGridViewTextBoxColumn"].Index)
                    {
                        if (Ordenar)
                        {
                            ListaCtaCte = (from x in ListaCtaCte orderby x.SaldoSoles ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListaCtaCte = (from x in ListaCtaCte orderby x.SaldoSoles descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    //saldo dolares
                    if (e.ColumnIndex == dgvDetalleCtaCte.Columns["saldoDolaresDataGridViewTextBoxColumn"].Index)
                    {
                        if (Ordenar)
                        {
                            ListaCtaCte = (from x in ListaCtaCte orderby x.SaldoDolares ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListaCtaCte = (from x in ListaCtaCte orderby x.SaldoDolares descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                }

                bsBase.DataSource = ListaCtaCte;
            }
        }

        private void txtCuenta_TextChanged(object sender, EventArgs e)
        {
            bsBase.DataSource = (from x in ListaCtaCte
                                 where (x.codCuenta).Contains(txtCuenta.Text.Trim())
                                 select x).ToList();
        }

        #endregion

    }
}
