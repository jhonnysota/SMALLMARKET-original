using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Maestros;
using Entidades.Contabilidad;
using Entidades.CtasPorCobrar;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using ClienteWinForm.Busquedas;
using ClienteWinForm.Contabilidad.Reportes;

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoLetrasAprobacion : FrmMantenimientoBase
    {

        public frmListadoLetrasAprobacion()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            FormatoGrid(dgvLetras, true);
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        CtasPorCobrarServiceAgent AgenteCtaPorCobrar { get { return new CtasPorCobrarServiceAgent(); } }
        List<LetrasE> oListaLetras = null;
        Boolean Ordenar = true;

        #endregion

        #region Procedimientos Heredados

        public override void Editar()
        {
            try
            {
                if (bsLetras.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmLetrasCanje);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        //si la instancia existe la pongo en primer plano
                        oFrm.BringToFront();
                        return;
                    }

                    LetrasE current = (LetrasE)bsLetras.Current;
                    //String Bloq = "N";

                    //if (!String.IsNullOrWhiteSpace(current.EstadoPlanillaBanco))
                    //{
                    //    if (current.EstadoPlanillaBanco == "C")
                    //    {
                    //        Bloq = "S";
                    //        Global.MensajeComunicacion((String.Format("La planilla de banco N° {0} se encuentra cerrada, no podrá hacer modificaciones.", current.codPlanillaBanco)));
                    //    }
                    //}

                    //sino existe la instancia se crea una nueva
                    oFrm = new frmLetrasCanje(current.idEmpresa, current.idLocal, current.tipCanje, current.codCanje, "S", "S")
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Buscar()
        {
            try
            {
                String Estado = rbTodos.Checked ? "" : "P";
                String tipCanje = String.Empty;
                Int32 idPersona = String.IsNullOrEmpty(txtIdCliente.Text.Trim()) ? 0 : Convert.ToInt32(txtIdCliente.Text.Trim());
                String TipoFecha = rbEmision.Checked ? "E" : "V";

                if (rbCanje.Checked)
                {
                    tipCanje = "CJ";
                }

                if (rbRenovacion.Checked)
                {
                    tipCanje = "RV";
                }

                if (rbTodosCanje.Checked)
                {
                    tipCanje = "%%";
                }

                bsLetras.DataSource = oListaLetras = AgenteVentas.Proxy.ListarLetras(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, tipCanje, idPersona, Estado, TipoFecha, dtpFecIni.Value.Date, dtpFecFin.Value.Date);
                bsLetras.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                LetrasE current = (LetrasE)bsLetras.Current;

                if (!String.IsNullOrWhiteSpace(current.EstadoPlanillaBanco))
                {
                    if (current.EstadoPlanillaBanco == "C")
                    {
                        Global.MensajeComunicacion((String.Format("La planilla de banco N° {0} asociada a la Letra se encuentra cerrada, no puede ser ANULADA.", current.codPlanillaBanco)));
                        return;
                    }
                }

                if (current.Estado == "A")
                {
                    Global.MensajeComunicacion("Solo se pueden anular las letras que estan en estado Por Aceptar.");
                    return;
                }

                List<LetrasEstadoE> oEstados = AgenteVentas.Proxy.ListarEstadosLetras(current.idEmpresa, current.idLocal, current.tipCanje, current.codCanje, current.Numero, current.Corre);

                if (oEstados.Count > 1)
                {
                    Global.MensajeComunicacion("No puede Anular porque la letra porque ya tiene movimientos.");
                    return;
                }

                if (current.Estado != "B")
                {
                    Int32 resp = AgenteVentas.Proxy.ActualizarEstadoDeLetra(current.idEmpresa, current.idLocal, current.tipCanje, current.codCanje, "%", "%%", null, null, "B", VariablesLocales.SesionUsuario.Credencial);

                    if (resp > 0)
                    {
                        Buscar();
                        Global.MensajeComunicacion("El canje de letra se anuló.");
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion("Se va eliminar el Canje de Letras completamente, desea continuar...") == DialogResult.Yes)
                    {
                        Int32 resp = AgenteVentas.Proxy.EliminarLetrasCanjeUnion(current.idEmpresa, current.idLocal, current.tipCanje, current.codCanje);

                        if (resp > 0)
                        {
                            Buscar();
                            Global.MensajeComunicacion("El canje se eliminó completamente.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_RenovacionClosing(Object sender, FormClosingEventArgs e)
        {
            frmLetrasCanje oFrm = sender as frmLetrasCanje;

            if (oFrm.DialogResult == DialogResult.OK && oFrm.oLetra != null)
            {
                if (oListaLetras != null)
                {
                    Buscar();
                    //if (oFrm.Opcion == (Int32)EnumOpcionGrabar.Actualizar)
                    //{
                    //    for (Int32 i = 0; i < oListaLetras.Count - 1; i++)
                    //    {
                    //        if (oListaLetras[i].idEmpresa == oFrm.oLetra.idEmpresa && oListaLetras[i].idLocal == oFrm.oLetra.idLocal
                    //            && oListaLetras[i].tipCanje == oFrm.oLetra.tipCanje && oListaLetras[i].codCanje == oFrm.oLetra.codCanje
                    //            && oListaLetras[i].Numero == oFrm.oLetra.Numero && oListaLetras[i].Corre == oFrm.oLetra.Corre)
                    //        {
                    //            oListaLetras[i] = oFrm.oLetra;
                    //            i = oListaLetras.Count;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    oListaLetras.Add(oFrm.oLetra);
                    //}

                    //oListaLetras = (from x in oListaLetras orderby x.codCanje, x.Corre select x).ToList();

                    //bsLetras.DataSource = oListaLetras;
                    //bsLetras.ResetBindings(false);
                }
            }
        }

        #endregion

        #region Eventos

        private void frmListadoLetrasAprobacion_Load(object sender, EventArgs e)
        {
            Grid = true;
            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());

            BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20535703214")//Fitocorp
            {
                tsmiRegenerar.Visible = true;
            }
        }

        private void dgvLetras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Editar();
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
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

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
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

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
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtIdCliente.Text = String.Empty;
            txtRazonSocial.Text = String.Empty;
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtIdCliente.Text = String.Empty;
            txtRuc.Text = String.Empty;
        }

        private void tsmAprobarLetras_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaLetras != null && oListaLetras.Count > 0 && bsLetras.Current != null)
                {
                    LetrasE current = (LetrasE)bsLetras.Current;

                    //Estado P=PorAceptar A=Aceptado B=Anulado
                    if (current.Estado == "A" || current.Estado == "B")
                    {
                        Global.MensajeComunicacion("Sólo se puede Aceptar Letras con Estado Por Aceptar.");
                        return;
                    }

                    frmMensajeFecAprobacion oFrm = new frmMensajeFecAprobacion();

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.FechaAprobacion != null)
                    {
                        DateTime? FechaApro = Convert.ToDateTime(oFrm.FechaAprobacion);
                        int Acepto = AgenteVentas.Proxy.AprobarLetrasCanjeUnion(current.idEmpresa, current.idLocal, current.tipCanje, current.codCanje, FechaApro.Value, VariablesLocales.SesionUsuario.Credencial);

                        if (Acepto == 1)
                        {
                            String Mensaje = AgenteVentas.Proxy.GenerarProvisionLetra(current.idEmpresa, current.idLocal, current.tipCanje, current.codCanje, current.idPersona, current.RazonSocial, VariablesLocales.SesionUsuario.Credencial);
                            Buscar();
                            Global.MensajeComunicacion(Mensaje);
                        }
                    }
                }
            }
            catch (Exception ex)    
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmRefinanciar_Click(object sender, EventArgs e)
        {

        }

        private void tsmRenovar_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaLetras != null && oListaLetras.Count > 0 && bsLetras.Current != null)
                {
                    LetrasE current = (LetrasE)bsLetras.Current;

                    if (current == null)
                    {
                        throw new Exception("Debe escoger una letra antes de rebovarla");
                    }

                    //Si el estado es Por Aceptar o Borrado no se puede renovar...
                    if (current.Estado == "P" || current.Estado == "B")
                    {
                        Global.MensajeComunicacion("Sólo se pueden renovar Letras Aceptadas.");
                        return;
                    }

                    ///Recuperar la letra completa
                    ///Cambió el 30-01-19
                    LetrasE oLetra = AgenteVentas.Proxy.ObtenerLetras(current.idEmpresa, current.idLocal, current.tipCanje, current.codCanje, current.Numero, current.Corre);//Colecciones.CopiarEntidad<LetrasE>(current);

                    if (oLetra.tipCanje != "RV")
                    {
                        List<LetrasE> oListaRenovacion = (from x in oListaLetras
                                                          where x.idEmpresa == oLetra.idEmpresa
                                                          && x.idLocal == oLetra.idLocal
                                                          && x.Numero == oLetra.Numero
                                                          && x.tipCanje == "RV"
                                                          select x).ToList();

                        if (oListaRenovacion.Count > Variables.Cero)
                        {
                            Global.MensajeComunicacion("La letra ya tiene Renovación. Escoja la última renovación");
                            oListaRenovacion = null;
                            return;
                        }
                    }
                    else
                    {
                        String Correlativo = Convert.ToString((from m in oListaLetras
                                                               where m.idEmpresa == oLetra.idEmpresa
                                                               && m.idLocal == oLetra.idLocal
                                                               && m.codCanje == oLetra.codCanje
                                                               && m.Numero == oLetra.Numero
                                                               && m.tipCanje == "RV"
                                                               select m.Corre).Max());

                        LetrasE oRenovacion = (from y in (from x in oListaLetras
                                                          where x.idEmpresa == oLetra.idEmpresa
                                                          && x.idLocal == oLetra.idLocal
                                                          && x.codCanje == oLetra.codCanje
                                                          && x.Numero == oLetra.Numero
                                                          && x.tipCanje == "RV"
                                                          && x.Corre == Correlativo
                                                          select x).ToList()
                                               select y).SingleOrDefault();

                        if (oRenovacion.Corre != oLetra.Corre)
                        {
                            Global.MensajeComunicacion("Debe escoger la última renovación.");
                            return;
                        }
                    }

                    List<CtaCteE> ListaCtaCte = new TesoreriaServiceAgent().Proxy.ObtenerCtaCtePorEstadosLetras(current.idEmpresa, "LT", "", current.Numero + current.Corre);

                    if (ListaCtaCte.Count == 1)
                    {
                        if (ListaCtaCte[0].FechaCancelacion.ToString("yyyMMdd") == "21001231")
                        {
                            oLetra.idCtaCte = ListaCtaCte[0].idCtaCte;
                            oLetra.numVerPlanCuentas = ListaCtaCte[0].numVerPlanCuentas;
                            oLetra.CuentaContable = ListaCtaCte[0].codCuenta;
                            oLetra.tipCambio = ListaCtaCte[0].TipoCambio;
                        }
                        else
                        {
                            Global.MensajeAdvertencia("No existe ningún movimiento en la CtaCte con la Letra escogida o la Letra ha sido cancelada en su totalidad.");
                            return;
                        }
                    }
                    else if (ListaCtaCte.Count > 1)
                    {
                        CtaCteE oCtaCte = ListaCtaCte.Find
                        (
                            delegate (CtaCteE cc) { return cc.FechaCancelacion.ToString("yyyMMdd") == "21001231"; }
                        );

                        if (oCtaCte != null)
                        {
                            oLetra.idCtaCte = oCtaCte.idCtaCte;
                            oLetra.numVerPlanCuentas = oCtaCte.numVerPlanCuentas;
                            oLetra.CuentaContable = oCtaCte.codCuenta;
                            oLetra.tipCambio = oCtaCte.TipoCambio;
                        }
                        else
                        {
                            Global.MensajeAdvertencia("No existe ningún movimiento en la CtaCte con la Letra escogida o la Letra ha sido cancelada en su totalidad.");
                            return;
                        }
                    }

                    oLetra.UsuarioRegistro = oLetra.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oLetra.FechaRegistro = oLetra.FechaModificacion = VariablesLocales.FechaHoy;

                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmLetrasCanje);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        //si la instancia existe la pongo en primer plano
                        oFrm.BringToFront();
                        return;
                    }

                    //sino existe la instancia se crea una nueva
                    oFrm = new frmLetrasCanje(oLetra, "RV")
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_RenovacionClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiVerVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpresionVoucher);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                LetrasE Letras = (LetrasE)bsLetras.Current;

                if (Letras != null)
                {
                    VoucherE VoucherRep = new VoucherE
                    {
                        AnioPeriodo = Letras.AnioPeriodo,
                        numVoucher = Letras.numVoucher,
                        idComprobante = Letras.idComprobante,
                        numFile = Letras.numFile,
                        MesPeriodo = Letras.MesPeriodo,
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        idLocal = Letras.idLocal
                    };

                    oFrm = new frmImpresionVoucher("N", VoucherRep)
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiDesaprobarLetra_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsLetras.Current != null)
                {
                    LetrasE current = (LetrasE)bsLetras.Current;

                    if (!String.IsNullOrWhiteSpace(current.EstadoPlanillaBanco))
                    {
                        if (current.EstadoPlanillaBanco == "C")
                        {
                            Global.MensajeComunicacion((String.Format("La planilla de banco N° {0} asociada a la Letra se encuentra cerrada, no puede ser DESAPROBADA.", current.codPlanillaBanco)));
                            return;
                        }
                    }

                    //Estado P=PorAceptar A=Aceptado B=Anulado
                    if (current.Estado != "A")
                    {
                        Global.MensajeComunicacion("Sólo se puede Desaprobar las Letras que esten Aceptadas.");
                        return;
                    }

                    if (current.tipCanje != "RV")
                    {
                        List<LetrasEstadoE> oEstados = AgenteVentas.Proxy.ListarEstadosLetras(current.idEmpresa, current.idLocal, current.tipCanje, current.codCanje, current.Numero, current.Corre);

                        if (oEstados.Count > 1)
                        {
                            Global.MensajeComunicacion("No puede Desaprobar la letra porque ya tiene movimientos.");
                            return;
                        } 
                    }

                    int Acepto = AgenteVentas.Proxy.DesaprobarLetras(current, VariablesLocales.SesionUsuario.Credencial);

                    if (Acepto == 1)
                    {
                        Buscar();
                        Global.MensajeComunicacion("Canje de Letra desaprobada.");
                    } 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmEstados_Click(object sender, EventArgs e)
        {
            try
            {
                LetrasE current = (LetrasE)bsLetras.Current;

                if (current != null && current.Estado == "A") //Solo estado Aceptado
                {
                    List<LetrasEstadoE> oEstados = AgenteVentas.Proxy.ListarEstadosLetras(current.idEmpresa, current.idLocal, current.tipCanje, current.codCanje, current.Numero, current.Corre);

                    if (oEstados.Count > 0)
                    {
                        frmLetraDetalles oFrm = new frmLetraDetalles(oEstados);
                        oFrm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiLimpiarVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsLetras.Current != null)
                {
                    LetrasE current = (LetrasE)bsLetras.Current;

                    //Estado P=PorAceptar A=Aceptado B=Anulado
                    if (current.Estado == "A" || current.Estado == "B")
                    {
                        Global.MensajeComunicacion("Sólo se limpian los datos si la letras estan Por Aceptar.");
                        return;
                    }

                    Int32 resp = AgenteVentas.Proxy.ActualizarLetrasCanjeConta(current.idEmpresa, current.idLocal, current.tipCanje, current.codCanje, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty,
                                                                                VariablesLocales.SesionUsuario.Credencial);
                    if (resp > 0)
                    {
                        ((LetrasE)bsLetras.Current).idComprobante = String.Empty;
                        ((LetrasE)bsLetras.Current).numFile = String.Empty;
                        ((LetrasE)bsLetras.Current).AnioPeriodo = String.Empty;
                        ((LetrasE)bsLetras.Current).MesPeriodo = String.Empty;
                        ((LetrasE)bsLetras.Current).numVoucher = String.Empty;

                        bsLetras.ResetBindings(false);
                    } 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvLetras_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //Si se encuentra anulado
                if ((String)dgvLetras.Rows[e.RowIndex].Cells["Estado"].Value == "B")
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Valores.ColorAnulado;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvLetras_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (oListaLetras != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // POR LETRA
                    if (e.ColumnIndex == dgvLetras.Columns["Letra"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaLetras = (from x in oListaLetras orderby x.Letra ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaLetras = (from x in oListaLetras orderby x.Letra descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR FECHA
                    if (e.ColumnIndex == dgvLetras.Columns["Fecha"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaLetras = (from x in oListaLetras orderby x.Fecha ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaLetras = (from x in oListaLetras orderby x.Fecha descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR FECHA DE VENCIMIENTO
                    if (e.ColumnIndex == dgvLetras.Columns["FechaVenc"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaLetras = (from x in oListaLetras orderby x.FechaVenc ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaLetras = (from x in oListaLetras orderby x.FechaVenc descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR RAZON SOCIAL
                    if (e.ColumnIndex == dgvLetras.Columns["RazonSocial"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaLetras = (from x in oListaLetras orderby x.RazonSocial ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaLetras = (from x in oListaLetras orderby x.RazonSocial descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR MONTO ORIGEN
                    if (e.ColumnIndex == dgvLetras.Columns["MontoOrigen"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaLetras = (from x in oListaLetras orderby x.MontoOrigen ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaLetras = (from x in oListaLetras orderby x.MontoOrigen descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR COD CANJE
                    if (e.ColumnIndex == dgvLetras.Columns["codCanje"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaLetras = (from x in oListaLetras orderby x.codCanje ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaLetras = (from x in oListaLetras orderby x.codCanje descending select x).ToList();
                            Ordenar = true;
                        }
                    }
                }

                bsLetras.DataSource = oListaLetras;
            }
        }

        private void bsLetras_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                LblTitulo.Text = "Registros " + bsLetras.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiCobranzas_Click(object sender, EventArgs e)
        {
            try
            {
                LetrasE current = (LetrasE)bsLetras.Current;

                if (current != null && current.Estado == "A") //Solo estado aceptado
                {
                    List<CobranzasItemDetE> oCobranzas = AgenteCtaPorCobrar.Proxy.ListarCobranzasItemDetPorLetra(current.idEmpresa, current.idLocal, current.idPersona, current.Numero + current.Corre);

                    if (oCobranzas.Count > 0)
                    {
                        frmLetraDetalles oFrm = new frmLetraDetalles(oCobranzas);
                        oFrm.ShowDialog();
                    }
                    else
                    {
                        Global.MensajeComunicacion("No existe ninguna cobranza.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btActualizarCtaCte_Click(object sender, EventArgs e)
        {
            try
            {
                LetrasE current = (LetrasE)bsLetras.Current;

                if (current != null)
                {
                    Int32 resp = AgenteVentas.Proxy.ActualizarLetraDocCtaCte(current.idEmpresa, current.idLocal, current.tipCanje, current.codCanje);

                    if (resp > 0)
                    {
                        Global.MensajeComunicacion("Id Cta.Cte. actualizada.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiRegenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.MensajeConfirmacion("Desea volvera generar el asiento") == DialogResult.Yes)
                {
                    LetrasE current = (LetrasE)bsLetras.Current;
                    String Mensaje = AgenteVentas.Proxy.GenerarProvisionLetra(current.idEmpresa, current.idLocal, current.tipCanje, current.codCanje, current.idPersona, current.RazonSocial, VariablesLocales.SesionUsuario.Credencial, "S");
                    Buscar();
                    Global.MensajeComunicacion(Mensaje);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiCorregir_Click(object sender, EventArgs e)
        {
            try
            {
                LetrasE current = (LetrasE)bsLetras.Current;

                //Si el estado es Por Aceptar o Borrado no se puede corregir...
                if (current.Estado == "P" || current.Estado == "B")
                {
                    Global.MensajeComunicacion("Sólo se pueden corregir Letras Aceptadas.");
                    return;
                }

                if (Global.MensajeConfirmacion("Se va a corregir el T.C. en las Letras, desea continuar?") == DialogResult.Yes)
                {
                    String Mensaje = AgenteVentas.Proxy.CorregirLetraTicaCteCte(current.idEmpresa, current.idLocal, current.tipCanje, current.codCanje, VariablesLocales.SesionUsuario.Credencial);
                    Buscar();
                    Global.MensajeComunicacion(Mensaje);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
