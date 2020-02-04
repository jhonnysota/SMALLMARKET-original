using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Entidades.Seguridad;
using Entidades.Maestros;
using Presentadora.AgenteServicio;
using Infraestructura;
using ClienteWinForm.Seguridad.Busquedas;
using Infraestructura.Recursos;
using Infraestructura.Enumerados;
namespace ClienteWinForm.Seguridad
{
    public partial class FrmUsuarioEmpresaLocal : FrmMantenimientoBase
    {
        List<Empresa> listaEmpresa = null;
        List<Empresa> listaUsuarioEmpresa = new List<Empresa>();
        List<LocalE> listaLocal = null;
        List<LocalE> listaUsuarioLocal = new List<LocalE>();
        MaestrosServiceAgent AgenteMaestro {
            get {
                return new MaestrosServiceAgent();
            }
        }

        Usuario usuario = null;

        #region Constructores

        public FrmUsuarioEmpresaLocal()
        {
            InitializeComponent();
        }

        private void FrmUsuarioEmpresaLocal_Load(object sender, EventArgs e)
        {
            base.Cancelar();
            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
            BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
            //BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
            BloquearOpcion(EnumOpcionMenuBarra.Editar, false);
        }

        #endregion

        #region Metodos_Mantenimiento
        public override void Buscar()
        {
            FrmBusquedaUsuario frm = new FrmBusquedaUsuario();

            if (frm.ShowDialog() == DialogResult.OK && frm.usuario != null)
            {
                usuario = frm.usuario;
                usuario.UsuarioEmpresas = new MaestrosServiceAgent().Proxy.ListarEmpresaPorUsuario(usuario.IdPersona);
                usuario.UsuarioLocales = new MaestrosServiceAgent().Proxy.ListarLocalPorUsuario(usuario.IdPersona);
                listaUsuarioEmpresa = usuario.UsuarioEmpresas;
                listaUsuarioLocal = usuario.UsuarioLocales;
                usuarioBindingSource.DataSource = usuario;
                CargaInicial();
                //foreach (Empresa e in listaUsuarioEmpresa)
                //{
                //    Empresa res = (from x in listaEmpresa where x.IdEmpresa.Equals(e.IdEmpresa) select x).FirstOrDefault();
                //    listaEmpresa.Remove(res);
                //    empresaBindingSource.ResetBindings(false);
                //}
                
               //CARGAINICIAL


                base.Buscar();
                pnlListado.Enabled = false;
                BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
            }
            
        }
        public override void Cancelar()
        {
            pnlListado.Enabled = false;
            base.Cancelar();
        }
        public override void Editar()
        {
            pnlListado.Enabled = true;
            base.Editar();
        }
        public override void Nuevo()
        {
            base.Nuevo();
        }
        public override void Grabar()
        {

            if (Global.MensajeConfirmacion("Desea grabar") != DialogResult.Yes)
            {
                return;
            }

            try
            {
                usuario = new SeguridadServiceAgent().Proxy.InsertarUsuarioEmpresaLocal(usuario);
                pnlListado.Enabled = false;

                base.Grabar();
                BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
                Global.MensajeComunicacion(Infraestructura.Recursos.Mensajes.GrabacionExitosa);
            }
            catch (Exception ex)
            {
                Global.MensajeComunicacion("Error al grabar " + ex.Message);
                //Log.Error(ex.Message, ex);
                //throw;
            }
        }
        #endregion
        
        public void CargaInicial()
        {

            listaEmpresa = AgenteMaestro.Proxy.ListarEmpresa("");
            listaLocal = AgenteMaestro.Proxy.ListarLocalTodos("", true, true);
            empresaBindingSource.DataSource = listaEmpresa;
            localBindingSource.DataSource = listaLocal;


            LocalUsuariobindingSource.DataSource = listaUsuarioLocal;
            EmpresaUsuariobindingSource.DataSource = listaUsuarioEmpresa;


            //  ELIMINAR LOS LOCALES Q YA TIENE ASIGNADO EL USUARIO
            foreach (LocalE l in listaUsuarioLocal)
            {
                LocalE res = (from x in listaLocal where x.IdLocal.Equals(l.IdLocal) && x.IdEmpresa.Equals(l.IdEmpresa) select x).FirstOrDefault();
                listaLocal.Remove(res);
                localBindingSource.ResetBindings(false);
            }

            //FILTRAR LOCALES DE EMPRESA ACTUAL
            if (empresaBindingSource.Count > 0)
            {
                List<LocalE> res = (from x in listaLocal where x.IdEmpresa.Equals(((Empresa)EmpresaUsuariobindingSource.Current).IdEmpresa) select x).ToList();
                localBindingSource.DataSource = res;
            }

        }

        #region Eventos
        private void empresaBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (empresaBindingSource.Count > 0) {
                List<LocalE> res = (from x in listaLocal where x.IdEmpresa.Equals(((Empresa)empresaBindingSource.Current).IdEmpresa) select x).ToList();
                localBindingSource.DataSource = res;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (empresaBindingSource.Count > 0)
            //{
            //    listaUsuarioEmpresa.Add((Empresa)empresaBindingSource.Current);
            //    listaEmpresa.Remove((Empresa)empresaBindingSource.Current);                
            //    empresaBindingSource.ResetBindings(false);
            //    EmpresaUsuariobindingSource.ResetBindings(false);
            //}
            //else 
            //    Global.MensajeComunicacion("No hay datos");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (EmpresaUsuariobindingSource.Count > 0) {
            //    LocalE res = (from x in listaUsuarioLocal where x.IdEmpresa.Equals(((Empresa)EmpresaUsuariobindingSource.Current).IdEmpresa) select x).FirstOrDefault();
            //    if (res != null) {
            //        Global.MensajeComunicacion("Este usuario tiene Locales asignados con esta empresa");
            //        return;
            //    }
            //    listaEmpresa.Add((Empresa)EmpresaUsuariobindingSource.Current);
            //    listaUsuarioEmpresa.Remove((Empresa)EmpresaUsuariobindingSource.Current);                
            //    EmpresaUsuariobindingSource.ResetBindings(false);
            //    empresaBindingSource.ResetBindings(false);
            //}
            //else
            //    Global.MensajeComunicacion("No hay datos");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // DE LOCALUSUARIO A LOCAL
            if (LocalUsuariobindingSource.Count > 0) 
            {
                //EMPRESA
                if (((Empresa)EmpresaUsuariobindingSource.Current).IdEmpresa != ((Empresa)empresaBindingSource.Current).IdEmpresa)
                {
                    Global.MensajeComunicacion("Seleccionar la misma empresa en Empresa-Usuario");
                    return;
                }

                //LOCAL
                LocalE temp = (LocalE)LocalUsuariobindingSource.Current;
                LocalUsuariobindingSource.RemoveCurrent();
                LocalUsuariobindingSource.ResetBindings(false);

                ////agregar a lista si no existe
                //if ((from x in listaLocal where x.IdEmpresa.Equals(temp.IdEmpresa) && x.IdLocal.Equals(temp.IdLocal) select x).FirstOrDefault() == null)
                //{
                //    listaLocal.Add(temp); 
                //}
                listaUsuarioLocal.Remove(temp);
                listaLocal.Add(temp); 
                List<LocalE> res = (from x in listaLocal where x.IdEmpresa.Equals(((Empresa)empresaBindingSource.Current).IdEmpresa) select x).ToList();
                localBindingSource.DataSource = res;
                localBindingSource.ResetBindings(false);

                LocalE listaActual = (from x in listaUsuarioLocal where x.IdEmpresa.Equals(((Empresa)empresaBindingSource.Current).IdEmpresa) select x).FirstOrDefault();
                if (listaActual == null)
                {
                    listaUsuarioEmpresa.Remove((Empresa)EmpresaUsuariobindingSource.Current);
                    EmpresaUsuariobindingSource.ResetBindings(false);
                }

                //listaLocal.Add((LocalE)LocalUsuariobindingSource.Current);
                //listaUsuarioLocal.Remove((LocalE)LocalUsuariobindingSource.Current);
                //LocalUsuariobindingSource.DataSource = listaUsuarioLocal;
                //LocalE res = (from x in listaUsuarioLocal where x.IdEmpresa.Equals(((LocalE)LocalUsuariobindingSource.Current).IdEmpresa) select x).FirstOrDefault();
                //if (res == null)
                //{
                //    listaUsuarioEmpresa.Remove((Empresa)EmpresaUsuariobindingSource.Current);
                //    EmpresaUsuariobindingSource.ResetBindings(false);
                //}
                //else
                //{ 
                
                //}
                //LocalUsuariobindingSource.ResetBindings(false);
                //localBindingSource.ResetBindings(false);
               
            }
            else
                Global.MensajeComunicacion("No hay datos");
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //DE LOCAL A LOCALUSUARIO
            if (localBindingSource.Count > 0)
            {
                //Empresa res = (from x in listaUsuarioEmpresa where x.IdEmpresa.Equals(((Empresa)empresaBindingSource.Current).IdEmpresa) select x).FirstOrDefault();
                //if (res == null)
                //{
                //    listaUsuarioEmpresa.Add((Empresa)empresaBindingSource.Current);
                //    EmpresaUsuariobindingSource.ResetBindings(false);
                //}
                //listaUsuarioLocal.Add((LocalE)localBindingSource.Current);
                //listaLocal.Remove((LocalE)localBindingSource.Current);
                //LocalUsuariobindingSource.DataSource = listaUsuarioLocal;
                //localBindingSource.ResetBindings(false);
                //LocalUsuariobindingSource.ResetBindings(false);

                //EMPRESA
                Empresa emp = (from x in listaUsuarioEmpresa where x.IdEmpresa.Equals(((Empresa)empresaBindingSource.Current).IdEmpresa) select x).FirstOrDefault();
                if (emp == null)
                {
                    listaUsuarioEmpresa.Add((Empresa)empresaBindingSource.Current);
                    EmpresaUsuariobindingSource.DataSource = listaUsuarioEmpresa;
                    EmpresaUsuariobindingSource.ResetBindings(false);
                }
                else
                {
                    if (((Empresa)EmpresaUsuariobindingSource.Current).IdEmpresa != ((Empresa)empresaBindingSource.Current).IdEmpresa) 
                    {
                        Global.MensajeComunicacion("Seleccionar la misma empresa en Empresa-Usuario");
                        return;
                    }
                }

                //LOCAL
                LocalE temp = (LocalE)localBindingSource.Current;
                localBindingSource.RemoveCurrent();
                localBindingSource.ResetBindings(false);

                ////agregar a lista si no existe
                //if ((from x in listaUsuarioLocal where x.IdEmpresa.Equals(temp.IdEmpresa) && x.IdLocal.Equals(temp.IdLocal) select x).FirstOrDefault() == null)
                //{
                //    listaUsuarioLocal.Add(temp);
                //}
                listaLocal.Remove(temp);
                listaUsuarioLocal.Add(temp);
                List<LocalE> res = (from x in listaUsuarioLocal where x.IdEmpresa.Equals(((Empresa)empresaBindingSource.Current).IdEmpresa) select x).ToList();
                LocalUsuariobindingSource.DataSource = res;
                LocalUsuariobindingSource.ResetBindings(false);

            }
            else
                Global.MensajeComunicacion("No hay datos");
            
        }

        private void EmpresaUsuariobindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (empresaBindingSource.Count > 0)
            {
                List<LocalE> res = (from x in listaUsuarioLocal where x.IdEmpresa.Equals(((Empresa)EmpresaUsuariobindingSource.Current).IdEmpresa) select x).ToList();
                LocalUsuariobindingSource.DataSource = res;
            }
        }

        #endregion

            }
}
