using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Seguridad;
using Entidades.Maestros;
using ClienteWinForm.Maestros.Busqueda;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Seguridad
{
    public partial class FrmUsuarioEmpresaLocalPerfil : FrmMantenimientoBase
    {
        public FrmUsuarioEmpresaLocalPerfil()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dataGridView1, true);
            FormatoGrid(dataGridView2, true);
        }

        #region VARIABLES

        List<Usuario> vListaUsuario = null;
        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }

        #endregion

        #region Procedimientos de Usuario

        private void CargaUsuarios() 
        {
            List<Empresa> oListaEmpresa = new List<Empresa>(VariablesLocales.SesionUsuario.UsuarioEmpresas);
            vListaUsuario = AgenteSeguridad.Proxy.ListarUsuariosLocalEmpresa(oListaEmpresa);///AgenteSeguridad.Proxy.ListarUsuario("", true, false);
            //List<UsuarioEmpresaLocal> vListaUsuarioEmpresaLocal = null;
            //List<UsuarioEmpresaLocalPerfil> vListaUsuarioEmpresaLocalPerfil = null;

            //foreach (Empresa itemEmpresa in VariablesLocales.SesionUsuario.UsuarioEmpresas)
            //{
            //    foreach (Usuario item in vListaUsuario)
            //    {
            //        vListaUsuarioEmpresaLocal = AgenteSeguridad.Proxy.ListarUsuarioEmpresaLocalPorUsuario(item.IdPersona, itemEmpresa.IdEmpresa);//VariablesLocales.SesionLocal.IdEmpresa);

            //        if (vListaUsuarioEmpresaLocal.Count > Variables.Cero)
            //        {
            //            item.ListaUsuarioEmpresaLocal.AddRange(vListaUsuarioEmpresaLocal);

            //            //foreach (UsuarioEmpresaLocal item2 in item.ListaUsuarioEmpresaLocal)
            //            //{
            //            //    vListaUsuarioEmpresaLocalPerfil = AgenteSeguridad.Proxy.ListaUsuarioEmpresaLocalPerfilPorUsuario(item2.IdPersona, item2.IdEmpresa, item2.IdLocal);
            //            //    item2.ListaUsuarioEmpresaLocalPerfil = vListaUsuarioEmpresaLocalPerfil;
            //            //}
            //        }
            //    }
            //}

            bindingSourceUsuario.DataSource = vListaUsuario;
        }

        //private void CambioEstadoBotonesFormulario() 
        //{
        //    BloquearOpcion(EnumOpcionMenuBarra.Grabar, false);
        //    BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
        //    BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
        //    BloquearOpcion(EnumOpcionMenuBarra.Cancelar, true);
        //    BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
        //    BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
        //    BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
        //    BloquearOpcion(EnumOpcionMenuBarra.Exportar, false);
        //    BloquearOpcion(EnumOpcionMenuBarra.Imprimir, false);
        //    BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
        //    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
        //}

        private bool ValidaLocalExistente(LocalE vLocal)
        {
            bool existe = false;

            foreach (UsuarioEmpresaLocal item in vListaUsuario[bindingSourceUsuario.Position].ListaUsuarioEmpresaLocal)
            {
                //CORREGIDO
                if (item.IdLocal == vLocal.IdLocal && item.IdEmpresa==vLocal.IdEmpresa)
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }
    
        #endregion

        #region Procedimientos Heredados

        public override void Grabar()
        {
            try
            {
                if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                if (bindingSourceUsuario.Position >= 0)
                {
                    bindingSourceUsuario.EndEdit();
                    BindingSourceUsuarioEmpresaLocal.EndEdit();

                    if (vListaUsuario != null)
                    {
                        //vListaUsuario[bindingSourceUsuario.Position].IdEmpresa = VariablesLocales.SesionLocal.IdEmpresa;
                        Usuario vUsuario = AgenteSeguridad.Proxy.GrabarUsuarioEmpresaLocalPerfil(vListaUsuario[bindingSourceUsuario.Position]);

                        if (vUsuario != null)
                        {
                            MessageBox.Show(Mensajes.GrabacionExitosa);
                            ////Habilitando Botones
                            bFlag = false;
                            Modificacion = false;
                            //BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
                            //BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
                            //BloquearOpcion(EnumOpcionMenuBarra.Editar, false);
                            //BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
                            pnlUsuarios.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Buscar()
        {
            try
            {
                CargaUsuarios();
                lblRegistroLocal.Text = "Registros " + BindingSourceUsuarioEmpresaLocal.Count.ToString();
                //dataGridView2.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
            base.Buscar();
        }

        public override void AgregarDetalle()
        {
            FrmBusquedaLocal ofrmBusquedaLocal = new FrmBusquedaLocal();
            ofrmBusquedaLocal.codigoEmpresa = VariablesLocales.SesionLocal.IdEmpresa;

            if (ofrmBusquedaLocal.ShowDialog() == DialogResult.OK && ofrmBusquedaLocal.local != null)
            {
                LocalE vLocal = ofrmBusquedaLocal.local;
                pnlUsuarios.Enabled = false;

                if (ValidaLocalExistente(vLocal))
                {
                    MessageBox.Show("Local seleccionado ya existe");
                    return;
                }

                UsuarioEmpresaLocal vUsuarioEmpresaLocal = new UsuarioEmpresaLocal();

                vUsuarioEmpresaLocal.IdPersona = vListaUsuario[bindingSourceUsuario.Position].IdPersona;
                vUsuarioEmpresaLocal.IdEmpresa = vLocal.IdEmpresa;//VariablesLocales.SesionLocal.IdEmpresa;
                vUsuarioEmpresaLocal.IdLocal = vLocal.IdLocal;
                vUsuarioEmpresaLocal.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                vUsuarioEmpresaLocal.FechaRegistro = DateTime.Now;
                vUsuarioEmpresaLocal.UsuarioActualizacion = VariablesLocales.SesionUsuario.Credencial;
                vUsuarioEmpresaLocal.FechaActualizacion = DateTime.Now;
                vUsuarioEmpresaLocal.NombreLocal = vLocal.Nombre;
                vUsuarioEmpresaLocal.NombreEmpresa = vLocal.NombreEmpresa;
                vListaUsuario[bindingSourceUsuario.Position].ListaUsuarioEmpresaLocal.Add(vUsuarioEmpresaLocal);

                BindingSourceUsuarioEmpresaLocal.DataSource = vListaUsuario[bindingSourceUsuario.Position].ListaUsuarioEmpresaLocal;
                BindingSourceUsuarioEmpresaLocal.EndEdit();
                BindingSourceUsuarioEmpresaLocal.ResetBindings(false);
                base.AgregarDetalle();
                BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
                BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
                BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
            }
        }

        public override void QuitarDetalle()
        {
            if (bindingSourceUsuario.Position >= 0)
            {
                if (BindingSourceUsuarioEmpresaLocal.Position >= 0)
                {
                    vListaUsuario[bindingSourceUsuario.Position].ListaUsuarioEmpresaLocal.RemoveAt(BindingSourceUsuarioEmpresaLocal.Position);
                    BindingSourceUsuarioEmpresaLocal.ResetBindings(false);

                    base.QuitarDetalle();
                    BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
                }
            }
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void FrmUsuarioEmpresaLocalPerfil_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = true;
                CargaUsuarios();

                //Habilitando Botones
                BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
                BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
                BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarDetalle();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                QuitarDetalle();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 2)
            //{
            //    FrmBusquedaPerfil oFrmBusquedaPerfil = new FrmBusquedaPerfil();
            //    //Colocando datos del usuario
            //    UsuarioEmpresaLocalPerfil vUsuarioPerfil = new UsuarioEmpresaLocalPerfil();

            //    vUsuarioPerfil.IdPersona = vListaUsuario[bindingSourceUsuario.Position].IdPersona;
            //    vUsuarioPerfil.IdEmpresa = vListaUsuario[bindingSourceUsuario.Position].ListaUsuarioEmpresaLocal[BindingSourceUsuarioEmpresaLocal.Position].IdEmpresa;
            //    vUsuarioPerfil.IdLocal = vListaUsuario[bindingSourceUsuario.Position].ListaUsuarioEmpresaLocal[BindingSourceUsuarioEmpresaLocal.Position].IdLocal;
            //    oFrmBusquedaPerfil.vUsuarioPerfil = vUsuarioPerfil;
                
            //    //Colocando Temporal de Perfiles Marcados
            //    List<UsuarioEmpresaLocalPerfil> vListaUsuarioPerfilBinding = new List<UsuarioEmpresaLocalPerfil>();
            //    vListaUsuarioPerfilBinding = vListaUsuario[bindingSourceUsuario.Position].ListaUsuarioEmpresaLocal[BindingSourceUsuarioEmpresaLocal.Position].ListaUsuarioEmpresaLocalPerfil;
            //    oFrmBusquedaPerfil.vListaPerfilBinding = vListaUsuarioPerfilBinding;
                
            //    if (oFrmBusquedaPerfil.ShowDialog() == DialogResult.OK && oFrmBusquedaPerfil.vListaPerfilUsuario != null)
            //    {
            //        vListaUsuario[bindingSourceUsuario.Position].ListaUsuarioEmpresaLocal[BindingSourceUsuarioEmpresaLocal.Position].ListaUsuarioEmpresaLocalPerfil = oFrmBusquedaPerfil.vListaPerfilUsuario;
            //        //MessageBox.Show(oFrmBusquedaPerfil.vListaPerfilUsuario.Count.ToString());
            //    }
            //}
        }

        private void bindingSourceUsuario_CurrentChanged(object sender, EventArgs e)
        {
            if (bindingSourceUsuario.Position >= 0)
            {
                BindingSourceUsuarioEmpresaLocal.DataSource = vListaUsuario[bindingSourceUsuario.Position].ListaUsuarioEmpresaLocal;
            }
        }

        #endregion Eventos

    }
}
