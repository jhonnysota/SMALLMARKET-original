using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using Entidades.Contabilidad;
using ClienteWinForm.Busquedas;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Recursos;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmEEFFItemCta : frmResponseBase
    {

        #region Contructores

        public frmEEFFItemCta()
        {
            InitializeComponent();
        }

        public frmEEFFItemCta(List<EEFFItemCtaE> olista)
            : this()
        {
            try
            {
                oListaCta = olista;
                DataTable oTablaDigitos = Global.CargarDigitosEEFF();

                foreach (EEFFItemCtaE oItemCta in oListaCta)
                {
                    foreach (DataRow row in oTablaDigitos.Rows)
                    {
                        if (oItemCta.TipoNivel.Equals(row[0].ToString()))
                        {
                            oItemCta.DesNivel = row[1].ToString();
                        }
                    }
                }

                if (oListaCta.Count == 0)
                {

                    txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                    txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
                }
                // GRILLA 
                bsEEFFItemCta.DataSource = oListaCta;
                bsEEFFItemCta.ResetBindings(false);

                lblRegistros.Text = "Items - " + bsEEFFItemCta.Count.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        } 

        #endregion

        public List<EEFFItemCtaE> oListaCta = new List<EEFFItemCtaE>();

        private void frmEEFFItemCta_Load(object sender, EventArgs e)
        {
            //Grid = false;
            FormatoGrid(dgvListadoEEFF, true);

            if (oListaCta.Count == 0)
            {
                txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }

            CargarCombos();
        }
        
        public void AgregarDetalle()
        {
            try
            {
                String Condicion = cboCondicion.SelectedValue.ToString();
                String Nivel = cboNivel.SelectedValue.ToString();
                String desNivel = cboNivel.Text;
                String CodCta = txtCuenta.Text;
                String DesCta = txtDesCuenta.Text;
                Boolean oExiste = true;

                // VALIDAMOS
                if (CodCta.Length == 0) 
                {
                    Global.MensajeAdvertencia("Debe de ingresar la Cuenta");
                    txtCuenta.Focus();
                }
                else 
                { 
                    //BUSCAMOS SI EXISTE ITEM
                    foreach (EEFFItemCtaE oItem in oListaCta)
                    {
                        if (oItem.CodPlaCta == CodCta)
                        {
                            oItem.TipoNivel = Nivel;
                            oItem.TipoCondicion = Condicion;
                            oItem.desCuenta = DesCta;
                            oItem.DesNivel = desNivel;
                            oItem.NumPlaCta = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;

                            Global.MensajeAdvertencia("Se actualizo la cuenta");
                            oExiste = false;
                        }
                    }

                    if (oExiste)
                    {
                        EEFFItemCtaE oItem = new EEFFItemCtaE();

                        oItem.TipoNivel = Nivel;
                        oItem.TipoCondicion = Condicion;
                        oItem.desCuenta = DesCta;
                        oItem.CodPlaCta = CodCta;
                        oItem.DesNivel = desNivel;
                        oItem.NumPlaCta = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;

                        oListaCta.Add(oItem);

                        Global.MensajeAdvertencia("Se agrego nueva cuenta");
                    }

                    // GRILLA 
                    bsEEFFItemCta.DataSource = oListaCta;
                    bsEEFFItemCta.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public void QuitarDetalle()
        {
            if (bsEEFFItemCta.Current != null)
            {
                if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                {
                    oListaCta.RemoveAt(bsEEFFItemCta.Position);
                    bsEEFFItemCta.DataSource = oListaCta;
                    bsEEFFItemCta.ResetBindings(false);
                }
            }
        }

        public override void Aceptar()
        {
            try
            {
                // VALIDAMOS
                if (oListaCta == null || oListaCta.Count == 0)
                {
                    Global.MensajeFault("Debe de agregar una Cuenta");
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

        void CargarCombos()
        {
            ComboHelper.RellenarCombos<DataTable>(cboCondicion, Global.CargarCondicionEEFFItem(), "IdCondicion", "Condicion", false);
            ComboHelper.RellenarCombos<DataTable>(cboNivel, Global.CargarDigitosEEFF(), "IdDigito", "Digito", false);
        }

        private void frmEEFFItemCta_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 27)
            //{
            //    this.Close();
            //}
        }

        private void dgvListadoEEFF_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                try
                {
                    if (bsEEFFItemCta.Count > 0)
                    {
                        EEFFItemCtaE oItemSeleccionado = (EEFFItemCtaE)bsEEFFItemCta.Current;

                        cboCondicion.SelectedValue = oItemSeleccionado.TipoCondicion.Trim();
                        cboNivel.SelectedValue = oItemSeleccionado.TipoNivel.Trim();

                        txtCuenta.Text = oItemSeleccionado.CodPlaCta;
                        txtDesCuenta.Text = oItemSeleccionado.desCuenta;

                        if (oItemSeleccionado.idEEFFItemCta != 0)
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

        private void btCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCuentas oFrmCuenta = new frmBuscarCuentas();

                if (oFrmCuenta.ShowDialog() == DialogResult.OK && oFrmCuenta.Cuentas != null)
                {
                    txtCuenta.Text = oFrmCuenta.Cuentas.codCuenta;
                    txtDesCuenta.Text = oFrmCuenta.Cuentas.Descripcion;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

    }
}
