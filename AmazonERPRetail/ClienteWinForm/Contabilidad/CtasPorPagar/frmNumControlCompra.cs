using Entidades.CtasPorPagar;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmNumControlCompra : FrmMantenimientoBase
    {
        public frmNumControlCompra()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvDocumentos, true);
        }

        public frmNumControlCompra(NumControlCompraE NC)
            : this()
        {
            //Obtiene de la Cabecera Y Detalle
            ControlDocumentos = AgenteCtasPorPagar.Proxy.ObtenerNumControlCompra(NC.idEmpresa, NC.idLocal, NC.idControl);
        }

        #region Variables

        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        NumControlCompraE ControlDocumentos = null;
        List<NumControlCompraDetE> FilesEliminados = null;
        Int32 opcion = 0;

        #endregion

        #region Procedimientos de Usuario

        void NuevoRegistro()
        {
            if (ControlDocumentos == null)
            {
                ControlDocumentos = new NumControlCompraE();
                ControlDocumentos.ListaNumControlCompra = new List<NumControlCompraDetE>();

                txtCodigo.Text = Variables.Cero.ToString();
                ControlDocumentos.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                ControlDocumentos.idLocal = VariablesLocales.SesionLocal.IdLocal;
                usuarioRegistroTextBox.Text = ControlDocumentos.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                ControlDocumentos.FechaRegistro = VariablesLocales.FechaHoy;
                textBox2.Text = Convert.ToString(ControlDocumentos.FechaRegistro);
                usuarioModificacionTextBox.Text = ControlDocumentos.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                ControlDocumentos.FechaModificacion = VariablesLocales.FechaHoy;
                textBox1.Text = Convert.ToString(ControlDocumentos.FechaModificacion);
                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                if (ControlDocumentos.ListaNumControlCompra == null)
                {
                    ControlDocumentos.ListaNumControlCompra = new List<NumControlCompraDetE>();
                }

                txtCodigo.Text = ControlDocumentos.idControl.ToString("00");
                ControlDocumentos.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                ControlDocumentos.FechaModificacion = VariablesLocales.FechaHoy;

                usuarioRegistroTextBox.Text = ControlDocumentos.UsuarioRegistro;
                textBox2.Text = Convert.ToString(ControlDocumentos.FechaRegistro);
                usuarioModificacionTextBox.Text = ControlDocumentos.UsuarioModificacion;
                textBox1.Text = Convert.ToString(ControlDocumentos.FechaModificacion);
                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsNumControlCompra.DataSource = ControlDocumentos;
            bsNumControlCompra.ResetBindings(false);
            bsNumControlDet.DataSource = ControlDocumentos.ListaNumControlCompra;
            bsNumControlDet.ResetBindings(false);
            FilesEliminados = new List<NumControlCompraDetE>();

            base.Nuevo();
        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlDatos.Enabled = Flag;
            pnlDetalles.Enabled = Flag;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Grabar()
        {
            try
            {
                bsNumControlCompra.EndEdit();
                bsNumControlDet.EndEdit();

                ControlDocumentos = (NumControlCompraE)bsNumControlCompra.Current;

                if (!ValidarGrabacion()) { return; }

                if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        ControlDocumentos = AgenteCtasPorPagar.Proxy.GrabarNumControlCompra(ControlDocumentos, EnumOpcionGrabar.Insertar);
                        txtCodigo.Text = ControlDocumentos.idControl.ToString("00");
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        ControlDocumentos = AgenteCtasPorPagar.Proxy.GrabarNumControlCompra(ControlDocumentos, EnumOpcionGrabar.Actualizar);

                        if (FilesEliminados != null && FilesEliminados.Count > Variables.Cero)
                        {
                            NumControlCompraE numTmp = new NumControlCompraE();
                            numTmp = ControlDocumentos;
                            numTmp.ListaNumControlCompra = new List<NumControlCompraDetE>(FilesEliminados);

                            ControlDocumentos = AgenteCtasPorPagar.Proxy.GrabarNumControlCompra(ControlDocumentos, EnumOpcionGrabar.Actualizar);
                            FilesEliminados = new List<NumControlCompraDetE>();
                        }

                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }

                bsNumControlCompra.DataSource = ControlDocumentos;
                bsNumControlCompra.ResetBindings(false);
                bsNumControlDet.ResetBindings(false);

                //Actualizando la variable global...
                //VariablesLocales.ListaDetalleNumControlCompra = AgenteCtasPorPagar.Proxy.ListarNumControlDetPorEmpresa(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);
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
            BloquearPaneles(true);
            base.Editar();
        }

        public override void Cancelar()
        {
            bsNumControlCompra.CancelEdit();
            bsNumControlDet.CancelEdit();
            BloquearPaneles(false);
            base.Cancelar();
            pnlAuditoria.Focus();
        }

        public override void AgregarDetalle()
        {
            bsNumControlCompra.EndEdit();

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                Global.MensajeFault("Debe ingresar la descripción del documento.");
                txtDescripcion.Focus();
                return;
            }
            frmNumControlCompraDet oFrm = new frmNumControlCompraDet();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Detalle != null)
            {
                Int32 Item;
                NumControlCompraDetE detItem = oFrm.Detalle;

                if (ControlDocumentos.ListaNumControlCompra.Count > Variables.Cero)
                {
                    Item = Convert.ToInt32(ControlDocumentos.ListaNumControlCompra.Max(mx => mx.item)) + 1;
                }
                else
                {
                    Item = Variables.ValorUno;
                }

                detItem.item = Item;
                ControlDocumentos.ListaNumControlCompra.Add(detItem);

                bsNumControlDet.DataSource = ControlDocumentos.ListaNumControlCompra;
                bsNumControlDet.ResetBindings(false);
            }

            base.AgregarDetalle();
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (bsNumControlDet.Current != null)
                {
                    if (ControlDocumentos.ListaNumControlCompra != null && ControlDocumentos.ListaNumControlCompra.Count > Variables.Cero)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) != DialogResult.Yes)
                            return;

                        bsNumControlCompra.EndEdit();
                        bsNumControlDet.EndEdit();

                        NumControlCompraDetE tmp = (NumControlCompraDetE)bsNumControlDet.Current;
                        tmp.Opcion = (Int32)EnumOpcionGrabar.Eliminar;

                        FilesEliminados.Add(tmp);
                        ControlDocumentos.ListaNumControlCompra.RemoveAt(bsNumControlDet.Position);
                        bsNumControlDet.DataSource = ControlDocumentos.ListaNumControlCompra;
                        bsNumControlDet.ResetBindings(false);

                    }
                }
                base.QuitarDetalle();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            String resp = ValidarEntidad<NumControlCompraE>(ControlDocumentos);

            if (!String.IsNullOrEmpty(resp))
            {
                Global.MensajeComunicacion(resp);
                return false;
            }

            return base.ValidarGrabacion();
        }

        public override void Cerrar()
        {
            bsNumControlCompra.EndEdit();
            bsNumControlDet.EndEdit();
            base.Cerrar();
        }


        #endregion

        #region Eventos

        private void frmNumControlCompra_Load(object sender, EventArgs e)
        {
            Grid = false;
            NuevoRegistro();
            dgvDocumentos.ClearSelection();
        }

        private void frmNumControlCompra_Activated(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (bsNumControlDet.Current != null)
                {
                    NumControlCompraDetE detTmp = new NumControlCompraDetE();
                    detTmp = (NumControlCompraDetE)ControlDocumentos.ListaNumControlCompra[e.RowIndex];

                    frmNumControlCompraDet oFrm = new frmNumControlCompraDet(detTmp);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Detalle != null)
                    {
                        ControlDocumentos.ListaNumControlCompra[e.RowIndex] = oFrm.Detalle;
                        bsNumControlDet.ResetBindings(false);
                    }
                }
            }
        }

        private void bsNumControlCompra_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType.ToString() == "ItemChanged")
            {
                Modificacion = true;
            }
        }

        private void bsNumControlDet_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType.ToString() == "ItemChanged")
            {
                Modificacion = true;
            }
        }


        #endregion

    }
}
