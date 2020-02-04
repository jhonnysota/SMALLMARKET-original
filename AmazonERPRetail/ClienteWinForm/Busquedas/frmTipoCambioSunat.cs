using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Entidades.Generales;
using ConsultasOnline;

namespace ClienteWinForm.Busquedas
{
    public partial class frmTipoCambioSunat : FrmMantenimientoBase
    {
        #region Constructores
        
        public frmTipoCambioSunat()
        {
            Global.AjustarResolucion(this);

            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            pFormatoGrid();
            LlenarCombos();
        }

        public frmTipoCambioSunat(Boolean VieneForm)
            : this()
        {
            DesdeMenu = VieneForm;
        } 

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }

        public Int32 MesConsulta;
        public Int32 AnioConsulta;
        public String Periodo = String.Empty;
        public TipoCambioE ETicCa = null;

        Int32 anioInicio = 0;
        Int32 anioFin = 0;
        SunatTica TipoCambio = null;
        Boolean DesdeMenu = true;
        DateTime FechaActual = VariablesLocales.FechaHoy;

        #endregion

        #region Procedimientos de Usuario

        private void LlenarCombos()
        {
            DataTable MesesAnios = FechasHelper.CargarMeses(1, true, "PM");
            DataRow Fila;
            
            //Cargando Meses
            Fila = MesesAnios.NewRow();
            Fila["MesId"] = "00";
            Fila["MesDes"] = "Mes";
            MesesAnios.Rows.Add(Fila);

            MesesAnios.DefaultView.Sort = "MesId ASC";
            cboMeses.DataSource = MesesAnios;
            cboMeses.ValueMember = "MesId";
            cboMeses.DisplayMember = "MesDes";
            cboMeses.SelectedValue = "00";

            //Cargando Años
            anioFin = Convert.ToInt32(FechaActual.Year);
            anioInicio = anioFin - 20;

            MesesAnios = new DataTable();
            MesesAnios = FechasHelper.CargarAnios(anioInicio, anioFin);
            Fila = MesesAnios.NewRow();
            Fila["AnioId"] = 0;
            Fila["AnioDes"] = "Año";
            MesesAnios.Rows.Add(Fila);

            MesesAnios.DefaultView.Sort = "AnioId";
            cboAnios.DataSource = MesesAnios;
            cboAnios.ValueMember = "AnioId";
            cboAnios.DisplayMember = "AnioDes";
            cboAnios.SelectedValue = 0;
        }

        private void pFormatoGrid()
        {
            //Inicializar propiedades básicas DataGridView.
            dgvTipoCambio.BackgroundColor = Color.White;
            dgvTipoCambio.BorderStyle = BorderStyle.None;

            //Establecer el estilo de las filas y columnas del encabezado
            dgvTipoCambio.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold, GraphicsUnit.Point);
            dgvTipoCambio.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(182, 203, 235);
            dgvTipoCambio.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(182, 203, 235);
            dgvTipoCambio.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvTipoCambio.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //Valores de propiedad, conjunto adecuado para la visualización.
            //dgvTipoCambio.AllowUserToAddRows = false;
            //dgvTipoCambio.AllowUserToDeleteRows = false;
            dgvTipoCambio.AllowUserToOrderColumns = false;
            dgvTipoCambio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTipoCambio.MultiSelect = false;

            dgvTipoCambio.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            dgvTipoCambio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvTipoCambio.AllowUserToResizeColumns = false;
            dgvTipoCambio.AllowUserToResizeRows = false;
            // establecer ajuste de altura automático para las filas
            //dgvTipoCambio.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            // establecer ajuste de anchura automático para las columnas
            //dgvTipoCambio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            ////Para que la primera columan no aparesca
            dgvTipoCambio.RowHeadersVisible = false;
            //dgvTipoCambio.RowHeadersWidth = 20;

            //Estableciendo el el alto de los titulos
            dgvTipoCambio.ColumnHeadersHeight = 30;            

            //Formato para las filas
            DataGridViewRow lineas = dgvTipoCambio.RowTemplate; //Establece la plantilla para todas las filas.
            lineas.Height = 20;
            lineas.MinimumHeight = 10;
            dgvTipoCambio.Refresh();

            //dgvAcciones.AutoResizeColumns();
            // Attach a handler to the CellFormatting event.
            //dgvTipoCambio.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvTipoCambio_CellFormatting);            
        }

        private void AlineacionGrid()
        {
            dgvTipoCambio.Columns[2].Visible = false;
            dgvTipoCambio.Columns[3].Visible = false;
            
            dgvTipoCambio.Columns[0].HeaderText = "Nomb. Dia";
            dgvTipoCambio.Columns[0].Width = 90;
            dgvTipoCambio.Columns[1].Width = 75;
            dgvTipoCambio.Columns[4].Width = 110;
            dgvTipoCambio.Columns[5].Width = 110;

            dgvTipoCambio.Columns[0].ReadOnly = true;
            dgvTipoCambio.Columns[1].ReadOnly = true;
            dgvTipoCambio.Columns[4].ReadOnly = true;
            dgvTipoCambio.Columns[5].ReadOnly = true;
            //dgvTipoCambio.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            //dgvTipoCambio.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            
            //Estableciendo alineaciones
            dgvTipoCambio.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTipoCambio.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTipoCambio.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTipoCambio.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvTipoCambio_CellFormatting);
        }

        private void Aceptar()
        {
            ETicCa = new TipoCambioE();

            int _dia = Convert.ToInt32(dgvTipoCambio.CurrentRow.Cells["Dia"].Value);
            string dia = _dia.ToString("00");
            ETicCa.fecCambio = Convert.ToDateTime(dia + "/" + MesConsulta + "/" + AnioConsulta).ToString("yyyyMMdd");
            ETicCa.valCompra = Convert.ToDecimal(dgvTipoCambio.CurrentRow.Cells["Compra"].Value);
            ETicCa.valVenta = Convert.ToDecimal(dgvTipoCambio.CurrentRow.Cells["Venta"].Value);

            /*ListaTipoCambio = new List<TipoCambioE>();

            foreach (DataGridViewRow Fila in dgvTipoCambio.Rows)
            {
                if (Convert.ToBoolean(Fila.Cells["Seleccionar"].Value) == true)
                {
                    TipoCambioE tica = new TipoCambioE();

                    _dia = Convert.ToInt32(Fila.Cells["Dia"].Value);
                    dia = _dia.ToString("00");

                    tica.fecCambio = Convert.ToDateTime(dia + "/" + MesConsulta + "/" + AnioConsulta);
                    tica.valCompra = Convert.ToDecimal(Fila.Cells["Compra"].Value);
                    tica.valVenta = Convert.ToDecimal(Fila.Cells["Venta"].Value);

                    ListaTipoCambio.Add(tica);
                }
            }*/
        }

        private void ObtenerPeriodo()
        {
            MesConsulta = Convert.ToInt32(cboMeses.SelectedValue);
            AnioConsulta = Convert.ToInt32(cboAnios.Text);

            lblPeriodo.Text = Global.PrimeraMayuscula(FechasHelper.NombreMes(MesConsulta)) + " - " + AnioConsulta.ToString();
        }

        private bool BuscarTipoCambio()
        {
            dgvTipoCambio.Columns.Clear();
            dgvTipoCambio.DataSource = null;

            List<SunatTica> oListaTiCa = new List<SunatTica>();
            TipoCambio = new SunatTica();

            oListaTiCa = TipoCambio.ObtenerPorMes(MesConsulta, AnioConsulta);

            foreach (SunatTica item in oListaTiCa)
            {
                item.Nombre = Global.PrimeraMayuscula(FechasHelper.NombreDia(Convert.ToDateTime(item.Dia + "/" + MesConsulta.ToString("00") + "/" + AnioConsulta.ToString())));
            }

            if (oListaTiCa.Count > Variables.Cero)
	        {
                dgvTipoCambio.DataSource = oListaTiCa;
                oListaTiCa = null;
                return true;
	        }
            else
            {
                Global.MensajeComunicacion("No exíste Tipo de Cambio para este mes.\n\rVuelva a intentarlo mas tarde...");
                return false;
            }
        }

        private TipoCambioE AgregarTica(DateTime Fecha, Decimal Compra, Decimal Venta)
        { 
            TipoCambioE oTiCa = new TipoCambioE() 
            {
                idMoneda = Variables.Dolares,
                fecCambio = Fecha.ToString("yyyyMMdd"),
                valCompra = Compra,
                valVenta = Venta,
                valCompraCaja = Variables.ValorCeroDecimal,
                valVentaCaja = Variables.ValorCeroDecimal,
                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
            };

            return oTiCa;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Buscar()
        {
            ObtenerPeriodo();
            
            if (BuscarTipoCambio())
            {
                AlineacionGrid();
            }
        }

        #endregion

        #region Eventos

        private void frmTipoCambioSunat_Load(object sender, EventArgs e)
        {
            if (DesdeMenu)
            {
                lblPeriodo.Text = Global.PrimeraMayuscula(FechasHelper.NombreMes(FechaActual.Month)) + " - " + FechaActual.Year.ToString();
                MesConsulta = FechaActual.Month;
                AnioConsulta = FechaActual.Year;
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                btGuardar.Visible = true;
                btExportar.Visible = true;

                if (BuscarTipoCambio())
                {
                    AlineacionGrid();
                }
            }
            else
            {
                btAceptar.Visible = true;
                btCancelar.Visible = true;
                lblPeriodo.Text = Periodo;

                if (!BuscarTipoCambio())
                {
                    btCancelar.PerformClick();
                }
                else
                {
                    AlineacionGrid();
                }
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMeses.SelectedValue.ToString() == "00")
                {
                    Global.MensajeFault("Debe escoger un mes.");
                    cboMeses.Focus();
                    return;
                }

                if (Convert.ToInt32(cboAnios.SelectedValue) == 0)
                {
                    Global.MensajeFault("Debe escoger un año.");
                    cboAnios.Focus();
                    return;
                }

                Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvTipoCambio_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            //Para que todas las columnas no se puedan ordenar por la cabecera...
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dgvTipoCambio_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTipoCambio.Columns[e.ColumnIndex].Name == "Dia")
            {
                e.CellStyle.Format = "00";
            }

            if (dgvTipoCambio.Columns[e.ColumnIndex].Name == "Venta" || dgvTipoCambio.Columns[e.ColumnIndex].Name == "Compra")
            {
                e.CellStyle.Format = "N3";
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Aceptar();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvTipoCambio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!DesdeMenu)
            {
                Aceptar();
                this.DialogResult = DialogResult.OK; 
            }
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<TipoCambioE> ListaTipoCambio = new List<TipoCambioE>();
                Int32 Dias = DateTime.DaysInMonth(Convert.ToInt32(AnioConsulta), Convert.ToInt32(MesConsulta));
                Int32 DiaGrid = Variables.Cero;
                Int32 filTemp = Variables.Cero;
                Int32 Inicio = Variables.ValorUno;
                Boolean Salir = false;
                Boolean ConteoFinal = false;

                DiaGrid = Convert.ToInt32(dgvTipoCambio.Rows[0].Cells["Dia"].Value);

                if (DiaGrid <= 5)
                {
                    List<SunatTica> oListaTiCaTemp = new List<SunatTica>();
                    SunatTica oTicaTemp = new SunatTica();

                    if (MesConsulta == 1)
                    {
                        oListaTiCaTemp = oTicaTemp.ObtenerPorMes(12, AnioConsulta - 1);
                    }
                    else
                    {
                        oListaTiCaTemp = oTicaTemp.ObtenerPorMes(MesConsulta - 1, AnioConsulta);
                    }

                    if (oListaTiCaTemp.Count > Variables.Cero)
                    {
                        for (int dia = 1; dia < DiaGrid; dia++)
                        {
                            ListaTipoCambio.Add(AgregarTica(Convert.ToDateTime(dia.ToString("00") + "/" + MesConsulta.ToString("00") + "/" + AnioConsulta.ToString()), 
                                                            Convert.ToDecimal(oListaTiCaTemp[oListaTiCaTemp.Count - 1].Compra), 
                                                            Convert.ToDecimal(oListaTiCaTemp[oListaTiCaTemp.Count - 1].Venta)));
                            Inicio++;
                        }

                        oListaTiCaTemp = null;
                        oTicaTemp = null;
                    }
                }

                DiaGrid = Variables.Cero;

                for (int i = Inicio; i <= Dias; i++)
                {
                    for (int iFil = filTemp; iFil < dgvTipoCambio.Rows.Count; iFil++)
                    {
                        DiaGrid = Convert.ToInt32(dgvTipoCambio.Rows[iFil].Cells["Dia"].Value);

                        if (i == DiaGrid)
                        {
                        //    oSb.Append(i.ToString("00")).Append("/").Append(MesConsulta.ToString("00")).Append("/").Append(AnioConsulta.ToString()).Append("|");
                        //    oSb.Append(Convert.ToDecimal(dgvTipoCambio.Rows[iFil].Cells["Compra"].Value).ToString("N3")).Append("|");
                        //    oSb.Append(Convert.ToDecimal(dgvTipoCambio.Rows[iFil].Cells["Venta"].Value).ToString("N3")).Append("|");
                            ListaTipoCambio.Add(AgregarTica(Convert.ToDateTime(i.ToString("00") + "/" + MesConsulta.ToString("00") + "/" + AnioConsulta.ToString()),
                                                            Convert.ToDecimal(dgvTipoCambio.Rows[iFil].Cells["Compra"].Value),
                                                            Convert.ToDecimal(dgvTipoCambio.Rows[iFil].Cells["Venta"].Value)));
                            filTemp = iFil + 1;
                            Salir = true;
                        }
                        else
                        {
                            if (!ConteoFinal)
                            {
                                //oSb.Append(i.ToString("00")).Append("/").Append(MesConsulta.ToString("00")).Append("/").Append(AnioConsulta.ToString()).Append("|");
                                //oSb.Append(Convert.ToDecimal(dgvTipoCambio.Rows[iFil - 1].Cells["Compra"].Value).ToString("N3")).Append("|");
                                //oSb.Append(Convert.ToDecimal(dgvTipoCambio.Rows[iFil - 1].Cells["Venta"].Value).ToString("N3")).Append("|");
                                ListaTipoCambio.Add(AgregarTica(Convert.ToDateTime(i.ToString("00") + "/" + MesConsulta.ToString("00") + "/" + AnioConsulta.ToString()),
                                                                Convert.ToDecimal(dgvTipoCambio.Rows[iFil - 1].Cells["Compra"].Value),
                                                                Convert.ToDecimal(dgvTipoCambio.Rows[iFil - 1].Cells["Venta"].Value)));
                            }
                            else
                            {
                                //oSb.Append(i.ToString("00")).Append("/").Append(MesConsulta.ToString("00")).Append("/").Append(AnioConsulta.ToString()).Append("|");
                                //oSb.Append(Convert.ToDecimal(dgvTipoCambio.Rows[iFil].Cells["Compra"].Value).ToString("N3")).Append("|");
                                //oSb.Append(Convert.ToDecimal(dgvTipoCambio.Rows[iFil].Cells["Venta"].Value).ToString("N3")).Append("|");
                                ListaTipoCambio.Add(AgregarTica(Convert.ToDateTime(i.ToString("00") + "/" + MesConsulta.ToString("00") + "/" + AnioConsulta.ToString()),
                                                                Convert.ToDecimal(dgvTipoCambio.Rows[iFil].Cells["Compra"].Value),
                                                                Convert.ToDecimal(dgvTipoCambio.Rows[iFil].Cells["Venta"].Value)));

                                filTemp = iFil + 1;
                            }

                            Salir = true;
                        }

                        if (Salir)
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (filTemp == dgvTipoCambio.Rows.Count)
                    {
                        ConteoFinal = true;
                    }

                    Salir = false;

                    if (i <= Dias)
                    {
                        if (ConteoFinal)
                        {
                            filTemp--;
                        }
                    }
                }

                if (ListaTipoCambio.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(String.Format("Desea guardar el Tipo de Cambio del mes de {0}", Global.PrimeraMayuscula(FechasHelper.NombreMes(MesConsulta)))) == DialogResult.Yes)
                    {
                        AgenteGeneral.Proxy.GrabarTipoCambioMasivo(ListaTipoCambio);
                        Global.MensajeComunicacion("Tipo de Cambio guardado...");
                    }
                }

                #region comentado

                //List<TipoCambioE> ListaTipoCambio = new List<TipoCambioE>();
                //TipoCambioE tica = null;
                //String dia = String.Empty;
                //Int32 DiaGrid = Variables.ValorCero;
                //Int32 MinDia = dgvTipoCambio.Rows.Cast<DataGridViewRow>().Min(r => Convert.ToInt32(r.Cells["Dia"].Value));
                //Int32 MaxDia = dgvTipoCambio.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["Dia"].Value));
                //Decimal ValorVenta = Variables.ValorCeroDecimal;
                //Decimal ValorCompra = Variables.ValorCeroDecimal;
                //Boolean ElPrimero = false; 

                //#endregion

                //#region Saber si la lista trae el primer dia

                //if (MinDia > 1)
                //{
                //    MinDia = 2;
                //    DateTime FechaAnterior = Convert.ToDateTime("01" + "/" + MesConsulta + "/" + AnioConsulta).AddDays(-1);
                //    TipoCambioE TicaTmp = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.MonedaDolares, FechaAnterior.Date);

                //    if (TicaTmp != null)
                //    {
                //        TicaTmp.idMoneda = Variables.MonedaDolares;
                //        TicaTmp.fecCambio = Convert.ToDateTime("01" + "/" + MesConsulta + "/" + AnioConsulta);
                //        TicaTmp.valCompra = ValorCompra = TicaTmp.valCompra;
                //        TicaTmp.valVenta = ValorVenta = TicaTmp.valVenta;
                //        TicaTmp.valCompraCaja = Variables.ValorCeroDecimal;
                //        TicaTmp.valVentaCaja = Variables.ValorCeroDecimal;
                //        TicaTmp.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;

                //        ListaTipoCambio.Add(TicaTmp);

                //        ElPrimero = true;
                //    }
                //    else
                //    {
                //        TicaTmp = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.MonedaDolares, FechaAnterior.Date.AddDays(-2));

                //        if (TicaTmp != null)
                //        {
                //            TicaTmp.idMoneda = Variables.MonedaDolares;
                //            TicaTmp.fecCambio = Convert.ToDateTime("01" + "/" + MesConsulta + "/" + AnioConsulta);
                //            TicaTmp.valCompra = ValorCompra = TicaTmp.valCompra;
                //            TicaTmp.valVenta = ValorVenta = TicaTmp.valVenta;
                //            TicaTmp.valCompraCaja = Variables.ValorCeroDecimal;
                //            TicaTmp.valVentaCaja = Variables.ValorCeroDecimal;
                //            TicaTmp.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;

                //            ListaTipoCambio.Add(TicaTmp);
                //        }
                //        else
                //        {
                //            TicaTmp = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.MonedaDolares, FechaAnterior.Date.AddDays(-3));

                //            if (TicaTmp != null)
                //            {
                //                TicaTmp.idMoneda = Variables.MonedaDolares;
                //                TicaTmp.fecCambio = Convert.ToDateTime("01" + "/" + MesConsulta + "/" + AnioConsulta);
                //                TicaTmp.valCompra = ValorCompra = TicaTmp.valCompra;
                //                TicaTmp.valVenta = ValorVenta = TicaTmp.valVenta;
                //                TicaTmp.valCompraCaja = Variables.ValorCeroDecimal;
                //                TicaTmp.valVentaCaja = Variables.ValorCeroDecimal;
                //                TicaTmp.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;

                //                ListaTipoCambio.Add(TicaTmp);
                //            }
                //        }

                //        ElPrimero = true;
                //    }
                //} 

                //#endregion

                //#region Llenando la lista del mes

                //for (int i = MinDia; i <= MaxDia; i++)
                //{
                //    tica = new TipoCambioE();

                //    for (int Fila = 0; Fila < dgvTipoCambio.Rows.Count; Fila++)
                //    {
                //        DiaGrid = Convert.ToInt32(dgvTipoCambio.Rows[Fila].Cells["Dia"].Value);

                //        if (i == DiaGrid)
                //        {
                //            dia = Convert.ToInt32(dgvTipoCambio.Rows[Fila].Cells["Dia"].Value).ToString("00");
                //            tica.idMoneda = Variables.MonedaDolares;
                //            tica.fecCambio = Convert.ToDateTime(dia + "/" + MesConsulta + "/" + AnioConsulta);
                //            tica.valCompra = ValorCompra = Convert.ToDecimal(dgvTipoCambio.Rows[Fila].Cells["Compra"].Value);
                //            tica.valVenta = ValorVenta = Convert.ToDecimal(dgvTipoCambio.Rows[Fila].Cells["Venta"].Value);
                //            tica.valCompraCaja = Variables.ValorCeroDecimal;
                //            tica.valVentaCaja = Variables.ValorCeroDecimal;
                //            tica.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;

                //            ListaTipoCambio.Add(tica);
                //            ElPrimero = false;
                //            break;
                //        }
                //        else
                //        {
                //            ElPrimero = false;
                //        }
                //    }

                //    if (i != DiaGrid && !ElPrimero)
                //    {
                //        dia = i.ToString("00");
                //        tica.idMoneda = Variables.MonedaDolares;
                //        tica.fecCambio = Convert.ToDateTime(dia + "/" + MesConsulta + "/" + AnioConsulta);
                //        tica.valCompra = ValorCompra;
                //        tica.valVenta = ValorVenta;
                //        tica.valCompraCaja = Variables.ValorCeroDecimal;
                //        tica.valVentaCaja = Variables.ValorCeroDecimal;
                //        tica.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;

                //        ListaTipoCambio.Add(tica);
                //    }
                //} 

                #endregion

                //if (ListaTipoCambio.Count > Variables.ValorCero)
                //{
                //    if (Global.MensajeConfirmacion(String.Format("Desea guardar el Tipo de Cambio del mes de {0}", Global.PrimeraMayuscula(FechasHelper.NombreMes(MesConsulta)))) == DialogResult.Yes)
                //    {
                //        AgenteGeneral.Proxy.GrabarTipoCambioMasivo(ListaTipoCambio);

                //        Global.MensajeComunicacion("Tipo de Cambio guardado...");
                //    }                    
                //}
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btExportar_Click(object sender, EventArgs e)
        {
            try
            {
                String Nombre = VariablesLocales.SesionUsuario.Empresa.RUC + ".tc";
                String Ruta = CuadrosDialogo.GuardarDocumento("Guardar en", Nombre, "Archivo (*.tc)|*.tc");

                if (!String.IsNullOrEmpty(Ruta))
                {
                    StringBuilder oSb = new StringBuilder();
                    Int32 MaxDia = dgvTipoCambio.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["Dia"].Value));
                    Int32 Dias = DateTime.DaysInMonth(Convert.ToInt32(AnioConsulta), Convert.ToInt32(MesConsulta));
                    Int32 DiaGrid = Variables.Cero;
                    Int32 filTemp = Variables.Cero;
                    Int32 Inicio = Variables.ValorUno;
                    Boolean Salir = false;
                    Boolean ConteoFinal = false;

                    if (File.Exists(Ruta))
                    {
                        File.Delete(Ruta);
                    }

                    using (StreamWriter oSw = new StreamWriter(Ruta, true, Encoding.Default))
                    {
                        DiaGrid = Convert.ToInt32(dgvTipoCambio.Rows[0].Cells["Dia"].Value);

                        if (DiaGrid <= 4)
                        {
                            List<SunatTica> oListaTiCa = new List<SunatTica>();
                            SunatTica oTicaTemp = new SunatTica();

                            if (MesConsulta == 1)
                            {
                                oListaTiCa = oTicaTemp.ObtenerPorMes(12, AnioConsulta -1);
                            }
                            else
                            {
                                oListaTiCa = oTicaTemp.ObtenerPorMes(MesConsulta - 1, AnioConsulta);
                            }

                            if (oListaTiCa.Count > Variables.Cero)
                            {
                                for (int dia = 1; dia < DiaGrid; dia++)
                                {
                                    oSb.Append(dia.ToString("00")).Append("/").Append(MesConsulta.ToString("00")).Append("/").Append(AnioConsulta.ToString()).Append("|");
                                    oSb.Append(Convert.ToDecimal(oListaTiCa[oListaTiCa.Count - 1].Compra).ToString("N3")).Append("|");
                                    oSb.Append(Convert.ToDecimal(oListaTiCa[oListaTiCa.Count - 1].Venta).ToString("N3")).Append("|");

                                    oSw.WriteLine(oSb.ToString());
                                    oSb.Clear();
                                    Inicio++;
                                }
                            }

                            oListaTiCa = null;
                            oTicaTemp = null;
                        }

                        for (int i = Inicio; i <= Dias; i++)
                        {
                            for (int iFil = filTemp; iFil < dgvTipoCambio.Rows.Count; iFil++)
                            {
                                DiaGrid = Convert.ToInt32(dgvTipoCambio.Rows[iFil].Cells["Dia"].Value);

                                if (i == DiaGrid)
                                {
                                    oSb.Append(i.ToString("00")).Append("/").Append(MesConsulta.ToString("00")).Append("/").Append(AnioConsulta.ToString()).Append("|");
                                    oSb.Append(Convert.ToDecimal(dgvTipoCambio.Rows[iFil].Cells["Compra"].Value).ToString("N3")).Append("|");
                                    oSb.Append(Convert.ToDecimal(dgvTipoCambio.Rows[iFil].Cells["Venta"].Value).ToString("N3")).Append("|");

                                    oSw.WriteLine(oSb.ToString());
                                    oSb.Clear();
                                    filTemp = iFil + 1;
                                    Salir = true;
                                }
                                else
                                {
                                    if (!ConteoFinal)
                                    {
                                        oSb.Append(i.ToString("00")).Append("/").Append(MesConsulta.ToString("00")).Append("/").Append(AnioConsulta.ToString()).Append("|");
                                        oSb.Append(Convert.ToDecimal(dgvTipoCambio.Rows[iFil - 1].Cells["Compra"].Value).ToString("N3")).Append("|");
                                        oSb.Append(Convert.ToDecimal(dgvTipoCambio.Rows[iFil - 1].Cells["Venta"].Value).ToString("N3")).Append("|"); 
                                    }
                                    else
                                    {
                                        oSb.Append(i.ToString("00")).Append("/").Append(MesConsulta.ToString("00")).Append("/").Append(AnioConsulta.ToString()).Append("|");
                                        oSb.Append(Convert.ToDecimal(dgvTipoCambio.Rows[iFil].Cells["Compra"].Value).ToString("N3")).Append("|");
                                        oSb.Append(Convert.ToDecimal(dgvTipoCambio.Rows[iFil].Cells["Venta"].Value).ToString("N3")).Append("|");

                                        filTemp = iFil + 1;
                                    }

                                    oSw.WriteLine(oSb.ToString());
                                    oSb.Clear();
                                    Salir = true;
                                }

                                if (Salir)
                                {
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            if (filTemp == dgvTipoCambio.Rows.Count)
                            {
                                ConteoFinal = true;
                            }
                            
                            Salir = false;

                            if (i <= Dias)
                            {
                                if (ConteoFinal)
                                {
                                    filTemp--;
                                }
                            }
                        }

                        oSb.Clear();
                    }

                    Global.MensajeComunicacion(String.Format("El tipo de cambio del mes de {0} se generó con éxito.", Global.PrimeraMayuscula(FechasHelper.NombreMes(MesConsulta))));
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
