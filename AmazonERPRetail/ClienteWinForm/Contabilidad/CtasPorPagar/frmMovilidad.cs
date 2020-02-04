using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.CtasPorPagar;
using Entidades.Generales;
using Entidades.Tesoreria;
using Entidades.Maestros;
using Entidades.Seguridad;
using ClienteWinForm.Busquedas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmMovilidad : FrmMantenimientoBase
    {

        #region Constructores

        //Nuevo
        public frmMovilidad()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvDetMov, true, false, 28);

            LlenarTipoGasto();
        }

        //Edición
        public frmMovilidad(Int32 idEmpresa, Int32 idLocal, Int32 idMovilidad)
            : this()
        {
            oMovilidad = AgenteCtaPorPagar.Proxy.ObtenerMovilidadCompleta(idEmpresa, idLocal, idMovilidad);
            Text = "Movilidad (N° " + oMovilidad.idMovilidad.ToString() + ")";
        }

        //Liquidación
        public frmMovilidad(String Tipo_)
            : this()
        {
            Tipo = Tipo_;
        }

        #endregion

        #region Variables

        CtasPorPagarServiceAgent AgenteCtaPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        public MovilidadE oMovilidadLiqui = null;
        MovilidadE oMovilidad = null;
        Int32 opcion;
        String Tipo = String.Empty;
        Boolean Libre = false;

        #endregion

        #region Procedimientos de Usuario

        void GuardarDatos()
        {
            oMovilidad.Fecha = dtpFecha.Value;
            oMovilidad.Serie = txtSerie.Text.Trim();
            oMovilidad.Numero = txtNumero.Text.Trim();
            oMovilidad.idPersona = Convert.ToInt32(txtIdPersona.Text);
            oMovilidad.tipGastoMovi = Convert.ToInt32(cboTipoGasto.SelectedValue);

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oMovilidad.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oMovilidad.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void EditarDetalle(DataGridViewCellEventArgs e, MovilidadDetE oReqItem)
        {
            try
            {
                if (bsMovilidadDet.Count > 0)
                {
                    String Estado = txtEstado.Text == "CERRADO" ? "C" : "A";

                    frmMovilidadDet oFrm = new frmMovilidadDet(oReqItem, Estado);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oMovilidad.ListaMovilidadDet[e.RowIndex] = oFrm.MovilidadItem;
                        bsMovilidadDet.DataSource = oMovilidad.ListaMovilidadDet;
                        bsMovilidadDet.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void LlenarTipoGasto()
        {
            //List<ParTabla> TipoGastos = AgenteGeneral.Proxy.ListarParTablaPorNemo("TGMOV");
            //ComboHelper.LlenarCombos<ParTabla>(cboTipoGasto, TipoGastos);

            //Tipo de Liquidación - Tipo Cuentas Contables
            //List<ParTabla> ListaCuentas = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPLIQ");
            //ListaCuentas.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione });
            ComboHelper.RellenarCombos<ParTabla>(cboTipoGasto, (from x in AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPLIQ")
                                                                orderby x.IdParTabla
                                                                select x).ToList(), "IdParTabla", "Nombre", false);
        }

        void BuscarFondoFijo(Int32 idPersona)
        {
            List<FondoFijoE> oListaFondoFijo = AgenteTesoreria.Proxy.ListarFondoFijoPorResponsable(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idPersona);

            if (oListaFondoFijo != null)
            {
                txtRUC.TextChanged -= txtRUC_TextChanged;
                txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                if (oListaFondoFijo.Count == 0)
                {
                    Bloquear(true);
                    Libre = true;
                }
                else if (oListaFondoFijo.Count == 1)
                {
                    txtIdPersona.Text = oListaFondoFijo[0].idPersonaResponsable.ToString();
                    txtRUC.Text = oListaFondoFijo[0].nroResponsable;
                    txtRazonSocial.Text = oListaFondoFijo[0].desResponsable;
                    cboTipoGasto.SelectedValue = oListaFondoFijo[0].TipoCuentaLiq;
                    Libre = false;
                }
                else if (oListaFondoFijo.Count > 1)
                {
                    frmBuscarFondoFijo oFrm = new frmBuscarFondoFijo(oListaFondoFijo);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oFondo != null)
                    {
                        txtIdPersona.Text = oFrm.oFondo.idPersonaResponsable.ToString();
                        txtRUC.Text = oFrm.oFondo.nroResponsable;
                        txtRazonSocial.Text = oFrm.oFondo.desResponsable;
                        cboTipoGasto.SelectedValue = oFrm.oFondo.TipoCuentaLiq;
                        Libre = false;
                    }
                }

                if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
                {
                    Bloquear(true);
                    Libre = true;
                }

                txtRUC.TextChanged += txtRUC_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
            }
            else
            {
                Bloquear(true);
            }
        }

        void Bloquear(Boolean Bloq)
        {
            dtpFecha.Enabled = Bloq;
            txtRUC.Enabled = Bloq;
            txtRazonSocial.Enabled = Bloq;
            cboTipoGasto.Enabled = Bloq;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oMovilidad == null)
            {
                oMovilidad = new MovilidadE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                    indEstado = false
                };

                txtEstado.Text = "PENDIENTE";
                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
                BuscarFondoFijo(VariablesLocales.SesionUsuario.IdPersona);
            }
            else
            {
                txtRUC.TextChanged -= txtRUC_TextChanged;
                txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                txtIdMovilidad.Text = oMovilidad.idMovilidad.ToString();
                dtpFecha.Value = oMovilidad.Fecha;
                txtSerie.Text = oMovilidad.Serie;
                txtNumero.Text = oMovilidad.Numero;
                txtIdPersona.Text = oMovilidad.idPersona.ToString();
                txtRUC.Text = oMovilidad.RUC;
                txtRazonSocial.Text = oMovilidad.RazonSocial;
                cboTipoGasto.SelectedValue = Convert.ToInt32(oMovilidad.tipGastoMovi);
                txtEstado.Text = oMovilidad.desEstado;

                txtUsuRegistra.Text = oMovilidad.UsuarioRegistro;
                txtRegistro.Text = oMovilidad.FechaRegistro.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = oMovilidad.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;

                txtRUC.TextChanged += txtRUC_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
            }

            bsMovilidadDet.DataSource = oMovilidad.ListaMovilidadDet;
            bsMovilidadDet.ResetBindings(false);

            if (Tipo != "Liqui")
            {
                if (oMovilidad.indEstado)
                {
                    Global.MensajeComunicacion("El registro de movilidad se encuentra Cerrado. No podrá hacer modificaciones.");
                    //pnlDatos.Enabled = false;
                    Bloquear(false);
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
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
                if (oMovilidad != null)
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
                            oMovilidad = oMovilidadLiqui = AgenteCtaPorPagar.Proxy.GrabarMovilidad(oMovilidad, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oMovilidad = AgenteCtaPorPagar.Proxy.GrabarMovilidad(oMovilidad, EnumOpcionGrabar.Actualizar);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                }

                if (Tipo != "Liqui")
                {
                    base.Grabar();
                }

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
            String Respuesta = ValidarEntidad<MovilidadE>(oMovilidad);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            if (String.IsNullOrEmpty(txtIdPersona.Text.Trim()))
            {
                Global.MensajeComunicacion("Debe ingresar un auxiliar.");
                txtRUC.Focus();
                return false;
            }

            return base.ValidarGrabacion();
        }

        public override void AgregarDetalle()
        {
            try
            {
                if (oMovilidad.ListaMovilidadDet == null)
                {
                    oMovilidad.ListaMovilidadDet = new List<MovilidadDetE>();
                }

                frmMovilidadDet oFrm = new frmMovilidadDet();

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    MovilidadDetE oMoviItem = oFrm.MovilidadItem;
                    oMovilidad.ListaMovilidadDet.Add(oMoviItem);
                    bsMovilidadDet.DataSource = oMovilidad.ListaMovilidadDet;
                    bsMovilidadDet.ResetBindings(false);
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
                if (bsMovilidadDet.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        if (oMovilidad.ListaMovilidadEliminados == null)
                        {
                            oMovilidad.ListaMovilidadEliminados = new List<MovilidadDetE>();
                        }

                        oMovilidad.ListaMovilidadEliminados.Add((MovilidadDetE)bsMovilidadDet.Current);
                        oMovilidad.ListaMovilidadDet.RemoveAt(bsMovilidadDet.Position);
                        bsMovilidadDet.DataSource = oMovilidad.ListaMovilidadDet;
                        bsMovilidadDet.ResetBindings(false);

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

        #region Eventos de Usuario

        private void lblListaTmp_DoubleClick(object sender, EventArgs e)
        {
            txtRUC.TextChanged -= txtRUC_TextChanged;
            txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

            ListBox lb = (ListBox)sender;

            txtIdPersona.Text = lb.SelectedValue.ToString();
            txtRUC.Text = ((TrabajadorE)lb.SelectedItem).NroDocumento;
            txtRazonSocial.Text = ((TrabajadorE)lb.SelectedItem).desPersona;

            lb.Visible = false;
            lb.Dispose();
            cboTipoGasto.Focus();

            txtRUC.TextChanged += txtRUC_TextChanged;
            txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
        }

        private void lblListaTmp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                txtRUC.TextChanged -= txtRUC_TextChanged;
                txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                ListBox lb = (ListBox)sender;

                txtIdPersona.Text = lb.SelectedValue.ToString();
                txtRUC.Text = ((TrabajadorE)lb.SelectedItem).NroDocumento;
                txtRazonSocial.Text = ((TrabajadorE)lb.SelectedItem).desPersona;

                lb.Visible = false;
                lb.Dispose();
                cboTipoGasto.Focus();

                txtRUC.TextChanged += txtRUC_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
            }
        }

        #endregion

        #region Eventos

        private void frmMovilidad_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();

            if (Tipo == "Liqui")
            {
                Size = new Size(867, 422);
            }
        }

        private void dgvDetMov_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditarDetalle(e, ((MovilidadDetE)bsMovilidadDet.Current));
            }
        }

        private void txtRUC_TextChanged(object sender, EventArgs e)
        {
            txtIdPersona.Text = string.Empty;
            txtRazonSocial.Text = String.Empty;
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtIdPersona.Text = string.Empty;
            txtRUC.Text = String.Empty;
        }

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtRUC.Text.Trim()) && !String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
            {
                Libre = true;
                if (!Libre)
                {
                    List<FondoFijoE> oListaFondoFijo = AgenteTesoreria.Proxy.ListarFondoFijoPorResponsable(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, 0);

                    if (oListaFondoFijo.Count > 0)
                    {
                        txtRUC.TextChanged -= txtRUC_TextChanged;
                        txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                        List<FondoFijoE> oListaFondoFijo2 = oListaFondoFijo.Where(x => x.desResponsable.ToUpper().Contains(txtRazonSocial.Text.Trim().ToUpper())).ToList();

                        if (oListaFondoFijo2.Count == 0)
                        {
                            txtIdPersona.Text = String.Empty;
                            txtRUC.Text = String.Empty;
                            txtRazonSocial.Text = String.Empty;
                        }
                        else if (oListaFondoFijo2.Count == 1)
                        {
                            txtIdPersona.Text = oListaFondoFijo2[0].idPersonaResponsable.ToString();
                            txtRUC.Text = oListaFondoFijo2[0].nroResponsable;
                            txtRazonSocial.Text = oListaFondoFijo2[0].desResponsable;
                        }
                        else if (oListaFondoFijo2.Count > 1)
                        {
                            frmBuscarFondoFijo oFrm = new frmBuscarFondoFijo(oListaFondoFijo);

                            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oFondo != null)
                            {
                                txtIdPersona.Text = oFrm.oFondo.idPersonaResponsable.ToString();
                                txtRUC.Text = oFrm.oFondo.nroResponsable;
                                txtRazonSocial.Text = oFrm.oFondo.desResponsable;
                            }
                        }

                        txtRUC.TextChanged += txtRUC_TextChanged;
                        txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                    }
                    else
                    {
                        Global.MensajeComunicacion("No se han creado ningún Auxiliar de Fondos Fijos");
                    } 
                }
                else
                {
                    //List<TrabajadorE> ListaTrabajador = AgenteMaestro.Proxy.ListarTrabajador(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "", txtRazonSocial.Text.Trim());

                    //if (ListaTrabajador.Count == 0)
                    //{
                    //    txtIdPersona.Text = String.Empty;
                    //    txtRUC.Text = String.Empty;
                    //    txtRazonSocial.Text = String.Empty;
                    //}
                    //else if (ListaTrabajador.Count == 1)
                    //{
                    //    txtRUC.TextChanged -= txtRUC_TextChanged;
                    //    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    //    txtIdPersona.Text = ListaTrabajador[0].idPersona.ToString();
                    //    txtRUC.Text = ListaTrabajador[0].NroDocumento;
                    //    txtRazonSocial.Text = ListaTrabajador[0].desPersona;

                    //    txtRUC.TextChanged += txtRUC_TextChanged;
                    //    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                    //}
                    //else if (ListaTrabajador.Count > 1)
                    //{
                    //    ListBox lblListaTmp = new ListBox()
                    //    {
                    //        FormattingEnabled = true,
                    //        Location = new Point(txtRazonSocial.Location.X, txtRazonSocial.Location.Y + txtRazonSocial.Height + 1),
                    //        Size = new Size(400, 40),
                    //        TabIndex = 0
                    //    };

                    //    lblListaTmp.Focus();
                    //    pnlDatos.Controls.Add(lblListaTmp);
                    //    lblListaTmp.BringToFront();

                    //    lblListaTmp.DataSource = ListaTrabajador;
                    //    lblListaTmp.DisplayMember = "desPersona";
                    //    lblListaTmp.ValueMember = "IdPersona";

                    //    lblListaTmp.Focus();
                    //    lblListaTmp.DoubleClick += new EventHandler(lblListaTmp_DoubleClick);
                    //    lblListaTmp.KeyDown += new KeyEventHandler(lblListaTmp_KeyDown);
                    //}
                }
            }
        }

        private void txtRUC_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRUC.Text.Trim()) && String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    if (!Libre)
                    {
                        List<FondoFijoE> oListaFondoFijo = AgenteTesoreria.Proxy.ListarFondoFijoPorResponsable(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, 0);

                        if (oListaFondoFijo.Count > 0)
                        {
                            txtRUC.TextChanged -= txtRUC_TextChanged;
                            txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                            List<FondoFijoE> oListaFondoFijo2 = oListaFondoFijo.Where(x => x.nroResponsable.Contains(txtRUC.Text)).ToList();

                            if (oListaFondoFijo2.Count == 0)
                            {
                                txtRUC.TextChanged -= txtRUC_TextChanged;
                                txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                                txtIdPersona.Text = String.Empty;
                                txtRUC.Text = String.Empty;
                                txtRazonSocial.Text = String.Empty;

                                txtRUC.TextChanged += txtRUC_TextChanged;
                                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                            }
                            else if (oListaFondoFijo2.Count == 1)
                            {
                                txtIdPersona.Text = oListaFondoFijo2[0].idPersonaResponsable.ToString();
                                txtRUC.Text = oListaFondoFijo2[0].nroResponsable;
                                txtRazonSocial.Text = oListaFondoFijo2[0].desResponsable;
                            }
                            else if (oListaFondoFijo2.Count > 1)
                            {
                                frmBuscarFondoFijo oFrm = new frmBuscarFondoFijo(oListaFondoFijo);

                                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oFondo != null)
                                {
                                    txtIdPersona.Text = oFrm.oFondo.idPersonaResponsable.ToString();
                                    txtRUC.Text = oFrm.oFondo.nroResponsable;
                                    txtRazonSocial.Text = oFrm.oFondo.desResponsable;
                                }
                            }

                            txtRUC.TextChanged += txtRUC_TextChanged;
                            txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                        }
                        else
                        {
                            Global.MensajeComunicacion("No se han creado ningún Auxiliar de Fondos Fijos");
                        } 
                    }
                    else
                    {
                        //List<TrabajadorE> ListaTrabajador = AgenteMaestro.Proxy.ListarTrabajador(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtRUC.Text.Trim(), "");

                        //if (ListaTrabajador.Count == 0)
                        //{
                        //    txtIdPersona.Text = String.Empty;
                        //    txtRUC.Text = String.Empty;
                        //    txtRazonSocial.Text = String.Empty;
                        //}
                        //else if (ListaTrabajador.Count == 1)
                        //{
                        //    txtIdPersona.Text = ListaTrabajador[0].idPersona.ToString();
                        //    txtRUC.Text = ListaTrabajador[0].NroDocumento;
                        //    txtRazonSocial.Text = ListaTrabajador[0].desPersona;
                        //}
                        //else if (ListaTrabajador.Count > 1)
                        //{
                        //    ListBox lblListaTmp = new ListBox()
                        //    {
                        //        FormattingEnabled = true,
                        //        Location = new Point(txtRUC.Location.X, txtRUC.Location.Y + txtRUC.Height + 1),
                        //        Size = new Size(400, 40),
                        //        TabIndex = 0
                        //    };

                        //    lblListaTmp.Focus();
                        //    pnlDatos.Controls.Add(lblListaTmp);
                        //    lblListaTmp.BringToFront();

                        //    lblListaTmp.DataSource = ListaTrabajador;
                        //    lblListaTmp.DisplayMember = "desPersona";
                        //    lblListaTmp.ValueMember = "IdPersona";

                        //    lblListaTmp.Focus();
                        //    lblListaTmp.DoubleClick += new EventHandler(lblListaTmp_DoubleClick);
                        //    lblListaTmp.KeyDown += new KeyEventHandler(lblListaTmp_KeyDown);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            oMovilidadLiqui = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btInsertarDetalle_Click(object sender, EventArgs e)
        {
            AgregarDetalle();
        }

        #endregion

    }
}
