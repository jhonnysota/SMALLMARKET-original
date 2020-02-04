using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Tesoreria;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmFondoFijo : FrmMantenimientoBase
    {

        #region Constructores

        public frmFondoFijo()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();
        }

        //Nuevo
        public frmFondoFijo(FondoFijoE FondoEnt, Persona pers_, Int32 OpcionGrabar, String Existe_) //String TipoFondoNuevo_, String Documento_, Int32 tipoper, Int32 tipodoc, Persona pers_, string Existe_)
           : this()
        {
            oFondoFijo = FondoEnt;
            oPersona = pers_;
            Existe = Existe_;
            opcion = OpcionGrabar;
        }

        //Edición
        public frmFondoFijo(Int32 idEmpresa, Int32 idLocal, Int32 idFondo, Persona Per_)
            : this()
        {
            oFondoFijo = AgenteTesoreria.Proxy.ObtenerFondoFijo(idEmpresa, idLocal, idFondo);
            oPersona = Per_;

            opcion = (Int32)EnumOpcionGrabar.Actualizar;
        } 

        #endregion

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        FondoFijoE oFondoFijo = null;
        Persona oPersona = null;
        Int32 opcion;
        String Existe;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            ///LIBROS///
            List<ComprobantesE> ListaTipoComprobante = new List<ComprobantesE>(VariablesLocales.oListaComprobantes); //AgenteContabilidad.Proxy.ListarComprobantes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ComprobantesE p = new ComprobantesE() { idComprobante = Variables.Cero.ToString(), desComprobanteComp = Variables.Todos };
            ListaTipoComprobante.Add(p);
            ComboHelper.RellenarCombos<ComprobantesE>(cboIDComprobante, (from x in ListaTipoComprobante
                                                                         orderby x.idComprobante
                                                                         select x).ToList(), "idComprobante", "desComprobanteComp", false);
            cboIDComprobante.SelectedValue = Variables.Cero.ToString();
            cboIDComprobante_SelectionChangeCommitted(new object(), new EventArgs());

            //////Moneda///////
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            MonedasE CampoInicial = new MonedasE() { idMoneda = Variables.Cero.ToString(), desMoneda = Variables.Seleccione };
            ListaMoneda.Add(CampoInicial);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListaMoneda
                                                               where (x.idMoneda == Variables.Soles) ||
                                                                     (x.idMoneda == Variables.Dolares) ||
                                                                     (x.idMoneda == Variables.Cero.ToString())
                                                               orderby x.idMoneda
                                                               select x).ToList(), "idMoneda", "desMoneda", false);

            //Moneda Bancaria
            ComboHelper.RellenarCombos<MonedasE>(cboMonedaBanco, (from x in ListaMoneda
                                                                  where (x.idMoneda == Variables.Soles) ||
                                                                        (x.idMoneda == Variables.Dolares) ||
                                                                        (x.idMoneda == Variables.Cero.ToString())
                                                                  orderby x.idMoneda
                                                                  select x).ToList(), "idMoneda", "desMoneda", false);

            ////TipoFondo////
            cboTipoFondo.DataSource = Global.CargarTipoFondo();
            cboTipoFondo.ValueMember = "id";
            cboTipoFondo.DisplayMember = "Nombre";

            //Tipo de Cuentas Bancarias
            List<ParTabla> ListaTipoArticulo = AgenteGeneral.Proxy.ListarParTablaPorNemo("CTABAN");
            ListaTipoArticulo.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione });
            ComboHelper.RellenarCombos<ParTabla>(cboTipoCuenta, (from x in ListaTipoArticulo orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);

            //Tipo de Liquidación - Tipo Cuentas Contables
            List<ParTabla> ListaCuentas = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPLIQ");
            ListaCuentas.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione });
            ComboHelper.RellenarCombos<ParTabla>(cboCuentas, (from x in ListaCuentas orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
        }

        void GuardarDatos()
        {
            oFondoFijo.Persona.Nombres = txtNombre.Text.Trim();
            oFondoFijo.Persona.ApeMaterno = txtMat.Text.Trim();
            oFondoFijo.Persona.ApePaterno = txtPat.Text.Trim();
            oFondoFijo.Persona.RazonSocial = txtDesFondo.Text.Trim();
            oFondoFijo.Persona.NroDocumento = txtDoc.Text.Trim();
            oFondoFijo.Persona.RUC = txtDoc.Text.Trim();

            oFondoFijo.desFondo = txtDesFondo.Text;
            oFondoFijo.idPersonaResponsable = Convert.ToInt32(txtRuc.Tag);
            oFondoFijo.codCuenta = txtCodCuenta.Text.Trim();
            oFondoFijo.idComprobante = Convert.ToString(cboIDComprobante.SelectedValue);
            oFondoFijo.numFile = Convert.ToString(cboNumFile.SelectedValue);
            oFondoFijo.idMoneda = Convert.ToString(cboMoneda.SelectedValue);
            oFondoFijo.MontoAutorizado = Convert.ToDecimal(txtMontoAutorizado.Text);
            oFondoFijo.TipoFondo = Convert.ToString(cboTipoFondo.SelectedValue);

            if (oFondoFijo.TipoFondo == "168")
            {
                if (rbCtas.Checked)
                {
                    oFondoFijo.Tipo = "C";
                }
                else if (rbViaticos.Checked)
                {
                    oFondoFijo.Tipo = "V";
                }
            }
            else
            {
                oFondoFijo.Tipo = "";
                oFondoFijo.TipoCuentaLiq = null;
            }

            oFondoFijo.idPersonaBanco = String.IsNullOrWhiteSpace(txtIdBanco.Text) ? (Int32?)null : Convert.ToInt32(txtIdBanco.Text);
            oFondoFijo.tipCuenta = Convert.ToInt32(cboTipoCuenta.SelectedValue);
            oFondoFijo.idMonedaCuenta = cboMonedaBanco.SelectedValue.ToString();
            oFondoFijo.numCuenta = txtNumCuenta.Text.Trim();
            oFondoFijo.numInterbancaria = txtCuentaInter.Text.Trim();

            if (Convert.ToInt32(cboCuentas.SelectedValue) != 0)
            {
                oFondoFijo.TipoCuentaLiq = Convert.ToInt32(cboCuentas.SelectedValue);
            }
            else
            {
                oFondoFijo.TipoCuentaLiq = null;
            }

            if (opcion == (Int32)EnumOpcionGrabar.Insertar) //No existe ninguno de los 2
            {
                oFondoFijo.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oFondoFijo.Persona.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oFondoFijo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oFondoFijo.Persona.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
            else if (opcion == (Int32)EnumOpcionGrabar.InsertarSimple) //Existe Persona, pero no existe fondo fijo
            {
                oFondoFijo.Persona.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oFondoFijo.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oFondoFijo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oFondoFijo.Persona.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
            else //Actualizar ambos
            {
                oFondoFijo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oFondoFijo.Persona.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }

           
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oFondoFijo.TipoFondo == "102")
            {
                if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    Text = "Fondo Fijo (Nuevo)"; 
                }
                else
                {
                    Text = "Fondo Fijo (Edición)";
                }

                txtNombre.Visible = false;
                txtPat.Visible = false;
                txtMat.Visible = false;

                label8.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                btReniec.Visible = false;
            }
            else
            {
                if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    Text = "Entregas a Rendir (Nuevo)";
                }
                else
                {
                    Text = "Entregas a Rendir (Edición)";
                }

                txtDesFondo.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }

            txtRuc.TextChanged -= txtRuc_TextChanged;
            txtDesResponsable.TextChanged -= txtDesResponsable_TextChanged;
            txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
            txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oFondoFijo.Persona = new Persona();
                oFondoFijo.Persona = oPersona;

                oFondoFijo.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                oFondoFijo.idLocal = VariablesLocales.SesionLocal.IdLocal;
                txtID.Text = Convert.ToString(oFondoFijo.idPersona);
                txtDesFondo.Text = oFondoFijo.desFondo;
                cboTipoFondo.SelectedValue = oFondoFijo.TipoFondo;
                oFondoFijo.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                txtDoc.Text = oFondoFijo.Persona.NroDocumento;

                if (oFondoFijo.TipoFondo == "168")
                {
                    txtNombre.Text = oPersona.Nombres;
                    txtMat.Text = oPersona.ApeMaterno;
                    txtPat.Text = oPersona.ApePaterno;

                    rbCtas.Checked = true;
                }
                else
                {
                    txtNombre.Text = String.Empty;
                    txtMat.Text = String.Empty;
                    txtPat.Text = String.Empty;
                }

                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                oFondoFijo.FechaRegistro = VariablesLocales.FechaHoy;
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();
                oFondoFijo.FechaModificacion = VariablesLocales.FechaHoy;

                if (Existe == "s")
                {
                    oFondoFijo.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }

                if (oFondoFijo.TipoFondo == "102")
                {
                    pnlTipo.Enabled = false;
                }
                else
                {
                    pnlTipo.Enabled = true;
                }
            }
            else if (opcion == (Int32)EnumOpcionGrabar.InsertarSimple)
            {
                oFondoFijo.Persona = new Persona();
                oFondoFijo.Persona = oPersona;
                oFondoFijo.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                oFondoFijo.idLocal = VariablesLocales.SesionLocal.IdLocal;
                oFondoFijo.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;

                txtID.Text = Convert.ToString(oPersona.IdPersona);
                txtDoc.Text = oPersona.NroDocumento;
                txtNombre.Text = oPersona.Nombres;
                txtPat.Text = oPersona.ApePaterno;
                txtMat.Text = oPersona.ApeMaterno;
                txtDesFondo.Text = oFondoFijo.desFondo;
                cboIDComprobante.SelectedValue = Variables.Cero.ToString();
                cboIDComprobante_SelectionChangeCommitted(new Object(), new EventArgs());
                cboNumFile.SelectedValue = Variables.Cero.ToString();
                cboTipoFondo.SelectedValue = oFondoFijo.TipoFondo;
                rbCtas.Checked = true;

                txtUsuRegistra.Text = oFondoFijo.UsuarioRegistro;
                txtRegistro.Text = oFondoFijo.FechaRegistro.ToString();
                txtUsuModifica.Text = oFondoFijo.UsuarioModificacion;
                txtModifica.Text = oFondoFijo.FechaModificacion.ToString();

                if (oFondoFijo.TipoFondo == "102")
                {
                    pnlTipo.Enabled = false;
                }
                else
                {
                    pnlTipo.Enabled = true;
                }

                oFondoFijo.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }
            else
            {
                txtIdBanco.TextChanged -= txtIdBanco_TextChanged;

                oFondoFijo.Persona = oPersona;

                txtID.Text = Convert.ToString(oPersona.IdPersona);
                txtDoc.Text = oPersona.NroDocumento;
                txtNombre.Text = oPersona.Nombres;
                txtPat.Text = oPersona.ApePaterno;
                txtMat.Text = oPersona.ApeMaterno;
                
                txtDesCuenta.Text = oFondoFijo.desCuenta;
                txtDesFondo.Text = oFondoFijo.desFondo;
                txtRuc.Tag = oFondoFijo.idPersonaResponsable;
                txtRuc.Text = oFondoFijo.nroResponsable;
                txtDesResponsable.Text = oFondoFijo.desResponsable;
                txtCodCuenta.Text = oFondoFijo.codCuenta;
                cboIDComprobante.SelectedValue = oFondoFijo.idComprobante == null ? Variables.Cero.ToString() : oFondoFijo.idComprobante;
                cboIDComprobante_SelectionChangeCommitted(new Object(), new EventArgs());
                cboNumFile.SelectedValue = oFondoFijo.numFile == null ? Variables.Cero.ToString() : oFondoFijo.numFile.ToString();
                cboMoneda.SelectedValue = oFondoFijo.idMoneda.ToString();
                txtMontoAutorizado.Text = oFondoFijo.MontoAutorizado.ToString("N2");
                cboTipoFondo.SelectedValue = oFondoFijo.TipoFondo;

                txtIdBanco.Text = oFondoFijo.idPersonaBanco.ToString();
                txtNomBanco.Text = oFondoFijo.desBanco;
                cboTipoCuenta.SelectedValue = Convert.ToInt32(oFondoFijo.tipCuenta);
                cboMonedaBanco.SelectedValue = oFondoFijo.idMonedaCuenta.ToString();
                txtNumCuenta.Text = oFondoFijo.numCuenta;
                txtCuentaInter.Text = oFondoFijo.numInterbancaria;
                
                txtUsuRegistra.Text = oFondoFijo.UsuarioRegistro;
                txtRegistro.Text = oFondoFijo.FechaRegistro.ToString();
                txtUsuModifica.Text = oFondoFijo.UsuarioModificacion;
                txtModifica.Text = oFondoFijo.FechaModificacion.ToString();

                oFondoFijo.Opcion = (Int32)EnumOpcionGrabar.Actualizar;

                if (oFondoFijo.TipoFondo == "102")
                {
                    pnlTipo.Enabled = false;
                }
                else
                {
                    if (oFondoFijo.Tipo == "C")
                    {
                        rbCtas.Checked = true;
                    }
                    else if(oFondoFijo.Tipo == "V")
                    {
                        rbViaticos.Checked = true;
                    }
                }

                cboCuentas.SelectedValue = Convert.ToInt32(oFondoFijo.TipoCuentaLiq);

                txtIdBanco.TextChanged += txtIdBanco_TextChanged;
            }

            txtRuc.TextChanged += txtRuc_TextChanged;
            txtDesResponsable.TextChanged += txtDesResponsable_TextChanged;
            txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
            txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oFondoFijo != null)
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
                            oFondoFijo = AgenteTesoreria.Proxy.GrabarFondo(oFondoFijo,EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else if (opcion == (Int32)EnumOpcionGrabar.InsertarSimple)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oFondoFijo = AgenteTesoreria.Proxy.GrabarFondo(oFondoFijo, EnumOpcionGrabar.InsertarSimple);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oFondoFijo = AgenteTesoreria.Proxy.GrabarFondo(oFondoFijo, EnumOpcionGrabar.Actualizar);
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
            String Respuesta = ValidarEntidad<FondoFijoE>(oFondoFijo);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            if (String.IsNullOrEmpty(txtRuc.Tag.ToString()))
            {
                Global.MensajeFault("Tiene que colocar el Responsable.");
                return false;
            }

            if (String.IsNullOrEmpty(txtCodCuenta.Text))
            {
                Global.MensajeFault("Tiene que colocar la Cuenta Contable.");
                return false;
            }

            if (Convert.ToString(cboIDComprobante.SelectedValue) == "0")
            {
                Global.MensajeFault("Tiene que colocar la Diario");
                return false;
            }

            if (Convert.ToString(cboNumFile.SelectedValue) == "0")
            {
                Global.MensajeFault("Tiene que colocar el File");
                return false;
            }

            if (Convert.ToString(cboMoneda.SelectedValue) == "0")
            {
                Global.MensajeFault("Debe Seleccionar Una Moneda");
                return false;
            }

            if (Convert.ToDecimal(txtMontoAutorizado.Text) == 0)
            {
                Global.MensajeFault("Debe Ingresar Monto Autorizado");
                return false;
            }

            if (opcion != (Int32)EnumOpcionGrabar.Actualizar)
            {
                Int32 Resp = AgenteTesoreria.Proxy.FondoFijoPorTipoFondoResp(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, cboTipoFondo.SelectedValue.ToString(), Convert.ToInt32(txtRuc.Tag));

                if (Resp > 0)
                {
                    if (oFondoFijo.TipoFondo == "102")
                    {
                        Global.MensajeFault("El responsable ya tiene a cargo una Caja.");
                    }
                    else
                    {
                        Global.MensajeFault("El responsable ya tiene a cargo una Rendición.");
                    }

                    return false;
                } 
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void cboIDComprobante_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboIDComprobante.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles = new List<ComprobantesFileE>(((ComprobantesE)cboIDComprobante.SelectedItem).ListaComprobantesFiles)
                    {
                        new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Todos }
                    };

                    ComboHelper.RellenarCombos<ComprobantesFileE>(cboNumFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);
                    cboNumFile.SelectedValue = Variables.Cero.ToString();

                    if (cboIDComprobante.SelectedValue.ToString() == Variables.Cero.ToString())
                    {
                        cboNumFile.Enabled = false;
                    }
                    else
                    {
                        cboNumFile.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmFondoFijo_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
            txtCodCuenta.MaxLength = VariablesLocales.VersionPlanCuentasActual.Longitud;
        }

        private void btPersona_Click(object sender, EventArgs e)
        {
            FrmBusquedaPersona oFrm = new FrmBusquedaPersona();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
            {
                txtRuc.TextChanged -= txtRuc_TextChanged;
                txtDesResponsable.TextChanged -= txtDesResponsable_TextChanged;

                txtRuc.Tag = oFrm.oPersona.IdPersona;
                txtRuc.Text = oFrm.oPersona.RUC;
                txtDesResponsable.Text = oFrm.oPersona.RazonSocial;

                txtRuc.TextChanged += txtRuc_TextChanged;
                txtDesResponsable.TextChanged += txtDesResponsable_TextChanged;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBuscarCuentas oFrm = new frmBuscarCuentas(txtCodCuenta.Text.Trim());

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Cuentas != null)
            {
                txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;

                txtCodCuenta.Text = oFrm.Cuentas.codCuenta;
                txtDesCuenta.Text = oFrm.Cuentas.Descripcion;

                if (oFrm.Cuentas.idMoneda != null)
                {
                    cboMoneda.SelectedValue = oFrm.Cuentas.idMoneda.ToString();
                    txtMontoAutorizado.Focus();
                }

                txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
            }
        }

        private void btReniec_Click(object sender, EventArgs e)
        {
            frmBuscarDni oFrm = new frmBuscarDni();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Informacion != null)
            {
                StringBuilder NombreCompleto = new StringBuilder();

                txtDoc.Text = oFrm.DNI;
                txtNombre.Text = oFrm.Informacion.Nombres;
                txtPat.Text = oFrm.Informacion.ApePaterno;
                txtMat.Text = oFrm.Informacion.ApeMaterno;
                
                NombreCompleto.Append(oFrm.Informacion.ApePaterno);
                NombreCompleto.Append(" ");
                NombreCompleto.Append(oFrm.Informacion.ApeMaterno);
                NombreCompleto.Append(" ");
                NombreCompleto.Append(oFrm.Informacion.Nombres);

                txtDesFondo.Text = NombreCompleto.ToString();
            }
        }

        private void txtMontoAutorizado_Enter(object sender, EventArgs e)
        {
            txtMontoAutorizado.SeleccinarTodo();
        }

        private void txtMontoAutorizado_Leave(object sender, EventArgs e)
        {
            txtMontoAutorizado.Text = Global.FormatoDecimal(txtMontoAutorizado.Text.Trim());
        }

        private void txtMontoAutorizado_MouseClick(object sender, MouseEventArgs e)
        {
            txtMontoAutorizado.SeleccinarTodo();
        }

        private void btCuenta_Click(object sender, EventArgs e)
        {
            frmBuscarBancos oFrm = new frmBuscarBancos();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oBancos != null)
            {
                txtIdBanco.TextChanged -= txtIdBanco_TextChanged;
                txtIdBanco.Text = Convert.ToString(oFrm.oBancos.idPersona);
                txtNomBanco.Text = oFrm.oBancos.RazonSocial;
                txtIdBanco.TextChanged += txtIdBanco_TextChanged;
            }
        }

        private void txtIdBanco_TextChanged(object sender, EventArgs e)
        {
            txtNomBanco.Text = String.Empty;
        }

        private void cboNumFile_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboNumFile.SelectedValue != null)
                {
                    cboMoneda.SelectedValue = ((ComprobantesFileE)cboNumFile.SelectedItem).idMoneda.ToString();
                    cboMonedaBanco.SelectedValue = ((ComprobantesFileE)cboNumFile.SelectedItem).idMoneda.ToString();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = String.Empty;
            txtDesResponsable.Text = string.Empty;
        }

        private void txtDesResponsable_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = String.Empty;
            txtRuc.Text = String.Empty;
        }

        private void txtRuc_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && string.IsNullOrEmpty(txtDesResponsable.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtDesResponsable.TextChanged -= txtDesResponsable_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRuc.Tag = oFrm.oPersona.IdPersona.ToString();
                            txtDesResponsable.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtDesResponsable.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRuc.Tag = oListaPersonas[0].IdPersona.ToString();
                        txtDesResponsable.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtRuc.Tag = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtDesResponsable.Text = String.Empty;
                        txtRuc.Focus();
                        return;
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtDesResponsable.TextChanged += txtDesResponsable_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtDesResponsable_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtDesResponsable.Text.Trim()) && string.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtDesResponsable.TextChanged -= txtDesResponsable_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtDesResponsable.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtDesResponsable.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            //.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRuc.Tag = oListaPersonas[0].IdPersona.ToString();
                        txtDesResponsable.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtRuc.Tag = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtDesResponsable.Text = String.Empty;

                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtDesResponsable.TextChanged += txtDesResponsable_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtCodCuenta_TextChanged(object sender, EventArgs e)
        {
            txtDesCuenta.Text = string.Empty;
        }

        private void txtDesCuenta_TextChanged(object sender, EventArgs e)
        {
            txtCodCuenta.Text = string.Empty;
        }

        private void txtCodCuenta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodCuenta.Text.Trim()) && string.IsNullOrEmpty(txtDesCuenta.Text.Trim()))
                {
                    txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCodCuenta.Text.Trim(),//cboTipoFondo.SelectedValue.ToString(),
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
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
                        txtCodCuenta.Text = oListaCuentas[0].codCuenta;
                        txtDesCuenta.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCodCuenta.Text = string.Empty;
                        txtDesCuenta.Text = string.Empty;
                    }

                    txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuenta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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
                        txtCodCuenta.Text = oListaCuentas[0].codCuenta;
                        txtDesCuenta.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCodCuenta.Text = string.Empty;
                        txtDesCuenta.Text = string.Empty;
                    }

                    txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
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
