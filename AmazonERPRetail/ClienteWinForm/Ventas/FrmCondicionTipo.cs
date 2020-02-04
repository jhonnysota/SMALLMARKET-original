using System;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;

namespace ClienteWinForm.Ventas
{
    public partial class FrmCondicionTipo : FrmMantenimientoBase
    {

        #region Constructores

        public FrmCondicionTipo()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvDocumentos, true);
        }

        public FrmCondicionTipo(CondicionTipoE TC)
            : this()
        {
            Condicion = AgenteVentas.Proxy.ObtenerCondicionTipoCompleto(TC.idTipCondicion);
        }

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        CondicionTipoE Condicion = null;
        Int32 opcion = Variables.Cero;

        #endregion

        #region Procedimientos de Usuario

        void EditarDetalle(DataGridViewCellEventArgs e, CondicionE oConTipo)
        {
            FrmDetalleCondicionTipo oFrm = new FrmDetalleCondicionTipo(oConTipo);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Detalle != null)
            {
                Condicion.ListaCondicionTipo[e.RowIndex] = oFrm.Detalle;
                bsCondicion.DataSource = Condicion.ListaCondicionTipo;
                bsCondicion.ResetBindings(false);
                base.AgregarDetalle();
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (Condicion == null)
            {
                Condicion = new CondicionTipoE();

                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtCodigo.Text = Condicion.idTipCondicion.ToString();
                txtDescripcion.Text = Condicion.desTipCondicion;
                txtUsuRegistra.Text = Condicion.UsuarioRegistro;
                txtRegistro.Text = Condicion.FechaRegistro.ToString();
                txtUsuModifica.Text = Condicion.UsuarioModificacion;
                txtModifica.Text = Condicion.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsCondicion.DataSource = Condicion.ListaCondicionTipo;
            bsCondicion.ResetBindings(false);

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                Condicion.desTipCondicion = txtDescripcion.Text;

                if (!ValidarGrabacion()) { return; }

                if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        Condicion.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        Condicion = AgenteVentas.Proxy.GrabarCondicionTipo(Condicion, EnumOpcionGrabar.Insertar);
                        txtCodigo.Text = Condicion.idTipCondicion.ToString();
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }                   
                }
                else
                {
                    Condicion.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    Condicion = AgenteVentas.Proxy.GrabarCondicionTipo(Condicion, EnumOpcionGrabar.Actualizar);
                    txtCodigo.Text = Condicion.idTipCondicion.ToString();
                    Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                }

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void AgregarDetalle()
        {
            bsCondicion.EndEdit();

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                Global.MensajeFault("Debe ingresar la Descripción de la Condicion.");
                txtDescripcion.Focus();
                return;
            }

            Int32 tipCondicion = Convert.ToInt32(Condicion.idTipCondicion);
            FrmDetalleCondicionTipo oFrm = new FrmDetalleCondicionTipo();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Detalle != null)
            {
                Int32 Item;
                CondicionE detItem = oFrm.Detalle;

                if (Condicion.ListaCondicionTipo.Count > Variables.Cero)
                {
                    Item = Convert.ToInt32(Condicion.ListaCondicionTipo.Max(mx => mx.idCondicion)) + 1;
                }
                else
                {
                    Item = Variables.ValorUno;
                }

                detItem.idCondicion = Item;
                Condicion.ListaCondicionTipo.Add(detItem);

                bsCondicion.DataSource = Condicion.ListaCondicionTipo;
                bsCondicion.ResetBindings(false);
            }

            base.AgregarDetalle();
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (bsCondicion.Current != null)
                {
                    if (Condicion.ListaCondicionTipo != null && Condicion.ListaCondicionTipo.Count > Variables.Cero)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) != DialogResult.Yes)
                            return;

                        bsCondicion.EndEdit();

                        Condicion.ListaCondicionTipo.RemoveAt(bsCondicion.Position);
                        bsCondicion.DataSource = Condicion.ListaCondicionTipo;
                        bsCondicion.ResetBindings(false);

                    }
                }
                base.QuitarDetalle();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void FrmCondicionTipo_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    EditarDetalle(e, (CondicionE)bsCondicion.Current); 
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
