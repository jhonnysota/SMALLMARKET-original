using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Tesoreria;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Recursos;
using ClienteWinForm.Busquedas;
using ClienteWinForm.Ventas.Facturacion;

namespace ClienteWinForm.Ventas
{
    public partial class frmLetrasCanje : FrmMantenimientoBase
    {

        #region Constructores

        //Nuevo
        public frmLetrasCanje()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvCanje, true);
            dgvCanje.RowHeadersWidth = 35;
            dgvCanje.BorderStyle = BorderStyle.Fixed3D;
            FormatoGrid(dgvLetras, false);

            Tipo = "Letras";
        }
        
        //Edición
        public frmLetrasCanje(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String BloquerTodo = "N", String FormAprobacion = "N")
            : this()
        {
            Tipo = "Letras";
            oLetrasCanjeUnion = AgenteVentas.Proxy.ObtenerLetrasCanjeUnion(idEmpresa, idLocal, tipCanje, codCanje);

            txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);

            if (BloquerTodo == "N")
            {
                //P=Por Aceptar A=Aceptada 
                if (oLetrasCanjeUnion.oListaLetras[0].Estado == "A")//Que ya haya sido aceptada...
                {
                    Global.MensajeComunicacion("Las letras ya han sido aceptadas no podrá hacer ninguna modificación.");
                    Bloquear();
                    BloqueoBarra = true;
                }

                //P=Por Aceptar A=Aceptada 
                if (oLetrasCanjeUnion.oListaLetras[0].Estado == "B")//Si se encuntran anuladas...
                {
                    Global.MensajeComunicacion("Las letras se encuentran ANULADAS no podrá hacer ninguna modificación.");
                    Bloquear();
                    BloqueoBarra = true;
                } 
            }

            if (BloquerTodo == "S")//Si viene del formulario de aprobación bloquear
            {
                Bloquear();
                BloqueoBarra = true;
            }

            if (FormAprobacion == "S")
            {
                lblFecAprobacion.Visible = true;
                label7.Visible = true;

                if (oLetrasCanjeUnion.oListaCanjes[0].fecAprobacion != null)
                {
                    lblFecAprobacion.Text = oLetrasCanjeUnion.oListaCanjes[0].fecAprobacion.Value.ToString("d");
                }
            }
        }

        //Renovación
        public frmLetrasCanje(LetrasE oLetraTemp, String TipoCanje, String FormAprobacion = "N")
            : this()
        {
            if (TipoCanje == "RV") //Renovación
            {
                oCanje = new LetrasCanjeE()
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                    idDocumento = "LT",
                    desDocumento = "LETRA DE CAMBIO EMITIDA",
                    numSerie = String.Empty,
                    numDocumento = oLetraTemp.Numero + oLetraTemp.Corre,
                    fecDocumento = oLetraTemp.Fecha,
                    idMoneda = oLetraTemp.idMoneda,
                    tipCambioDoc = oLetraTemp.tipCambio.Value,
                    desMoneda = oLetraTemp.desMoneda,
                    idPersona = oLetraTemp.idPersona,
                    Ruc = oLetraTemp.RUC,
                    RazonSocial = oLetraTemp.RazonSocial,
                    SaldoDoc = oLetraTemp.MontoOrigen,
                    idComprobante = String.Empty,
                    numFile = String.Empty,
                    AnioPeriodo = String.Empty,
                    MesPeriodo = String.Empty,
                    numVoucher = String.Empty,
                    fecProceso = dtpFecProceso.Value.Date,
                    Glosa = txtGlosa.Text,
                    numVerPlanCuentas = oLetraTemp.numVerPlanCuentas,
                    codCuenta = oLetraTemp.CuentaContable,
                    idCtaCte = oLetraTemp.idCtaCte,
                    UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                    FechaRegistro = VariablesLocales.FechaHoy,
                    UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                    FechaModificacion = VariablesLocales.FechaHoy
                };

                //oLetrasCanjeUnion.oListaCanjes.Add(oCanje);
                btImprimir.Enabled = true;

                oLetra = oLetraTemp;
                oLetra.tipCanje = TipoCanje;

                if (FormAprobacion == "S")//Si viene del formulario de aprobación bloquear
                {
                    Bloquear();
                }
            }

            Tipo = "Letras";
        }

        //Documentos de Ventas
        public frmLetrasCanje(List<EmisionDocumentoE> oListaDocumentoVentas_, List<CondicionDiasE> ListaDias_)
            : this()
        {
            oListaDocumentosVentas = oListaDocumentoVentas_;
            ListaDias = ListaDias_;
            Tipo = "Ventas";
        }

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        LetrasCanjeUnionE oLetrasCanjeUnion = null;
        LetrasCanjeE oCanje = null;
        public LetrasE oLetra = null;
        public Int16 Opcion = Variables.Cero;
        List<LetrasCanjeE> oCanjesEliminados = new List<LetrasCanjeE>();
        List<LetrasE> oLetraEliminadas = new List<LetrasE>();
        List<EmisionDocumentoE> oListaDocumentosVentas = null;
        List<CondicionDiasE> ListaDias = null;
        Boolean BloqueoBarra = false;
        String Tipo = String.Empty;
        EmisionDocumentoE oDocumentoVenta = null;

        #endregion Variables

        #region Procedimientos de Usuario

        void SumarSaldo()
        {
            if (oLetrasCanjeUnion.oListaCanjes != null && oLetrasCanjeUnion.oListaCanjes.Count > Variables.Cero)
            {
                Decimal MontoNC = 0;
                Decimal Monto = 0;
                Decimal Saldo = 0;

                MontoNC = Convert.ToDecimal((from x in oLetrasCanjeUnion.oListaCanjes where x.idDocumento == "NC" select x.SaldoDoc).Sum());
                Monto   = Convert.ToDecimal((from x in oLetrasCanjeUnion.oListaCanjes where x.idDocumento != "NC" select x.SaldoDoc).Sum());
                Saldo   = Monto - MontoNC;

                lblTotalSaldo.Text = Saldo.ToString("N2");
            }
            else
            {
                lblTotalSaldo.Text = "0.00";
            }
        }

        void SumarMontos()
        {
            if (oLetrasCanjeUnion.oListaLetras != null && oLetrasCanjeUnion.oListaLetras.Count > Variables.Cero)
            {
                lblAbono.Text = Convert.ToDecimal((from x in oLetrasCanjeUnion.oListaLetras select x.MontoOrigen).Sum()).ToString("N2");
                lblSoles.Text = Convert.ToDecimal((from x in oLetrasCanjeUnion.oListaLetras select x.MontoSoles).Sum()).ToString("N2");
                lblDolares.Text = Convert.ToDecimal((from x in oLetrasCanjeUnion.oListaLetras select x.MontoDolares).Sum()).ToString("N2");
            }
            else
            {
                lblAbono.Text = "0.00";
                lblSoles.Text = "0.00";
                lblDolares.Text = "0.00";
            }
        }

        Boolean RevisarCliente()
        {
            if (String.IsNullOrEmpty(txtIdCliente.Text.Trim()))
            {
                Global.MensajeFault("No se ha definido ningún Cliente.");
                return false;
            }

            return true;
        }

        Boolean RevisarNuevoCanje()
        {
            if (!RevisarCliente())
            {
                return false;
            }

            if (oLetrasCanjeUnion.oListaCanjes == null || oLetrasCanjeUnion.oListaCanjes.Count == Variables.Cero)
            {
                Global.MensajeFault("No hay documentos para hacer el canje.");
                return false;
            }

            if (Convert.ToDecimal(lblAbono.Text) >= Convert.ToDecimal(lblTotalSaldo.Text))
            {
                Global.MensajeFault("No puede sobrepasar el saldo total.");
                return false;
            }

            return true;
        }

        void Bloquear()
        {
            txtGlosa.Enabled = false;
            btAgregarNota.Enabled = false;
            dgvCanje.Enabled = false;
            btPendientes.Enabled = false;
            btNuevoCanje.Enabled = false;
            btEliminarCanje.Enabled = false;
            btNuevaLetra.Enabled = false;
            btELiminarLetra.Enabled = false;
        }

        void LlenarComboGrid()
        {
            DataGridViewComboBoxColumn oCombo = dgvCanje.Columns["cboDgvDocumentos"] as DataGridViewComboBoxColumn;
            List<DocumentosE> oListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                                       where x.indDocumentoVentas == true
                                                                       select x).ToList();

            ComboHelper.RellenarCombos<DocumentosE>(oCombo, oListaDocumentos, "idDocumento", "desDocumento");
        }

        void EditarDetalleLetra(DataGridViewCellEventArgs e, LetrasE oItem)
        {
            frmDetalleLetra oFrm = new frmDetalleLetra(oItem);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oLetra != null)
            {
                LetrasE letras = oFrm.oLetra;

                if (oLetrasCanjeUnion.oListaLetras[e.RowIndex].idVendedor == 0)
                {
                    if (oDocumentoVenta == null)
                    {
                        oDocumentoVenta = AgenteVentas.Proxy.ObtenerVendedorCondicion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, oLetrasCanjeUnion.oListaCanjes[0].idDocumento, oLetrasCanjeUnion.oListaCanjes[0].numSerie, oLetrasCanjeUnion.oListaCanjes[0].numDocumento);

                        if (oDocumentoVenta != null)
                        {
                            letras.idVendedor = oDocumentoVenta.idVendedor;
                            letras.idTipCondicion = oDocumentoVenta.idTipCondicion;
                            letras.idCondicion = oDocumentoVenta.idCondicion;
                        }
                        else
                        {
                            letras.idVendedor = null;
                            letras.idTipCondicion = null;
                            letras.idCondicion = null;
                        }
                    }
                }

                oLetrasCanjeUnion.oListaLetras[e.RowIndex] = oFrm.oLetra;
                bsLetras.DataSource = oLetrasCanjeUnion.oListaLetras;
                bsLetras.ResetBindings(false);
                SumarMontos();
            }
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (Tipo == "Letras")
            {
                if (oLetrasCanjeUnion != null) //////// EDICIÓN ////////
                {
                    LlenarComboGrid();
                    bsCanjeLetras.DataSource = oLetrasCanjeUnion.oListaCanjes;
                    bsCanjeLetras.ResetBindings(false);
                    bsLetras.DataSource = oLetrasCanjeUnion.oListaLetras;
                    bsLetras.ResetBindings(false);

                    txtIdCliente.Text = oLetrasCanjeUnion.oListaCanjes[0].idPersona.ToString();
                    txtRuc.Text = oLetrasCanjeUnion.oListaCanjes[0].Ruc;
                    txtRazonSocial.Text = oLetrasCanjeUnion.oListaCanjes[0].RazonSocial;
                    dtpFecProceso.Value = oLetrasCanjeUnion.oListaCanjes[0].fecProceso;
                    txtGlosa.Text = oLetrasCanjeUnion.oListaCanjes[0].Glosa;

                    lblLetras.Text = "Letras " + oLetrasCanjeUnion.oListaLetras.Count.ToString();

                    Opcion = (Int16)EnumOpcionGrabar.Actualizar;

                    SumarSaldo();
                    SumarMontos();
                }
                else
                {
                    oLetrasCanjeUnion = new LetrasCanjeUnionE();
                    LlenarComboGrid();

                    if (oCanje != null && oLetra != null && oLetra.tipCanje == "RV")
                    {
                        oLetrasCanjeUnion.oListaCanjes.Add(oCanje);

                        txtIdCliente.Text = oLetrasCanjeUnion.oListaCanjes[0].idPersona.ToString();
                        txtRuc.TextChanged -= txtRuc_TextChanged;
                        txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                        txtRuc.Text = oLetrasCanjeUnion.oListaCanjes[0].Ruc;
                        txtRazonSocial.Text = oLetrasCanjeUnion.oListaCanjes[0].RazonSocial;
                        txtRuc.TextChanged += txtRuc_TextChanged;
                        txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                        dtpFecProceso.Value = oLetrasCanjeUnion.oListaCanjes[0].fecProceso;
                        txtGlosa.Text = oLetrasCanjeUnion.oListaCanjes[0].Glosa;

                        SumarSaldo();
                    }

                    bsCanjeLetras.DataSource = oLetrasCanjeUnion.oListaCanjes;
                    bsCanjeLetras.ResetBindings(false);
                    bsLetras.DataSource = oLetrasCanjeUnion.oListaLetras;
                    bsLetras.ResetBindings(false);

                    Opcion = (Int16)EnumOpcionGrabar.Insertar;
                } 
            }

            if (Tipo == "Ventas")
            {
                if (oListaDocumentosVentas != null && oListaDocumentosVentas.Count > 0)
                {
                    /////////////////////////////////////////// CABECERA DE LA LETRA //////////////////////////////////////////////////
                    Decimal MontoSaldo = 0;
                    oLetrasCanjeUnion = new LetrasCanjeUnionE();

                    txtIdCliente.Text = oListaDocumentosVentas[0].idPersona.ToString();
                    txtRuc.Text = oListaDocumentosVentas[0].numRuc;
                    txtRazonSocial.Text = oListaDocumentosVentas[0].RazonSocial;
                    LlenarComboGrid();

                    foreach (EmisionDocumentoE item in oListaDocumentosVentas)
                    {
                        frmEscogerDetraRete oFrm = new frmEscogerDetraRete(item);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.MontoSaldo > 0)
                        {
                            MontoSaldo = oFrm.MontoSaldo;
                        }
                        else
                        {
                            MontoSaldo = item.totTotal;
                        }

                        //if (item.AfectoDetraccion)
                        //{
                        //    MontoSaldo = item.totTotal - item.MontoDetraccion;
                        //}
                        //else
                        //{
                        //    if (VariablesLocales.oListaImpuestos[2] == null)
                        //    {
                        //        throw new Exception("Falta ingresar el impuesto de Retención en Maestros/Impuestos");
                        //    }

                        //    MontoSaldo = item.totTotal - Math.Round((item.totTotal * (VariablesLocales.oListaImpuestos[2].Porcentaje) / 100), 2);
                        //}

                        //if (item.AfectoRetencion)
                        //{
                        //    MontoSaldo = Math.Round(item.totTotal - (item.totTotal * 0.03m), 2);
                        //}
                        //else
                        //{
                        //    MontoSaldo = item.totTotal;
                        //}

                        LetrasCanjeE oCanje = new LetrasCanjeE()
                        {
                            idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                            idLocal = VariablesLocales.SesionLocal.IdLocal,
                            idDocumento = item.idDocumento,
                            numSerie = item.numSerie,
                            numDocumento = item.numDocumento,
                            //fecDocumento = item.fecEmision, //Por revisar
                            idMoneda = item.idMoneda,
                            desMoneda = item.desMoneda,
                            SaldoDoc = MontoSaldo,
                            tipCambioDoc = 0, //Por actualizar en la capa de negocio
                            idPersona = Convert.ToInt32(txtIdCliente.Text),
                            fecProceso = dtpFecProceso.Value.Date,
                            Glosa = txtGlosa.Text,
                            numVerPlanCuentas = String.Empty, //Por actualizar en la capa de negocio
                            codCuenta = String.Empty, //Por actualizar en la capa de negocio
                            idCtaCte = 0, //Por actualizar en la capa de negocio
                            Opcion = (Int32)EnumOpcionGrabar.Insertar,
                            UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                            FechaRegistro = VariablesLocales.FechaHoy,
                            UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                            FechaModificacion = VariablesLocales.FechaHoy
                        };

                        oLetrasCanjeUnion.oListaCanjes.Add(oCanje);
                    }

                    bsCanjeLetras.DataSource = oLetrasCanjeUnion.oListaCanjes;
                    bsCanjeLetras.ResetBindings(false);
                    SumarSaldo();

                    /////////////////////////////////////////// DETALLE DE LA LETRA ////////////////////////////////////////////////
                    LetrasE oLetrita = null;
                    int canDivision = ListaDias.Count;
                    Decimal MontoLetra = Math.Round(MontoSaldo / canDivision, 2, MidpointRounding.AwayFromZero);
                    Decimal tipCambio = Convert.ToDecimal(VariablesLocales.TipoCambioDelDia.valVenta);

                    foreach (CondicionDiasE item in ListaDias)
                    {
                        #region Datos Letras

                        oLetrita = new LetrasE
                        {
                            idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                            idLocal = VariablesLocales.SesionLocal.IdLocal,
                            tipCanje = "CJ",
                            Numero = string.Empty,
                            Corre = "00",
                            Letra = string.Empty,
                            //Fecha = oListaDocumentosVentas[0].fecEmision, //Por revisar
                            //FechaVenc = oListaDocumentosVentas[0].fecEmision.AddDays(item.Dias), //Por revisar
                            idMoneda = oListaDocumentosVentas[0].idMoneda,
                            desMoneda = oListaDocumentosVentas[0].desMoneda,
                            Estado = "P",
                            desEstado = "Por Aceptar",
                            tipCambio = tipCambio,
                            Observacion = string.Empty,
                            UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                            FechaRegistro = VariablesLocales.FechaHoy,
                            UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                            FechaModificacion = VariablesLocales.FechaHoy,
                            Opcion = (Int32)EnumOpcionGrabar.Insertar
                        };

                        if (oLetrita.idMoneda == Variables.Soles)
                        {
                            oLetrita.MontoOrigen = MontoLetra;
                            oLetrita.MontoRefe = Math.Round(MontoLetra / tipCambio, 2, MidpointRounding.AwayFromZero);
                            oLetrita.MontoSoles = oLetrita.MontoOrigen;
                            oLetrita.MontoDolares = oLetrita.MontoRefe;
                        }
                        else
                        {
                            oLetrita.MontoOrigen = MontoLetra;
                            oLetrita.MontoRefe = Math.Round(MontoLetra * tipCambio, 2, MidpointRounding.AwayFromZero);
                            oLetrita.MontoDolares = oLetrita.MontoOrigen;
                            oLetrita.MontoSoles = oLetrita.MontoRefe;
                        }

                        #endregion Datos Letras

                        #region Cliente

                        Persona oPersona = AgenteMaestro.Proxy.RecuperarPersonaPorID(Convert.ToInt32(oListaDocumentosVentas[0].idPersona), VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "S");
                        oLetrita.idPersona = oPersona.IdPersona;
                        oLetrita.RUC = oPersona.RUC;
                        oLetrita.RazonSocial = oPersona.RazonSocial;
                        oLetrita.GiradoA = oPersona.RazonSocial;
                        oLetrita.Direccion = Global.DejarSoloUnEspacio(oPersona.DireccionCompleta.Trim().Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, ""));
                        oLetrita.Telefono = oPersona.Telefonos;
                        oLetrita.Plaza = "15";
                        oLetrita.Doi = oPersona.RUC;

                        #endregion Cliente

                        #region Avales

                        if (oPersona.oListaAvales != null && oPersona.oListaAvales.Count > Variables.Cero)
                        {
                            ClienteAvalE oClienteAval = (from x in oPersona.oListaAvales
                                                         where x.EsPrincipal == true
                                                         select x).SingleOrDefault();

                            if (oClienteAval != null)
                            {
                                oLetrita.Aval = oClienteAval.RazonSocial;
                                oLetrita.DireccionAval = oClienteAval.Direccion;
                                oLetrita.DoiAval = oClienteAval.nroDocumento;
                                oLetrita.TelefAval = oClienteAval.Telefonos;
                                oLetrita.DireccionAval = Global.DejarSoloUnEspacio(oClienteAval.Direccion.Trim().Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, ""));
                                //txtRepresentanteAval.Text = Global.DejarSoloUnEspacio(txtRepresentanteAval.Text.Trim().Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, ""));
                            }
                            else
                            {
                                oLetrita.Aval = string.Empty;
                                oLetrita.DireccionAval = string.Empty;
                                oLetrita.DoiAval = string.Empty;
                                oLetrita.TelefAval = string.Empty;
                                oLetrita.DireccionAval = string.Empty;
                                oLetrita.Representante = string.Empty;
                            }
                        }
                        else
                        {
                            oLetrita.Aval = string.Empty;
                            oLetrita.DireccionAval = string.Empty;
                            oLetrita.DoiAval = string.Empty;
                            oLetrita.TelefAval = string.Empty;
                            oLetrita.DireccionAval = string.Empty;
                            oLetrita.Representante = string.Empty;
                        }

                        #endregion Avales

                        oLetrasCanjeUnion.oListaLetras.Add(oLetrita);
                    }

                    #region Si existe alguna diferencia

                    decimal Diferencia = 0;

                    if (oListaDocumentosVentas[0].idMoneda == Variables.Soles)
                    {
                        if (Convert.ToDecimal(lblTotalSaldo.Text) != Convert.ToDecimal(lblSoles.Text))
                        {
                            Diferencia = Convert.ToDecimal(lblTotalSaldo.Text) - Convert.ToDecimal(lblSoles.Text);
                        }
                    }
                    else
                    {
                        if (Convert.ToDecimal(lblTotalSaldo.Text) != Convert.ToDecimal(lblDolares.Text))
                        {
                            Diferencia = Convert.ToDecimal(lblTotalSaldo.Text) - Convert.ToDecimal(lblDolares.Text);
                        }
                    }

                    if ((Diferencia != 0 && oListaDocumentosVentas[0].idMoneda == Variables.Dolares && Math.Abs(Diferencia) <= 0.03m) || (Diferencia != 0 && oListaDocumentosVentas[0].idMoneda == Variables.Soles && Math.Abs(Diferencia) <= 0.03m))
                    {
                        int Filas = oLetrasCanjeUnion.oListaLetras.Count;

                        if (oLetrasCanjeUnion.oListaLetras[Filas - 1].idMoneda == Variables.Soles)
                        {
                            oLetrasCanjeUnion.oListaLetras[Filas - 1].MontoOrigen += Diferencia;
                            oLetrasCanjeUnion.oListaLetras[Filas - 1].MontoRefe = Math.Round(oLetrasCanjeUnion.oListaLetras[Filas - 1].MontoOrigen / tipCambio, 2, MidpointRounding.AwayFromZero);
                            oLetrasCanjeUnion.oListaLetras[Filas - 1].MontoSoles = oLetrasCanjeUnion.oListaLetras[Filas - 1].MontoOrigen;
                            oLetrasCanjeUnion.oListaLetras[Filas - 1].MontoDolares = oLetrasCanjeUnion.oListaLetras[Filas - 1].MontoRefe;
                        }
                        else
                        {
                            oLetrasCanjeUnion.oListaLetras[Filas - 1].MontoOrigen += Diferencia;
                            oLetrasCanjeUnion.oListaLetras[Filas - 1].MontoRefe = Math.Round(oLetrasCanjeUnion.oListaLetras[Filas - 1].MontoOrigen * tipCambio, 2, MidpointRounding.AwayFromZero);
                            oLetrasCanjeUnion.oListaLetras[Filas - 1].MontoDolares = oLetrasCanjeUnion.oListaLetras[Filas - 1].MontoOrigen;
                            oLetrasCanjeUnion.oListaLetras[Filas - 1].MontoSoles = oLetrasCanjeUnion.oListaLetras[Filas - 1].MontoRefe;
                        }
                    }

                    #endregion

                    bsLetras.DataSource = oLetrasCanjeUnion.oListaLetras;
                    bsLetras.ResetBindings(false);
                    SumarMontos();
                    lblLetras.Text = "Letras " + oLetrasCanjeUnion.oListaLetras.Count.ToString();
                    Opcion = (Int32)EnumOpcionGrabar.Insertar;
                }
            }

            if (!BloqueoBarra)
            {
                base.Nuevo();
                BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
                BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
            }
            else
            {
                btPendientes.Enabled = false;
                btNuevoCanje.Enabled = false;
                btEliminarCanje.Enabled = false;
                btNuevaLetra.Enabled = false;
                btELiminarLetra.Enabled = false;

                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            }
        }

        public override void Grabar()
        {
            try
            {
                if (oLetrasCanjeUnion.oListaCanjes.Count > Variables.Cero && oLetrasCanjeUnion.oListaLetras.Count > Variables.Cero)
                {
                    bool Grabo = false;
                    dgvCanje.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    bsCanjeLetras.EndEdit();
                    bsLetras.EndEdit();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (Opcion == (Int16)EnumOpcionGrabar.Insertar)
                    {
                        Grabo = AgenteVentas.Proxy.GrabarLetrasCanje(oLetrasCanjeUnion, EnumOpcionGrabar.Insertar);

                        if (Grabo)
                        {
                            Global.MensajeComunicacion("Los datos fueron ingresados correctamente.");
                        }
                    }
                    else
                    {
                        Grabo = AgenteVentas.Proxy.GrabarLetrasCanje(oLetrasCanjeUnion, EnumOpcionGrabar.Actualizar);

                        if (Grabo)
                        {
                            Global.MensajeComunicacion("Los datos fueron actualizados correctamente.");
                        }
                    }

                    oCanjesEliminados = null;
                    oLetraEliminadas = null;
                }

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Imprimir()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            Decimal.TryParse(lblTotalSaldo.Text, out Decimal Saldo);
            Decimal.TryParse(lblAbono.Text, out Decimal Abono);

            if (Saldo != Abono)
            {
                Global.MensajeAdvertencia("Los montos del Total Saldo y Total deben coincidir.");
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmLetrasCanje_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                Nuevo();
                dgvCanje.RowPostPaint += new DataGridViewRowPostPaintEventHandler(DataGridViewHelper.rowPostPaint_HeaderCount);

                if (oLetra != null && oLetra.tipCanje == "RV")
                {
                    String idMoneda = oLetrasCanjeUnion.oListaCanjes != null ? oLetrasCanjeUnion.oListaCanjes[0].idMoneda : Variables.Soles;
                    Decimal.TryParse(lblTotalSaldo.Text, out Decimal MontoSaldo);
                    Decimal.TryParse(lblAbono.Text, out Decimal MontoAbonado);
                    Decimal MontoTotal = MontoSaldo - MontoAbonado;

                    //Cambiado 30-01-19
                    //frmDetalleLetra oFrm = new frmDetalleLetra(Convert.ToInt32(txtIdCliente.Text), txtRuc.Text.Trim(), txtRazonSocial.Text.Trim(), MontoTotal.ToString("N2"), dtpFecProceso.Value, idMoneda, oLetra);
                    frmDetalleLetra oFrm = new frmDetalleLetra(oLetra, "S");

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oLetra != null)
                    {
                        LetrasE oItem = oFrm.oLetra;
                        oLetrasCanjeUnion.oListaLetras.Add(oItem);
                        bsLetras.DataSource = oLetrasCanjeUnion.oListaLetras;
                        bsLetras.ResetBindings(false);

                        SumarMontos();
                        lblLetras.Text = "Letras " + oLetrasCanjeUnion.oListaLetras.Count.ToString();
                    }

                    btNuevaLetra.Enabled = false;
                }

                BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btPendientes_Click(object sender, EventArgs e)
        {
            try
            {
                if (RevisarCliente())
                {
                    frmPendientesAuxiliarVentas oFrm = new frmPendientesAuxiliarVentas(Convert.ToInt32(txtIdCliente.Text), txtRuc.Text.Trim(), txtRazonSocial.Text.Trim(), "CJ");

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaCtaCte != null && oFrm.oListaCtaCte.Count > Variables.Cero)
                    {
                        Decimal MontoSaldo = 0;
                        String nomDocumento = String.Empty;
                        Decimal porRetencion = 0;

                        foreach (CtaCteE item in oFrm.oListaCtaCte)
                        {
                            MontoSaldo = item.Saldo;

                            if (item.AgenteRetenedor)
                            {
                                if (VariablesLocales.oListaImpuestos[2] == null) //Retenciones
                                {
                                    throw new Exception("Falta ingresar el impuesto de Retención en Maestros/Impuestos");
                                }

                                porRetencion = VariablesLocales.oListaImpuestos[2].Porcentaje;
                                MontoSaldo = item.Saldo - (item.Saldo * (porRetencion / 100));
                            }

                            if (item.EsDetraCab)
                            {
                                MontoSaldo = item.Saldo - item.MontoDetraFac;
                            }

                            LetrasCanjeE oCanje = new LetrasCanjeE()
                            {
                                idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                idLocal = VariablesLocales.SesionLocal.IdLocal,
                                idDocumento = item.idDocumento,
                                numSerie = item.numSerie,
                                numDocumento = item.numDocumento,
                                fecDocumento = item.FechaDocumento,
                                idMoneda = item.idMoneda,
                                desMoneda = item.desMoneda,
                                SaldoDoc = MontoSaldo,
                                SaldoTemp = MontoSaldo,
                                tipCambioDoc = item.TipoCambio,
                                idPersona = Convert.ToInt32(txtIdCliente.Text),
                                fecProceso = dtpFecProceso.Value.Date,
                                Glosa = txtGlosa.Text,
                                numVerPlanCuentas = item.numVerPlanCuentas,
                                codCuenta = item.codCuenta,
                                idCtaCte = item.idCtaCte,
                                Opcion = (Int32)EnumOpcionGrabar.Insertar,
                                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                                FechaRegistro = VariablesLocales.FechaHoy,
                                UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                                FechaModificacion = VariablesLocales.FechaHoy
                            };

                            oLetrasCanjeUnion.oListaCanjes.Add(oCanje);
                        }

                        bsCanjeLetras.DataSource = oLetrasCanjeUnion.oListaCanjes;
                        bsCanjeLetras.ResetBindings(false);
                        SumarSaldo();
                        txtGlosa.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btEliminarCanje_Click(object sender, EventArgs e)
        {
            try
            {
                //if (oLetrasCanjeUnion.oListaCanjes != null && oLetrasCanjeUnion.oListaCanjes.Count > Variables.Cero)
                //{
                //    if (oLetrasCanjeUnion.oListaLetras.Count == 0)
                //    {
                //        if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                //        {
                //Inicializando la lista de los canjes eliminados
                if (oLetrasCanjeUnion.CanjesEliminados == null)
                {
                    oLetrasCanjeUnion.CanjesEliminados = new List<LetrasCanjeE>();
                }

                oLetrasCanjeUnion.CanjesEliminados.Add((LetrasCanjeE)bsCanjeLetras.Current);

                //Removiendo de la lista principal(temporalmente)...
                oLetrasCanjeUnion.oListaCanjes.RemoveAt(bsCanjeLetras.Position);
                //Actualizando la lista...
                bsCanjeLetras.DataSource = oLetrasCanjeUnion.oListaCanjes;
                bsCanjeLetras.ResetBindings(false);

                SumarSaldo();
                base.QuitarDetalle();
                //        }
                //    }
                //    else
                //    {
                //        Global.MensajeFault("Este canje ya posee letras, eliminelas primero.");
                //    }
                //}
                //else
                //{
                //    Global.MensajeFault("Debe haber un documento al menos para poder eliminar.");
                //}
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btNuevoCanje_Click(object sender, EventArgs e)
        {
            try
            {
                if (RevisarCliente())
                {
                    LlenarComboGrid();
                    LetrasCanjeE oCanje = new LetrasCanjeE()
                    {
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        idLocal = VariablesLocales.SesionLocal.IdLocal,
                        idDocumento = "FV",
                        numSerie = String.Empty,
                        numDocumento = String.Empty,
                        fecDocumento = null,
                        idMoneda = String.Empty,
                        desMoneda = String.Empty,
                        idPersona = Convert.ToInt32(txtIdCliente.Text),
                        SaldoDoc = Variables.ValorCeroDecimal,
                        idComprobante = String.Empty,
                        numFile = String.Empty,
                        AnioPeriodo = String.Empty,
                        MesPeriodo = String.Empty,
                        numVoucher = String.Empty,
                        fecProceso = dtpFecProceso.Value.Date,
                        Glosa = txtGlosa.Text,
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                        FechaRegistro = VariablesLocales.FechaHoy,
                        UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                        FechaModificacion = VariablesLocales.FechaHoy
                    };

                    oLetrasCanjeUnion.oListaCanjes.Add(oCanje);
                    bsCanjeLetras.DataSource = oLetrasCanjeUnion.oListaCanjes;
                    bsCanjeLetras.ResetBindings(false);
                    bsCanjeLetras.MoveLast();

                    dgvCanje.Columns[0].ReadOnly = false;
                    dgvCanje.Columns[5].ReadOnly = false;
                    dgvCanje.Focus();
                    dgvCanje.CurrentCell = dgvCanje.Rows[bsCanjeLetras.Position].Cells[5];
                    dgvCanje.CurrentCell.Selected = true; 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            try
            {

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
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
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
                        txtRazonSocial.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
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
                        txtRazonSocial.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRuc.Text.Trim()))
            {
                txtIdCliente.Text = String.Empty;
                txtRazonSocial.Text = String.Empty;
            }
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
            {
                txtIdCliente.Text = String.Empty;
                txtRuc.Text = String.Empty;
            }
        }

        private void btNuevaLetra_Click(object sender, EventArgs e)
        {
            try
            {
                if (RevisarNuevoCanje())
                {
                    String idMoneda = oLetrasCanjeUnion.oListaCanjes != null ? oLetrasCanjeUnion.oListaCanjes[0].idMoneda : Variables.Soles;
                    Decimal MontoSaldo = Variables.ValorCeroDecimal;
                    Decimal MontoAbonado = Variables.ValorCeroDecimal;
                    Decimal MontoTotal = Variables.ValorCeroDecimal;
                    Decimal.TryParse(lblTotalSaldo.Text, out MontoSaldo);
                    Decimal.TryParse(lblAbono.Text, out MontoAbonado);
                    MontoTotal = MontoSaldo - MontoAbonado;

                    frmDetalleLetra oFrm = new frmDetalleLetra(Convert.ToInt32(txtIdCliente.Text), txtRuc.Text.Trim(), txtRazonSocial.Text.Trim(), MontoTotal.ToString("N2"), dtpFecProceso.Value, idMoneda, oLetra);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oLetra != null)
                    {
                        if (oDocumentoVenta == null)
                        {
                            oDocumentoVenta = AgenteVentas.Proxy.ObtenerVendedorCondicion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, oLetrasCanjeUnion.oListaCanjes[0].idDocumento, oLetrasCanjeUnion.oListaCanjes[0].numSerie, oLetrasCanjeUnion.oListaCanjes[0].numDocumento);
                        }

                        LetrasE oItem = oFrm.oLetra;

                        if (oDocumentoVenta != null)
                        {
                            oItem.idVendedor = oDocumentoVenta.idVendedor;
                            oItem.idTipCondicion = oDocumentoVenta.idTipCondicion;
                            oItem.idCondicion = oDocumentoVenta.idCondicion;
                        }
                        else
                        {
                            oItem.idVendedor = null;
                            oItem.idTipCondicion = null;
                            oItem.idCondicion = null;
                        }

                        oLetrasCanjeUnion.oListaLetras.Add(oItem);
                        bsLetras.DataSource = oLetrasCanjeUnion.oListaLetras;
                        bsLetras.ResetBindings(false);

                        SumarMontos();
                        lblLetras.Text = "Letras " + oLetrasCanjeUnion.oListaLetras.Count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btELiminarLetra_Click(object sender, EventArgs e)
        {
            try
            {
                if (oLetrasCanjeUnion.oListaLetras != null && oLetrasCanjeUnion.oListaLetras.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        if ((((LetrasE)bsLetras.Current).Opcion == (Int32)EnumOpcionGrabar.Actualizar) || (((LetrasE)bsLetras.Current).Opcion == 0))
                        {
                            if (oLetrasCanjeUnion.LetrasEliminadas == null)
                            {
                                oLetrasCanjeUnion.LetrasEliminadas = new List<LetrasE>();
                            }

                            oLetrasCanjeUnion.LetrasEliminadas.Add((LetrasE)bsLetras.Current);

                            //Actualizando el campo para saber que se va a realizar...
                            //((LetrasE)bsLetras.Current).Opcion = (Int32)EnumOpcionGrabar.Eliminar;
                            //Agregando a la lista de eliminados
                            //oLetraEliminadas.Add((LetrasE)bsLetras.Current);
                            //Removiendo de la lista principal(temporalmente)...
                            oLetrasCanjeUnion.oListaLetras.RemoveAt(bsLetras.Position);
                            base.QuitarDetalle();
                        }
                        else if(((LetrasE)bsLetras.Current).Opcion == (Int32)EnumOpcionGrabar.Insertar)
                        {
                            //Removiendo de la lista principal(temporalmente)...
                            oLetrasCanjeUnion.oListaLetras.RemoveAt(bsLetras.Position);
                        }

                        //Actualizando la lista...
                        bsLetras.DataSource = oLetrasCanjeUnion.oListaLetras;
                        bsLetras.ResetBindings(false);

                        SumarMontos();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btImprimirLetra_Click(object sender, EventArgs e)
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPrevioLetras);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                LetrasE oLetraImpresion = AgenteVentas.Proxy.ObtenerLetras(((LetrasE)bsLetras.Current).idEmpresa, ((LetrasE)bsLetras.Current).idLocal, ((LetrasE)bsLetras.Current).tipCanje,
                                                                            ((LetrasE)bsLetras.Current).codCanje, ((LetrasE)bsLetras.Current).Numero, ((LetrasE)bsLetras.Current).Corre, "S");

                oFrm = new frmPrevioLetras(oLetraImpresion)
                {
                    MdiParent = MdiParent
                };
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvCanje_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Validando la columna Saldo
                if (dgvCanje.CurrentCell.ColumnIndex == 5)
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
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvCanje_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvCanje.CurrentCell.ColumnIndex == 5)// || dgvCanje.CurrentCell.ColumnIndex == 2)
            {
                if (e.Control is TextBox txt)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dgvCanje_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(dgvCanje_KeyPress);
                }
            }
        }

        private void dgvCanje_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewCell cellSaldo = dgvCanje.Rows[e.RowIndex].Cells["SaldoDoc"];
            //DataGridViewCell cellSaldoTemp = dgvCanje.Rows[e.RowIndex].Cells["SaldoTemp"];

            //if (Convert.ToDecimal(cellSaldo.Value) > Convert.ToDecimal(cellSaldoTemp.Value))
            //{
            //    Global.MensajeFault("No puede exceder el monto Saldo.");
            //    cellSaldo.Value = cellSaldoTemp.Value;
            //    return;
            //}

            SumarSaldo();
        }

        private void btAgregarNota_Click(object sender, EventArgs e)
        {
            frmTextoLargo oFrm = new frmTextoLargo();

            if (!String.IsNullOrEmpty(txtGlosa.Text))
            {
                oFrm.Texto = txtGlosa.Text;
            }

            if (oFrm.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(oFrm.Texto))
            {
                txtGlosa.Text = oFrm.Texto;
            }
        }

        private void dgvCanje_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dgvCanje.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvLetras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    //P=Por Aceptar A=Aceptada
                    EditarDetalleLetra(e, (LetrasE)bsLetras.Current);
                    //if (((LetrasE)bsLetras.Current).Estado == "P")
                    //{
                    //    EditarDetalleLetra(e, (LetrasE)bsLetras.Current);
                    //}
                    //else
                    //{
                    //    Global.MensajeComunicacion("Solo de pueden modificar Letras por Aceptar.");
                    //}
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvCanje_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (((LetrasCanjeE)bsCanjeLetras.Current).Opcion != (int)EnumOpcionGrabar.Insertar)
                {
                    ((LetrasCanjeE)bsCanjeLetras.Current).UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    ((LetrasCanjeE)bsCanjeLetras.Current).FechaModificacion = VariablesLocales.FechaHoy;
                    ((LetrasCanjeE)bsCanjeLetras.Current).Opcion = (int)EnumOpcionGrabar.Actualizar;
                }
            }
        }

        #endregion

    }
}
