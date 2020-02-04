using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Generales
{
    public partial class frmImpuestos : FrmMantenimientoBase
    {

        #region Constructores

        public frmImpuestos()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvDocumentos, true);
            AnchoColumnas();
        }

        public frmImpuestos(ImpuestosE NC)
            :this()
        {
            oImpuestos = AgenteGenerales.Proxy.ObtenerImpuestosCompleto(NC.idImpuesto);
        }

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        ImpuestosE oImpuestos = null;

        #endregion

        #region Procedimientos de Usuario

        void NuevoRegistro()
        {
            if (oImpuestos == null)
            {
                oImpuestos = new ImpuestosE();
                oImpuestos.listaImpuestosPeriodo = new List<ImpuestosPeriodoE>();
        
                txtIdImp.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);

                txtIdImp.Text = oImpuestos.idImpuesto.ToString();
                usuarioRegistroTextBox.Text = oImpuestos.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oImpuestos.FechaRegistro = VariablesLocales.FechaHoy;
                txtFechareg.Text = oImpuestos.FechaRegistro.ToString();
                usuarioModificacionTextBox.Text = oImpuestos.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oImpuestos.FechaModificacion = VariablesLocales.FechaHoy;
                fechamod.Text = oImpuestos.FechaModificacion.ToString();
            }
            else
            {
                if (oImpuestos.listaImpuestosPeriodo == null)
                {
                    oImpuestos.listaImpuestosPeriodo = new List<ImpuestosPeriodoE>();
                }

                txtIdImp.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtIdImp.Text = System.Convert.ToString(oImpuestos.idImpuesto);
                txtCuenta.Text = oImpuestos.codCuenta;
                txtDesCuenta.Text = oImpuestos.desCuenta;
                txtDes.Text = oImpuestos.desImpuesto;
                txtDesA.Text = oImpuestos.desAbreviatura;

                usuarioRegistroTextBox.Text = oImpuestos.UsuarioRegistro;
                txtFechareg.Text = oImpuestos.FechaRegistro.ToString();
                usuarioModificacionTextBox.Text = oImpuestos.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oImpuestos.FechaModificacion = VariablesLocales.FechaHoy;
                fechamod.Text = oImpuestos.FechaModificacion.ToString();
            } 
              
            bsImpuestosLista.DataSource = oImpuestos.listaImpuestosPeriodo;
            bsImpuestosLista.ResetBindings(false);
             
            base.Nuevo();
        }

        void GuardarDatos()
        {
            oImpuestos.idImpuesto = Convert.ToInt32(txtIdImp.Text);

            if (String.IsNullOrEmpty(oImpuestos.numVerPlanCuentas))
            {
                oImpuestos.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
            }
             
            oImpuestos.codCuenta = txtCuenta.Text;
            oImpuestos.desImpuesto = txtDes.Text;
            oImpuestos.desAbreviatura = txtDesA.Text;
        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlDatos.Enabled = Flag;
            pnlDetalles.Enabled = Flag;
        }

        void AnchoColumnas()
        {
            dgvDocumentos.Columns[0].Width = 40; //Item
            dgvDocumentos.Columns[1].Width = 70; //Código*
            dgvDocumentos.Columns[2].Width = 75; //Descripción  
            dgvDocumentos.Columns[3].Width = 90; //Serie*
            dgvDocumentos.Columns[4].Width = 90; //Usuario Registro
            dgvDocumentos.Columns[5].Width = 120; //Fecha Registro
            dgvDocumentos.Columns[6].Width = 90; //Usuario Modificacion
            dgvDocumentos.Columns[7].Width = 120; //Fecha Modificacion       
        }

        #endregion

        #region Procedimientos Heredados

        public override void Grabar()
        {
            try
            {                
                bsImpuestosLista.EndEdit();
                GuardarDatos();

                if (!ValidarGrabacion()) { return; }

                if (oImpuestos.idImpuesto == Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        oImpuestos = AgenteGenerales.Proxy.GrabarImpuestosControl(oImpuestos, EnumOpcionGrabar.Insertar);
                        txtIdImp.Text = oImpuestos.idImpuesto.ToString("00");
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        oImpuestos = AgenteGenerales.Proxy.GrabarImpuestosControl(oImpuestos, EnumOpcionGrabar.Actualizar);

                        //if (FilesEliminados != null && FilesEliminados.Count > Variables.ValorCero)
                        //{
                        //    ImpuestosE numTmp = new ImpuestosE();
                        //    numTmp = ControlDocumentos;
                        //    numTmp.listaImpuestosPeriodo = new List<ImpuestosPeriodoE>(FilesEliminados);

                        //    ControlDocumentos = AgenteGenerales.Proxy.GrabarImpuestosControl(ControlDocumentos, EnumOpcionGrabar.Actualizar);
                        //    FilesEliminados = new List<ImpuestosPeriodoE>();
                        //}

                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }

                bsImpuestosLista.DataSource = oImpuestos;            
                bsImpuestosLista.ResetBindings(false);

                base.Grabar();
                BloquearPaneles(false);
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
            bsImpuestosLista.CancelEdit();
            BloquearPaneles(false);
            base.Cancelar();
            pnlAuditoria.Focus();
        }

        public override void AgregarDetalle()
        {
            bsImpuestosLista.EndEdit();

            if (String.IsNullOrEmpty(txtIdImp.Text))
            {
                Global.MensajeFault("Debe ingresar la descripción del documento.");
                txtIdImp.Focus();
                return;
            }

            frmImpuestosDetalle oFrm = new frmImpuestosDetalle();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Detalle != null)
            {
                Int32 Item;
                ImpuestosPeriodoE detItem = oFrm.Detalle;

                if (oImpuestos.listaImpuestosPeriodo.Count > Variables.Cero)
                {
                    Item = Convert.ToInt32(oImpuestos.listaImpuestosPeriodo.Max(mx => mx.Item)) + 1;
                }
                else
                {
                    Item = Variables.ValorUno;
                }

                detItem.Item = Item;
                oImpuestos.listaImpuestosPeriodo.Add(detItem);

                bsImpuestosLista.DataSource = oImpuestos.listaImpuestosPeriodo;
                bsImpuestosLista.ResetBindings(false);
            }

            base.AgregarDetalle();
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (bsImpuestosLista.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        base.QuitarDetalle();
                        Int32 numItem = Variables.ValorUno;

                        oImpuestos.listaImpuestosPeriodo.RemoveAt(bsImpuestosLista.Position);
                        List<ImpuestosPeriodoE> ListaAuxiliar = new List<ImpuestosPeriodoE>();

                        foreach (ImpuestosPeriodoE item in oImpuestos.listaImpuestosPeriodo)
                        {
                            item.Item = numItem;
                            ListaAuxiliar.Add(item);
                            numItem++;
                        }

                        bsImpuestosLista.DataSource = oImpuestos.listaImpuestosPeriodo = ListaAuxiliar;
                        bsImpuestosLista.ResetBindings(false);
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
            String resp = ValidarEntidad<ImpuestosE>(oImpuestos);

            if (!String.IsNullOrEmpty(resp))
            {
                Global.MensajeComunicacion(resp);
                return false;
            }

            if (String.IsNullOrEmpty(VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas))
            {
                Global.MensajeFault("No se ha definido una estructura para el Plan de Cuentas...");
                return false;
            }

            return base.ValidarGrabacion();
        }

        public override void Cerrar()
        {
            bsImpuestosLista.EndEdit();
            base.Cerrar();
        }

        #endregion

        #region Eventos

        private void frmImpuestos_Load(object sender, EventArgs e)
        {
            Grid = false;
            NuevoRegistro();
            dgvDocumentos.ClearSelection();
        }

        private void bsImpuestosLista_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType.ToString() == "ItemChanged")
            {
                Modificacion = true;
            }
        }

        private void frmImpuestos_Activated(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
        }

        private void dgvDocumentos_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (bsImpuestosLista.Current != null)
                {
                    ImpuestosPeriodoE detTmp = new ImpuestosPeriodoE();
                    detTmp = (ImpuestosPeriodoE)oImpuestos.listaImpuestosPeriodo[e.RowIndex];

                    frmImpuestosDetalle oFrm = new frmImpuestosDetalle(detTmp);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Detalle != null)
                    {
                        oImpuestos.listaImpuestosPeriodo[e.RowIndex] = oFrm.Detalle;
                        bsImpuestosLista.ResetBindings(false);
                    }
                }
            }
        }

        private void btCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCuentas oFrm = new frmBuscarCuentas();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Cuentas != null)
                {
                    txtCuenta.Text = oFrm.Cuentas.codCuenta;
                    txtDesCuenta.Text = oFrm.Cuentas.Descripcion;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

    }
}
