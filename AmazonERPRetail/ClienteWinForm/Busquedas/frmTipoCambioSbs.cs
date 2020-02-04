using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using ConsultasOnline;

namespace ClienteWinForm.Busquedas
{
    public partial class frmTipoCambioSbs : FrmMantenimientoBase
    {

        public frmTipoCambioSbs()
        {
            Global.AjustarResolucion(this);
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            pFormatoGrid(dgvTica);
        }

        #region Variables
        
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        SbsTica oSbs = new SbsTica();
        List<SbsTica> oListaTica = null; 

        #endregion

        #region Procedimientos de Usuario

        void QuitarLineas(DataGridViewCellPaintingEventArgs e, Int32 numIni, Int32 numFin, TextFormatFlags flag)
        {
            if (e.RowIndex >= numIni && (e.ColumnIndex == numFin))
            {
                Color clrFondoCelda;
                Color clrTextoCelda;

                clrFondoCelda = Color.White;
                clrTextoCelda = Color.FromArgb(108, 146, 186);

                // rellenar el rectángulo de la celda con el color correspondiente
                if (e.ColumnIndex == 0)
                {
                    Color FondoTmp = Color.FromArgb(239, 239, 239);
                    e.Graphics.FillRectangle(new SolidBrush(FondoTmp), e.CellBounds);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(clrFondoCelda), e.CellBounds);
                }

                // dibujar solamente la línea vertical de la celda
                e.Graphics.DrawLine(new Pen(SystemColors.ActiveBorder), new Point(e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y), 
                    new Point(e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height));

                // si la celda tiene valor
                if (e.Value != null)
                {
                    // dibujar el texto
                    TextRenderer.DrawText(e.Graphics,
                        e.FormattedValue.ToString(),
                        e.CellStyle.Font,
                        e.CellBounds,
                        clrTextoCelda,
                        flag);
                }

                e.Handled = true;
            }
        }

        void pFormatoGrid(DataGridView oDgv)
        {
            ////Para que la primera columan no aparesca
            oDgv.RowHeadersVisible = false;

            //Inicializar propiedades básicas DataGridView.
            oDgv.BorderStyle = BorderStyle.None;

            //Establecer el estilo de las filas y columnas del encabezado
            oDgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9.25f, FontStyle.Bold, GraphicsUnit.Point);
            oDgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            oDgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //Alternando colores en las filas
            oDgv.RowsDefaultCellStyle.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point);

            //Valores de propiedad, conjunto adecuado para la visualización.
            oDgv.AllowUserToAddRows = false;
            oDgv.AllowUserToDeleteRows = false;
            oDgv.AllowUserToOrderColumns = false;
            oDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            oDgv.MultiSelect = false;

            oDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            oDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            //Estableciendo el el alto de los titulos
            oDgv.ColumnHeadersHeight = 20;
            oDgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //Formato para las filas
            DataGridViewRow lineas = oDgv.RowTemplate; //Establece la plantilla para todas las filas.
            lineas.Height = 16;
            lineas.MinimumHeight = 10;
            lineas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            oDgv.Refresh();
        }

        void OtroFormato()
        {
            dgvTica.Columns[0].Width = 160;
            dgvTica.Columns[1].Width = 160;
            dgvTica.Columns[2].Width = 160;

            dgvTica.Columns[0].HeaderText = "MONEDA";
            dgvTica.Columns[1].HeaderText = "COMPRA(S/.)";
            dgvTica.Columns[2].HeaderText = "VENTA(S/.)";
        }

        TipoCambioE DevolverTipoCambio(String idMoneda_, DateTime fecCambio_, Decimal valCompra_, Decimal valVenta_, Decimal valVentaCaja_, Decimal valCompraCaja_)
        {
            return new TipoCambioE()
            {
                idMoneda = idMoneda_,
                //fecCambio = fecCambio_,
                valCompra = valCompra_,
                valVenta = valVenta_,
                valVentaCaja = valVentaCaja_,
                valCompraCaja = valCompraCaja_,
                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
            };
        }

        #endregion

        #region Eventos

        private void TipoCambioSbs_Load(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            lblGlosa.Text = "LOS TIPOS DE CAMBIO SON PARA EL DIA " + dtpFecha.Value.Date.AddDays(1).ToString("d");
        }

        private void btConsultar_Click(object sender, EventArgs e)
        {
            oSbs.Fecha = dtpFecha.Value.ToString("dd/MM/yyyy");
            oListaTica = oSbs.ObtenerTicaSbs();
            dgvTica.DataSource = oListaTica;

            if (oListaTica.Count > Variables.Cero)
            {
                lblFecha.Text = "Tipo de Cambio al " + dtpFecha.Value.ToString("d");
                lblGlosa.Text = "LOS TIPOS DE CAMBIO SON PARA EL DIA " + dtpFecha.Value.Date.AddDays(1).ToString("d");
                btGuardar.Enabled = true;
            }
            else
            {
                btGuardar.Enabled = false;
                lblFecha.Text = "No existe Tipo de Cambio para la fecha indicada.";
            }

            OtroFormato();
        }

        private void dgvTica_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            String column = dgvTica.Columns[e.ColumnIndex].Name;

            if (e.RowIndex == Variables.Cero)
            {
                if (column == "Moneda" || column == "Compra" || column == "Venta")
                {
                    dgvTica.Columns[e.ColumnIndex].HeaderCell.Style.BackColor = Color.FromArgb(243, 246, 250); //Celeste
                    dgvTica.Columns[e.ColumnIndex].HeaderCell.Style.ForeColor = Color.FromArgb(108, 146, 180); //Celeste
                }
            }
            else
            {
                if (column == "Compra" || column == "Venta")
                {
                    e.CellStyle.Format = "N3";
                }
            }
        }

        private void dgvTica_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            QuitarLineas(e, 0, 0, TextFormatFlags.Left);
            QuitarLineas(e, 0, 1, TextFormatFlags.Right);
            QuitarLineas(e, 0, 2, TextFormatFlags.Right);
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaTica != null)
                {
                    if (oListaTica.Count > Variables.Cero)
                    {
                        List<TipoCambioE> oListaPorEnviar = new List<TipoCambioE>();
                        DateTime FechaActual = dtpFecha.Value.Date;
                        TipoCambioE oTica = null;
                        Boolean Posicion;

                        foreach (var item in oListaTica)
                        {
                            #region Dólares

                            Posicion = (item.Moneda.ToUpper().IndexOf("N.A.")) > 0;

                            if (Posicion)
                            {
                                oTica = DevolverTipoCambio(Variables.Dolares, FechaActual.Date.AddDays(1), Convert.ToDecimal(item.Compra), Convert.ToDecimal(item.Venta),
                                    Variables.ValorCeroDecimal, Variables.ValorCeroDecimal);

                                if (oTica != null)
                                {
                                    oListaPorEnviar.Add(oTica);

                                    if (FechaActual.AddDays(1).ToString("dd/MM/yyyy") == VariablesLocales.FechaHoy.ToString("dd/MM/yyyy"))
                                    {
                                        VariablesLocales.TipoCambioDelDia = oTica;
                                    }
                                }
                            }

                            #endregion

                            #region Euros

                            Posicion = (item.Moneda.ToUpper().IndexOf("EURO")) > -1;

                            if (Posicion)
                            {
                                oTica = DevolverTipoCambio(Variables.Euros, FechaActual.Date.AddDays(1), Convert.ToDecimal(item.Compra), Convert.ToDecimal(item.Venta),
                                    Variables.ValorCeroDecimal, Variables.ValorCeroDecimal);

                                if (oTica != null)
                                {
                                    oListaPorEnviar.Add(oTica);
                                }
                            }

                            #endregion

                            #region Franco Suizo

                            Posicion = (item.Moneda.ToUpper().IndexOf("FRANCO SUIZO")) > -1;

                            if (Posicion)
                            {
                                oTica = DevolverTipoCambio(Variables.MonedaFrancoSuizo, FechaActual.Date.AddDays(1), Convert.ToDecimal(item.Compra), Convert.ToDecimal(item.Venta),
                                    Variables.ValorCeroDecimal, Variables.ValorCeroDecimal);

                                if (oTica != null)
                                {
                                    oListaPorEnviar.Add(oTica);
                                }
                            }

                            #endregion

                            #region Libra Esterlina

                            Posicion = (item.Moneda.ToUpper().IndexOf("LIBRA ESTERLINA")) > -1;

                            if (Posicion)
                            {
                                oTica = DevolverTipoCambio(Variables.MonedaLibraEsterlina, FechaActual.Date.AddDays(1), Convert.ToDecimal(item.Compra), Convert.ToDecimal(item.Venta),
                                    Variables.ValorCeroDecimal, Variables.ValorCeroDecimal);

                                if (oTica != null)
                                {
                                    oListaPorEnviar.Add(oTica);
                                }
                            }

                            #endregion
                        }

                        if (oListaPorEnviar.Count > Variables.Cero)
                        {
                            AgenteGeneral.Proxy.GrabarTipoCambioMasivo(oListaPorEnviar);
                            Global.MensajeComunicacion("El tipo de Cambio se guardo correctamente.");
                            btGuardar.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            btGuardar.Enabled = false;
        }

        #endregion

    }
}
