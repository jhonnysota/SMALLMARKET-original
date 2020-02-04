using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
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
    public partial class frmEEFFItemFor : frmResponseBase
    {
        public List<EEFFItemForE> oListaFor = new List<EEFFItemForE>();

        public frmEEFFItemFor()
        {
            InitializeComponent();
        }

        public frmEEFFItemFor(List<EEFFItemForE> olista, DataTable dtIEEFFItem)
            : this()
        {

            try
            {
                ComboHelper.RellenarCombos<DataTable>(cboItem, dtIEEFFItem, "secItem", "desItem", false);

                oListaFor = olista;

                if (oListaFor.Count == 0) {

                    txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                    txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
                }

                // GRILLA 
                bsEEFFItemFor.DataSource = oListaFor;
                bsEEFFItemFor.ResetBindings(false);

                lblRegistros.Text = "Fórmulas - " + bsEEFFItemFor.Count.ToString() + " Registros";


            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }

        }

        public void AgregarDetalle()
        {
            try
            {
                String secItem = cboItem.SelectedValue.ToString();
                String desItem = cboItem.Text;
                String Operacion = cboOperacion.SelectedValue.ToString();
                Boolean oExiste = true;

                //BUSCAMOS SI EXISTE ITEM
                foreach (EEFFItemForE oItem in oListaFor)
                {
                    if (oItem.secItem == secItem)
                    {
                        oItem.TipoOperador = Operacion;
                        Global.MensajeAdvertencia("Se actualizo fórmula");
                        oExiste = false;
                    }
                }

                if (oExiste)
                {
                    EEFFItemForE oItem = new EEFFItemForE();
                    oItem.TipoOperador = Operacion;
                    oItem.secItem = secItem;
                    oItem.desItem = desItem;
                    oListaFor.Add(oItem);

                    Global.MensajeAdvertencia("Se agrego nueva fórmula");
                }

                // GRILLA 
                bsEEFFItemFor.DataSource = oListaFor;
                bsEEFFItemFor.ResetBindings(false);

            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }
        //// ===================================================================================
        //// QUITAR DETALLE
        //// ===================================================================================
        public void QuitarDetalle()
        {
            if (bsEEFFItemFor.Current != null)
            {
                if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                {
                    //base.QuitarDetalle();

                    oListaFor.RemoveAt(bsEEFFItemFor.Position);

                    bsEEFFItemFor.DataSource = oListaFor;
                    bsEEFFItemFor.ResetBindings(false);
                }
            }
        }
        // ===================================================================================
        // LOAD
        // ===================================================================================
        private void frmEEFFItemFor_Load(object sender, EventArgs e)
        {
            FormatoGrid(dgvListadoEEFF, true);
            CargarCombos();
        }
        // ===================================================================================
        // COMBOS
        // ===================================================================================
        void CargarCombos()
        {
            ComboHelper.RellenarCombos<DataTable>(cboOperacion, Global.CargarOperacionEEFFItem(), "IdOperacion", "Operacion", false);
        }

        private void frmEEFFItemFor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==27)
            {
                this.Close();
            }
        }
        // ===================================================================================
        // GRILLA CLICK
        // ===================================================================================
        private void dgvListadoEEFF_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                try
                {
                    if (bsEEFFItemFor.Count > 0)
                    {
                        EEFFItemForE oItemSeleccionado = (EEFFItemForE)bsEEFFItemFor.Current;

                        cboItem.SelectedValue = oItemSeleccionado.secItem.Trim();
                        cboOperacion.SelectedValue = oItemSeleccionado.TipoOperador.Trim();

                        if (oItemSeleccionado.idEEFFItemFor != 0)
                        {
                            // AUDITORIA
                            txtUsuRegistro.Text = oItemSeleccionado.UsuarioRegistro;
                            txtFechaRegistro.Text = oItemSeleccionado.FechaRegistro.ToString();
                            txtUsuModificacion.Text = oItemSeleccionado.UsuarioModificacion;
                            txtFechaModificacion.Text = oItemSeleccionado.FechaModificacion.ToString();
                        }
                        else 
                        {
                            txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                            txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                            txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                            txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Global.MensajeError(ex.Message);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarDetalle();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            QuitarDetalle();
        }
        // ================================
        // ACEPTAR
        // ================================
        public override void Aceptar()
        {
            try
            {
                // VALIDAMOS
                if (oListaFor == null || oListaFor.Count == 0)
                {
                    Global.MensajeFault("Debe de agregar una Fórmula");
                }
                else
                {
                    //SISTEMAS
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

    }
}
