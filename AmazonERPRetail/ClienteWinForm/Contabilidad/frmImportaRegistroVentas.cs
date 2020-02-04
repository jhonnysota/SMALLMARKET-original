using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

#region Para Excel

using OfficeOpenXml;

#endregion

namespace ClienteWinForm.Contabilidad
{
    public partial class frmImportaRegistroVentas : FrmMantenimientoBase
    {

        public frmImportaRegistroVentas()
        {
            Infraestructura.Global.AjustarResolucion(this);
            InitializeComponent();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<RegistroVentasE> oListaRegistroVentas = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        Int32 LineaError = Variables.Cero;
        String Tipo = String.Empty;
        String Marquee = String.Empty;
        Int32 letra = 0;

        Int32 Registros = Variables.Cero;

        #endregion

        #region Procedimientos de Usuario

        void ImportarExcel(String Ruta)
        {
            FileInfo oFi_ = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(oFi_))
            {
                //Entidad
                RegistroVentasE oRegistroVenta = null;
                //Para el correlativo
                Int32 numCorrelativo = Variables.ValorUno;
                //Excel
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets[1];
                //Para el recorrido del excel
                Int32 totFilasExcel = oHoja.Dimension.Rows;//oHoja.Dimension.End.Row;

                //Recorriendo la hoja excel hasta el total de fila obtenido...
                for (int f = 5; f <= totFilasExcel; f++)
                {
                    if (oHoja.Cells[f, 1].Value != null)
                    {
                        LineaError = f;
                        oRegistroVenta = new RegistroVentasE()
                        {
                            idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                            idLocal = VariablesLocales.SesionLocal.IdLocal,
                            Anio = Convert.ToDateTime(oHoja.Cells[f, 2].Value).ToString("yyyy"),
                            Mes = Convert.ToDateTime(oHoja.Cells[f, 2].Value).ToString("MM"),
                            fecDocumento = Convert.ToDateTime(oHoja.Cells[f, 2].Value)
                        };

                        #region Tipo Documento de Venta

                        if (oHoja.Cells[f, 3].Value.ToString() == "BOLETA")
                        {
                            oRegistroVenta.tipDocVenta = "03";
                        }
                        else if (oHoja.Cells[f, 3].Value.ToString() == "NOTA DE CREDITO")
                        {
                            //if (oHoja.Cells[f, 6].Value.ToString().Trim().Length == Variables.NroCaracteresRUC)
                            //{
                                oRegistroVenta.tipDocVenta = "07";
                            //}
                            //else
                            //{
                            //    oRegistroVenta.tipDocVenta = "97";
                            //}
                        }
                        else if (oHoja.Cells[f, 3].Value.ToString().Trim().Substring(0, 7) == "FACTURA")
                        {
                            oRegistroVenta.tipDocVenta = "01";
                        }
                        else
                        {
                            throw new Exception("Tipo de documento no controlado... Revisar el archivo excel...");
                        }

                        #endregion

                        oRegistroVenta.Serie = oHoja.Cells[f, 4].Value.ToString();
                        oRegistroVenta.Numero = oHoja.Cells[f, 5].Value.ToString();
                        oRegistroVenta.idPersona = Variables.Cero;

                        #region Tipo Documento de la Persona

                        if (oRegistroVenta.tipDocVenta == "01") //Factura
                        {
                            if (oHoja.Cells[f, 6].Value.ToString().Trim().Length == Variables.NroCaracteresRUC)
                            {
                                oRegistroVenta.tipDocPersona = "6";
                            }
                            else
                            {
                                oRegistroVenta.tipDocPersona = "0";
                            }
                        }
                        else if (oRegistroVenta.tipDocVenta == "03") //Boletas
                        {
                            oRegistroVenta.tipDocPersona = "7";                            
                        }
                        else //Notas de Crédito
                        {
                            if (oRegistroVenta.Serie.Substring(0, 1) == "F")
                            {
                                if (oHoja.Cells[f, 6].Value.ToString().Trim().Length == Variables.NroCaracteresRUC)
                                {
                                    oRegistroVenta.tipDocPersona = "6";
                                }
                                else
                                {
                                    oRegistroVenta.tipDocPersona = "0";
                                }
                            }
                            else
                            {
                                oRegistroVenta.tipDocPersona = "7";
                            }
                        }

                        #endregion

                        #region Numero de Documento de la Persona

                        //if (oRegistroVenta.tipDocPersona == "6")
                        //{
                        //    oRegistroVenta.numDocPersona = oHoja.Cells[f, 6].Value.ToString();

                        //    if (!Infraestructura.Global.EsNumero(oRegistroVenta.numDocPersona))
                        //    {
                        //        throw new Exception(String.Format("El número de RUC {0} esta errado", oRegistroVenta.numDocPersona));
                        //    }

                        //    if (oRegistroVenta.numDocPersona.Trim().Length != Variables.NroCaracteresRUC)
                        //    {
                        //        throw new Exception(String.Format("El número de RUC {0} debe tener 11 digitos", oRegistroVenta.numDocPersona));
                        //    }
                        //}
                        //else
                        //{
                        //    oRegistroVenta.numDocPersona = oHoja.Cells[f, 26].Value.ToString();
                        //}

                        if (oRegistroVenta.tipDocVenta == "07")
                        {
                            oRegistroVenta.numDocPersona = oHoja.Cells[f, 6].Value.ToString();
                            oRegistroVenta.RazonSocial = oHoja.Cells[f, 7].Value.ToString();
                        }
                        else
                        {
                            if (oHoja.Cells[f, 36].Value == null)
                            {
                                if (oRegistroVenta.tipDocPersona == "6")
                                {
                                    oRegistroVenta.numDocPersona = oHoja.Cells[f, 6].Value.ToString();

                                    if (!Infraestructura.Global.EsNumero(oRegistroVenta.numDocPersona))
                                    {
                                        throw new Exception(String.Format("El número de RUC {0} esta errado", oRegistroVenta.numDocPersona));
                                    }

                                    if (oRegistroVenta.numDocPersona.Trim().Length != Variables.NroCaracteresRUC)
                                    {
                                        throw new Exception(String.Format("El número de RUC {0} debe tener 11 digitos", oRegistroVenta.numDocPersona));
                                    }

                                    oRegistroVenta.RazonSocial = oHoja.Cells[f, 7].Value.ToString();
                                }
                                else
                                {
                                    oRegistroVenta.numDocPersona = oHoja.Cells[f, 6].Value.ToString();
                                    oRegistroVenta.RazonSocial = oHoja.Cells[f, 7].Value.ToString();
                                }
                            }
                            else
                            {
                                if (oHoja.Cells[f, 6].Value.ToString() == "A")
                                {
                                    oRegistroVenta.numDocPersona = oHoja.Cells[f, 6].Value.ToString();
                                    oRegistroVenta.RazonSocial = oHoja.Cells[f, 7].Value.ToString();
                                }
                            }                            
                        }

                        #endregion Numero de Documento de la Persona

                        #region Montos

                        oRegistroVenta.idMoneda = oHoja.Cells[f, 18].Value.ToString(); //Moneda
                        oRegistroVenta.Tica = Convert.ToDecimal(oHoja.Cells[f, 19].Value);

                        if (oHoja.Cells[f, 12].Value != null)
                        {
                            if (oHoja.Cells[f, 12].Value.ToString() == "T598" || oHoja.Cells[f, 12].Value.ToString() == "T599")
                            {
                                oRegistroVenta.BaseExportacion = Variables.ValorCeroDecimal;
                                oRegistroVenta.BaseInafecta = Variables.ValorCeroDecimal;
                                oRegistroVenta.BaseImponible = Convert.ToDecimal(oHoja.Cells[f, 21].Value);

                                if (oRegistroVenta.BaseImponible == 0M)
                                {
                                    oRegistroVenta.BaseImponible = Convert.ToDecimal(oHoja.Cells[f, 20].Value);
                                }

                                if (oRegistroVenta.idMoneda == Variables.Dolares)
                                {
                                    oRegistroVenta.Total = Convert.ToDecimal(oHoja.Cells[f, 24].Value);
                                }
                                else
                                {
                                    oRegistroVenta.Total = Convert.ToDecimal(oHoja.Cells[f, 23].Value);
                                }

                                oRegistroVenta.Igv = Convert.ToDecimal(oHoja.Cells[f, 22].Value);
                            }
                            else
                            {
                                if (oRegistroVenta.idMoneda == Variables.Dolares)
                                {
                                    oRegistroVenta.BaseExportacion = Convert.ToDecimal(oHoja.Cells[f, 24].Value);
                                    oRegistroVenta.Total = Convert.ToDecimal(oHoja.Cells[f, 24].Value);
                                }
                                else
                                {
                                    oRegistroVenta.BaseExportacion = Convert.ToDecimal(oHoja.Cells[f, 23].Value);
                                    oRegistroVenta.Total = Convert.ToDecimal(oHoja.Cells[f, 23].Value);
                                }
                                
                                oRegistroVenta.BaseInafecta = Variables.ValorCeroDecimal;
                                oRegistroVenta.BaseImponible = Variables.ValorCeroDecimal;
                                oRegistroVenta.Igv = Variables.ValorCeroDecimal;                                
                            }
                        }
                        else
                        {
                            if (oRegistroVenta.idMoneda == Variables.Dolares)
                            {
                                oRegistroVenta.BaseExportacion = Convert.ToDecimal(oHoja.Cells[f, 24].Value);
                                oRegistroVenta.Total = Convert.ToDecimal(oHoja.Cells[f, 24].Value);
                            }
                            else
                            {
                                oRegistroVenta.BaseExportacion = Convert.ToDecimal(oHoja.Cells[f, 23].Value);
                                oRegistroVenta.Total = Convert.ToDecimal(oHoja.Cells[f, 23].Value);
                            }

                            oRegistroVenta.BaseInafecta = Variables.ValorCeroDecimal;
                            oRegistroVenta.BaseImponible = Variables.ValorCeroDecimal;
                            oRegistroVenta.Igv = Variables.ValorCeroDecimal;
                        }

                        #endregion

                        #region Documento de referencia

                        if (oRegistroVenta.tipDocVenta == "07")
                        {
                            if (oHoja.Cells[f, 27].Value.ToString() == "BOLETA")
                            {
                                oRegistroVenta.tipDocVentaRef = "03";
                            }
                            else if (oHoja.Cells[f, 27].Value.ToString().Trim().Substring(0, 7) == "FACTURA")
                            {
                                oRegistroVenta.tipDocVentaRef = "01";
                            }
                            else
                            {
                                throw new Exception("Tipo de documento no controlado... Revisar el archivo excel...");
                            }

                            oRegistroVenta.SerieRef = oHoja.Cells[f, 28].Value.ToString();
                            oRegistroVenta.NumeroRef = oHoja.Cells[f, 29].Value.ToString();
                            oRegistroVenta.FechaRef = Convert.ToDateTime(oHoja.Cells[f, 30].Value);
                        }
                        else
                        {
                            oRegistroVenta.tipDocVentaRef = String.Empty;
                            oRegistroVenta.SerieRef = String.Empty;
                            oRegistroVenta.NumeroRef = String.Empty;
                            oRegistroVenta.FechaRef = (Nullable<DateTime>)null;
                        }

                        #endregion

                        oRegistroVenta.Percepcion = Variables.ValorCeroDecimal;

                        #region Saber si lleva IGV

                        if (oHoja.Cells[f, 11].Value != null)
                        {
                            if (oHoja.Cells[f, 11].Value.ToString() == "T598" || oHoja.Cells[f, 11].Value.ToString() == "T599")
                            {
                                oRegistroVenta.csIgv = true;
                            }
                            else
                            {
                                oRegistroVenta.csIgv = false;
                            }
                        }
                        else
                        {
                            oRegistroVenta.csIgv = false;
                        } 

                        #endregion

                        oRegistroVenta.Correlativo = String.Format("{0:0000000000}", numCorrelativo);
                        oRegistroVenta.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        oRegistroVenta.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        
                        oListaRegistroVentas.Add(oRegistroVenta);
                        numCorrelativo++;
                        lblProcesando.Text = String.Format("Importando de Excel: Linea {0}", f);
                    }
                }
            }
        }

        #endregion

        #region Eventos de Usuario

        void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (Tipo == "I")
                {
                    ImportarExcel(txtRuta.Text);    
                }
                else if(Tipo == "P")
                {
                    if (oListaRegistroVentas.Count > Variables.Cero)
                    {
                        Int32 TotalReg = oListaRegistroVentas.Count;
                        Int32 cantReg = TotalReg / 10;
                        Int32 Residuo = TotalReg % 10;
                        DateTime fecInicial = Convert.ToDateTime((from mx in oListaRegistroVentas
                                                                  select (DateTime?)mx.fecDocumento).Min());
                        DateTime fecFinal = Convert.ToDateTime((from mx in oListaRegistroVentas
                                                                select (DateTime?)mx.fecDocumento).Max());

                        for (int conta = 0; conta <= 10; conta++)
                        {
                            List<RegistroVentasE> oListaTemporal = new List<RegistroVentasE>();

                            if (Residuo == oListaRegistroVentas.Count)
                            {
                                for (int i = 0; i < Residuo; i++)
                                {
                                    oListaTemporal.Add(oListaRegistroVentas[i]);
                                }
                            }
                            else
                            {
                                for (int i = 0; i < cantReg; i++)
                                {
                                    oListaTemporal.Add(oListaRegistroVentas[i]);
                                }
                            }

                            foreach (RegistroVentasE item in oListaTemporal)
                            {
                                oListaRegistroVentas.Remove(item);
                            }

                            if (conta == 0)
                            {
                                Registros = AgenteContabilidad.Proxy.InsertarRegistroVentasPorVolumen(oListaTemporal, fecInicial, fecFinal, true);
                            }
                            else
                            {
                                Registros = AgenteContabilidad.Proxy.InsertarRegistroVentasPorVolumen(oListaTemporal, fecInicial, fecFinal, false);
                            }
                            
                            lblCantidad.Text = "Total Reg. " + TotalReg.ToString() + " Faltan " + oListaRegistroVentas.Count.ToString();
                            oListaTemporal = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oListaRegistroVentas = null;
                throw new Exception(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            Cursor = System.Windows.Forms.Cursors.Arrow;

            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else
            {
                if (Tipo == "I")
                {
                    if (oListaRegistroVentas != null)
                    {
                        btProcesar.Enabled = true;
                        btActualizar.Enabled = false;
                        lblProcesando.Text = String.Empty;
                        lblProcesando.Visible = false;
                        btExaminar.Enabled = true;
                        Infraestructura.Global.MensajeComunicacion(String.Format("Se importaron {0} registros", oListaRegistroVentas.Count));
                    }
                    else
                    {
                        lblProcesando.Text = String.Empty;
                        btActualizar.Enabled = true;
                        btExaminar.Enabled = false;
                        lblProcesando.Text = String.Format("Ha ocurrido un error en la Hoja Excel en la linea {0}. Revise por favor.", LineaError);
                    }
                }
                else if (Tipo == "P")
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
            }
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
                    oListaRegistroVentas = new List<RegistroVentasE>();
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
