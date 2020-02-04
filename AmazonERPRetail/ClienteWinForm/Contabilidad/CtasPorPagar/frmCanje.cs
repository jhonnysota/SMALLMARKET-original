using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.CtasPorPagar;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;
using ClienteWinForm.Tesoreria;
using InputKey;

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmCanje : FrmMantenimientoBase
    {

        #region Constructores

        //Nuevo
        public frmCanje()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
            FormatoGrid(dgvCanjeDsctoItem, false);
            FormatoGrid(dgvLetrasItem, false);
        }

        //Edición
        public frmCanje(CanjeE oCanjeLetra)
            :this()
        {
            oCanje = AgenteCtasPorPagar.Proxy.ObtenerCanjeCompleto(oCanjeLetra.idCanje);
        } 

        #endregion

        #region Variables

        Boolean YaEntro = false;
        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        CanjeE oCanje = null;

        #endregion

        #region Procedimientos de Usuario

        void Datos()
        {
            oCanje.numCanje = txtCanjeNum.Text.Trim();
            oCanje.FechaCanje = dtpFechaProceso.Value.Date;
            oCanje.TipoCambio = Convert.ToDecimal(txtTipCambio.Text);
            oCanje.idPersona = Convert.ToInt32(txtIdProveedor.Text);
            oCanje.idMonedaCanje = Convert.ToString(cboMoneda.SelectedValue);
            oCanje.indRetencion = chkRetencion.Checked;

            if (oCanje.idMonedaCanje == Variables.Soles)
            {
                oCanje.MontoCanje = Convert.ToDecimal(lblTotaSol.Text);
            }
            else
            {
                oCanje.MontoCanje = Convert.ToDecimal(lblTotalDol.Text);
            }

            if (String.IsNullOrWhiteSpace(txtCanjeNum.Text))
            {
                oCanje.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oCanje.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void LlenarCombos()
        {
            ////// Moneda ///////
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListaMoneda
                                                             where x.idMoneda == "01"
                                                             || x.idMoneda == "02"
                                                             orderby x.idMoneda
                                                             select x).ToList(), "idMoneda", "desAbreviatura", false);
            // Dias //
            List<ParTabla> oListaDias = AgenteGeneral.Proxy.ListarParTablaPorValorCadena("LET");
            oListaDias.Add(new ParTabla() { Descripcion = "0", Nombre = Variables.Seleccione });
            ComboHelper.LlenarCombos<ParTabla>(cboDias, (from x in oListaDias orderby x.Descripcion select x).ToList(), "Descripcion", "Nombre");

            ListaMoneda = null;
            oListaDias = null;
        }

        void ObtenerTiCa()
        {
            DateTime Fecha = dtpFechaProceso.Value.Date;
            TipoCambioE Tica = VariablesLocales.RetornaTipoCambio(cboMoneda.SelectedValue.ToString(), Fecha);

            if (Tica != null)
            {
                txtTipCambio.Text = Tica.valVenta.ToString("N3");
            }
            else
            {
                txtTipCambio.Text = Variables.ValorCeroDecimal.ToString("N3");
                dtpFechaProceso.Focus();
                Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
            }
        }

        void Opciones()
        {
            if (rbFila.Checked)
            {
                cboDias.Enabled = false;
                cboDias.SelectedValue = "0";
                txtDia.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }

            if (rbPorDias.Checked)
            {
                cboDias.Enabled = true;
                txtDia.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }

            if (rbFijo.Checked)
            {
                cboDias.Enabled = false;
                cboDias.SelectedValue = "0";
                txtDia.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }

            txtCuotas.Focus();
        }

        void SumarTotales()
        {
            if (oCanje.ListaCanjeDctoItem.Count > 0)
            {
                Decimal totSoles = oCanje.ListaCanjeDctoItem.Sum(x => x.MontoSoles);
                Decimal totDolares = oCanje.ListaCanjeDctoItem.Sum(x => x.MontoDolares);
                Decimal reteSoles = oCanje.ListaCanjeDctoItem.Sum(x => x.MontoReteSoles);
                Decimal reteDolares = oCanje.ListaCanjeDctoItem.Sum(x => x.MontoReteDolares);

                lblTotaSol.Text = totSoles.ToString("N2");
                lblTotalDol.Text = totDolares.ToString("N2");
                lblTotReteS.Text = reteSoles.ToString("N2");
                lblTotReteD.Text = reteDolares.ToString("N2");
            }
            else
            {
                lblTotaSol.Text = "0.00";
                lblTotalDol.Text = "0.00";
                lblTotReteS.Text = "0.00";
                lblTotReteD.Text = "0.00";
            }

            if (oCanje.ListaLetrasItem.Count > 0)
            {
                Decimal totSolesLet = oCanje.ListaLetrasItem.Sum(x => x.MontoSoles);
                Decimal totDolaresLet = oCanje.ListaLetrasItem.Sum(x => x.MontoDolares);

                lblSolPrim.Text = totSolesLet.ToString("N2");
                lblDolSeg.Text = totDolaresLet.ToString("N2");
            }
            else
            {
                lblSolPrim.Text = "0.00";
                lblDolSeg.Text = "0.00";
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (oCanje == null)
                {
                    oCanje = new CanjeE
                    {
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        idLocal = VariablesLocales.SesionLocal.IdLocal
                    };

                    txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                    txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                    dtpFechaProceso_ValueChanged(null, null);
                }
                else
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtProveedor.TextChanged -= txtProveedor_TextChanged;

                    txtCanjeNum.Text = oCanje.numCanje;
                    dtpFechaProceso.Value = oCanje.FechaCanje;
                    txtTipCambio.Text = oCanje.TipoCambio.ToString("N3");
                    cboMoneda.SelectedValue = oCanje.idMonedaCanje.ToString();
                    txtIdProveedor.Text = oCanje.idPersona.ToString();
                    txtRuc.Text = oCanje.RUC;
                    txtProveedor.Text = oCanje.RazonSocial;
                    chkRetencion.Checked = oCanje.indRetencion;
                    txtUsuarioRegistro.Text = oCanje.UsuarioRegistro;
                    txtFechaRegistro.Text = oCanje.FechaRegistro.ToString();
                    txtUsuarioModificacion.Text = oCanje.UsuarioModificacion;
                    txtFechaModificacion.Text = oCanje.FechaModificacion.ToString();

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtProveedor.TextChanged += txtProveedor_TextChanged;
                }

                bsCanjeDscto.DataSource = oCanje.ListaCanjeDctoItem;
                bsCanjeDscto.ResetBindings(false);

                bsLetrasItem.DataSource = oCanje.ListaLetrasItem;
                bsLetrasItem.ResetBindings(false);

                SumarTotales();

                if (oCanje.Estado == "AN") //Anulada
                {
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                    pnlPrincipales.Enabled = false;
                    btInsertarCanje.Enabled = false;
                    btAgregarLetra.Enabled = false;
                    btBorrarCanje.Enabled = false;
                    btQuitarLetra.Enabled = false;
                    Global.MensajeFault("No podrá modificar, este canje se encuentra Anulado.");
                }
                else if (oCanje.Estado == "AC") //Aceptada
                {
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                    pnlPrincipales.Enabled = false;
                    btInsertarCanje.Enabled = false;
                    btAgregarLetra.Enabled = false;
                    btBorrarCanje.Enabled = false;
                    btQuitarLetra.Enabled = false;
                    Global.MensajeFault("No podrá modificar, este canje se encuentra Aceptada.");
                }
                else
                {
                    base.Nuevo();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Grabar()
        {
            try
            {
                if (oCanje != null)
                {
                    Datos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (String.IsNullOrWhiteSpace(txtCanjeNum.Text))
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oCanje = AgenteCtasPorPagar.Proxy.GrabarCanje(oCanje, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oCanje = AgenteCtasPorPagar.Proxy.GrabarCanje(oCanje, EnumOpcionGrabar.Actualizar);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                }

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<CanjeE>(oCanje);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmCanje_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
            chkRetencion.Checked = VariablesLocales.SesionUsuario.Empresa.AgenteRetenedor;
        }

        private void dtpFechaProceso_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ObtenerTiCa();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboMoneda.SelectedIndex == 0)
            {
                //txtCuenta.Text = "423101";
            }
            
            if (cboMoneda.SelectedIndex == 1)
            {
                //txtCuenta.Text = "423102";
            }
          
        }

        private void dgvLetrasItem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == 0)
                    {
                        dgvLetrasItem.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                        e.CellStyle.BackColor = Color.Bisque;
                    }

                    if (e.ColumnIndex == 1)
                    {
                        dgvLetrasItem.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                        e.CellStyle.BackColor = Color.Bisque;
                    }

                    if (e.ColumnIndex == 2)
                    {
                        dgvLetrasItem.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                        e.CellStyle.BackColor = Color.Bisque;
                    }

                    if (cboMoneda.SelectedValue.ToString() == "01")
                    {
                        if (dgvLetrasItem.Columns["MontoSoles"].Name == "MontoSoles")
                        {
                            dgvLetrasItem.Rows[e.RowIndex].Cells["MontoSoles"].ReadOnly = false;
                            dgvLetrasItem.Rows[e.RowIndex].Cells["MontoDolares"].ReadOnly = true;
                            dgvLetrasItem.Rows[e.RowIndex].Cells["MontoSoles"].Style.BackColor = Color.White;
                            dgvLetrasItem.Rows[e.RowIndex].Cells["MontoDolares"].Style.BackColor = Color.Bisque;
                        }
                    }

                    if (cboMoneda.SelectedValue.ToString() == "02")
                    {
                        if (dgvLetrasItem.Columns["MontoDolares"].Name == "MontoDolares")
                        {
                            dgvLetrasItem.Rows[e.RowIndex].Cells["MontoSoles"].ReadOnly = true;
                            dgvLetrasItem.Rows[e.RowIndex].Cells["MontoDolares"].ReadOnly = false;
                            dgvLetrasItem.Rows[e.RowIndex].Cells["MontoSoles"].Style.BackColor = Color.Bisque;
                            dgvLetrasItem.Rows[e.RowIndex].Cells["MontoDolares"].Style.BackColor = Color.White; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvLetrasItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Elimina el mensaje de error de la cabecera de la fila
                dgvLetrasItem.Rows[e.RowIndex].ErrorText = String.Empty;
                SumarTotales();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvLetrasItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLetrasItem.Rows.Count > Variables.Cero)
            {
                // Cuando se cambia la Cantidad
                if (!YaEntro)
                {
                    DataGridViewCell cellCantidad = dgvLetrasItem.Rows[e.RowIndex].Cells["MontoSoles"];
                    DataGridViewCell cellCantidad2 = dgvLetrasItem.Rows[e.RowIndex].Cells["MontoDolares"];
                    Decimal Cantidad1 = Variables.ValorCeroDecimal;
                    Decimal Cantidad2 = Variables.ValorCeroDecimal;
                    Decimal.TryParse(Convert.ToString(cellCantidad.Value), out Cantidad1);
                    Decimal.TryParse(Convert.ToString(cellCantidad2.Value), out Cantidad2);

                    if (Cantidad1 >= 0)
                    {
                        Decimal tot1 = Cantidad1 + Cantidad2;
                        lblSolPrim.Text = Convert.ToString(tot1);
                    }

                    if (Cantidad2 >= 0)
                    {
                        Decimal tot2 = Cantidad2 + Cantidad1;
                        lblDolSeg.Text = Convert.ToString(tot2);
                    }
                }
            }
        }

        private void btInsertarCanje_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtProveedor.Text))
                {
                    Global.MensajeComunicacion("Debe Ingresar un auxiliar.");
                    return;
                }

                frmPendientesAuxiliares oFrm = new frmPendientesAuxiliares(Convert.ToInt32(txtIdProveedor.Text), txtRuc.Text.Trim(), txtProveedor.Text.Trim(), "N");

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaCtaCte.Count > Variables.Cero)
                {
                    foreach (CtaCteE item in oFrm.oListaCtaCte)
                    {
                        CanjeDctoItemE CanjeDcto = new CanjeDctoItemE
                        {
                            idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                            idLocal = VariablesLocales.SesionLocal.IdLocal,
                            idPersona = item.idPersona,
                            numVerPlanCuentas = item.numVerPlanCuentas,
                            codCuenta = item.codCuenta,
                            Documento = item.idDocumento + " " + item.numSerie + "-" + item.numDocumento,
                            idDocumento = item.idDocumento,
                            serDocumento = item.numSerie,
                            numDocumento = item.numDocumento,
                            FechaDocumento = item.FechaDocumento,
                            FechaVencimiento = item.FechaVencimiento,
                            idMonedaOrigen = item.idMoneda,
                            desMoneda = item.desMoneda,
                            MontoOrigen = item.Saldo,
                            TipoCambio = Convert.ToDecimal(txtTipCambio.Text),
                            UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                            FechaRegistro = VariablesLocales.FechaHoy,
                            UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                            FechaModificacion = VariablesLocales.FechaHoy,
                            Opcion = (Int32)EnumOpcionGrabar.Insertar
                        };

                        if (item.idMoneda == "01")
                        {
                            CanjeDcto.MontoSoles = item.Saldo;
                            CanjeDcto.MontoDolares = item.Saldo / Convert.ToDecimal(txtTipCambio.Text);
                        }
                        if (item.idMoneda == "02")
                        {
                            CanjeDcto.MontoSoles = item.Saldo * Convert.ToDecimal(txtTipCambio.Text);
                            CanjeDcto.MontoDolares = item.Saldo;
                        }
                        
                        CanjeDcto.indDebeHaber = item.indDebeHaber;

                        if (chkRetencion.Checked)
                        {
                            ImpuestosPeriodoE oImpuestoRete = AgenteGeneral.Proxy.ObtenerPorcentajeImpuesto(3, item.FechaDocumento);

                            if (oImpuestoRete != null)
                            {
                                CanjeDcto.PorRetencion = oImpuestoRete.Porcentaje;
                                CanjeDcto.MontoReteSoles = CanjeDcto.MontoSoles * (oImpuestoRete.Porcentaje / 100);
                                CanjeDcto.MontoReteDolares = CanjeDcto.MontoDolares * (oImpuestoRete.Porcentaje / 100);
                            }
                        }
                        else
                        {
                            CanjeDcto.PorRetencion = 0;
                            CanjeDcto.MontoReteSoles = 0;
                            CanjeDcto.MontoReteDolares = 0;
                        }

                        oCanje.ListaCanjeDctoItem.Add(CanjeDcto);
                    }

                    bsCanjeDscto.DataSource = oCanje.ListaCanjeDctoItem;
                    bsCanjeDscto.ResetBindings(false);
                    SumarTotales();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btBorrarCanje_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsCanjeDscto.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        base.QuitarDetalle();

                        if (oCanje.ListaDocsEliminados == null)
                        {
                            oCanje.ListaDocsEliminados = new List<CanjeDctoItemE>();
                        }

                        //Agregando el registro a eliminar a la lista de eliminados
                        oCanje.ListaDocsEliminados.Add((CanjeDctoItemE)bsCanjeDscto.Current);
                        //Removiendo de la lista principal(temporalmente)...
                        oCanje.ListaCanjeDctoItem.RemoveAt(bsCanjeDscto.Position);
                        //Actualizando la lista...
                        bsCanjeDscto.DataSource = oCanje.ListaCanjeDctoItem;
                        bsCanjeDscto.ResetBindings(false);
                        SumarTotales();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btAgregarLetra_Click(object sender, EventArgs e)
        {
            try
            {
                bsLetrasItem.EndEdit();

                if (txtCuotas.Text == "0" || String.IsNullOrWhiteSpace(txtCuotas.Text))
                {
                    Global.MensajeComunicacion("Debe ingresar las cuotas antes de generar las letras.");
                    txtCuotas.Focus();
                    return;
                }

                if (Convert.ToDecimal(lblTotaSol.Text) == 0 || Convert.ToDecimal(lblTotalDol.Text) == 0)
                {
                    Global.MensajeComunicacion("Debe ingresar documentos antes de generar la letras.");
                    return;
                }

                if (oCanje.ListaLetrasItem != null && oCanje.ListaLetrasItem.Count > 0)
                {
                    if (oCanje.ListaLetrasEliminados == null)
                    {
                        oCanje.ListaLetrasEliminados = new List<LetrasItemE>();
                    }

                    oCanje.ListaLetrasEliminados.AddRange(oCanje.ListaLetrasItem);
                }

                oCanje.ListaLetrasItem = new List<LetrasItemE>();
                LetrasItemE ItemNuevo = null;
                String ValorDevuelto = String.Empty;
                DateTime? FechaVencAnte = null;
                Decimal MontoS = ((Convert.ToDecimal(lblTotaSol.Text) - Convert.ToDecimal(lblTotReteS.Text)) / Convert.ToDecimal(txtCuotas.Text));
                Decimal MontoD = ((Convert.ToDecimal(lblTotalDol.Text) - Convert.ToDecimal(lblTotReteD.Text)) / Convert.ToDecimal(txtCuotas.Text));
                Int32 Mes = dtpFechaProceso.Value.Month;
                Int32 Anio = dtpFechaProceso.Value.Year;
                Int32 Dias = 0;
                Int32 DiasCorridos = 0;
                Int32 DiaFijo = Convert.ToInt32(txtDia.Text);
                List<String> ListaDias = null;

                for (int i = 1; i <= Convert.ToInt32(txtCuotas.Text); i++)
                {
                    ItemNuevo = new LetrasItemE
                    {
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        idLocal = VariablesLocales.SesionLocal.IdLocal,
                        idPersona = Convert.ToInt32(txtIdProveedor.Text),
                        FechaEmision = dtpFechaProceso.Value.Date,
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                        FechaRegistro = VariablesLocales.FechaHoy,
                        UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                        FechaModificacion = VariablesLocales.FechaHoy,
                        Opcion = (int)EnumOpcionGrabar.Insertar
                    };

                    ValorDevuelto = InputDialog.mostrar("Introduzca el N° de Letra", "N° de Letra", 0);

                    if (String.IsNullOrWhiteSpace(ValorDevuelto))
                    {
                        throw new Exception("Debe ingresar un N° de Letra.");
                    }
                    else
                    {
                        foreach (LetrasItemE item in oCanje.ListaLetrasItem)
                        {
                            if (item.numLetra == ValorDevuelto)
                            {
                                Global.MensajeComunicacion("El N° de Letra ya ha sido ingresado, intente nuevamente.");
                                ValorDevuelto = InputDialog.mostrar("Introduzca el N° de Letra", "N° de Letra", 0);
                                break;
                            }
                        }

                        ItemNuevo.numLetra = ValorDevuelto;
                    }

                    if (rbFila.Checked)
                    {
                        ValorDevuelto = InputDialog.mostrar("Introduzca la Fecha de Vencimiento (dd/mm/yyyy o dd-mm-yyyy)", "Fecha de Vencimiento", 0);

                        if (String.IsNullOrWhiteSpace(ValorDevuelto))
                        {
                            throw new Exception("Debe colocar un fecha válida.");
                        }

                        DateTime FechaVenc = Convert.ToDateTime(ValorDevuelto);

                        if (FechaVencAnte != null)
                        {
                            if (FechaVenc < FechaVencAnte)
                            {
                                throw new Exception("La fecha de vencimiento no puede ser menor a la anterior.");
                            }
                        }
                        else
                        {
                            if (FechaVenc < ItemNuevo.FechaEmision)
                            {
                                throw new Exception("La fecha de vencimiento no puede ser menor a la fecha de emisión.");
                            }
                        }

                        ItemNuevo.FechaVencimiento = FechaVenc.Date;
                        FechaVencAnte = ItemNuevo.FechaVencimiento;
                    }

                    if (rbPorDias.Checked)
                    {
                        if (cboDias.SelectedValue.ToString() == "0")
                        {
                            cboDias.Focus();
                            throw new Exception("Debe escoger los dias que van a transcurrir.");
                        }

                        if (ListaDias == null)
                        {
                            String Patron = @"(?:- *)?\d+(?:\.\d+)?";
                            String Cadena = ((ParTabla)cboDias.SelectedItem).Nombre;
                            Regex regex = new Regex(Patron);
                            ListaDias = regex.Matches(Cadena).OfType<Match>().Select(m => m.Value).ToList();
                        }

                        if (ListaDias.Count > 1)
                        {
                            if (Dias == 0)
                            {
                                if (ListaDias.Count != Convert.ToInt32(txtCuotas.Text))
                                {
                                    throw new Exception("Las cuotas difieren de la cantidad de dias.");
                                }

                                DiasCorridos = Dias = Convert.ToInt32(ListaDias[0]);
                            }
                            else
                            {
                                ListaDias = ListaDias.FindAll(
                                delegate (string d)
                                {
                                    return d != Dias.ToString();
                                });

                                Dias = Convert.ToInt32(ListaDias[0]);
                                DiasCorridos += Dias;
                            }

                            ItemNuevo.FechaVencimiento = ItemNuevo.FechaEmision.AddDays(DiasCorridos);
                        }
                        else
                        {
                            if (Dias == 0)
                            {
                                DiasCorridos = Dias = Convert.ToInt32(ListaDias[0]);
                            }

                            ItemNuevo.FechaVencimiento = ItemNuevo.FechaEmision.AddDays(DiasCorridos);
                            DiasCorridos += Dias;
                        }
                    }

                    if (rbFijo.Checked)
                    {
                        Mes ++;

                        if (Mes > 12)
                        {
                            Anio++;
                            Mes = 1;
                        }

                        ItemNuevo.FechaVencimiento = Convert.ToDateTime(DiaFijo.ToString() + "/" + Mes.ToString() + "/" + Anio.ToString());
                    }

                    ItemNuevo.idMoneda = Convert.ToString(cboMoneda.SelectedValue);
                    ItemNuevo.MontoLetra = ItemNuevo.idMoneda == Variables.Soles ? MontoS : MontoD;

                    if (VariablesLocales.oConParametros != null)
                    {
                        if (ItemNuevo.idMoneda == Variables.Soles)
                        {
                            if (!String.IsNullOrWhiteSpace(VariablesLocales.oConParametros.codCtaLetraS))
                            {
                                ItemNuevo.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                                ItemNuevo.codCuenta = VariablesLocales.oConParametros.codCtaLetraS;
                            }
                            else
                            {
                                throw new Exception("Falta configurar la cuenta de Letras en Soles en los Parámetros Contables");
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrWhiteSpace(VariablesLocales.oConParametros.codCtaLetraD))
                            {
                                ItemNuevo.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                                ItemNuevo.codCuenta = VariablesLocales.oConParametros.codCtaLetraD;
                            }
                            else
                            {
                                throw new Exception("Falta configurar la cuenta de Letras en Dólares en los Parámetros Contables");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Falta configurar Los Parámetros Contables");
                    }

                    ItemNuevo.MontoSoles = MontoS;
                    ItemNuevo.MontoDolares = MontoD;
                    ItemNuevo.Estado = ItemNuevo.Estado;

                    oCanje.ListaLetrasItem.Add(ItemNuevo);
                }

                bsLetrasItem.DataSource = oCanje.ListaLetrasItem;
                bsLetrasItem.ResetBindings(false);
                bsLetrasItem.MoveLast();

                base.AgregarDetalle();
                SumarTotales();
            }
            catch (Exception ex)
            {
                if (ex.Message.ToString().Contains("valor DateTime válido"))
                {
                    Global.MensajeFault("Debe ingresar una fecha válida");
                }
                else
                {
                    Global.MensajeFault(ex.Message);
                }
            }
        }

        private void btQuitarLetra_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsLetrasItem.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        if (oCanje.ListaLetrasEliminados == null)
                        {
                            oCanje.ListaLetrasEliminados = new List<LetrasItemE>();
                        }

                        base.QuitarDetalle();

                        //Agregando a la lista de letras eliminadas...
                        oCanje.ListaLetrasEliminados.Add((LetrasItemE)bsLetrasItem.Current);
                        //Removiendo de la lista principal(temporalmente)...
                        oCanje.ListaLetrasItem.RemoveAt(bsLetrasItem.Position);
                        //Actualizando la lista...
                        bsLetrasItem.DataSource = oCanje.ListaLetrasItem;
                        bsLetrasItem.ResetBindings(false);

                        SumarTotales();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtProveedor.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtProveedor.TextChanged -= txtProveedor_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdProveedor.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtProveedor.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtProveedor.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdProveedor.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtProveedor.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        txtRuc.Text = String.Empty;
                        txtProveedor.Text = String.Empty;
                        Global.MensajeFault("El Ruc ingresado no existe");
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtProveedor.TextChanged += txtProveedor_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtProveedor.TextChanged += txtProveedor_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtProveedor_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtProveedor.Text.Trim()) && String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtProveedor.TextChanged -= txtProveedor_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtProveedor.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdProveedor.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtProveedor.Text = oFrm.oPersona.RazonSocial;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdProveedor.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtProveedor.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        txtRuc.Text = String.Empty;
                        txtProveedor.Text = String.Empty;
                        Global.MensajeFault("La razón social ingresada no existe");
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtProveedor.TextChanged += txtProveedor_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtProveedor.TextChanged += txtProveedor_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtIdProveedor.Text = String.Empty;
            txtProveedor.Text = String.Empty;
        }

        private void txtProveedor_TextChanged(object sender, EventArgs e)
        {
            txtIdProveedor.Text = String.Empty;
            txtRuc.Text = String.Empty;
        }

        private void rbFila_CheckedChanged(object sender, EventArgs e)
        {
            Opciones();
        }

        private void rbPorDias_CheckedChanged(object sender, EventArgs e)
        {
            Opciones();
        }

        private void rbFijo_CheckedChanged(object sender, EventArgs e)
        {
            Opciones();
        }

        private void dgvLetrasItem_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dgvLetrasItem.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        #endregion

    }
}
