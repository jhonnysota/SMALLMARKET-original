using Entidades.Contabilidad;
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
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad
{
    public partial class FrmPlanCuentasVersion : FrmMantenimientoBase
    {

        #region Constructores

        public FrmPlanCuentasVersion()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvEstructura, true);
            LlenarCombos();
        }

        public FrmPlanCuentasVersion(PlanCuentasVersionE PV)
            : this()
        {
            Cuentas = AgenteContabilidad.Proxy.ObtenerPlanCuentasVersionCompleto(PV.idEmpresa, PV.numVerPlanCuentas);
        }

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        PlanCuentasVersionE Cuentas = null;
        Int32 opcion = Variables.Cero;

        #endregion

        #region Procedimientos de Usuario

        void BloquearPaneles(Boolean Flag)
        {
            pnlDatos.Enabled = Flag;
            //pnlDetalles.Enabled = Flag;
        }

        void LlenarCombos()
        {
            cboIndVig.DataSource = Global.CargarSN();
            cboIndVig.ValueMember = "id";
            cboIndVig.DisplayMember = "Nombre";
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (Cuentas == null)
            {
                Cuentas = new PlanCuentasVersionE();

                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtNum.Text = Cuentas.numVerPlanCuentas.ToString();
                txtDescripcion.Text = Cuentas.Descripcion;
                cboIndVig.SelectedValue = Cuentas.indVigente;
                txtUsuRegistra.Text = Cuentas.UsuarioRegistro;
                txtRegistro.Text = Cuentas.FechaRegistro.ToString();
                txtUsuModifica.Text = Cuentas.UsuarioModificacion;
                txtModifica.Text = Cuentas.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsplanCuentasEstruc.DataSource = Cuentas.ListaEstructura;
            bsplanCuentasEstruc.ResetBindings(false);

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                Cuentas.Descripcion = txtDescripcion.Text;

                if (!ValidarGrabacion()) { return; }

                if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                {

                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        Cuentas.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        Cuentas = AgenteContabilidad.Proxy.GrabarPlanCuentasVersion(Cuentas, EnumOpcionGrabar.Insertar);
                        txtNum.Text = Cuentas.numVerPlanCuentas.ToString();
                        cboIndVig.SelectedValue = Cuentas.indVigente.ToString();
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    Cuentas.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    Cuentas = AgenteContabilidad.Proxy.GrabarPlanCuentasVersion(Cuentas, EnumOpcionGrabar.Actualizar);
                    txtNum.Text = Cuentas.numVerPlanCuentas.ToString();
                    cboIndVig.SelectedValue = Cuentas.indVigente.ToString();
                    Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                }

                base.Grabar();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }

        }

        void EditarDetalle(DataGridViewCellEventArgs e, PlanCuentasEstrucE oPlanCuentas)
        {
            FrmDetallePlanCuentasVersion oFrm = new FrmDetallePlanCuentasVersion(oPlanCuentas);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Detalle != null)
            {
                Cuentas.ListaEstructura[e.RowIndex] = oFrm.Detalle;
                bsplanCuentasEstruc.DataSource = Cuentas.ListaEstructura;
                bsplanCuentasEstruc.ResetBindings(false);
                base.AgregarDetalle();
            }
        }

        public override void AgregarDetalle()
        {
            bsplanCuentasEstruc.EndEdit();

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                Global.MensajeFault("Debe ingresar la Descripción del Plan Cuentas.");
                txtDescripcion.Focus();
                return;
            }

            Int32 tipCuenta = Convert.ToInt32(Cuentas.numVerPlanCuentas);
            FrmDetallePlanCuentasVersion oFrm = new FrmDetallePlanCuentasVersion();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Detalle != null)
            {
                String Item;
                PlanCuentasEstrucE detItem = oFrm.Detalle;

                if (Cuentas.ListaEstructura.Count > Variables.Cero)
                {
                    Item = Convert.ToString(Cuentas.ListaEstructura.Max(mx => mx.numVerPlanCuentas)) + 1;
                }
                else
                {
                    Item = null;
                }

                detItem.numVerPlanCuentas = Item;
                Cuentas.ListaEstructura.Add(detItem);

                bsplanCuentasEstruc.DataSource = Cuentas.ListaEstructura;
                bsplanCuentasEstruc.ResetBindings(false);
            }

            base.AgregarDetalle();
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (bsplanCuentasEstruc.Current != null)
                {
                    if (Cuentas.ListaEstructura != null && Cuentas.ListaEstructura.Count > Variables.Cero)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) != DialogResult.Yes)
                            return;

                        bsplanCuentasEstruc.EndEdit();

                        Cuentas.ListaEstructura.RemoveAt(bsplanCuentasEstruc.Position);
                        bsplanCuentasEstruc.DataSource = Cuentas.ListaEstructura;
                        bsplanCuentasEstruc.ResetBindings(false);

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

        private void FrmPlanCuentasVersion_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
        }

        private void dgvEstructura_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    EditarDetalle(e, (PlanCuentasEstrucE)bsplanCuentasEstruc.Current);
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
