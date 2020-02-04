using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Ventas
{
    public partial class frmTransporte : FrmMantenimientoBase
    {

        #region Constructores

        public frmTransporte()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvConductores, false);
            FormatoGrid(dgvVehiculos, false);
            AnchoColumnas(0);
            AnchoColumnas(1);
        }

        public frmTransporte(Int32 idTransporte_)
            :this()
        {
            oTransporte = AgenteVentas.Proxy.ObtenerTransporteCompleto(idTransporte_);

            if (oTransporte.indEstado)
            {
                BloquearPaneles(true);
            }
        }

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        public TransporteE oTransporte = null;
        public Int32 Opcion = Variables.Cero;

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas(Int32 Tipo)
        {
            if (Tipo == Variables.Cero)
            {
                dgvConductores.Columns[0].Width = 40;
                dgvConductores.Columns[1].Width = 80;
                dgvConductores.Columns[2].Width = 200;
                dgvConductores.Columns[3].Width = 30;
                dgvConductores.Columns[4].Width = 90;
                dgvConductores.Columns[5].Width = 120;
                dgvConductores.Columns[6].Width = 90;
                dgvConductores.Columns[7].Width = 120;
            }
            else
            {
                dgvVehiculos.Columns[0].Width = 40;
                dgvVehiculos.Columns[1].Width = 80;
                dgvVehiculos.Columns[2].Width = 200;
                dgvVehiculos.Columns[3].Width = 100;
                dgvVehiculos.Columns[4].Width = 30;
                dgvVehiculos.Columns[5].Width = 90;
                dgvVehiculos.Columns[6].Width = 120;
                dgvVehiculos.Columns[7].Width = 90;
                dgvVehiculos.Columns[8].Width = 120;
            }
        }

        void GuardarDatos()
        {
            oTransporte.RazonSocial = txtRazonSocial.Text.Trim();
            oTransporte.Direccion = Global.DejarSoloUnEspacio(txtDireccion.Text.Trim());
            oTransporte.Ruc = txtRuc.Text.Trim();

            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oTransporte.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oTransporte.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlDatos.Enabled = Flag;
            pnlConductores.Enabled = Flag;
            pnlVehiculos.Enabled = Flag;
        }

        void EditarConductor(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvConductores.Rows.Count > Variables.Cero)
                {
                    TransporteConductoresE Detalle = new TransporteConductoresE();
                    Detalle = (TransporteConductoresE)oTransporte.ListaConductores[e.RowIndex];

                    if (!Detalle.indEstado)
                    {
                        frmConductores oFrm = new frmConductores(Detalle.idTransporte, Detalle.idConductor);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oConductor != null)
                        {
                            oFrm.oConductor.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                            oTransporte.ListaConductores[e.RowIndex] = oFrm.oConductor;
                            bsConductores.ResetBindings(false);
                            Modificacion = true;
                        }   
                    }
                    else
                    {
                        Global.MensajeFault("No se puede hacer modificaciones porque el registro se encuentra anulado.");
                    }
                }
            }
        }

        void EditarVehiculo(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvVehiculos.Rows.Count > Variables.Cero)
                {
                    TransporteVehiculosE Detalle = new TransporteVehiculosE();
                    Detalle = (TransporteVehiculosE)oTransporte.ListaVehiculos[e.RowIndex];

                    if (!Detalle.indEstado)
                    {
                        frmVehiculos oFrm = new frmVehiculos(Detalle.idTransporte, Detalle.idVehiculo);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oVehiculo != null)
                        {
                            oFrm.oVehiculo.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                            oTransporte.ListaVehiculos[e.RowIndex] = oFrm.oVehiculo;
                            bsVehiculos.ResetBindings(false);
                            Modificacion = true;
                        }    
                    }
                    else
                    {
                        Global.MensajeFault("No se puede hacer modificaciones porque el registro se encuentra anulado.");
                    }
                }
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oTransporte == null)
            {
                oTransporte = new TransporteE();
                oTransporte.ListaConductores = new List<TransporteConductoresE>();
                oTransporte.ListaVehiculos = new List<TransporteVehiculosE>();

                Global.LimpiarControlesPaneles(pnlDatos);
                txtIdTransporte.Text = oTransporte.idTransporte.ToString();
                oTransporte.indEstado = false;
                oTransporte.Tipo = "1";

                txtUsuRegistra.Text = oTransporte.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = oTransporte.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                lblestado.Text = "Se encuentra ACTIVO";
                Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtIdTransporte.Text = oTransporte.idTransporte.ToString("00");
                txtRuc.Text = oTransporte.Ruc;
                txtRazonSocial.Text = oTransporte.RazonSocial;
                txtDireccion.Text = oTransporte.Direccion;

                txtUsuRegistra.Text = oTransporte.UsuarioRegistro;
                txtRegistro.Text = oTransporte.FechaRegistro.ToString();
                txtUsuModifica.Text = oTransporte.UsuarioModificacion;
                txtModifica.Text = oTransporte.FechaModificacion.ToString();

                if (!oTransporte.indEstado)
                {
                    lblestado.Text = "Se encuentra ACTIVO";
                }
                else
                {
                    lblestado.Text = "Se encuentra daddo de BAJA";
                }

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsConductores.DataSource = oTransporte.ListaConductores;
            bsConductores.ResetBindings(false);
            bsVehiculos.DataSource = oTransporte.ListaVehiculos;
            bsVehiculos.ResetBindings(false);

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oTransporte != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oTransporte = AgenteVentas.Proxy.GrabarTransporte(oTransporte, EnumOpcionGrabar.Insertar);
                            txtIdTransporte.Text = oTransporte.idTransporte.ToString("00");
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oTransporte = AgenteVentas.Proxy.GrabarTransporte(oTransporte, EnumOpcionGrabar.Actualizar);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }

                    BloquearPaneles(false);
                }

                base.Grabar();
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
            Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            BloquearPaneles(true);
            base.Editar();
            //BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
        }

        public override void Cancelar()
        {
            BloquearPaneles(false);
            base.Cancelar();
            //BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
        }

        public override void AgregarDetalle()
        {
            try
            {
                if (dgvConductores.SelectedRows.Count > Variables.Cero)
                {
                    bsConductores.EndEdit();
                    frmConductores oFrm = new frmConductores();

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oConductor != null)
                    {
                        Int32 Correlativo = Variables.Cero;

                        if (oTransporte.ListaConductores.Count > Variables.Cero)
                        {
                            Correlativo = Convert.ToInt32(oTransporte.ListaConductores.Max(mx => mx.idConductor)) + 1;
                        }
                        else
                        {
                            Correlativo = Variables.ValorUno;
                        }
                        
                        oFrm.oConductor.idConductor = Correlativo;
                        oFrm.oConductor.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                        oTransporte.ListaConductores.Add(oFrm.oConductor);
                        bsConductores.ResetBindings(false);
                    }
                }
                else if (dgvVehiculos.SelectedRows.Count > Variables.Cero)
                {
                    bsVehiculos.EndEdit();
                    frmVehiculos oFrm = new frmVehiculos();

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oVehiculo != null)
                    {
                        Int32 Correlativo = Variables.Cero;

                        if (oTransporte.ListaVehiculos.Count > Variables.Cero)
                        {
                            Correlativo = Convert.ToInt32(oTransporte.ListaVehiculos.Max(mx => mx.idVehiculo)) + 1;
                        }
                        else
                        {
                            Correlativo = Variables.ValorUno;
                        }

                        oFrm.oVehiculo.idVehiculo = Correlativo;
                        oFrm.oVehiculo.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                        oTransporte.ListaVehiculos.Add(oFrm.oVehiculo);
                        bsVehiculos.ResetBindings(false);
                    }
                }
                else if (dgvVehiculos.SelectedRows.Count == Variables.Cero && dgvConductores.SelectedRows.Count == Variables.Cero)
                {
                    frmConductores oFrm1 = new frmConductores();

                    if (oFrm1.ShowDialog() == DialogResult.OK && oFrm1.oConductor != null)
                    {
                        Int32 Correlativo = Variables.Cero;

                        if (oTransporte.ListaConductores.Count > Variables.Cero)
                        {
                            Correlativo = Convert.ToInt32(oTransporte.ListaConductores.Max(mx => mx.idConductor)) + 1;
                        }
                        else
                        {
                            Correlativo = Variables.ValorUno;
                        }

                        oFrm1.oConductor.idConductor = Correlativo;
                        oFrm1.oConductor.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                        oTransporte.ListaConductores.Add(oFrm1.oConductor);
                        bsConductores.DataSource = oTransporte.ListaConductores;
                        bsConductores.ResetBindings(false);
                    }

                    frmVehiculos oFrm2 = new frmVehiculos();

                    if (oFrm2.ShowDialog() == DialogResult.OK && oFrm2.oVehiculo != null)
                    {
                        Int32 Correlativo = Variables.Cero;

                        if (oTransporte.ListaVehiculos.Count > Variables.Cero)
                        {
                            Correlativo = Convert.ToInt32(oTransporte.ListaVehiculos.Max(mx => mx.idVehiculo)) + 1;
                        }
                        else
                        {
                            Correlativo = Variables.ValorUno;
                        }

                        oFrm2.oVehiculo.idVehiculo = Correlativo;
                        oFrm2.oVehiculo.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                        oTransporte.ListaVehiculos.Add(oFrm2.oVehiculo);
                        bsVehiculos.DataSource = oTransporte.ListaVehiculos;
                        bsVehiculos.ResetBindings(false);
                    }
                }

                base.AgregarDetalle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (dgvConductores.SelectedRows.Count > Variables.Cero)
                {
                    bsConductores.EndEdit();
                    if (dgvConductores.Rows.Count > Variables.Cero)
                    {
                        if (Global.MensajeConfirmacion("Desea anular al conductor... ?") == DialogResult.Yes)
                        {
                            Int32 reg = AgenteVentas.Proxy.AnularTransporteConductores(((TransporteConductoresE)bsConductores.Current).idTransporte, ((TransporteConductoresE)bsConductores.Current).idConductor);
                            Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                        }
                    }
                }
                else
                {
                    bsVehiculos.EndEdit();
                    if (dgvVehiculos.Rows.Count > Variables.Cero)
                    {
                        if (Global.MensajeConfirmacion("Desea anular el vehículo... ?") == DialogResult.Yes)
                        {
                            Int32 reg = AgenteVentas.Proxy.AnularTransporteVehiculos(((TransporteVehiculosE)bsVehiculos.Current).idTransporte, ((TransporteVehiculosE)bsVehiculos.Current).idVehiculo);
                            Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                        }
                    }
                }

                oTransporte = AgenteVentas.Proxy.ObtenerTransporteCompleto(oTransporte.idTransporte);
                bsConductores.DataSource = oTransporte.ListaConductores;
                bsConductores.ResetBindings(false);
                bsVehiculos.DataSource = oTransporte.ListaVehiculos;
                bsVehiculos.ResetBindings(false);

                base.QuitarDetalle();
                Modificacion = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void Cerrar()
        {
            base.Cerrar();
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<TransporteE>(oTransporte);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmTransporte_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        private void btSunat_Click(object sender, EventArgs e)
        {
            frmBuscarRuc oFrm = new frmBuscarRuc();

            if (String.IsNullOrEmpty(txtRuc.Text.Trim()) || txtRuc.Text.Length != Variables.NroCaracteresRUC)
            {
                Global.MensajeFault("Debe ingresar un numero de Ruc válido.");
                txtRuc.Focus();
                return;
            }

            oFrm.Ruc = txtRuc.Text;

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Informacion != null)
            {
                txtRuc.Text = oFrm.Ruc;
                txtRazonSocial.Text = oFrm.RazonSocial;
                txtDireccion.Text = oFrm.Direccion;;
            }
        }

        private void dgvConductores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((Boolean)dgvConductores.Rows[e.RowIndex].Cells["chkIndEstadoC"].Value == true)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado;
                }
            }

            if (e.ColumnIndex == Variables.Cero)
            {
                dgvConductores.Columns[0].DefaultCellStyle.Format = "00";
            }
        }

        private void dgvVehiculos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((Boolean)dgvVehiculos.Rows[e.RowIndex].Cells["chkIndEstadoV"].Value == true)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado;
                }
            }

            if (e.ColumnIndex == Variables.Cero)
            {
                dgvVehiculos.Columns[0].DefaultCellStyle.Format = "00";
            }
        }

        private void frmTransporte_Activated(object sender, EventArgs e)
        {
            OpcionMenu(EnumOpcionMenuBarra.AgregarDetalle);
            OpcionMenu(EnumOpcionMenuBarra.QuitarDetalle);
        }

        private void dgvConductores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditarConductor(e);
        }

        private void dgvVehiculos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditarVehiculo(e);
        }

        private void dgvConductores_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvVehiculos.ClearSelection();
        }

        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvConductores.ClearSelection();
        }

        #endregion

    }
}
