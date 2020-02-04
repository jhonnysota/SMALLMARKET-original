using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Seguridad;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Seguridad
{
    public partial class FrmUsuarioAccion : FrmMantenimientoBase
    {

        #region Constructores

        public FrmUsuarioAccion()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        public FrmUsuarioAccion(UsuarioAccionE usuarioAccion, Empresa empresa, UsuarioEmpresaLocal usuario)
            :this()
        {
            ListaOpcionesAccion = AgenteSeguridad.Proxy.ObtenerUsuarioAccion(usuarioAccion.idPersona, usuarioAccion.idEmpresa, usuarioAccion.idOpcion);

            if (ListaOpcionesAccion.Count == 0)
            {
                txtEmpresa.Tag = empresa.IdEmpresa;
                txtEmpresa.Text = empresa.RazonSocial;
                txtUsuario.Tag = usuario.IdPersona;
                txtUsuario.Text = usuario.NombreUsuario;
                txtGrupo.Text = usuarioAccion.NombreGrupo;
                txtOpcion.Tag = usuarioAccion.idOpcion;
                txtOpcion.Text = usuarioAccion.NombreOpcion;
            }
        } 

        #endregion

        #region Variables
        
        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        List<UsuarioAccionE> ListaOpcionesAccion = null;
        EnumOpcionGrabar Opcion = EnumOpcionGrabar.Insertar;

        #endregion

        #region Procedimientos Heredados

        public override void Grabar()
        {
            try
            {
                if (ValidarGrabacion())
                {
                    UsuarioAccionE accion = null;

                    if (Opcion == EnumOpcionGrabar.Insertar)
                    {
                        foreach (AccionE item in chklbListaCrud.CheckedItems.OfType<AccionE>())
                        {
                            accion = new UsuarioAccionE()
                            {
                                idPersona = Convert.ToInt32(txtUsuario.Tag),
                                idAccion = item.IdAccion,
                                idEmpresa = Convert.ToInt32(txtEmpresa.Tag),
                                idOpcion = Convert.ToInt32(txtOpcion.Tag),
                                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                            };

                            ListaOpcionesAccion.Add(accion);
                        }

                        if (ListaOpcionesAccion.Count > 0)
                        {
                            if (Global.MensajeConfirmacion("Se van a grabar las opciones, continuar??") == DialogResult.Yes)
                            {
                                String resp = AgenteSeguridad.Proxy.GrabarUsuarioAccion(ListaOpcionesAccion, Opcion);
                                Global.MensajeComunicacion(resp);
                            }
                        }
                    }
                    else
                    {
                        ListaOpcionesAccion = new List<UsuarioAccionE>();

                        foreach (var item in chklbListaCrud.CheckedItems.OfType<AccionE>())
                        {
                            accion = new UsuarioAccionE()
                            {
                                idPersona = Convert.ToInt32(txtUsuario.Tag),
                                idAccion = item.IdAccion,
                                idEmpresa = Convert.ToInt32(txtEmpresa.Tag),
                                idOpcion = Convert.ToInt32(txtOpcion.Tag),
                                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                            };

                            ListaOpcionesAccion.Add(accion);
                        }

                        if (ListaOpcionesAccion.Count > 0)
                        {
                            if (Global.MensajeConfirmacion("Se van actualizar las opciones, desea continuar??") == DialogResult.Yes)
                            {
                                String resp = AgenteSeguridad.Proxy.GrabarUsuarioAccion(ListaOpcionesAccion, Opcion);
                                Global.MensajeComunicacion(resp);
                            }
                        }
                    }

                    base.Grabar();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault("No se pudo graba correctamente " + ex.Message);
            }
        }

        public override void Nuevo()
        {
            if (ListaOpcionesAccion != null && ListaOpcionesAccion.Count > 0)
            {
                txtEmpresa.Tag = ListaOpcionesAccion[0].idEmpresa;
                txtEmpresa.Text = ListaOpcionesAccion[0].NombreEmpresa;
                txtUsuario.Tag = ListaOpcionesAccion[0].idPersona;
                txtUsuario.Text = ListaOpcionesAccion[0].NombreUsuario;
                txtGrupo.Text = ListaOpcionesAccion[0].NombreGrupo;
                txtOpcion.Tag = ListaOpcionesAccion[0].idOpcion;
                txtOpcion.Text = ListaOpcionesAccion[0].NombreOpcion;

                txtUsuarioRegistro.Text = ListaOpcionesAccion[0].UsuarioRegistro;
                txtFechaRegistro.Text = ListaOpcionesAccion[0].FechaRegistro.ToString();

                Opcion = EnumOpcionGrabar.Actualizar;
            }
            else
            {
                ListaOpcionesAccion = new List<UsuarioAccionE>();
                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
            }

            base.Nuevo();
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
        }

        public override bool ValidarGrabacion()
        {
            List<AccionE> ListaAcciones = new List<AccionE>();

            foreach (var item in chklbListaCrud.CheckedItems.OfType<AccionE>())
            {
                ListaAcciones.Add(item);
            }

            foreach (var item in chklbListaCrud.CheckedItems.OfType<AccionE>())
            {
                if (item.IdAccion == 1) //Control Total
                {
                    AccionE accion = ListaAcciones.Find
                    (
                        delegate (AccionE a) { return a.IdAccion != 1; }
                    );

                    if (accion != null)
                    {
                        Global.MensajeAdvertencia("Cuando tiene escogido Control Total, no puede escoger otra Opción.");
                        return false;
                    }
                }

                if (item.IdAccion == 4) //Consulta o solo lectura
                {
                    AccionE accion = ListaAcciones.Find
                    (
                        delegate (AccionE a) { return a.IdAccion != 4; }
                    );

                    if (accion != null)
                    {
                        Global.MensajeAdvertencia("Cuando tiene escogido Consultar, no puede escoger otra Opción.");
                        return false;
                    }
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Procedimientos Usuario

        void LlenarListBox()
        {
            //Acciones
            List<AccionE> oListaAcciones = AgenteSeguridad.Proxy.ListarAccionesCrud();
            ComboHelper.LlenarListBox<AccionE>(chklbListaCrud, oListaAcciones, "IdAccion", "Descripcion");

            if (ListaOpcionesAccion != null && ListaOpcionesAccion.Count > 0)
            {
                foreach (UsuarioAccionE item in ListaOpcionesAccion)
                {
                    foreach (AccionE itemAccion in oListaAcciones)
                    {
                        if (itemAccion.IdAccion == item.idAccion)
                        {
                            chklbListaCrud.SetItemChecked(itemAccion.Indice, true);
                        }
                    }
                }
            }
        }

        #endregion

        #region Eventos

        private void FrmUsuarioAccion_Load(object sender, EventArgs e)
        {
            Grid = false;
            LlenarListBox();
            Nuevo();
        } 

        #endregion

    }
}
