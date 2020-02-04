using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades.Seguridad;
using Presentadora.AgenteServicio;

namespace ClienteWinForm.Seguridad.Busquedas
{
    public partial class FrmBusquedaPerfil : FrmMantenimientoBase
    {
        public FrmBusquedaPerfil()
        {
            InitializeComponent();
        }

        #region AGENTES
        SeguridadServiceAgent AgenteSeguridad
        {
            get
            {
                return new SeguridadServiceAgent();
            }
        }

        #endregion

        #region VARIABLES

        List<Perfil> vListaPerfil = null;
        public List<UsuarioEmpresaLocalPerfil> vListaPerfilUsuario = null;
        public UsuarioEmpresaLocalPerfil vUsuarioPerfil = null;
        public List<UsuarioEmpresaLocalPerfil> vListaPerfilBinding = null;
        #endregion
        #region LOAD

        private void FrmBusquedaPerfil_Load(object sender, EventArgs e)
        {
            CargarPerfil();

        }

        #endregion

        #region MÉTODOS PRIVADOS

        private void CargarPerfil() {
           
            //List<UsuarioEmpresaLocalPerfil> vListaUsuarioEmpresaLocalPerfil = AgenteSeguridad.Proxy.ListaUsuarioEmpresaLocalPerfilPorUsuario(vUsuarioPerfil.IdPersona, vUsuarioPerfil.IdEmpresa, vUsuarioPerfil.IdLocal);
            //foreach (UsuarioEmpresaLocalPerfil item in vListaUsuarioEmpresaLocalPerfil) {
            //    foreach (Perfil item2 in vListaPerfil) {
            //        if (item.IdPerfil == item2.IdPerfil) {
            //            item2.CheckPerfil = true;
            //        }
            //    }
            //}

            //Marcando Check de Perfiles en lista Temporal
            vListaPerfil = AgenteSeguridad.Proxy.ListarPerfil("");
            if (vListaPerfilBinding != null) {
                foreach (UsuarioEmpresaLocalPerfil item in vListaPerfilBinding)
                {
                    foreach (Perfil item2 in vListaPerfil)
                    {
                        if (item.IdPerfil == item2.IdPerfil)
                        {
                            item2.CheckPerfil = true;
                        }
                    }
                }
            }
            
            //
            bindingSourcePerfil.DataSource = vListaPerfil;
            bindingSourcePerfil.ResetBindings(true);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            vListaPerfilUsuario = new List<UsuarioEmpresaLocalPerfil>();
            UsuarioEmpresaLocalPerfil entidad = null;
            foreach (Perfil item in vListaPerfil) {
                if (item.CheckPerfil == true) {
                
                    entidad = new UsuarioEmpresaLocalPerfil();
                    entidad.IdPersona = vUsuarioPerfil.IdPersona;
                    entidad.IdEmpresa = vUsuarioPerfil.IdEmpresa;
                    entidad.IdLocal = vUsuarioPerfil.IdLocal;
                    entidad.IdPerfil = item.IdPerfil;
                    vListaPerfilUsuario.Add(entidad);
                 
                }
            
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }





    }
}
