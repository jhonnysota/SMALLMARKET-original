using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.CtasPorPagar;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Almacen
{
    public partial class frmSalidaAlmacenesEditar : FrmMantenimientoBase
    {
       
        #region Constructor

        public frmSalidaAlmacenesEditar()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            FormatoGrid(dgvitems, false);
        }

        //Nuevo
        public frmSalidaAlmacenesEditar(Int32 idAlmacen_, Int32 idTipoMovimiento_, Int32 idOperacion_, List<AlmacenE> ListaAlmacenes, List<ParTabla> ListaMovimientos, List<OperacionE> ListaOperaciones)
            : this()
        {
            idAlmacen = idAlmacen_;
            idTipoMovimiento = idTipoMovimiento_;
            idOperacion = idOperacion_;
            oListaAlmacenes = ListaAlmacenes;
            oListaTipoMovimientos = ListaMovimientos;
            oListaOp = ListaOperaciones;
        }

        //Edición
        public frmSalidaAlmacenesEditar(MovimientoAlmacenE oEntidad_, List<AlmacenE> ListaAlmacenes, List<ParTabla> ListaMovimientos, List<OperacionE> ListaOperaciones)
            : this()
        {
            oMovimientoAlmacen = AgenteAlmacen.Proxy.ObtenerMovimientoAlmacenCompleto(oEntidad_.idEmpresa, oEntidad_.tipMovimiento, oEntidad_.idDocumentoAlmacen);
            oListaAlmacenes = ListaAlmacenes;
            oListaTipoMovimientos = ListaMovimientos;
            oListaOp = ListaOperaciones;
        }

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        CtasPorPagarServiceAgent AgentePorPagar { get { return new CtasPorPagarServiceAgent(); } }

        List<MovimientoAlmacenItemE> oListaItems = new List<MovimientoAlmacenItemE>();
        MovimientoAlmacenE oMovimientoAlmacen;
        List<AlmacenE> oListaAlmacenes;
        List<AlmacenE> oAlmacenesDestino;
        List<ParTabla> oListaTipoMovimientos = null;
        List<OperacionE> oListaOp;
        OrdenCompraE oOrdenCompra = null;

        Int32 idAlmacen = 0;
        Int32 idTipoMovimiento = 0;
        Int32 idOperacion = 0;

        List<MovimientoAlmacenItemE> itemEliminados = new List<MovimientoAlmacenItemE>();

        public Int32 Opcion = Variables.Cero;
        Boolean YaEntro = false;
        String RutaGeneral = String.Empty;

        #endregion

        #region Override

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                //  Si el control DataGridView no tiene el foco...
                if (!dgvitems.Focused && !dgvitems.IsCurrentCellInEditMode)
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }

                if ((keyData != Keys.Return))
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }

                Int32 iColumnIndex = dgvitems.CurrentCell.ColumnIndex;
                Int32 iRowIndex = dgvitems.CurrentCell.RowIndex;

                if (keyData == Keys.Enter)
                {
                    if (iColumnIndex == dgvitems.Columns.Count - 1)
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }
                    else
                    {
                        dgvitems.CurrentCell = dgvitems[iColumnIndex + 1, iRowIndex];
                    }

                    return true;
                }
                else
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Procedimientos de Usuario

        private void LlenarCombos()
        {
            // Documentos
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(VariablesLocales.ListarDocumentoGeneral);
            DocumentosE Fila = new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione };
            ListaDocumentos.Add(Fila);

            ComboHelper.RellenarCombos<DocumentosE>(cboDocumento, (from x in ListaDocumentos
                                                                   where x.indAlmacen == true || x.idDocumento == "0"
                                                                   orderby x.desDocumento
                                                                   select x).ToList(), "idDocumento", "desDocumento", false);
            // Documentos Referencia
            ComboHelper.RellenarCombos<DocumentosE>(cboDocReferencia, (from x in ListaDocumentos
                                                                       where x.indAlmacen == true || x.idDocumento == "0"
                                                                       orderby x.desDocumento
                                                                       select x).ToList(), "idDocumento", "desDocumento", false);

            // Monedas
            List<MonedasE> listaMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas);
            MonedasE monIni = new MonedasE() { idMoneda = Variables.Cero.ToString(), desMoneda = Variables.Seleccione };
            listaMonedas.Add(monIni);
            ComboHelper.LlenarCombos<MonedasE>(cbomoneda, (from x in listaMonedas
                                                           where x.idMoneda == "0"
                                                           || x.idMoneda == Variables.Soles
                                                           || x.idMoneda == Variables.Dolares
                                                           orderby x.idMoneda
                                                           select x).ToList(), "idMoneda", "desMoneda");

            //Movimientos de Almacen
            List<ParTabla> ListarTipoMovimiento = new List<ParTabla>(oListaTipoMovimientos);
            ComboHelper.RellenarCombos<ParTabla>(cboTipoMovimiento, (from x in ListarTipoMovimiento
                                                                     where (x.NemoTecnico == "EG" || x.NemoTecnico == "EGR") ||
                                                                           (x.NemoTecnico == "IN" || x.NemoTecnico == "ING")
                                                                     orderby x.IdParTabla
                                                                     select x).ToList(), "IdParTabla", "Nombre", false);

            //Almacenes
            oListaAlmacenes = new List<AlmacenE>(oListaAlmacenes);
            ComboHelper.RellenarCombos<AlmacenE>(cboAlmacen, (from x in oListaAlmacenes orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen", false);

            oAlmacenesDestino = new List<AlmacenE>(from x in oListaAlmacenes
                                                   where x.idAlmacen != Convert.ToInt32(cboAlmacen.SelectedValue)
                                                   select x).ToList();

            //Operaciones - Conceptos
            List<OperacionE> oListaOperaciones = new List<OperacionE>(oListaOp);
            ComboHelper.RellenarCombos<OperacionE>(cboConcepto, (from x in oListaOperaciones orderby x.desOperacion select x).ToList(), "idOperacion", "desOperacion", false);
            cboConcepto.SelectedValue = Variables.Cero.ToString();

            // Documentos
            List<DocumentosE> ListaDocumentosDev = new List<DocumentosE>(VariablesLocales.ListarDocumentoGeneral);
            DocumentosE FilaDev = new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione };
            ListaDocumentosDev.Add(FilaDev);

            ComboHelper.RellenarCombos<DocumentosE>(cboDocumentoDev, (from x in ListaDocumentosDev
                                                                      where x.indAlmacen == true || x.idDocumento == "0"
                                                                   orderby x.desDocumento
                                                                   select x).ToList(), "idDocumento", "desDocumento", false);

        }

        private Boolean ValidarTica()
        {
            Decimal Respuesta = Convert.ToDecimal(txttipocambio.Text);

            if (Respuesta == 0)
            {
                Global.MensajeComunicacion("Debe Agregar un Tipo De Cambio");
                return false;
            }

            return true;
        }

        private void AgregarArticulo(ArticuloServE oArticulo, string Lote, decimal Cantidad, decimal PrecioUni, decimal impVenta, decimal impTotal, Int32 idItemCompra, String idMoneda, Boolean CalculoCosto = false)
        {
            Boolean ConLote = ((AlmacenE)cboAlmacen.SelectedItem).VerificaLote;

            if (!ConLote)
            {
                for (int i = 0; i < oListaItems.Count; i++)
                {
                    if (oListaItems[i].idArticulo == oArticulo.idArticulo)
                    {
                        if (Global.MensajeConfirmacion("El Item seleccionado ya existe desea reemplazarlo") == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            oMovimientoAlmacen.ListaAlmacenItem.RemoveAt(i);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < oListaItems.Count; i++)
                {
                    if (oListaItems[i].idArticulo == oArticulo.idArticulo && oListaItems[i].Lote == oArticulo.Lote)
                    {
                        if (Global.MensajeConfirmacion("El Item seleccionado ya existe desea reemplazarlo") == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            oMovimientoAlmacen.ListaAlmacenItem.RemoveAt(i);
                        }
                    }
                }
            }

            MovimientoAlmacenItemE oNuevo = new MovimientoAlmacenItemE();

            oNuevo.idEmpresa = oMovimientoAlmacen.idEmpresa;
            oNuevo.idDocumentoAlmacen = oMovimientoAlmacen.idDocumentoAlmacen;
            oNuevo.idItem = 0;
            oNuevo.numItem = (oMovimientoAlmacen.ListaAlmacenItem.Count == 0 ? "0001" : (oMovimientoAlmacen.ListaAlmacenItem.Count + 1).ToString("0000"));
            oNuevo.idArticulo = oArticulo.idArticulo;
            oNuevo.codArticulo = oArticulo.codArticulo;
            oNuevo.nomArticulo = oArticulo.nomArticulo;
            oNuevo.Lote = oArticulo.Lote;
            oNuevo.LoteProveedor = oArticulo.LoteProveedor;
            oNuevo.idUbicacion = 0;
            oNuevo.Cantidad = Cantidad;
            oNuevo.nroEnvases = 0;
            oNuevo.indCalidad = false;
            oNuevo.indConformidad = false;
            oNuevo.idCCostos = "";
            oNuevo.idCCostosUso = "";
            oNuevo.desCCostos = "";

            if (idMoneda == Variables.Soles)
            {
                if (!CalculoCosto)
                {
                    oNuevo.ImpCostoUnitarioBase = PrecioUni;
                    oNuevo.ImpCostoUnitarioRefe = PrecioUni * Convert.ToDecimal(txttipocambio.Text);
                    oNuevo.ImpTotalBase = PrecioUni * Cantidad;
                    oNuevo.ImpTotalRefe = (PrecioUni * Convert.ToDecimal(txttipocambio.Text)) * Cantidad;
                }
                else
                {
                    oNuevo.ImpCostoUnitarioBase = PrecioUni;
                    oNuevo.ImpCostoUnitarioRefe = PrecioUni * Convert.ToDecimal(txttipocambio.Text);
                    oNuevo.ImpTotalBase = impTotal;
                    oNuevo.ImpTotalRefe = impTotal * Convert.ToDecimal(txttipocambio.Text);
                }
            }

            if (idMoneda == Variables.Dolares)
            {
                if (!CalculoCosto)
                {
                    oNuevo.ImpCostoUnitarioBase = PrecioUni * Convert.ToDecimal(txttipocambio.Text);
                    oNuevo.ImpCostoUnitarioRefe = PrecioUni;
                    oNuevo.ImpTotalBase = (PrecioUni * Convert.ToDecimal(txttipocambio.Text)) * Cantidad;
                    oNuevo.ImpTotalRefe = PrecioUni * Cantidad;
                }
                else
                {
                    oNuevo.ImpCostoUnitarioBase = PrecioUni * Convert.ToDecimal(txttipocambio.Text);
                    oNuevo.ImpCostoUnitarioRefe = PrecioUni;
                    oNuevo.ImpTotalBase = impTotal * Convert.ToDecimal(txttipocambio.Text);
                    oNuevo.ImpTotalRefe = impTotal;
                }
            }

            if (idMoneda == "")
            {
                if (CalculoCosto)
                {
                    oNuevo.ImpCostoUnitarioBase = PrecioUni;
                    oNuevo.ImpCostoUnitarioRefe = PrecioUni * Convert.ToDecimal(txttipocambio.Text);
                    oNuevo.ImpTotalBase = PrecioUni * Cantidad;
                    oNuevo.ImpTotalRefe = (PrecioUni * Convert.ToDecimal(txttipocambio.Text)) * Cantidad;
                }
                else
                {
                    oNuevo.ImpCostoUnitarioBase = PrecioUni;
                    oNuevo.ImpCostoUnitarioRefe = PrecioUni * Convert.ToDecimal(txttipocambio.Text);
                    oNuevo.ImpTotalBase = impTotal;
                    oNuevo.ImpTotalRefe = impTotal * Convert.ToDecimal(txttipocambio.Text);
                }
            }

            oNuevo.Valorizado = false;
            oNuevo.idItemCompra = idItemCompra;
            oNuevo.idArticuloUso = 0;
            oNuevo.nroParteProd = "";
            oNuevo.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            oNuevo.FechaRegistro = VariablesLocales.FechaHoy;
            oNuevo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            oNuevo.FechaModificacion = VariablesLocales.FechaHoy;

            oMovimientoAlmacen.ListaAlmacenItem.Add(oNuevo);

            bsItems.DataSource = oMovimientoAlmacen.ListaAlmacenItem;
            bsItems.ResetBindings(false);
        }

        private void DatosGrabacion()
        {
            // CARGAMOS VARIABLES
            oMovimientoAlmacen.idAlmacen = Convert.ToInt32(cboAlmacen.SelectedValue);
            oMovimientoAlmacen.tipMovimiento = Convert.ToInt32(cboTipoMovimiento.SelectedValue);
            oMovimientoAlmacen.idOperacion = Convert.ToInt32(cboConcepto.SelectedValue);
            oMovimientoAlmacen.tipAlmacen = Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen);
            oMovimientoAlmacen.fecProceso = dtpFecProceso.Value.ToString("yyyyMMdd");
            oMovimientoAlmacen.indFactura = false;

            oMovimientoAlmacen.idDocumento = cboDocumento.SelectedValue.ToString();
            oMovimientoAlmacen.serDocumento = txtSerieDoc.Text;
            oMovimientoAlmacen.numDocumento = txtNumDoc.Text;
            oMovimientoAlmacen.fecDocumento = dtpFecDocumento.Value.ToString("yyyyMMdd");
            oMovimientoAlmacen.indDocDevolucion = chkDev.Checked;

            if (chkDev.Checked)
            {
                oMovimientoAlmacen.idDocumentoDevolucion = cboDocumentoDev.SelectedValue.ToString();
                oMovimientoAlmacen.serDocumentoDevolucion = txtSerieDev.Text;
                oMovimientoAlmacen.numDocumentoDevolucion = txtNumDev.Text;
            }
            else
            {
                oMovimientoAlmacen.idDocumentoDevolucion = String.Empty;
                oMovimientoAlmacen.serDocumentoDevolucion = String.Empty;
                oMovimientoAlmacen.numDocumentoDevolucion = String.Empty;
            }

            oMovimientoAlmacen.idOrdenCompra = string.IsNullOrEmpty(txtordencompra.Text.Trim()) ? (int?)null : Convert.ToInt32(txtIdOC.Text);
            oMovimientoAlmacen.numRequisicion = string.Empty;
            oMovimientoAlmacen.Glosa = txtGlosa.Text;

            if (cboDocReferencia.SelectedValue == null)
            {
                oMovimientoAlmacen.idDocumentoRef = cboDocumento.SelectedValue.ToString();
            }
            else
            {
                oMovimientoAlmacen.idDocumentoRef = cboDocReferencia.SelectedValue.ToString();
            }

            oMovimientoAlmacen.SerieDocumentoRef = txtSerieRefe.Text;
            oMovimientoAlmacen.NumeroDocumentoRef = txtNumRefe.Text;
            oMovimientoAlmacen.idPersona = string.IsNullOrEmpty(txtIdCliente.Text.Trim()) ? (int?)null : Convert.ToInt32(txtIdCliente.Text.Trim());
            oMovimientoAlmacen.idMoneda = cbomoneda.SelectedValue.ToString();
            oMovimientoAlmacen.indCambio = chbtipo_cambio.Checked;
            oMovimientoAlmacen.tipCambio = Convert.ToDecimal(txttipocambio.Text);

            oMovimientoAlmacen.impValorVenta = Convert.ToDecimal(lblValorVentaSol.Text);
            oMovimientoAlmacen.indImpuesto = chkIgv.Checked;

            if (chkIgv.Checked)
            {
                oMovimientoAlmacen.porIgv = Convert.ToDecimal(lblIgvPor.Text);
                oMovimientoAlmacen.Impuesto = Convert.ToDecimal(lblIgvSol.Text);
            }
            else
            {
                oMovimientoAlmacen.porIgv = 0;
                oMovimientoAlmacen.Impuesto = 0;
            }

            oMovimientoAlmacen.impTotal = Convert.ToDecimal(lblImporteSol.Text);

            if (oMovimientoAlmacen.idAlmacenOrigen == null || oMovimientoAlmacen.idAlmacenOrigen == 0)
            {
                oMovimientoAlmacen.idAlmacenOrigen = 0;
            }

            if (((OperacionE)cboConcepto.SelectedItem).indTransferencia)
            {
                oMovimientoAlmacen.indPorAsociar = true;
                oMovimientoAlmacen.idAlmacenDestino = Convert.ToInt32(cboAlmacenDestino.SelectedValue);
            }
            else
            {
                oMovimientoAlmacen.indPorAsociar = false;
                oMovimientoAlmacen.idAlmacenDestino = 0;
            }

            #region Calzado

            AlmacenE oAlmacen = (AlmacenE)cboAlmacen.SelectedItem;

            if (oAlmacen.EsCalzado)
            {
                foreach (MovimientoAlmacenItemE item in oMovimientoAlmacen.ListaAlmacenItem)
                {
                    item.oLoteEntidad = null;
                }
            }

            oAlmacen = null;

            #endregion

            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oMovimientoAlmacen.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oMovimientoAlmacen.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        private void SumarTotal()
        {
            //String Mon = Convert.ToString(cbomoneda.SelectedValue);

            //if (oMovimientoAlmacen.ListaAlmacenItem != null && oMovimientoAlmacen.ListaAlmacenItem.Count > 0)
            //{
            //    lblCantidad.Text = oMovimientoAlmacen.ListaAlmacenItem.Sum(x => x.Cantidad).ToString("N2");

            //    if (Mon == Variables.Soles)
            //    {
            //        lblValorVentaSol.Text = oMovimientoAlmacen.ListaAlmacenItem.Sum(x => x.ImpTotalBase).ToString("N2");//(oMovimientoAlmacen.ListaAlmacenItem.Sum(x => x.Cantidad) * oMovimientoAlmacen.ListaAlmacenItem.Sum(x => x.ImpCostoUnitarioBase)).ToString("N2");
            //    }

            //    if (Mon == Variables.Dolares)
            //    {
            //        lblValorVentaSol.Text = oMovimientoAlmacen.ListaAlmacenItem.Sum(x => x.ImpTotalRefe).ToString("N2"); //(oMovimientoAlmacen.ListaAlmacenItem.Sum(x => x.Cantidad) * oMovimientoAlmacen.ListaAlmacenItem.Sum(x => x.ImpCostoUnitarioRefe)).ToString("N2");
            //    }
            //}
            if (oMovimientoAlmacen.ListaAlmacenItem != null && oMovimientoAlmacen.ListaAlmacenItem.Count > 0)
            {
                decimal IgvDol = 0;
                decimal IgvSol = 0;
                decimal porIgv = 0;
                decimal SubTotalSol = 0;
                decimal SubTotalDol = 0;

                if (chkIgv.Checked)
                {
                    ImpuestosPeriodoE oImpuesto = VariablesLocales.oListaImpuestos.Where(x => x.idImpuesto == 1).FirstOrDefault();//AgenteGeneral.Proxy.ObtenerImpuestosPeriodo(1, 1);
                    lblIgvPor.Text = (oImpuesto.Porcentaje).ToString("N2");
                }
                else
                {
                    lblIgvPor.Text = "0.00";
                }

                decimal.TryParse(lblIgvPor.Text, out porIgv);

                lblCantidad.Text = oMovimientoAlmacen.ListaAlmacenItem.Sum(x => x.Cantidad).ToString("N3");
                SubTotalDol = oMovimientoAlmacen.ListaAlmacenItem.Sum(x => x.ImpTotalRefe);
                SubTotalSol = oMovimientoAlmacen.ListaAlmacenItem.Sum(x => x.ImpTotalBase);
                IgvDol = SubTotalDol * (porIgv / 100);
                IgvSol = SubTotalSol * (porIgv / 100);
                lblValorVentaDol.Text = SubTotalDol.ToString("N2");
                lblValorVentaSol.Text = SubTotalSol.ToString("N2");
                lblIgvDol.Text = IgvDol.ToString("N2");
                lblIgvSol.Text = IgvSol.ToString("N2");
                lblImporteDol.Text = (SubTotalDol + IgvDol).ToString("N2");
                lblImporteSol.Text = (SubTotalSol + IgvSol).ToString("N2");
            }
        }

        private void SinOperacion()
        {
          label16.Text = "Cliente";
          txtRuc.Text = "";
          txtRazonSocial.Text = "";
          btnVerOrdenCompra.Enabled = false;
        }

        private void ValidarAuxiliar(List<Persona> oListaPersonasTmp)
        {
            if (!oListaPersonasTmp[0].Cli)
            {
                if (Global.MensajeConfirmacion("Este auxiliar no esta ingresado como Cliente. Desea agregarlo ?") == DialogResult.Yes)
                {
                    ClienteE oCliente = new ClienteE()
                    {
                        idPersona = oListaPersonasTmp[0].IdPersona,
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        SiglaComercial = oListaPersonasTmp[0].RazonSocial,
                        TipoCliente = 0,
                        fecInscripcion = (Nullable<DateTime>)null,
                        fecInicioEmpresa = (Nullable<DateTime>)null,
                        tipConstitucion = 0,
                        tipRegimen = 0,
                        catCliente = 0,
                        //idCanalVenta = CanalVenta,
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                    };

                    AgenteMaestros.Proxy.InsertarCliente(oCliente);
                }
            }
        }

        private void RecalculaColumnsDetalle()
        {
            if (oMovimientoAlmacen.ListaAlmacenItem != null && oMovimientoAlmacen.ListaAlmacenItem.Count > 0)
            {
                Decimal Cantidad = 1;
                Boolean indAjuste = ((OperacionE)cboConcepto.SelectedItem).indServicio;

                foreach (MovimientoAlmacenItemE item in oMovimientoAlmacen.ListaAlmacenItem)
                {
                    if (!indAjuste)
                    {
                        Cantidad = Convert.ToDecimal(item.Cantidad);
                    }

                    if (cbomoneda.SelectedValue.ToString() == Variables.Soles)
                    {
                        item.ImpCostoUnitarioRefe = item.ImpCostoUnitarioBase / Convert.ToDecimal(txttipocambio.Text);

                        item.ImpTotalBase = item.ImpCostoUnitarioBase * Cantidad;
                        item.ImpTotalRefe = item.ImpCostoUnitarioRefe * Cantidad;
                    }
                    else if (cbomoneda.SelectedValue.ToString() == Variables.Dolares)
                    {
                        item.ImpCostoUnitarioBase = item.ImpCostoUnitarioRefe * Convert.ToDecimal(txttipocambio.Text);
 
                        item.ImpTotalBase = item.ImpCostoUnitarioBase * Cantidad;
                        item.ImpTotalRefe = item.ImpCostoUnitarioRefe * Cantidad;
                    }
                }

                bsItems.DataSource = oMovimientoAlmacen.ListaAlmacenItem;
                bsItems.ResetBindings(false);
                SumarTotal();
            }
        }

        private void InsertarExcel(String Ruta)
        {
            FileInfo oFi_ = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(oFi_))
            {
                //Entidad
                MovimientoAlmacenItemE oMovAlmItem = null;
                //Excel
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets[1];
                //Para el recorrido del excel
                Int32 totFilasExcel = oHoja.Dimension.Rows;//oHoja.Dimension.End.Row;
                String Mensaje = String.Empty;

                //Recorriendo la hoja excel hasta el total de fila obtenido...
                for (int f = 2; f <= totFilasExcel; f++)
                {
                    if (oHoja.Cells[f, 1].Value.ToString() != String.Empty)
                    {
                        ArticuloServE oArtServ = AgenteMaestros.Proxy.ObtenerArticuloPorCodArticulo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, (oHoja.Cells[f, 1].Value).ToString().Substring(0, 8));

                        if (oArtServ != null)
                        {
                            //String ultimo = (oHoja.Cells[f, 1].Value).ToString();
                            //String Equival = ultimo.Substring(8, 2);
                            //SeriesNumeroE oSeriesNum = AgenteMaestros.Proxy.ObtenerSeriesNumeroPorSerieEquivalente(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(oArtServ.codSerie), Equival);

                            //if (oSeriesNum != null)
                            //{
                            oMovAlmItem = new MovimientoAlmacenItemE()
                            {
                                idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                idDocumentoAlmacen = oMovimientoAlmacen.idDocumentoAlmacen,
                                idItem = 0,
                                numItem = (oMovimientoAlmacen.ListaAlmacenItem.Count == 0 ? "0001" : (oMovimientoAlmacen.ListaAlmacenItem.Count + 1).ToString("0000")),
                                idArticulo = oArtServ.idArticulo,
                                codArticulo = oArtServ.codArticulo,
                                nomArticulo = oArtServ.nomArticulo,
                                Lote = "0",
                                idUbicacion = 0,
                                Cantidad = Convert.ToInt32(oHoja.Cells[f, 2].Value),
                                nroEnvases = 0,
                                indCalidad = false,
                                indConformidad = false,
                                idCCostos = String.Empty,
                                idCCostosUso = String.Empty,
                                desCCostos = String.Empty,
                                codSerie = 0,//Convert.ToInt32(oArtServ.codSerie),
                                ImpCostoUnitarioBase = Convert.ToInt32(oHoja.Cells[f, 3].Value),
                                ImpCostoUnitarioRefe = 0,
                                ImpTotalBase = 0,
                                ImpTotalRefe = 0,
                                Valorizado = false,
                                idItemCompra = null,
                                idArticuloUso = 0,
                                nroParteProd = "",
                                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                                FechaRegistro = VariablesLocales.FechaHoy,
                                UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                                FechaModificacion = VariablesLocales.FechaHoy,
                                oLoteEntidad = null
                            };

                            if (cbomoneda.SelectedValue.ToString() == Variables.Soles)
                            {
                                oMovAlmItem.ImpCostoUnitarioBase = Convert.ToInt32(oHoja.Cells[f, 3].Value);
                                oMovAlmItem.ImpTotalBase = oMovAlmItem.ImpCostoUnitarioBase * oMovAlmItem.Cantidad;
                                if (chbtipo_cambio.Checked == true)
                                {
                                    oMovAlmItem.ImpCostoUnitarioRefe = oMovAlmItem.ImpCostoUnitarioBase * Convert.ToDecimal(txttipocambio.Text);
                                    oMovAlmItem.ImpTotalRefe = oMovAlmItem.ImpCostoUnitarioRefe * oMovAlmItem.Cantidad;
                                }
                            }
                            else
                            {
                                oMovAlmItem.ImpCostoUnitarioRefe = Convert.ToInt32(oHoja.Cells[f, 3].Value);
                                oMovAlmItem.ImpTotalRefe = oMovAlmItem.ImpCostoUnitarioRefe * oMovAlmItem.Cantidad;
                                if (chbtipo_cambio.Checked == true)
                                {
                                    oMovAlmItem.ImpCostoUnitarioBase = oMovAlmItem.ImpCostoUnitarioRefe / Convert.ToDecimal(txttipocambio.Text);
                                    oMovAlmItem.ImpTotalBase = oMovAlmItem.ImpCostoUnitarioRefe * oMovAlmItem.Cantidad;
                                }
                            }

                            oMovimientoAlmacen.ListaAlmacenItem.Add(oMovAlmItem);
                            //}
                            //else
                            //{
                            //    Mensaje = Equival;
                            //    Global.MensajeComunicacion("Codigo Serie " + Mensaje + " No Encontrado Vuelva a Cargar El Excel");
                            //    btExaminar.Enabled = true;
                            //    btAgregar.Enabled = false;
                            //    break;
                            //}
                        }
                        else
                        {
                            Mensaje = (oHoja.Cells[f, 1].Value).ToString().Substring(0, 8);
                            Global.MensajeComunicacion("Codigo " + Mensaje + " No Encontrado Vuelva a Cargar El Excel");
                            btExaminar.Enabled = true;
                            btAgregar.Enabled = false;
                            break;
                        }
                    }
                    else
                    {
                        Global.MensajeComunicacion(" Codigo Barra No Existente Vuelva a Cargar El Excel");
                        btExaminar.Enabled = true;
                        btAgregar.Enabled = false;
                        break;
                    }
                }
                if (Mensaje == String.Empty)
                {
                    bsItems.DataSource = oMovimientoAlmacen.ListaAlmacenItem;
                    bsItems.ResetBindings(false);
                }
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (oMovimientoAlmacen == null)
                {
                    oMovimientoAlmacen = new MovimientoAlmacenE
                    {
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        indAutomatico = false
                    };

                    cboAlmacen.SelectedValue = idAlmacen;
                    cboTipoMovimiento.SelectedValue = idTipoMovimiento;
                    cboConcepto.SelectedValue = idOperacion;
                    cbomoneda.SelectedValue = Variables.Soles;

                    if (VariablesLocales.TipoCambioDelDia != null)
                    {
                        txttipocambio.Text = VariablesLocales.TipoCambioDelDia.valVenta.ToString("N3");
                    }
                    else
                    {
                        Global.MensajeComunicacion("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el Tipo de Cambio del dia.");
                        txttipocambio.Text = "0.000";
                    }

                    oMovimientoAlmacen.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    Opcion = (Int32)EnumOpcionGrabar.Insertar;

                    cboConcepto_SelectionChangeCommitted(new object(), new EventArgs());

                    oAlmacenesDestino = new List<AlmacenE>(from x in oListaAlmacenes
                                                           where x.idAlmacen != Convert.ToInt32(cboAlmacen.SelectedValue)
                                                           select x).ToList();
                }
                else
                {
                    dtpFecDocumento.ValueChanged -= dtpFecDocumento_ValueChanged;
                    chbtipo_cambio.CheckedChanged -= chbtipo_cambio_CheckedChanged;
                    chkIgv.CheckedChanged -= chkIgv_CheckedChanged;

                    cboAlmacen.SelectedValue = Convert.ToInt32(oMovimientoAlmacen.idAlmacen);
                    cboTipoMovimiento.SelectedValue = Convert.ToInt32(oMovimientoAlmacen.tipMovimiento);
                    txtnumCorrelativo.Text = oMovimientoAlmacen.numCorrelativo;
                    dtpFecProceso.Value = Convert.ToDateTime(oMovimientoAlmacen.fecProceso);
                    cboConcepto.SelectedValue = oMovimientoAlmacen.idOperacion;
                    cboConcepto_SelectionChangeCommitted(new object(), new EventArgs());
                    txtIdOC.Text = oMovimientoAlmacen.idOrdenCompra.ToString();
                    txtordencompra.Text = oMovimientoAlmacen.numOrdenCompra;

                    if (oMovimientoAlmacen.idAlmacenDestino != 0)
                    {
                        cboAlmacenDestino.SelectedValue = oMovimientoAlmacen.idAlmacenDestino;
                    }

                    if (oMovimientoAlmacen.idPersona != 0)
                    {
                        txtIdCliente.Text = oMovimientoAlmacen.idPersona.ToString();
                    }
                    else
                    {
                        txtIdCliente.Text = String.Empty;
                    }

                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    txtRuc.Text = oMovimientoAlmacen.ruc;
                    txtRazonSocial.Text = oMovimientoAlmacen.RazonSocial;
                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;

                    txtGlosa.Text = oMovimientoAlmacen.Glosa;
                    cboDocumento.SelectedValue = oMovimientoAlmacen.idDocumento;
                    txtSerieDoc.Text = oMovimientoAlmacen.serDocumento;
                    txtNumDoc.Text = oMovimientoAlmacen.numDocumento;
                    chkDev.Checked = oMovimientoAlmacen.indDocDevolucion;

                    if (oMovimientoAlmacen.indDocDevolucion)
                    {
                        cboDocumentoDev.SelectedValue = oMovimientoAlmacen.idDocumentoDevolucion;
                        txtSerieDev.Text = oMovimientoAlmacen.serDocumentoDevolucion;
                        txtNumDev.Text = oMovimientoAlmacen.numDocumentoDevolucion;
                    }

                    if (!string.IsNullOrWhiteSpace(oMovimientoAlmacen.fecDocumento))
                    {
                        dtpFecDocumento.Value = Convert.ToDateTime(oMovimientoAlmacen.fecDocumento);
                    }
                    
                    cboDocReferencia.SelectedValue = oMovimientoAlmacen.idDocumentoRef;
                    txtSerieRefe.Text = oMovimientoAlmacen.SerieDocumentoRef;
                    txtNumRefe.Text = oMovimientoAlmacen.NumeroDocumentoRef;
                    cbomoneda.SelectedValue = oMovimientoAlmacen.idMoneda.ToString();
                    chbtipo_cambio.Checked = oMovimientoAlmacen.indCambio;
                    txttipocambio.Text = oMovimientoAlmacen.tipCambio.ToString("N3");
                    chkIgv.Checked = oMovimientoAlmacen.indImpuesto;

                    Opcion = (Int32)EnumOpcionGrabar.Actualizar;

                    SumarTotal();

                    dtpFecDocumento.ValueChanged += dtpFecDocumento_ValueChanged;
                    chbtipo_cambio.CheckedChanged += chbtipo_cambio_CheckedChanged;
                    chkIgv.CheckedChanged += chkIgv_CheckedChanged;

                    oAlmacenesDestino = new List<AlmacenE>(from x in oListaAlmacenes
                                                           where x.idAlmacen != Convert.ToInt32(cboAlmacen.SelectedValue)
                                                           select x).ToList();
                }

                bsItems.DataSource = oMovimientoAlmacen.ListaAlmacenItem;
                bsItems.ResetBindings(false);

                if (oMovimientoAlmacen.indEstado == "AN")
                {
                    Global.MensajeComunicacion("El movimiento ha sido anulado no podra hacer ninguna modificación.");
                    pnlPrincipales.Enabled = false;
                    pnlFactura.Enabled = false;
                    pnlReferencia.Enabled = false;
                    pnlTica.Enabled = false;
                    pnlDetalle.Enabled = false;
                }
                else
                {
                    if (oMovimientoAlmacen.indAutomatico)
                    {
                        pnlPrincipales.Enabled = false;
                        pnlFactura.Enabled = false;
                        pnlReferencia.Enabled = false;
                        pnlTica.Enabled = false;
                        pnlDetalle.Enabled = false;
                        BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                        Global.MensajeComunicacion("El movimiento es Automático, no podrá hacer ninguna modificación.");
                        return;
                    }

                    PeriodosAlmE PeriodoAlmacen = AgenteAlmacen.Proxy.ObtenerPeriodoPorMesAlm(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToDateTime(oMovimientoAlmacen.fecProceso).ToString("yyyy"), Convert.ToDateTime(oMovimientoAlmacen.fecProceso).ToString("MM"));

                    if (PeriodoAlmacen != null)
                    {
                        if (PeriodoAlmacen.indCierre)
                        {
                            pnlPrincipales.Enabled = false;
                            pnlFactura.Enabled = false;
                            pnlReferencia.Enabled = false;
                            pnlTica.Enabled = false;
                            pnlDetalle.Enabled = false;
                            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                            Global.MensajeComunicacion("El periodo se encuentra cerrado no podrá hacer modificaciones.");
                            return;
                        }
                    }

                    base.Nuevo();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                if (bsItems.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        if (oMovimientoAlmacen.idDocumentoAlmacen == 0)
                        {
                            oListaItems.RemoveAt(bsItems.Position);
                            bsItems.DataSource = oListaItems;
                            bsItems.ResetBindings(false);
                        }
                        else
                        {
                            oListaItems[bsItems.Position].FechaAnula = VariablesLocales.FechaHoy;
                            oListaItems[bsItems.Position].UsuarioAnula = VariablesLocales.SesionUsuario.Credencial;
                            bsItems.DataSource = oListaItems;
                            bsItems.ResetBindings(false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Grabar()
        {
            try
            {
                if (dgvitems.IsCurrentCellDirty)
                {
                    dgvitems.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }

                if (ValidarGrabacion())
                {
                    //// VERIFICA MES CERRADO
                    //List<PeriodosAlmE> oListaPeridoValida = AgenteAlmacen.Proxy.ListarPeriodosAlm(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.PeriodoContable.AnioPeriodo);

                    //foreach (PeriodosAlmE oItemValida in oListaPeridoValida)
                    //{
                    //    if (Convert.ToInt32( oItemValida.MesPeriodo ) ==  dtpFecProceso.Value.Month && oItemValida.indCierre)
                    //    {
                    //        Global.MensajeFault("Sistema Bloqueado, " + oItemValida.desPeriodo + " esta Cerrado");
                    //        return;
                    //    }
                    //}

                    if (!ValidarTica())
                    {
                        return;
                    }

                    DatosGrabacion();

                    if (((OperacionE)cboConcepto.SelectedItem).indDevolucion)
                    {
                        oOrdenCompra = null;
                    }

                    if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        AgenteAlmacen.Proxy.GuardarMovimientoAlmacen(oMovimientoAlmacen, EnumOpcionGrabar.Insertar, oOrdenCompra);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                    else
                    {
                        oMovimientoAlmacen.ListaAlmacenItemEliminado = itemEliminados;
                        AgenteAlmacen.Proxy.GuardarMovimientoAlmacen(oMovimientoAlmacen, EnumOpcionGrabar.Actualizar, oOrdenCompra);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }

                    base.Grabar();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (bsItems.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        base.QuitarDetalle();

                        itemEliminados.Add((MovimientoAlmacenItemE)bsItems.Current);
                        oMovimientoAlmacen.ListaAlmacenItem.RemoveAt(bsItems.Position);

                        bsItems.DataSource = oMovimientoAlmacen.ListaAlmacenItem;
                        bsItems.ResetBindings(false);

                        SumarTotal();

                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void AgregarDetalle()
        {
            try
            {
                if (!ValidarTica())
                {
                    return;
                }

                AlmacenE oAlmacen = (AlmacenE)cboAlmacen.SelectedItem;
                frmBuscarArticulo oFrm = new frmBuscarArticulo(oAlmacen, "stock", dtpFecProceso.Value.ToString("yyyy"), dtpFecProceso.Value.ToString("MM")); //ArtAlmacen
                oListaItems = new List<MovimientoAlmacenItemE>(oMovimientoAlmacen.ListaAlmacenItem);

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    Boolean indAjuste = ((OperacionE)cboConcepto.SelectedItem).indServicio;

                    if (oFrm.Articulo != null)
                    {
                        ArticuloServE oItemDetalle = oFrm.Articulo;

                        if (oAlmacen.VerificaLote)
                        {
                            AgregarArticulo(oItemDetalle, "", (indAjuste == true ? 0 : 1), 0, 0, 0, 0, "");
                        }
                        else
                        {
                            AgregarArticulo(oItemDetalle, "0000000", (indAjuste == true ? 0 : 1), 0, 0, 0, 0, "");
                        }
                    }
                    else
                    {
                        if (oFrm.oListaArticulosVarios != null && oFrm.oListaArticulosVarios.Count > Variables.Cero)
                        {
                            foreach (ArticuloServE item in oFrm.oListaArticulosVarios)
                            {
                                if (oAlmacen.VerificaLote)
                                {
                                    AgregarArticulo(item, "", (indAjuste == true ? 0 : 1), 0, 0, 0, 0, "");
                                }
                                else
                                {
                                    AgregarArticulo(item, "0000000", (indAjuste == true ? 0 : 1), 0, 0, 0, 0, "");
                                }
                            }
                        }
                    }

                    base.AgregarDetalle();


                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            if (cboAlmacen.SelectedValue.ToString() == "0")
            {
                Global.MensajeFault("Debe de seleccionar un Almacen");
                return false;
            }

            if (cboTipoMovimiento.SelectedValue.ToString() == "0")
            {
                Global.MensajeFault("Debe de seleccionar el Tipo de movimiento");
                return false;
            }

            if (cboConcepto.SelectedValue.ToString() == "0")
            {
                Global.MensajeFault("Debe de seleccionar una Operacion");
                return false;
            }

            if (oMovimientoAlmacen.ListaAlmacenItem != null && oMovimientoAlmacen.ListaAlmacenItem.Count == 0)
            {
                Global.MensajeFault("Debe de agregar Items");
                return false;
            }

            #region Validaciones de Tipo de Operación

            OperacionE operacion = (OperacionE)cboConcepto.SelectedItem;

            if (operacion.indTransferencia)
            {
                if (cboAlmacenDestino.SelectedValue == null)
                {
                    Global.MensajeFault("La operación escogida solicita transferencia, tiene que colocar un almacén de destino.");
                    return false;
                }
                else
                {
                    if (Convert.ToInt32(cboAlmacenDestino.SelectedValue) == 0)
                    {
                        Global.MensajeFault("La operación escogida solicita transferencia, tiene que colocar un almacén de destino.");
                        return false;
                    }
                }
            }

            if (operacion.indTransferencia)
            {
                if (((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen != ((AlmacenE)cboAlmacenDestino.SelectedItem).tipAlmacen)
                {
                    Global.MensajeFault("Los almacenes tienen que tener el mismo tipo de articulo.");
                    return false;
                }
            }

            if (operacion.indDocumento)
            {
                if (cboDocumento.SelectedValue.ToString() == "0")
                {
                    Global.MensajeFault("El tipo de operación exige un tipo de documento.");
                    cboDocumento.Focus();
                    return false;
                }

                if (String.IsNullOrEmpty(txtSerieDoc.Text))
                {
                    Global.MensajeFault("El tipo de operación exige la serie del documento.");
                    txtSerieDoc.Focus();
                    return false;
                }

                if (String.IsNullOrEmpty(txtNumDoc.Text))
                {
                    Global.MensajeFault("El tipo de operación exige el número del documento.");
                    txtNumDoc.Focus();
                    return false;
                }
            }

            if (operacion.indReferencia)
            {
                if (cboDocReferencia.SelectedValue.ToString() == "0")
                {
                    Global.MensajeFault("El tipo de operación exige un tipo de documento de referencia.");
                    cboDocumento.Focus();
                    return false;
                }

                if (String.IsNullOrEmpty(txtSerieRefe.Text))
                {
                    Global.MensajeFault("El tipo de operación exige la serie del documento de referencia.");
                    txtSerieDoc.Focus();
                    return false;
                }

                if (String.IsNullOrEmpty(txtNumRefe.Text))
                {
                    Global.MensajeFault("El tipo de operación exige el número del documento de referencia.");
                    txtNumDoc.Focus();
                    return false;
                }
            } 

            #endregion

            Boolean ConLote = ((AlmacenE)cboAlmacen.SelectedItem).VerificaLote;

            if (ConLote)
            {
                foreach (MovimientoAlmacenItemE item in oMovimientoAlmacen.ListaAlmacenItem)
                {
                    if (item.Lote == "0000000" || String.IsNullOrWhiteSpace(item.Lote))
                    {
                        Global.MensajeFault("El almacén exige Lote, tiene que colocarlo");
                        return false;
                    }
                }
            }

            return base.ValidarGrabacion();
        }

        private void ExportarExcel(String Ruta)
        {

            String NombrePestaña = String.Empty;
            NombrePestaña = " REPORTE FORMATO DE SALIDA ";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 1;



                    #region Cabeceras del Detalle

                    oHoja.Cells[InicioLinea, 1].Value = " Código Barra";
                    oHoja.Cells[InicioLinea, 2].Value = " Cantidad ";
                    oHoja.Cells[InicioLinea, 3].Value = " Costo Unit. ";

                    for (int i = 1; i <= 3; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;


                    #endregion



                    foreach (MovimientoAlmacenItemE item in oMovimientoAlmacen.ListaAlmacenItem)
                    {
                        oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 1].Value = item.codArticulo.ToString() + item.Lote.Substring(0, 2);
                        oHoja.Cells[InicioLinea, 2].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 2].Value = item.Cantidad;
                        oHoja.Cells[InicioLinea, 3].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 3].Value = item.ImpCostoUnitarioBase;

                        oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";

                        InicioLinea++;
                    }



                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns(0);

                    //Insertando Encabezado
                    oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + "Formato De Salida";
                    //Pie de Pagina(Derecho) "Número de paginas y el total"
                    oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                    //Pie de Pagina(centro)
                    oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                    //Otras Propiedades
                    oHoja.Workbook.Properties.Title = "Formato De Salida";
                    oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                    oHoja.Workbook.Properties.Subject = "Reportes";
                    //oHoja.Workbook.Properties.Keywords = "";
                    oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
                    oHoja.Workbook.Properties.Comments = NombrePestaña;

                    // Establecer algunos valores de las propiedades extendidas
                    oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                    //Propiedades para imprimir
                    oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A3;

                    //Guardando el excel
                    oExcel.Save();
                }
            }
        }

        #endregion

        #region Eventos

        private void frmSalidaAlmacenesEditar_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
                BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);

                LlenarCombos();
                Nuevo();

                if (((AlmacenE)cboAlmacen.SelectedItem).VerificaLote)
                {
                    if (VariablesLocales.SesionUsuario.Empresa.RUC == "20502647009" || //AgroGenesis
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20523020561" || //Huerto Genesis
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20517933318" || //Vivero Genesis
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20552695217" || //Jeritec
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20552186681" || //A Y V SEEDS CO. S.A.C.
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20552690410" || //POWER SEEDS S.A.C
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20513078952")   //NOVA SEEDS
                    {
                        //Lote Proveedor
                        dgvitems.Columns[7].Visible = true;
                    }
                    else
                    {
                        //Lote Indusoft
                        dgvitems.Columns[6].Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void chbtipo_cambio_CheckedChanged(object sender, EventArgs e)
        {
            if (chbtipo_cambio.Checked)
            {
                txttipocambio.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                dtpFecDocumento_ValueChanged(null, null);
            }
            else
            {
                txttipocambio.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
                txttipocambio.Text = "0.000";
            }
        }               

        private void dgvitems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Elimina el mensaje de error de la cabecera de la fila
                dgvitems.Rows[e.RowIndex].ErrorText = String.Empty;
                SumarTotal();
                YaEntro = false;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvitems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvitems.Columns[e.ColumnIndex].Name == "LoteGV" || dgvitems.Columns[e.ColumnIndex].Name == "LoteProveedor")
                {
                    if (!((AlmacenE)cboAlmacen.SelectedItem).VerificaLote)
                    {
                        Global.MensajeFault("Este almacén no maneja Lote para sus Artículos...");
                        return;
                    }

                    frmBuscarLoteArticulo oFrm = new frmBuscarLoteArticulo(((MovimientoAlmacenItemE)bsItems.Current).idEmpresa, Convert.ToInt32(cboAlmacen.SelectedValue), 
                                                                            Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen), ((MovimientoAlmacenItemE)bsItems.Current).idArticulo, 
                                                                            dtpFecProceso.Value.ToString("yyyy"), dtpFecProceso.Value.ToString("MM"), 
                                                                            ((AlmacenE)cboAlmacen.SelectedItem).VerificaLote);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oStock != null)
                    {
                        ((MovimientoAlmacenItemE)bsItems.Current).Lote = oFrm.oStock.Lote;
                        ((MovimientoAlmacenItemE)bsItems.Current).LoteProveedor = oFrm.oStock.LoteProveedor;
                        bsItems.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cbomoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgvitems.Refresh();
        }

        private void dgvitems_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Validando la columna de Cantidad y los costos para que acepte solo números
                if (dgvitems.Rows.Count > 0)
                {
                    if (dgvitems.CurrentCell.ColumnIndex == 5 || dgvitems.CurrentCell.ColumnIndex == 8 || dgvitems.CurrentCell.ColumnIndex == 9)
                    {
                        if (e.KeyChar == (char)Keys.Back || char.IsNumber(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvitems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgvitems.CurrentCell.ColumnIndex == 5 || dgvitems.CurrentCell.ColumnIndex == 8 || dgvitems.CurrentCell.ColumnIndex == 9)
                {
                    TextBox txt = e.Control as TextBox;

                    if (txt != null)
                    {
                        txt.KeyPress -= new KeyPressEventHandler(dgvitems_KeyPress);
                        txt.KeyPress += new KeyPressEventHandler(dgvitems_KeyPress);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvitems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
                {
                    dgvitems.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dtpFecDocumento_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime Fecha = dtpFecDocumento.Value;
                TipoCambioE Tica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, Fecha.ToString("yyyyMMdd"));

                if (Tica != null)
                {
                    txttipocambio.Text = Tica.valVenta.ToString("N3");
                    RecalculaColumnsDetalle();
                }
                else
                {
                    txttipocambio.Text = Variables.ValorCeroDecimal.ToString("N3");
                    dtpFecDocumento.Focus();
                    Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRuc.Text.Trim()) && string.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdCliente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtIdCliente.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtRazonSocial.Text = String.Empty;
            txtIdCliente.Text = String.Empty;
        }

        private void txtRazonSocial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && string.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdCliente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtIdCliente.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtIdCliente.Text = string.Empty;
            txtRuc.Text = string.Empty;
        }

        private void txttipocambio_Leave(object sender, EventArgs e)
        {
            try
            {
                txttipocambio.Text = Global.FormatoDecimal(txttipocambio.Text, 3);
                RecalculaColumnsDetalle();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txttipocambio_MouseClick(object sender, MouseEventArgs e)
        {
            txttipocambio.SeleccinarTodo();
        }

        private void txttipocambio_Enter(object sender, EventArgs e)
        {
            txttipocambio.SeleccinarTodo();
        }

        private void cboConcepto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboConcepto.SelectedValue != null)
                {
                    if (Convert.ToInt32(cboConcepto.SelectedValue) != 0)
                    {
                        if (((OperacionE)cboConcepto.SelectedItem).indCliente)
                        {
                            label16.Text = "Cliente";
                            txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
                            txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
                        }
                        else
                        {
                            txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                            txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                        }

                        if (((OperacionE)cboConcepto.SelectedItem).indOrdenCompra)
                        {
                            btnVerOrdenCompra.Enabled = true;
                        }
                        else
                        {
                            btnVerOrdenCompra.Enabled = false;
                        }

                        if (((OperacionE)cboConcepto.SelectedItem).indTransferencia)
                        {

                            oAlmacenesDestino = new List<AlmacenE>(from x in oListaAlmacenes
                                                                   where x.idAlmacen != Convert.ToInt32(cboAlmacen.SelectedValue)
                                                                   select x).ToList();

                            cboAlmacenDestino.Enabled = true;
                            ComboHelper.RellenarCombos<AlmacenE>(cboAlmacenDestino, (from x in oAlmacenesDestino
                                                                                     orderby x.idAlmacen
                                                                                     select x).ToList(), "idAlmacen", "desAlmacen", false);
                        }
                        else
                        {
                            cboAlmacenDestino.Enabled = false;
                            cboAlmacenDestino.DataSource = null;
                        }

                        if (((OperacionE)cboConcepto.SelectedItem).indServicio) //Ajuste de Costo
                        {
                            if (oMovimientoAlmacen.ListaAlmacenItem.Count > 0)
                            {
                                foreach (MovimientoAlmacenItemE item in oMovimientoAlmacen.ListaAlmacenItem)
                                {
                                    item.Cantidad = 0;
                                }

                                RecalculaColumnsDetalle();
                            }
                        }


                        if (((OperacionE)cboConcepto.SelectedItem).indDevolucion) // Si necesita indica Devolucion
                        {
                            pnlDevol.Visible = true;
                            btnVerNotaCredito.Visible = true;
                        }
                        else
                        {
                            pnlDevol.Visible = false;
                            btnVerNotaCredito.Visible = false;
                        }


                    }
                    else
                    {
                        SinOperacion();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvitems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    String nomColumn = dgvitems.Columns[e.ColumnIndex].Name;
                    String Moneda = Convert.ToString(cbomoneda.SelectedValue);
                    Boolean indAjuste = ((OperacionE)cboConcepto.SelectedItem).indServicio;

                    if (nomColumn == "Cantidad" || nomColumn == "impCostoUnitarioBase" || nomColumn == "impCostoUnitarioRefe")
                    {
                        if (nomColumn == "Cantidad")
                        {
                            if (!indAjuste)
                            {
                                dgvitems.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                                e.CellStyle.BackColor = Color.Bisque;
                            }
                            else
                            {
                                dgvitems.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                                e.CellStyle.BackColor = Color.PaleTurquoise;
                            }
                        }

                        if (nomColumn == "impCostoUnitarioBase")
                        {
                            if (Moneda == Variables.Soles)
                            {
                                dgvitems.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                                e.CellStyle.BackColor = Color.Bisque;
                            }
                            else
                            {
                                dgvitems.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                                e.CellStyle.BackColor = Color.PaleTurquoise;
                            }
                        }

                        if (nomColumn == "impCostoUnitarioRefe")
                        {
                            if (Moneda == Variables.Dolares)
                            {
                                dgvitems.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                                e.CellStyle.BackColor = Color.Bisque;
                            }
                            else
                            {
                                dgvitems.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                                e.CellStyle.BackColor = Color.PaleTurquoise;
                            }
                        }
                    }
                    else
                    {
                        dgvitems.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                        e.CellStyle.BackColor = Color.PaleTurquoise;
                    }

                    // Colum Total S/.
                    if (nomColumn == "impTotalBase")
                    {
                        if (Moneda == Variables.Soles)
                        {
                            e.CellStyle.BackColor = Color.Bisque;
                        }
                        else
                        {
                            e.CellStyle.BackColor = Color.PaleTurquoise;
                        }
                    }

                    if (nomColumn == "impTotalRefe")
                    {
                        if (Moneda == Variables.Dolares)
                        {
                            e.CellStyle.BackColor = Color.Bisque;
                        }
                        else
                        {
                            e.CellStyle.BackColor = Color.PaleTurquoise;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvitems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (dgvitems.Columns[e.ColumnIndex].Name == "Cantidad" || dgvitems.Columns[e.ColumnIndex].Name == "impCostoUnitarioBase")
                {
                    //
                    // Si el campo esta vacio no lo marco como error
                    //
                    if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        return;

                    //
                    // Solo se valida ante el ingreso de un valor en el campo
                    //
                    decimal pedido = 0;

                    if (!decimal.TryParse(e.FormattedValue.ToString(), out pedido))
                    {
                        Global.MensajeFault("Valor incorrecto");

                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvitems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvitems.Rows.Count > Variables.Cero)
                {
                    Decimal Cantidad = 1;
                    Decimal CostoUnitario = Variables.ValorCeroDecimal;
                    Boolean indAjuste = ((OperacionE)cboConcepto.SelectedItem).indServicio;

                    #region Cuando se cambia la Cantidad

                    if (!YaEntro)
                    {
                        if (dgvitems.Columns[e.ColumnIndex].Name == "Cantidad")
                        {
                            String Moneda = Convert.ToString(cbomoneda.SelectedValue);
                            
                            if (!indAjuste)
                            {
                                Cantidad = Convert.ToDecimal(dgvitems.Rows[e.RowIndex].Cells["Cantidad"].Value);
                            }

                            if (Moneda == Variables.Soles)
                            {
                                // Multiplicando el total moneda soles
                                DataGridViewCell cellUnitario = dgvitems.Rows[e.RowIndex].Cells["ImpCostoUnitarioBase"];
                                DataGridViewCell cellTotal = dgvitems.Rows[e.RowIndex].Cells["ImpTotalBase"];

                                Decimal.TryParse(Convert.ToString(cellUnitario.Value), out CostoUnitario);
                                Decimal Total = (Cantidad * CostoUnitario);
                                cellTotal.Value = Total;

                                // Multiplicando el total moneda extranjera
                                DataGridViewCell cellUnitarioRefe = dgvitems.Rows[e.RowIndex].Cells["ImpCostoUnitarioRefe"];
                                DataGridViewCell cellTotalRefe = dgvitems.Rows[e.RowIndex].Cells["ImpTotalRefe"];
                                Decimal CostoUnitarioRefe = Variables.ValorCeroDecimal;
                                Decimal.TryParse(Convert.ToString(cellUnitarioRefe.Value), out CostoUnitarioRefe);
                                Decimal TotalRefe = (Cantidad * CostoUnitarioRefe);
                                cellTotalRefe.Value = TotalRefe;
                            }
                            else
                            {
                                DataGridViewCell cellUnitario = dgvitems.Rows[e.RowIndex].Cells["ImpCostoUnitarioRefe"];
                                DataGridViewCell cellTotal = dgvitems.Rows[e.RowIndex].Cells["ImpTotalRefe"];
                                
                                Decimal.TryParse(Convert.ToString(cellUnitario.Value), out CostoUnitario);
                                Decimal Total = (Cantidad * CostoUnitario);
                                cellTotal.Value = Total;
                                // Multiplicando el total moneda base
                                DataGridViewCell cellUnitarioBase = dgvitems.Rows[e.RowIndex].Cells["ImpCostoUnitarioBase"];
                                DataGridViewCell cellTotalBase = dgvitems.Rows[e.RowIndex].Cells["ImpTotalBase"];
                                Decimal CostoUnitarioBase = Variables.ValorCeroDecimal;
                                Decimal.TryParse(Convert.ToString(cellUnitarioBase.Value), out CostoUnitarioBase);
                                Decimal TotalBase = (Cantidad * CostoUnitarioBase);
                                cellTotalBase.Value = TotalBase;
                            }

                            YaEntro = true;
                            SumarTotal();
                        }
                    }

                    #endregion

                    #region Cuando se cambia el Precio Unitario Soles

                    if (!YaEntro)
                    {
                        if (dgvitems.Columns[e.ColumnIndex].Name == "impCostoUnitarioBase")
                        {
                            Decimal TipoCambio = Variables.ValorCeroDecimal;
                            Decimal.TryParse(txttipocambio.Text, out TipoCambio);

                            if (!indAjuste)
                            {
                                Cantidad = Convert.ToDecimal(dgvitems.Rows[e.RowIndex].Cells["Cantidad"].Value);
                            }

                            DataGridViewCell cellUnitario = dgvitems.Rows[e.RowIndex].Cells["ImpCostoUnitarioBase"];
                            DataGridViewCell cellTotal = dgvitems.Rows[e.RowIndex].Cells["ImpTotalBase"];
                            Decimal.TryParse(Convert.ToString(cellUnitario.Value), out CostoUnitario);
                            Decimal Total = (Cantidad * CostoUnitario);
                            cellTotal.Value = Total;

                            DataGridViewCell cellUnitarioRefe = dgvitems.Rows[e.RowIndex].Cells["ImpCostoUnitarioRefe"];
                            DataGridViewCell cellTotalRefe = dgvitems.Rows[e.RowIndex].Cells["ImpTotalRefe"];
                            cellUnitarioRefe.Value = (CostoUnitario / TipoCambio);

                            Decimal CostoUnitarioRefe = Variables.ValorCeroDecimal;
                            Decimal.TryParse(Convert.ToString(cellUnitarioRefe.Value), out CostoUnitarioRefe);
                            Decimal TotalRefe = (Cantidad * CostoUnitarioRefe);
                            cellTotalRefe.Value = TotalRefe;
                        }
                    }

                    #endregion

                    #region Cuando se cambia el Precio Unitario Dolares

                    if (!YaEntro)
                    {
                        if (dgvitems.Columns[e.ColumnIndex].Name == "impCostoUnitarioRefe")
                        {
                            Decimal TipoCambio = Variables.ValorCeroDecimal;
                            Decimal.TryParse(txttipocambio.Text, out TipoCambio);

                            if (!indAjuste)
                            {
                                Cantidad = Convert.ToDecimal(dgvitems.Rows[e.RowIndex].Cells["Cantidad"].Value);
                            }

                            DataGridViewCell cellUnitarioRefe = dgvitems.Rows[e.RowIndex].Cells["ImpCostoUnitarioRefe"];
                            DataGridViewCell cellTotalRefe = dgvitems.Rows[e.RowIndex].Cells["ImpTotalRefe"];
                            Decimal.TryParse(Convert.ToString(cellUnitarioRefe.Value), out CostoUnitario);
                            Decimal Total = (Cantidad * CostoUnitario);
                            cellTotalRefe.Value = Total;

                            DataGridViewCell cellUnitario = dgvitems.Rows[e.RowIndex].Cells["ImpCostoUnitarioBase"];
                            DataGridViewCell cellTotal = dgvitems.Rows[e.RowIndex].Cells["ImpTotalBase"];
                            cellUnitario.Value = (CostoUnitario * TipoCambio);

                            Decimal CostoUnitarioBase = Variables.ValorCeroDecimal;
                            Decimal.TryParse(Convert.ToString(cellUnitario.Value), out CostoUnitarioBase);
                            Decimal TotalBase = (Cantidad * CostoUnitarioBase);
                            cellTotal.Value = TotalBase;
                        }
                    }

                    #endregion

                    if (e.ColumnIndex == 99)
                    {
                        string valorTC = txttipocambio.Text;
                        string valor1 = dgvitems.Rows[e.RowIndex].Cells[7].Value.ToString();
                        string valor2 = dgvitems.Rows[e.RowIndex].Cells[10].Value.ToString();
                        decimal cant = (valor1.Length > 0 ? Convert.ToDecimal(valor1) : 0);
                        decimal costo = (valor2.Length > 0 ? Convert.ToDecimal(valor2) : 0);
                        decimal TC = (valorTC.Length > 0 ? Convert.ToDecimal(valorTC) : 1);

                        dgvitems.Rows[e.RowIndex].Cells[11].Value = costo * TC;
                        dgvitems.Rows[e.RowIndex].Cells[12].Value = cant * costo;
                        dgvitems.Rows[e.RowIndex].Cells[13].Value = (costo * TC) * cant;

                        SumarTotal();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btnVerNotaCredito_Click(object sender, EventArgs e)
        {
            try
            {
               if (txttipocambio.Text.Trim() == "0.000")
                {
                    Global.MensajeComunicacion("Debe ingresar Tipo de Cambio.");
                    return;
                }

             frmBuscarProvisiones oFrm = new frmBuscarProvisiones("NCDevolucion");

               if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oProvision != null)
                {
                    bsItems.DataSource = null;
                    txtIdOC.Text = oFrm.oProvision.idOrdenCompra.ToString();
                    txtordencompra.Text = oFrm.oProvision.numOrdenCompra;                   

                    cbomoneda.SelectedValue = oFrm.oProvision.CodMonedaProvision;
                    txtGlosa.Text = oFrm.oProvision.DesProvision;
                    txtIdCliente.Text = oFrm.oProvision.idPersona.ToString();

                    cboDocumento.SelectedValue = oFrm.oProvision.idDocumento;
                    txtSerieDoc.Text = oFrm.oProvision.NumSerie;
                    txtNumDoc.Text = oFrm.oProvision.NumDocumento;
                    dtpFecDocumento.Text = oFrm.oProvision.FechaDocumento.ToString();

                    chbtipo_cambio.Checked = false;
                    txttipocambio.Text = oFrm.oProvision.TipCambio.ToString();

                    cboDocReferencia.SelectedValue = oFrm.oProvision.idDocumentoRef;
                    txtSerieRefe.Text = oFrm.oProvision.numSerieRef;
                    txtNumRefe.Text = oFrm.oProvision.numDocumentoRef;

                    chkDev.Checked = true;
                    cboDocumentoDev.SelectedValue = oFrm.oProvision.idDocumentoRef;
                    txtSerieDev.Text = oFrm.oProvision.numSerieRef;
                    txtNumDev.Text = oFrm.oProvision.numDocumentoRef;

                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    txtRuc.Text = oFrm.oProvision.Ruc;
                    txtRazonSocial.Text = oFrm.oProvision.RazonSocial;
                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;

                    ProvisionesE oProvisionCompleta = null;

                    oProvisionCompleta = AgentePorPagar.Proxy.RecuperarProvisionesPorId(oFrm.oProvision.idEmpresa, oFrm.oProvision.idLocal, oFrm.oProvision.idProvision);

                    foreach (Provisiones_PorCCostoE item in oProvisionCompleta.ListaPorCCosto)
                    {
                        if (item.Tipo == "A")
                        {
                        // Decimal PrecioUnitario = item.impPrecioUnitario - (item.impPrecioUnitario * (item.porDescuento / 100));
                        ArticuloServE oArticulo = null;
                        MovimientoAlmacenItemE oLote = null;

                        oArticulo = AgenteMaestros.Proxy.ObtenerArticuloServ(item.idEmpresa, item.idArticulo.Value);

                        oLote = AgenteAlmacen.Proxy.ObtenerMovimiento_Almacen_ItemLote(item.idEmpresa, oFrm.oProvision.idOrdenCompra.Value, item.idItem, oFrm.oProvision.idDocumentoRef, oFrm.oProvision.numSerieRef, oFrm.oProvision.numDocumentoRef);
                        String nLote = String.Empty;

                        if (oLote == null)
                         {
                           nLote = "0000000";
                         }
                         else
                         {
                           nLote = oLote.Lote;
                         }


                            if (oArticulo != null)
                            {
                                oArticulo.Lote = nLote;
                                AgregarArticulo(oArticulo, nLote, item.Cantidad, item.PrecioUnitario, item.subTotal, item.MontoCuenta, item.idItem, cbomoneda.SelectedValue.ToString());
                            }
                        }
                    }

                    SumarTotal();
                }

            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btnVerOrdenCompra_Click(object sender, EventArgs e)
        {
            try
            {
                if (txttipocambio.Text.Trim() == "0.000")
                {
                    Global.MensajeComunicacion("Debe ingresar Tipo de Cambio.");
                    return;
                }

                frmBuscarOrdenCompra oFrm = new frmBuscarOrdenCompra("N");

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oOC != null)
                {
                    bsItems.DataSource = null;
                    txtIdOC.Text = oFrm.oOC.idOrdenCompra.ToString();
                    txtordencompra.Text = oFrm.oOC.numOrdenCompra;

                    oOrdenCompra = AgenteAlmacen.Proxy.ObtenerOrdenDeCompraCompleto(oFrm.oOC.idEmpresa, oFrm.oOC.idOrdenCompra);

                    cbomoneda.SelectedValue = oOrdenCompra.idMoneda;
                    txtGlosa.Text = oOrdenCompra.Observacion;
                    txtIdCliente.Text = oOrdenCompra.idProveedor.ToString();

                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    txtRuc.Text = oOrdenCompra.RUC;
                    txtRazonSocial.Text = oOrdenCompra.RazonSocial;
                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;

                    foreach (OrdenCompraItemE item in oOrdenCompra.ListaOrdenesCompras)
                    {
                        if (((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen == item.ArticuloServ.idTipoArticulo)
                        {
                            if (item.CalculoCosto)
                            {
                                AgregarArticulo(item.ArticuloServ, item.Lote, item.CanOrdenada, item.PrecioCosto, item.impVentaItem, item.CostoTotal, item.idItem, cbomoneda.SelectedValue.ToString());
                            }
                            else
                            {
                                Decimal PrecioUnitario = item.impPrecioUnitario - (item.impPrecioUnitario * (item.porDescuento / 100));
                                AgregarArticulo(item.ArticuloServ, item.Lote, item.CanOrdenada, PrecioUnitario, item.impVentaItem, item.impTotalItem, item.idItem, cbomoneda.SelectedValue.ToString());
                            }
                        }
                    }

                    chkIgv.Checked = oOrdenCompra.impIgv > 0;
                    lblIgvSol.Text = oOrdenCompra.impIgv.ToString("N2");
                    lblIgvPor.Text = oOrdenCompra.porIgv.ToString("N2");

                    SumarTotal();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkIgv_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SumarTotal();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void chkDev_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDev.Checked)
            {
                cboDocumentoDev.Enabled = true;
                txtSerieDev.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
                txtNumDev.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
            }
            else
            {
                cboDocumentoDev.Enabled = false;
                txtSerieDev.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtNumDev.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
        }

        private void txtCodBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (((AlmacenE)cboAlmacen.SelectedItem).EsCalzado)
                {
                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        if (!String.IsNullOrWhiteSpace(txtCodBarras.Text))
                        {
                            ImpresionBarrasDetDetE oImpresionArticulo = AgenteMaestros.Proxy.ObtenerImpresionDetDetPorBarras(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtCodBarras.Text.Trim());

                            if (oImpresionArticulo != null)
                            {
                                oListaItems = new List<MovimientoAlmacenItemE>(oMovimientoAlmacen.ListaAlmacenItem);
                                Boolean ConLote = ((AlmacenE)cboAlmacen.SelectedItem).VerificaLote;

                                if (!ConLote)
                                {
                                    for (int i = 0; i < oListaItems.Count; i++)
                                    {
                                        if (oListaItems[i].idArticulo == oImpresionArticulo.idArticulo)
                                        {
                                            if (Global.MensajeConfirmacion("El Item seleccionado ya existe desea reemplazarlo") == DialogResult.No)
                                            {
                                                return;
                                            }
                                            else
                                            {
                                                oMovimientoAlmacen.ListaAlmacenItem.RemoveAt(i);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < oListaItems.Count; i++)
                                    {
                                        if (oListaItems[i].idArticulo == oImpresionArticulo.idArticulo && oListaItems[i].Lote == oImpresionArticulo.Talla.ToString())
                                        {
                                            if (Global.MensajeConfirmacion("El Item seleccionado ya existe desea reemplazarlo") == DialogResult.No)
                                            {
                                                return;
                                            }
                                            else
                                            {
                                                oMovimientoAlmacen.ListaAlmacenItem.RemoveAt(i);
                                            }
                                        }
                                    }
                                }

                                MovimientoAlmacenItemE oNuevo = new MovimientoAlmacenItemE()
                                {
                                    idEmpresa = oMovimientoAlmacen.idEmpresa,
                                    idDocumentoAlmacen = oMovimientoAlmacen.idDocumentoAlmacen,
                                    idItem = 0,
                                    numItem = (oMovimientoAlmacen.ListaAlmacenItem.Count == 0 ? "0001" : (oMovimientoAlmacen.ListaAlmacenItem.Count + 1).ToString("0000")),
                                    idArticulo = oImpresionArticulo.oArticulo.idArticulo,
                                    codArticulo = oImpresionArticulo.oArticulo.codArticulo,
                                    nomArticulo = oImpresionArticulo.oArticulo.nomArticulo,
                                    Lote = oImpresionArticulo.Talla.ToString("N2"),
                                    idUbicacion = 0,
                                    Cantidad = 1,
                                    nroEnvases = 0,
                                    indCalidad = false,
                                    indConformidad = false,
                                    idCCostos = String.Empty,
                                    idCCostosUso = String.Empty,
                                    desCCostos = String.Empty,
                                    //codSerie = oImpresionArticulo.oArticulo.codSerie,
                                    ImpCostoUnitarioBase = 0,
                                    ImpCostoUnitarioRefe = 0,
                                    ImpTotalBase = 0,
                                    ImpTotalRefe = 0,
                                    Valorizado = false,
                                    idItemCompra = null,
                                    idArticuloUso = 0,
                                    nroParteProd = "",
                                    UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                                    FechaRegistro = VariablesLocales.FechaHoy,
                                    UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                                    FechaModificacion = VariablesLocales.FechaHoy
                                };

                                oMovimientoAlmacen.ListaAlmacenItem.Add(oNuevo);
                                bsItems.DataSource = oMovimientoAlmacen.ListaAlmacenItem;
                                bsItems.ResetBindings(false);

                                txtCodBarras.SelectAll();
                                txtCodBarras.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
                txtCodBarras.SelectAll();
                txtCodBarras.Focus();
            }
        }

        private void btExaminar_Click(object sender, EventArgs e)
        {
            try
            {
                txtRuta.Text = CuadrosDialogo.BuscarArchivo("Buscar Archivo Excel", "Archivos Excel (.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(txtRuta.Text))
                {
                    btExaminar.Enabled = false;
                    btAgregar.Enabled = true;
                }
                else
                {
                    btExaminar.Enabled = true;
                    btAgregar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Infraestructura.Global.MensajeError(ex.Message);
            }
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            InsertarExcel(txtRuta.Text);
            btExaminar.Enabled = true;
            btAgregar.Enabled = false;
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsItems == null || bsItems.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "FormatoSalida", "Archivos Excel (*.xlsx)|*.xlsx");

                ExportarExcel(RutaGeneral);


            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

    }
}       
