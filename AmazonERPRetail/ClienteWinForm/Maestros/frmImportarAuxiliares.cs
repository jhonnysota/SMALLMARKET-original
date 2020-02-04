using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Contabilidad.Reportes;

#region Para Excel

using OfficeOpenXml;

#endregion

namespace ClienteWinForm.Maestros
{
    public partial class frmImportarAuxiliares : FrmMantenimientoBase
    {

        public frmImportarAuxiliares()
        {
            Infraestructura.Global.AjustarResolucion(this);
            InitializeComponent();
        }

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<ClienteXLSE> oListaAuxiliares = null;
        List<ParTabla> oListaTipoPersona = null;
        List<ParTabla> oListaTipoDocumento = null;
        List<ParTabla> oListaTipoMercado = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String Tipo = String.Empty;
        String Marquee = String.Empty;
        Int32 letra = 0;
        Int32 Registros = Variables.Cero;
        Int32 errores = 0;
        String TipoImportacion = String.Empty;
        String Mensaje = String.Empty;
        #endregion

        #region Procedimientos de Usuario

        Boolean ImportarExcel(String Ruta)
        {
            FileInfo oFi_ = new FileInfo(Ruta);
            Int32 FilaError = 0;
            Int32 Columna = 0;

            try
            {
                using (ExcelPackage oExcel = new ExcelPackage(oFi_))
                {
                    Int32 CanalNacional = (from x in oListaTipoMercado where x.NemoTecnico == "MERNAC" select x.IdParTabla).FirstOrDefault();
                    Int32 CanalExtranjero = (from x in oListaTipoMercado where x.NemoTecnico == "MEREXT" select x.IdParTabla).FirstOrDefault();

                    //Entidades
                    ClienteXLSE oRegistroPersona = null;
                    ParTabla oPartabla = null;
                    //Excel
                    ExcelWorksheet oHoja = oExcel.Workbook.Worksheets[1];
                    //Para el recorrido del excel
                    Int32 totFilasExcel = oHoja.Dimension.Rows;//oHoja.Dimension.End.Row;

                    //Recorriendo la hoja excel hasta el total de fila obtenido...
                    for (int f = 5; f <= totFilasExcel; f++)
                    {
                        if (oHoja.Cells[f, 1].Value != null)
                        {
                            oRegistroPersona = new ClienteXLSE()
                            {
                                Linea = FilaError = f,
                                idEmpresa = Convert.ToInt32(oHoja.Cells[2, 1].Value),
                                RazonSocial = Convert.ToString(oHoja.Cells[2, 2].Value)
                            };

                            TipoImportacion = Convert.ToString(oHoja.Cells[2, 5].Value);

                            if (oRegistroPersona.idEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa && oRegistroPersona.RazonSocial == VariablesLocales.SesionUsuario.Empresa.RazonSocial && (TipoImportacion == "Clientes" || TipoImportacion == "Proveedores"))
                            {
                                Columna = 1;

                                oPartabla = oListaTipoPersona.Find
                                (
                                    delegate (ParTabla cc) { return cc.Nombre == Convert.ToString(oHoja.Cells[f, 1].Value); }
                                );

                                if (oPartabla != null)
                                {
                                    oRegistroPersona.TipoPersona = oPartabla.IdParTabla;

                                    if (oPartabla.NemoTecnico == "PERJU" || oPartabla.NemoTecnico == "PERCR" || oPartabla.NemoTecnico == "PERSR")
                                    {
                                        oRegistroPersona.idCanalVenta = CanalNacional;
                                        oRegistroPersona.idPais = 90;
                                    }
                                    else
                                    {
                                        oRegistroPersona.idCanalVenta = CanalExtranjero;
                                        oRegistroPersona.idPais = 0;
                                    }
                                }
                                else
                                {
                                    oRegistroPersona.TipoPersona = 0;
                                    oRegistroPersona.idPais = 0;
                                    oRegistroPersona.idCanalVenta = 0;
                                }

                                Columna = 2;
                                oRegistroPersona.RazonSocial = Convert.ToString(oHoja.Cells[f, 2].Value);

                                if (oRegistroPersona.RazonSocial.Length > 200)
                                {
                                    throw new Exception("El campo Razon Social debe tener como máximo 200 dígitos.");
                                }

                                Columna = 3;
                                oRegistroPersona.ApePaterno = Convert.ToString(oHoja.Cells[f, 3].Value);

                                if (oRegistroPersona.ApePaterno.Length > 50)
                                {
                                    throw new Exception("El campo Apellido Paterno debe tener como máximo 50 dígitos.");
                                }

                                Columna = 4;
                                oRegistroPersona.ApeMaterno = Convert.ToString(oHoja.Cells[f, 4].Value);

                                if (oRegistroPersona.ApeMaterno.Length > 50)
                                {
                                    throw new Exception("El campo Apellido Materno debe tener como máximo 50 dígitos.");
                                }

                                Columna = 5;
                                oRegistroPersona.Nombres = Convert.ToString(oHoja.Cells[f, 5].Value);

                                if (oRegistroPersona.Nombres.Length > 50)
                                {
                                    throw new Exception("El campo Nombres debe tener como máximo 50 dígitos.");
                                }

                                Columna = 6;
                                oPartabla = oListaTipoDocumento.Find
                                (
                                    delegate (ParTabla cc) { return cc.Nombre == Convert.ToString(oHoja.Cells[f, 6].Value); }
                                );

                                if (oPartabla != null)
                                {
                                    oRegistroPersona.TipoDocumento = oPartabla.IdParTabla;
                                }
                                else
                                {
                                    oRegistroPersona.TipoDocumento = 0;
                                }

                                Columna = 7;
                                oRegistroPersona.NroDocumento = Convert.ToString(oHoja.Cells[f, 7].Value);

                                if (oRegistroPersona.NroDocumento.Length > 25)
                                {
                                    throw new Exception("El campo Nro. Documento debe tener como máximo 250 dígitos.");
                                }

                                Columna = 8;
                                oRegistroPersona.DireccionCompleta = Global.DejarSoloUnEspacio(Convert.ToString(oHoja.Cells[f, 8].Value).Trim());

                                if (oRegistroPersona.DireccionCompleta.Length > 300)
                                {
                                    throw new Exception("El campo Direccion debe tener como máximo 300 dígitos.");
                                }

                                oListaAuxiliares.Add(oRegistroPersona);
                                lblProcesando.Text = String.Format("Importando de Excel: Linea {0}", f);
                            }
                            else
                            {
                                Mensaje = "s";
                            }
                        }
                    }

                    if (Mensaje == "s")
                    {
                        Infraestructura.Global.MensajeError("La Empresa o Importacion No Coinciden");
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
                if (Tipo == "E")
                {
                    #region Importando Desde Excel

                    ImportarExcel(txtRuta.Text);

                    #endregion
                }
                else if (Tipo == "P")
                {
                    #region Procesando La Informacion

                    if (oListaAuxiliares.Count > Variables.Cero)
                    {
                        errores = 0;
                        Int32 TotalReg = Variables.Cero; //Total registros en la lista Principal
                        Int32 TotalTemp = Variables.Cero; //Total registros para poder ir descontando cuantos van quedandos
                        Int32 cantReg = Variables.Cero; //Para saber cuantos registros se van a ir quitando
                        Int32 Residuo = Variables.Cero; //Para saber si sobra registros en caso el total sea impar

                        //Lista Temporal para borrar y traer los errores si los hubiere...
                        var ListaTemporal = oListaAuxiliares.GroupBy(x => new { x.NroDocumento }).Select(g => g.First()).ToList();
                        //Borrando VoucherXLS por Local
                        AgenteMaestro.Proxy.EliminarClienteXLS(ListaTemporal.ToList());

                        //Empezando el ingreso a VoucherXLS
                        if (oListaAuxiliares.Count < 1000)
                        {
                            Registros = AgenteMaestro.Proxy.InsertarClienteXLS(oListaAuxiliares);
                        }
                        else
                        {
                            List<ClienteXLSE> oListaExcel = new List<ClienteXLSE>(oListaAuxiliares);
                            TotalReg = TotalTemp = oListaExcel.Count;
                            cantReg = TotalReg / 10;
                            Residuo = TotalReg % 10;

                            for (int conta = 0; conta <= 10; conta++)
                            {
                                List<ClienteXLSE> oListaTemporal = new List<ClienteXLSE>();

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

                                foreach (ClienteXLSE itemTemp in oListaTemporal)
                                {
                                    oListaExcel.Remove(itemTemp);
                                }

                                if (oListaTemporal.Count > Variables.Cero)
                                {
                                    Minimo = Convert.ToInt32(oListaTemporal.Min(x => x.Linea));
                                    Maximo = Convert.ToInt32(oListaTemporal.Max(x => x.Linea));
                                    MensajeErr = String.Format("Revisar en el rango de lineas de {0} al {1}.", Minimo.ToString(), Maximo.ToString());

                                    AgenteMaestro.Proxy.InsertarClienteXLS(oListaTemporal);

                                    TotalTemp -= oListaTemporal.Count();
                                    oListaTemporal = null;
                                    //lblRegistros.Text = "Total Reg. " + TotalReg.ToString() + " Faltan " + TotalTemp.ToString();
                                }
                            }

                            oListaExcel = null;
                        }

                        //Obteniendo los errores si los hubiere...
                        errores = AgenteMaestro.Proxy.ErroresClienteXLS(ListaTemporal.ToList());

                        if (errores > 0)
                        {
                            throw new Exception(String.Format("El proceso tiene {0} errores. Revise el reporte de Errores.", errores.ToString()));
                        }
                    }

                    #endregion
                }
                else if (Tipo == "I")
                {
                    #region Integrando La Informacion

                    String TipoAuxi = cboTipo.SelectedIndex == 0 ? "C" : "P";
                    Int32 Reg = AgenteMaestro.Proxy.IntegrarClienteXLS(oListaAuxiliares, TipoAuxi, VariablesLocales.SesionUsuario.Credencial);

                    #endregion
                }

                if (_bw.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }
            catch (Exception ex)
            {
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
            lblCantidad.Visible = false;
            lblCantidad.Text = String.Empty;
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
                    btErrores.Enabled = true;
                }

                btProcesar.Enabled = false;
                btIntegrar.Enabled = false;
            }
            else if (e.Cancelled)
            {
                Global.MensajeComunicacion("La operación ha sido cancelada.");
            }
            //else if (e.Result.ToString() != "ok") 3 - Si es diferente de ok mostrar el mensaje de error
            //{
            //    Infraestructura.Global.MensajeFault(e.Result.ToString());
            //}
            else
            {
                if (Tipo == "P")
                {
                    if (e.Error == null)
                    {
                        btProcesar.Enabled = true;
                        btErrores.Enabled = false;
                        btIntegrar.Enabled = true;

                        Global.MensajeComunicacion("El proceso ha concluido correctamente...");
                    }

                    if (e.Error != null)
                    {
                        Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));

                        if (errores > 0)
                        {
                            btErrores.Enabled = true;
                        }

                        btProcesar.Enabled = false;
                        btIntegrar.Enabled = false;
                    }
                }
                else if (Tipo == "E")
                {
                    if (e.Error == null)
                    {
                        btProcesar.Enabled = oListaAuxiliares.Count > 0;

                        if (Mensaje != "s")
                        {
                            Global.MensajeComunicacion("Se ha importado la hoja excel correctamente...");
                        }
                    }

                    if (e.Error != null)
                    {
                        Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));

                        if (errores > 0)
                        {
                            btErrores.Enabled = true;
                        }

                        btProcesar.Enabled = false;
                        btIntegrar.Enabled = false;
                    }
                }
                else
                {
                    if (e.Error == null)
                    {
                        btProcesar.Enabled = false;
                        btErrores.Enabled = false;
                        btIntegrar.Enabled = false;
                        Global.MensajeComunicacion("Se han ingresado los Auxiliares correctamente...");
                    }

                    if (e.Error != null)
                    {
                        Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));

                        if (errores > 0)
                        {
                            btErrores.Enabled = true;
                        }

                        btProcesar.Enabled = false;
                        btIntegrar.Enabled = false;
                    }
                }
            }
        }

        #endregion

        #region Eventos

        private void frmImportarClientes_Load(object sender, EventArgs e)
        {
            Grid = false;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
            CheckForIllegalCrossThreadCalls = false;

            cboTipo.SelectedIndex = 0;

            oListaTipoPersona = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPPER");
            oListaTipoDocumento = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPDOCPER");
            oListaTipoMercado = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPMER");
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
                btExaminar.Enabled = true;
                Tipo = String.Empty;
                lblProcesando.Visible = false;
                timer1.Enabled = false;
                Cursor = System.Windows.Forms.Cursors.Arrow;
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

                txtRuta.Text = txtRuta.Text.Trim();

                if (File.Exists(txtRuta.Text))
                {
                    if (_bw.IsBusy)
                    {
                        _bw.CancelAsync();
                    }

                    Tipo = "E";
                    btExaminar.Enabled = false;
                    btCancelar.Enabled = true;
                    btActualizar.Enabled = false;
                    btProcesar.Enabled = false;
                    btErrores.Enabled = false;
                    btIntegrar.Enabled = false;
                    oListaAuxiliares = new List<ClienteXLSE>();
                    lblProcesando.Visible = true;
                    timer1.Enabled = true;
                    Cursor = Cursors.WaitCursor;
                    Marquee = "Cargando Hoja Excel...";
                    pbProgress.Visible = true;
                    _bw.RunWorkerAsync();

                }
                else
                {
                    Infraestructura.Global.MensajeFault(String.Format("El archivo no existe en la ruta especificada: {0}. \n\rRevise por favor", txtRuta.Text));
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
                if (oListaAuxiliares != null && oListaAuxiliares.Count > Variables.Cero)
                {
                    lblProcesando.Text = String.Empty;
                    Marquee = "Ingresando la información a la Base de Datos...";
                    Cursor = Cursors.WaitCursor;
                    btActualizar.Enabled = false;
                    btCancelar.Enabled = true;
                    btProcesar.Enabled = false;
                    btExaminar.Enabled = false;
                    btErrores.Enabled = false;
                    btIntegrar.Enabled = false;
                    timer1.Enabled = true;
                    lblProcesando.Visible = true;
                    pbProgress.Visible = true;
                    Tipo = "P";
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

                oFrm = new frmErrores("CLIENTE");
                oFrm.MdiParent = MdiParent;
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Infraestructura.Global.MensajeError(ex.Message);
            }
        }

        private void btIntegrar_Click(object sender, EventArgs e)
        {
            try
            {
                String TipoAuxiliar = cboTipo.SelectedIndex == 0 ? "C" : "P";

                Tipo = "I";
                btExaminar.Enabled = false;
                btActualizar.Enabled = false;
                btCancelar.Enabled = true;
                btProcesar.Enabled = false;
                btIntegrar.Enabled = false;
                lblProcesando.Visible = true;
                timer1.Enabled = true;
                Cursor = Cursors.WaitCursor;

                if (TipoAuxiliar == "C")
                {
                    Marquee = "Insertando los Clientes...";
                }
                else
                {
                    Marquee = "Insertando los Proveedores...";
                }

                pbProgress.Visible = true;
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            _bw.CancelAsync();
        }

        #endregion

    }
}
