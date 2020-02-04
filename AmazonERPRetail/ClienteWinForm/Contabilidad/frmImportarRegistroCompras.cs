﻿using System;
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
using Infraestructura.Winform;

#region Para Excel

//using OfficeOpenXml;
//using OfficeOpenXml.Style;
//using System.Diagnostics;
////using Microsoft.Office.Interop.Excel;
//using System.IO;

#endregion

namespace ClienteWinForm.Contabilidad
{
    public partial class frmImportaRegistroCompras : FrmMantenimientoBase
    {
        public frmImportaRegistroCompras()
        {
            InitializeComponent();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<RegistroComprasE> oListaRegistroCompras = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        Int32 LineaError = Variables.Cero;
        String Tipo = String.Empty;
        String Marquee = String.Empty;
        Int32 letra = 0;

        Int32 Registros = Variables.Cero;

        #endregion

        #region Procedimientos de Usuario

        //void ImportarExcel(String Ruta)
        //{
        //    FileInfo oFi_ = new FileInfo(Ruta);

        //    using (ExcelPackage oExcel = new ExcelPackage(oFi_))
        //    {
        //        //Entidad
        //        RegistroVentasE oRegistroCompras = null;
        //        //Para el correlativo
        //        Int32 numCorrelativo = Variables.ValorUno;
        //        //Excel
        //        ExcelWorksheet oHoja = oExcel.Workbook.Worksheets[1];
        //        //Para el recorrido del excel
        //        Int32 totFilasExcel = oHoja.Dimension.Rows;//oHoja.Dimension.End.Row;

        //        //Recorriendo la hoja excel hasta el total de fila obtenido...
        //        for (int f = 5; f <= totFilasExcel; f++)
        //        {
        //            if (oHoja.Cells[f, 1].Value != null)
        //            {
        //                LineaError = f;
        //                oRegistroVenta = new RegistroVentasE();

        //                oRegistroVenta.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
        //                oRegistroVenta.idLocal = VariablesLocales.SesionLocal.IdLocal;
        //                oRegistroVenta.Anio = Convert.ToDateTime(oHoja.Cells[f, 1].Value).ToString("yyyy");
        //                oRegistroVenta.Mes = Convert.ToDateTime(oHoja.Cells[f, 1].Value).ToString("MM");
        //                oRegistroVenta.fecDocumento = Convert.ToDateTime(oHoja.Cells[f, 1].Value);

        //                #region Tipo Documento de Venta

        //                if (oHoja.Cells[f, 2].Value.ToString() == "BOLETA")
        //                {
        //                    oRegistroVenta.tipDocVenta = "03";
        //                }
        //                else if (oHoja.Cells[f, 2].Value.ToString() == "NOTA DE CREDITO")
        //                {
        //                    oRegistroVenta.tipDocVenta = "07";
        //                }
        //                else if (oHoja.Cells[f, 2].Value.ToString().Trim().Substring(0, 7) == "FACTURA")
        //                {
        //                    oRegistroVenta.tipDocVenta = "01";
        //                }
        //                else
        //                {
        //                    throw new Exception("Tipo de documento no controlado... Revisar el archivo excel...");
        //                }

        //                #endregion

        //                oRegistroVenta.Serie = oHoja.Cells[f, 3].Value.ToString();
        //                oRegistroVenta.Numero = oHoja.Cells[f, 4].Value.ToString();
        //                oRegistroVenta.idPersona = Variables.ValorCero;

        //                #region Tipo Documento de la Persona

        //                if (oRegistroVenta.tipDocVenta == "01") //Factura
        //                {
        //                    oRegistroVenta.tipDocPersona = "6";
        //                }
        //                else if (oRegistroVenta.tipDocVenta == "03") //Boletas
        //                {
        //                    if (oHoja.Cells[f, 6].Value.ToString() == "PASAJERO" && oHoja.Cells[f, 24].Value.ToString() == "999999")
        //                    {
        //                        oRegistroVenta.tipDocPersona = "0";
        //                    }
        //                    else
        //                    {
        //                        oRegistroVenta.tipDocPersona = "7";
        //                    }
        //                }
        //                else //Notas de Crédito
        //                {
        //                    if (oRegistroVenta.Serie.Substring(0, 1) == "F")
        //                    {
        //                        oRegistroVenta.tipDocPersona = "6";
        //                    }
        //                    else
        //                    {
        //                        if (oHoja.Cells[f, 6].Value.ToString() == "PASAJERO" && oHoja.Cells[f, 24].Value.ToString() == "999999")
        //                        {
        //                            oRegistroVenta.tipDocPersona = "0";
        //                        }
        //                        else
        //                        {
        //                            oRegistroVenta.tipDocPersona = "7";
        //                        }
        //                    }
        //                }

        //                #endregion

        //                #region Numero de Documento de la Persona

        //                if (oRegistroVenta.tipDocPersona == "6")
        //                {
        //                    oRegistroVenta.numDocPersona = oHoja.Cells[f, 5].Value.ToString();

        //                    if (!Infraestructura.Global.EsNumero(oRegistroVenta.numDocPersona))
        //                    {
        //                        throw new Exception(String.Format("El número de RUC {0} esta errado", oRegistroVenta.numDocPersona));
        //                    }

        //                    if (oRegistroVenta.numDocPersona.Trim().Length != Variables.NroCaracteresRUC)
        //                    {
        //                        throw new Exception(String.Format("El número de RUC {0} debe tener 11 digitos", oRegistroVenta.numDocPersona));
        //                    }
        //                }
        //                else
        //                {
        //                    oRegistroVenta.numDocPersona = oHoja.Cells[f, 24].Value.ToString();
        //                }

        //                #endregion

        //                oRegistroVenta.RazonSocial = oHoja.Cells[f, 6].Value.ToString();

        //                #region Montos

        //                if (oHoja.Cells[f, 11].Value != null)
        //                {
        //                    if (oHoja.Cells[f, 11].Value.ToString() == "T656")
        //                    {
        //                        oRegistroVenta.BaseExportacion = Variables.ValorCeroDecimal;
        //                        oRegistroVenta.BaseInafecta = Variables.ValorCeroDecimal;
        //                        oRegistroVenta.BaseImponible = Convert.ToDecimal(oHoja.Cells[f, 19].Value);
        //                        oRegistroVenta.Igv = Convert.ToDecimal(oHoja.Cells[f, 21].Value);
        //                        oRegistroVenta.Total = Convert.ToDecimal(oHoja.Cells[f, 22].Value);
        //                    }
        //                    else
        //                    {
        //                        oRegistroVenta.BaseExportacion = Convert.ToDecimal(oHoja.Cells[f, 19].Value);
        //                        oRegistroVenta.BaseInafecta = Variables.ValorCeroDecimal;
        //                        oRegistroVenta.BaseImponible = Variables.ValorCeroDecimal;
        //                        oRegistroVenta.Igv = Variables.ValorCeroDecimal;
        //                        oRegistroVenta.Total = Convert.ToDecimal(oHoja.Cells[f, 22].Value);
        //                    } 
        //                }
        //                else
        //                {
        //                    oRegistroVenta.BaseExportacion = Convert.ToDecimal(oHoja.Cells[f, 19].Value);
        //                    oRegistroVenta.BaseInafecta = Variables.ValorCeroDecimal;
        //                    oRegistroVenta.BaseImponible = Variables.ValorCeroDecimal;
        //                    oRegistroVenta.Igv = Variables.ValorCeroDecimal;
        //                    oRegistroVenta.Total = Convert.ToDecimal(oHoja.Cells[f, 22].Value);
        //                }

        //                oRegistroVenta.Tica = Convert.ToDecimal(oHoja.Cells[f, 18].Value);

        //                #endregion

        //                #region Documento de referencia

        //                if (oRegistroVenta.tipDocVenta == "07")
        //                {
        //                    if (oHoja.Cells[f, 25].Value.ToString() == "BOLETA")
        //                    {
        //                        oRegistroVenta.tipDocVentaRef = "03";
        //                    }
        //                    else if (oHoja.Cells[f, 25].Value.ToString().Trim().Substring(0, 7) == "FACTURA")
        //                    {
        //                        oRegistroVenta.tipDocVentaRef = "01";
        //                    }
        //                    else
        //                    {
        //                        throw new Exception("Tipo de documento no controlado... Revisar el archivo excel...");
        //                    }

        //                    oRegistroVenta.SerieRef = oHoja.Cells[f, 26].Value.ToString();
        //                    oRegistroVenta.NumeroRef = oHoja.Cells[f, 27].Value.ToString();
        //                    oRegistroVenta.FechaRef = Convert.ToDateTime(oHoja.Cells[f, 28].Value);
        //                }
        //                else
        //                {
        //                    oRegistroVenta.tipDocVentaRef = String.Empty;
        //                    oRegistroVenta.SerieRef = String.Empty;
        //                    oRegistroVenta.NumeroRef = String.Empty;
        //                    oRegistroVenta.FechaRef = (Nullable<DateTime>)null;
        //                }

        //                #endregion

        //                oRegistroVenta.Percepcion = Variables.ValorCeroDecimal;

        //                #region Saber si lleva IGV

        //                if (oHoja.Cells[f, 11].Value != null)
        //                {
        //                    if (oHoja.Cells[f, 11].Value.ToString() == "T656")
        //                    {
        //                        oRegistroVenta.csIgv = true;
        //                    }
        //                    else
        //                    {
        //                        oRegistroVenta.csIgv = false;
        //                    }
        //                }
        //                else
        //                {
        //                    oRegistroVenta.csIgv = false;
        //                } 

        //                #endregion

        //                oRegistroVenta.Correlativo = String.Format("{0:0000000000}", numCorrelativo);
        //                oRegistroVenta.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        
        //                oListaRegistroVentas.Add(oRegistroVenta);
        //                numCorrelativo++;
        //                lblProcesando.Text = String.Format("Importando de Excel: Linea {0}", f);
        //            }
        //        }
        //    }
        //}

        #endregion

        #region Eventos de Usuario

        void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (Tipo == "I")
                {
                    //ImportarExcel(txtRuta.Text);    
                }
                else if(Tipo == "P")
                {
                    if (oListaRegistroCompras.Count > Variables.Cero)
                    {
            //            Registros = AgenteContabilidad.Proxy.InsertarRegistroVentasPorVolumen(oListaRegistroCompras);
                    }
                }
            }
            catch (Exception ex)
            {
                oListaRegistroCompras = null;
                Infraestructura.Global.MensajeError(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            Cursor = System.Windows.Forms.Cursors.Arrow;

            if (Tipo == "I")
            {
                if (oListaRegistroCompras != null)
                {
                    btProcesar.Enabled = true;
                    btActualizar.Enabled = false;
                    lblProcesando.Text = String.Empty;
                    lblProcesando.Visible = false;
                    btExaminar.Enabled = true;
                    Infraestructura.Global.MensajeComunicacion(String.Format("Se importaron {0} registros", oListaRegistroCompras.Count));
                }
                else
                {
                    lblProcesando.Text = String.Empty;
                    btActualizar.Enabled = true;
                    btExaminar.Enabled = false;
                    lblProcesando.Text = String.Format("Ha ocurrido un error en la Hoja Excel en la linea {0}. Revise por favor.", LineaError);
                }
            }
            else if(Tipo == "P")
            {
                if (Registros > Variables.Cero)
                {
                    btExaminar.Enabled = true;
                    btProcesar.Enabled = false;
                    txtRuta.Text = String.Empty;
                    timer1.Enabled = false;
                    lblProcesando.Visible = false;
                    letra = Variables.Cero;

                    Infraestructura.Global.MensajeComunicacion("Los registros se ingresaron correctamente");
                }
                else
                {
                    btExaminar.Enabled = false;
                    btProcesar.Enabled = true;
                    txtRuta.Text = String.Empty;
                    timer1.Enabled = false;
                    lblProcesando.Visible = false;
                    lblProcesando.Text = String.Empty;
                    letra = Variables.Cero;                    
                }
            }

            _bw.CancelAsync();
            _bw.Dispose();
        }

        #endregion

        #region Eventos
        
        private void frmImportaRegistroVentas_Load(object sender, EventArgs e)
        {
            Grid = false;
            CheckForIllegalCrossThreadCalls = false;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
        }

        private void btExaminar_Click(object sender, EventArgs e)
        {
            try
            {
                txtRuta.Text = CuadrosDialogo.BuscarArchivo("Buscar Archivo Excel", "Archivos Excel (.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(txtRuta.Text))
                {
                    btExaminar.Enabled = false;
                    btActualizar.Enabled = true;
                }
                else
                {
                    btExaminar.Enabled = true;
                    btActualizar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Infraestructura.Global.MensajeError(ex.Message);
            }
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuta.Text))
                {
                    oListaRegistroCompras = new List<RegistroComprasE>();
                    btActualizar.Enabled = false;
                    btProcesar.Enabled = false;
                    btExaminar.Enabled = false;
                    lblProcesando.Visible = true;
                    Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    pbProgress.Visible = true;
                    lblProcesando.Text = "Preparando el archivo excel para su importación...";
                    Tipo = "I";

                    _bw.RunWorkerAsync();
                }
                else
                {
                    Infraestructura.Global.MensajeFault("Tiene que buscar un archivo");
                }
            }
            catch (Exception ex)
            {
                if (_bw.IsBusy)
                {
                    _bw.CancelAsync();
                    _bw.Dispose();
                }

                Infraestructura.Global.MensajeError(ex.Message);
            }
        }

        private void btProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                lblProcesando.Text = String.Empty;
                Marquee = "Ingresando la información a la Base de Datos...";
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                btActualizar.Enabled = false;
                btProcesar.Enabled = false;
                btExaminar.Enabled = false;
                timer1.Enabled = true;
                lblProcesando.Visible = true;
                pbProgress.Visible = true;
                Tipo = "P";

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                if (_bw.IsBusy)
                {
                    _bw.CancelAsync();
                    _bw.Dispose();
                }

                Infraestructura.Global.MensajeError(ex.Message);
            }
        } 

        private void timer1_Tick(object sender, EventArgs e)
        {
            letra += 1;
            if (letra == Marquee.Length)
            {
                lblProcesando.Text = String.Empty;
                letra = 0;
            }
            else
            {
                lblProcesando.Text += Marquee.Substring(letra - 1, 1);
            }
        }

        #endregion

    }
}