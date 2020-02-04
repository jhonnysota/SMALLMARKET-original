using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Seguridad;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Tools;
using Infraestructura.Recursos;
using ClienteWinForm.Busquedas;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using ControlesWinForm;

namespace ClienteWinForm.Seguridad
{
    public partial class FrmUsuario : FrmMantenimientoBase
    {

        #region Constructores

        public FrmUsuario()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.AjustarResolucion(this);

            FormatoGrid(dgvPlanilla, true);
            FormatoGrid(dgvSeries, true);
            FormatoGrid(dgvCostos, true);
            FormatoGrid(dgvUsuarioAlmacen, true);
        }

        public FrmUsuario(Usuario usuario, Persona persona, Int32 Opcion)
            : this()
        {
            oUsuario = usuario;
            oPersona = persona;
            OpcionGrabar = Opcion;
        }

        public FrmUsuario(Usuario usuario, Int32 Opcion)
            : this()
        {
            oUsuario = usuario;
            OpcionGrabar = Opcion;
        }

        #endregion

        #region Variables

        public Usuario oUsuario = null;
        public Persona oPersona = null;
        public int OpcionGrabar = 0;
        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }

        #endregion

        #region Procedimientos Usuario

        private void LlenarCombo()
        {
            try
            {
                cboTipoPersona.DataSource = null;

                List<ParTabla> ListaTipoPer = AgenteGenerales.Proxy.ListarParTablaPorNemo("TIPPER");
                ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoPersona, ListaTipoPer, "IdParTabla", "Nombre");

                List<UbigeoE> ListaDepartamento = AgenteMaestros.Proxy.ListarDepartamentos();
                ListaDepartamento.Add(new UbigeoE() { Departamento = Variables.SeleccionDepartamento });

                ComboHelper.LlenarCombos<UbigeoE>(cboDepartamento, ListaDepartamento, "Departamento", "Departamento");
                cboDepartamento.SelectedValue = Variables.SeleccionDepartamento;
                cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void CargarDatos()
        {
            //// Personas
            txtIdPersona.Text = oUsuario.Persona.IdPersona.ToString();
            cboTipoPersona.SelectedValue = oUsuario.Persona.TipoPersona;
            cboTipoPersona_SelectionChangeCommitted(new object(), new EventArgs());
            txtRuc.Text = oUsuario.Persona.RUC;
            txtRazPat.Text = oUsuario.Persona.ApePaterno;
            txtComMat.Text = oUsuario.Persona.ApeMaterno;
            txtNombres.Text = oUsuario.Persona.Nombres;
            cboTipoDocumento.SelectedValue = oUsuario.Persona.TipoDocumento;
            txtNroDocumento.Text = oUsuario.Persona.NroDocumento;
            txtCorreo.Text = oUsuario.Persona.Correo;

            if (oUsuario.Persona.TipoPersona == Convert.ToInt32(enumTipoPersona.Juridica))
            {
                txtRazPat.Text = oUsuario.Persona.RazonSocial;
                txtComMat.Text = oUsuario.Persona.DireccionCompleta;
                txtNombres.Text = oUsuario.Persona.Web;
            }
            else
            {
                txtRazPat.Text = oUsuario.Persona.ApePaterno;
                txtComMat.Text = oUsuario.Persona.ApeMaterno;
                txtNombres.Text = oUsuario.Persona.Nombres;
            }

            if (oUsuario.Persona.idUbigeo != null && !String.IsNullOrWhiteSpace(oUsuario.Persona.idUbigeo.Trim()))
            {
                UbigeoE oUbigeo = AgenteMaestros.Proxy.RecuperarUbigeoPorId(oUsuario.Persona.idUbigeo);

                if (oUbigeo != null)
                {
                    if (oUbigeo.Departamento != null)
                    {
                        cboDepartamento.SelectedValue = oUbigeo.Departamento;
                        cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                        cboProvincia.SelectedValue = oUbigeo.Provincia;
                        cboProvincia_SelectionChangeCommitted(new Object(), new EventArgs());
                        cboDistrito.SelectedValue = oUsuario.Persona.idUbigeo;
                    }
                }
            }

            //Usuario
            txtNombreCorto.Text = oUsuario.NombreCorto;
            txtCredencial.Text = oUsuario.Credencial;

            ////Auditoria
            if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar) || OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
            {
                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFecRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFecModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                txtUsuarioRegistro.Text = oUsuario.UsuarioRegistro;
                txtFecRegistro.Text = oUsuario.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oUsuario.UsuarioModificacion;
                txtFecModificacion.Text = oUsuario.FechaModificacion.ToString();
            }
        }

        private void GuardarDatos()
        {
            //Persona
            oUsuario.Persona.IdPersona = !String.IsNullOrEmpty(txtIdPersona.Text) ? Convert.ToInt32(txtIdPersona.Text) : 0;
            oUsuario.Persona.TipoPersona = Convert.ToInt32(cboTipoPersona.SelectedValue);

            if (oUsuario.Persona.TipoPersona == Convert.ToInt32(enumTipoPersona.Juridica))
            {
                oUsuario.Persona.RazonSocial = txtRazPat.Text.Trim();
                oUsuario.Persona.DireccionCompleta = txtComMat.Text.Trim();
                oUsuario.Persona.Web = txtNombres.Text.Trim();

                if (cboDistrito.SelectedValue.ToString() != "0")
                {
                    oUsuario.Persona.idUbigeo = cboDistrito.SelectedValue.ToString();
                }
                else
                {
                    oUsuario.Persona.idUbigeo = String.Empty;
                }
            }
            else
            {
                StringBuilder cad = new StringBuilder();

                oUsuario.Persona.ApePaterno = txtRazPat.Text.Trim();
                oUsuario.Persona.ApeMaterno = txtComMat.Text.Trim();
                oUsuario.Persona.Nombres = txtNombres.Text.Trim();

                cad.Append(oUsuario.Persona.ApePaterno).Append(" ");
                cad.Append(oUsuario.Persona.ApeMaterno).Append(" ");
                cad.Append(oUsuario.Persona.Nombres);

                oUsuario.Persona.RazonSocial = cad.ToString().Trim();

                if (cboDistrito.SelectedValue.ToString() != "0")
                {
                    oUsuario.Persona.idUbigeo = cboDistrito.SelectedValue.ToString();
                }
                else
                {
                    oUsuario.Persona.idUbigeo = String.Empty;
                }
            }

            if (!String.IsNullOrEmpty(txtRuc.Text.Trim()))
            {
                oUsuario.Persona.RUC = txtRuc.Text.Trim();
            }
            else
            {
                oUsuario.Persona.RUC = txtNroDocumento.Text.Trim();
            }

            if (!String.IsNullOrEmpty(txtNroDocumento.Text.Trim()))
            {
                oUsuario.Persona.NroDocumento = txtNroDocumento.Text.Trim();
            }
            else
            {
                oUsuario.Persona.NroDocumento = txtRuc.Text.Trim();
            }

            oUsuario.Persona.Correo = txtCorreo.Text.Trim();

            //Usuario
            oUsuario.Credencial = txtCredencial.Text.Trim();
            oUsuario.NombreCorto = txtNombreCorto.Text.Trim();
            oUsuario.Estado = chkEstado.Checked;

            //Auditoria
            if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar)) //Cuando Ambos son nuevos
            {
                oUsuario.Clave = EncryptHelper.EncryptToByte(txtClave.Text);
                oUsuario.Persona.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oUsuario.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple)) //Cuando el Auxiliar existe pero en Usuarios no.
            {
                oUsuario.Clave = EncryptHelper.EncryptToByte(txtClave.Text);
                oUsuario.Persona.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oUsuario.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else //Cuando ambos se van actualizar...
            {
                oUsuario.Persona.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oUsuario.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }

            oUsuario.Empresa = new Empresa();
            oUsuario.Empresa = VariablesLocales.SesionUsuario.Empresa;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar))
            {
                oUsuario.Persona = new Persona();
                oUsuario.Persona = oPersona;
                CargarDatos();
                txtClave.Enabled = true;
            }
            else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
            {
                oUsuario = new Usuario
                {
                    Persona = oPersona
                };
                CargarDatos();
                txtClave.Enabled = true;
            }
            else
            {
                CargarDatos();

                //if (oUsuario.listaUsuarioCCostos != null)
                //{
                //    int count = chbListaCCostos.Items.Count;

                //    for (int i = 0; i < count; i++)
                //    {
                //        String idCCostos = ((CCostosE)chbListaCCostos.Items[i]).idCCostos;

                //        foreach (UsuarioCCostosE item in oUsuario.listaUsuarioCCostos)
                //        {
                //            if (item.idCCostos == idCCostos)
                //                chbListaCCostos.SetItemChecked(i, true);
                //        }
                //    }
                //}

                txtClave.Enabled = false;
            }

            bsCCostos.DataSource = oUsuario.listaUsuarioCCostos;
            bsCCostos.ResetBindings(false);
            bsUsuarioPlanilla.DataSource = oUsuario.ListaUsuarioPlanilla;
            bsUsuarioPlanilla.ResetBindings(false);
            bsSeries.DataSource = oUsuario.ListaSeries;
            bsSeries.ResetBindings(false);
            bsUsuarioAlmacen.DataSource = oUsuario.ListaUsuarioAlmacen;
            bsUsuarioAlmacen.ResetBindings(false);

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            { 
                bsUsuarioPlanilla.EndEdit();
                bsCCostos.EndEdit();
                bsSeries.EndEdit();

                if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar))
                {
                    if (String.IsNullOrEmpty(txtClave.Text.Trim()))
                    {
                        Global.MensajeComunicacion("Debe ingresar una clave cuando se trata de un Usuario Nuevo.");
                        return;
                    }
                }

                GuardarDatos();

                if (!ValidarGrabacion())
                {
                    return;
                }

			    //Grabando
			    if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.Insertar))
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        oUsuario = AgenteSeguridad.Proxy.GrabarUsuario(oUsuario, EnumOpcionGrabar.Insertar);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else if (OpcionGrabar == Convert.ToInt32(EnumOpcionGrabar.InsertarSimple))
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        oUsuario = AgenteSeguridad.Proxy.GrabarUsuario(oUsuario, EnumOpcionGrabar.InsertarSimple);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        oUsuario = AgenteSeguridad.Proxy.GrabarUsuario(oUsuario, EnumOpcionGrabar.Actualizar);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
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
            string resultado = ValidarEntidad<Usuario>(oUsuario);

            if (!string.IsNullOrEmpty(resultado))
            {
                Global.MensajeComunicacion(resultado);
                return false;
            }

            if (oUsuario.Persona.TipoPersona == (int)enumTipoPersona.Juridica)
            {
                if (OpcionGrabar == (Int32)EnumOpcionGrabar.Insertar)
                {
                    if (String.IsNullOrEmpty(oUsuario.Persona.RUC.Trim()) || oUsuario.Persona.RUC.Length != Variables.NroCaracteresRUC)
                    {
                        Global.MensajeFault("El Nro de RUC debe ser 11 dígitos");
                        return false;
                    }

                    if (!string.IsNullOrEmpty(oUsuario.Persona.RUC.Trim()))
                    {
                        Persona p = AgenteMaestros.Proxy.ValidaRUCExistente(oUsuario.Persona.RUC.Trim());

                        if (p != null)
                        {
                            Global.MensajeFault("El nro de RUC ya esta asignado a " + p.RazonSocial);
                            return false;
                        }
                    } 
                }
            }
            else if (oUsuario.Persona.TipoPersona == (int)enumTipoPersona.Natural_Sin_Ruc)
            {
                if (OpcionGrabar == (Int32)EnumOpcionGrabar.Insertar)
                {
                    if (String.IsNullOrEmpty(oUsuario.Persona.RUC.Trim()) || oUsuario.Persona.RUC.Length != Variables.NroCaracteresDNI)
                    {
                        Global.MensajeFault("El Nro de Documento debe ser 8 dígitos");
                        return false;
                    }

                    Persona p = AgenteMaestros.Proxy.ValidaNroDocumentoExistente(oUsuario.Persona.TipoDocumento, oUsuario.Persona.NroDocumento, oUsuario.Persona.IdPersona);

                    if (p != null)
                    {
                        Global.MensajeFault("El nro de documento ya esta asignado a " + p.RazonSocial);
                        return false;
                    } 
                }
            }
            else
            {
                if (OpcionGrabar == (Int32)EnumOpcionGrabar.Insertar)
                {
                    if (!string.IsNullOrEmpty(oUsuario.Persona.RUC.Trim()))
                    {
                        Persona p = AgenteMaestros.Proxy.ValidaRUCExistente(oUsuario.Persona.RUC);

                        if (p != null)
                        {
                            Global.MensajeFault("El nro de RUC ya esta asignado a " + p.RazonSocial);
                            return false;
                        }
                    } 
                }
            }

            return true;
        }

        public override void AgregarDetalle()
        {
            try
            {
                if (tbUsuarios.SelectedTab == tpPlanilla)
                {
                    #region Planillas

                    //if (dgvPlanilla.IsCurrentCellDirty)
                    //{
                    //    dgvPlanilla.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    //}

                    ////bsUsuario.EndEdit();
                    //bsUsuarioPlanilla.EndEdit();

                    //UsuarioPlanillaE ItemNuevo = new UsuarioPlanillaE();
                    //if (oUsuario.ListaUsuarioPlanilla == null)
                    //{
                    //    oUsuario.ListaUsuarioPlanilla = new List<UsuarioPlanillaE>();
                    //}

                    //frmBuscarPlanilla oFrm = new frmBuscarPlanilla();

                    //if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPlanilla != null)
                    //{
                    //    ItemNuevo.idPlanillas = oFrm.oPlanilla.idPlanillas;
                    //}

                    //if (ItemNuevo.idPlanillas != null)
                    //{
                    //    ItemNuevo.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    //    ItemNuevo.idPersona = oUsuario.IdPersona;
                    //    ItemNuevo.VerRemun = oFrm.Verremunera;
                    //    ItemNuevo.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    //    ItemNuevo.FechaRegistro = VariablesLocales.FechaHoy;
                    //    ItemNuevo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    //    ItemNuevo.FechaModificacion = VariablesLocales.FechaHoy;
                    //    ItemNuevo.Opcion = (Int32)EnumOpcionGrabar.Insertar;

                    //    oUsuario.ListaUsuarioPlanilla.Add(ItemNuevo);
                    //    bsUsuarioPlanilla.DataSource = oUsuario.ListaUsuarioPlanilla;
                    //    bsUsuarioPlanilla.ResetBindings(false);

                    //    bsUsuarioPlanilla.MoveLast();
                    //    dgvPlanilla.Focus();
                    //    base.AgregarDetalle();
                    //} 

                    #endregion
                }
                else if (tbUsuarios.SelectedTab == tpSeries)
                {
                    #region Series

                    if (dgvSeries.IsCurrentCellDirty)
                    {
                        dgvSeries.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    }

                    bsSeries.EndEdit();

                    frmBuscarSeriesVentas oFrm = new frmBuscarSeriesVentas();

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oSerie != null)
                    {
                        UsuarioSeriesE oUsuarioSerie = new UsuarioSeriesE()
                        {
                            idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                            idDocumento = oFrm.oSerie.idDocumento,
                            desDocumento = oFrm.oSerie.desDocumento,
                            numSerie = oFrm.oSerie.Serie,
                            UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                            FechaRegistro = VariablesLocales.FechaHoy,
                            UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                            FechaModificacion = VariablesLocales.FechaHoy
                        };

                        oUsuario.ListaSeries.Add(oUsuarioSerie);
                        bsSeries.DataSource = oUsuario.ListaSeries;
                        bsSeries.ResetBindings(false);
                        base.AgregarDetalle();
                    } 

                    #endregion
                }
                else if (tbUsuarios.SelectedTab == tpUbicacion)
                {
                    #region Centros de Costo

                    if (dgvCostos.IsCurrentCellDirty)
                    {
                        dgvCostos.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    }

                    bsCCostos.EndEdit();

                    FrmBusquedaCentroDeCosto oFrm = new FrmBusquedaCentroDeCosto();

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.CentroCosto != null)
                    {
                        UsuarioCCostosE oUsuarioCostos = new UsuarioCCostosE()
                        {
                            idCCostos = oFrm.CentroCosto.idCCostos,
                            desCCostos = oFrm.CentroCosto.desCCostos,
                            UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                            FechaRegistro = VariablesLocales.FechaHoy,
                            UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                            FechaModificacion = VariablesLocales.FechaHoy
                        };

                        oUsuario.listaUsuarioCCostos.Add(oUsuarioCostos);
                        bsCCostos.DataSource = oUsuario.listaUsuarioCCostos;
                        bsCCostos.ResetBindings(false);
                        base.AgregarDetalle();
                    }

                    #endregion
                }
                else if (tbUsuarios.SelectedTab == tpUsuarioAlmacen)
                {
                    #region Usuario Almacen

                    if (dgvUsuarioAlmacen.IsCurrentCellDirty)
                    {
                        dgvUsuarioAlmacen.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    }

                    List<Int32> ListaAlm = new List<Int32>();

                    foreach (UsuarioAlmacenE item in oUsuario.ListaUsuarioAlmacen)
                    {
                        ListaAlm.Add(item.idAlmacen);
                    }             

                    if (bsUsuarioAlmacen.Count > 0)
                    {
                        frmUsuarioAlmacen oFrm = new frmUsuarioAlmacen(ListaAlm);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oUsuAlmacen != null)
                        {
                            UsuarioAlmacenE oUsuarioAlmacen = new UsuarioAlmacenE()
                            {
                                idPersona = oUsuario.IdPersona,
                                idAlmacen = oFrm.oUsuAlmacen.idAlmacen,
                                DesAlmacen = oFrm.oUsuAlmacen.desAlmacen,
                                idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                                FechaRegistro = VariablesLocales.FechaHoy,
                                UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                                FechaModificacion = VariablesLocales.FechaHoy,
                                Opcion = (Int32)EnumOpcionGrabar.Insertar,
                            };
                            
                            oUsuario.ListaUsuarioAlmacen.Add(oUsuarioAlmacen);
                            bsUsuarioAlmacen.DataSource = oUsuario.ListaUsuarioAlmacen;
                            bsUsuarioAlmacen.ResetBindings(false);
                            base.AgregarDetalle();
                        }
                    }
                    else
                    {
                        frmUsuarioAlmacen oFrm = new frmUsuarioAlmacen();
                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oUsuAlmacen != null)
                        {
                            UsuarioAlmacenE oUsuarioAlmacen = new UsuarioAlmacenE()
                            {
                                idPersona = oUsuario.IdPersona,
                                idAlmacen = oFrm.oUsuAlmacen.idAlmacen,
                                DesAlmacen = oFrm.oUsuAlmacen.desAlmacen,
                                idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                                FechaRegistro = VariablesLocales.FechaHoy,
                                UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                                FechaModificacion = VariablesLocales.FechaHoy,
                                Opcion = (Int32)EnumOpcionGrabar.Insertar,
                            };

                            oUsuario.ListaUsuarioAlmacen.Add(oUsuarioAlmacen);
                            bsUsuarioAlmacen.DataSource = oUsuario.ListaUsuarioAlmacen;
                            bsUsuarioAlmacen.ResetBindings(false);
                            base.AgregarDetalle();
                        }
                    }

                  

                   

                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (tbUsuarios.SelectedTab == tpUbicacion)
                {
                    #region Centros de Costo

                    if (bsCCostos.Current != null)
                    {
                        if (oUsuario.listaUsuarioCCostos != null && oUsuario.listaUsuarioCCostos.Count > Variables.Cero)
                        {
                            if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) != DialogResult.Yes)
                                return;

                            bsCCostos.EndEdit();

                            oUsuario.listaUsuarioCCostos.RemoveAt(bsCCostos.Position);
                            bsCCostos.DataSource = oUsuario.listaUsuarioCCostos;
                            bsCCostos.ResetBindings(false);
                            base.QuitarDetalle();
                        }
                    } 

                    #endregion
                }
                else if (tbUsuarios.SelectedTab == tpPlanilla)
                {
                    #region Planillas

                    if (bsUsuarioPlanilla.Current != null)
                    {
                        if (oUsuario.ListaUsuarioPlanilla != null && oUsuario.ListaUsuarioPlanilla.Count > Variables.Cero)
                        {
                            if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) != DialogResult.Yes)
                                return;

                            bsUsuarioPlanilla.EndEdit();

                            oUsuario.ListaUsuarioPlanilla.RemoveAt(bsUsuarioPlanilla.Position);
                            bsUsuarioPlanilla.DataSource = oUsuario.ListaUsuarioPlanilla;
                            bsUsuarioPlanilla.ResetBindings(false);
                            base.QuitarDetalle();
                        }
                    } 

                    #endregion
                }
                else if (tbUsuarios.SelectedTab == tpSeries)
                {
                    #region Series

                    if (bsSeries.Current != null)
                    {
                        if (oUsuario.ListaSeries != null && oUsuario.ListaSeries.Count > Variables.Cero)
                        {
                            if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) != DialogResult.Yes)
                                return;

                            bsUsuarioPlanilla.EndEdit();

                            oUsuario.ListaSeries.RemoveAt(bsSeries.Position);
                            bsSeries.DataSource = oUsuario.ListaSeries;
                            bsSeries.ResetBindings(false);
                            base.QuitarDetalle();
                        }
                    }

                    #endregion
                }
                else if (tbUsuarios.SelectedTab == tpUsuarioAlmacen)
                {
                    #region Usuario Almacen

                    if (bsUsuarioAlmacen.Current != null)
                    {
                        if (oUsuario.ListaUsuarioAlmacen != null && oUsuario.ListaUsuarioAlmacen.Count > Variables.Cero)
                        {
                            if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) != DialogResult.Yes)
                                return;

                            bsUsuarioAlmacen.EndEdit();
                            AgenteSeguridad.Proxy.EliminarUsuarioAlmacen(((UsuarioAlmacenE)bsUsuarioAlmacen.Current).idPersona, ((UsuarioAlmacenE)bsUsuarioAlmacen.Current).idAlmacen, ((UsuarioAlmacenE)bsUsuarioAlmacen.Current).idEmpresa);
                            oUsuario.ListaUsuarioAlmacen.RemoveAt(bsUsuarioAlmacen.Position);
                            bsUsuarioAlmacen.DataSource = oUsuario.ListaUsuarioAlmacen;
                            bsUsuarioAlmacen.ResetBindings(false);
                            base.QuitarDetalle();
                        }
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                LlenarCombo();
                Nuevo();

                cboTipoPersona_SelectionChangeCommitted(new object(), new EventArgs());

                if (OpcionGrabar == (Int32)EnumOpcionGrabar.Insertar)
                {
                    tbUsuarios.TabPages.Remove(tpPlanilla);
                }

                if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
                {
                    btClave.Visible = true;
                }

                BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtNroDocumento_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Text = txtNroDocumento.Text;
            oUsuario.Persona.RUC = oUsuario.Persona.NroDocumento;
        }

        private void txtNroDocumento_Leave(object sender, EventArgs e)
        {
            //bsPersona.EndEdit();
        }

        private void btSunat_Click(object sender, EventArgs e)
        {
            string sDir = string.Empty;
            string dirTemp = string.Empty;
            string sDep = string.Empty;
            string sPro = string.Empty;
            string sDis = string.Empty;
            string RazonSocial = string.Empty;

            int num = 0;
            frmBuscarRuc oFrm = new frmBuscarRuc();
            List<string> ListaUbigeo;

            if (string.IsNullOrEmpty(txtRuc.Text))
            {
                Global.MensajeAdvertencia("Debe ingresar el nro de ruc antes");
                txtRuc.Focus();
                return;
            }

            oFrm.Ruc = txtRuc.Text;

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Informacion != null)
            {
                switch (Convert.ToInt32(cboTipoPersona.SelectedValue))
                {
                    case 102001: //Personas Juridicas
                        oUsuario.Persona.RUC = oFrm.Ruc;
                        txtRazPat.Text = oUsuario.Persona.RazonSocial = oFrm.RazonSocial;
                        sDir = oFrm.Direccion;

                        for (int i = 0; i < cboDepartamento.Items.Count; i++)
                        {
                            num = sDir.IndexOf(cboDepartamento.GetItemText(cboDepartamento.Items[i]));

                            if (num > 20)
                            {
                                dirTemp = Global.Extraer(sDir, num);
                                ListaUbigeo = new List<string>(dirTemp.Split('-'));

                                num = ListaUbigeo[0].IndexOf(")");

                                if (num > 0)
                                {
                                    ListaUbigeo[0] = ListaUbigeo[0].Substring(num + 1);
                                }

                                if (ListaUbigeo.Count != 0)
                                {
                                    sDep = ListaUbigeo[0].Trim().ToString();
                                    sPro = ListaUbigeo[1].ToString().Trim();
                                    sDis = ListaUbigeo[2].Trim().ToString();
                                    sDis = sDis.Replace("�", "Ñ");

                                    cboDepartamento.SelectedValue = sDep.Trim();
                                    cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                                    cboProvincia.SelectedValue = sPro.Trim();
                                    cboProvincia_SelectionChangeCommitted(new object(), new EventArgs());
                                    cboDistrito.Text = sDis.Trim();

                                    break;
                                }
                            }
                        }

                        sDir = sDir.Replace(sDep + " - " + sPro + " - " + sDis, string.Empty);
                        sDir = sDir.Replace(sDep + "  - " + sPro + "  - " + sDis, string.Empty);
                        txtComMat.Text = oUsuario.Persona.DireccionCompleta = sDir;
                        break;

                    case 102002: //Personas Natural con Ruc

                        oUsuario.Persona.RUC = oFrm.Ruc;
                        oUsuario.Persona.NroDocumento = oFrm.DNI;
                        oUsuario.Persona.RazonSocial = RazonSocial = oFrm.RazonSocial;
                        
                        if (oFrm.Avisar)
                        {
                            txtRazPat.Text = oUsuario.Persona.ApePaterno = oFrm.ApellidosPaternos;
                            txtComMat.Text = oUsuario.Persona.ApeMaterno = oFrm.ApellidosMaternos;
                            txtNombres.Text = oUsuario.Persona.Nombres = oFrm.nombres;
                        }
                        else
                        {
                            List<string> NombreApellidos = new List<string>(RazonSocial.Split(' '));

                            if (NombreApellidos.Count() == 4)
                            {
                                txtRazPat.Text = oUsuario.Persona.ApePaterno = NombreApellidos[0];
                                txtComMat.Text = oUsuario.Persona.ApeMaterno = NombreApellidos[1];
                                txtNombres.Text = oUsuario.Persona.Nombres = NombreApellidos[2] + " " + NombreApellidos[3];
                            }
                            else if (NombreApellidos.Count() == 3)
                            {
                                txtRazPat.Text = oUsuario.Persona.ApePaterno = NombreApellidos[0];
                                txtComMat.Text = oUsuario.Persona.ApeMaterno = NombreApellidos[1];
                                txtNombres.Text = oUsuario.Persona.Nombres = NombreApellidos[2];
                            }
                            else
                            {
                                txtRazPat.Text = oUsuario.Persona.ApePaterno = string.Empty;
                                txtComMat.Text = oUsuario.Persona.ApeMaterno = string.Empty;
                                txtNombres.Text = oUsuario.Persona.Nombres = NombreApellidos[0];
                            }

                            txtRazPat.Text = RazonSocial;
                        }
                        
                        //Direccion
                        sDir = oFrm.Direccion;

                        for (int i = 0; i < cboDepartamento.Items.Count; i++)
                        {
                            num = sDir.IndexOf(cboDepartamento.GetItemText(cboDepartamento.Items[i]));

                            if (num > 20)
                            {
                                dirTemp = Global.Extraer(sDir, num);
                                ListaUbigeo = new List<string>(dirTemp.Split('-'));

                                num = ListaUbigeo[0].IndexOf(")");

                                if (num > 0)
                                {
                                    ListaUbigeo[0] = ListaUbigeo[0].Substring(num + 1);
                                }

                                if (ListaUbigeo.Count != 0)
                                {
                                    sDep = ListaUbigeo[0].Trim().ToString();
                                    sPro = ListaUbigeo[1].Trim().ToString();
                                    sDis = ListaUbigeo[2].Trim().ToString();

                                    sDis = sDis.Replace("�", "Ñ");
                                    cboDepartamento.SelectedValue = sDep;
                                    cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                                    cboProvincia.SelectedValue = sPro;
                                    cboProvincia_SelectionChangeCommitted(new object(), new EventArgs());
                                    cboDistrito.Text = sDis;
                                }
                            }
                        }

                        sDir = sDir.Replace(sDep + " - " + sPro + " - " + sDis, string.Empty);
                        sDir = sDir.Replace(sDep + "  - " + sPro + "  - " + sDis, string.Empty);
                        oUsuario.Persona.DireccionCompleta = sDir.Trim();
                        break;
                }

                //bsUsuario.DataSource = EUsuario;
                //bsPersona.DataSource = EUsuario.Persona;
                //bsPersona.ResetBindings(false);
                //bsUsuario.ResetBindings(false);
            }
        }

        private void cboTipoPersona_SelectionChangeCommitted(object sender, EventArgs e)
        {
            List<ParTabla> ListaDocumentos = new List<ParTabla>();

            ListaDocumentos = AgenteGenerales.Proxy.ListarParTablaPorGrupo(Convert.ToInt32(EnumParTabla.TipoDocumento), "");

            if (Convert.ToInt32(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Juridica))
            {
                cboDepartamento.Visible = true;
                cboProvincia.Visible = true;
                cboDistrito.Visible = true;

                List<ParTabla> ListaDocumentosJuridica = new List<ParTabla>();
                ListaDocumentosJuridica = (from x in ListaDocumentos
                                           where x.IdParTabla == Convert.ToInt32(EnumTipoDocumento.Ruc) 
                                           select x).ToList();
                ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoDocumento, ListaDocumentosJuridica, "IdParTabla", "Nombre");

                apePaternoLabel.Text = "Razón Social";
                apeMaternoLabel.Text = "Dirección";
                nombresLabel.Text = "Pag. Web";
                txtNombres.CharacterCasing = CharacterCasing.Normal;

                cboTipoDocumento.Enabled = false;
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                //txtRuc.Enabled = true;
                //txtRuc.BackColor = Color.White;
                txtNroDocumento.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                //txtNroDocumento.Enabled = false;
                //txtNroDocumento.BackColor = SystemColors.InactiveCaption;
                //txtNroDocumento.Text = string.Empty;
                btSunat.Enabled = true;
                btReniec.Enabled = false;
            }
            else if (Convert.ToInt32(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Natural_Ruc))
            {
                cboDepartamento.Visible = true;
                cboProvincia.Visible = true;
                cboDistrito.Visible = true;

                List<ParTabla> ListaDocumentosNatural = new List<ParTabla>();
                ListaDocumentosNatural = (from x in ListaDocumentos
                                          where x.IdParTabla != Convert.ToInt32(EnumTipoDocumento.Ruc)
                                          select x).ToList();
                ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoDocumento, ListaDocumentosNatural, "IdParTabla", "Nombre");

                apePaternoLabel.Text = "Ape. Paterno";
                apeMaternoLabel.Text = "Ape. Materno";
                nombresLabel.Text = "Nombres";
                txtNombres.CharacterCasing = CharacterCasing.Upper;
                cboTipoDocumento.Enabled = true;
                //txtRuc.Enabled = true;
                //txtRuc.BackColor = Color.White;
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtNroDocumento.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                //txtNroDocumento.Enabled = false;
                //txtNroDocumento.BackColor = SystemColors.InactiveCaption;
                //txtNroDocumento.Text = string.Empty;
                btSunat.Enabled = true;
                btReniec.Enabled = false;
            }
            else if ((Convert.ToInt32(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Natural_Sin_Ruc)))
            {
                cboDepartamento.Visible = false;
                cboProvincia.Visible = false;
                cboDistrito.Visible = false;

                List<ParTabla> ListaDocumentosJuridica = new List<ParTabla>();
                ListaDocumentosJuridica = (from x in ListaDocumentos
                                           where x.IdParTabla == Convert.ToInt32(EnumTipoDocumento.Dni)
                                           select x).ToList();
                ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoDocumento, ListaDocumentosJuridica, "IdParTabla", "Nombre");

                apePaternoLabel.Text = "Ape. Paterno";
                apeMaternoLabel.Text = "Ape. Materno";
                nombresLabel.Text = "Nombres";
                txtNombres.CharacterCasing = CharacterCasing.Upper;
                cboTipoDocumento.Enabled = false;
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                //txtRuc.Enabled = false;
                //txtRuc.BackColor = SystemColors.InactiveCaption;
                txtNroDocumento.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                //txtNroDocumento.Enabled = true;
                //txtNroDocumento.BackColor = Color.White;
                //txtRuc.Text = string.Empty;
                btSunat.Enabled = false;
                btReniec.Enabled = true;
                txtNroDocumento.MaxLength = 8;
                txtNroDocumento.TextBoxEstados = SuperTextBox.EstadoValidacion.SoloNumeros;
            }
            else if ((Convert.ToInt32(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Otros)))
            {
                cboDepartamento.Visible = false;
                cboProvincia.Visible = false;
                cboDistrito.Visible = false;

                List<ParTabla> ListaDocumentosNatural = new List<ParTabla>();
                ListaDocumentosNatural = (from x in ListaDocumentos
                                          where (x.IdParTabla != Convert.ToInt32(EnumTipoDocumento.Ruc)) && (x.IdParTabla != Convert.ToInt32(EnumTipoDocumento.Dni))
                                          select x).ToList();
                ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoDocumento, ListaDocumentosNatural, "IdParTabla", "Nombre");

                apePaternoLabel.Text = "Ape. Paterno";
                apeMaternoLabel.Text = "Ape. Materno";
                nombresLabel.Text = "Nombres";
                txtNombres.CharacterCasing = CharacterCasing.Upper;
                cboTipoDocumento.Enabled = true;
                txtNroDocumento.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                cboDepartamento.Visible = false;
                cboProvincia.Visible = false;
                cboDistrito.Enabled = false;
                cboTipoDocumento.DataSource = null;
                cboTipoDocumento.Enabled = false;
            }
        }

        private void cboTipoDocumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Juridica))
            {
                if (Convert.ToInt32(cboTipoDocumento.SelectedValue) == Convert.ToInt32(EnumTipoDocumento.Ruc))
                {
                    txtRuc.Enabled = true;
                    txtRuc.BackColor = Color.White;
                    txtNroDocumento.Enabled = false;
                    txtNroDocumento.BackColor = SystemColors.InactiveCaption;
                    txtNroDocumento.Text = string.Empty;
                    btSunat.Enabled = true;
                    btReniec.Enabled = false;
                }
            }
            else if (Convert.ToInt32(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Natural_Ruc))
            {
                txtRuc.Enabled = true;
                txtRuc.BackColor = Color.White;
                txtRuc.Text = string.Empty;
                txtNroDocumento.Enabled = true;
                txtNroDocumento.BackColor = Color.White;
                txtNroDocumento.Text = string.Empty;
                btSunat.Enabled = true;
                btReniec.Enabled = true;
                txtNroDocumento.MaxLength = 8;
                txtNroDocumento.TextBoxEstados = SuperTextBox.EstadoValidacion.SoloNumeros;
            }
            else if ((Convert.ToInt32(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Natural_Sin_Ruc)))
            {
                txtRuc.Enabled = false;
                txtRuc.BackColor = SystemColors.InactiveCaption;
                txtNroDocumento.Enabled = true;
                txtNroDocumento.BackColor = Color.White;
                txtRuc.Text = string.Empty;
                btSunat.Enabled = false;
                btReniec.Enabled = true;
                txtNroDocumento.MaxLength = 8;
                txtNroDocumento.TextBoxEstados = SuperTextBox.EstadoValidacion.SoloNumeros;
            }
            else if ((Convert.ToInt32(cboTipoPersona.SelectedValue) == Convert.ToInt32(enumTipoPersona.Otros)))
            {
                txtRuc.Enabled = false;
                txtRuc.BackColor = SystemColors.InactiveCaption;
                txtNroDocumento.Enabled = true;
                txtNroDocumento.BackColor = Color.White;
                txtRuc.Text = string.Empty;
                btSunat.Enabled = false;
                btReniec.Enabled = false;
                txtNroDocumento.MaxLength = 20;
                txtNroDocumento.TextBoxEstados = SuperTextBox.EstadoValidacion.Defecto;
            }
            else
            {
                cboTipoDocumento.DataSource = null;
                cboTipoDocumento.Enabled = false;

                txtRuc.Enabled = false;
                txtRuc.BackColor = SystemColors.InactiveCaption;
                txtRuc.Text = string.Empty;
                txtNroDocumento.Enabled = false;
                txtNroDocumento.BackColor = Color.White;
                txtNroDocumento.Text = string.Empty;
            }
        }

        private void btReniec_Click(object sender, EventArgs e)
        {
            frmBuscarDni oFrm = new frmBuscarDni();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Informacion != null)
            {
                if (Convert.ToInt32(cboTipoPersona.SelectedValue) == 102003)
                {
                    StringBuilder NombreCompleto = new StringBuilder();

                    oUsuario.Persona.NroDocumento = txtNroDocumento.Text = oFrm.DNI;
                    oUsuario.Persona.RUC = txtRuc.Text = oFrm.DNI;
                    oUsuario.Persona.Nombres = txtNombres.Text =  oFrm.Informacion.Nombres;
                    oUsuario.Persona.ApePaterno = txtRazPat.Text = oFrm.Informacion.ApePaterno;
                    oUsuario.Persona.ApeMaterno = txtComMat.Text = oFrm.Informacion.ApeMaterno;

                    NombreCompleto.Append(oFrm.Informacion.ApePaterno);
                    NombreCompleto.Append(" ");
                    NombreCompleto.Append(oFrm.Informacion.ApeMaterno);
                    NombreCompleto.Append(" ");
                    NombreCompleto.Append(oFrm.Informacion.Nombres);
                    oUsuario.Persona.RazonSocial = NombreCompleto.ToString();
                    
                    //bsUsuario.DataSource = EUsuario;
                    //bsPersona.DataSource = EUsuario.Persona;
                    //bsPersona.ResetBindings(false);
                    //bsUsuario.ResetBindings(false);
                }
            } 
        }

        private void cboDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                List<UbigeoE> ListaProvincias = AgenteMaestros.Proxy.ListarProvincias(cboDepartamento.SelectedValue.ToString());
                UbigeoE CampoInicial = new UbigeoE() { Provincia = Variables.SeleccioneProvincia };
                ListaProvincias.Add(CampoInicial);
                ComboHelper.LlenarCombos<UbigeoE>(cboProvincia, ListaProvincias, "Provincia", "Provincia");

                cboProvincia.SelectedValue = Variables.SeleccioneProvincia;
                cboProvincia_SelectionChangeCommitted(new object(), new EventArgs());
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                List<UbigeoE> ListaDistritos = AgenteMaestros.Proxy.ListarDistritos(cboDepartamento.SelectedValue.ToString(), cboProvincia.SelectedValue.ToString());
                UbigeoE CampoInicial = new UbigeoE() { idUbigeo = "0", Distrito = Variables.SeleccioneDistrito };
                ListaDistritos.Add(CampoInicial);

                ComboHelper.LlenarCombos<UbigeoE>(cboDistrito, ListaDistritos, "idUbigeo", "Distrito");
                cboDistrito.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvPlanilla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6)
                {
                    if (e.ColumnIndex == 0)
                    {
                        dgvPlanilla.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                    }

                    if (e.ColumnIndex == 1)
                    {
                        dgvPlanilla.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                    }

                    if (e.ColumnIndex == 2)
                    {
                        dgvPlanilla.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                    }

                    if (e.ColumnIndex == 3)
                    {
                        dgvPlanilla.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                    }

                    if (e.ColumnIndex == 4)
                    {
                        dgvPlanilla.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                    }

                    if (e.ColumnIndex == 5)
                    {
                        dgvPlanilla.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                    }

                    if (e.ColumnIndex == 6)
                    {
                        dgvPlanilla.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                    }
                }
            }
        }

        private void btClave_Click(object sender, EventArgs e)
        {
            try
            {
                if (OpcionGrabar != Convert.ToInt32(EnumOpcionGrabar.Insertar))
                {
                    byte[] Clave = AgenteSeguridad.Proxy.ObtenerClaveUsuario(Convert.ToInt32(txtIdPersona.Text));

                    if (Clave != null)
                    {
                        txtClave.Text = EncryptHelper.Decrypt(Clave);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbUsuarios.SelectedTab == tpUbicacion || tbUsuarios.SelectedTab == tpPlanilla || tbUsuarios.SelectedTab == tpSeries || tbUsuarios.SelectedTab == tpUsuarioAlmacen)
            {
                BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
                BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
            }
            else
            {
                BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
                BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
            }
        }

        private void dgvPlanilla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                if (oUsuario != null)
                {
                    if (oUsuario.ListaUsuarioPlanilla != null && oUsuario.ListaUsuarioPlanilla.Count > Variables.Cero)
                    {
                        foreach (UsuarioPlanillaE item in oUsuario.ListaUsuarioPlanilla)
                        {
                            item.VerRemun = ((UsuarioPlanillaE)bsUsuarioPlanilla.Current).VerRemun;
                            item.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                        }

                        oUsuario = AgenteSeguridad.Proxy.GrabarUsuario(oUsuario, EnumOpcionGrabar.Actualizar);
                    }
                }
            }
        }

        #endregion

    }
}
