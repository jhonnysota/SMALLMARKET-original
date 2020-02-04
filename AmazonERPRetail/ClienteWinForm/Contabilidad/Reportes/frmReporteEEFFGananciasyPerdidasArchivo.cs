using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using OfficeOpenXml;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteEEFFGananciasyPerdidasArchivo : FrmMantenimientoBase
    {
        
        string RutaArchivo="";
        List<ReporteEEFFItemE> oListaDatos;
        

        public frmReporteEEFFGananciasyPerdidasArchivo()
        {
            InitializeComponent();
            //FormatoGrid(dgvListado, false);
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            RutaArchivo = CuadrosDialogo.BuscarArchivo("Buscar Archivo Excel", "Todos los Archivos Excel |*.xlsx");

            lblRuta.Text = " Ruta : " + RutaArchivo;
        }

        // ========================
        // CONSTRUCTOR
        // ========================

        public frmReporteEEFFGananciasyPerdidasArchivo(List<ReporteEEFFItemE> oLista, string Moneda, string desEEFF)
            :this()
        {
            

            lbltitulo.Text = "Item : " + desEEFF + " - " + oLista.Count.ToString()+" registros";

            oListaDatos = oLista;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try{
                    if(txtHoja.Text.Length==0)
                    {
                        Global.MensajeFault("Debe de ingresar el número de hoja");
                        return;
                    }
                    if (Convert.ToInt32(txtHoja.Text) == 0)
                    {
                        Global.MensajeFault("Debe de ingresar número de hoja valido");
                        return;
                    }
                    if (RutaArchivo.Length == 0)
                        {
                            Global.MensajeFault("Debe de seleccionar un archivo");
                            return;
                        }

                    FileInfo oArchivo = new FileInfo(RutaArchivo);

                    if (oArchivo.Exists)
                    {
                        // VALIDAMOS
                        if (oListaDatos==null ||  oListaDatos.Count == 0)
                        {
                            Global.MensajeFault("No hay datos a exportar");
                            return;
                        }
                        // CONVERTIAMOS ARCHIVO 
                        if (oArchivo.Extension == ".xls" || oArchivo.Extension == ".XLS")
                        {
                            //oArchivo = Infraestructura.Global.CambiarExtensionExcel(oArchivo);
                        }

                        using (ExcelPackage oExcel = new ExcelPackage(oArchivo,true))
                        {
                            int NumHoja = Convert.ToInt32(txtHoja.Text);

                            // ============================================================
                            // VALIDAMOS

                            Boolean oExiste=true;

                            foreach (ExcelWorksheet valida in oExcel.Workbook.Worksheets)
                            {
                                if (valida.Index == NumHoja)
                                    oExiste = false;
                            }

                            if (oExiste)
                            {
                                Global.MensajeFault("Hoja indicada no existe en el archivo");
                                return;
                            }
                            // ============================================================


                            //Excel
                            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets[NumHoja];

                            //ExcelRange row = ExcelWorksheet;
                            
                            //Recorriendo la hoja excel hasta el total de fila obtenido...
                            for (int f = 0; f < oListaDatos.Count ; f++)
                            {
                                if (oListaDatos[f].fila > 0 && oListaDatos[f].columna > 0)
                                {
                                    oHoja.Cells[oListaDatos[f].fila, oListaDatos[f].columna].Value = oListaDatos[f].saldo_sol;
                                    oHoja.Cells[oListaDatos[f].fila, oListaDatos[f].columna].Style.Numberformat.Format = "###,###0.00";
                                }
                            }

                            if (!String.IsNullOrEmpty(RutaArchivo))
                            {
                                Byte[] bin = oExcel.GetAsByteArray();
                                File.WriteAllBytes(RutaArchivo, bin);
                           
                            }
                        }

                        Global.MensajeComunicacion("Se guardaron los registros con exito");
                        this.Close();
                }
            }
            catch (Exception ex)
            {
                Infraestructura.Global.MensajeError(ex.Message);
            }
        }

        private void frmReporteEEFFGananciasyPerdidasArchivo_Load(object sender, EventArgs e)
        {
            Grid = true;

            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
        }    
    }
}
