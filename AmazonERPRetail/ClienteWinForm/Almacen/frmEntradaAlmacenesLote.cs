using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Almacen
{
    public partial class frmEntradaAlmacenesLote : frmResponseBase
    {

        #region Constructores

        public frmEntradaAlmacenesLote()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
        }

        //Conversiones
        public frmEntradaAlmacenesLote(Int32 idEmpresa_, String Lote_, Int32 IdAlmacen_)
           : this()
        {
            Lote = Lote_;
            idAlmacen = IdAlmacen_;
            oLote = AgenteAlmacen.Proxy.ObtenerLote(idEmpresa_, Lote, idAlmacen);
            GI = "S";
        }

        //Ingresos - Cuando el Lote es null
        public frmEntradaAlmacenesLote(MovimientoAlmacenE oMovimiento_, Int32 Almacen)
           : this()
        {
            oMovimiento = oMovimiento_;
            idAlmacen = Almacen;
        }

        //Ingresos - Cuando hay Lote
        public frmEntradaAlmacenesLote(MovimientoAlmacenE oMovimiento_, LoteE oLote_, Int32 Almacen)
            : this()
        {
            oMovimiento = oMovimiento_;
            oLote = oLote_;
            idAlmacen = Almacen;
        }

        #endregion

        #region Variables
      
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        public LoteE oLote = null;
        MovimientoAlmacenE oMovimiento = new MovimientoAlmacenE();
        Int32 idAlmacen = 0;
        String Lote = String.Empty;
        String GI = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        private void LlenarCombos()
        {
            //Paises
            List<PaisesE> ListarPaises = AgenteGeneral.Proxy.ListarPaises();
            ListarPaises.Add(new PaisesE() { idPais = Variables.Cero, Nombre = Variables.Seleccione });

            ComboHelper.LlenarCombos<PaisesE>(cboPaisOrigen, (from x in ListarPaises orderby x.idPais select x).ToList(), "idPais", "Nombre");
            ComboHelper.LlenarCombos<PaisesE>(cboPaisProcedencia, (from x in ListarPaises orderby x.idPais select x).ToList(), "idPais", "Nombre");

            ListarPaises = null;
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
                        fecInscripcion = null,
                        fecInicioActividad = null,
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

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oLote != null)
            {
                //El lote de indusoft
                txtLote.Text = oLote.Lote;
                //Lote Proveedor
                txtLoteProveedor.Text = oLote.LoteProveedor;
                chbindfecProceso.Checked = oLote.indfecProceso;

                if (GI == "S")
                {
                    dtpFecProceso.Value = oLote.fecProceso;
                }
                else
                {
                    if (chbindfecProceso.Checked)
                    {
                        dtpFecProceso.Value = oLote.fecProceso;
                    }
                    else
                    {
                        dtpFecProceso.Value = Convert.ToDateTime(oMovimiento.fecProceso.Substring(oMovimiento.fecProceso.Length - 2, 2) + "/" + oMovimiento.fecProceso.Substring(4, 2) + "/" + oMovimiento.fecProceso.Substring(0, 4));
                    }
                }
                
                txtSiglaEmpresa.Text = oLote.SiglaLoteAlmacen;

                //.............. Proveedor ..............//
                chbindPersona.Checked = oLote.indPersona;
                txtIdProveedor.Text = Convert.ToString(oLote.idPersona);

                txtRuc.TextChanged -= txtRuc_TextChanged;
                txtproveedor.TextChanged -= txtproveedor_TextChanged;
                txtproveedor.Text = oLote.RazonSocial;
                txtRuc.Text = oLote.ruc;
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtproveedor.TextChanged += txtproveedor_TextChanged;

                cboPaisOrigen.SelectedValue = oLote.idPaisOrigen == null ? 0 : oLote.idPaisOrigen;
                cboPaisProcedencia.SelectedValue = oLote.idPaisProcedencia == null ? 0 : oLote.idPaisProcedencia;
                //txtBatch.Text = oLote.Batch;
                //txtGerminacion.Text = oLote.PorcentajeGerminacion.ToString();

                if (oLote.fecPrueba != null)
                {
                    dtpFecPrueba.Value = Convert.ToDateTime(oLote.fecPrueba);
                }
                else
                {
                    dtpFecPrueba.Checked = false;
                }

                txtPesoUnitario.Text = oLote.PesoUnitario.ToString();
                //txtnomComercial.Text = oLote.nomComercial;
                //cbocodColor.SelectedValue = oLote.codColor;
                //txtHibOp.Text = oLote.HibOp;
                //txtOtros.Text = oLote.Otros;
                //txtCaCm.Text = oLote.CaCm;
                //txtPatron.Text = oLote.Patron;
                txtObservacion.Text = oLote.Observacion;
                //txtEntregadoPor.Text = oLote.EntregadoPor;
                txtLoteAlmacen.Text = oLote.LoteAlmacen;

                txtUsuRegistro.Text = String.IsNullOrWhiteSpace(oLote.UsuarioRegistro) ? VariablesLocales.SesionUsuario.Credencial : oLote.UsuarioRegistro;
                txtFechaRegistro.Text = String.IsNullOrWhiteSpace(oLote.UsuarioRegistro) ? VariablesLocales.FechaHoy.ToString() : oLote.FechaRegistro.ToString();
                txtUsuModificacion.Text = String.IsNullOrWhiteSpace(oLote.UsuarioModificacion) ? VariablesLocales.SesionUsuario.Credencial : oLote.UsuarioModificacion;
                txtFechaModificacion.Text = String.IsNullOrWhiteSpace(oLote.UsuarioRegistro) ? VariablesLocales.FechaHoy.ToString() : oLote.FechaModificacion.ToString();

                if (oLote.Opcion != (Int32)EnumOpcionGrabar.Insertar)
                {
                    oLote.Opcion = (Int32)EnumOpcionGrabar.Actualizar; 
                }
            }
            else
            {
                txtRuc.TextChanged -= txtRuc_TextChanged;
                txtproveedor.TextChanged -= txtproveedor_TextChanged;

                oLote = new LoteE
                {
                    //El lote de indusoft
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    Opcion = (Int32)EnumOpcionGrabar.Insertar,
                };

                AlmacenE almacenSigla = AgenteAlmacen.Proxy.ObtenerSiglaLoteAlmacen(oLote.idEmpresa, idAlmacen);
                txtSiglaEmpresa.Text = almacenSigla.SiglaLoteAlmacen;
                txtLote.Text = "0";
                dtpFecProceso.Value = Convert.ToDateTime(oMovimiento.fecProceso.Substring(oMovimiento.fecProceso.Length - 2, 2) + "/" + oMovimiento.fecProceso.Substring(4, 2) + "/" + oMovimiento.fecProceso.Substring(0, 4)); //oMovimiento.fecProceso;
                txtIdProveedor.Text = Convert.ToString(oMovimiento.idPersona);
                txtLoteAlmacen.Text = AgenteAlmacen.Proxy.ObtenerMaxLoteAlmacenInterno(oLote.idEmpresa);
                txtRuc.Text = oMovimiento.ruc;
                txtproveedor.Text = oMovimiento.RazonSocial;
                cboPaisOrigen.SelectedValue = 90;
                cboPaisProcedencia.SelectedValue = 90;
                txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                txtRuc.TextChanged += txtRuc_TextChanged;
                txtproveedor.TextChanged += txtproveedor_TextChanged;
            }
        }

        public override void Aceptar()
        {
            try
            {
                // VALIDAMOS
                if (txtLoteProveedor.Text.Trim().Length == 0)
                {
                    Global.MensajeAdvertencia("Debe de ingresar el Lote Proveedor");
                    txtLoteProveedor.Focus();
                }
                else
                {
                    if (ValidarGrabacion())
                    {
                        //Lote Indusoft
                        oLote.Lote = txtLote.Text;
                        //Lote Proveedor
                        oLote.LoteProveedor = txtLoteProveedor.Text;
                        oLote.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                        oLote.idPaisOrigen = Convert.ToInt32(cboPaisOrigen.SelectedValue);
                        oLote.idPaisProcedencia = Convert.ToInt32(cboPaisProcedencia.SelectedValue);
                        oLote.fecProceso = dtpFecProceso.Value;
                        oLote.indfecProceso = chbindfecProceso.Checked;
                        oLote.indPersona = chbindPersona.Checked;

                        oLote.idPersona = !String.IsNullOrWhiteSpace(txtIdProveedor.Text.Trim()) ? Convert.ToInt32(txtIdProveedor.Text) : 0;
                        oLote.ruc = txtRuc.Text.Trim();
                        oLote.RazonSocial = txtproveedor.Text.Trim();

                        if (!chbindPersona.Checked)
                        {
                            if (String.IsNullOrWhiteSpace(txtIdProveedor.Text) && String.IsNullOrWhiteSpace(txtRuc.Text) && String.IsNullOrWhiteSpace(txtproveedor.Text))
                            {
                                oLote.idPersona = Convert.ToInt32(oMovimiento.idPersona);
                                oLote.ruc = oMovimiento.ruc;
                                oLote.RazonSocial = oMovimiento.RazonSocial;
                            }
                        }

                        oLote.nomComercial = string.Empty;
                        oLote.codColor = 0;
                        oLote.HibOp = string.Empty;
                        oLote.Otros = string.Empty;
                        oLote.CaCm = string.Empty;
                        oLote.Patron = string.Empty;
                        oLote.Observacion = txtObservacion.Text;
                        oLote.EntregadoPor = string.Empty;
                        oLote.LoteAlmacen = txtLoteAlmacen.Text;
                        oLote.Batch = string.Empty;
                        oLote.PorcentajeGerminacion = 0;
                        oLote.fecPrueba = dtpFecPrueba.Checked ? dtpFecPrueba.Value.Date : (DateTime?)null;
                        oLote.PesoUnitario = Convert.ToDecimal(txtPesoUnitario.Text);

                        oLote.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        oLote.FechaRegistro = Convert.ToDateTime(txtFechaRegistro.Text);
                        oLote.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        oLote.FechaModificacion = Convert.ToDateTime(txtFechaModificacion.Text);

                        if (GI == "S")
                        {
                            oLote = AgenteAlmacen.Proxy.ActualizarLote(oLote);
                        }

                        //SISTEMAS
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            if (String.IsNullOrWhiteSpace(txtLoteProveedor.Text.Trim()))
            {
                Global.MensajeComunicacion("Se necesita un Lote");
                return false;
            }

            if (!dtpFecPrueba.Checked)
            {
                Global.MensajeComunicacion("Eliga la Fecha de Vencimiento");
                return false;
            }

            //if (VariablesLocales.SesionUsuario.Empresa.RUC == "20535703214")
            //{
                
            //}
            //else
            //{
            //    if (cboPaisOrigen.SelectedIndex == 0)
            //    {
            //        Global.MensajeComunicacion("Eliga El Pais Origen");
            //        return false;
            //    }

            //    if (String.IsNullOrWhiteSpace(txtPesoUnitario.Text.Trim()))
            //    {
            //        Global.MensajeComunicacion("Digite el Peso Unitario");
            //        return false;
            //    }
            //}

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmEntradaAlmacenesLote_Load(object sender, EventArgs e)
        {
            try
            {
                LlenarCombos();
                Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboPaisOrigen_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboPaisProcedencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void txtfecPrueba_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //SendKeys.Send("{TAB}");
                //e.Handled = true; //esta linea quita el sonido al presionar enter
                btAceptar.Focus();
            }
        }

        private void chbindPersona_CheckedChanged(object sender, EventArgs e)
        {
            if (chbindPersona.Checked)
            {
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtproveedor.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtIdProveedor.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                txtIdProveedor.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtproveedor.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
        }

        private void chbindfecProceso_CheckedChanged(object sender, EventArgs e)
        {
            if (chbindfecProceso.Checked)
            {
                dtpFecProceso.Enabled = true;
            }
            else
            {
                dtpFecProceso.Enabled = false;
            }
        }
        
        private void txtproveedor_TextChanged(object sender, EventArgs e)
        {
            txtIdProveedor.Text = string.Empty;
            txtRuc.Text = string.Empty;
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

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtproveedor.Text = String.Empty;
            txtIdProveedor.Text = String.Empty;
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
                        //btContacto.Focus();
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

        private void txtPesoUnitario_Leave(object sender, EventArgs e)
        {
            txtPesoUnitario.Text = Global.FormatoDecimal(txtPesoUnitario.Text, 5);
        }

        private void txtPesoUnitario_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPesoUnitario.Text == "0.00000")
            {
                txtPesoUnitario.SelectAll();
            }
        }

        #endregion
     
    }
}
