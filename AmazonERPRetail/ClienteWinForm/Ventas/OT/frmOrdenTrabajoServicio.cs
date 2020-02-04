using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using ClienteWinForm.Busquedas;
using ClienteWinForm.Generales;
using Infraestructura.Extensores;

namespace ClienteWinForm.Ventas.OT
{
    public partial class frmOrdenTrabajoServicio : FrmMantenimientoBase
    {

        #region Constructor

        public frmOrdenTrabajoServicio()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvItem, false);
        }

        //Nuevo
        public frmOrdenTrabajoServicio(Int32 AreaNew_)
           : this()
        {
            Areanueva = AreaNew_;
        }

        //Editar
        public frmOrdenTrabajoServicio(Int32 idEmpresa, Int32 idLocal, Int32 idOt)
            :this()
        {
            oOrdenTrabajoServicio = AgenteVentas.Proxy.ObtenerOrdenTrabServCompleto(idEmpresa, idLocal, idOt); 
        }

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        OrdenTrabajoServicioE oOrdenTrabajoServicio = null;
        List<OrdenTrabajoServicioItemE> oListaEliminados = null;
        Int32 Opcion = Variables.Cero;
        Int32 Areanueva = 0;

        #endregion

        #region Procedimientos de Usuario

        void GuardarDatos()
        {
            oOrdenTrabajoServicio.FechaEmision = dtpFecEmision.Value;
            oOrdenTrabajoServicio.Observacion = txtObservacion.Text;
            oOrdenTrabajoServicio.Cotizacion = txtCotizacion.Text;
            oOrdenTrabajoServicio.numeroOT = txtnumeroOT.Text;
        }

        void EditarDetalle(DataGridViewCellEventArgs e, OrdenTrabajoServicioItemE oOrdenTrabajoServItem)
        {
            try
            {
                if (bsOrdenTrabajoServicioItem.Count > 0)
                {
                    frmOrdenTrabajoServicioItem oFrm = new frmOrdenTrabajoServicioItem(oOrdenTrabajoServItem);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oOrdenTrabajoServicio.ListaItemsOrdenTrabajo[e.RowIndex] = oFrm.oOrdenTrabajoServicioItem;
                        bsOrdenTrabajoServicioItem.DataSource = oOrdenTrabajoServicio.ListaItemsOrdenTrabajo;
                        bsOrdenTrabajoServicioItem.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void ValidarAuxiliar(List<Persona> oListaPersonasTmp)
        {
            if (!oListaPersonasTmp[0].Cli)
            {
                if (Global.MensajeConfirmacion("Este auxiliar no esta ingresado como Cliente. Desea agregarlo ?") == DialogResult.Yes)
                {
                    ClienteE oCliente = new ClienteE()
                    {
                        idPersona = oListaPersonasTmp[0].IdPersona,
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        SiglaComercial = oListaPersonasTmp[0].RazonSocial,
                        TipoCliente = 0,
                        fecInscripcion = (Nullable<DateTime>)null,
                        fecInicioEmpresa = (Nullable<DateTime>)null,
                        tipConstitucion = 0,
                        tipRegimen = 0,
                        catCliente = 0,
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                    };

                    AgenteMaestros.Proxy.InsertarCliente(oCliente);
                }
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oOrdenTrabajoServicio == null)
            {
                oOrdenTrabajoServicio = new OrdenTrabajoServicioE();

                oOrdenTrabajoServicio.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                oOrdenTrabajoServicio.idLocal = VariablesLocales.SesionLocal.IdLocal;
                oOrdenTrabajoServicio.idArea = Areanueva;
                txtUsuarioRegistro.Text = oOrdenTrabajoServicio.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oOrdenTrabajoServicio.FechaRegistro = VariablesLocales.FechaHoy;
                txtFechaRegistro.Text = oOrdenTrabajoServicio.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oOrdenTrabajoServicio.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oOrdenTrabajoServicio.FechaModificacion = VariablesLocales.FechaHoy;
                txtFechaModificacion.Text = oOrdenTrabajoServicio.FechaModificacion.ToString();
                
                Int32 NroOT = AgenteVentas.Proxy.ObtenerNroOT(oOrdenTrabajoServicio.idEmpresa, oOrdenTrabajoServicio.idLocal, oOrdenTrabajoServicio.idArea.Value);
                txtnumeroOT.Text = Convert.ToString(NroOT);

                Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtRucCLiente.TextChanged -= txtRucCLiente_TextChanged;
                txtRazonCliente.TextChanged -= txtRazonCliente_TextChanged;

                txtnumeroOT.Text = oOrdenTrabajoServicio.numeroOT;
                dtpFecEmision.Value = Convert.ToDateTime(oOrdenTrabajoServicio.FechaEmision);
                txtIdCliente.Text = oOrdenTrabajoServicio.idPersona.ToString();
                txtRucCLiente.Text = oOrdenTrabajoServicio.RUC;
                txtRazonCliente.Text = oOrdenTrabajoServicio.RazonSocial;
                txtDireccion.Text = oOrdenTrabajoServicio.Direccion;
                txtObservacion.Text = oOrdenTrabajoServicio.Observacion;
                txtCotizacion.Text = oOrdenTrabajoServicio.Cotizacion;

                txtUsuarioRegistro.Text = oOrdenTrabajoServicio.UsuarioRegistro;
                txtFechaRegistro.Text = oOrdenTrabajoServicio.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oOrdenTrabajoServicio.UsuarioModificacion;
                txtFechaModificacion.Text = oOrdenTrabajoServicio.FechaModificacion.ToString();
                
                txtRucCLiente.TextChanged += txtRucCLiente_TextChanged;
                txtRazonCliente.TextChanged += txtRazonCliente_TextChanged;

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsOrdenTrabajoServicioItem.DataSource = oOrdenTrabajoServicio.ListaItemsOrdenTrabajo;
            bsOrdenTrabajoServicioItem.ResetBindings(false);
            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oOrdenTrabajoServicio != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (!String.IsNullOrWhiteSpace(oOrdenTrabajoServicio.RutaBorrarImagenLocal))
                    {
                        Global.EliminarTemporal(oOrdenTrabajoServicio.RutaBorrarImagenLocal);
                    }

                    if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oOrdenTrabajoServicio = AgenteVentas.Proxy.GrabarOrdenTrabajoServicio(oOrdenTrabajoServicio, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            if (oListaEliminados != null && oListaEliminados.Count > Variables.Cero)
                            {
                                foreach (OrdenTrabajoServicioItemE item in oListaEliminados)
                                {
                                    oOrdenTrabajoServicio.ListaItemsOrdenTrabajo.Add(item);
                                }
                            }

                            oOrdenTrabajoServicio = AgenteVentas.Proxy.GrabarOrdenTrabajoServicio(oOrdenTrabajoServicio, EnumOpcionGrabar.Actualizar);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                            oListaEliminados = null;
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
            String Respuesta = ValidarEntidad<OrdenTrabajoServicioE>(oOrdenTrabajoServicio);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        public override void AgregarDetalle()
        {
            try
            {
                if (oOrdenTrabajoServicio.ListaItemsOrdenTrabajo == null)
                {
                    oOrdenTrabajoServicio.ListaItemsOrdenTrabajo = new List<OrdenTrabajoServicioItemE>();
                }

                frmOrdenTrabajoServicioItem oFrm = new frmOrdenTrabajoServicioItem();

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    OrdenTrabajoServicioItemE oServItem = oFrm.oOrdenTrabajoServicioItem;
                    oOrdenTrabajoServicio.ListaItemsOrdenTrabajo.Add(oServItem);
                    bsOrdenTrabajoServicioItem.DataSource = oOrdenTrabajoServicio.ListaItemsOrdenTrabajo;
                    bsOrdenTrabajoServicioItem.ResetBindings(false);
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
                if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                {
                    base.QuitarDetalle();

                    if (oListaEliminados == null)
                    {
                        oListaEliminados = new List<OrdenTrabajoServicioItemE>();
                    }

                    oListaEliminados.Add((OrdenTrabajoServicioItemE)bsOrdenTrabajoServicioItem.Current);

                    foreach (OrdenTrabajoServicioItemE item in oListaEliminados)
                    {
                        item.Opcion = (Int32)EnumOpcionGrabar.Eliminar;
                    }

                    oOrdenTrabajoServicio.ListaItemsOrdenTrabajo.RemoveAt(bsOrdenTrabajoServicioItem.Position);

                    bsOrdenTrabajoServicioItem.DataSource = oOrdenTrabajoServicio.ListaItemsOrdenTrabajo;
                    bsOrdenTrabajoServicioItem.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmOrdenTrabajoServicio_Load(object sender, EventArgs e)
        {
            Grid = false;
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
            Nuevo();
        }

        private void dgvItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditarDetalle(e, ((OrdenTrabajoServicioItemE)bsOrdenTrabajoServicioItem.Current));
            }
        }

        private void txtRazonCliente_TextChanged(object sender, EventArgs e)
        {
            txtIdCliente.Text = string.Empty;
            txtRucCLiente.Text = string.Empty;
            txtDireccion.Text = string.Empty;
        }

        private void txtRazonCliente_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRazonCliente.Text.Trim()) && string.IsNullOrEmpty(txtRucCLiente.Text.Trim()))
                {
                    txtRucCLiente.TextChanged -= txtRucCLiente_TextChanged;
                    txtRazonCliente.TextChanged -= txtRazonCliente_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonCliente.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            oOrdenTrabajoServicio.idPersona = oFrm.oPersona.IdPersona;
                            txtRucCLiente.Text = oFrm.oPersona.RUC.ToString();
                            txtRazonCliente.Text = oFrm.oPersona.RazonSocial;
                            txtDireccion.Text = oFrm.oPersona.DireccionCompleta;
                        }
                        else
                        {
                            txtRazonCliente.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);
                        oOrdenTrabajoServicio.idPersona = oListaPersonas[0].IdPersona;
                        txtRucCLiente.Text = oListaPersonas[0].RUC.ToString();
                        txtRazonCliente.Text = oListaPersonas[0].RazonSocial;
                        txtDireccion.Text = oListaPersonas[0].DireccionCompleta;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtRucCLiente.Text = String.Empty;
                        txtRazonCliente.Text = String.Empty;
                        txtDireccion.Text = String.Empty;
                    }

                    txtRucCLiente.TextChanged += txtRucCLiente_TextChanged;
                    txtRazonCliente.TextChanged += txtRazonCliente_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRucCLiente_TextChanged(object sender, EventArgs e)
        {
            txtIdCliente.Text = string.Empty;
            txtRazonCliente.Text = string.Empty;
            txtDireccion.Text = string.Empty;
        }

        private void txtRucCLiente_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRucCLiente.Text.Trim()) && string.IsNullOrEmpty(txtRazonCliente.Text.Trim()))
                {
                    txtRazonCliente.TextChanged -= txtRazonCliente_TextChanged;
                    txtRucCLiente.TextChanged -= txtRucCLiente_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRucCLiente.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            oOrdenTrabajoServicio.idPersona = oFrm.oPersona.IdPersona;
                            txtRucCLiente.Text = oFrm.oPersona.RUC.ToString();
                            txtRazonCliente.Text = oFrm.oPersona.RazonSocial;
                            txtDireccion.Text = oFrm.oPersona.DireccionCompleta;
                        }
                        else
                        {
                            txtRazonCliente.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);
                        oOrdenTrabajoServicio.idPersona = oListaPersonas[0].IdPersona;
                        txtRucCLiente.Text = oListaPersonas[0].RUC.ToString();
                        txtRazonCliente.Text = oListaPersonas[0].RazonSocial;
                        txtDireccion.Text = oListaPersonas[0].DireccionCompleta;
                    }
                    else
                    {
                        Global.MensajeFault("La Persona ingresada no existe");
                        txtRucCLiente.Text = String.Empty;
                        txtRazonCliente.Text = String.Empty;
                        txtDireccion.Text = String.Empty;
                    }

                    txtRucCLiente.TextChanged += txtRucCLiente_TextChanged;
                    txtRazonCliente.TextChanged += txtRazonCliente_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btVerImagen_Click(object sender, EventArgs e)
        {
            try
            {
                OrdenTrabajoServicioE oOt = Colecciones.CopiarEntidad<OrdenTrabajoServicioE>(oOrdenTrabajoServicio);

                frmImagenGeneral oFrm = new frmImagenGeneral(oOt);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oTrabajoServicio != null)
                {
                    if (oFrm.oTrabajoServicio.ConImagen)
                    {
                        oOrdenTrabajoServicio.NombreReal = oFrm.oTrabajoServicio.NombreReal;
                        oOrdenTrabajoServicio.NombreImagen = oFrm.oTrabajoServicio.NombreImagen;
                        oOrdenTrabajoServicio.Extension = oFrm.oTrabajoServicio.Extension;
                        oOrdenTrabajoServicio.RutaDirectorioServer = oFrm.oTrabajoServicio.RutaDirectorioServer;
                        oOrdenTrabajoServicio.RutaImagenServer = oFrm.oTrabajoServicio.RutaImagenServer;
                        oOrdenTrabajoServicio.Imagen = oFrm.oTrabajoServicio.Imagen;
                        oOrdenTrabajoServicio.ConImagen = true;
                        oOrdenTrabajoServicio.CambioImagen = oFrm.oTrabajoServicio.CambioImagen;
                        oOrdenTrabajoServicio.RutaBorrarImagenLocal = oFrm.oTrabajoServicio.RutaBorrarImagenLocal;
                    }
                    else
                    {
                        oOrdenTrabajoServicio.NombreReal = String.Empty;
                        oOrdenTrabajoServicio.NombreImagen = String.Empty;
                        oOrdenTrabajoServicio.Extension = String.Empty;
                        oOrdenTrabajoServicio.RutaDirectorioServer = String.Empty;
                        oOrdenTrabajoServicio.RutaImagenServer = oFrm.oTrabajoServicio.RutaImagenServer;
                        oOrdenTrabajoServicio.Imagen = null;
                        oOrdenTrabajoServicio.ConImagen = false;
                        oOrdenTrabajoServicio.CambioImagen = oFrm.oTrabajoServicio.CambioImagen;
                        oOrdenTrabajoServicio.RutaBorrarImagenLocal = oFrm.oTrabajoServicio.RutaBorrarImagenLocal;
                    }

                    
                }
                else
                {
                    oOrdenTrabajoServicio.CambioImagen = false;
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
