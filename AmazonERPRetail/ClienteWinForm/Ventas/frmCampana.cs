using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
//using Entidades.Asistencia;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Maestros;

namespace ClienteWinForm.Ventas
{
    public partial class frmCampana : FrmMantenimientoBase
    {
        #region Constructores
        
        public frmCampana()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();
        }

        public frmCampana(Int32 idCampana, Int32 idEmpresa)
           : this()
        {
            oCampana = AgenteVentas.Proxy.ObtenerCampana(idCampana, idEmpresa);
        }

        #endregion

         #region Variables

         VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
         CampanaE oCampana = null;
         Int32 opcion;

         #endregion

         #region Procedimientos de Usuario

         void EsNuevoRegistro()
         {
             if (oCampana == null)
             {
                 oCampana = new CampanaE();
                 oCampana.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;    
                 oCampana.Inicio = VariablesLocales.FechaHoy;
                 oCampana.Fin = VariablesLocales.FechaHoy;
    
                 txtUsuRegistra.Text = oCampana.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                 oCampana.FechaRegistro = VariablesLocales.FechaHoy;
                 txtRegistro.Text = oCampana.FechaRegistro.ToString();
                 txtUsuModifica.Text = oCampana.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                 oCampana.FechaModificacion = VariablesLocales.FechaHoy;
                 txtModifica.Text = oCampana.FechaModificacion.ToString();

                 opcion = (Int32)EnumOpcionGrabar.Insertar;
             }
             else
             {
                 txtCampana.Text = Convert.ToString(oCampana.idCampana);
                 //txtTitulo.Text = oCampana.Titulo;
                 txtNombre.Text = oCampana.Nombre;
                 cboTipoCampana.SelectedValue= Convert.ToInt32(oCampana.idTipoCampana);

                 cboEstado.SelectedValue = Convert.ToInt32(oCampana.Estado);
                 cboTipo.SelectedValue = Convert.ToInt32(oCampana.Tipo);
                 cboEstadoPrecio.SelectedValue = Convert.ToInt32(oCampana.EstadoPrecio);
                 cboEstadoDirectoras.SelectedValue = Convert.ToInt32(oCampana.EstadoDirectoras);
                 cboPedWeb.SelectedValue = Convert.ToInt32(oCampana.MostrarPedWeb);
                 cboDevWeb.SelectedValue = Convert.ToInt32(oCampana.MostrarDevWeb);
                 cboDiferido.SelectedValue = Convert.ToInt32(oCampana.EsDiferido);
                 cboEstadoCampana.SelectedValue = Convert.ToString(oCampana.EstadoCampana);
                 cboActArticulo.SelectedValue = Convert.ToInt32(oCampana.EstadoActivarArticulo);

                 if (oCampana.Focus)
                 {
                     chkFocus.Checked = true;

                 }
                 else
                 {
                     chkFocus.Checked = false;
                 }

                 dtpInicio.Value = Convert.ToDateTime(oCampana.Inicio);
                 dtpFin.Value = Convert.ToDateTime(oCampana.Fin);

                 txtUsuRegistra.Text = oCampana.UsuarioRegistro;
                 txtRegistro.Text = oCampana.FechaRegistro.ToString();
                 txtUsuModifica.Text = oCampana.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                 oCampana.FechaModificacion = VariablesLocales.FechaHoy;
                 txtModifica.Text = oCampana.FechaModificacion.ToString();

                 opcion = (Int32)EnumOpcionGrabar.Actualizar;

             }

             base.Nuevo();
         }

         void LlenarCombos()
         {
             //Tipo de Campaña
             List<CampanaTipoE> ListaTipoCampana = AgenteVentas.Proxy.ListarCampanaTipo();
             CampanaTipoE p = new CampanaTipoE();
             p.idTipoCampana = Variables.Cero;
             p.desTipoCampana = Variables.Seleccione;
             ListaTipoCampana.Add(p);
             ComboHelper.RellenarCombos<CampanaTipoE>(cboTipoCampana, (from x in ListaTipoCampana orderby x.idTipoCampana select x).ToList(), "idTipoCampana", "desTipoCampana", false);

             cboEstado.DataSource = Global.CargarAID();
             cboEstado.ValueMember = "id";
             cboEstado.DisplayMember = "Nombre";

             cboTipo.DataSource = Global.CargarLTD();
             cboTipo.ValueMember = "id";
             cboTipo.DisplayMember = "Nombre";

             cboDiferido.DataSource = Global.CargarSNID();
             cboDiferido.ValueMember = "id";
             cboDiferido.DisplayMember = "Nombre";

             cboActArticulo.DataSource = Global.CargarAID();
             cboActArticulo.ValueMember = "id";
             cboActArticulo.DisplayMember = "Nombre";

             cboEstadoPrecio.DataSource = Global.CargarAC();
             cboEstadoPrecio.ValueMember = "id";
             cboEstadoPrecio.DisplayMember = "Nombre";

             cboEstadoDirectoras.DataSource = Global.CargarAID();
             cboEstadoDirectoras.ValueMember = "id";
             cboEstadoDirectoras.DisplayMember = "Nombre";

             cboPedWeb.DataSource = Global.CargarMN();
             cboPedWeb.ValueMember = "id";
             cboPedWeb.DisplayMember = "Nombre";

             cboDevWeb.DataSource = Global.CargarMN();
             cboDevWeb.ValueMember = "id";
             cboDevWeb.DisplayMember = "Nombre";

             cboEstadoCampana.DataSource = Global.CargarMV();
             cboEstadoCampana.ValueMember = "id";
             cboEstadoCampana.DisplayMember = "Nombre";
         }

         void GuardarDatos()
         {
             oCampana.Inicio = Convert.ToDateTime(dtpInicio.Value.Date);
             oCampana.Fin = Convert.ToDateTime(dtpFin.Value.Date);

             if (chkFocus.Checked)
             {
                 oCampana.Focus = true;

             }
             else
             {
                 oCampana.Focus = false;
             }

             oCampana.Titulo = String.Empty;
             oCampana.Nombre = txtNombre.Text;
             oCampana.idTipoCampana = Convert.ToInt32(cboTipoCampana.SelectedValue);

             oCampana.Estado = Convert.ToString(cboEstado.SelectedValue);
             oCampana.Tipo = Convert.ToString(cboTipo.SelectedValue);

            if (cboEstadoPrecio.SelectedValue.ToString() == Variables.Cero.ToString())
             {
                 oCampana.EstadoPrecio = false;
             }
             else
             {
                 oCampana.EstadoPrecio = true;
             }

            if (cboEstadoDirectoras.SelectedValue.ToString() == Variables.Cero.ToString())
             {
                 oCampana.EstadoDirectoras = false;
             }
             else
             {
                 oCampana.EstadoDirectoras = true;
             }

            if (cboPedWeb.SelectedValue.ToString() == Variables.Cero.ToString())
             {
                 oCampana.MostrarPedWeb = false;
             }
             else
             {
                 oCampana.MostrarPedWeb = true;
             }

            if (cboDevWeb.SelectedValue.ToString() == Variables.Cero.ToString())
             {
                 oCampana.MostrarDevWeb = false;
             }
             else
             {
                 oCampana.MostrarDevWeb = true;
             }

            if (cboDiferido.SelectedValue.ToString() == Variables.Cero.ToString())
             {
                 oCampana.EsDiferido = false;
             }
             else
             {
                 oCampana.EsDiferido = true;
             }

             oCampana.EstadoCampana = Convert.ToString(cboEstadoCampana.SelectedValue);

            if (cboActArticulo.SelectedValue.ToString() == Variables.Cero.ToString())
             {
                 oCampana.EstadoActivarArticulo = false;
             }
             else
             {
                 oCampana.EstadoActivarArticulo = true;
             }
         }

         void BloquearPaneles(Boolean Flag)
         {
             pnlDatos.Enabled = Flag;
         }

         #endregion

         #region Procedimientos Heredados

         public override void Nuevo()
         {
             BloquearPaneles(true);
             oCampana = new CampanaE();

             base.Nuevo();
         }

         public override void Grabar()
         {
             try
             {
                 if (oCampana != null)
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
                             oCampana = AgenteVentas.Proxy.InsertarCampana(oCampana);
                             Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                         }
                     }
                     else
                     {
                         if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                         {
                             oCampana = AgenteVentas.Proxy.ActualizarCampana(oCampana);
                             Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                         }
                     }
                 }
                 this.DialogResult = DialogResult.OK;
                 this.Close();
             }
             catch (Exception ex)
             {
                 Global.MensajeError(ex.Message);
             }
         }

         public override void Editar()
         {
             BloquearPaneles(true);
             base.Editar();
         }

         public override void Cancelar()
         {
             BloquearPaneles(false);
             pnlAuditoria.Focus();
             base.Cancelar();
         }

         public override bool ValidarGrabacion()
         {
             String Respuesta = ValidarEntidad<CampanaE>(oCampana);

             if (!String.IsNullOrEmpty(Respuesta))
             {
                 Global.MensajeComunicacion(Respuesta);
                 return false;
             }

             return base.ValidarGrabacion();
         }

         #endregion

         #region Eventos

         private void frmCampana_Load(object sender, EventArgs e)
        {
            Grid = false;
            EsNuevoRegistro();
        }

         #endregion
    }
}
