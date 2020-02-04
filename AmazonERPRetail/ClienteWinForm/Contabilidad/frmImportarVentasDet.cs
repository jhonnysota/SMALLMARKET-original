using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using ClienteWinForm.Contabilidad.Reportes;
using ClienteWinForm.Busquedas;

#region Para Excel

using OfficeOpenXml;

#endregion

namespace ClienteWinForm.Contabilidad
{
    public partial class frmImportarVentasDet : FrmMantenimientoBase
    {

        public frmImportarVentasDet()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        String RutaGeneral = String.Empty;
        List<RegVentasDetXLSE> oListaPrincipal = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String Marquee = String.Empty;
        Int32 letra = 0;
        String TipoProceso = String.Empty;
        Int32 errores = 0;
        List<ErrorImportGeneralE> oListaError = null;

        #endregion

        #region Procedimientos de Usuario

        Boolean ImportarExcelGas(String Ruta)
        {
            int Inicio = 9;
            Int32 FilaError = 0;
            Int32 Columna = 0;
            FileInfo oFi_ = new FileInfo(Ruta);
            Decimal porIgv = VariablesLocales.oListaImpuestos[0].Porcentaje;
            Double numDouble = 0;

            try
            {
                using (ExcelPackage oExcel = new ExcelPackage(oFi_))
                {
                    //Entidad
                    RegVentasDetXLSE oRegistro = null;
                    oListaPrincipal = new List<RegVentasDetXLSE>();

                    //Excel
                    ExcelWorksheet oHoja = oExcel.Workbook.Worksheets[1];

                    //Para el recorrido del excel
                    Int32 totFilas = oHoja.Dimension.Rows;

                    //Recorriendo la hoja excel hasta el total de fila obtenido...
                    for (int f = Inicio; f <= totFilas; f++)
                    {
                        if (oHoja.Cells[f, 1].Value == null)
                        {
                            if ((oHoja.Cells[f, 2].Value).ToString().Trim().Length > 0 && oHoja.Cells[f, 8].Value != null)
                            {
                                if (oHoja.Cells[f, 8].Value.ToString() != "Venta Credito")
                                {

                                    oRegistro = new RegVentasDetXLSE();
                                    oRegistro.Linea = FilaError = f;
                                    oRegistro.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                                    oRegistro.idLocal = VariablesLocales.SesionLocal.IdLocal;
                                    oRegistro.idUsuario = VariablesLocales.SesionUsuario.IdPersona;
                                    oRegistro.idCCostos = txtCCostos.Text.Trim();

                                    Columna = 3; //FECHA DESPACHO
                                    if (oHoja.Cells[f, 3].Value != null)
                                    {
                                        double FechaTipoDouble = Convert.ToDouble(oHoja.Cells[f, 3].Value);
                                        DateTime Fecha = DateTime.FromOADate(FechaTipoDouble);
                                        oRegistro.FechaReal = Fecha;
                                    }

                                    Columna = 6;//FECHA TURNO
                                    if (oHoja.Cells[f, 6].Value != null)
                                    {
                                        oRegistro.FechaTurno = Convert.ToDateTime(oHoja.Cells[f, 6].Value);
                                    }

                                    Columna = 7; //Ruc
                                    if (oHoja.Cells[f, 7].Value != null)
                                    {
                                        oRegistro.Ruc = Global.DejarSoloUnEspacio((oHoja.Cells[f, 7].Value).ToString().Trim());
                                        oRegistro.RazonSocial = String.Empty;

                                        if (String.IsNullOrWhiteSpace(oRegistro.Ruc))
                                        {
                                            oRegistro.Ruc = VariablesLocales.oVenParametros.RUC;
                                            oRegistro.RazonSocial = VariablesLocales.oVenParametros.RazonSocial;
                                        }
                                    }
                                    else
                                    {
                                        oRegistro.Ruc = VariablesLocales.oVenParametros.RUC;
                                        oRegistro.RazonSocial = VariablesLocales.oVenParametros.RazonSocial;
                                    }

                                    Columna = 8; //Tipo de comprobante
                                    if (oHoja.Cells[f, 8].Value != null)
                                    {
                                        String Documento = (oHoja.Cells[f, 8].Value).ToString().Trim();

                                        //if (Documento.ToUpper().Contains("BOLE"))
                                        //{
                                        //    oRegistro.idDocumento = "BV";
                                        //}
                                        //else if (Documento.ToUpper().Contains("FACT"))
                                        //{
                                        //    oRegistro.idDocumento = "FV";
                                        //}
                                        //else if (Documento.ToUpper().Contains("12"))
                                        //{
                                        oRegistro.idDocumento = "TK";
                                        //}
                                        //else
                                        //{
                                        //    throw new Exception("Tipo de Documento no ingresado.");
                                        //}
                                    }

                                    Columna = 10; //Serie y número de documento
                                    if (oHoja.Cells[f, 10].Value != null)
                                    {
                                        String Linea = (oHoja.Cells[f, 10].Value).ToString();
                                        List<String> oListaDocumentos = new List<string>(Linea.Split(' '));

                                        if (oListaDocumentos.Count == 2)
                                        {
                                            oRegistro.numSerie = Global.Derecha("0000" + oListaDocumentos[0].Trim(), 4);
                                            oRegistro.numDocumentoIni = Global.Derecha("00000000" + oListaDocumentos[1].Trim(), 8);
                                        }
                                    }

                                    Columna = 11; //Placa
                                    if (oHoja.Cells[f, 11].Value != null)
                                    {
                                        oRegistro.Placa = (oHoja.Cells[f, 8].Value).ToString().Trim();
                                    }

                                    Columna = 17; //Cantidad
                                    if (oHoja.Cells[f, 17].Value != null)
                                    {
                                        numDouble = Convert.ToDouble(oHoja.Cells[f, 17].Value);
                                        oRegistro.Cantidad = Convert.ToDecimal(numDouble);
                                    }

                                    Columna = 19; //Descuento
                                    Decimal Descuento = 0;
                                    if (oHoja.Cells[f, 19].Value != null)
                                    {
                                        numDouble = Convert.ToDouble(oHoja.Cells[f, 19].Value);
                                        Descuento = Convert.ToDecimal(numDouble);
                                    }

                                    Columna = 21; //Recaudo
                                    if (oHoja.Cells[f, 21].Value != null)
                                    {
                                        numDouble = Convert.ToDouble(oHoja.Cells[f, 21].Value);
                                        oRegistro.Recaudo = Convert.ToDecimal(numDouble);
                                    }

                                    Columna = 22; //Total Venta
                                    Decimal Total = 0;
                                    Decimal Igv = 0;
                                    Decimal BaseImp = 0;

                                    if (oHoja.Cells[f, 22].Value != null)
                                    {
                                        numDouble = Convert.ToDouble(oHoja.Cells[f, 22].Value);
                                        oRegistro.Total = Total = Convert.ToDecimal(numDouble) - Descuento;
                                        BaseImp = Total / ((porIgv/100) + 1);
                                        Igv = Total - BaseImp;

                                        oRegistro.BaseImponible = BaseImp;
                                        oRegistro.Igv = Igv;
                                    }

                                    //Otros Campos
                                    oRegistro.numDocumentoFin = String.Empty;
                                    oRegistro.Producto = "GNV";
                                    oRegistro.RazonSocial = String.Empty;
                                    oRegistro.SerieMaquina = String.Empty;
                                    oRegistro.OpeInafecta = String.Empty;
                                    oRegistro.desUmed = "Galones";
                                    oRegistro.idDocumentoRef = String.Empty;
                                    oRegistro.numSerieRef = String.Empty;
                                    oRegistro.numDocumentoRef = String.Empty;
                                    oRegistro.FechaRef = (DateTime?)null;

                                    oListaPrincipal.Add(oRegistro);
                                }
                            }
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error en la Fila: {0} Columna: {1} Motivo: {2}", FilaError.ToString(), Columna.ToString(), ex.Message));
            }
        }

        Boolean ImportarExcelFull(String Ruta)
        {
            int Inicio = 2;
            Int32 FilaError = 0;
            Int32 Columna = 0;
            FileInfo oFi_ = new FileInfo(Ruta);

            try
            {
                using (ExcelPackage oExcel = new ExcelPackage(oFi_))
                {
                    //Entidad
                    RegVentasDetXLSE oRegistro = null;
                    oListaPrincipal = new List<RegVentasDetXLSE>();

                    //Excel
                    ExcelWorksheet oHoja = oExcel.Workbook.Worksheets[1];

                    //Para el recorrido del excel
                    Int32 totFilas = oHoja.Dimension.Rows;

                    //Recorriendo la hoja excel hasta el total de fila obtenido...
                    for (int f = Inicio; f <= totFilas; f++)
                    {
                        if (oHoja.Cells[f, 1].Value != null)
                        {
                            if ((oHoja.Cells[f, 1].Value).ToString().Trim().Length > 0)
                            {
                                oRegistro = new RegVentasDetXLSE();
                                oRegistro.Linea = FilaError = f;
                                oRegistro.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                                oRegistro.idLocal = VariablesLocales.SesionLocal.IdLocal;
                                oRegistro.idUsuario = VariablesLocales.SesionUsuario.IdPersona;
                                oRegistro.idCCostos = txtCCostos.Text.Trim();

                                Columna = 1; //Fecha Real
                                if (oHoja.Cells[f, 1].Value != null)
                                {
                                    oRegistro.FechaReal = Convert.ToDateTime(oHoja.Cells[f, 1].Value);
                                }

                                Columna = 2;//Fecha Turno
                                if (oHoja.Cells[f, 2].Value != null)
                                {
                                    oRegistro.FechaTurno = Convert.ToDateTime(oHoja.Cells[f, 2].Value);
                                }

                                Columna = 4; //Tipo de comprobante
                                if (oHoja.Cells[f, 4].Value != null)
                                {
                                    oRegistro.idDocumento = (oHoja.Cells[f, 4].Value).ToString().Trim();

                                    if (!String.IsNullOrWhiteSpace(oRegistro.idDocumento))
                                    {
                                        switch (oRegistro.idDocumento)
                                        {
                                            case "01": //Factura
                                                oRegistro.idDocumento = "FV";

                                                break;
                                            case "03": //Boleta
                                                oRegistro.idDocumento = "BV";

                                                break;
                                            case "07": //Nota de Crédito
                                                oRegistro.idDocumento = "NC";

                                                break;
                                            case "08": //Nota de Débito
                                                oRegistro.idDocumento = "ND";

                                                break;
                                            case "12": //Ticket
                                                oRegistro.idDocumento = "TK";

                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }

                                Columna = 5; //Serie
                                if (oHoja.Cells[f, 5].Value != null)
                                {
                                    oRegistro.numSerie = (oHoja.Cells[f, 5].Value).ToString().Trim();
                                    oRegistro.numSerie = Global.Derecha("0000" + oRegistro.numSerie, 4);
                                }

                                Columna = 6; //Producto
                                if (oHoja.Cells[f, 6].Value != null)
                                {
                                    oRegistro.Producto = (oHoja.Cells[f, 6].Value).ToString().Trim();
                                }

                                Columna = 7; //Número Inicial
                                if (oHoja.Cells[f, 7].Value != null)
                                {
                                    oRegistro.numDocumentoIni = Convert.ToString(oHoja.Cells[f, 7].Value);
                                    oRegistro.numDocumentoIni = Global.Derecha("00000000" + oRegistro.numDocumentoIni, 8);
                                }

                                Columna = 8; //Número Final
                                if (oHoja.Cells[f, 8].Value != null)
                                {
                                    oRegistro.numDocumentoFin = (oHoja.Cells[f, 8].Value).ToString().Trim();
                                    oRegistro.numDocumentoFin = Global.Derecha("00000000" + oRegistro.numDocumentoFin, 8);
                                }

                                Columna = 9; //Serie Maquina
                                if (oHoja.Cells[f, 9].Value != null)
                                {
                                    oRegistro.SerieMaquina = (oHoja.Cells[f, 9].Value).ToString().Trim();
                                }

                                Columna = 10; //Ruc
                                if (oHoja.Cells[f, 10].Value != null)
                                {
                                    oRegistro.Ruc = Global.DejarSoloUnEspacio((oHoja.Cells[f, 10].Value).ToString().Trim());

                                    if (oRegistro.Ruc.Substring(0, 3) == "000")
                                    {
                                        oRegistro.Ruc = VariablesLocales.oVenParametros.RUC;
                                    }
                                }

                                Columna = 11; //Razón Social
                                if (oHoja.Cells[f, 11].Value != null)
                                {
                                    oRegistro.RazonSocial = Global.DejarSoloUnEspacio((oHoja.Cells[f, 11].Value).ToString().Trim());

                                    if (oRegistro.Ruc.Substring(0, 3) == "000")
                                    {
                                        oRegistro.RazonSocial = VariablesLocales.oVenParametros.RazonSocial;
                                    }
                                }

                                Columna = 12; //Placa
                                if (oHoja.Cells[f, 12].Value != null)
                                {
                                    oRegistro.Placa = (oHoja.Cells[f, 12].Value).ToString().Trim();
                                }

                                Columna = 13; //Operación Inafecta
                                if (oHoja.Cells[f, 13].Value != null)
                                {
                                    oRegistro.OpeInafecta = (oHoja.Cells[f, 13].Value).ToString().Trim();
                                }

                                Columna = 14; //Base Imponible
                                if (oHoja.Cells[f, 14].Value != null)
                                {
                                    oRegistro.BaseImponible = Convert.ToDecimal(oHoja.Cells[f, 14].Value);
                                }

                                Columna = 15; //Igv
                                if (oHoja.Cells[f, 15].Value != null)
                                {
                                    oRegistro.Igv = Convert.ToDecimal(oHoja.Cells[f, 15].Value);
                                }

                                Columna = 16; //Total Venta
                                if (oHoja.Cells[f, 16].Value != null)
                                {
                                    oRegistro.Total = Convert.ToDecimal(oHoja.Cells[f, 16].Value);
                                }

                                Columna = 17; //Recaudo
                                if (oHoja.Cells[f, 17].Value != null)
                                {
                                    oRegistro.Recaudo = Convert.ToDecimal(oHoja.Cells[f, 17].Value);
                                }

                                Columna = 18; //Cantidad
                                if (oHoja.Cells[f, 18].Value != null)
                                {
                                    oRegistro.Cantidad = Convert.ToDecimal(oHoja.Cells[f, 18].Value);
                                }

                                Columna = 19; //Unidad de Medida
                                if (oHoja.Cells[f, 19].Value != null)
                                {
                                    oRegistro.desUmed = oHoja.Cells[f, 19].Value.ToString();
                                }

                                Columna = 20; //Tipo Comprobante Ref.
                                if (oHoja.Cells[f, 20].Value != null)
                                {
                                    oRegistro.idDocumentoRef = (oHoja.Cells[f, 20].Value).ToString().Trim();

                                    if (!String.IsNullOrWhiteSpace(oRegistro.idDocumentoRef))
                                    {
                                        switch (oRegistro.idDocumentoRef)
                                        {
                                            case "01": //Factura
                                                oRegistro.idDocumentoRef = "FV";

                                                break;
                                            case "03": //Boleta
                                                oRegistro.idDocumentoRef = "BV";

                                                break;
                                            case "07": //Nota de Crédito
                                                oRegistro.idDocumentoRef = "NC";

                                                break;
                                            case "08": //Nota de Débito
                                                oRegistro.idDocumentoRef = "ND";

                                                break;
                                            case "12": //Ticket
                                                oRegistro.idDocumentoRef = "TK";

                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }

                                Columna = 21; //Serie Ref.
                                if (oHoja.Cells[f, 21].Value != null)
                                {
                                    oRegistro.numSerieRef = (oHoja.Cells[f, 21].Value).ToString().Trim();

                                    if (!String.IsNullOrWhiteSpace(oRegistro.numSerieRef))
                                    {
                                        oRegistro.numSerieRef = Global.Derecha("0000" + oRegistro.numSerieRef, 4);
                                    }
                                }

                                Columna = 22; //Número Ref.
                                if (oHoja.Cells[f, 22].Value != null)
                                {
                                    oRegistro.numDocumentoRef = (oHoja.Cells[f, 22].Value).ToString().Trim();

                                    if (!String.IsNullOrWhiteSpace(oRegistro.numDocumentoRef))
                                    {
                                        oRegistro.numDocumentoRef = Global.Derecha("00000000" + oRegistro.numDocumentoRef, 8);
                                    }
                                }

                                Columna = 23; //Fecha Ref.
                                if (String.IsNullOrWhiteSpace(oRegistro.numSerieRef) && String.IsNullOrWhiteSpace(oRegistro.numDocumentoRef))
                                {
                                    oRegistro.FechaRef = (DateTime?)null;
                                }
                                else
                                {
                                    if (oHoja.Cells[f, 23].Value != null)
                                    {
                                        oRegistro.FechaRef = Convert.ToDateTime(oHoja.Cells[f, 23].Text);
                                    }
                                    else
                                    {
                                        oRegistro.FechaRef = (DateTime?)null;
                                    }
                                }

                                oListaPrincipal.Add(oRegistro);
                                //ContadorItem++;
                            }
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error en la Fila: {0} Columna: {1} Motivo: {2}", FilaError.ToString(), Columna.ToString(), ex.Message));
            }
        }

        #endregion

        #region Eventos de Usuario

        void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Int32 Minimo = 0; //Para saber la linea mínima
            Int32 Maximo = 0; //Para saber la linea máxima
            String MensajeErr = String.Empty;

            try
            {
                if (TipoProceso == "P")
                {
                    #region Procesando la Información

                    errores = 0;
                    Int32 TotalReg = Variables.Cero; //Total registros en la lista Principal
                    Int32 TotalTemp = Variables.Cero; //Total registros para poder ir descontando cuantos van quedandos
                    Int32 cantReg = Variables.Cero; //Para saber cuantos registros se van a ir quitando
                    Int32 Residuo = Variables.Cero; //Para saber si sobra registros en caso el total sea impar

                    //Borrando VENTAS por Empresa, Local y Usuario
                    AgenteContabilidad.Proxy.EliminarRegVentasDetXLS(oListaPrincipal[0].idEmpresa, oListaPrincipal[0].idLocal, oListaPrincipal[0].idUsuario);

                    //Empezando el ingreso a VoucherXLS
                    if (oListaPrincipal.Count < 1000)
                    {
                        AgenteContabilidad.Proxy.InsertarRegVentasDetXLS(oListaPrincipal);
                    }
                    else
                    {
                        List<RegVentasDetXLSE> oListaExcel = new List<RegVentasDetXLSE>(oListaPrincipal);
                        TotalReg = TotalTemp = oListaExcel.Count;
                        cantReg = TotalReg / 10;
                        Residuo = TotalReg % 10;

                        for (int conta = 0; conta <= 10; conta++)
                        {
                            List<RegVentasDetXLSE> oListaTemporal = new List<RegVentasDetXLSE>();

                            if (Residuo == oListaExcel.Count)
                            {
                                for (int i = 0; i < Residuo; i++)
                                {
                                    oListaTemporal.Add(oListaExcel[i]);
                                }
                            }
                            else
                            {
                                for (int i = 0; i < cantReg; i++)
                                {
                                    oListaTemporal.Add(oListaExcel[i]);
                                }
                            }

                            foreach (RegVentasDetXLSE itemTemp in oListaTemporal)
                            {
                                oListaExcel.Remove(itemTemp);
                            }

                            if (oListaTemporal.Count > Variables.Cero)
                            {
                                Minimo = Convert.ToInt32(oListaTemporal.Min(x => x.Linea));
                                Maximo = Convert.ToInt32(oListaTemporal.Max(x => x.Linea));
                                MensajeErr = String.Format("Revisar en el rango de lineas de {0} al {1}.", Minimo.ToString(), Maximo.ToString());

                                AgenteContabilidad.Proxy.InsertarRegVentasDetXLS(oListaTemporal);

                                TotalTemp -= oListaTemporal.Count();
                                oListaTemporal = null;
                                lblRegistros.Text = "Total Reg. " + TotalReg.ToString() + " Faltan " + TotalTemp.ToString();
                            }
                        }

                        oListaExcel = null;
                    }

                    //Obteniendo los errores si los hubiere...
                    errores = AgenteContabilidad.Proxy.ErroresRegVentasDetXLS(oListaPrincipal[0].idEmpresa, oListaPrincipal[0].idLocal, oListaPrincipal[0].idUsuario);

                    if (errores > 0)
                    {
                        oListaError = AgenteContabilidad.Proxy.ListarErrorImportGeneral(oListaPrincipal[0].idEmpresa, oListaPrincipal[0].idLocal, oListaPrincipal[0].idUsuario, "VentasDetXLS");
                        throw new Exception(String.Format("El proceso tiene {0} errores. Revise el reporte de Errores.", errores.ToString()));
                    }

                    #endregion
                }
                else if (TipoProceso == "E")
                {
                    #region Importando desde la hoja de Excel

                    if (cboSistema.SelectedIndex == 0)
                    {
                        ImportarExcelFull(RutaGeneral);
                    }
                    else if (cboSistema.SelectedIndex == 1)
                    {
                        ImportarExcelGas(RutaGeneral);
                    }

                    foreach (RegVentasDetXLSE item in oListaPrincipal)
                    {
                        if (item.Ruc.Substring(0, 4) == "9999" || Global.Derecha(item.Ruc, 4) == "0000")
                        {
                            item.idPersona = VariablesLocales.oVenParametros.ClienteVarios;
                        }
                    }
                    //List<CCostosNumControlDetE> oListaCostosSeries = AgenteMaestro.Proxy.ListarCCostosNumControlDet(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtCCostos.Text.Trim());

                    //foreach (CCostosNumControlDetE item in oListaCostosSeries)
                    //{
                    //    foreach (RegVentasDetXLSE itemDet in oListaPrincipal)
                    //    {
                    //        if (item.idDocumento != itemDet.idDocumento && item.Serie != itemDet.numSerie)
                    //        {
                    //            Global.MensajeComunicacion(String.Format("La serie {0} no esta asignada a este C.Costo {1}", item.Serie, item.idCCostos));
                    //            oListaPrincipal = new List<RegVentasDetXLSE>();
                    //            break;
                    //        }
                    //    }
                    //} 

                    #endregion
                }
                else if (TipoProceso == "I")
                {
                    #region Integrando a con_RegistroVentasDet

                    Int32 Reg = AgenteContabilidad.Proxy.IntegrarVentasDetXLS(oListaPrincipal, (cboSistema.SelectedIndex == 0 ? "FUL" : "GAS"), VariablesLocales.SesionUsuario.Credencial); 

                    #endregion
                }

                if (_bw.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                //e.Result = "ok"; 1 - Otro manera de manejar el error... Pasarle ok si todo esta OK
            }
            catch (Exception ex)
            {
                //e.Result = ex.Message; 2 - Asignarle el mensaje de error... Pasarle al result el mensaje de error...
                throw new Exception(MensajeErr + ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btExaminar.Enabled = true;
            btActualizar.Enabled = true;
            btCancelar.Enabled = false;
            pbProgress.Visible = false;
            lblProcesando.Visible = false;
            lblProcesando.Text = String.Empty;
            lblRegistros.Visible = false;
            lblRegistros.Text = String.Empty;
            Marquee = String.Empty;
            letra = 0;
            timer1.Enabled = false;
            Cursor = Cursors.Arrow;

            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));

                if (errores > 0)
                {
                    if (oListaError != null && oListaError.Count > 0)
                    {
                        foreach (ErrorImportGeneralE item in oListaError)
                        {
                            if (item.NombreCampo == "RUC")
                            {
                                btIntegrar.Visible = false;
                                btAuxiliares.Visible = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        btAuxiliares.Visible = false;
                        btIntegrar.Visible = true;
                    }

                    btErrores.Enabled = true;
                }

                btProcesar.Enabled = false;
                btIntegrar.Enabled = false;
            }
            else if (e.Cancelled == true)
            {
                Global.MensajeComunicacion("La operación ha sido cancelada.");
            }
            //else if (e.Result.ToString() != "ok") 3 - Si es diferente de ok mostrar el mensaje de error
            //{
            //    Global.MensajeFault(e.Result.ToString());
            //}
            else
            {
                if (TipoProceso == "P")
                {
                    btProcesar.Enabled = true;
                    btErrores.Enabled = false;
                    btIntegrar.Enabled = true;

                    Global.MensajeComunicacion("El proceso ha concluido correctamente...");
                }
                else if (TipoProceso == "E")
                {
                    btProcesar.Enabled = oListaPrincipal.Count > 0;

                    if (oListaPrincipal.Count > 0)
                    {
                        Global.MensajeComunicacion(String.Format("Se han importado {0} registros de la hoja excel...", oListaPrincipal.Count));
                    }
                }
                else
                {
                    btProcesar.Enabled = false;
                    btErrores.Enabled = false;
                    btIntegrar.Enabled = false;
                    btGenerarVoucher.Enabled = true;
                    Global.MensajeComunicacion("Se han ingresado la venta detallada correctamente...");
                }
            }
        }

        #endregion

        #region Eventos

        private void frmImportarVentasDet_Load(object sender, EventArgs e)
        {
            Grid = false;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btExaminar_Click(object sender, EventArgs e)
        {
            try
            {
                txtRuta.Text = CuadrosDialogo.BuscarArchivo("Buscar Archivo Excel", "Todos los Archivos Excel |*.xlsx;*.xls");

                if (!String.IsNullOrWhiteSpace(txtRuta.Text.Trim()))
                {
                    btActualizar.Enabled = true;
                    FileInfo newFile = new FileInfo(txtRuta.Text.Trim());

                    using (ExcelPackage oExcel = new ExcelPackage(newFile))
                    {
                        using (ExcelWorksheet oHoja = oExcel.Workbook.Worksheets[1])
                        {
                            String tipDoc = String.Empty;
                            String Serie = String.Empty;
                            String CeldaClave = oHoja.Cells[6, 2].Value.ToString().Trim();

                            if (CeldaClave == "GNV")
                            {
                                cboSistema.SelectedIndex = 1;
                                tipDoc = oHoja.Cells[9, 8].Value.ToString().Trim();
                                Serie = oHoja.Cells[9, 10].Value.ToString().Trim().Substring(0, 3);
                             
                                tipDoc = "TK";
                            }
                            else
                            {
                                cboSistema.SelectedIndex = 0;
                                tipDoc = oHoja.Cells[2, 4].Value.ToString().Trim();
                                Serie = oHoja.Cells[2, 5].Value.ToString().Trim();

                                if (tipDoc == "01")
                                {
                                    tipDoc = "FV";
                                }

                                if (tipDoc == "03")
                                {
                                    tipDoc = "BV";
                                }

                                if (tipDoc == "07")
                                {
                                    tipDoc = "NC";
                                }

                                if (tipDoc.ToUpper() == "12")
                                {
                                    tipDoc = "TK";
                                }
                            }

                            Serie = Global.Derecha("0000" + Serie, 4);
                            //Buscando por el serie el centro de costo...
                            CCostosNumControlDetE oDetSerie = AgenteMaestro.Proxy.CCostosNumControlPorSerie(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, tipDoc, Serie);

                            if (oDetSerie != null)
                            {
                                List<NumControlDetE> oListaDocumentos = new List<NumControlDetE>();
                                List<CCostosNumControlDetE> oListaSeries = AgenteMaestro.Proxy.CCostosNumControlPorCC(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, oDetSerie.idCCostos);
                                int Inicio = CeldaClave == "GNV" ? 9 : 2;
                                Int32 totFilas = oHoja.Dimension.Rows;

                                //Recorriendo la hoja excel hasta el total de fila obtenido...
                                for (int f = Inicio; f <= totFilas; f++)
                                {
                                    tipDoc = String.Empty;
                                    Serie = String.Empty;

                                    if (oHoja.Cells[f, 1].Value == null)
                                    {
                                        if (!String.IsNullOrWhiteSpace(oHoja.Cells[f, 2].Value.ToString()))
                                        {
                                            if (CeldaClave == "GNV")
                                            {
                                                tipDoc = oHoja.Cells[f, 8].Value.ToString().Trim();
                                                Serie = oHoja.Cells[f, 10].Value.ToString().Trim().Substring(0, 3);

                                                if (tipDoc == "Venta Credito")
                                                {
                                                    tipDoc = "";
                                                }
                                                else
                                                {
                                                    tipDoc = "TK";
                                                }
                                            } 
                                        }
                                    }
                                    else
                                    {
                                        tipDoc = oHoja.Cells[f, 4].Value.ToString().Trim();
                                        Serie = oHoja.Cells[f, 5].Value.ToString().Trim();

                                        if (tipDoc == "01")
                                        {
                                            tipDoc = "FV";
                                        }

                                        if (tipDoc == "03")
                                        {
                                            tipDoc = "BV";
                                        }

                                        if (tipDoc == "07")
                                        {
                                            tipDoc = "NC";
                                        }

                                        if (tipDoc == "12")
                                        {
                                            tipDoc = "TK";
                                        }
                                    }

                                    if (!String.IsNullOrWhiteSpace(tipDoc) && !String.IsNullOrWhiteSpace(Serie))
                                    {
                                        Serie = Global.Derecha("0000" + Serie, 4);
                                        NumControlDetE Item = new NumControlDetE() { idDocumento = tipDoc, Serie = Serie };
                                        oListaDocumentos.Add(Item); 
                                    }
                                }

                                txtCCostos.Text = oDetSerie.idCCostos;
                                txtDesCCostos.Text = oDetSerie.desCCostos;

                                //Agrupando para revisar
                                var oListaDocTemp = oListaDocumentos.GroupBy(x => x.idDocumento + x.Serie).Select(p => p.First()).ToList();

                                foreach (NumControlDetE item in oListaDocTemp.ToList())
                                {
                                    CCostosNumControlDetE ItemSerie = oListaSeries.Find
                                    (
                                        delegate (CCostosNumControlDetE cd) { return cd.idDocumento + cd.Serie == item.idDocumento + item.Serie; }
                                    );

                                    if (ItemSerie == null)
                                    {
                                        btActualizar.Enabled = false;
                                        Global.MensajeComunicacion(String.Format("La serie {0}-{1} no esta asignada al centro de costo {2}", item.idDocumento, item.Serie, txtDesCCostos.Text));
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Global.MensajeComunicacion(String.Format("La serie {0}-{1} no tiene asignado ningún Centro de Costo.", tipDoc, Serie));
                                txtRuta.Text = String.Empty;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                btActualizar.Enabled = false;
                btExaminar.Enabled = true;
                TipoProceso = String.Empty;
                lblProcesando.Visible = false;
                timer1.Enabled = false;
                Cursor = Cursors.Arrow;
                Marquee = String.Empty;
                Global.MensajeError(ex.Message);
            }
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtCCostos.Text.Trim()))
                {
                    Global.MensajeComunicacion("Debe ingresar primero el Centro de Costo.");
                    return;
                }

                if (String.IsNullOrEmpty(txtRuta.Text))
                {
                    Global.MensajeFault("Tiene que seleccionar el archivo de Registro");
                    return;
                }

                if (VariablesLocales.oVenParametros != null)
                {
                    if (VariablesLocales.oVenParametros.ClienteVarios == 0)
                    {
                        Global.MensajeComunicacion("Falta configurar Clientes Varios en Parámetros de Ventas");
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Falta configurar los Parámetros de Ventas");
                    return;
                }

                RutaGeneral = txtRuta.Text.Trim();

                if (File.Exists(RutaGeneral))
                {
                    if (_bw.IsBusy)
                    {
                        _bw.CancelAsync();
                    }

                    TipoProceso = "E";
                    btExaminar.Enabled = false;
                    btCancelar.Enabled = true;
                    btActualizar.Enabled = false;
                    btProcesar.Enabled = false;
                    btErrores.Enabled = false;
                    btIntegrar.Enabled = false;
                    btGenerarVoucher.Enabled = false;

                    lblProcesando.Visible = true;
                    timer1.Enabled = true;
                    Cursor = Cursors.WaitCursor;
                    Marquee = "Cargando Hoja Excel...";
                    pbProgress.Visible = true;
                    _bw.RunWorkerAsync();
                }
                else
                {
                    Global.MensajeFault(String.Format("El archivo no existe en la ruta especificada: {0}. \n\rRevise por favor", RutaGeneral));
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_bw.IsBusy)
                {
                    _bw.CancelAsync();
                }

                if (oListaPrincipal != null && oListaPrincipal.Count > Variables.Cero)
                {
                    TipoProceso = "P";
                    btExaminar.Enabled = false;
                    btCancelar.Enabled = true;
                    btActualizar.Enabled = false;
                    btProcesar.Enabled = false;
                    btErrores.Enabled = false;
                    btIntegrar.Enabled = false;

                    lblProcesando.Visible = true;
                    lblRegistros.Visible = true;
                    timer1.Enabled = true;
                    Cursor = Cursors.WaitCursor;
                    Marquee = "Procesando Información...";
                    pbProgress.Visible = true;
                    _bw.RunWorkerAsync();
                }
                else
                {
                    Global.MensajeFault("La lista de registros se encuentra vacia aún...");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
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

        private void btIntegrar_Click(object sender, EventArgs e)
        {
            try
            {
                TipoProceso = "I";
                btExaminar.Enabled = false;
                btCancelar.Enabled = true;
                btActualizar.Enabled = false;
                btProcesar.Enabled = false;
                btIntegrar.Enabled = false;
                lblProcesando.Visible = true;
                lblRegistros.Visible = true;
                timer1.Enabled = true;
                Cursor = Cursors.WaitCursor;
                Marquee = "Insertando las Ventas...";
                pbProgress.Visible = true;
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btErrores_Click(object sender, EventArgs e)
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmErrores);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmErrores("VENTASDET");
                oFrm.MdiParent = MdiParent;
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            _bw.CancelAsync();
        }

        private void btCentroC_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 Nivel = 1;

                if (VariablesLocales.oConParametros != null)
                {
                    if (VariablesLocales.oConParametros.numNivelCCosto > 0)
                    {
                        Nivel = Convert.ToInt32(VariablesLocales.oConParametros.numNivelCCosto);
                    }
                }

                FrmBusquedaCentroDeCosto oFrm = new FrmBusquedaCentroDeCosto(Nivel);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.CentroCosto != null)
                {
                    txtCCostos.Text = oFrm.CentroCosto.idCCostos;
                    txtDesCCostos.Text = oFrm.CentroCosto.desCCostos;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btAuxiliares_Click(object sender, EventArgs e)
        {
            try
            {
                List<ErrorImportGeneralE> ListaPorMandar = new List<ErrorImportGeneralE>();

                foreach (RegVentasDetXLSE item in oListaPrincipal)
                {
                    foreach (ErrorImportGeneralE itemErr in oListaError)
                    {
                        if ((itemErr.ValorCampo == item.Ruc) && itemErr.Mensaje.ToUpper().Contains("NO EXISTE"))
                        {
                            ErrorImportGeneralE errBuscar = ListaPorMandar.Find
                            (
                                delegate (ErrorImportGeneralE er) { return er.ValorCampo == item.Ruc; }
                            );

                            if (errBuscar == null)
                            {
                                itemErr.RazonSocial = item.RazonSocial;
                                ListaPorMandar.Add(itemErr);
                            }
                        }
                    }
                }

                Int32 resp = AgenteContabilidad.Proxy.CrearAuxiliares(ListaPorMandar, VariablesLocales.SesionUsuario.Credencial);

                if (resp > 0)
                {
                    Global.MensajeComunicacion("Se crearon los auxiliares correctamente.");
                    btAuxiliares.Visible = false;
                    btIntegrar.Visible = true;
                    btErrores.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btGenerarVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecInicial; DateTime fecFinal;

                fecInicial = Convert.ToDateTime((from mn in oListaPrincipal
                                                 select (DateTime?)mn.FechaTurno).Min());

                fecFinal = Convert.ToDateTime((from mx in oListaPrincipal
                                               select (DateTime?)mx.FechaTurno).Max());

                Int32? ClienteVarios = VariablesLocales.oVenParametros.ClienteVarios.Value;

                AgenteContabilidad.Proxy.GenerarVoucherVentasDet(oListaPrincipal[0].idEmpresa, oListaPrincipal[0].idLocal, oListaPrincipal[0].idCCostos,
                                                                (cboSistema.SelectedIndex == 0 ? "FUL" : "GAS"), fecInicial, fecFinal, VariablesLocales.SesionUsuario.Credencial, ClienteVarios);

                oListaPrincipal = new List<RegVentasDetXLSE>();
                btGenerarVoucher.Enabled = false;
                Global.MensajeComunicacion("Voucher Generado");
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
