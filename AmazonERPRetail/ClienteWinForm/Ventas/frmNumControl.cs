using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Recursos;

namespace ClienteWinForm.Ventas
{
    public partial class frmNumControl : FrmMantenimientoBase
    {

        #region Constructores

        public frmNumControl()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.AjustarResolucion(this);

            FormatoGrid(dgvDocumentos, true);
            AnchoColumnas();
            LlenarCombo();
        }

        //Edición
        public frmNumControl(NumControlE NC)
            :this()
        {
            ControlDocumentos = AgenteVentas.Proxy.ObtenerNumControlCompleto(NC.idEmpresa, NC.idLocal, NC.idControl);
        }

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        NumControlE ControlDocumentos = null;
        List<NumControlDetE> FilesEliminados = null;

        #endregion

        #region Procedimientos de Usuario

        void NuevoRegistro()
        {
            if (ControlDocumentos == null)
            {
                ControlDocumentos = new NumControlE();
                ControlDocumentos.ListaNumControl = new List<NumControlDetE>();

                txtCodigo.Text = Variables.Cero.ToString();
                ControlDocumentos.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                ControlDocumentos.idLocal = VariablesLocales.SesionLocal.IdLocal;
                ControlDocumentos.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                ControlDocumentos.FechaRegistro = VariablesLocales.FechaHoy;
                ControlDocumentos.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                ControlDocumentos.FechaModificacion = VariablesLocales.FechaHoy;

                ControlDocumentos.idTipCondicion = Variables.Cero;
            }
            else
            {
                if (ControlDocumentos.ListaNumControl == null)
                {
                    ControlDocumentos.ListaNumControl = new List<NumControlDetE>();
                }

                txtCodigo.Text = ControlDocumentos.idControl.ToString("00");
                ControlDocumentos.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                ControlDocumentos.FechaModificacion = VariablesLocales.FechaHoy;
            }

            bsNumControl.DataSource = ControlDocumentos;
            bsNumControl.ResetBindings(false);
            bsNumControlLista.DataSource = ControlDocumentos.ListaNumControl;
            bsNumControlLista.ResetBindings(false);
            FilesEliminados = new List<NumControlDetE>();

            base.Nuevo();
        }

        void LlenarCombo()
        {
            List<CondicionTipoE> ListaTipoCondicion = AgenteVentas.Proxy.ListarCondicionTipo();
            CondicionTipoE p = new CondicionTipoE();
            p.idTipCondicion = Variables.Cero;
            p.desTipCondicion = Variables.Seleccione;
            ListaTipoCondicion.Add(p);

            ComboHelper.RellenarCombos<CondicionTipoE>(cboTipoCondicion, (from x in ListaTipoCondicion orderby x.idTipCondicion select x).ToList(), "idTipCondicion", "desTipCondicion", false);
        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlDatos.Enabled = Flag;
            pnlDetalles.Enabled = Flag;
            //pnlAuditoria.Enabled = Flag;

            //BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, Flag);
            //BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, Flag);
        }

        void AnchoColumnas()
        {
            dgvDocumentos.Columns[0].Width = 20; //Item
            dgvDocumentos.Columns[1].Width = 35; //Código
            dgvDocumentos.Columns[2].Width = 200; //Descripción  
            dgvDocumentos.Columns[3].Width = 50; //Tipo
            dgvDocumentos.Columns[4].Width = 40; //Serie
            dgvDocumentos.Columns[5].Width = 70; //Número Inicio
            dgvDocumentos.Columns[6].Width = 70; //Número Final
            dgvDocumentos.Columns[7].Width = 70; //Número Correlativo
            dgvDocumentos.Columns[8].Width = 50; //Estado de la serie
            dgvDocumentos.Columns[9].Width = 100; //Nombre Impresora
            dgvDocumentos.Columns[10].Width = 90; //Usuario Registro
            dgvDocumentos.Columns[11].Width = 120; //Fecha Registro
            dgvDocumentos.Columns[12].Width = 90; //Usuario Modificación
            dgvDocumentos.Columns[13].Width = 120; //Fecha Modificación
        }

        #endregion

        #region Procedimientos Heredados

        public override void Grabar()
        {
            try
            {
                bsNumControl.EndEdit();
                bsNumControlLista.EndEdit();

                ControlDocumentos = (NumControlE)bsNumControl.Current;

                if (!ValidarGrabacion()) { return; }

                if (ControlDocumentos.idControl == Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        ControlDocumentos = AgenteVentas.Proxy.GrabarNumControl(ControlDocumentos, EnumOpcionGrabar.Insertar);
                        txtCodigo.Text = ControlDocumentos.idControl.ToString("00");
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        ControlDocumentos = AgenteVentas.Proxy.GrabarNumControl(ControlDocumentos, EnumOpcionGrabar.Actualizar);

                        if (FilesEliminados != null && FilesEliminados.Count > Variables.Cero)
                        {
                            NumControlE numTmp = new NumControlE();
                            numTmp = ControlDocumentos;
                            numTmp.ListaNumControl = new List<NumControlDetE>(FilesEliminados);

                            ControlDocumentos = AgenteVentas.Proxy.GrabarNumControl(ControlDocumentos, EnumOpcionGrabar.Actualizar);
                            FilesEliminados = new List<NumControlDetE>();
                        }

                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }

                bsNumControl.DataSource = ControlDocumentos;
                bsNumControl.ResetBindings(false);
                bsNumControlLista.ResetBindings(false);

                //Actualizando la variable global...
                VariablesLocales.ListaDetalleNumControl = AgenteVentas.Proxy.ListarNumControlDetPorEmpresa(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);
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

        public override void AgregarDetalle()
        {
            bsNumControl.EndEdit();

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                Global.MensajeFault("Debe ingresar la descripción del documento.");
                txtDescripcion.Focus();
                return;
            }

            if (Convert.ToInt32(cboTipoCondicion.SelectedValue) == Variables.Cero)
            {
                Global.MensajeFault("Debe escoger un tipo de condición...");
                cboTipoCondicion.Focus();
                return;
            }

            Int32 tipCondicion = Convert.ToInt32(ControlDocumentos.idTipCondicion);
            frmDetalleNumControl oFrm = new frmDetalleNumControl(tipCondicion);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Detalle != null)
            {
                Int32 Item;
                NumControlDetE detItem = oFrm.Detalle;

                if (ControlDocumentos.ListaNumControl.Count > Variables.Cero)
                {
                    Item = Convert.ToInt32(ControlDocumentos.ListaNumControl.Max(mx => mx.item)) + 1;
                }
                else
                {
                    Item = Variables.ValorUno;
                }

                detItem.item = Item;
                ControlDocumentos.ListaNumControl.Add(detItem);

                bsNumControlLista.DataSource = ControlDocumentos.ListaNumControl;
                bsNumControlLista.ResetBindings(false);

                base.AgregarDetalle();
            }
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (bsNumControlLista.Current != null)
                {
                    if (ControlDocumentos.ListaNumControl != null && ControlDocumentos.ListaNumControl.Count > Variables.Cero)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) != DialogResult.Yes)
                            return;

                        bsNumControl.EndEdit();
                        bsNumControlLista.EndEdit();

                        NumControlDetE tmp = (NumControlDetE)bsNumControlLista.Current;
                        tmp.Opcion = (Int32)EnumOpcionGrabar.Eliminar;

                        FilesEliminados.Add(tmp);
                        ControlDocumentos.ListaNumControl.RemoveAt(bsNumControlLista.Position);
                        //bsNumControl.ResetBindings(false);
                        bsNumControlLista.DataSource = ControlDocumentos.ListaNumControl;
                        bsNumControlLista.ResetBindings(false);

                        base.QuitarDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            String resp = ValidarEntidad<NumControlE>(ControlDocumentos);

            if (!String.IsNullOrEmpty(resp))
            {
                Global.MensajeComunicacion(resp);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmNumControl_Load(object sender, EventArgs e)
        {
            Grid = false;
            NuevoRegistro();
            dgvDocumentos.ClearSelection();
        }

        private void cboTipoCondicion_Enter(object sender, EventArgs e)
        {
            //cboTipoCondicion.DroppedDown = true;
        }

        private void frmNumControl_Activated(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (bsNumControlLista.Current != null)
                    {
                        Int32 tipCondicion = Convert.ToInt32(ControlDocumentos.idTipCondicion);
                        NumControlDetE detTmp = new NumControlDetE();
                        detTmp = (NumControlDetE)ControlDocumentos.ListaNumControl[e.RowIndex];

                        frmDetalleNumControl oFrm = new frmDetalleNumControl(detTmp, tipCondicion);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Detalle != null)
                        {
                            ControlDocumentos.ListaNumControl[e.RowIndex] = oFrm.Detalle;
                            bsNumControlLista.ResetBindings(false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsNumControl_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType.ToString() == "ItemChanged")
            {
                Modificacion = true;
            }
        }

        private void bsNumControlLista_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType.ToString() == "ItemChanged")
            {
                Modificacion = true;
            }
        }

        #endregion

    }
}
