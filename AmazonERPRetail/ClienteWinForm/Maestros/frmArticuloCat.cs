using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Generales;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using ClienteWinForm.Maestros.Busqueda;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Maestros
{
    public partial class frmArticuloCat : FrmMantenimientoBase
    {

        #region Constructores

        public frmArticuloCat()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.AjustarResolucion(this);
        }

        //Edición
        public frmArticuloCat(ArticuloCatE Articulo, List<ArticuloEstrucE> oListaEstructuraTemp, List<ParTabla> oListaTipoArticulo_)
            : this()
        {
            oArticuloCat = Articulo;
            oListaTipoArticulo = oListaTipoArticulo_;
            Niveles(oListaEstructuraTemp);
        }

        //Nuevo
        public frmArticuloCat(Int32 TipoArticuloTmp, List<ArticuloEstrucE> oListaEstructuraTemp, List<ParTabla> oListaTipoArticulo_)
            : this()
        {
            TipoArticulo = TipoArticuloTmp;
            oListaTipoArticulo = oListaTipoArticulo_;
            Niveles(oListaEstructuraTemp);
        }

        #endregion 

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        ArticuloCatE oArticuloCat = null;
        List<ArticuloEstrucE> oListaEstructura = null;
        List<ParTabla> oListaTipoArticulo = null;
        Int32 TipoArticulo = 0;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        private void LlenarCombos()
        {
            cboIndNivel.DataSource = Global.CargarSN();
            cboIndNivel.ValueMember = "id";
            cboIndNivel.DisplayMember = "Nombre";

            ComboHelper.RellenarCombos<ParTabla>(cboTipoArticulo, (from x in oListaTipoArticulo orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
            //ComboHelper.RellenarCombos<ParTabla>(cboArt2, (from x in oListaTipoArticulo orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
            oListaTipoArticulo = null;
        }

        private void GuardarDatos()
        {
            oArticuloCat.idTipoArticulo = Convert.ToInt32(cboTipoArticulo.SelectedValue);
            oArticuloCat.nombre_categoria = txtNom.Text.Trim();
            oArticuloCat.numNivel = Convert.ToInt32(NumNivel.Value);
            oArticuloCat.indUltimoNivel = cboIndNivel.SelectedValue.ToString();
            oArticuloCat.CodCategoriaSup = txtCatSuperior.Text.Trim();
            oArticuloCat.codCategoriaAsoc = string.Empty;

            if (String.IsNullOrEmpty(txtCatSuperior.Text.Trim()))
            {
                oArticuloCat.CodCategoria = txtCodCategoria.Text.Trim();
            }
            else
            {
                oArticuloCat.CodCategoria = txtCatSuperior.Text.Trim() + txtCodCategoria.Text.Trim();
            }

            oArticuloCat.indCuenta = chkIndCuenta.Checked;

            if (chkIndCuenta.Checked)
            {
                oArticuloCat.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                oArticuloCat.codCuentaAdm = txtCodCuenta.Text.Trim();
                oArticuloCat.codCuentaVta = txtCuentavta.Text.Trim();
                oArticuloCat.codCuentaPro = txtCuentapro.Text.Trim();
                oArticuloCat.codCuentaConsumo = txtConsumo.Text.Trim();
                oArticuloCat.codCuentaVenta = txtVenta.Text.Trim();
                oArticuloCat.codCuentaVenta12 = txtProvVenta12.Text.Trim();
                oArticuloCat.codCuentaCompra = txtCuentaCom.Text.Trim();
                oArticuloCat.codCuentaPorRecibir = txtCuentaRec.Text.Trim();
            }
            else
            {
                oArticuloCat.numVerPlanCuentas = String.Empty;
                oArticuloCat.codCuentaAdm = String.Empty;
                oArticuloCat.codCuentaVta = String.Empty;
                oArticuloCat.codCuentaPro = String.Empty;
                oArticuloCat.codCuentaConsumo = String.Empty;
                oArticuloCat.codCuentaVenta = String.Empty;
                oArticuloCat.codCuentaVenta12 = String.Empty;
                oArticuloCat.codCuentaCompra = String.Empty;
            }

            oArticuloCat.idTipoArticuloAsoc = null;
            //oArticuloCat.codCategoriaAsoc = null;

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oArticuloCat.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oArticuloCat.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        private void BuscarGrupoOpcion()
        {
            FrmArticuloCatOpcionArbol frm = new FrmArticuloCatOpcionArbol(TipoArticulo, Convert.ToInt32(NumNivel.Value), "CAT");

            if (frm.ShowDialog() == DialogResult.OK && frm.ArticuloCat != null)
            {
                txtCatSuperior.Text = frm.ArticuloCat.CodCategoria.Trim();
            }
            else
            {
                txtCatSuperior.Text = String.Empty;
            }
        }

        private void Niveles(List<ArticuloEstrucE> oLista)
        {
            oListaEstructura = new List<ArticuloEstrucE>(oLista);
            NumNivel.Minimum = oListaEstructura.Min(c => c.numNivel);
            NumNivel.Maximum = oListaEstructura.Max(c => c.numNivel);
        }

        private void LongitudCodigo(Int32 Nivel)
        {
            ArticuloEstrucE oEstructuraActual = oListaEstructura.Where(n => n.numNivel == Nivel && n.idTipoArticulo == Convert.ToInt32(cboTipoArticulo.SelectedValue)).Single();
            //Int32 Registro = oListaEstructura.FindIndex(n => n.numNivel == Nivel);
            
            if (Nivel == 1)
            {
                txtCodCategoria.MaxLength = Convert.ToInt32(oEstructuraActual.numLongitud);    
            }
            else
            {
                //ArticuloEstrucE oEstructura2 = oListaEstructura.Skip(Registro - 1).Take(1).FirstOrDefault();

                //if (Convert.ToInt32(oEstructuraActual.numLongitud) == 1 && Convert.ToInt32(oEstructura2.numLongitud) == 1)
                //{
                //    txtCodCategoria.MaxLength = 1;
                //}
                //else
                //{
                txtCodCategoria.MaxLength = Convert.ToInt32(oEstructuraActual.numLongitud); //- Convert.ToInt32(oEstructura2.numLongitud);
                //}

                //oEstructura2 = null;
            }

            if (txtCodCategoria.TextLength > Convert.ToInt32(oEstructuraActual.numLongitud))
            {
                txtCodCategoria.Text = txtCodCategoria.Text.Substring(0, Convert.ToInt32(oEstructuraActual.numLongitud));
            }

            cboIndNivel.SelectedValue = oEstructuraActual.indUltimoNivel;

            //if (!String.IsNullOrEmpty(txtCodCategoria.Text.Trim()))
            //{
            //    if (txtCodCategoria.MaxLength < oEstructuraActual.numLongitud)
            //    {
            //        txtCodCategoria.Text = txtCodCategoria.Text.Substring(0, txtCodCategoria.MaxLength);
            //    }
            //}
            //else
            //{
            //    txtCodCategoria.Text = String.Empty;
            //}

            oEstructuraActual = null;
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oArticuloCat == null)
            {
                oArticuloCat = new ArticuloCatE()
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                };

                cboTipoArticulo.SelectedValue = TipoArticulo;
                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
                NumNivel_ValueChanged(null, null);
            }
            else
            {
                cboTipoArticulo.SelectedValue = Convert.ToInt32(oArticuloCat.idTipoArticulo);
                txtCatSuperior.Text = oArticuloCat.CodCategoriaSup.Trim();
                //cboArt2.SelectedValue =  oArticuloCat.idTipoArticuloAsoc;
                //cboArt2_SelectionChangeCommitted(new object(), new EventArgs());
                //cboCat.SelectedValue = oArticuloCat.codCategoriaAsoc;
                NumNivel.Value = Convert.ToInt32(oArticuloCat.numNivel);

                if (Convert.ToInt32(oArticuloCat.numNivel) == 1)
                {
                    NumNivel_ValueChanged(null, null);
                }

                if (oArticuloCat.numNivel == 1)
                {
                    txtCodCategoria.Text = oArticuloCat.CodCategoria;
                }
                else
                {
                    txtCodCategoria.Text = oArticuloCat.CodCategoria.Replace(txtCatSuperior.Text.Trim(), "");
                    //txtCodCategoria.Text = Global.Reemplazar(oArticuloCat.CodCategoria, 2, 2, "");//oArticuloCat.CodCategoria.Replace(txtCatSuperior.Text.Trim(), String.Empty);
                }

                oArticuloCat.CodCategoriaAnte = oArticuloCat.CodCategoria; //Para poder actualizar una de las llaves... siempre y cuando no este relacionada.
                txtNom.Text = oArticuloCat.nombre_categoria;
                cboIndNivel.SelectedValue = oArticuloCat.indUltimoNivel.ToString();

                txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;
                txtCuentavta.TextChanged -= txtCuentavta_TextChanged;
                txtDesCuentavta.TextChanged -= txtDesCuentavta_TextChanged;
                txtCuentapro.TextChanged -= txtCuentapro_TextChanged;
                txtDesCuentapro.TextChanged -= txtDesCuentapro_TextChanged;
                txtConsumo.TextChanged -= txtConsumo_TextChanged;
                txtDesConsumo.TextChanged -= txtDesConsumo_TextChanged;
                txtVenta.TextChanged -= txtVenta_TextChanged;
                txtDesVenta.TextChanged -= txtDesVenta_TextChanged;
                txtProvVenta12.TextChanged -= txtProvVenta12_TextChanged;
                txtDesProvVenta12.TextChanged -= txtDesProvVenta12_TextChanged;
                txtCuentaCom.TextChanged -= txtCuentaCom_TextChanged;
                txtDesCuentaCom.TextChanged -= txtDesCuentaCom_TextChanged;
                txtCuentaRec.TextChanged -= txtCuentaRec_TextChanged;
                txtDesRec.TextChanged -= txtDesRec_TextChanged;

                chkIndCuenta.Checked = oArticuloCat.indCuenta;
                txtCodCuenta.Text = oArticuloCat.codCuentaAdm;
                txtCuentavta.Text = oArticuloCat.codCuentaVta;
                txtCuentapro.Text = oArticuloCat.codCuentaPro;
                txtConsumo.Text = oArticuloCat.codCuentaConsumo;
                txtVenta.Text = oArticuloCat.codCuentaVenta;
                txtProvVenta12.Text = oArticuloCat.codCuentaVenta12;

                txtDesCuenta.Text = oArticuloCat.desCuenta;
                txtDesCuentavta.Text = oArticuloCat.desCuenta2;
                txtDesCuentapro.Text = oArticuloCat.desCuenta3;
                txtDesConsumo.Text = oArticuloCat.desCuenta4;
                txtDesVenta.Text = oArticuloCat.desCuenta5;
                txtDesProvVenta12.Text = oArticuloCat.desCuenta12;

                txtCuentaCom.Text = oArticuloCat.codCuentaCompra;
                txtDesCuentaCom.Text = oArticuloCat.desCuenta6;
                txtCuentaRec.Text = oArticuloCat.codCuentaPorRecibir;
                txtDesRec.Text = oArticuloCat.desCuenta7;

                txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                txtCuentavta.TextChanged += txtCuentavta_TextChanged;
                txtDesCuentavta.TextChanged += txtDesCuentavta_TextChanged;
                txtCuentapro.TextChanged += txtCuentapro_TextChanged;
                txtDesCuentapro.TextChanged += txtDesCuentapro_TextChanged;
                txtConsumo.TextChanged += txtConsumo_TextChanged;
                txtDesConsumo.TextChanged += txtDesConsumo_TextChanged;
                txtVenta.TextChanged += txtVenta_TextChanged;
                txtDesVenta.TextChanged += txtDesVenta_TextChanged;

                txtProvVenta12.TextChanged += txtProvVenta12_TextChanged;
                txtDesProvVenta12.TextChanged += txtDesProvVenta12_TextChanged;

                txtCuentaCom.TextChanged += txtCuentaCom_TextChanged;
                txtDesCuentaCom.TextChanged += txtDesCuentaCom_TextChanged;
                txtCuentaRec.TextChanged += txtCuentaRec_TextChanged;
                txtDesRec.TextChanged += txtDesRec_TextChanged;

                txtUsuRegistra.Text = oArticuloCat.UsuarioRegistro;
                txtFechaRegistro.Text = oArticuloCat.fechaRegistro.ToString();
                txtUsuModifica.Text = oArticuloCat.UsuarioModificacion;
                txtModifica.Text = oArticuloCat.fechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oArticuloCat != null)
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
                            oArticuloCat = AgenteMaestro.Proxy.GrabarArticuloCat(oArticuloCat, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oArticuloCat = AgenteMaestro.Proxy.GrabarArticuloCat(oArticuloCat, EnumOpcionGrabar.Actualizar);
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
            String Respuesta = ValidarEntidad<ArticuloCatE>(oArticuloCat);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            if (NumNivel.Value > 1)
            {
                if (String.IsNullOrEmpty(txtCatSuperior.Text.Trim()))
                {
                    Global.MensajeComunicacion("Solo el Nivel 1 no puede tener Código Superior.");
                    return false;
                }
            }

            if (String.IsNullOrEmpty(txtCodCategoria.Text.Trim()))
            {
                Global.MensajeComunicacion("Debe colocar un código de articulo.");
                txtCodCategoria.Focus();
                return false;
            }

            //if (Convert.ToInt32(cboArt2.SelectedValue) != 0)
            //{
            //    if (cboCat.SelectedValue == null)
            //    {
            //        Global.MensajeComunicacion("Si ha escogido un Tipo de Articulo para asociar, deberia esocger una categoria.");
            //        cboCat.Focus();
            //        return false;
            //    } 
            //}

            return base.ValidarGrabacion();
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void ArticuloCategoria_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                LlenarCombos();
                Nuevo();
                BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
                BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
                //txtCodCuenta.MaxLength = (Int32)Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                //txtCuentavta.MaxLength = (Int32)Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                //txtCuentapro.MaxLength = (Int32)Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                //txtConsumo.MaxLength = (Int32)Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                //txtVenta.MaxLength = (Int32)Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btBuscarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (NumNivel.Value > 1)
                {
                    TipoArticulo = Convert.ToInt32(cboTipoArticulo.SelectedValue.ToString());
                    BuscarGrupoOpcion(); 
                }
                else
                {
                    Global.MensajeComunicacion("La estructura esta en Nivel 1. No tiene la necesidad que haya un Código Superior.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboIndNivel_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void NumNivel_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LongitudCodigo(Convert.ToInt32(NumNivel.Value));
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void chkIndCuenta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIndCuenta.Checked)
            {
                txtCodCuenta.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesCuenta.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtCodCuenta.Focus();

                txtCuentavta.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesCuentavta.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);

                txtCuentapro.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesCuentapro.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);

                txtConsumo.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesConsumo.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);

                txtVenta.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesVenta.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);

                txtCuentaCom.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesCuentaCom.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);

                txtCuentaRec.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesRec.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);

                txtProvVenta12.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesProvVenta12.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                txtCodCuenta.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesCuenta.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");

                txtCuentavta.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesCuentavta.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");

                txtCuentapro.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesCuentapro.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");

                txtConsumo.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesConsumo.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");

                txtVenta.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesVenta.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");

                txtCuentaCom.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesCuentaCom.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");

                txtCuentaRec.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesRec.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");

                txtProvVenta12.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesProvVenta12.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");

            }
        }

        private void txtCodCuenta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCodCuenta.Text.Trim()) && String.IsNullOrEmpty(txtDesCuenta.Text.Trim()))
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
                        txtCodCuenta.Text = String.Empty;
                        txtDesCuenta.Text = String.Empty;
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
                if (String.IsNullOrEmpty(txtCodCuenta.Text.Trim()) && !String.IsNullOrEmpty(txtDesCuenta.Text.Trim()))
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
                        txtCodCuenta.Text = String.Empty;
                        txtDesCuenta.Text = String.Empty;
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

        private void txtCodCuenta_TextChanged(object sender, EventArgs e)
        {
            txtDesCuenta.Text = String.Empty;
        }

        private void txtDesCuenta_TextChanged(object sender, EventArgs e)
        {
            txtCodCuenta.Text = String.Empty;
        }

        private void txtCuentavta_TextChanged(object sender, EventArgs e)
        {
            txtDesCuentavta.Text = String.Empty;
        }

        private void txtCuentavta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCuentavta.Text.Trim()) && String.IsNullOrEmpty(txtDesCuentavta.Text.Trim()))
                {
                    txtCuentavta.TextChanged -= txtCuentavta_TextChanged;
                    txtDesCuentavta.TextChanged -= txtDesCuentavta_TextChanged;

                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCuentavta.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCuentavta.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentavta.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCuentavta.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCuentavta.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentavta.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCuentavta.Text = String.Empty;
                        txtDesCuentavta.Text = String.Empty;
                    }

                    txtCuentavta.TextChanged += txtCuentavta_TextChanged;
                    txtDesCuentavta.TextChanged += txtDesCuentavta_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuentavta_TextChanged(object sender, EventArgs e)
        {
            txtCuentavta.Text = String.Empty;
        }

        private void txtDesCuentavta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCuentavta.Text.Trim()) && !String.IsNullOrEmpty(txtDesCuentavta.Text.Trim()))
                {
                    txtCuentavta.TextChanged -= txtCuentavta_TextChanged;
                    txtDesCuentavta.TextChanged -= txtDesCuentavta_TextChanged;

                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCuentavta.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCuentavta.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentavta.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCuentavta.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCuentavta.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentavta.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCuentavta.Text = String.Empty;
                        txtDesCuentavta.Text = String.Empty;
                    }

                    txtCuentavta.TextChanged += txtCuentavta_TextChanged;
                    txtDesCuentavta.TextChanged += txtDesCuentavta_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCuentapro_TextChanged(object sender, EventArgs e)
        {
            txtDesCuentapro.Text = String.Empty;
        }

        private void txtCuentapro_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCuentapro.Text.Trim()) && String.IsNullOrEmpty(txtDesCuentapro.Text.Trim()))
                {
                    txtCuentapro.TextChanged -= txtCuentapro_TextChanged;
                    txtDesCuentapro.TextChanged -= txtDesCuentapro_TextChanged;

                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCuentapro.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCuentapro.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentapro.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCuentapro.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCuentapro.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentapro.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCuentapro.Text = String.Empty;
                        txtDesCuentapro.Text = String.Empty;
                    }

                    txtCuentapro.TextChanged += txtCuentapro_TextChanged;
                    txtDesCuentapro.TextChanged += txtDesCuentapro_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuentapro_TextChanged(object sender, EventArgs e)
        {
            txtCuentapro.Text = String.Empty;
        }

        private void txtDesCuentapro_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCuentapro.Text.Trim()) && !String.IsNullOrEmpty(txtDesCuentapro.Text.Trim()))
                {
                    txtCuentapro.TextChanged -= txtCuentapro_TextChanged;
                    txtDesCuentapro.TextChanged -= txtDesCuentapro_TextChanged;

                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCuentapro.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCuentapro.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentapro.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCuentapro.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCuentapro.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentapro.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCuentapro.Text = String.Empty;
                        txtDesCuentapro.Text = String.Empty;
                    }

                    txtCuentapro.TextChanged += txtCuentapro_TextChanged;
                    txtDesCuentapro.TextChanged += txtDesCuentapro_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtConsumo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtConsumo.Text.Trim()) && String.IsNullOrEmpty(txtDesConsumo.Text.Trim()))
                {
                    txtConsumo.TextChanged -= txtConsumo_TextChanged;
                    txtDesConsumo.TextChanged -= txtDesConsumo_TextChanged;

                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtConsumo.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtConsumo.Text = oFrm.oCuenta.codCuenta;
                            txtDesConsumo.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesConsumo.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtConsumo.Text = oListaCuentas[0].codCuenta;
                        txtDesConsumo.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtConsumo.Text = String.Empty;
                        txtDesConsumo.Text = String.Empty;
                    }

                    txtConsumo.TextChanged += txtConsumo_TextChanged;
                    txtDesConsumo.TextChanged += txtDesConsumo_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesConsumo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtConsumo.Text.Trim()) && !String.IsNullOrEmpty(txtDesConsumo.Text.Trim()))
                {
                    txtConsumo.TextChanged -= txtConsumo_TextChanged;
                    txtDesConsumo.TextChanged -= txtDesConsumo_TextChanged;

                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesConsumo.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtConsumo.Text = oFrm.oCuenta.codCuenta;
                            txtDesConsumo.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtConsumo.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtConsumo.Text = oListaCuentas[0].codCuenta;
                        txtDesConsumo.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtConsumo.Text = String.Empty;
                        txtDesConsumo.Text = String.Empty;
                    }

                    txtConsumo.TextChanged += txtConsumo_TextChanged;
                    txtDesConsumo.TextChanged += txtDesConsumo_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtConsumo_TextChanged(object sender, EventArgs e)
        {
            txtDesConsumo.Text = String.Empty;
        }

        private void txtDesConsumo_TextChanged(object sender, EventArgs e)
        {
            txtConsumo.Text = String.Empty;
        }

        private void txtVenta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtVenta.Text.Trim()) && String.IsNullOrEmpty(txtDesVenta.Text.Trim()))
                {
                    txtVenta.TextChanged -= txtVenta_TextChanged;
                    txtDesVenta.TextChanged -= txtDesVenta_TextChanged;

                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtVenta.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtVenta.Text = oFrm.oCuenta.codCuenta;
                            txtDesVenta.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesVenta.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtVenta.Text = oListaCuentas[0].codCuenta;
                        txtDesVenta.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtVenta.Text = String.Empty;
                        txtDesVenta.Text = String.Empty;
                    }

                    txtVenta.TextChanged += txtVenta_TextChanged;
                    txtDesVenta.TextChanged += txtDesVenta_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesVenta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtVenta.Text.Trim()) && !String.IsNullOrEmpty(txtDesVenta.Text.Trim()))
                {
                    txtVenta.TextChanged -= txtVenta_TextChanged;
                    txtDesVenta.TextChanged -= txtDesVenta_TextChanged;

                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesVenta.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtVenta.Text = oFrm.oCuenta.codCuenta;
                            txtDesVenta.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtVenta.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtVenta.Text = oListaCuentas[0].codCuenta;
                        txtDesVenta.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtVenta.Text = String.Empty;
                        txtDesVenta.Text = String.Empty;
                    }

                    txtVenta.TextChanged += txtVenta_TextChanged;
                    txtDesVenta.TextChanged += txtDesVenta_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtVenta_TextChanged(object sender, EventArgs e)
        {
            txtDesVenta.Text = String.Empty;
        }

        private void txtDesVenta_TextChanged(object sender, EventArgs e)
        {
            txtVenta.Text = String.Empty;
        }

        private void txtCuentaCom_TextChanged(object sender, EventArgs e)
        {
            txtDesCuentaCom.Text = String.Empty;
        }

        private void txtDesCuentaCom_TextChanged(object sender, EventArgs e)
        {
            txtCuentaCom.Text = String.Empty;
        }

        private void txtCuentaCom_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCuentaCom.Text.Trim()) && String.IsNullOrEmpty(txtDesCuentaCom.Text.Trim()))
                {
                    txtCuentaCom.TextChanged -= txtCuentaCom_TextChanged;
                    txtDesCuentaCom.TextChanged -= txtDesCuentaCom_TextChanged;

                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCuentaCom.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCuentaCom.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentaCom.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCuentaCom.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCuentaCom.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentaCom.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCuentaCom.Text = String.Empty;
                        txtDesCuentaCom.Text = String.Empty;
                    }

                    txtCuentaCom.TextChanged += txtCuentaCom_TextChanged;
                    txtDesCuentaCom.TextChanged += txtDesCuentaCom_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuentaCom_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCuentaCom.Text.Trim()) && !String.IsNullOrEmpty(txtDesCuentaCom.Text.Trim()))
                {
                    txtCuentaCom.TextChanged -= txtCuentaCom_TextChanged;
                    txtDesCuentaCom.TextChanged -= txtDesCuentaCom_TextChanged;

                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCuentaCom.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCuentaCom.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentaCom.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCuentaCom.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCuentaCom.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentaCom.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCuentaCom.Text = String.Empty;
                        txtDesCuentaCom.Text = String.Empty;
                    }

                    txtCuentaCom.TextChanged += txtCuentaCom_TextChanged;
                    txtDesCuentaCom.TextChanged += txtDesCuentaCom_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCuentaRec_TextChanged(object sender, EventArgs e)
        {
            txtDesRec.Text = String.Empty;
        }

        private void txtDesRec_TextChanged(object sender, EventArgs e)
        {
            txtCuentaRec.Text = String.Empty;
        }

        private void txtCuentaRec_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCuentaRec.Text.Trim()) && String.IsNullOrEmpty(txtDesRec.Text.Trim()))
                {
                    txtCuentaRec.TextChanged -= txtCuentaRec_TextChanged;
                    txtDesRec.TextChanged -= txtDesRec_TextChanged;

                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCuentaRec.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCuentaRec.Text = oFrm.oCuenta.codCuenta;
                            txtDesRec.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesRec.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCuentaRec.Text = oListaCuentas[0].codCuenta;
                        txtDesRec.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCuentaRec.Text = String.Empty;
                        txtDesRec.Text = String.Empty;
                    }

                    txtCuentaRec.TextChanged += txtCuentaRec_TextChanged;
                    txtDesRec.TextChanged += txtDesRec_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesRec_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCuentaRec.Text.Trim()) && !String.IsNullOrEmpty(txtDesRec.Text.Trim()))
                {
                    txtCuentaRec.TextChanged -= txtCuentaRec_TextChanged;
                    txtDesRec.TextChanged -= txtDesRec_TextChanged;

                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesRec.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCuentaRec.Text = oFrm.oCuenta.codCuenta;
                            txtDesRec.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCuentaRec.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCuentaRec.Text = oListaCuentas[0].codCuenta;
                        txtDesRec.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCuentaRec.Text = String.Empty;
                        txtDesRec.Text = String.Empty;
                    }

                    txtCuentaRec.TextChanged += txtCuentaRec_TextChanged;
                    txtDesRec.TextChanged += txtDesRec_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtProvVenta12_TextChanged(object sender, EventArgs e)
        {
            txtDesProvVenta12.Text = String.Empty;
        }

        private void txtDesProvVenta12_TextChanged(object sender, EventArgs e)
        {
            txtProvVenta12.Text = String.Empty;
        }

        private void txtProvVenta12_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtProvVenta12.Text.Trim()) && String.IsNullOrEmpty(txtDesProvVenta12.Text.Trim()))
                {
                    txtProvVenta12.TextChanged -= txtProvVenta12_TextChanged;
                    txtDesProvVenta12.TextChanged -= txtDesProvVenta12_TextChanged;

                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtProvVenta12.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtProvVenta12.Text = oFrm.oCuenta.codCuenta;
                            txtDesProvVenta12.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesProvVenta12.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtProvVenta12.Text = oListaCuentas[0].codCuenta;
                        txtDesProvVenta12.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtProvVenta12.Text = String.Empty;
                        txtDesProvVenta12.Text = String.Empty;
                    }

                    txtProvVenta12.TextChanged += txtProvVenta12_TextChanged;
                    txtDesProvVenta12.TextChanged += txtDesProvVenta12_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesProvVenta12_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtProvVenta12.Text.Trim()) && !String.IsNullOrEmpty(txtDesProvVenta12.Text.Trim()))
                {
                    txtProvVenta12.TextChanged -= txtProvVenta12_TextChanged;
                    txtDesProvVenta12.TextChanged -= txtDesProvVenta12_TextChanged;

                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesProvVenta12.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtProvVenta12.Text = oFrm.oCuenta.codCuenta;
                            txtDesProvVenta12.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtProvVenta12.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtProvVenta12.Text = oListaCuentas[0].codCuenta;
                        txtDesProvVenta12.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtProvVenta12.Text = String.Empty;
                        txtDesProvVenta12.Text = String.Empty;
                    }

                    txtProvVenta12.TextChanged += txtProvVenta12_TextChanged;
                    txtDesProvVenta12.TextChanged += txtDesProvVenta12_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Eventos

    }
}
