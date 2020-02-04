using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.CtasPorPagar;
using Entidades.Contabilidad;
using Entidades.Tesoreria;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmLiquidacion : FrmMantenimientoBase
    {

        #region Contructores

        public frmLiquidacion()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvLiq, true, false, 28);
            LlenarCombos();
        }

        //Nuevo
        public frmLiquidacion(String TipoF, UsuarioFondoFijoE Seguridad)
            :this()
        {
            Text = "Liquidación Fondo Fijo y Rendiciones (Nuevo)";
            TipoFondo = TipoF;
            SeguridadFondoFijo = Seguridad;
        }

        //Edición
        public frmLiquidacion(LiquidacionE oLiquid, UsuarioFondoFijoE Seguridad)
            :this()
        {
            oLiquidacion = AgenteCtasPorPagar.Proxy.ObtenerLiquidacionCompleta(oLiquid.idEmpresa, oLiquid.idLocal, oLiquid.idLiquidacion);
            Text = "Liquidación Fondo Fijo y Rendiciones (" + oLiquidacion.idLiquidacion.ToString() + ")";
            TipoFondo = oLiquid.TipoFondo;
            SeguridadFondoFijo = Seguridad;
        } 

        #endregion

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        LiquidacionE oLiquidacion = null;
        String Estado = "P"; //C=Cerrado P=Pendiente
        Int32 opcion;
        String RazonSocial = String.Empty;
        Boolean Ordenar = false;
        String TipoCuentaLiqui = String.Empty;
        String TipoFondo = String.Empty; //168=Rendiciones 102=Fondo Fijo
        String Bloqueo = "N";
        UsuarioFondoFijoE SeguridadFondoFijo = null;

        #endregion

        #region Procedimientos de Usuario

        void GuardarDatos()
        {
            oLiquidacion.Fecha = dtpFecha.Value;
            oLiquidacion.idPersona = Convert.ToInt32(txtRuc.Tag);
            oLiquidacion.numVerPlanCuentas = txtCodCuenta.Tag.ToString();
            oLiquidacion.codCuenta = txtCodCuenta.Text.Trim();
            oLiquidacion.idComprobante = cboLibro.SelectedValue.ToString();
            oLiquidacion.numFile = cboFile.SelectedValue.ToString();
            oLiquidacion.PeriodoIni = dtpPeriodoIni.Value.Date;
            oLiquidacion.PeriodoFin = dtpPeriodoFin.Value.Date;

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oLiquidacion.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oLiquidacion.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void EditarDetalle(DataGridViewCellEventArgs e, LiquidacionDetE LineaEdicion)
        {
            try
            {
                if (bsLiquidacionDet.Count > 0)
                {
                    List<LiquidacionDetE> oListaLiquiMovilidad = new List<LiquidacionDetE>(from x in oLiquidacion.ListaLiquidacionDet
                                                                                           where x.tipoDocumento == 2
                                                                                           && x.idMovilidad != LineaEdicion.idMovilidad
                                                                                           select x).ToList();

                    frmLiquidacionDetalle oFrm = new frmLiquidacionDetalle(LineaEdicion, Estado, TipoCuentaLiqui, oListaLiquiMovilidad, TipoFondo, Bloqueo);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oLiquidacion.ListaLiquidacionDet[e.RowIndex] = oFrm.oLiquidacion;
                        bsLiquidacionDet.DataSource = oLiquidacion.ListaLiquidacionDet;
                        bsLiquidacionDet.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void LlenarCombos()
        {
            ///LIBROS///
            List<ComprobantesE> ListaTipoComprobante = new List<ComprobantesE>(VariablesLocales.oListaComprobantes)
            {
                new ComprobantesE() { idComprobante = Variables.Cero.ToString(), desComprobanteComp = Variables.Todos }
            };

            ComboHelper.RellenarCombos<ComprobantesE>(cboLibro, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp", false);
        }

        void SumarColumna(List<LiquidacionDetE> oLista)
        {
            Decimal TotalLiquidar = Convert.ToDecimal(oLista.Sum(x => x.MontoLiquidar));
            lblTotal.Text = TotalLiquidar.ToString("N2");

            if (lblSaldo.Text != "0.00")
            {
                lblSaldoActual.Text = (Convert.ToDecimal(lblSaldo.Text) - TotalLiquidar).ToString("N2");
            }
            else
            {
                lblSaldoActual.Text = TotalLiquidar.ToString("N2");
            }
        }

        void BuscarFondoFijo(Int32 idPersona, String Boton = "N")
        {
            List<FondoFijoE> oListaFondoFijo = AgenteTesoreria.Proxy.ListarFondoFijoPorResponsable(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idPersona);

            if (oListaFondoFijo != null && oListaFondoFijo.Count > 0)
            {
                FondoFijoE fondo = oListaFondoFijo.Find
                (
                    delegate (FondoFijoE f) { return f.TipoFondo == TipoFondo && f.idPersonaResponsable == idPersona; }
                );

                if (fondo == null)
                {
                    pnlDatos.Enabled = true;
                    cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
                    TipoCuentaLiqui = String.Empty;
                    Bloqueo = "N";

                    if (Boton == "S")
                    {
                        //oListaFondoFijo = AgenteTesoreria.Proxy.ListarFondoFijoPorResponsable(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, 0);
                        List<FondoFijoE> oListaBusqueda = new List<FondoFijoE>((from x in AgenteTesoreria.Proxy.ListarFondoFijoPorResponsable(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, 0)
                                                                                where x.TipoFondo == TipoFondo
                                                                                //&& x.idPersonaResponsable != VariablesLocales.SesionUsuario.IdPersona
                                                                                select x).ToList());

                        frmBuscarFondoFijo oFrm = new frmBuscarFondoFijo(oListaBusqueda);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oFondo != null)
                        {
                            txtRuc.TextChanged -= txtRuc_TextChanged;
                            txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                            txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                            txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;

                            txtRuc.Tag = oFrm.oFondo.idPersonaResponsable;
                            txtRuc.Text = oFrm.oFondo.nroResponsable;
                            txtRazonSocial.Text = oFrm.oFondo.desResponsable;
                            cboLibro.SelectedValue = oFrm.oFondo.idComprobante.ToString();
                            cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
                            cboFile.SelectedValue = oFrm.oFondo.numFile.ToString();
                            txtCodCuenta.Tag = oFrm.oFondo.numVerPlanCuentas;
                            txtCodCuenta.Text = oFrm.oFondo.codCuenta;
                            txtDesCuenta.Text = oFrm.oFondo.desCuenta;
                            TipoCuentaLiqui = oFrm.oFondo.desTipoCuentaLiq;
                            TipoFondo = oFrm.oFondo.TipoFondo;

                            txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                            txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                            txtRuc.TextChanged += txtRuc_TextChanged;
                            txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;

                            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
                            {
                                Bloqueo = "N";
                                pnlDatos.Enabled = true;
                                cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
                            }
                        }
                    }
                }
                else
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;

                    txtRuc.Tag = fondo.idPersonaResponsable;
                    txtRuc.Text = fondo.nroResponsable;
                    txtRazonSocial.Text = fondo.desResponsable;
                    cboLibro.SelectedValue = fondo.idComprobante.ToString();
                    cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
                    cboFile.SelectedValue = fondo.numFile.ToString();
                    txtCodCuenta.Tag = fondo.numVerPlanCuentas;
                    txtCodCuenta.Text = fondo.codCuenta;
                    txtDesCuenta.Text = fondo.desCuenta;
                    TipoCuentaLiqui = fondo.desTipoCuentaLiq;
                    TipoFondo = fondo.TipoFondo;

                    //if (oListaFondoFijo.Count == 1)
                    //{
                    //    txtRuc.Tag = oListaFondoFijo[0].idPersonaResponsable;
                    //    txtRuc.Text = oListaFondoFijo[0].nroResponsable;
                    //    txtRazonSocial.Text = oListaFondoFijo[0].desResponsable;
                    //    cboLibro.SelectedValue = oListaFondoFijo[0].idComprobante.ToString();
                    //    cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
                    //    cboFile.SelectedValue = oListaFondoFijo[0].numFile.ToString();
                    //    txtCodCuenta.Tag = oListaFondoFijo[0].numVerPlanCuentas;
                    //    txtCodCuenta.Text = oListaFondoFijo[0].codCuenta;
                    //    txtDesCuenta.Text = oListaFondoFijo[0].desCuenta;
                    //    TipoCuentaLiqui = oListaFondoFijo[0].desTipoCuentaLiq;
                    //    TipoFondo = oListaFondoFijo[0].TipoFondo;
                    //}
                    //else if (oListaFondoFijo.Count > 1)
                    //{
                    //    frmBuscarFondoFijo oFrm = new frmBuscarFondoFijo(oListaFondoFijo);

                    //    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oFondo != null)
                    //    {
                    //        txtRuc.Tag = oFrm.oFondo.idPersonaResponsable;
                    //        txtRuc.Text = oFrm.oFondo.nroResponsable;
                    //        txtRazonSocial.Text = oFrm.oFondo.desResponsable;
                    //        cboLibro.SelectedValue = oFrm.oFondo.idComprobante.ToString();
                    //        cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
                    //        cboFile.SelectedValue = oFrm.oFondo.numFile.ToString();
                    //        txtCodCuenta.Tag = oFrm.oFondo.numVerPlanCuentas;
                    //        txtCodCuenta.Text = oFrm.oFondo.codCuenta;
                    //        txtDesCuenta.Text = oFrm.oFondo.desCuenta;
                    //        TipoCuentaLiqui = oFrm.oFondo.desTipoCuentaLiq;
                    //        TipoFondo = oFrm.oFondo.TipoFondo;
                    //    }
                    //}

                    if (TipoFondo == "102") //Fondo Fijo
                    {
                        Bloqueo = "N";
                    }
                    else //Rendiciones
                    {
                        Bloqueo = "S";
                    }

                    txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;

                    if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
                    {
                        Bloqueo = "N";
                        pnlDatos.Enabled = true;
                        cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
                    }
                }
            }
            else
            {
                Bloqueo = "N";
                pnlDatos.Enabled = true;
                cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
                Global.MensajeComunicacion("No se han creado ningún Auxiliar de Fondos Fijos");
            }

            //if (oListaFondoFijo != null)
            //{
            //    txtRuc.TextChanged -= txtRuc_TextChanged;
            //    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
            //    txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
            //    txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;

            //    if (oListaFondoFijo.Count == 0)
            //    {
            //        pnlDatos.Enabled = true;
            //        cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
            //        TipoFondo = String.Empty;
            //        TipoCuentaLiqui = String.Empty;
            //    }
            //    else if (oListaFondoFijo.Count == 1)
            //    {
            //        txtRuc.Tag = oListaFondoFijo[0].idPersonaResponsable;
            //        txtRuc.Text = oListaFondoFijo[0].nroResponsable;
            //        txtRazonSocial.Text = oListaFondoFijo[0].desResponsable;
            //        cboLibro.SelectedValue = oListaFondoFijo[0].idComprobante.ToString();
            //        cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
            //        cboFile.SelectedValue = oListaFondoFijo[0].numFile.ToString();
            //        txtCodCuenta.Tag = oListaFondoFijo[0].numVerPlanCuentas;
            //        txtCodCuenta.Text = oListaFondoFijo[0].codCuenta;
            //        txtDesCuenta.Text = oListaFondoFijo[0].desCuenta;
            //        TipoCuentaLiqui = oListaFondoFijo[0].desTipoCuentaLiq;
            //        TipoFondo = oListaFondoFijo[0].TipoFondo;
            //    }
            //    else if (oListaFondoFijo.Count > 1)
            //    {
            //        frmBuscarFondoFijo oFrm = new frmBuscarFondoFijo(oListaFondoFijo);

            //        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oFondo != null)
            //        {
            //            txtRuc.Tag = oFrm.oFondo.idPersonaResponsable;
            //            txtRuc.Text = oFrm.oFondo.nroResponsable;
            //            txtRazonSocial.Text = oFrm.oFondo.desResponsable;
            //            cboLibro.SelectedValue = oFrm.oFondo.idComprobante.ToString();
            //            cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
            //            cboFile.SelectedValue = oFrm.oFondo.numFile.ToString();
            //            txtCodCuenta.Tag = oFrm.oFondo.numVerPlanCuentas;
            //            txtCodCuenta.Text = oFrm.oFondo.codCuenta;
            //            txtDesCuenta.Text = oFrm.oFondo.desCuenta;
            //            TipoCuentaLiqui = oFrm.oFondo.desTipoCuentaLiq;
            //            TipoFondo = oFrm.oFondo.TipoFondo;
            //        }
            //    }

            //    if (TipoFondo == "102") //Fondo Fijo
            //    {
            //        Bloqueo = "N";
            //    }
            //    else //Rendiciones
            //    {
            //        Bloqueo = "S";
            //    }

            //    txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
            //    txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
            //    txtRuc.TextChanged += txtRuc_TextChanged;
            //    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;

            //    if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            //    {
            //        Bloqueo = "N";
            //        pnlDatos.Enabled = true;
            //        cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
            //    }
            //}
            //else
            //{
            //    Bloqueo = "N";
            //    pnlDatos.Enabled = true;
            //    cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
            //    Global.MensajeComunicacion("No se han creado ningún Auxiliar de Fondos Fijos");
            //}
        }

        void BuscarFondoFijo2(Int32 idPersona)
        {
            List<FondoFijoE> oListaFondoFijo = AgenteTesoreria.Proxy.ListarFondoFijoPorResponsable(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idPersona);


        }

        bool BuscarDocumento(string TextoABuscar, string Columna, DataGridView grid)
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

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oLiquidacion == null)
            {
                oLiquidacion = new LiquidacionE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal
                };

                txtEstado.Text = "ABIERTO";

                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                if (SeguridadFondoFijo != null)
                {
                    if (SeguridadFondoFijo.Asignacion)
                    {
                        BuscarFondoFijo(VariablesLocales.SesionUsuario.IdPersona);
                    }
                    else
                    {
                        BuscarFondoFijo(0);
                    }
                }
                else
                {
                    BuscarFondoFijo(0);
                }

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtRuc.TextChanged -= txtRuc_TextChanged;
                txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;

                txtIdLiqui.Text = oLiquidacion.idLiquidacion.ToString();
                dtpFecha.Value = oLiquidacion.Fecha;
                txtEstado.Text = oLiquidacion.desEstado;
                txtRuc.Tag = oLiquidacion.idPersona;
                txtRuc.Text = oLiquidacion.RUC;
                txtRazonSocial.Text = oLiquidacion.RazonSocial;
                cboLibro.SelectedValue = oLiquidacion.idComprobante;
                cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
                cboFile.SelectedValue = oLiquidacion.numFile.ToString();
                txtCodCuenta.Tag = oLiquidacion.numVerPlanCuentas;
                txtCodCuenta.Text = oLiquidacion.codCuenta;
                txtDesCuenta.Text = oLiquidacion.desCuenta;
                dtpPeriodoIni.Value = oLiquidacion.PeriodoIni;
                dtpPeriodoFin.Value = oLiquidacion.PeriodoFin;

                txtUsuRegistra.Text = oLiquidacion.UsuarioRegistro;
                txtRegistro.Text = oLiquidacion.FechaRegistro.ToString();
                txtUsuModifica.Text = oLiquidacion.UsuarioModificacion;
                txtModifica.Text = oLiquidacion.FechaModificacion.ToString();

                TipoCuentaLiqui = oLiquidacion.desTipoCuentaLiq;

                LiquidacionSaldosE oSaldoLiqui = AgenteCtasPorPagar.Proxy.ObtenerSaldosPorIdLiquidacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, oLiquidacion.idPersona, Convert.ToInt32(txtIdLiqui.Text));

                if (oSaldoLiqui != null)
                {
                    if (oSaldoLiqui.SaldoAnterior > 0)
                    {
                        lblSaldo.Text = (oSaldoLiqui.Abono + oSaldoLiqui.SaldoAnterior).ToString("N2");
                    }
                    else
                    {
                        lblSaldo.Text = (oSaldoLiqui.Abono).ToString("N2");
                    }
                }

                opcion = (Int32)EnumOpcionGrabar.Actualizar;

                //if (!oLiquidacion.Estado)
                //{
                //    Int32 Resp = AgenteTesoreria.Proxy.FondoFijoPorTipoFondoResp(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, TipoFondo, VariablesLocales.SesionUsuario.IdPersona);
                //    pnlDatos.Enabled = !(Resp > 0);
                //    Bloqueo = (Resp > 0) ? "S" : "N";
                //}

                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
            }

            bsLiquidacionDet.DataSource = oLiquidacion.ListaLiquidacionDet;
            bsLiquidacionDet.ResetBindings(false);
            SumarColumna(oLiquidacion.ListaLiquidacionDet);

            if (oLiquidacion.Estado)
            {
                Global.MensajeComunicacion("Este registro de liquidación ha sido cerrado. No podra hacer modificaciones.");
                pnlDatos.Enabled = false;
                Estado = "C";
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                dtpPeriodoIni.Enabled = false;
                dtpPeriodoFin.Enabled = false;
            }
            else
            {
                if (SeguridadFondoFijo != null)
                {
                    if ((!SeguridadFondoFijo.Edicion && SeguridadFondoFijo.Visualizar) || (!SeguridadFondoFijo.Edicion && !SeguridadFondoFijo.Visualizar))
                    {
                        pnlDatos.Enabled = false;
                        pnlTipo.Enabled = false;
                        //pnlDetalle.Enabled = false;
                        BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                        Bloqueo = "S";
                        Estado = "C";
                    }
                    else
                    {
                        base.Nuevo();
                    }
                }
                else
                {
                    base.Nuevo();
                }
            }
        }

        public override void Grabar()
        {
            try
            {
                if (oLiquidacion != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oLiquidacion = AgenteCtasPorPagar.Proxy.GrabarLiquidacion(oLiquidacion, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oLiquidacion = AgenteCtasPorPagar.Proxy.GrabarLiquidacion(oLiquidacion, EnumOpcionGrabar.Actualizar);
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
            String Respuesta = ValidarEntidad<LiquidacionE>(oLiquidacion);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                if (String.IsNullOrWhiteSpace(TipoCuentaLiqui))
                {
                    Global.MensajeComunicacion("El auxiliar no tiene el tipo de cuenta en el Maestro de Fondo Fijo y Cuentas a Rendir");
                    return false;
                }
            }
            else
            {
                if (String.IsNullOrWhiteSpace(oLiquidacion.desTipoCuentaLiq))
                {
                    Global.MensajeComunicacion("El auxiliar no tiene el tipo de cuenta en el Maestro de Fondo Fijo y Cuentas a Rendir");
                    return false;
                }
            }

            return base.ValidarGrabacion();
        }

        public override void AgregarDetalle()
        {
            try
            {
                if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    if (String.IsNullOrWhiteSpace(TipoCuentaLiqui))
                    {
                        Global.MensajeComunicacion("El auxiliar no tiene el tipo de cuenta en el Maestro de Fondo Fijo y Cuentas a Rendir");
                        return;
                    }
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(oLiquidacion.desTipoCuentaLiq))
                    {
                        Global.MensajeComunicacion("El auxiliar no tiene el tipo de cuenta en el Maestro de Fondo Fijo y Cuentas a Rendir");
                        return;
                    }
                }

                List<LiquidacionDetE> oListaLiquiMovilidad = new List<LiquidacionDetE>(from x in oLiquidacion.ListaLiquidacionDet
                                                                                       where x.tipoDocumento == 2
                                                                                       select x).ToList();

                frmLiquidacionDetalle oFrm = new frmLiquidacionDetalle(TipoCuentaLiqui, oListaLiquiMovilidad, TipoFondo, Bloqueo);

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    oLiquidacion.ListaLiquidacionDet.Add(oFrm.oLiquidacion);
                    bsLiquidacionDet.DataSource = oLiquidacion.ListaLiquidacionDet;
                    bsLiquidacionDet.ResetBindings(false);
                    SumarColumna(oLiquidacion.ListaLiquidacionDet);
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
                if (bsLiquidacionDet.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        if (((LiquidacionDetE)bsLiquidacionDet.Current).tipoDocumento == 1)
                        {
                            ProvisionesE oProvisionCompra = AgenteCtasPorPagar.Proxy.RecuperarProvisionesPorId(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                VariablesLocales.SesionLocal.IdLocal, 
                                                                                                                ((LiquidacionDetE)bsLiquidacionDet.Current).idProvision.Value, false, "N");
                            if (oProvisionCompra.EstadoProvision == "PR")
                            {
                                Global.MensajeComunicacion("Este documento no se puede eliminar porque ya se encuentra Provisionado.");
                                return;
                            }
                        }

                        if (oLiquidacion.ListaEliminados == null)
                        {
                            oLiquidacion.ListaEliminados = new List<LiquidacionDetE>();
                        }

                        oLiquidacion.ListaEliminados.Add((LiquidacionDetE)bsLiquidacionDet.Current);
                        oLiquidacion.ListaLiquidacionDet.RemoveAt(bsLiquidacionDet.Position);

                        bsLiquidacionDet.DataSource = oLiquidacion.ListaLiquidacionDet;
                        bsLiquidacionDet.ResetBindings(false);
                        SumarColumna(oLiquidacion.ListaLiquidacionDet);

                        base.QuitarDetalle();
                    }
                }

            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmLiquidacion_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                Nuevo();
                txtCodCuenta.MaxLength = VariablesLocales.VersionPlanCuentasActual.Longitud;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvLiq_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditarDetalle(e, ((LiquidacionDetE)bsLiquidacionDet.Current));
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
            txtRuc.Tag = 0;
            txtRazonSocial.Text = String.Empty;

            cboLibro.SelectedValue = "0";
            cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
            cboFile.SelectedValue = "0";
            txtCodCuenta.Text = String.Empty;
            txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtRuc.TextChanged -= txtRuc_TextChanged;
            txtRuc.Tag = 0;
            txtRuc.Text = String.Empty;

            cboLibro.SelectedValue = "0";
            cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
            cboFile.SelectedValue = "0";
            txtCodCuenta.Text = String.Empty;
            txtRuc.TextChanged += txtRuc_TextChanged;
        }

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            //if (String.IsNullOrEmpty(txtRuc.Text.Trim()) && !String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
            //{
            //    List<FondoFijoE> oListaFondoFijo = AgenteTesoreria.Proxy.ListarFondoFijoPorResponsable(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, 0);

            //    if (oListaFondoFijo.Count > 0)
            //    {
            //        txtRuc.TextChanged -= txtRuc_TextChanged;
            //        txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
            //        txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
            //        txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;

            //        List<FondoFijoE> oListaFondoFijo2 = oListaFondoFijo.Where(x => x.desResponsable.ToUpper().Contains(txtRazonSocial.Text.Trim().ToUpper())).ToList();

            //        if (oListaFondoFijo2.Count == 0)
            //        {
            //            txtRuc.Tag = 0;
            //            txtRuc.Text = String.Empty;
            //            txtRazonSocial.Text = String.Empty;
            //            cboLibro.SelectedValue = "0";
            //            cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
            //            cboFile.SelectedValue = "0";
            //            txtCodCuenta.Tag = String.Empty;
            //            txtCodCuenta.Text = String.Empty;
            //            txtDesCuenta.Text = String.Empty;

            //            TipoCuentaLiqui = String.Empty;
            //            TipoFondo = String.Empty;
            //        }
            //        else if (oListaFondoFijo2.Count == 1)
            //        {
            //            txtRuc.Tag = oListaFondoFijo2[0].idPersonaResponsable;
            //            txtRuc.Text = oListaFondoFijo2[0].nroResponsable;
            //            txtRazonSocial.Text = oListaFondoFijo2[0].desResponsable;
            //            cboLibro.SelectedValue = oListaFondoFijo2[0].idComprobante.ToString();
            //            cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
            //            cboFile.SelectedValue = oListaFondoFijo2[0].numFile.ToString();
            //            txtCodCuenta.Tag = oListaFondoFijo2[0].numVerPlanCuentas;
            //            txtCodCuenta.Text = oListaFondoFijo2[0].codCuenta;
            //            txtDesCuenta.Text = oListaFondoFijo2[0].desCuenta;

            //            TipoCuentaLiqui = oListaFondoFijo2[0].desTipoCuentaLiq;
            //            TipoFondo = oListaFondoFijo2[0].TipoFondo;
            //        }
            //        else if (oListaFondoFijo2.Count > 1)
            //        {
            //            frmBuscarFondoFijo oFrm = new frmBuscarFondoFijo(oListaFondoFijo);

            //            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oFondo != null)
            //            {
            //                txtRuc.Tag = oFrm.oFondo.idPersonaResponsable;
            //                txtRuc.Text = oFrm.oFondo.nroResponsable;
            //                txtRazonSocial.Text = oFrm.oFondo.desResponsable;
            //                cboLibro.SelectedValue = oFrm.oFondo.idComprobante.ToString();
            //                cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
            //                cboFile.SelectedValue = oFrm.oFondo.numFile.ToString();
            //                txtCodCuenta.Tag = oFrm.oFondo.numVerPlanCuentas;
            //                txtCodCuenta.Text = oFrm.oFondo.codCuenta;
            //                txtDesCuenta.Text = oFrm.oFondo.desCuenta;

            //                TipoCuentaLiqui = oFrm.oFondo.desTipoCuentaLiq;
            //                TipoFondo = oFrm.oFondo.TipoFondo;
            //            }
            //        }

            //        txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
            //        txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
            //        txtRuc.TextChanged += txtRuc_TextChanged;
            //        txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
            //    }
            //    else
            //    {
            //        Global.MensajeComunicacion("No se han creado ningún Auxiliar de Fondos Fijos");
            //    }
            //}
        }

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            //try
            //{
            //    if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
            //    {
            //        List<FondoFijoE> oListaFondoFijo = AgenteTesoreria.Proxy.ListarFondoFijoPorResponsable(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, 0);

            //        if (oListaFondoFijo.Count > 0)
            //        {
            //            txtRuc.TextChanged -= txtRuc_TextChanged;
            //            txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
            //            txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
            //            txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;

            //            List<FondoFijoE> oListaFondoFijo2 = oListaFondoFijo.Where(x => x.nroResponsable.Contains(txtRuc.Text)).ToList();

            //            if (oListaFondoFijo2.Count == 0)
            //            {
            //                txtRuc.Tag = 0;
            //                txtRuc.Text = String.Empty;
            //                txtRazonSocial.Text = String.Empty;
            //                cboLibro.SelectedValue = "0";
            //                cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
            //                cboFile.SelectedValue = "0";
            //                txtCodCuenta.Tag = String.Empty;
            //                txtCodCuenta.Text = String.Empty;
            //                txtDesCuenta.Text = String.Empty;
            //            }
            //            else if (oListaFondoFijo2.Count == 1)
            //            {
            //                txtRuc.Tag = oListaFondoFijo2[0].idPersonaResponsable;
            //                txtRuc.Text = oListaFondoFijo2[0].nroResponsable;
            //                txtRazonSocial.Text = oListaFondoFijo2[0].desResponsable;
            //                cboLibro.SelectedValue = oListaFondoFijo2[0].idComprobante.ToString();
            //                cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
            //                cboFile.SelectedValue = oListaFondoFijo2[0].numFile.ToString();
            //                txtCodCuenta.Tag = oListaFondoFijo2[0].numVerPlanCuentas;
            //                txtCodCuenta.Text = oListaFondoFijo2[0].codCuenta;
            //                txtDesCuenta.Text = oListaFondoFijo2[0].desCuenta;
            //            }
            //            else if (oListaFondoFijo2.Count > 1)
            //            {
            //                frmBuscarFondoFijo oFrm = new frmBuscarFondoFijo(oListaFondoFijo);

            //                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oFondo != null)
            //                {
            //                    txtRuc.Tag = oFrm.oFondo.idPersonaResponsable;
            //                    txtRuc.Text = oFrm.oFondo.nroResponsable;
            //                    txtRazonSocial.Text = oFrm.oFondo.desResponsable;
            //                    cboLibro.SelectedValue = oFrm.oFondo.idComprobante.ToString();
            //                    cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
            //                    cboFile.SelectedValue = oFrm.oFondo.numFile.ToString();
            //                    txtCodCuenta.Tag = oFrm.oFondo.numVerPlanCuentas;
            //                    txtCodCuenta.Text = oFrm.oFondo.codCuenta;
            //                    txtDesCuenta.Text = oFrm.oFondo.desCuenta;
            //                }
            //            }

            //            txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
            //            txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
            //            txtRuc.TextChanged += txtRuc_TextChanged;
            //            txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
            //        }
            //        else
            //        {
            //            Global.MensajeComunicacion("No se han creado ningún Auxiliar de Fondos Fijos");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
            //    txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
            //    txtRuc.TextChanged += txtRuc_TextChanged;
            //    Global.MensajeError(ex.Message);
            //}
        }

        private void txtCodCuenta_TextChanged(object sender, EventArgs e)
        {
            txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;
            txtCodCuenta.Tag = String.Empty;
            txtDesCuenta.Text = String.Empty;
            txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
        }

        private void txtDesCuenta_TextChanged(object sender, EventArgs e)
        {
            txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
            txtCodCuenta.Tag = String.Empty;
            txtCodCuenta.Text = String.Empty;
            txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
        }

        private void txtCodCuenta_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodCuenta.Text.Trim()) && string.IsNullOrEmpty(txtDesCuenta.Text.Trim()))
                {
                    txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCodCuenta.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCodCuenta.Tag = oFrm.oCuenta.numVerPlanCuentas;
                            txtCodCuenta.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuenta.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCuenta.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCodCuenta.Tag = oListaCuentas[0].numVerPlanCuentas;
                        txtCodCuenta.Text = oListaCuentas[0].codCuenta;
                        txtDesCuenta.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCodCuenta.Tag = String.Empty;
                        txtCodCuenta.Text = String.Empty;
                        txtDesCuenta.Text = String.Empty;
                    }

                    txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuenta_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodCuenta.Text.Trim()) && !string.IsNullOrEmpty(txtDesCuenta.Text.Trim()))
                {
                    txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCuenta.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCodCuenta.Tag = oFrm.oCuenta.numVerPlanCuentas;
                            txtCodCuenta.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuenta.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCodCuenta.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCodCuenta.Tag = oListaCuentas[0].numVerPlanCuentas;
                        txtCodCuenta.Text = oListaCuentas[0].codCuenta;
                        txtDesCuenta.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCodCuenta.Tag = String.Empty;
                        txtCodCuenta.Text = String.Empty;
                        txtDesCuenta.Text = String.Empty;
                    }

                    txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboLibro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboLibro.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles = new List<ComprobantesFileE>(((ComprobantesE)cboLibro.SelectedItem).ListaComprobantesFiles);
                    ComprobantesFileE File = new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Todos };
                    ListaFiles.Add(File);
                    ComboHelper.RellenarCombos<ComprobantesFileE>(cboFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);

                    if (cboLibro.SelectedValue.ToString() == Variables.Cero.ToString())
                    {
                        cboFile.Enabled = false;
                    }
                    else
                    {
                        cboFile.Enabled = true;
                    }

                    if (ListaFiles.Count == 2)
                    {
                        cboFile.SelectedValue = ListaFiles[0].numFile;
                    }
                    else
                    {
                        cboFile.SelectedValue = Variables.Cero.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void bsLiquidacionDet_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                lblDetalle.Text = "Detalle " + bsLiquidacionDet.List.Count + " Registros";
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btEncargado_Click(object sender, EventArgs e)
        {
            try
            {
                //BuscarFondoFijo(VariablesLocales.SesionUsuario.IdPersona, "S");
                if (SeguridadFondoFijo != null)
                {
                    if (SeguridadFondoFijo.Asignacion)
                    {
                        BuscarFondoFijo(VariablesLocales.SesionUsuario.IdPersona, "S");
                    }
                    else
                    {
                        BuscarFondoFijo(0, "S");
                    }
                }
                else
                {
                    BuscarFondoFijo(0, "S");
                }
                //List<FondoFijoE> oListaFondoFijo = AgenteTesoreria.Proxy.ListarFondoFijoPorResponsable(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, 0);

                //if (oListaFondoFijo.Count > 0)
                //{
                //    txtRuc.TextChanged -= txtRuc_TextChanged;
                //    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                //    txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                //    txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;

                //    if (oListaFondoFijo.Count == 0)
                //    {
                //        txtRuc.Text = String.Empty;
                //        txtCodCuenta.Text = String.Empty;
                //        TipoFondo = String.Empty;
                //        TipoCuentaLiqui = String.Empty;
                //    }
                //    else if (oListaFondoFijo.Count == 1)
                //    {
                //        txtRuc.Tag = oListaFondoFijo[0].idPersonaResponsable;
                //        txtRuc.Text = oListaFondoFijo[0].nroResponsable;
                //        txtRazonSocial.Text = oListaFondoFijo[0].desResponsable;
                //        cboLibro.SelectedValue = oListaFondoFijo[0].idComprobante.ToString();
                //        cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
                //        cboFile.SelectedValue = oListaFondoFijo[0].numFile.ToString();
                //        txtCodCuenta.Tag = oListaFondoFijo[0].numVerPlanCuentas;
                //        txtCodCuenta.Text = oListaFondoFijo[0].codCuenta;
                //        txtDesCuenta.Text = oListaFondoFijo[0].desCuenta;
                //        TipoCuentaLiqui = oListaFondoFijo[0].desTipoCuentaLiq;
                //        TipoFondo = oListaFondoFijo[0].TipoFondo;
                //    }
                //    else if (oListaFondoFijo.Count > 1)
                //    {
                //        frmBuscarFondoFijo oFrm = new frmBuscarFondoFijo(oListaFondoFijo);

                //        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oFondo != null)
                //        {
                //            txtRuc.Tag = oFrm.oFondo.idPersonaResponsable;
                //            txtRuc.Text = oFrm.oFondo.nroResponsable;
                //            txtRazonSocial.Text = oFrm.oFondo.desResponsable;
                //            cboLibro.SelectedValue = oFrm.oFondo.idComprobante.ToString();
                //            cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
                //            cboFile.SelectedValue = oFrm.oFondo.numFile.ToString();
                //            txtCodCuenta.Tag = oFrm.oFondo.numVerPlanCuentas;
                //            txtCodCuenta.Text = oFrm.oFondo.codCuenta;
                //            txtDesCuenta.Text = oFrm.oFondo.desCuenta;
                //            TipoCuentaLiqui = oFrm.oFondo.desTipoCuentaLiq;
                //            TipoFondo = oFrm.oFondo.TipoFondo;
                //        }
                //    }

                //    if (TipoFondo == "102") //Fondo Fijo
                //    {
                //        Bloqueo = "N";
                //    }
                //    else //Rendiciones
                //    {
                //        Bloqueo = "S";
                //    }

                //    txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                //    txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                //    txtRuc.TextChanged += txtRuc_TextChanged;
                //    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;

                //    if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
                //    {
                //        Bloqueo = "N";
                //        pnlDatos.Enabled = true;
                //        cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
                //    }
                //}
                //else
                //{
                //    Bloqueo = "N";
                //    pnlDatos.Enabled = true;
                //    cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
                //    Global.MensajeComunicacion("No se han creado ningún Auxiliar de Fondos Fijos");
                //}
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvLiq_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (oLiquidacion.ListaLiquidacionDet != null && oLiquidacion.ListaLiquidacionDet.Count > Variables.Cero)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (e.ColumnIndex == dgvLiq.Columns["RazonSocial1"].Index)
                        {
                            if (Ordenar)
                            {
                                bsLiquidacionDet.DataSource = (from x in oLiquidacion.ListaLiquidacionDet orderby x.RazonSocial ascending select x).ToList();
                                Ordenar = false;
                            }
                            else
                            {
                                bsLiquidacionDet.DataSource = (from x in oLiquidacion.ListaLiquidacionDet orderby x.RazonSocial descending select x).ToList();
                                Ordenar = true;
                            }
                        }

                        if (e.ColumnIndex == dgvLiq.Columns["idDocumento"].Index)
                        {
                            if (Ordenar)
                            {
                                bsLiquidacionDet.DataSource = (from x in oLiquidacion.ListaLiquidacionDet orderby x.idDocumento ascending select x).ToList();
                                Ordenar = false;
                            }
                            else
                            {
                                bsLiquidacionDet.DataSource = (from x in oLiquidacion.ListaLiquidacionDet orderby x.idDocumento descending select x).ToList();
                                Ordenar = true;
                            }
                        }

                        if (e.ColumnIndex == dgvLiq.Columns["numSerie"].Index)
                        {
                            if (Ordenar)
                            {
                                bsLiquidacionDet.DataSource = (from x in oLiquidacion.ListaLiquidacionDet orderby x.numSerie ascending select x).ToList();
                                Ordenar = false;
                            }
                            else
                            {
                                bsLiquidacionDet.DataSource = (from x in oLiquidacion.ListaLiquidacionDet orderby x.numSerie descending select x).ToList();
                                Ordenar = true;
                            }
                        }

                        if (e.ColumnIndex == dgvLiq.Columns["numDocumento"].Index)
                        {
                            if (Ordenar)
                            {
                                bsLiquidacionDet.DataSource = (from x in oLiquidacion.ListaLiquidacionDet orderby x.numDocumento ascending select x).ToList();
                                Ordenar = false;
                            }
                            else
                            {
                                bsLiquidacionDet.DataSource = (from x in oLiquidacion.ListaLiquidacionDet orderby x.numDocumento descending select x).ToList();
                                Ordenar = true;
                            }
                        }

                        if (e.ColumnIndex == dgvLiq.Columns["FechaDocumento"].Index)
                        {
                            if (Ordenar)
                            {
                                bsLiquidacionDet.DataSource = (from x in oLiquidacion.ListaLiquidacionDet orderby x.FechaDocumento ascending select x).ToList();
                                Ordenar = false;
                            }
                            else
                            {
                                bsLiquidacionDet.DataSource = (from x in oLiquidacion.ListaLiquidacionDet orderby x.FechaDocumento descending select x).ToList();
                                Ordenar = true;
                            }
                        }
                    }

                    //bsLiquidacionDet.DataSource = oListaDocumentos;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btBuscarTexto_Click(object sender, EventArgs e)
        {
          
          BuscarDocumento(txtBuscar.Text.ToUpper(), "numDocumento", dgvLiq);
          
        }

        #endregion
    }
}
