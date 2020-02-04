using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Almacen
{
    public partial class frmAlmacenes : FrmMantenimientoBase
    {
        
        #region Contructores
        
        public frmAlmacenes()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();

            LlenarCombos();
            LlenarAyuda();
        }

        public frmAlmacenes(Int32 idEmpresa, Int32 idAlmacen)
            :this()
        {
            oAlmacen = AgenteAlmacen.Proxy.ObtenerAlmacen(idEmpresa, idAlmacen);
        }

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        AlmacenE oAlmacen = null;
        Int32 Opcion = Variables.Cero;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //Tipo articulos...
            List<ParTabla> ListarTipoArticulos = new GeneralesServiceAgent().Proxy.ListarParTablaPorNemo("TIPART");
            ListarTipoArticulos.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Todos });
            ComboHelper.RellenarCombos<ParTabla>(cboTipoArticulo, (from x in ListarTipoArticulos orderby x.IdParTabla select x).ToList(), "idParTabla", "Nombre", false);

            //List<EnumParTabla> ListaParTabla = new List<EnumParTabla>();
            //ListaParTabla.Add(EnumParTabla.ClaseAlmacen);

            //Dictionary<EnumParTabla, List<ParTabla>> ListaParametros = AgenteGeneral.Proxy.ListarParTablaPorListaGrupo(ListaParTabla);

            //ParTabla addNew = new ParTabla() { IdParTabla = 0, Nombre = Variables.Seleccione };
            //ListaParametros[EnumParTabla.ClaseAlmacen].Add(addNew);

            //ComboHelper.RellenarCombos<List<ParTabla>>(cboClaseAlmacen, (from x in ListaParametros[EnumParTabla.ClaseAlmacen] orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre");

            //Clase Almacén...
            List<ParTabla> ListarClaseAlmacen = new GeneralesServiceAgent().Proxy.ListarParTablaPorNemo("CAL");
            ListarClaseAlmacen.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Todos });
            ComboHelper.RellenarCombos<ParTabla>(cboClaseAlmacen, (from x in ListarClaseAlmacen orderby x.IdParTabla select x).ToList(), "idParTabla", "Nombre", false);

            cboTipoNumeracion.DataSource = Global.CargarTipoNumeracion();
            cboTipoNumeracion.ValueMember = "id";
            cboTipoNumeracion.DisplayMember = "Nombre";

            cboUbicacion.DataSource = Global.CargarUbicacionGenerica();
            cboUbicacion.ValueMember = "id";
            cboUbicacion.DisplayMember = "Nombre";
        }

        void GuardarDatos()
        {
            oAlmacen.tipAlmacen = Convert.ToInt32(cboTipoArticulo.SelectedValue);
            oAlmacen.Clase = Convert.ToInt32(cboClaseAlmacen.SelectedValue);
            oAlmacen.desAlmacen = txtDescripcion.Text;
            oAlmacen.desCorta = txtDesCorta.Text;
            oAlmacen.Direccion = txtDireccion.Text;
            oAlmacen.TipoNumeracion = cboTipoNumeracion.SelectedValue.ToString();
            oAlmacen.VerificaStock = chkStock.Checked;
            oAlmacen.VerificaLote = chkLote.Checked;
            oAlmacen.idCCostos = txtIdCostos.Text;
            oAlmacen.indUbiGenerica = cboUbicacion.SelectedValue.ToString();
            oAlmacen.idUbicacion = txtIdUbicacion.Text;
            oAlmacen.desResponsable = txtContacto.Text;
            oAlmacen.tlfResponsable = txtTelefonos.Text;
            oAlmacen.EmailResponsable = txtCorreo.Text;
            oAlmacen.indEstado = false;
            oAlmacen.fecBaja = (Nullable<DateTime>)null;
            oAlmacen.SiglaLoteAlmacen = txtLoteSigla.Text;
            oAlmacen.CodEstablecimiento = txtCodEstablecimiento.Text;

            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oAlmacen.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oAlmacen.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlDatos.Enabled = Flag;
            pnlOtros.Enabled = Flag;
            pnlContacto.Enabled = Flag;
        }

        void LlenarAyuda()
        {
            Global.CrearToolTip(btBuscarCostos, "Buscar Centro de Costos.");
            Global.CrearToolTip(btBuscarUbicacion, "Buscar Ubicación.");
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oAlmacen == null)
            {
                oAlmacen = new AlmacenE()
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                };

                txtIdAlmacen.Text = oAlmacen.idAlmacen.ToString();
                cboTipoArticulo.SelectedValue = Variables.Cero;
                cboClaseAlmacen.SelectedValue = Variables.Cero;
                cboTipoNumeracion.SelectedValue = Variables.Cero.ToString();
                cboUbicacion.SelectedValue = "X";

                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtIdAlmacen.Text = oAlmacen.idAlmacen.ToString();
                cboTipoArticulo.SelectedValue = oAlmacen.tipAlmacen;
                cboClaseAlmacen.SelectedValue = oAlmacen.Clase;
                txtDescripcion.Text = oAlmacen.desAlmacen;
                txtDesCorta.Text = oAlmacen.desCorta;
                txtDireccion.Text = oAlmacen.Direccion;
                chkStock.Checked = oAlmacen.VerificaStock;
                chkLote.Checked = oAlmacen.VerificaLote;
                cboTipoNumeracion.SelectedValue = oAlmacen.TipoNumeracion;
                txtIdCostos.Text = oAlmacen.idCCostos;
                txtDesCostos.Text = oAlmacen.desCostos;
                cboUbicacion.SelectedValue = oAlmacen.indUbiGenerica;
                txtIdUbicacion.Text = oAlmacen.idUbicacion;
                txtDesUbicacion.Text = oAlmacen.desUbicacion;
                txtContacto.Text = oAlmacen.desResponsable;
                txtTelefonos.Text = oAlmacen.tlfResponsable;
                txtCorreo.Text = oAlmacen.EmailResponsable;
                txtLoteSigla.Text = oAlmacen.SiglaLoteAlmacen;
                txtCodEstablecimiento.Text = oAlmacen.CodEstablecimiento;

                if (oAlmacen.indEstado)
                {
                    lblBaja.Text = "Dado de baja el día " + oAlmacen.fecBaja.ToString();
                }
                else
                {
                    lblBaja.Text = "En Actividad";
                }

                cboUbicacion_SelectionChangeCommitted(new Object(), new EventArgs());
                txtUsuRegistra.Text = oAlmacen.UsuarioRegistro;
                txtRegistro.Text = oAlmacen.FechaRegistro.ToString();
                txtUsuModifica.Text = oAlmacen.UsuarioModificacion;
                txtModifica.Text = oAlmacen.FechaModificacion.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            if (oAlmacen.indEstado)
            {
                BloquearPaneles(false);
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            }
            else
            {
                base.Nuevo();
            }
        }

        public override void Grabar()
        {
            try
            {
                if (oAlmacen != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (txtIdAlmacen.Text == Variables.Cero.ToString())
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oAlmacen = AgenteAlmacen.Proxy.InsertarAlmacen(oAlmacen);
                            txtIdAlmacen.Text = oAlmacen.idAlmacen.ToString("000");
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oAlmacen = AgenteAlmacen.Proxy.ActualizarAlmacen(oAlmacen);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
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
            String Respuesta = ValidarEntidad<AlmacenE>(oAlmacen);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmAlmacenes_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
        }

        private void cboUbicacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboUbicacion.SelectedValue.ToString() != "X")
            {
                btBuscarUbicacion.Enabled = true;
                btBuscarUbicacion.Focus();
            }
            else
            {
                btBuscarUbicacion.Enabled = false;
            }
        }

        private void btBuscarCostos_Click(object sender, EventArgs e)
        {
            FrmBusquedaCentroDeCosto oFrm = new FrmBusquedaCentroDeCosto(2);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.CentroCosto != null)
            {
                txtIdCostos.Text = oFrm.CentroCosto.idCCostos;
                txtDesCostos.Text = oFrm.CentroCosto.desCCostos;
            }
        }

        #endregion

    }
}
