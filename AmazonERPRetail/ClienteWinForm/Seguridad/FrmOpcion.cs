using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Seguridad;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using ClienteWinForm.Seguridad.Busquedas;

namespace ClienteWinForm.Seguridad
{
    public partial class FrmOpcion : FrmMantenimientoBase
    {

        public FrmOpcion()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(opcionDataGridView, true);
        }

        #region Variables

        Opcion opcion = null;
        List<Opcion> listaOpciones = null;
        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        #endregion

        #region Procedimientos de Usuario

        private void vBuscar()
        {
            ListadoOpcionBindingSource.DataSource = (from x in listaOpciones where x.Nombre.Contains(txtFiltro.Text.ToUpper()) select x).ToList();

            if (ListadoOpcionBindingSource.Count > 0)
            {
                BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
                BloquearOpcion(EnumOpcionMenuBarra.Cancelar, true);
            }
            else
            {
                BloquearOpcion(EnumOpcionMenuBarra.Editar, false);
                BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
            }
        }

        public void LlenarCombos()
        {
            List<EnumParTabla> listaPartabla = new List<EnumParTabla>
            {
                EnumParTabla.TipoAplicacion
            };
            Dictionary<EnumParTabla, List<ParTabla>> listaParametro = AgenteGenerales.Proxy.ListarParTablaPorListaGrupo(listaPartabla);
            ComboHelper.RellenarCombos<List<ParTabla>>(cbTipoAplicacion, listaParametro[EnumParTabla.TipoAplicacion], "IdParTabla", "Nombre");

            //List<Opcion> res = (from x in listaOpciones where x.GrupoOpcion.Equals(0) select x).ToList();
            //Opcion menuPrincipal = new Opcion();
            //menuPrincipal.IdOpcion = 0;
            //menuPrincipal.Nombre = "MENU PRINCIPAL";
            //menuPrincipal.GrupoOpcion = 0;
            //res.Add(menuPrincipal);
            //ComboHelper.LlenarCombos<Opcion>(grupoOpcionComboBox, res, "IdOpcion", "Nombre");
        }

        public void BuscarGrupoOpcion()
        {
            try
            {
                FrmBusquedaOpcionArbol frm = new FrmBusquedaOpcionArbol();

                    if (frm.ShowDialog() == DialogResult.OK && frm.opcion != null)
                    {
                             grupoOpcionTextBox.Text =Convert.ToString(frm.opcion.GrupoOpcion);
                             nombreGrupoTextBox.Text = frm.opcion.Nombre;
                              OpcionBindingSource.ResetBindings(false);
                    }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Anular()
        {
            try
            {
                if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.No)
                {
                    return;
                }

                opcion = (Opcion)ListadoOpcionBindingSource.Current;
                AgenteSeguridad.Proxy.BorrarOpcion(opcion.IdOpcion);
                ListadoOpcionBindingSource.Remove((Opcion)ListadoOpcionBindingSource.Current);

                //Buscar();
                base.Anular();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Buscar()
        {
            try
            {
                listaOpciones = new SeguridadServiceAgent().Proxy.ListarOpcion("");
                vBuscar();

                pnlDetalle.Enabled = false;
                pnllistado.Enabled = true;
                txtFiltro.Enabled = true;
                txtFiltro.BackColor = Color.White;
                BtnBuscar.Enabled = true;
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Cancelar()
        {
            pnllistado.Enabled = true;
            pnlDetalle.Enabled = false;
            richTexObservacion.Enabled = false;
            base.Cancelar();
        }

        public override void Editar()
        {
            pnllistado.Enabled = false;
            pnlDetalle.Enabled = true;
            pnlDetalle.Focus();
            idOpcionTextBox.Enabled = false;
            richTexObservacion.Enabled = true;
            base.Editar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
            cbTipoAplicacion.Focus();
        }

        public override void Grabar()
        {
            try
            {
                OpcionBindingSource.EndEdit();
                opcion = (Opcion)OpcionBindingSource.Current;

                if (Global.MensajeConfirmacion(Mensajes.GrabacionExitosa) != DialogResult.Yes)
                {
                    return;
                }

                if (!ValidarGrabacion())
                {
                    return;
                }

                if (opcion.IdOpcion == 0)
                {
                    opcion.UsuarioActualizacion = VariablesLocales.SesionUsuario.Credencial;
                    opcion.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    opcion = AgenteSeguridad.Proxy.InsertarOpcion(opcion);
                    Global.MensajeComunicacion("Opcion ingresada");
                    pnlDetalle.Enabled = false;
                    richTexObservacion.Enabled = false;
                }
                else
                {
                    opcion.UsuarioActualizacion = VariablesLocales.SesionUsuario.Credencial;
                    opcion = AgenteSeguridad.Proxy.ActualizarOpcion(opcion);
                    Global.MensajeComunicacion("Opcion actualizada");
                    pnlDetalle.Enabled = false;
                    richTexObservacion.Enabled = false;
                }

                Buscar();
                txtFiltro.Focus();

                base.Grabar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            string res = ValidarEntidad<Opcion>(opcion);
            if (!string.IsNullOrEmpty(res))
            {
                Global.MensajeComunicacion(res);
                return false;
            }
            return base.ValidarGrabacion();
        }

        public override void Nuevo()
        {
            opcion = new Opcion
            {
                UsuarioActualizacion = VariablesLocales.SesionUsuario.Credencial,
                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                FechaActualizacion = DateTime.Now,
                FechaRegistro = DateTime.Now
            };

            OpcionBindingSource.DataSource = opcion;
            pnlDetalle.Enabled = true;
            pnllistado.Enabled = false;
            idOpcionTextBox.Enabled = false;
            richTexObservacion.Enabled = true;
            base.Nuevo();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
            BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
        }

        #endregion

        #region Eventos

        private void FrmOpcion_Load(object sender, EventArgs e)
        {
            LlenarCombos();
            richTexObservacion.Enabled = false;//Bloqueo

            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
        }

        private void opcionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (ListadoOpcionBindingSource.Current != null)
            {
                OpcionBindingSource.DataSource = opcion = (Opcion)ListadoOpcionBindingSource.Current;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            vBuscar();
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Global.EventoEnter(e, BtnBuscar);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }            
        }

        private void nombreGrupoTextBox_DoubleClick(object sender, EventArgs e)
        {
            BuscarGrupoOpcion();
        }

        private void grupoOpcionTextBox_DoubleClick(object sender, EventArgs e)
        {
            BuscarGrupoOpcion();
        } 

        #endregion

    }
}
