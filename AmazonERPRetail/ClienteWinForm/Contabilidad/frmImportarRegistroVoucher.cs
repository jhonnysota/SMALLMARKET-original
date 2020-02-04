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
using System.Windows.Forms;
using ClienteWinForm.Contabilidad.Reportes;

#endregion

namespace ClienteWinForm.Contabilidad
{
    public partial class frmImportarRegistroVoucher : FrmMantenimientoBase
    {

        public frmImportarRegistroVoucher()
        {
            Infraestructura.Global.AjustarResolucion(this);
            InitializeComponent();
        }

        #region Variables
        
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        String RutaGeneral = String.Empty;
        List<VoucherXLSE> oListaPrincipal = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String Marquee = String.Empty;
        Int32 letra = 0;
        String TipoProceso = String.Empty;
        Int32 errores = 0;
        Int32 IntegroBien = 0;
        //Int32 Registros = 0;

        #endregion        

        #region Procedimientos de Usuario
        
        Boolean ImportarExcel(String Ruta)
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
                    VoucherXLSE oRegistro = null;
                    oListaPrincipal = new List<VoucherXLSE>();
                    
                    //Excel
                    ExcelWorksheet oHoja = oExcel.Workbook.Worksheets[1];

                    //Para el recorrido del excel
                    Int32 totFilas = oHoja.Dimension.Rows;
                    int ContadorItem = 1;

                    //Recorriendo la hoja excel hasta el total de fila obtenido...
                    for (int f = Inicio; f <= totFilas; f++)
                    {
                        if (oHoja.Cells[f, 1].Value != null)
                        {
                            if ((oHoja.Cells[f, 1].Value).ToString().Trim().Length > 0)
                            {
                                // FILA
                                oRegistro = new VoucherXLSE();
                                oRegistro.Linea = FilaError = f;
                                oRegistro.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;

                                Columna = 1;
                                if (oHoja.Cells[f, 1].Value != null)
                                {
                                    oRegistro.idLocal = Convert.ToInt32(oHoja.Cells[f, 1].Value);
                                }

                                Columna = 2;
                                if (oHoja.Cells[f, 2].Value != null)
                                {
                                    oRegistro.Anio = Convert.ToString(oHoja.Cells[f, 2].Value);

                                    if (oRegistro.Anio.Length != 4)
                                    {
                                        throw new Exception("El campo Año debe tener 4 dígitos.");
                                    }
                                }
                                
                                Columna = 3;
                                if (oHoja.Cells[f, 3].Value != null)
                                {
                                    oRegistro.Mes = (oHoja.Cells[f, 3].Value).ToString().Trim();

                                    if (oRegistro.Mes.Length != 2)
                                    {
                                        throw new Exception("El campo Mes debe tener 2 dígitos.");
                                    }
                                }

                                Columna = 4;
                                if (oHoja.Cells[f, 4].Value != null)
                                {
                                    oRegistro.Diario = (oHoja.Cells[f, 4].Value).ToString().Trim();

                                    if (oRegistro.Diario.Length != 2)
                                    {
                                        throw new Exception("El campo Diario debe tener 2 dígitos.");
                                    }
                                }

                                Columna = 5;
                                if (oHoja.Cells[f, 5].Value != null)
                                {
                                    oRegistro.NumFile = (oHoja.Cells[f, 5].Value).ToString().Trim();

                                    if (oRegistro.NumFile.Length != 2)
                                    {
                                        throw new Exception("El campo File debe tener 2 dígitos.");
                                    }
                                }

                                Columna = 6;
                                if (oHoja.Cells[f, 6].Value != null)
                                {
                                    oRegistro.Numero = (oHoja.Cells[f, 6].Value).ToString().Trim();

                                    if (oRegistro.Numero.Length > 9)
                                    {
                                        throw new Exception("El campo Número del Voucher no debe exceder los 9 dígitos.");
                                    }
                                }

                                Columna = 7;
                                if (oHoja.Cells[f, 7].Value != null)
                                {
                                    oRegistro.FechaOperacion = Convert.ToDateTime(oHoja.Cells[f, 7].Value);
                                }

                                Columna = 8;
                                if (oHoja.Cells[f, 8].Value != null)
                                {
                                    oRegistro.Moneda = (oHoja.Cells[f, 8].Value).ToString().Trim();

                                    if (oRegistro.Moneda.Length != 2)
                                    {
                                        throw new Exception("El campo Moneda debe tener 2 dígitos.");
                                    }
                                }

                                Columna = 9;
                                if (oHoja.Cells[f, 9].Value != null)
                                {
                                    oRegistro.GlosaGeneral = (oHoja.Cells[f, 9].Value).ToString().Trim();

                                    if (oRegistro.GlosaGeneral.Length > 500)
                                    {
                                        throw new Exception("El campo Glosa General no debe exceder los 500 dígitos.");
                                    }
                                }

                                Columna = 10;
                                if (oHoja.Cells[f, 10].Value != null)
                                {
                                    oRegistro.Item = (oHoja.Cells[f, 10].Value).ToString().Trim();

                                    if (oRegistro.Item.Length > 5)
                                    {
                                        throw new Exception("El campo Item debe tener 5 dígitos.");
                                    }
                                }

                                Columna = 11;
                                if (oHoja.Cells[f, 11].Value != null)
                                {
                                    oRegistro.Cuenta = (oHoja.Cells[f, 11].Value).ToString().Trim();

                                    if (oRegistro.Cuenta.Length > 7)
                                    {
                                        throw new Exception("El campo Cuenta no debe exceder los 7 dígitos.");
                                    }
                                }

                                Columna = 12;
                                if (oHoja.Cells[f, 12].Value != null)
                                {
                                    oRegistro.Descripcion = (oHoja.Cells[f, 12].Value).ToString().Trim();

                                    if (oRegistro.Descripcion.Length > 200)
                                    {
                                        throw new Exception("El campo Descripción no debe exceder los 200 dígitos.");
                                    }
                                }

                                Columna = 13;
                                if (oHoja.Cells[f, 13].Value != null)
                                {
                                    oRegistro.CtaDes = (oHoja.Cells[f, 13].Value).ToString().Trim();

                                    if (oRegistro.CtaDes.Length > 2)
                                    {
                                        throw new Exception("El campo Cta.Destino no debe exceder los 2 dígitos.");
                                    }
                                }

                                Columna = 14;
                                if (oHoja.Cells[f, 14].Value != null)
                                {
                                    oRegistro.CompraVenta = oHoja.Cells[f, 14].Value.ToString().Trim();

                                    if (oRegistro.CompraVenta.Length > 20)
                                    {
                                        throw new Exception("El campo Compra Venta no debe exceder los 20 dígitos.");
                                    }
                                }

                                Columna = 15;
                                if (oHoja.Cells[f, 15].Value != null)
                                {
                                    oRegistro.Codigo = Convert.ToInt32(oHoja.Cells[f, 15].Value);
                                }

                                Columna = 16;
                                if (oHoja.Cells[f, 16].Value != null)
                                {
                                    oRegistro.RUC = (oHoja.Cells[f, 16].Value).ToString().Trim();

                                    if (oRegistro.RUC.Length > 20)
                                    {
                                        throw new Exception("El campo RUC no debe exceder los 20 dígitos.");
                                    }
                                }

                                Columna = 17;
                                if (oHoja.Cells[f, 17].Value != null)
                                {
                                    oRegistro.DescripcionLarga = (oHoja.Cells[f, 17].Value).ToString().Trim();

                                    if (oRegistro.DescripcionLarga.Length > 250)
                                    {
                                        throw new Exception("El campo Descripción o Razón Social no debe exceder los 250 dígitos.");
                                    }
                                }
                                else
                                {
                                    oRegistro.DescripcionLarga = String.Empty;
                                }

                                Columna = 18;
                                if (oHoja.Cells[f, 18].Value != null)
                                {
                                    oRegistro.TipoDoc = (oHoja.Cells[f, 18].Value).ToString().Trim();

                                    if (oRegistro.TipoDoc.Length > 2)
                                    {
                                        throw new Exception("El campo TD no debe exceder los 2 dígitos.");
                                    }
                                }

                                Columna = 19;
                                if (oHoja.Cells[f, 19].Value != null)
                                {
                                    oRegistro.Serie = (oHoja.Cells[f, 19].Value).ToString().Trim();

                                    if (oRegistro.Serie.Length > 20)
                                    {
                                        throw new Exception("El campo Serie no debe exceder los 20 dígitos.");
                                    }
                                }

                                Columna = 20;
                                if (oHoja.Cells[f, 20].Value != null)
                                {
                                    oRegistro.Documentos = Infraestructura.Global.DejarSoloUnEspacio((oHoja.Cells[f, 20].Value).ToString().Trim().Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, ""));

                                    if (oRegistro.Documentos.Length > 20)
                                    {
                                        throw new Exception("El campo Documentos no debe exceder los 20 dígitos.");
                                    }
                                }

                                Columna = 21;
                                if (oHoja.Cells[f, 21].Value != null)
                                {
                                    oRegistro.Fecha = Convert.ToDateTime(oHoja.Cells[f, 21].Value);
                                }
                                else
                                {
                                    oRegistro.Fecha = (DateTime?)null;
                                }

                                Columna = 22;
                                if (oHoja.Cells[f, 22].Value  != null)
                                {
                                    oRegistro.FechaVen = Convert.ToDateTime(oHoja.Cells[f, 22].Value);
                                }
                                else
                                {
                                    oRegistro.FechaVen = (DateTime?)null;
                                }

                                Columna = 23;
                                if (oHoja.Cells[f, 23].Value != null)
                                {
                                    oRegistro.indTipoCambio = (oHoja.Cells[f, 23].Value).ToString().Trim();

                                    if (oRegistro.indTipoCambio.Length > 2)
                                    {
                                        throw new Exception("El campo Indica Conversión T.C. no debe exceder los 2 dígitos.");
                                    }
                                }

                                Columna = 24;
                                oRegistro.TipoCambio = Convert.ToDecimal(oHoja.Cells[f, 24].Value != null && oHoja.Cells[f, 24].Value.ToString().Length > 0 ? Convert.ToDecimal(oHoja.Cells[f, 24].Value) : 0M);

                                Columna = 25;
                                if (oHoja.Cells[f, 25].Value != null)
                                {
                                    oRegistro.CentroCosto = (oHoja.Cells[f, 25].Value).ToString().Trim();

                                    if (oRegistro.CentroCosto.Length > 20)
                                    {
                                        throw new Exception("El campo Centro Costo no debe exceder los 20 dígitos.");
                                    }
                                }

                                Columna = 26;
                                if (oHoja.Cells[f, 26].Value != null)
                                {
                                    oRegistro.indDH = (oHoja.Cells[f, 26].Value).ToString().Trim();

                                    if (oRegistro.indDH.Length > 1)
                                    {
                                        throw new Exception("El campo D/H no debe exceder los 20 dígitos.");
                                    }
                                }

                                Columna = 27;
                                oRegistro.MontoSoles = Convert.ToDecimal(oHoja.Cells[f, 27].Value != null && oHoja.Cells[f, 27].Value.ToString().Length > 0 ? Convert.ToDecimal(oHoja.Cells[f, 27].Value) : 0M);
                                Columna = 28;
                                oRegistro.MontoDolares = Convert.ToDecimal(oHoja.Cells[f, 28].Value != null && oHoja.Cells[f, 28].Value.ToString().Length > 0 ? Convert.ToDecimal(oHoja.Cells[f, 28].Value) : 0M);

                                Columna = 29;
                                if (oHoja.Cells[f, 29].Value != null)
                                {
                                    oRegistro.TipoDocRef = (oHoja.Cells[f, 29].Value).ToString().Trim();

                                    if (oRegistro.TipoDocRef.Length > 2)
                                    {
                                        throw new Exception("El campo Tipo Doc.Ref. no debe exceder los 2 dígitos.");
                                    }
                                }

                                Columna = 30;
                                if (oHoja.Cells[f, 30].Value != null)
                                {
                                    oRegistro.SerieDocRef = (oHoja.Cells[f, 30].Value).ToString().Trim();

                                    if (oRegistro.SerieDocRef.Length > 20)
                                    {
                                        throw new Exception("El campo Serie Doc.Ref. no debe exceder los 20 dígitos.");
                                    }
                                }

                                Columna = 31;
                                if (oHoja.Cells[f, 31].Value != null)
                                {
                                    oRegistro.NumDocRef = (oHoja.Cells[f, 31].Value).ToString().Trim();

                                    if (oRegistro.NumDocRef.Length > 20)
                                    {
                                        throw new Exception("El campo Num.Doc.Ref. no debe exceder los 20 dígitos.");
                                    }
                                }

                                Columna = 31;
                                if (oHoja.Cells[f, 32].Value  != null)
                                {
                                    oRegistro.FechaRef = Convert.ToDateTime(oHoja.Cells[f, 32].Value);
                                }
                                else
                                {
                                    oRegistro.FechaRef = (DateTime?)null;
                                }

                                Columna = 33;
                                if (oHoja.Cells[f, 33].Value != null)
                                {
                                    oRegistro.Glosa = (oHoja.Cells[f, 33].Value).ToString().Trim();

                                    if (oRegistro.Glosa.Length > 400)
                                    {
                                        throw new Exception("El campo Glosa del Detalle no debe exceder los 400 dígitos.");
                                    }
                                }

                                Columna = 34;
                                if (oHoja.Cells[f, 34].Value != null)
                                {
                                    oRegistro.indReparable = (oHoja.Cells[f, 34].Value).ToString().Trim();

                                    if (oRegistro.indReparable.Length > 2)
                                    {
                                        throw new Exception("El campo Reparable no debe exceder los 2 dígitos.");
                                    }
                                }

                                oListaPrincipal.Add(oRegistro);
                                ContadorItem++;
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
                if (TipoProceso == "P") //Procesar
                {
                    #region Procesando la Información

                    errores = 0;
                    Int32 TotalReg = Variables.Cero; //Total registros en la lista Principal
                    Int32 TotalTemp = Variables.Cero; //Total registros para poder ir descontando cuantos van quedandos
                    Int32 cantReg = Variables.Cero; //Para saber cuantos registros se van a ir quitando
                    Int32 Residuo = Variables.Cero; //Para saber si sobra registros en caso el total sea impar

                    //Lista Temporal para borrar y traer los errores si los hubiere...
                    var ListaTemporal = oListaPrincipal.GroupBy(x => new { x.idEmpresa, x.idLocal }).Select(g => g.First()).ToList();
                    //Borrando VoucherXLS por Local
                    AgenteContabilidad.Proxy.EliminarVoucherXLS(ListaTemporal.ToList());

                    //Empezando el ingreso a VoucherXLS
                    if (oListaPrincipal.Count < 1000)
                    {
                        AgenteContabilidad.Proxy.InsertarVoucherXLS(oListaPrincipal);
                    }
                    else
                    {
                        List<VoucherXLSE> oListaExcel = new List<VoucherXLSE>(oListaPrincipal);
                        TotalReg = TotalTemp = oListaExcel.Count;
                        cantReg = TotalReg / 10;
                        Residuo = TotalReg % 10;

                        for (int conta = 0; conta <= 10; conta++)
                        {
                            List<VoucherXLSE> oListaTemporal = new List<VoucherXLSE>();

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

                            foreach (VoucherXLSE itemTemp in oListaTemporal)
                            {
                                oListaExcel.Remove(itemTemp);
                            }

                            if (oListaTemporal.Count > Variables.Cero)
                            {
                                Minimo = Convert.ToInt32(oListaTemporal.Min(x => x.Linea));
                                Maximo = Convert.ToInt32(oListaTemporal.Max(x => x.Linea));
                                MensajeErr = String.Format("Revisar en el rango de lineas de {0} al {1}.", Minimo.ToString(), Maximo.ToString());

                                AgenteContabilidad.Proxy.InsertarVoucherXLS(oListaTemporal);

                                TotalTemp -= oListaTemporal.Count();
                                oListaTemporal = null;
                                lblRegistros.Text = "Total Reg. " + TotalReg.ToString() + " Faltan " + TotalTemp.ToString();
                            }
                        }

                        oListaExcel = null;
                    }

                    //Obteniendo los errores si los hubiere...
                    errores = AgenteContabilidad.Proxy.ErroresVoucherXLS(ListaTemporal.ToList());

                    if (errores > 0)
                    {
                        throw new Exception(String.Format("El proceso tiene {0} errores. Revise el reporte de Errores.", errores.ToString()));
                    } 

                    #endregion
                }
                else if(TipoProceso == "E") //Actualizar
                {
                    #region Importando desde Excel

                    ImportarExcel(RutaGeneral);

                    if (oListaPrincipal.Count > 0)
                    {
                        PeriodosE oPeriodoContable = AgenteContabilidad.Proxy.ObtenerPeriodoPorMes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, oListaPrincipal[0].Anio, oListaPrincipal[0].Mes);

                        if (oPeriodoContable.indCierre)
                        {
                            throw new Exception("El mes se encuentra cerrado. No podra ingresar vouchers al Módulo de Contabilidad.");
                        }
                    } 

                    #endregion
                }
                else if (TipoProceso == "I") //Integrar
                {
                    IntegroBien = 0;

                    if (chkEliminacion.Checked)
                    {
                        List<VoucherE> oListaVouchers = new List<VoucherE>();
                        Int32 Acumulador = 0;

                        var ListaVerificar = oListaPrincipal.GroupBy(x => new { x.idLocal, x.Anio, x.Mes, x.Diario, x.NumFile }).Select(g => g.First()).ToList();

                        foreach (VoucherXLSE item in ListaVerificar)
                        {
                            oListaVouchers = AgenteContabilidad.Proxy.ListarVoucher(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, item.idLocal,item.Anio,item.Mes,item.Diario,item.NumFile);
                            Acumulador += oListaVouchers.Count;
                        }
                        
                        if (Acumulador > 0 && Global.MensajeConfirmacion("¿Se va a eliminar " + Acumulador.ToString() + " Voucher(s) esta seguro S/N? ") == DialogResult.Yes)
                        {
                            Int32 Reg = AgenteContabilidad.Proxy.IntegrarVoucherXLS(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, oListaPrincipal[0].idLocal, VariablesLocales.SesionUsuario.Credencial, oListaPrincipal, chkEliminacion.Checked, "S");
                        }
                        else
                        {
                            List<VoucherE> oListaVouchersfilt = new List<VoucherE>();
                            Int32 Acumulador2 = 0;

                            var ListaVerificarVoucher = oListaPrincipal.GroupBy(x => new { x.idLocal, x.Anio, x.Mes, x.Diario, x.NumFile,x.Numero }).Select(g => g.First()).ToList();

                            foreach (VoucherXLSE item in ListaVerificarVoucher)
                            {
                                oListaVouchersfilt = AgenteContabilidad.Proxy.ListarVoucherNumVoucher(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, item.idLocal, item.Anio, item.Mes, item.Diario, item.NumFile,item.Numero);

                                Acumulador2 += oListaVouchersfilt.Count;
                            }

                            if (Acumulador2 == 0)
                            {                            
                                Int32 Reg = AgenteContabilidad.Proxy.IntegrarVoucherXLS(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, oListaPrincipal[0].idLocal, VariablesLocales.SesionUsuario.Credencial, oListaPrincipal, chkEliminacion.Checked, "N");
                            }
                            else
                            {
                                IntegroBien = 1;
                                Global.MensajeComunicacion("El Voucher Ya Existe");
                            }
                        }
                    }
                    else
                    {
                        List<VoucherE> oListaVouchersfilt2 = new List<VoucherE>();
                        Int32 Acumulador3 = 0;

                        var ListaVerificarVoucher = oListaPrincipal.GroupBy(x => new { x.idLocal, x.Anio, x.Mes, x.Diario, x.NumFile, x.Numero }).Select(g => g.First()).ToList();

                        foreach (VoucherXLSE item in ListaVerificarVoucher)
                        {
                            oListaVouchersfilt2 = AgenteContabilidad.Proxy.ListarVoucherNumVoucher(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, item.idLocal, item.Anio, item.Mes, item.Diario, item.NumFile,item.Numero);
                            Acumulador3 += oListaVouchersfilt2.Count;
                        }

                        if (Acumulador3 == 0)
                        {
                            Int32 Reg = AgenteContabilidad.Proxy.IntegrarVoucherXLS(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, oListaPrincipal[0].idLocal, VariablesLocales.SesionUsuario.Credencial, oListaPrincipal, chkEliminacion.Checked, "N");
                        }
                        else
                        {
                            IntegroBien = 1;
                            Global.MensajeComunicacion("El Voucher Ya Existe");
                        }
                    }
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
                Infraestructura.Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));

                if (errores > 0)
                {
                    btErrores.Enabled = true;
                }

                btProcesar.Enabled = false;
                btIntegrar.Enabled = false;
            }
            else if (e.Cancelled == true)
            {
                Infraestructura.Global.MensajeComunicacion("La operación ha sido cancelada.");
            }
            //else if (e.Result.ToString() != "ok") 3 - Si es diferente de ok mostrar el mensaje de error
            //{
            //    Infraestructura.Global.MensajeFault(e.Result.ToString());
            //}
            else
            {
                if (TipoProceso == "P")
                {
                    btProcesar.Enabled = true;
                    btErrores.Enabled = false;
                    btIntegrar.Enabled = true;

                    Infraestructura.Global.MensajeComunicacion("El proceso ha concluido correctamente...");
                }
                else if(TipoProceso == "E")
                {
                    btProcesar.Enabled = oListaPrincipal.Count > 0;
                    Infraestructura.Global.MensajeComunicacion("Se ha importado la hoja excel correctamente...");
                }
                else
                {
                    btProcesar.Enabled = false;
                    btErrores.Enabled = false;
                    btIntegrar.Enabled = false;

                    if (IntegroBien == 0)
                    {
                        Infraestructura.Global.MensajeComunicacion("Se han ingresado los vouchers correctamente...");
                    }
                }
            }
        }

        #endregion

        #region Eventos

        private void btExaminar_Click(object sender, EventArgs e)
        {
            try
            {                
                txtRuta.Text = CuadrosDialogo.BuscarArchivo("Buscar Archivo Excel", "Todos los Archivos Excel |*.xlsx;*.xls");
            }
            catch (Exception ex)
            {
                btExaminar.Enabled = true;
                TipoProceso = String.Empty;
                lblProcesando.Visible = false;
                timer1.Enabled = false;
                Cursor = Cursors.Arrow;
                Marquee = String.Empty;
                Infraestructura.Global.MensajeError(ex.Message);
            }
        }
        
        private void btActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtRuta.Text))
                {
                    Infraestructura.Global.MensajeFault("Tiene que seleccionar el archivo de Registro");
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

                    lblProcesando.Visible = true;
                    timer1.Enabled = true;
                    Cursor = Cursors.WaitCursor;
                    Marquee = "Cargando Hoja Excel...";
                    pbProgress.Visible = true;
                    _bw.RunWorkerAsync();
                }
                else
                {
                    Infraestructura.Global.MensajeFault(String.Format("El archivo no existe en la ruta especificada: {0}. \n\rRevise por favor", RutaGeneral));
                }
            }
            catch (Exception ex)
            {
                Infraestructura.Global.MensajeError(ex.Message);
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
                    Infraestructura.Global.MensajeFault("La lista de registros se encuentra vacia aún...");
                }
            }
            catch (Exception ex)
            {
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

        private void frmImportarRegistroVoucher_Load(object sender, EventArgs e)
        {
            Grid = false;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
            CheckForIllegalCrossThreadCalls = false;
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
                Marquee = "Insertando los Vouchers...";
                pbProgress.Visible = true;
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Infraestructura.Global.MensajeFault(ex.Message);
            }
        }

        private void btErrores_Click(object sender, EventArgs e)
        {
            try
            {
                Form oFrm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmErrores);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmErrores("VOUCHER");
                oFrm.MdiParent = MdiParent;
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Infraestructura.Global.MensajeError(ex.Message);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            _bw.CancelAsync();
        }

        private void chkEliminacion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminacion.Checked)
            {
                chkEliminacion.Text = "Eliminación (Por Diario, File y Periodo)";
            }
            else
            {
                chkEliminacion.Text = "No eliminar.";
            }
        }

        #endregion

    }
}
