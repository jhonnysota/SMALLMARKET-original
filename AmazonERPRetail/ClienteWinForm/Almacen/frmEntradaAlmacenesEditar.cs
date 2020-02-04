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
    public partial class frmEntradaAlmacenesEditar : FrmMantenimientoBase
    {

        #region Constructor

        public frmEntradaAlmacenesEditar()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            FormatoGrid(dgvitems, false, false, 25, 20, true, 8.25f, 8f, DataGridViewSelectionMode.CellSelect);
        }

        //Nuevo
        public frmEntradaAlmacenesEditar(Int32 idAlmacen_, Int32 idTipoMovimiento_, Int32 idOperacion_, List<AlmacenE> ListaAlmacenes, List<ParTabla> ListaMovimientos, List<OperacionE> ListaOperaciones)
            : this()
        {
            idAlmacen = idAlmacen_;
            idTipoMovimiento = idTipoMovimiento_;
            idOperacion = idOperacion_;
            oListaAlmacenes = ListaAlmacenes;
            oListaTipoMovimientos = ListaMovimientos;
            oListaOp = ListaOperaciones;
        }

        //Editar
        public frmEntradaAlmacenesEditar(MovimientoAlmacenE oEntidad_, List<AlmacenE> ListaAlmacenes, List<ParTabla> ListaMovimientos, List<OperacionE> ListaOperaciones)
            : this()
        {
            oMovimientoAlmacen = AgenteAlmacen.Proxy.ObtenerMovimientoAlmacenCompleto(oEntidad_.idEmpresa, oEntidad_.tipMovimiento, oEntidad_.idDocumentoAlmacen, false, "S");
            oListaAlmacenes = ListaAlmacenes;
            oListaTipoMovimientos = ListaMovimientos;
            oListaOp = ListaOperaciones;
        }

        #endregion

        #region Variables
    
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }

        List<MovimientoAlmacenItemE> oListaItems = new List<MovimientoAlmacenItemE>();
        MovimientoAlmacenE oMovimientoAlmacen;
        List<AlmacenE> oListaAlmacenes;
        List<ParTabla> oListaTipoMovimientos = null;
        List<OperacionE> oListaOp;
        OrdenCompraE oOrdenCompra = null;

        Int32 idAlmacen = 0;
        Int32 idTipoMovimiento = 0;
        Int32 idOperacion = 0;
        String RutaGeneral = String.Empty;
        List<MovimientoAlmacenItemE> itemEliminados = new List<MovimientoAlmacenItemE>();

        public Int32 Opcion = Variables.Cero;
        Boolean YaEntro = false;

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

                ////  Si la tecla presionada es distinta de la tecla Enter
                ////  abandonamos el procedimiento.
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
                        if (iColumnIndex == 5)
                        {
                            dgvitems.CurrentCell = dgvitems[iColumnIndex + 3, iRowIndex]; dgvitems.CurrentCell = dgvitems[iColumnIndex + 4, iRowIndex];
                        }
                        else
                        {
                            dgvitems.CurrentCell = dgvitems[iColumnIndex + 1, iRowIndex];
                        }
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

        #endregion Override

        #region Procedimientos de Usuario

        private void LlenarCombos()
        {
            // Documentos
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(VariablesLocales.ListarDocumentoGeneral);
            ListaDocumentos.Add(new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione });

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
            List<MonedasE> listaMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas)
            {
                new MonedasE() { idMoneda = Variables.Cero.ToString(), desMoneda = Variables.Seleccione }
            };
            ComboHelper.LlenarCombos<MonedasE>(cbomoneda, (from x in listaMonedas
                                                           where x.idMoneda == "0"
                                                           || x.idMoneda == Variables.Soles
                                                           || x.idMoneda == Variables.Dolares
                                                           orderby x.idMoneda select x).ToList(), "idMoneda", "desMoneda");
            //Movimientos de Almacen
            List<ParTabla> ListarTipoMovimiento = new List<ParTabla>(oListaTipoMovimientos);
            ComboHelper.RellenarCombos<ParTabla>(cboTipoMovimiento, (from x in ListarTipoMovimiento
                                                                     where (x.NemoTecnico == "EG" || x.NemoTecnico == "EGR") ||
                                                                           (x.NemoTecnico == "IN" || x.NemoTecnico == "ING")
                                                                     orderby x.IdParTabla
                                                                     select x).ToList(), "IdParTabla", "Nombre", false);

            cboTipoMovimiento.SelectedValue = Convert.ToInt32((from x in ListarTipoMovimiento
                                                               where x.NemoTecnico == "IN" || x.NemoTecnico == "ING"
                                                               select x.IdParTabla).FirstOrDefault());
            //Almacenes
            oListaAlmacenes = new List<AlmacenE>(oListaAlmacenes);
            ComboHelper.RellenarCombos<AlmacenE>(cboAlmacen, (from x in oListaAlmacenes orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen", false);

            //Operaciones - Conceptos
            List<OperacionE> oListaOperaciones = new List<OperacionE>(oListaOp);
            ComboHelper.RellenarCombos<OperacionE>(cboConcepto, (from x in oListaOperaciones orderby x.desOperacion select x).ToList(), "idOperacion", "desOperacion", false);
            cboConcepto.SelectedValue = Variables.Cero.ToString();


            // Documentos
            List<DocumentosE> ListaDocumentosDev = new List<DocumentosE>(VariablesLocales.ListarDocumentoGeneral)
            {
                new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione }
            };
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

        private void AgregarArticulo(ArticuloServE oArticulo, String Lote, Decimal Cantidad, Decimal PrecioUni, Decimal impVenta, Decimal impTotal, Int32 idItemCompra, String idMoneda, Boolean CalculoCosto = false)
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

            MovimientoAlmacenItemE oNuevo = new MovimientoAlmacenItemE()
            {
                idEmpresa = oMovimientoAlmacen.idEmpresa,
                idDocumentoAlmacen = oMovimientoAlmacen.idDocumentoAlmacen,
                idItem = 0,
                numItem = (oMovimientoAlmacen.ListaAlmacenItem.Count == 0 ? "0001" : (oMovimientoAlmacen.ListaAlmacenItem.Count + 1).ToString("0000")),
                idArticulo = oArticulo.idArticulo,
                codArticulo = oArticulo.codArticulo,
                nomArticulo = oArticulo.nomArticulo,
                Lote = Lote,
                idUbicacion = 0,
                Cantidad = Cantidad,
                nroEnvases = 0,
                indCalidad = false,
                indConformidad = false,
                idCCostos = "",
                idCCostosUso = "",
                desCCostos = ""
            };

            if (idMoneda == Variables.Soles)
            {
                if (!CalculoCosto)
                {
                    oNuevo.ImpCostoUnitarioBase = PrecioUni;
                    oNuevo.ImpCostoUnitarioRefe = PrecioUni / Convert.ToDecimal(txttipocambio.Text);
                    oNuevo.ImpTotalBase = PrecioUni * Cantidad;
                    oNuevo.ImpTotalRefe = (PrecioUni / Convert.ToDecimal(txttipocambio.Text)) * Cantidad;
                }
                else
                {
                    oNuevo.ImpCostoUnitarioBase = PrecioUni;
                    oNuevo.ImpCostoUnitarioRefe = PrecioUni / Convert.ToDecimal(txttipocambio.Text);
                    oNuevo.ImpTotalBase = impTotal;
                    oNuevo.ImpTotalRefe = impTotal / Convert.ToDecimal(txttipocambio.Text);
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

        public void EditarLote(DataGridViewCellEventArgs e)
        {
            try
            {
                if (bsItems != null)
                {
                    MovimientoAlmacenItemE oMovimientoSelec = (MovimientoAlmacenItemE)bsItems.Current;
                    frmEntradaAlmacenesLote oFrm;

                    oMovimientoAlmacen.fecProceso = dtpFecProceso.Value.ToString("yyyyMMdd");
                    if (txtIdProveedor.Text != "")
                    {
                        oMovimientoAlmacen.idPersona = Convert.ToInt32(txtIdProveedor.Text.Trim());
                    }
                    else
                    {
                        oMovimientoAlmacen.idPersona = 0;
                    }
                  
                    oMovimientoAlmacen.ruc = txtRuc.Text;
                    oMovimientoAlmacen.RazonSocial = txtproveedor.Text;

                    Int32 idAlmacen = Convert.ToInt32(cboAlmacen.SelectedValue);

                    if (oMovimientoSelec.oLoteEntidad == null)
                    {
                        oFrm = new frmEntradaAlmacenesLote(oMovimientoAlmacen, idAlmacen);
                    }
                    else
                    {
                        oFrm = new frmEntradaAlmacenesLote(oMovimientoAlmacen, oMovimientoSelec.oLoteEntidad, idAlmacen);
                    }

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oMovimientoAlmacen.ListaAlmacenItem[e.RowIndex].oLoteEntidad = oFrm.oLote;
                        oMovimientoAlmacen.ListaAlmacenItem[e.RowIndex].Lote = oFrm.oLote.Lote;
                        oMovimientoAlmacen.ListaAlmacenItem[e.RowIndex].LoteProveedor = oFrm.oLote.LoteProveedor;

                        bsItems.DataSource = oMovimientoAlmacen.ListaAlmacenItem;
                        bsItems.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void SumarTotal()
        {
            if (oMovimientoAlmacen.ListaAlmacenItem != null && oMovimientoAlmacen.ListaAlmacenItem.Count > 0)
            {
                decimal IgvDol = 0;
                decimal IgvSol = 0;
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

                decimal.TryParse(lblIgvPor.Text, out decimal porIgv);

                //Igv = ValorVenta * (porIgv / 100);
                //lblIgvDol.Text = Igv.ToString("N2");

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
                //if (Mon == Variables.Soles)
                //{
                //    lblValorVentaDol.Text = oMovimientoAlmacen.ListaAlmacenItem.Sum(x => x.ImpTotalBase).ToString("N2");//(oMovimientoAlmacen.ListaAlmacenItem.Sum(x => x.Cantidad) * oMovimientoAlmacen.ListaAlmacenItem.Sum(x => x.ImpCostoUnitarioBase)).ToString("N2");
                //}

                //if (Mon == Variables.Dolares)
                //{
                //    lblValorVentaDol.Text = oMovimientoAlmacen.ListaAlmacenItem.Sum(x => x.ImpTotalRefe).ToString("N2"); //(oMovimientoAlmacen.ListaAlmacenItem.Sum(x => x.Cantidad) * oMovimientoAlmacen.ListaAlmacenItem.Sum(x => x.ImpCostoUnitarioRefe)).ToString("N2");
                //}
            }
        }

        private void SinOperacion()
        {
            label16.Text = "Proveedor";
            txtRuc.Text = "";
            txtproveedor.Text = "";
            btnVerOrdenCompra.Enabled = false;
        }

        private void DatosGrabacion()
        {
            // CARGAMOS VARIABLES
            oMovimientoAlmacen.idAlmacen = Convert.ToInt32(cboAlmacen.SelectedValue);
            oMovimientoAlmacen.tipMovimiento = Convert.ToInt32(cboTipoMovimiento.SelectedValue);
            oMovimientoAlmacen.idOperacion = Convert.ToInt32(cboConcepto.SelectedValue);      
            oMovimientoAlmacen.tipAlmacen = Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen);
            oMovimientoAlmacen.fecProceso = dtpFecProceso.Value.ToString("yyyyMMdd");
            oMovimientoAlmacen.indFactura = chkIndFactura.Checked;
            oMovimientoAlmacen.indDocDevolucion = chkDev.Checked;

            if (chkIndFactura.Checked)
            {
                oMovimientoAlmacen.idDocumento = cboDocumento.SelectedValue.ToString();
                oMovimientoAlmacen.serDocumento = txtSerieDoc.Text;
                oMovimientoAlmacen.numDocumento = txtNumDoc.Text;
                oMovimientoAlmacen.fecDocumento = dtpFecDocumento.Value.ToString("yyyyMMdd");
            }
            else
            {
                oMovimientoAlmacen.idDocumento = String.Empty;
                oMovimientoAlmacen.serDocumento = String.Empty;
                oMovimientoAlmacen.numDocumento = String.Empty;
                oMovimientoAlmacen.fecDocumento = null;
            }

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
            oMovimientoAlmacen.numRequisicion = string.Empty; ;
            oMovimientoAlmacen.Glosa = txtGlosa.Text;
            oMovimientoAlmacen.idDocumentoRef = cboDocReferencia.SelectedValue.ToString();
            oMovimientoAlmacen.SerieDocumentoRef = txtSerieRefe.Text;
            oMovimientoAlmacen.NumeroDocumentoRef = txtNumRefe.Text;
            oMovimientoAlmacen.idPersona = string.IsNullOrEmpty(txtIdProveedor.Text.Trim()) ? (int?)null : Convert.ToInt32(txtIdProveedor.Text.Trim());
            oMovimientoAlmacen.idMoneda = cbomoneda.SelectedValue.ToString();
            oMovimientoAlmacen.indCambio = chbtipo_cambio.Checked;
            oMovimientoAlmacen.tipCambio = Convert.ToDecimal(txttipocambio.Text);

            oMovimientoAlmacen.impValorVenta = Convert.ToDecimal(lblValorVentaDol.Text);
            oMovimientoAlmacen.indImpuesto = chkIgv.Checked;

            if (chkIgv.Checked)
            {
                oMovimientoAlmacen.porIgv = Convert.ToDecimal(lblIgvPor.Text);
                oMovimientoAlmacen.Impuesto = Convert.ToDecimal(lblIgvDol.Text);
            }
            else
            {
                oMovimientoAlmacen.porIgv = 0;
                oMovimientoAlmacen.Impuesto = 0;
            }
            
            oMovimientoAlmacen.impTotal = Convert.ToDecimal(lblImporteDol.Text);

            if (oMovimientoAlmacen.idAlmacenOrigen == null || oMovimientoAlmacen.idAlmacenOrigen == 0)
            {
                oMovimientoAlmacen.idAlmacenOrigen = 0;
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
                oMovimientoAlmacen.FechaRegistro = VariablesLocales.FechaHoy;
                oMovimientoAlmacen.FechaModificacion = VariablesLocales.FechaHoy;
            }
            else
            {
                oMovimientoAlmacen.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
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
                        item.ImpTotalRefe = (item.ImpCostoUnitarioBase / Convert.ToDecimal(txttipocambio.Text)) * Cantidad;
                    }
                    else if (cbomoneda.SelectedValue.ToString() == Variables.Dolares)
                    {
                        item.ImpCostoUnitarioBase = item.ImpCostoUnitarioRefe * Convert.ToDecimal(txttipocambio.Text);
                        item.ImpTotalBase = (item.ImpCostoUnitarioRefe * Convert.ToDecimal(txttipocambio.Text)) * Cantidad;
                        item.ImpTotalRefe = item.ImpCostoUnitarioRefe * Cantidad;
                    }
                }

                bsItems.DataSource = oMovimientoAlmacen.ListaAlmacenItem;
                bsItems.ResetBindings(false);
            }

            SumarTotal();
        }

        private void ValidarAuxiliar(List<Persona> oListaPersonasTmp)
        {
            if (!oListaPersonasTmp[0].Pro)
            {
                if (Global.MensajeConfirmacion("Este auxiliar no esta ingresado como Proveedor. Desea agregarlo ?") == DialogResult.Yes)
                {
                    ProveedorE oProveedor = new ProveedorE()
                    {
                        IdPersona = oListaPersonasTmp[0].IdPersona,
                        IdEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        SiglaComercial = oListaPersonasTmp[0].RazonSocial,
                        TipoProveedor = 0,
                        fecInscripcion = (Nullable<DateTime>)null,
                        fecInicioActividad = (Nullable<DateTime>)null,
                        tipConstitucion = 0,
                        tipRegimen = 0,
                        catProveedor = 0,
                        indBaja = Variables.NO,
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                    };

                    AgenteMaestros.Proxy.InsertarProveedor(oProveedor);
                }
            }
        }

        private bool BuscarArticulo(string TextoABuscar, string Columna, DataGridView grid)
        {
            bool encontrado = false;
            Int32 fila = 0;
            if (TextoABuscar == string.Empty) return false;
            if (grid.RowCount == 0) return false;
            fila = grid.CurrentRow.Index;
            grid.ClearSelection();

            if (Columna == string.Empty)
            {
                IEnumerable<DataGridViewRow> obj = (from DataGridViewRow row in grid.Rows.Cast<DataGridViewRow>()
                                                    from DataGridViewCell cells in row.Cells
                                                    where cells.OwningRow.Equals(row) && cells.Value.ToString() == TextoABuscar
                                                    select row);
                if (obj.Any())
                {
                    grid.Rows[obj.FirstOrDefault().Index].Selected = true;
                    return true;
                }

            }
            else
            {
                IEnumerable<DataGridViewRow> obj = (from DataGridViewRow row in grid.Rows.Cast<DataGridViewRow>()
                                                    where row.Cells[4].Value.ToString().Contains(TextoABuscar) && row.Index > fila
                                                    select row);
                if (obj.Any())
                {

                    grid.Rows[obj.FirstOrDefault().Index].Selected = true;
                    grid.Focus();
                    grid.CurrentCell = grid.Rows[obj.FirstOrDefault().Index].Cells[4];

                    return true;
                }
                else
                {
                    Global.MensajeFault("No se Encontraron Coincidencias.");
                    grid.Rows[0].Selected = true;
                    grid.Focus();
                    grid.CurrentCell = grid.Rows[0].Cells[4];
                }
            }

            return encontrado;
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
                for (int f = 7; f <= totFilasExcel; f++)
                {
                    if (oHoja.Cells[f, 1].Value.ToString() != String.Empty)
                    {
                        ArticuloServE oArtServ = AgenteMaestros.Proxy.ObtenerArticuloPorCodArticulo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, oHoja.Cells[f, 1].Value.ToString());

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
                                Cantidad = Convert.ToDecimal(oHoja.Cells[f, 3].Value),
                                nroEnvases = 0,
                                indCalidad = false,
                                indConformidad = false,
                                idCCostos = String.Empty,
                                idCCostosUso = String.Empty,
                                desCCostos = String.Empty,
                                codSerie = 0,//Convert.ToInt32(oArtServ.codSerie),
                                ImpCostoUnitarioBase = Convert.ToDecimal(oHoja.Cells[f, 4].Value),
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
                                oLoteEntidad = new LoteE()
                                {
                                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                    fecPrueba = oHoja.Cells[f, 6].Value != null ? Convert.ToDateTime(oHoja.Cells[f, 6].Value) : (DateTime?)null,
                                    LoteProveedor = oHoja.Cells[f, 5].Value.ToString(),
                                    idPaisOrigen = 90,
                                    idPaisProcedencia = 90,
                                    fecProceso = dtpFecProceso.Value.Date,
                                    UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                                    Opcion = (Int32)EnumOpcionGrabar.Insertar
                                }
                            };

                            if (cbomoneda.SelectedValue.ToString() == Variables.Soles)
                            {
                                oMovAlmItem.ImpCostoUnitarioBase = Convert.ToDecimal(oHoja.Cells[f, 4].Value);
                                oMovAlmItem.ImpTotalBase = oMovAlmItem.ImpCostoUnitarioBase * oMovAlmItem.Cantidad;

                                if (chbtipo_cambio.Checked == true)
                                {
                                    oMovAlmItem.ImpCostoUnitarioRefe = oMovAlmItem.ImpCostoUnitarioBase / Convert.ToDecimal(txttipocambio.Text);
                                    oMovAlmItem.ImpTotalRefe = oMovAlmItem.ImpCostoUnitarioRefe * oMovAlmItem.Cantidad;
                                }
                            }
                            else
                            {
                                oMovAlmItem.ImpCostoUnitarioRefe = Convert.ToDecimal(oHoja.Cells[f, 4].Value);
                                oMovAlmItem.ImpTotalRefe = oMovAlmItem.ImpCostoUnitarioRefe * oMovAlmItem.Cantidad;

                                if (chbtipo_cambio.Checked == true)
                                {
                                    oMovAlmItem.ImpCostoUnitarioBase = oMovAlmItem.ImpCostoUnitarioRefe * Convert.ToDecimal(txttipocambio.Text);
                                    oMovAlmItem.ImpTotalBase = oMovAlmItem.ImpCostoUnitarioBase * oMovAlmItem.Cantidad;
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

        private void ExportarExcel(String Ruta)
        {
            string NombrePestaña = " REPORTE FORMATO DE ENTRADA ";

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
                        oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 1].Value = item.codArticulo.ToString() + item.Lote.Substring(0,2);
                        oHoja.Cells[InicioLinea, 2].Style.Font.SetFromFont(new Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 2].Value = item.Cantidad;
                        oHoja.Cells[InicioLinea, 3].Style.Font.SetFromFont(new Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 3].Value = item.ImpCostoUnitarioBase;
                        oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";

                        InicioLinea++;
                    }

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns(0);

                    //Insertando Encabezado
                    oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + "Formato De Entrada";
                    //Pie de Pagina(Derecho) "Número de paginas y el total"
                    oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                    //Pie de Pagina(centro)
                    oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                    //Otras Propiedades
                    oHoja.Workbook.Properties.Title = "Formato De Entrada";
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
                }
                else
                {
                    dtpFecDocumento.ValueChanged -= dtpFecDocumento_ValueChanged;
                    dtpFecProceso.ValueChanged -= dtpFecProceso_ValueChanged;
                    chbtipo_cambio.CheckedChanged -= chbtipo_cambio_CheckedChanged;
                    chkIgv.CheckedChanged -= chkIgv_CheckedChanged;
                    chkIndFactura.CheckedChanged -= chkIndFactura_CheckedChanged;

                    txtIdOC.Text = Convert.ToString(oMovimientoAlmacen.idOrdenCompra);
                    txtordencompra.Text = oMovimientoAlmacen.numOrdenCompra;
                    cboAlmacen.SelectedValue = Convert.ToInt32(oMovimientoAlmacen.idAlmacen);
                    cboTipoMovimiento.SelectedValue = Convert.ToInt32(oMovimientoAlmacen.tipMovimiento);
                    cboConcepto.SelectedValue = oMovimientoAlmacen.idOperacion;
                    cboConcepto_SelectionChangeCommitted(new object(), new EventArgs());

                    txtnumCorrelativo.Text = oMovimientoAlmacen.numCorrelativo;
                    dtpFecProceso.Value = Convert.ToDateTime(oMovimientoAlmacen.fecProceso);

                    if (oMovimientoAlmacen.idDocumentoAlmacenAsociado != 0)
                    {
                        txtidDocumentoAlmacenAsociar.Text = oMovimientoAlmacen.idDocumentoAlmacenAsociado.ToString();
                    }

                    if (oMovimientoAlmacen.idPersona != 0)
                    {
                        txtIdProveedor.Text = oMovimientoAlmacen.idPersona.ToString();
                    }
                    else
                    {
                        txtIdProveedor.Text = String.Empty;
                    }

                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtproveedor.TextChanged -= txtproveedor_TextChanged;
                    txtRuc.Text = oMovimientoAlmacen.ruc;
                    txtproveedor.Text = oMovimientoAlmacen.RazonSocial;
                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtproveedor.TextChanged += txtproveedor_TextChanged;

                    txtGlosa.Text = oMovimientoAlmacen.Glosa;
                    chkIndFactura.Checked = oMovimientoAlmacen.indFactura;
                    chkDev.Checked = oMovimientoAlmacen.indDocDevolucion;

                    if (oMovimientoAlmacen.indFactura)
                    {
                        txtSerieDoc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        txtNumDoc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        dtpFecDocumento.Enabled = true;

                        cboDocumento.SelectedValue = oMovimientoAlmacen.idDocumento;
                        txtSerieDoc.Text = oMovimientoAlmacen.serDocumento;
                        txtNumDoc.Text = oMovimientoAlmacen.numDocumento;
                        dtpFecDocumento.Value = string.IsNullOrWhiteSpace(oMovimientoAlmacen.fecDocumento) == true ? dtpFecDocumento.Value : Convert.ToDateTime(oMovimientoAlmacen.fecDocumento);
                    }

                    if (oMovimientoAlmacen.indDocDevolucion)
                    {
                        cboDocumentoDev.SelectedValue = oMovimientoAlmacen.idDocumentoDevolucion;
                        txtSerieDev.Text = oMovimientoAlmacen.serDocumentoDevolucion;
                        txtNumDev.Text = oMovimientoAlmacen.numDocumentoDevolucion;
                    }

                    cboDocReferencia.SelectedValue = oMovimientoAlmacen.idDocumentoRef.ToString();
                    txtSerieRefe.Text = oMovimientoAlmacen.SerieDocumentoRef;
                    txtNumRefe.Text = oMovimientoAlmacen.NumeroDocumentoRef;
                    cbomoneda.SelectedValue = oMovimientoAlmacen.idMoneda.ToString();
                    chbtipo_cambio.Checked = oMovimientoAlmacen.indCambio;
                    txttipocambio.Text = oMovimientoAlmacen.tipCambio.ToString("N3");
                    chkIgv.Checked = oMovimientoAlmacen.indImpuesto;

                    Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                    SumarTotal();

                    dtpFecDocumento.ValueChanged += dtpFecDocumento_ValueChanged;
                    dtpFecProceso.ValueChanged += dtpFecProceso_ValueChanged;
                    chbtipo_cambio.CheckedChanged += chbtipo_cambio_CheckedChanged;
                    chkIgv.CheckedChanged += chkIgv_CheckedChanged;
                    chkIndFactura.CheckedChanged += chkIndFactura_CheckedChanged;

                    if (oMovimientoAlmacen.idOrdenCompra != 0)
                    {
                        Int32.TryParse(txtIdOC.Text, out Int32 idOc);
                        oOrdenCompra = AgenteAlmacen.Proxy.ObtenerOrdenDeCompraCompleto(oMovimientoAlmacen.idEmpresa, idOc, "S");
                    }
                }

                bsItems.DataSource = oMovimientoAlmacen.ListaAlmacenItem;
                bsItems.ResetBindings(false);

                if (oMovimientoAlmacen.indEstado == "AN")
                {
                    Global.MensajeFault("El movimiento ha sido anulado no podra hacer ninguna modificación.");
                    pnlPrincipales.Enabled = false;
                    pnlFactura.Enabled = false;
                    pnlReferencia.Enabled = false;
                    pnlTica.Enabled = false;
                    pnlDetalle.Enabled = false;
                }
                else if (oMovimientoAlmacen.indEstado == "HC")
                {
                    Global.MensajeFault("La Hoja de Costo se encuentra cerrada, no podrá hacer ninguna modificación en el movimiento.");
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

                    //if (oListaPeridoValida != null)
                    //{
                    //    foreach (PeriodosAlmE oItemValida in oListaPeridoValida)
                    //    {
                    //        if (Convert.ToInt32(oItemValida.MesPeriodo) == dtpFecProceso.Value.Month && oItemValida.indCierre)
                    //        {
                    //            Global.MensajeFault("Sistema Bloqueado, " + oItemValida.desPeriodo + " esta Cerrado");
                    //            return;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    Global.MensajeFault("No se ha aperturado el año contable en CONTABILIDAD/MAESTROS/CAMBIAR SUCURSAL, PERIODO ");
                    //    return;
                    //}

                    if (!ValidarTica())
                    {
                        return;
                    }

                    DatosGrabacion();

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
                String Tipo = String.Empty;
                oListaItems = new List<MovimientoAlmacenItemE>(oMovimientoAlmacen.ListaAlmacenItem);

                if (!oAlmacen.EsCalzado)
                {
                    Tipo = "ArtAlmacen";

                    frmBuscarArticulo oFrm = new frmBuscarArticulo(oAlmacen, Tipo, "", "");

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

                        bsItems.MoveLast();
                        dgvitems.Focus();
                        dgvitems.CurrentRow.Cells["Cantidad"].Selected = true;
                    }
                }
                //else
                //{
                //    //ParTabla oTipoArticulo = new GeneralesServiceAgent().Proxy.ParTablaPorNemo("PT");
                //    //frmBuscarArticuloCalzado oFrm = new frmBuscarArticuloCalzado(oTipoArticulo.IdParTabla, "A");

                //    //if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaArticulos != null && oFrm.oListaArticulos.Count > 0)
                //    //{
                //    //    List<ArticuloServE> oListaArticulosBarras = new List<ArticuloServE>(oFrm.oListaArticulos);
                //    //    Boolean ConLote = ((AlmacenE)cboAlmacen.SelectedItem).VerificaLote;

                //    //    foreach (ArticuloServE item in oListaArticulosBarras)
                //    //    {
                //    //        if (!ConLote)
                //    //        {
                //    //            for (int i = 0; i < oListaItems.Count; i++)
                //    //            {
                //    //                if (oListaItems[i].idArticulo == item.idArticulo)
                //    //                {
                //    //                    if (Global.MensajeConfirmacion("El Item seleccionado ya existe desea reemplazarlo") == DialogResult.No)
                //    //                    {
                //    //                        return;
                //    //                    }
                //    //                    else
                //    //                    {
                //    //                        oMovimientoAlmacen.ListaAlmacenItem.RemoveAt(i);
                //    //                    }
                //    //                }
                //    //            }
                //    //        }
                //    //        else
                //    //        {
                //    //            for (int i = 0; i < oListaItems.Count; i++)
                //    //            {
                //    //                if (oListaItems[i].idArticulo == item.idArticulo && oListaItems[i].Lote == item.Lote)
                //    //                {
                //    //                    if (Global.MensajeConfirmacion("El Item seleccionado ya existe desea reemplazarlo") == DialogResult.No)
                //    //                    {
                //    //                        return;
                //    //                    }
                //    //                    else
                //    //                    {
                //    //                        oMovimientoAlmacen.ListaAlmacenItem.RemoveAt(i);
                //    //                    }
                //    //                }
                //    //            }
                //    //        }

                //    //        MovimientoAlmacenItemE oNuevo = new MovimientoAlmacenItemE()
                //    //        {
                //    //            idEmpresa = oMovimientoAlmacen.idEmpresa,
                //    //            idDocumentoAlmacen = oMovimientoAlmacen.idDocumentoAlmacen,
                //    //            idItem = 0,
                //    //            numItem = (oMovimientoAlmacen.ListaAlmacenItem.Count == 0 ? "0001" : (oMovimientoAlmacen.ListaAlmacenItem.Count + 1).ToString("0000")),
                //    //            idArticulo = item.idArticulo,
                //    //            codArticulo = item.codArticulo,
                //    //            nomArticulo = item.nomArticulo,
                //    //            Lote = item.Lote,
                //    //            idUbicacion = 0,
                //    //            Cantidad = 1,
                //    //            nroEnvases = 0,
                //    //            indCalidad = false,
                //    //            indConformidad = false,
                //    //            idCCostos = String.Empty,
                //    //            idCCostosUso = String.Empty,
                //    //            desCCostos = String.Empty,
                //    //            codSerie = item.codSerie.Value,
                //    //            ImpCostoUnitarioBase = 0,
                //    //            ImpCostoUnitarioRefe = 0,
                //    //            ImpTotalBase = 0,
                //    //            ImpTotalRefe = 0,
                //    //            Valorizado = false,
                //    //            idItemCompra = null,
                //    //            idArticuloUso = 0,
                //    //            nroParteProd = "",
                //    //            UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                //    //            FechaRegistro = VariablesLocales.FechaHoy,
                //    //            UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                //    //            FechaModificacion = VariablesLocales.FechaHoy,
                //    //            oLoteEntidad = null
                //    //        };

                //    //        oMovimientoAlmacen.ListaAlmacenItem.Add(oNuevo);
                //    //        bsItems.DataSource = oMovimientoAlmacen.ListaAlmacenItem;
                //    //        bsItems.ResetBindings(false);
                //    //    }

                //    //    //bsDetalle.DataSource = oImpresion.oListaArticulos;
                //    //    //bsDetalle.ResetBindings(false);

                //    //    base.AgregarDetalle();
                //    //}
                //}
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

            OperacionE operacion = (OperacionE)cboConcepto.SelectedItem;

            if (operacion.indDocumento)
            {
                if (!chkIndFactura.Checked)
                {
                    Global.MensajeFault("El tipo de operacón exige Documento.");
                    return false;
                }

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

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmEntradaAlmacenesEditar_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                //BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
                //BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);

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

                //if (((AlmacenE)cboAlmacen.SelectedItem).EsCalzado)
                //{
                //    dgvitems.Columns["LoteGV"].HeaderText = "Talla";
                //}
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            } 
        }

        private void cboConcepto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboConcepto.SelectedValue != null)
                {
                    if (Convert.ToInt32(cboConcepto.SelectedValue) != 0)
                    {
                        if (((OperacionE)cboConcepto.SelectedItem).indProveedor)
                        {
                            label16.Text = "Proveedor";
                            txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
                            txtproveedor.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
                        }
                        else
                        {
                            label16.Text = "Cliente";
                            txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                            txtproveedor.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
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
                            cbotipMovimientoAsociar.Enabled = true;
                            btnAsociar.Enabled = true;

                            List<ParTabla> ListarTipoMovimiento = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPMOVALM");
                            ComboHelper.RellenarCombos<ParTabla>(cbotipMovimientoAsociar, (from x in ListarTipoMovimiento
                                                                                           where (x.NemoTecnico == "EGR") ||
                                                                                                   (x.NemoTecnico == "ING")
                                                                                           orderby x.IdParTabla
                                                                                           select x).ToList(), "IdParTabla", "Nombre", false);

                            cbotipMovimientoAsociar.SelectedValue = Convert.ToInt32((from x in ListarTipoMovimiento
                                                                                     where x.NemoTecnico == "EGR"
                                                                                     select x.IdParTabla).FirstOrDefault());
                        }
                        else
                        {
                            cbotipMovimientoAsociar.Enabled = false;
                            btnAsociar.Enabled = false;
                            cbotipMovimientoAsociar.DataSource = null;
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
                        }
                        else
                        {
                            pnlDevol.Visible = false;
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
                    oOrdenCompra = AgenteAlmacen.Proxy.ObtenerOrdenDeCompraCompleto(oFrm.oOC.idEmpresa, oFrm.oOC.idOrdenCompra, "S");

                    if (oOrdenCompra.idMoneda != "01" && oOrdenCompra.idMoneda != "02")
                    {
                        Global.MensajeAdvertencia("Solo se puede usar soles o dólares, la O.C. tiene una moneda diferente");
                        return;
                    }

                    txtIdOC.Text = oFrm.oOC.idOrdenCompra.ToString();
                    txtordencompra.Text = oFrm.oOC.numOrdenCompra;

                    if (oFrm.oOC.idDocumento != null && !String.IsNullOrWhiteSpace(oFrm.oOC.idDocumento.Trim()))
                    {
                        chkIndFactura.Checked = true;
                        cboDocumento.SelectedValue = oFrm.oOC.idDocumento;
                        txtSerieDoc.Text = oFrm.oOC.numSerie;
                        txtNumDoc.Text = oFrm.oOC.numDocumento;
                        dtpFecDocumento.Value = Convert.ToDateTime(oFrm.oOC.fecDocumento);
                    }
                    else
                    {
                        chkIndFactura.Checked = false;
                    }

                    cbomoneda.SelectedValue = oOrdenCompra.idMoneda;
                    //txtRuc.Text = oOrdenCompra.RUC;
                    //txtproveedor.Text = oOrdenCompra.RazonSocial;
                    txtGlosa.Text = oOrdenCompra.Observacion;
                    txtIdProveedor.Text = oOrdenCompra.idProveedor.ToString();

                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtproveedor.TextChanged -= txtproveedor_TextChanged;
                    txtRuc.Text = oOrdenCompra.RUC;
                    txtproveedor.Text = oOrdenCompra.RazonSocial;
                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtproveedor.TextChanged += txtproveedor_TextChanged;

                    foreach (OrdenCompraItemE item in oOrdenCompra.ListaOrdenesCompras)
                    {
                        if (((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen == item.ArticuloServ.idTipoArticulo)
                        {
                            if ((item.CanOrdenada - item.CanIngresada) > 0)
                            {
                                if (item.CalculoCosto)
                                {
                                    AgregarArticulo(item.ArticuloServ, item.Lote, item.CanOrdenada - item.CanIngresada, item.PrecioCosto, item.impVentaItem, item.CostoTotal, item.idItem, cbomoneda.SelectedValue.ToString());
                                }
                                else
                                {
                                    Decimal PrecioUnitario = item.impPrecioUnitario - (item.impPrecioUnitario * (item.porDescuento / 100));
                                    AgregarArticulo(item.ArticuloServ, item.Lote, item.CanOrdenada - item.CanIngresada, PrecioUnitario, item.impVentaItem, item.impTotalItem, item.idItem, cbomoneda.SelectedValue.ToString());
                                }  
                            }
                        }
                        //else
                        //{
                        //    Global.MensajeAdvertencia("El tipo de articulo o almacén no coincide entre el almacen y el artículo");
                        //    break;
                        //}
                    }

                    if (oOrdenCompra.impIgv > 0)
                    {
                        chkIgv.Checked = true;
                    }
                    else
                    {
                        chkIgv.Checked = false;
                    }

                    SumarTotal();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chbtipo_cambio_CheckedChanged(object sender, EventArgs e)
        {
            if (chbtipo_cambio.Checked)
            {
                txttipocambio.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");

                if (chkIndFactura.Checked)
                {
                    dtpFecDocumento_ValueChanged(null, null);
                }
                else
                {
                    dtpFecProceso_ValueChanged(null, null);
                }
            }
            else
            {
                txttipocambio.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
                txttipocambio.Text = "0.000";
            }
        }

        private void dgvitems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (dgvitems.Columns[e.ColumnIndex].Name == "Cantidad" || dgvitems.Columns[e.ColumnIndex].Name == "impCostoUnitarioBase"||dgvitems.Columns[e.ColumnIndex].Name== "Lote")
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

        private void dgvitems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    String nomColumn = dgvitems.Columns[e.ColumnIndex].Name;
                    String Moneda = Convert.ToString(cbomoneda.SelectedValue);
                    Boolean indAjuste = ((OperacionE)cboConcepto.SelectedItem).indServicio;

                    if (nomColumn == "Cantidad" || nomColumn == "impCostoUnitarioBase" || nomColumn == "impCostoUnitarioRefe"|| nomColumn == "LoteGV")
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
                        if (nomColumn == "LoteGV")
                        {
                            
                            dgvitems.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                            e.CellStyle.BackColor = Color.PaleTurquoise;

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

        private void dgvitems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Elimina el mensaje de error de la cabecera de la fila
            dgvitems.Rows[e.RowIndex].ErrorText = String.Empty;
            SumarTotal();
            YaEntro = false;
        }

        private void dgvitems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvitems.Columns[e.ColumnIndex].Name == "LoteGV" || dgvitems.Columns[e.ColumnIndex].Name == "LoteProveedor")
                {
                    if (((AlmacenE)cboAlmacen.SelectedItem).VerificaLote)
                    {
                        if (!((AlmacenE)cboAlmacen.SelectedItem).EsCalzado)
                        {
                           // if (txtproveedor.Text != "")
                            //{
                                EditarLote(e);
                           // }
                           // else
                            //{
                             //   Global.MensajeFault("Se necesita un Proveedor.");
                           // }
                        }
                        else
                        {
                            //if (Convert.ToInt32(((MovimientoAlmacenItemE)bsItems.Current).codSerie) != 0)
                            //{
                            //    frmBuscarTallas oFrm = new frmBuscarTallas(Convert.ToInt32(((MovimientoAlmacenItemE)bsItems.Current).codSerie));

                            //    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oSerieNum != null)
                            //    {
                            //        //oMovimientoAlmacen.ListaAlmacenItem[e.RowIndex].oLoteEntidad = oFrm.oLote;
                            //        oMovimientoAlmacen.ListaAlmacenItem[e.RowIndex].Lote = oFrm.oSerieNum.Talla.ToString();
                            //        bsItems.DataSource = oMovimientoAlmacen.ListaAlmacenItem;
                            //        bsItems.ResetBindings(false);
                            //    }
                            //}
                        }
                    }
                    else
                    {
                        Global.MensajeFault("Este almacén no maneja Lote para sus Artículos...");
                    }
                }
                
                if (dgvitems.Columns[e.ColumnIndex].Name == "numItem")
                {
                    //InputDialog ventana = new InputDialog();

                    //String numLote = InputDialog.mostrar("Introduzca el N° de Lote Correcto?", "Cambio de Lote", 0);

                    //if (!String.IsNullOrEmpty(numLote.Trim()))
                    //{
                    //    MovimientoAlmacenItemE Item = new MovimientoAlmacenItemE()
                    //    {
                    //        idEmpresa = ((MovimientoAlmacenItemE)bsItems.Current).idEmpresa,
                    //        tipMovimiento = ((MovimientoAlmacenItemE)bsItems.Current).tipMovimiento,
                    //        idItem = ((MovimientoAlmacenItemE)bsItems.Current).idItem,
                    //        Lote = numLote,
                    //        UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial
                    //    };

                    //    AgenteAlmacen.Proxy.ActualizarLoteMovAlmacen(Item);
                    //    Global.MensajeComunicacion("Se actualizó el Lote");
                    //    ((MovimientoAlmacenItemE)bsItems.Current).Lote = numLote;
                    //    bsItems.ResetBindings(false);
                    //}
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
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dgvitems.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnAsociar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txttipocambio.Text.Trim() == "0.000")
                {
                    Global.MensajeComunicacion("Debe ingresar Tipo de Cambio.");
                    return;
                }

                frmBuscaMovimientoAlmacen oFrm = new frmBuscaMovimientoAlmacen(Convert.ToInt32(cbotipMovimientoAsociar.SelectedValue), Convert.ToInt32(cboAlmacen.SelectedValue));

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.eMovAlmacen != null)
                {
                    txtidDocumentoAlmacenAsociar.Text = Convert.ToString(oFrm.eMovAlmacen.idDocumentoAlmacen);

                    MovimientoAlmacenE oMovEgreso = AgenteAlmacen.Proxy.ObtenerMovimientoAlmacenCompleto(oFrm.eMovAlmacen.idEmpresa, oFrm.eMovAlmacen.tipMovimiento, oFrm.eMovAlmacen.idDocumentoAlmacen);

                    for (int i = 0; i < oMovEgreso.ListaAlmacenItem.Count; i++)
                    {
                        int idEmpresa = oMovEgreso.ListaAlmacenItem[i].idEmpresa;
                        int tipMovimiento = oMovEgreso.ListaAlmacenItem[i].tipMovimiento;
                        int idDocumentoAlmacen = oMovEgreso.ListaAlmacenItem[i].idDocumentoAlmacen;
                        int idArticulo = Convert.ToInt32(oMovEgreso.ListaAlmacenItem[i].idArticulo);

                        string lote = oMovEgreso.ListaAlmacenItem[i].Lote;
                        decimal cantidad = oMovEgreso.ListaAlmacenItem[i].Cantidad;
                        decimal precio_uni = oMovEgreso.ListaAlmacenItem[i].ImpCostoUnitarioBase;
                        decimal impVenta = oMovEgreso.ListaAlmacenItem[i].ImpTotalRefe;
                        decimal impTotal = oMovEgreso.ListaAlmacenItem[i].ImpTotalBase;
                        Int32 idItemCompra = oMovEgreso.ListaAlmacenItem[i].idItem;

                        //txtRuc.Text = oMovEgreso.RUC;
                        txtproveedor.Text = oMovEgreso.RazonSocial;
                        //txtGlosa.Text = oMovEgreso.Observacion;
                        //oEntidad.idPersona = oMovEgreso.idProveedor;

                        AgregarArticulo(AgenteMaestros.Proxy.ObtenerArticuloServ(idEmpresa, idArticulo), lote, cantidad, precio_uni, impVenta, impTotal, idItemCompra, "");
                    }

                    SumarTotal();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkIndFactura_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIndFactura.Checked)
            {
                cboDocumento.Enabled = true;
                txtSerieDoc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtNumDoc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                dtpFecDocumento.Enabled = true;
                dtpFecDocumento_ValueChanged(null, null);
            }
            else
            {
                cboDocumento.Enabled = false;
                txtSerieDoc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtNumDoc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                dtpFecDocumento.Enabled = false;
                dtpFecProceso_ValueChanged(null, null);
            }
        }

        private void dtpFecDocumento_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkIndFactura.Checked && chbtipo_cambio.Checked)
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
                if (!string.IsNullOrEmpty(txtRuc.Text.Trim()) && string.IsNullOrEmpty(txtproveedor.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtproveedor.TextChanged -= txtproveedor_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtIdProveedor.Text = oFrm.oPersona.IdPersona.ToString();
                            txtproveedor.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtproveedor.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdProveedor.Text = oListaPersonas[0].IdPersona.ToString();
                        txtproveedor.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtIdProveedor.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtproveedor.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtproveedor.TextChanged += txtproveedor_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtproveedor.Text = String.Empty;
            txtIdProveedor.Text = String.Empty;
        }

        private void txtproveedor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtproveedor.Text.Trim()) && string.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtproveedor.TextChanged -= txtproveedor_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtproveedor.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtIdProveedor.Text = oFrm.oPersona.IdPersona.ToString();
                            txtproveedor.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtproveedor.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdProveedor.Text = oListaPersonas[0].IdPersona.ToString();
                        txtproveedor.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtIdProveedor.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtproveedor.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtproveedor.TextChanged += txtproveedor_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtproveedor_TextChanged(object sender, EventArgs e)
        {
            txtIdProveedor.Text = string.Empty;
            txtRuc.Text = string.Empty;
        }

        private void dtpFecProceso_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!chkIndFactura.Checked && chbtipo_cambio.Checked)
                {
                    DateTime Fecha = dtpFecProceso.Value;
                    TipoCambioE Tica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, Fecha.ToString("yyyyMMdd"));

                    if (Tica != null)
                    {
                        txttipocambio.Text = Tica.valVenta.ToString("N3");
                        RecalculaColumnsDetalle();
                    }
                    else
                    {
                        txttipocambio.Text = Variables.ValorCeroDecimal.ToString("N3");
                        dtpFecProceso.Focus();
                        Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txttipocambio_Enter(object sender, EventArgs e)
        {
            txttipocambio.SeleccinarTodo();
        }

        private void txttipocambio_MouseClick(object sender, MouseEventArgs e)
        {
            txttipocambio.SeleccinarTodo();
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

        private void btBuscarTexto_Click(object sender, EventArgs e)
        {
            BuscarArticulo(txtBuscar.Text.ToUpper(), "nomArticulo", dgvitems);
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

        private void btSalidas_Click(object sender, EventArgs e)
        {
            frmEntradaDetalleSalidasLote oFrm = new frmEntradaDetalleSalidasLote(oMovimientoAlmacen.ListaMovimientoSalidas);
            oFrm.ShowDialog();
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

        private void btActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarExcel(txtRuta.Text);
                btExaminar.Enabled = true;
                btAgregar.Enabled = false;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
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

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "FormatoEntrada", "Archivos Excel (*.xlsx)|*.xlsx");

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
