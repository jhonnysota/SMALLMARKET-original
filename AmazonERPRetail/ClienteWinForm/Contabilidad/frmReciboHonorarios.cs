using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Contabilidad;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmReciboHonorarios : FrmMantenimientoBase
    {

        #region Constructor

        public frmReciboHonorarios()
        {
            InitializeComponent();
            FormatoGrid(dgvListado, false);
        }

        //Nuevo
        public frmReciboHonorarios(String anio_, String Mes_)
           : this()
        {
            Anio = anio_;
            Mes = Mes_;
        }

        //Edición
        public frmReciboHonorarios(ReciboHonorariosE oEntidad_, String anio_, String Mes_)
            : this()
        {
            Anio = anio_;
            Mes = Mes_;
            oRh = AgenteContabilidad.Proxy.ObtenerReciboHonorarios(oEntidad_.idEmpresa, oEntidad_.idLocal, oEntidad_.idReciboHonorarios);
        }

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        ReciboHonorariosE oRh;
        Int32 option = 0;
        String Anio = String.Empty;
        String Mes = String.Empty;
        List<ReciboHonorariosDetE> FilasItem = null;

        #endregion

        #region Procedimientos de Usuario

        void DatosGrabacion()
        {
            oRh.idPersona = String.IsNullOrWhiteSpace(txtIdAuxiliar.Text) ? 0 : Convert.ToInt32(txtIdAuxiliar.Text);
            oRh.impRecibo = oRh.oListaRecibos.Sum(x => x.impRecibo);
            oRh.impCuartaCat = oRh.oListaRecibos.Sum(x => x.impCuartaCat);
            oRh.impIES = 0;

            if (option == (Int32)EnumOpcionGrabar.Insertar)
            {
                oRh.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oRh.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void EditarDetalle(DataGridViewCellEventArgs e, ReciboHonorariosDetE oDetRecibo)
        {
            try
            {
                if (bsRecibohonorariosDetE.Count > 0)
                {
                    frmReciboHonorariosComprobante oFrm = new frmReciboHonorariosComprobante(oDetRecibo, Anio, Mes);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oRh.oListaRecibos[e.RowIndex] = oFrm.oDetalle;
                        bsRecibohonorariosDetE.DataSource = oRh.oListaRecibos;
                        bsRecibohonorariosDetE.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oRh == null)
            {
                oRh = new ReciboHonorariosE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                    AnioPeriodo = Anio,
                    MesPeriodo = Mes,
                    indEstado = false
                };

                txtUsuarioRegistro.Text = txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                option = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                option = (Int32)EnumOpcionGrabar.CambioNoPermitido;

                if (oRh.oListaRecibos == null)
                {
                    oRh.oListaRecibos = new List<ReciboHonorariosDetE>();
                }

                txtIdAuxiliar.Text = oRh.idPersona.ToString();
                txtRuc.Text = oRh.RUC;
                txtRazonSocial.Text = oRh.NomPersona;
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);

                txtUsuarioRegistro.Text = oRh.UsuarioRegistro;
                txtFechaRegistro.Text = oRh.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oRh.UsuarioModificacion;
                txtFechaModificacion.Text = oRh.FechaModificacion.ToString();

                option = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsRecibohonorariosDetE.DataSource = oRh.oListaRecibos;
            bsRecibohonorariosDetE.ResetBindings(false);

            if (!oRh.indEstado)
            {
                base.Nuevo();
            }
            else
            {
                Global.MensajeComunicacion("No podrá realizar modificaciones al recibo...");
                BloquearOpcion(EnumOpcionMenuBarra.Grabar, false);
                BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
                BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            }
        }

        public override void Grabar()
        {
            try
            {
                bsRecibohonorariosDetE.EndEdit();
                DatosGrabacion();

                if (!ValidarGrabacion()) { return; }

                if (option == (Int32)EnumOpcionGrabar.Insertar)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        oRh = AgenteContabilidad.Proxy.GrabarReciboHonorarios(oRh, EnumOpcionGrabar.Insertar);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        oRh = AgenteContabilidad.Proxy.GrabarReciboHonorarios(oRh, EnumOpcionGrabar.Actualizar);

                        if (FilasItem != null && FilasItem.Count > Variables.Cero)
                        {
                            ReciboHonorariosE Retetmp = new ReciboHonorariosE();
                            Retetmp = oRh;
                            Retetmp.oListaRecibos = FilasItem;

                            oRh = AgenteContabilidad.Proxy.GrabarReciboHonorarios(oRh, EnumOpcionGrabar.Actualizar);
                        }

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

        public override void AgregarDetalle()
        {
            try
            {
                //if (option != (Int32)EnumOpcionGrabar.Insertar)
                //{
                    frmReciboHonorariosComprobante oFrm = new frmReciboHonorariosComprobante(oRh, Anio, Mes);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        ReciboHonorariosDetE oReciboHon = oFrm.oDetalle;
                        oRh.oListaRecibos.Add(oReciboHon);
                        bsRecibohonorariosDetE.DataSource = oRh.oListaRecibos;
                        bsRecibohonorariosDetE.ResetBindings(false);
                    }
                //}
                //else
                //{
                //    Global.MensajeComunicacion("Primero escoja el auxiliar... ");
                //}
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
                if (bsRecibohonorariosDetE.Current != null)
                {
                    if (oRh.oListaRecibos != null && oRh.oListaRecibos.Count > Variables.Cero)
                    {
                        bsRecibohonorariosDetE.EndEdit();                            
            
                        if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                        {
                            //Actualizando el campo para saber que se va a realizar...
                            ((ReciboHonorariosDetE)bsRecibohonorariosDetE.Current).Opcion = (Int32)EnumOpcionGrabar.Eliminar;

                            if (FilasItem == null)
                            {
                               FilasItem = new List<ReciboHonorariosDetE>();
                            }
                            
                            //Agregando a la lista de eliminados
                            FilasItem.Add((ReciboHonorariosDetE)bsRecibohonorariosDetE.Current);
                            //Removiendo de la lista principal(temporalmente)...
                            oRh.oListaRecibos.RemoveAt(bsRecibohonorariosDetE.Position);
                            //Actualizando la lista...
                            bsRecibohonorariosDetE.DataSource = oRh.oListaRecibos;
                            bsRecibohonorariosDetE.ResetBindings(false);

                            base.QuitarDetalle();
                        }                                                    
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
            String resp = ValidarEntidad<ReciboHonorariosE>(oRh);

            if (!String.IsNullOrEmpty(resp))
            {
                Global.MensajeComunicacion(resp);
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtIdAuxiliar.Text))
            {
                Global.MensajeComunicacion("Tiene que ingresar un auxiliar.");
                return false;
            }

            return base.ValidarGrabacion();
        }

        public override void Buscar()
        {
            try
            {
                oRh.oListaRecibos = AgenteContabilidad.Proxy.ListarReciboHonorariosDet(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,VariablesLocales.SesionLocal.IdLocal, oRh.idReciboHonorarios);

                bsRecibohonorariosDetE.DataSource = oRh.oListaRecibos;
                bsRecibohonorariosDetE.ResetBindings(false);

                lblRegistros.Text = bsRecibohonorariosDetE.Count.ToString() + " Recibos por Honorarios";
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmReciboHonorarios_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();

            //if (oEntidad.idReciboHonorarios == 0)
            //{
            //    oEntidad.oListaRecibos = new List<ReciboHonorariosDetE>();
            //}
            //else
            //{
            //    oEntidad.oListaRecibos = AgenteContabilidad.Proxy.ListarReciboHonorariosDet(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,VariablesLocales.SesionLocal.IdLocal, oEntidad.idReciboHonorarios);

            //    bsRecibohonorariosDetE.DataSource = oEntidad.oListaRecibos;
            //    bsRecibohonorariosDetE.ResetBindings(false);

            //    lblRegistros.Text = bsRecibohonorariosDetE.Count.ToString() + " Recibos por Honorarios";
            //}

            //BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
            //BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
            //BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            //BloquearOpcion(EnumOpcionMenuBarra.Grabar, true);

            //if (oEntidad.oListaRecibos.Count == 0 )
            //{
            //    btGeneraVoucher.Enabled = false;
            //    btEliminarVoucher.Enabled = false;
            //}
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditarDetalle(e, ((ReciboHonorariosDetE)bsRecibohonorariosDetE.Current));
            }
        }

        private void btGeneraVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                //ReciboHonorariosDetE oReciboHonorario = (ReciboHonorariosDetE)bsRecibohonorariosDetE.Current;

                //if (oReciboHonorario.idReciboHonorarios == 0)
                //{
                //    Global.MensajeFault("Antes de Generar el Asiento debe Grabar !!! ");
                //}
                //else
                //{
                //    if (oReciboHonorario != null)
                //    {
                //        if (!oReciboHonorario.indVoucher)
                //        {
                //            ReciboHonorariosDetE oResultado = AgenteContabilidad.Proxy.GeneraAsientoReciboHonorariosDet(oReciboHonorario);
                //            Global.MensajeFault("Se Genero Correctamente el Asiento Contable ");
                //            Buscar();
                //        }
                //        else
                //        {
                //            Global.MensajeFault("El Asiento ya Fue Generado !! ");
                //        }
                //    }
                //    else
                //    {
                //        Global.MensajeFault("No Seleccionado Ningun Registro");
                //    }
                //}
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }   
        }

        private void btEliminarVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                ReciboHonorariosDetE oReciboHonorario = (ReciboHonorariosDetE)bsRecibohonorariosDetE.Current;

                if (oReciboHonorario != null)
                {
                    if (oReciboHonorario.indVoucher)
                    {
                        ReciboHonorariosDetE oResultado = AgenteContabilidad.Proxy.CerrarReciboHonorariosDet(oReciboHonorario);
                        Global.MensajeFault("Se Abrio Correctamente el Asiento Contable ");
                        Buscar();
                    }
                    else
                    {
                        Global.MensajeFault("El Recibo no Esta Cerrado !!");
                    }
                }
                else
                {
                    Global.MensajeFault("No ha Seleccionado Ningun Registro");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            if (option != (Int32)EnumOpcionGrabar.CambioNoPermitido)
            {
                txtIdAuxiliar.Text = String.Empty;
                txtRazonSocial.Text = String.Empty;
            }
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            if (option != (Int32)EnumOpcionGrabar.CambioNoPermitido)
            {
                txtIdAuxiliar.Text = String.Empty;
                txtRuc.Text = string.Empty;
            }
        }

        private void txtRuc_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRuc.Text.Trim()) && string.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        //ValidarAuxiliar(oListaPersonas);
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtIdAuxiliar.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRazonSocial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && string.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtIdAuxiliar.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsRecibohonorariosDetE_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = "Registros " + bsRecibohonorariosDetE.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
