using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;
using Infraestructura.Winform;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteConCtaCTePorParametros : FrmMantenimientoBase
    {
        public frmReporteConCtaCTePorParametros()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            DataGridViewHelper.AplicarTemaGrid(oDataGridView);
            DataGridViewHelper.AplicarTemaGrid(oDataGridViewDetalle);

            oDataGridView.ColumnAdded += new DataGridViewColumnEventHandler(OrdenarDataGridView);
            oDataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(FormatoCelda);
            //Creando las columnas para el llenado de los datos
            //CrearColumnas();
            CrearColumnasDetalle();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<conCtaCteE> oListaCtaCte = null;
        DataGridView oDataGridView = new DataGridView { Dock = DockStyle.Fill };
        DataGridView oDataGridViewDetalle = new DataGridView();
        Bitmap bitExpandir = new Bitmap(ClienteWinForm.Properties.Resources.Add_Reg);
        Bitmap bitContraer = new Bitmap(ClienteWinForm.Properties.Resources.Menos);
        Bitmap bitBlanco = new Bitmap(ClienteWinForm.Properties.Resources.Blanco);
        Bitmap bitAmarillo = new Bitmap(ClienteWinForm.Properties.Resources.amarillo_naranja);
        Bitmap bitVerde = new Bitmap(ClienteWinForm.Properties.Resources.Verde);
        Bitmap bitAcero = new Bitmap(ClienteWinForm.Properties.Resources.acero);
        Int32 idPersona = Variables.Cero;
        String Estado = "expandir";
        Int32 Indice = Variables.Cero;

        #endregion

        #region Procedimientos de Usuario

        void CrearColumnasDetalle()
        {
            //Limpiando el datagridview
            oDataGridViewDetalle.Rows.Clear();
            oDataGridViewDetalle.Columns.Clear();
            oDataGridViewDetalle.DataSource = null;
            
            //Creando las columnas
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.Numeros, "idPersona", "Auxiliar", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable, true);
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.Texto, "RazonSocial", "Razón Social", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable, true);
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.Texto, "codCuenta", "Cuenta", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable, true);
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.Texto, "desCuenta", "Des. Cuenta", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable, true);
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.NumerosDecimales, "TipoCambio", "T.C.", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.Texto, "indDebeHaber", "D/H", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.NumerosDecimales, "impSoles", "Importe Soles", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.NumerosDecimales, "SaldoSoles", "Saldo Soles", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.Texto, "indDebeHaber", "D/H", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.NumerosDecimales, "impDolares", "Importe Dólares", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.NumerosDecimales, "SaldoDolares", "Saldo Dólares", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.Texto, "indDebeHaber", "D/H", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.Texto, "idDocumentoMov", "T.D.", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.Texto, "SerieMov", "Serie", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.Texto, "NumeroMov", "Número", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.Fecha, "FechaMovimiento", "Fec.Doc.", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.Fecha, "fecVencimiento", "Fec.Venc.", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.Numeros, "idLocal", "Suc.", "Surcursal", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.Texto, "idComprobante", "Diario", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.Texto, "numFile", "File", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridViewDetalle, DataGridViewHelper.TipoDatosGrid.Texto, "numVoucher", "Voucher", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
        }

        void CrearColumnas()
        {
            //Limpiando el datagridview
            oDataGridView.Rows.Clear();
            oDataGridView.Columns.Clear();
            oDataGridView.DataSource = null;

            //Creando las columnas
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.ImageColumn, "", "imgColumn", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewColumnSortMode.NotSortable, true, bitExpandir);
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.Texto, "codCuenta", "Cuenta", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable, true);
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.Texto, "desCuenta", "Des. Cuenta", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable, true);
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.Numeros, "idPersona", "Auxiliar", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable, true);
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.Texto, "RazonSocial", "Razón Social", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable, true);
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.Texto, "idDocumento", "T.D.", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.Texto, "serDocumento", "Serie", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.Texto, "numDocumento", "Número", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.Fecha, "fecDocumento", "Fec.Doc.", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.Fecha, "fecVencimiento", "Fec.Venc.", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.NumerosDecimales, "CargoSoles", "Cargo Soles", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.NumerosDecimales, "SaldoSoles", "Saldo Soles", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.NumerosDecimales, "CargoDolares", "Cargo Dólares", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.NumerosDecimales, "SaldoDolares", "Saldo Dólares", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.Numeros, "idLocal", "Suc.", "Surcursal", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.Texto, "idComprobante", "Diario", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.Texto, "numFile", "File", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.Texto, "numVoucher", "Voucher", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.Fecha, "fecOperacion", "Fec.Ope.", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.Texto, "Glosa", "Glosa", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
            DataGridViewHelper.Columnas(oDataGridView, DataGridViewHelper.TipoDatosGrid.Numeros, "idCtaCTe", "idCtaCTe", "", true, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewColumnSortMode.NotSortable);
        }

        void LlenarDetalle(List<conCtaCteItemE> Items)
        {
            Int32 Fila = 1;
            oDataGridViewDetalle.DataSource = null;
            oDataGridViewDetalle.Rows.Clear();

            foreach (conCtaCteItemE item in Items)
            {
                Fila = oDataGridViewDetalle.Rows.Add();
                oDataGridViewDetalle.Rows[Fila].Cells[0].Value = item.idPersona;
                oDataGridViewDetalle.Rows[Fila].Cells[1].Value = item.RazonSocial;
                oDataGridViewDetalle.Rows[Fila].Cells[2].Value = item.codCuenta;
                oDataGridViewDetalle.Rows[Fila].Cells[3].Value = item.desCuenta;
                oDataGridViewDetalle.Rows[Fila].Cells[4].Value = item.TipoCambio;
                oDataGridViewDetalle.Rows[Fila].Cells[5].Value = item.indDebeHaber;
                oDataGridViewDetalle.Rows[Fila].Cells[6].Value = item.impSoles;
                oDataGridViewDetalle.Rows[Fila].Cells[7].Value = item.SaldoSoles;
                oDataGridViewDetalle.Rows[Fila].Cells[8].Value = item.indDebeHaber;
                oDataGridViewDetalle.Rows[Fila].Cells[9].Value = item.impDolares;
                oDataGridViewDetalle.Rows[Fila].Cells[10].Value = item.SaldoDolares;
                oDataGridViewDetalle.Rows[Fila].Cells[11].Value = item.indDebeHaber;
                oDataGridViewDetalle.Rows[Fila].Cells[12].Value = item.idDocumentoMov;
                oDataGridViewDetalle.Rows[Fila].Cells[13].Value = item.SerieMov;
                oDataGridViewDetalle.Rows[Fila].Cells[14].Value = item.NumeroMov;
                oDataGridViewDetalle.Rows[Fila].Cells[15].Value = item.FechaMovimiento;
                oDataGridViewDetalle.Rows[Fila].Cells[16].Value = item.fecVencimiento;
                oDataGridViewDetalle.Rows[Fila].Cells[17].Value = item.idLocal;
                oDataGridViewDetalle.Rows[Fila].Cells[18].Value = item.idComprobante;
                oDataGridViewDetalle.Rows[Fila].Cells[19].Value = item.numFile;
                oDataGridViewDetalle.Rows[Fila].Cells[20].Value = item.numVoucher;
            }
        }

        #endregion

        #region Eventos de Usuario

        void OrdenarDataGridView(Object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        void FormatoCelda(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((String)oDataGridView.Rows[e.RowIndex].Cells["RazonSocial"].Value.ToString().Trim() == "TOTAL GENERAL >>>>")
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 217, 102);
                }
            }
            else if ((String)oDataGridView.Rows[e.RowIndex].Cells["RazonSocial"].Value.ToString().Trim() == "TOTAL CUENTA >>>>")
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Color.FromArgb(142, 169, 219);
                } 
            }
            else if ((String)oDataGridView.Rows[e.RowIndex].Cells["RazonSocial"].Value.ToString().Trim() == "TOTAL AUXILIAR >>>>")
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Color.FromArgb(169, 208, 142);
                }
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {
                String Cuenta = String.Empty;
                String Estado = String.Empty;
                
                if (!chkCuentas.Checked)
                {
                    Cuenta = txtCuenta.Text;
                }

                #region Estado
                
                if (cboEstado.SelectedIndex == Variables.Cero)
                {
                    Estado = "A";
                }
                else if (cboEstado.SelectedIndex == 1)
                {
                    Estado = "P";
                }
                else
                {
                    Estado = "C";
                } 

                #endregion

                oListaCtaCte = AgenteContabilidad.Proxy.ResumenConCtaCtePorParametros(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Cuenta, idPersona, dtpFecIni.Value.Date, Estado);

                if (oListaCtaCte.Count > Variables.Cero)
                {
                    #region Variables

                    Int32 numFila;
                    Int32 Auxiliar = Variables.Cero;
                    String codCuenta = String.Empty;
                    Decimal totAuxiliarSoles = Variables.Cero;
                    Decimal totAuxiliarDolares = Variables.Cero;
                    Decimal totCuentaSoles = Variables.ValorCeroDecimal;
                    Decimal totCuentaDolares = Variables.ValorCeroDecimal;
                    Decimal totGeneralSoles = Variables.ValorCeroDecimal;
                    Decimal totGeneralDolares = Variables.ValorCeroDecimal;
                    Int32 Index_ = Variables.Cero;

                    #endregion

                    //Creando las columnas para el grid master
                    CrearColumnas();

                    //Obteniendo los primeros datos para la comparación
                    Auxiliar = oListaCtaCte[0].idPersona;
                    codCuenta = oListaCtaCte[0].codCuenta;

                    //Recorriendo la lista para volcarlo al datagridview
                    foreach (conCtaCteE item in oListaCtaCte)
                    {
                        item.FilaIndex = Index_;
                        numFila = oDataGridView.Rows.Add();

                        if (codCuenta == item.codCuenta)
                        {
                            #region Cuenta Igual

                            if (Auxiliar == item.idPersona)
                            {
                                #region Si el Auxiliar es igual

                                oDataGridView.Rows[numFila].Cells[1].Value = item.codCuenta;
                                oDataGridView.Rows[numFila].Cells[2].Value = item.desCuenta;
                                oDataGridView.Rows[numFila].Cells[3].Value = item.idPersona;
                                oDataGridView.Rows[numFila].Cells[4].Value = item.RazonSocial;
                                oDataGridView.Rows[numFila].Cells[5].Value = item.idDocumento;
                                oDataGridView.Rows[numFila].Cells[6].Value = item.serDocumento;
                                oDataGridView.Rows[numFila].Cells[7].Value = item.numDocumento;
                                oDataGridView.Rows[numFila].Cells[8].Value = item.fecDocumento;
                                oDataGridView.Rows[numFila].Cells[9].Value = item.fecVencimiento;
                                oDataGridView.Rows[numFila].Cells[10].Value = item.CargoSoles;
                                oDataGridView.Rows[numFila].Cells[11].Value = item.SaldoSoles;
                                oDataGridView.Rows[numFila].Cells[12].Value = item.CargoDolares;
                                oDataGridView.Rows[numFila].Cells[13].Value = item.SaldoDolares;
                                oDataGridView.Rows[numFila].Cells[14].Value = item.idLocal;
                                oDataGridView.Rows[numFila].Cells[15].Value = item.idComprobante;
                                oDataGridView.Rows[numFila].Cells[16].Value = item.numFile;
                                oDataGridView.Rows[numFila].Cells[17].Value = item.numVoucher;
                                oDataGridView.Rows[numFila].Cells[18].Value = item.fecOperacion;
                                oDataGridView.Rows[numFila].Cells[19].Value = item.Glosa;
                                oDataGridView.Rows[numFila].Cells[20].Value = item.idCtaCte;

                                #endregion

                                totAuxiliarSoles += item.CargoSoles;//Convert.ToDecimal(oDataGridView.Rows[numFila].Cells[10].Value);
                                totAuxiliarDolares += item.CargoDolares; //Convert.ToDecimal(oDataGridView.Rows[numFila].Cells[12].Value);
                            }
                            else
                            {
                                #region Si el auxiliar es diferente

                                oDataGridView.Rows[numFila].Cells[0].Value = bitVerde;
                                oDataGridView.Rows[numFila].Cells[1].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[2].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[3].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[4].Style.Font = new Font("Arial", 8.25f, FontStyle.Bold);
                                oDataGridView.Rows[numFila].Cells[4].Value = "                                                            TOTAL AUXILIAR >>>> ";
                                oDataGridView.Rows[numFila].Cells[5].Value = String.Empty;                                
                                oDataGridView.Rows[numFila].Cells[6].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[7].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[8].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[9].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[10].Style.Font = new Font("Arial", 8.25f, FontStyle.Bold);
                                oDataGridView.Rows[numFila].Cells[10].Value = totAuxiliarSoles;
                                oDataGridView.Rows[numFila].Cells[11].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[12].Style.Font = new Font("Arial", 8.25f, FontStyle.Bold);
                                oDataGridView.Rows[numFila].Cells[12].Value = totAuxiliarDolares;
                                oDataGridView.Rows[numFila].Cells[13].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[14].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[15].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[16].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[17].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[18].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[19].Value = String.Empty;
                                //oDataGridView.Rows[numFila].Cells[20].Value = item.idCtaCte;
                                #endregion

                                //Limpiando las variables para la nueva entrada en auxiliares
                                totAuxiliarSoles = Variables.ValorCeroDecimal;
                                totAuxiliarDolares = Variables.ValorCeroDecimal;

                                #region Agregando el nuevo auxiliar

                                //Agregando una nueva fila
                                numFila = oDataGridView.Rows.Add();
                                oDataGridView.Rows[numFila].Cells[1].Value = item.codCuenta;
                                oDataGridView.Rows[numFila].Cells[2].Value = item.desCuenta;
                                oDataGridView.Rows[numFila].Cells[3].Value = item.idPersona;
                                oDataGridView.Rows[numFila].Cells[4].Value = item.RazonSocial;
                                oDataGridView.Rows[numFila].Cells[5].Value = item.idDocumento;
                                oDataGridView.Rows[numFila].Cells[6].Value = item.serDocumento;
                                oDataGridView.Rows[numFila].Cells[7].Value = item.numDocumento;
                                oDataGridView.Rows[numFila].Cells[8].Value = item.fecDocumento;
                                oDataGridView.Rows[numFila].Cells[9].Value = item.fecVencimiento;
                                oDataGridView.Rows[numFila].Cells[10].Value = item.CargoSoles;
                                oDataGridView.Rows[numFila].Cells[11].Value = item.SaldoSoles;
                                oDataGridView.Rows[numFila].Cells[12].Value = item.CargoDolares;
                                oDataGridView.Rows[numFila].Cells[13].Value = item.SaldoDolares;
                                oDataGridView.Rows[numFila].Cells[14].Value = item.idLocal;
                                oDataGridView.Rows[numFila].Cells[15].Value = item.idComprobante;
                                oDataGridView.Rows[numFila].Cells[16].Value = item.numFile;
                                oDataGridView.Rows[numFila].Cells[17].Value = item.numVoucher;
                                oDataGridView.Rows[numFila].Cells[18].Value = item.fecOperacion;
                                oDataGridView.Rows[numFila].Cells[19].Value = item.Glosa;
                                oDataGridView.Rows[numFila].Cells[20].Value = item.idCtaCte;

                                #endregion

                                //Obteniendo el ultimo codigo de Auxiliar
                                Auxiliar = item.idPersona;
                                //Sumando los totales
                                totAuxiliarSoles += item.CargoSoles;
                                totAuxiliarDolares += item.CargoDolares;
                            }

                            totCuentaSoles += item.CargoSoles;
                            totCuentaDolares += item.CargoDolares; 

                            #endregion
                        }
                        else
                        {
                            #region Cuenta Diferente

                            if (Auxiliar == item.idPersona)
                            {
                                #region Si el Auxiliar es igual

                                oDataGridView.Rows[numFila].Cells[1].Value = item.codCuenta;
                                oDataGridView.Rows[numFila].Cells[2].Value = item.desCuenta;
                                oDataGridView.Rows[numFila].Cells[3].Value = item.idPersona;
                                oDataGridView.Rows[numFila].Cells[4].Value = item.RazonSocial;
                                oDataGridView.Rows[numFila].Cells[5].Value = item.idDocumento;
                                oDataGridView.Rows[numFila].Cells[6].Value = item.serDocumento;
                                oDataGridView.Rows[numFila].Cells[7].Value = item.numDocumento;
                                oDataGridView.Rows[numFila].Cells[8].Value = item.fecDocumento;
                                oDataGridView.Rows[numFila].Cells[9].Value = item.fecVencimiento;
                                oDataGridView.Rows[numFila].Cells[10].Value = item.CargoSoles;
                                oDataGridView.Rows[numFila].Cells[11].Value = item.SaldoSoles;
                                oDataGridView.Rows[numFila].Cells[12].Value = item.CargoDolares;
                                oDataGridView.Rows[numFila].Cells[13].Value = item.SaldoDolares;
                                oDataGridView.Rows[numFila].Cells[14].Value = item.idLocal;
                                oDataGridView.Rows[numFila].Cells[15].Value = item.idComprobante;
                                oDataGridView.Rows[numFila].Cells[16].Value = item.numFile;
                                oDataGridView.Rows[numFila].Cells[17].Value = item.numVoucher;
                                oDataGridView.Rows[numFila].Cells[18].Value = item.fecOperacion;
                                oDataGridView.Rows[numFila].Cells[19].Value = item.Glosa;
                                oDataGridView.Rows[numFila].Cells[20].Value = item.idCtaCte;

                                #endregion

                                totAuxiliarSoles += item.CargoSoles; //Convert.ToDecimal(oDataGridView.Rows[numFila].Cells[16].Value);
                                totAuxiliarDolares += item.CargoDolares; //Convert.ToDecimal(oDataGridView.Rows[numFila].Cells[18].Value);
                            }
                            else
                            {
                                #region Si el auxiliar es diferente

                                oDataGridView.Rows[numFila].Cells[0].Value = bitVerde;
                                oDataGridView.Rows[numFila].Cells[1].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[2].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[3].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[4].Style.Font = new Font("Arial", 8.25f, FontStyle.Bold);
                                oDataGridView.Rows[numFila].Cells[4].Value = "                                                            TOTAL AUXILIAR >>>> ";
                                oDataGridView.Rows[numFila].Cells[5].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[6].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[7].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[8].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[9].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[10].Style.Font = new Font("Arial", 8.25f, FontStyle.Bold);
                                oDataGridView.Rows[numFila].Cells[10].Value = totAuxiliarSoles;
                                oDataGridView.Rows[numFila].Cells[11].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[12].Style.Font = new Font("Arial", 8.25f, FontStyle.Bold);
                                oDataGridView.Rows[numFila].Cells[12].Value = totAuxiliarDolares;
                                oDataGridView.Rows[numFila].Cells[13].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[14].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[15].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[16].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[17].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[18].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[19].Value = String.Empty;
                                //oDataGridView.Rows[numFila].Cells[20].Value = item.idCtaCte;

                                #endregion

                                //Limpiando las variables para la nueva entrada en auxiliares
                                totAuxiliarSoles = Variables.ValorCeroDecimal;
                                totAuxiliarDolares = Variables.ValorCeroDecimal;

                                #region Total de la cuenta

                                //Agregando una fila
                                numFila = oDataGridView.Rows.Add();
                                oDataGridView.Rows[numFila].Cells[0].Value = bitAcero;
                                oDataGridView.Rows[numFila].Cells[1].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[2].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[3].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[4].Style.Font = new Font("Arial", 8.25f, FontStyle.Bold);
                                oDataGridView.Rows[numFila].Cells[4].Value = "                                                            TOTAL CUENTA >>>> ";
                                oDataGridView.Rows[numFila].Cells[5].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[6].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[7].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[8].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[9].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[10].Style.Font = new Font("Arial", 8.25f, FontStyle.Bold);
                                oDataGridView.Rows[numFila].Cells[10].Value = totCuentaSoles;
                                oDataGridView.Rows[numFila].Cells[11].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[12].Style.Font = new Font("Arial", 8.25f, FontStyle.Bold);
                                oDataGridView.Rows[numFila].Cells[12].Value = totCuentaDolares;
                                oDataGridView.Rows[numFila].Cells[13].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[14].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[15].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[16].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[17].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[18].Value = String.Empty;
                                oDataGridView.Rows[numFila].Cells[19].Value = String.Empty;
                                //oDataGridView.Rows[numFila].Cells[20].Value = item.idCtaCte;

                                //Limpiando las variables para la nueva entrada en cuentas
                                totCuentaSoles = Variables.ValorCeroDecimal;
                                totCuentaDolares = Variables.ValorCeroDecimal;

                                #endregion

                                #region Agregando el nuevo auxiliar

                                //Agregando una fila
                                numFila = oDataGridView.Rows.Add();
                                oDataGridView.Rows[numFila].Cells[1].Value = item.codCuenta;
                                oDataGridView.Rows[numFila].Cells[2].Value = item.desCuenta;
                                oDataGridView.Rows[numFila].Cells[3].Value = item.idPersona;
                                oDataGridView.Rows[numFila].Cells[4].Value = item.RazonSocial;
                                oDataGridView.Rows[numFila].Cells[5].Value = item.idDocumento;
                                oDataGridView.Rows[numFila].Cells[6].Value = item.serDocumento;
                                oDataGridView.Rows[numFila].Cells[7].Value = item.numDocumento;
                                oDataGridView.Rows[numFila].Cells[8].Value = item.fecDocumento;
                                oDataGridView.Rows[numFila].Cells[9].Value = item.fecVencimiento;
                                oDataGridView.Rows[numFila].Cells[10].Value = item.CargoSoles;
                                oDataGridView.Rows[numFila].Cells[11].Value = item.SaldoSoles;
                                oDataGridView.Rows[numFila].Cells[12].Value = item.CargoDolares;
                                oDataGridView.Rows[numFila].Cells[13].Value = item.SaldoDolares;
                                oDataGridView.Rows[numFila].Cells[14].Value = item.idLocal;
                                oDataGridView.Rows[numFila].Cells[15].Value = item.idComprobante;
                                oDataGridView.Rows[numFila].Cells[16].Value = item.numFile;
                                oDataGridView.Rows[numFila].Cells[17].Value = item.numVoucher;
                                oDataGridView.Rows[numFila].Cells[18].Value = item.fecOperacion;
                                oDataGridView.Rows[numFila].Cells[19].Value = item.Glosa;
                                oDataGridView.Rows[numFila].Cells[20].Value = item.idCtaCte;

                                #endregion

                                //Obteniendo el ultimo codigo de Auxiliar
                                Auxiliar = item.idPersona;
                                //Sumando los totales
                                totAuxiliarSoles += item.CargoSoles;
                                totAuxiliarDolares += item.CargoDolares;
                            }

                            codCuenta = item.codCuenta;
                            totCuentaSoles += item.CargoSoles;
                            totCuentaDolares += item.CargoDolares; 

                            #endregion
                        }

                        totGeneralSoles += item.CargoSoles;
                        totGeneralDolares += item.CargoDolares;
                        Index_++;
                    }

                    #region Ultima fila de total auxiliar

                    //Agregando una fila
                    numFila = oDataGridView.Rows.Add();
                    oDataGridView.Rows[numFila].Cells[0].Value = bitVerde;
                    oDataGridView.Rows[numFila].Cells[1].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[2].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[3].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[4].Style.Font = new Font("Arial", 8.25f, FontStyle.Bold);
                    oDataGridView.Rows[numFila].Cells[4].Value = "                                                            TOTAL AUXILIAR >>>> ";
                    oDataGridView.Rows[numFila].Cells[5].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[6].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[7].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[8].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[9].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[10].Style.Font = new Font("Arial", 8.25f, FontStyle.Bold);
                    oDataGridView.Rows[numFila].Cells[10].Value = totAuxiliarSoles;
                    oDataGridView.Rows[numFila].Cells[11].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[12].Style.Font = new Font("Arial", 8.25f, FontStyle.Bold);
                    oDataGridView.Rows[numFila].Cells[12].Value = totAuxiliarDolares;
                    oDataGridView.Rows[numFila].Cells[13].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[14].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[15].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[16].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[17].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[18].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[19].Value = String.Empty;
                    //oDataGridView.Rows[numFila].Cells[20].Value = item.idCtaCte;

                    #endregion

                    #region Ultima fila de total cuenta
                    
                    //Agregando una fila
                    numFila = oDataGridView.Rows.Add();
                    oDataGridView.Rows[numFila].Cells[0].Value = bitAcero;
                    oDataGridView.Rows[numFila].Cells[1].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[2].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[3].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[4].Style.Font = new Font("Arial", 8.25f, FontStyle.Bold);
                    oDataGridView.Rows[numFila].Cells[4].Value = "                                                            TOTAL CUENTA >>>> ";
                    oDataGridView.Rows[numFila].Cells[5].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[6].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[7].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[8].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[9].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[10].Style.Font = new Font("Arial", 8.25f, FontStyle.Bold);
                    oDataGridView.Rows[numFila].Cells[10].Value = totCuentaSoles;
                    oDataGridView.Rows[numFila].Cells[11].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[12].Style.Font = new Font("Arial", 8.25f, FontStyle.Bold);
                    oDataGridView.Rows[numFila].Cells[12].Value = totCuentaDolares;
                    oDataGridView.Rows[numFila].Cells[13].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[14].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[15].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[16].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[17].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[18].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[19].Value = String.Empty;
                    //oDataGridView.Rows[numFila].Cells[20].Value = item.idCtaCte;

                    #endregion

                    #region Ultima Fila TOTAL
                    
                    numFila = oDataGridView.Rows.Add();
                    oDataGridView.Rows[numFila].Cells[0].Value = bitAmarillo;
                    oDataGridView.Rows[numFila].Cells[1].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[2].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[3].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[4].Style.Font = new Font("Arial", 9f, FontStyle.Bold);
                    oDataGridView.Rows[numFila].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    oDataGridView.Rows[numFila].Cells[4].Value = "                                                            TOTAL GENERAL >>>> ";
                    oDataGridView.Rows[numFila].Cells[5].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[6].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[7].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[8].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[9].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[10].Style.Font = new Font("Arial", 9f, FontStyle.Bold);
                    oDataGridView.Rows[numFila].Cells[10].Value = totGeneralSoles;
                    oDataGridView.Rows[numFila].Cells[11].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[12].Style.Font = new Font("Arial", 9f, FontStyle.Bold);
                    oDataGridView.Rows[numFila].Cells[12].Value = totGeneralDolares;
                    oDataGridView.Rows[numFila].Cells[13].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[14].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[15].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[16].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[17].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[18].Value = String.Empty;
                    oDataGridView.Rows[numFila].Cells[19].Value = String.Empty;
                    //oDataGridView.Rows[numFila].Cells[20].Value = item.idCtaCte;

                    #endregion

                    oDataGridView.AutoResizeColumns();
                }
                else
                {
                    Global.MensajeComunicacion("No existen datos...");
                }
            }
            catch (OutOfMemoryException mEx)
            {
                Global.MensajeError(mEx.Message);
            }
            catch (ArgumentException eEx)
            {
                Global.MensajeError(eEx.Message);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos
        
        private void frmReporteConCtaCTePorParametros_Load(object sender, EventArgs e)
        {
            Grid = false;
            cboEstado.SelectedIndex = Variables.Cero;

            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            panel5.Controls.Add(oDataGridView);

            oDataGridView.CellContentClick += new DataGridViewCellEventHandler(MasterGrid_CellContentClick_Event);

            //Nuevo ubicación del reporte y nuevo tamaño de acuerdo al tamaño del menu
            this.Location = new Point(0, 0);
            this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
        }

        private void btAuxiliar_Click(object sender, EventArgs e)
        {
            FrmBusquedaPersona oFrm = new FrmBusquedaPersona();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
            {
                idPersona = oFrm.oPersona.IdPersona;
                txtRuc.Text = oFrm.oPersona.RUC;
                txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
            }
        }

        private void chkAuxiliares_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkAuxiliares.Checked)
            {
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRazonSocial.Text = String.Empty;
                btAuxiliar.Enabled = true;
            }
            else
            {
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtRazonSocial.Text = String.Empty;
                btAuxiliar.Enabled = false;
                idPersona = Variables.Cero;
            }
        }

        private void chkCuentas_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCuentas.Checked)
            {
                txtCuenta.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesCuenta.Text = String.Empty;
                btCuenta.Enabled = true;
            }
            else
            {
                txtCuenta.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtDesCuenta.Text = String.Empty;
                btCuenta.Enabled = true;
            }
        }

        private void MasterGrid_CellContentClick_Event(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (!String.IsNullOrEmpty(oDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString()))
                    {
                        if (e.ColumnIndex == 0)
                        {
                            if (Estado == "expandir")
                            {
                                //for (int i = 0; i < oDataGridView.Rows.Count; i++)
                                //{
                                if (!String.IsNullOrEmpty(oDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString()))
                                {
                                    oDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = bitExpandir;

                                    if ((String)oDataGridView.Rows[e.RowIndex].Cells["RazonSocial"].Value.ToString().Trim() == "TOTAL GENERAL >>>>")
                                    {
                                        oDataGridView.Rows[e.RowIndex].Cells[0].Value = bitAmarillo;
                                    }
                                    else if ((String)oDataGridView.Rows[e.RowIndex].Cells["RazonSocial"].Value.ToString().Trim() == "TOTAL CUENTA >>>>")
                                    {
                                        oDataGridView.Rows[e.RowIndex].Cells[0].Value = bitAcero;
                                    }
                                    else if ((String)oDataGridView.Rows[e.RowIndex].Cells["RazonSocial"].Value.ToString().Trim() == "TOTAL AUXILIAR >>>>")
                                    {
                                        oDataGridView.Rows[e.RowIndex].Cells[0].Value = bitVerde;
                                    }
                                }
                                else
                                {
                                    oDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = bitBlanco;

                                    if ((String)oDataGridView.Rows[e.RowIndex].Cells["RazonSocial"].Value.ToString().Trim() == "TOTAL GENERAL >>>>")
                                    {
                                        oDataGridView.Rows[e.RowIndex].Cells[0].Value = bitAmarillo;
                                    }
                                    else if ((String)oDataGridView.Rows[e.RowIndex].Cells["RazonSocial"].Value.ToString().Trim() == "TOTAL CUENTA >>>>")
                                    {
                                        oDataGridView.Rows[e.RowIndex].Cells[0].Value = bitAcero;
                                    }
                                    else if ((String)oDataGridView.Rows[e.RowIndex].Cells["RazonSocial"].Value.ToString().Trim() == "TOTAL AUXILIAR >>>>")
                                    {
                                        oDataGridView.Rows[e.RowIndex].Cells[0].Value = bitVerde;
                                    }
                                }
                                //}

                                oDataGridViewDetalle.Visible = true;
                                Estado = "contraer";
                                oDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = bitContraer;

                                oDataGridView.Controls.Add(oDataGridViewDetalle);

                                Rectangle dgvRectangle = oDataGridView.GetCellDisplayRectangle(1, e.RowIndex, true);
                                oDataGridViewDetalle.Size = new Size(oDataGridView.Width - 200, 200);
                                oDataGridViewDetalle.Location = new Point(dgvRectangle.X, dgvRectangle.Y + 20);

                                Int32 idCtaCteTmp = (Int32)oDataGridView.Rows[e.RowIndex].Cells[20].Value;
                                conCtaCteE idLinea = oListaCtaCte.Find(delegate(conCtaCteE cc) { return cc.idCtaCte == idCtaCteTmp; } );

                                if (idLinea != null)
                                {
                                    LlenarDetalle(idLinea.ListaCtaCteItems);
                                }                                

                                Indice = oDataGridView.CurrentRow.Index;
                            }
                            else
                            {
                                //for (int i = 0; i < oDataGridView.Rows.Count; i++)
                                //{
                                if (!String.IsNullOrEmpty(oDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString()))
                                {
                                    oDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = bitExpandir;
                                }
                                else
                                {
                                    oDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = bitBlanco;
                                }
                                //}

                                Estado = "expandir";
                                oDataGridViewDetalle.Visible = false;

                                if (Indice != oDataGridView.CurrentRow.Index)
                                {
                                    oDataGridViewDetalle.Visible = true;
                                    Estado = "expandir";
                                    oDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = bitContraer;

                                    oDataGridView.Controls.Add(oDataGridViewDetalle);

                                    Rectangle dgvRectangle = oDataGridView.GetCellDisplayRectangle(1, e.RowIndex, true);
                                    oDataGridViewDetalle.Size = new Size(oDataGridView.Width - 200, 200);
                                    oDataGridViewDetalle.Location = new Point(dgvRectangle.X, dgvRectangle.Y + 20);
                                }
                            }

                            oDataGridViewDetalle.AutoResizeColumns();
                        }
                        else
                        {
                            for (int i = 0; i < oDataGridView.Rows.Count; i++)
                            {
                                if (!String.IsNullOrEmpty(oDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString()))
                                {
                                    oDataGridView.Rows[i].Cells[0].Value = bitExpandir;

                                    if ((String)oDataGridView.Rows[i].Cells["RazonSocial"].Value.ToString().Trim() == "TOTAL GENERAL >>>>")
                                    {
                                        oDataGridView.Rows[i].Cells[0].Value = bitAmarillo;
                                    }
                                    else if ((String)oDataGridView.Rows[i].Cells["RazonSocial"].Value.ToString().Trim() == "TOTAL CUENTA >>>>")
                                    {
                                        oDataGridView.Rows[i].Cells[0].Value = bitAcero;
                                    }
                                    else if ((String)oDataGridView.Rows[i].Cells["RazonSocial"].Value.ToString().Trim() == "TOTAL AUXILIAR >>>>")
                                    {
                                        oDataGridView.Rows[i].Cells[0].Value = bitVerde;
                                    }
                                }
                                else
                                {
                                    oDataGridView.Rows[i].Cells[0].Value = bitBlanco;

                                    if ((String)oDataGridView.Rows[i].Cells["RazonSocial"].Value.ToString().Trim() == "TOTAL GENERAL >>>>")
                                    {
                                        oDataGridView.Rows[i].Cells[0].Value = bitAmarillo;
                                    }
                                    else if ((String)oDataGridView.Rows[i].Cells["RazonSocial"].Value.ToString().Trim() == "TOTAL CUENTA >>>>")
                                    {
                                        oDataGridView.Rows[i].Cells[0].Value = bitAcero;
                                    }
                                    else if ((String)oDataGridView.Rows[i].Cells["RazonSocial"].Value.ToString().Trim() == "TOTAL AUXILIAR >>>>")
                                    {
                                        oDataGridView.Rows[i].Cells[0].Value = bitVerde;
                                    }
                                }
                            }

                            oDataGridViewDetalle.Visible = false;
                            Estado = "expandir";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Estado = "expandir";
                Global.MensajeError(ex.Message);
            }
        } 

        #endregion

        private void btCuenta_Click(object sender, EventArgs e)
        {
            frmBuscarCuentasCte oFrm = new frmBuscarCuentasCte();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Cuentas != null)
            {
                //idPersona = oFrm.oPersona.IdPersona;
                txtCuenta.Text = oFrm.Cuentas.codCuenta;
                txtDesCuenta.Text = oFrm.Cuentas.Descripcion;
            }
        }

    }
}