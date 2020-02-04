using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Extensores;

namespace ClienteWinForm.Generales
{
    public partial class frmDetracciones : FrmMantenimientoBase
    {

        #region Constructor

        public frmDetracciones()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvDetracciones, true);
            LlenarCombo();
        }

        public frmDetracciones(String idtipo_detraccion)
            :this()
        {
            oDetracciones = AgenteGenerales.Proxy.ObtenerTasasDetraccionesCompleto(idtipo_detraccion);
        }   

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        TasasDetraccionesE oDetracciones = null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombo()
        {
            List<ParTabla> ListaTipoDiario = AgenteGenerales.Proxy.ListarParTablaPorNemo("TIPOPE");
            ComboHelper.RellenarCombos<List<ParTabla>>(cboOperacion, ListaTipoDiario, "IdParTabla", "Nombre");
        }

        void GuardarDatos()
        {
            oDetracciones.idTipoOperacion = Convert.ToString(cboOperacion.SelectedValue);
            oDetracciones.idTipoDetraccion = txtIDTraccion.Text;
            oDetracciones.Nombre = txtNombre.Text;
            oDetracciones.BaseAfecta = Convert.ToDecimal(txtTasa.Text);
            oDetracciones.Excluido = chkExcluido.Checked;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oDetracciones == null)
            {
                oDetracciones = new TasasDetraccionesE();

                txtUsuRegistra.Text = oDetracciones.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oDetracciones.FechaRegistro = VariablesLocales.FechaHoy;
                txtRegistro.Text = oDetracciones.FechaRegistro.ToString();
                txtUsuModifica.Text = oDetracciones.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oDetracciones.FechaModificacion = VariablesLocales.FechaHoy;

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtIDTraccion.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtIDTraccion.Text = oDetracciones.idTipoDetraccion;
                txtNombre.Text = oDetracciones.Nombre;
                chkExcluido.Checked = oDetracciones.Excluido;
                cboOperacion.SelectedValue = Convert.ToInt32(oDetracciones.idTipoOperacion);
                txtTasa.Text = oDetracciones.BaseAfecta.ToString("N");

                txtUsuRegistra.Text = oDetracciones.UsuarioRegistro;
                txtRegistro.Text = oDetracciones.FechaRegistro.ToString();
                txtUsuModifica.Text = oDetracciones.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oDetracciones.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oDetracciones.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsTasasDetraccionesDetalle.DataSource = oDetracciones.listaDetraccionesDetalle;
            bsTasasDetraccionesDetalle.ResetBindings(false);

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oDetracciones != null)
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
                            oDetracciones = AgenteGenerales.Proxy.GrabarTasasDetracciones(oDetracciones, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oDetracciones = AgenteGenerales.Proxy.GrabarTasasDetracciones(oDetracciones, EnumOpcionGrabar.Actualizar);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                }

                bsTasasDetraccionesDetalle.DataSource = oDetracciones.listaDetraccionesDetalle;
                bsTasasDetraccionesDetalle.ResetBindings(false);

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
            String Respuesta = ValidarEntidad<TasasDetraccionesE>(oDetracciones);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        public override void AgregarDetalle()
        {
            bsTasasDetraccionesDetalle.EndEdit();

            frmDetraccionesDetalle oFrm = new frmDetraccionesDetalle();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Detalle != null)
            {
                Int32 Item;
                TasasDetraccionesDetalleE detItem = oFrm.Detalle;

                if (oDetracciones.listaDetraccionesDetalle.Count > Variables.Cero)
                {
                    Item = Convert.ToInt32(oDetracciones.listaDetraccionesDetalle.Max(mx => mx.item)) + 1;
                }
                else
                {
                    Item = Variables.ValorUno;
                }

                detItem.item = Item;
                oDetracciones.listaDetraccionesDetalle.Add(detItem);

                bsTasasDetraccionesDetalle.DataSource = oDetracciones.listaDetraccionesDetalle;
                bsTasasDetraccionesDetalle.ResetBindings(false);

                base.AgregarDetalle();
            }
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (bsTasasDetraccionesDetalle.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        if (oDetracciones.ListaDetalleEliminados == null)
                        {
                            oDetracciones.ListaDetalleEliminados = new List<TasasDetraccionesDetalleE>();
                        }

                        oDetracciones.ListaDetalleEliminados.Add((TasasDetraccionesDetalleE)bsTasasDetraccionesDetalle.Current);
                        oDetracciones.listaDetraccionesDetalle.RemoveAt(bsTasasDetraccionesDetalle.Position);
                        bsTasasDetraccionesDetalle.DataSource = oDetracciones.listaDetraccionesDetalle;
                        bsTasasDetraccionesDetalle.ResetBindings(false);

                        base.QuitarDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmDetracciones_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (bsTasasDetraccionesDetalle.Current != null)
                {
                    TasasDetraccionesDetalleE detTmp = new TasasDetraccionesDetalleE();
                    detTmp = (TasasDetraccionesDetalleE)oDetracciones.listaDetraccionesDetalle[e.RowIndex];

                    frmDetraccionesDetalle oFrm = new frmDetraccionesDetalle(detTmp);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Detalle != null)
                    {
                        oDetracciones.listaDetraccionesDetalle[e.RowIndex] = oFrm.Detalle;
                        bsTasasDetraccionesDetalle.ResetBindings(false);
                    }
                }
            }
        }

        private void txtTasa_Leave(object sender, EventArgs e)
        {
            txtTasa.Text = Global.FormatoDecimal(txtTasa.Text);
        }

        #endregion

    }
}
