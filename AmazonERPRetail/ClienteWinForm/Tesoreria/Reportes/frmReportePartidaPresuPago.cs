using ClienteWinForm.Almacen.Reportes;
using Entidades.CtasPorPagar;
using Infraestructura;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClienteWinForm.Formulario_Bubbler
{
    public partial class frmReportePartidaPresuPago : FrmMantenimientoBase
    {

        CtasPorPagarServiceAgent AgenteCtasPorPagar{ get { return new CtasPorPagarServiceAgent(); } }

        List<ProvisionesE> oListaPartipaPresu = new List<ProvisionesE>();

        public frmReportePartidaPresuPago()
        {
            InitializeComponent();

            FormatoGrid(dgvPivot, false, false, 30, 25, false);
        }

        void FormatoGrid(DataGridView oDgv, bool PrimerCol, Boolean EscogerVariasFilas = false, Int32 AltoCabecera = 25, Int32 AltoFilas = 20, Boolean MostrarColorAlterno = true)
        {
            ////Para que la primera columan no aparesca
            oDgv.RowHeadersVisible = PrimerCol;
            oDgv.RowHeadersWidth = 20;

            //Inicializar propiedades básicas DataGridView.
            oDgv.BackgroundColor = Color.LightSteelBlue;
            oDgv.BorderStyle = BorderStyle.None;

            //Establecer el estilo de las filas y columnas del encabezado
            oDgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point);
            oDgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;
            oDgv.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            oDgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            oDgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //Alternando colores en las filas
            oDgv.RowsDefaultCellStyle.BackColor = Color.White;

            if (MostrarColorAlterno)
            {
                oDgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            }

            oDgv.RowsDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);

            //Valores de propiedad, conjunto adecuado para la visualización.
            oDgv.AllowUserToAddRows = false;
            oDgv.AllowUserToDeleteRows = false;
            oDgv.AllowUserToOrderColumns = false;
            oDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            oDgv.MultiSelect = EscogerVariasFilas;

            oDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            oDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            //Estableciendo el el alto de los titulos
            oDgv.ColumnHeadersHeight = AltoCabecera;

            //Formato para las filas
            DataGridViewRow lineas = oDgv.RowTemplate; //Establece la plantilla para todas las filas.
            lineas.Height = AltoFilas;
            lineas.MinimumHeight = 10;

            oDgv.Refresh();
        }


        private void frmReportePartidaPresu_Load(object sender, EventArgs e)
        {
            //Grid = true;

            //this.Location = new Point(0, 0);
            //this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            txtDesde.Value = Convert.ToDateTime("01/" + txtDesde.Value.Month.ToString("00") + "/" + txtDesde.Value.Year);
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            oListaPartipaPresu = AgenteCtasPorPagar.Proxy.ListarPartidaPresuAgrupadoPorPagos(4, txtDesde.Value, txtHasta.Value);

            // ==========================================
            if (oListaPartipaPresu == null || oListaPartipaPresu.Count == 0)
            {
                dgvPivot.DataSource = null;
                lblregistros.Text = "0 registros";
                Global.MensajeFault("No hay registros");
                return;
            }
            // ==========================================

            DataTable dtDatos = new DataTable();

            DataRow dt = null;

            dtDatos.Columns.Add("Codigo");
            dtDatos.Columns.Add("Descripcion");

            dtDatos.Columns.Add("Total");


            // ==========================================
            // LISTA CABECERA
            // ==========================================

            List<ProvisionesE> listaCabe;

           
           listaCabe = oListaPartipaPresu.GroupBy(x => x.MesPeriodo).Select(g => g.First()).OrderBy(x => x.MesPeriodo).ToList();
           
            for (int i = 0; i < listaCabe.Count; i++)
            {
                string mes = listaCabe[i].MesPeriodo;

                dtDatos.Columns.Add(listaCabe[i].AnioPeriodo + " - " + (mes == "00" ? "APERTURA" : (mes == "01" ? "ENERO" : (mes == "02" ? "FEBRERO" : (mes == "03" ? "MARZO" : (mes == "04" ? "ABRIL" : (mes == "05" ? "MAYO" : (mes == "06" ? "JUNIO" : (mes == "07" ? "JULIO" : (mes == "08" ? "AGOSTO" : (mes == "09" ? "SETIEMBRE" : (mes == "10" ? "OCTUBRE" : (mes == "11" ? "NOVIEMBRE" : "DICIEMBRE")))))))))))));
                
            }

            // ==========================================
            // LISTA CABECERA
            // ==========================================

            List<ProvisionesE> listaData = new List<ProvisionesE>();
                
            listaData = (from x in oListaPartipaPresu orderby Convert.ToInt32(x.CodPartidaPresu) select x).ToList();

            Boolean NuevoLinea = false;

            string CodPartidaPresu = "";
            int contador = 0;

            for (int data = 0; data < listaData.Count; data++)
            {
                if (data == 0)
                {
                    dt = dtDatos.NewRow();
                    NuevoLinea = true;
                    CodPartidaPresu = listaData[data].CodPartidaPresu;

                    dt["Codigo"] = listaData[data].CodPartidaPresu;
                    dt["Descripcion"] = listaData[data].desPartidaPresu;

                    contador++;
                }

                if (data > 0)
                {
                    if (CodPartidaPresu != listaData[data].CodPartidaPresu)
                    {
                        dt = dtDatos.NewRow();
                        NuevoLinea = true;
                        CodPartidaPresu = listaData[data].CodPartidaPresu;

                        dt["Codigo"] = listaData[data].CodPartidaPresu;
                        dt["Descripcion"] = listaData[data].desPartidaPresu;

                        contador++;
                    }
                    else
                    {
                        NuevoLinea = false;
                    }
                }

                if (NuevoLinea)
                {
                    decimal? Total = 0;

                    for (int i = 0; i < listaCabe.Count; i++)
                    {
                        string mes = listaCabe[i].MesPeriodo;
                        List<ProvisionesE> item;
                        string NombreColumna = "";

                        NombreColumna = listaCabe[i].AnioPeriodo + " - " + (mes == "00" ? "APERTURA" : (mes == "01" ? "ENERO" : (mes == "02" ? "FEBRERO" : (mes == "03" ? "MARZO" : (mes == "04" ? "ABRIL" : (mes == "05" ? "MAYO" : (mes == "06" ? "JUNIO" : (mes == "07" ? "JULIO" : (mes == "08" ? "AGOSTO" : (mes == "09" ? "SETIEMBRE" : (mes == "10" ? "OCTUBRE" : (mes == "11" ? "NOVIEMBRE" : "DICIEMBRE"))))))))))));

                        item = (from x in oListaPartipaPresu where x.AnioPeriodo == listaCabe[i].AnioPeriodo 
                                    && x.MesPeriodo == listaCabe[i].MesPeriodo && x.CodPartidaPresu == CodPartidaPresu select x).ToList();

                        if (item != null && item.Count > 0)
                        {

                            dt[NombreColumna] = Convert.ToDecimal(item[0].monto).ToString("N2");
                            Total = Convert.ToDecimal(item[0].monto);
                        }
                        else
                            dt[NombreColumna] = 0;
                        
                    }

                    dt["Total"] = Convert.ToDecimal(Total).ToString("N2");

                    dtDatos.Rows.Add(dt);
                }
            }

            lblregistros.Text = " " + contador.ToString() + " Registros";

            // ==========================================

            dgvPivot.DataSource = dtDatos;

            // ==========================================

            dgvPivot.Columns[0].Width = 50;
            dgvPivot.Columns[1].Width = 300;


            //for (int i = 0; i < dgvPivot.Columns.Count; i++)
            //{
            //    if (i <= 1)
            //    {
            //        dgvPivot.Columns[i].DefaultCellStyle.BackColor = Color.Bisque;
            //    }

            //    if (i == 2)
            //    {
            //        dgvPivot.Columns[i].DefaultCellStyle.BackColor = Color.PaleTurquoise;
            //        dgvPivot.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //        dgvPivot.Columns[i].Width = 100;
            //    }

            //    if (i > 2)
            //    {
            //        dgvPivot.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //        dgvPivot.Columns[i].Width = 90;
            //    }
            //}

        }
        
        string columnName = "";

        private void dgvPivot_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            //int idLocal = VariablesLocales.SesionLocal.IdLocal;

            int rowindex = dgvPivot.CurrentCell.RowIndex;
            int columnindex = dgvPivot.CurrentCell.ColumnIndex;
            
            // se valida que sea celda con valor
            if (columnindex >2)
            {
                string codigo = dgvPivot.Rows[rowindex].Cells[0].Value.ToString();
                string desItem = dgvPivot.Rows[rowindex].Cells[1].Value.ToString();
                
                // =========================================================
                
                columnName = dgvPivot.Columns[columnindex].Name;
                
                string mes = (columnName.Contains("ENE") ? "01" : (columnName.Contains("FEB") ? "02" : (columnName.Contains("MAR") ? "03" : (columnName.Contains("ABR") ? "04" : (columnName.Contains("MAY") ? "05" : (columnName.Contains("JUN") ? "06" : (columnName.Contains("JUL") ? "07" : (columnName.Contains("AGO") ? "08" : (columnName.Contains("SET") ? "09" : (columnName.Contains("OCT") ? "10" : (columnName.Contains("NOV") ? "11" : (columnName.Contains("DIC") ? "12" : "00"))))))))))));
                string ano = columnName.Trim().Substring(0, 4);
                // =========================================================

                List<ProvisionesE> oListaDetalle = new List<ProvisionesE>();

                oListaDetalle = AgenteCtasPorPagar.Proxy.ListarPagosPorPartidaPresu(4, codigo,mes,ano);

                // =========================================================

                if (oListaDetalle == null || oListaDetalle.Count == 0)
                {
                    Global.MensajeFault("No hay registros Voucher");
                    return;
                }

                // =========================================================

                //CerrarFormulario("frmReportePartidaPresuDetalle");

                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReportePartidaPresuPagoDetalle);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmReportePartidaPresuPagoDetalle(oListaDetalle, desItem + "  " + columnName);
                oFrm.MdiParent = this.MdiParent;
                oFrm.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ==========================================
            if (oListaPartipaPresu == null || oListaPartipaPresu.Count == 0)
            {
                dgvPivot.DataSource = null;
                lblregistros.Text = "0 registros";
                Global.MensajeFault("No hay registros");
                return;
            }

            //Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReport);

            //if (oFrm != null)
            //{
            //    if (oFrm.WindowState == FormWindowState.Minimized)
            //    {
            //        oFrm.WindowState = FormWindowState.Normal;
            //    }

            //    oFrm.BringToFront();
            //    return;
            //}

            //oFrm = new frmReport(oListaPartipaPresu);
            //oFrm.MdiParent = this.MdiParent;
            //oFrm.Show();
        }

        private void dgvPivot_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.ColumnIndex == 0 || e.ColumnIndex ==1)
            //{
            //    dgvPivot.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = e.CellStyle.BackColor = Color.Bisque;
            //}

            if (e.ColumnIndex == 2 )
            {
                dgvPivot.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = e.CellStyle.BackColor = Color.PaleTurquoise;
            }
            //dgvPivot.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            if (e.ColumnIndex > 1)
            {
                dgvPivot.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            //if (e.RowIndex >= TotalRow - 1)
            //{
            //    dgvListado.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = e.CellStyle.BackColor = Color.Bisque;
            //}
        }
        

    }
}
