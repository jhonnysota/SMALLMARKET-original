using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClienteWinForm.Busquedas;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Presentadora.AgenteServicio;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmEEFFItemXls : frmResponseBase
    {

        // ===================================================================================
        // VARIABLES
        // ===================================================================================
        public List<EEFFItemXlsE> oListaXls = new List<EEFFItemXlsE> ();
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        // ================================
        // ACEPTAR
        // ================================
        public override void Aceptar()
        {
            try
            {
                // VALIDAMOS
                if (oListaXls == null || oListaXls.Count == 0)
                {
                    Global.MensajeFault("Debe de agregar un Centro de Costos");
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

        // ======================================
        // CONSTRUCTOR 
        // ======================================
        public frmEEFFItemXls()
        {
            InitializeComponent();
            
        }


        // ============================================
        // LOAD
        // ============================================
        private void frmEEFFItemXls_Load(object sender, EventArgs e)
        {
            //Grid = false;
            FormatoGrid(dgvListadoEEFFitemXls, true);

            //base.AgregarDetalle();
            //base.QuitarDetalle();

            //BloquearOpcion(EnumOpcionMenuBarra.Grabar, false);
            //BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);


            if (oListaXls.Count == 0)
            {

                txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }


            //base.Modificacion = false;

            //ColorGrilla();

        }
        // ===============================================
        // AGREGAR DETALLE
        // ===============================================
        public void AgregarDetalle()
        {
            try
            {

                //base.Modificacion = false;

                String CodCCostos = txtCCostos.Text;
                String desCCostos = "";
               

                Boolean oExiste = true;

                // VALIDAMOS
                if (CodCCostos.Length == 0)
                {
                    Global.MensajeAdvertencia("Debe de ingresar el centro de costos");
                    txtCCostos.Focus();
                }
                else
                {
                    CCostosE oCCosto = ObtenerCCostos(txtCCostos.Text);

                    if (oCCosto != null)
                    {
                        desCCostos = oCCosto.desCCostos;

                        //BUSCAMOS SI EXISTE ITEM
                        foreach (EEFFItemXlsE oItem in oListaXls)
                        {
                            if (oItem.codcCostos == CodCCostos)
                            {

                                if (Global.MensajeConfirmacion("El centro de costos ya existe, desea reemplazarlo") == DialogResult.Yes)
                                {
                                    oItem.fila = 0;
                                    oItem.columna = 0;

                                    Global.MensajeAdvertencia("Se actualizo la cuenta");
                                }
                                oExiste = false;
                            }
                        }

                        if (oExiste)
                        {
                            EEFFItemXlsE oItem = new EEFFItemXlsE();

                            oItem.codcCostos = CodCCostos;
                            oItem.descCostos = desCCostos;
                            oItem.fila = 0;
                            oItem.columna = 0;

                            oListaXls.Add(oItem);

                            Global.MensajeAdvertencia("Se agrego nuevo centro de costos");
                        }

                        // GRILLA 
                        bsEEFFItemXls.DataSource = oListaXls;
                        bsEEFFItemXls.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        // =============================================
        // QUITAR DETALLE
        // =============================================
        public void QuitarDetalle()
        {
            //base.Modificacion = false;

            if (bsEEFFItemXls.Current != null)
            {
                if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                {

                    

                    oListaXls.RemoveAt(bsEEFFItemXls.Position);

                    bsEEFFItemXls.DataSource = oListaXls;
                    bsEEFFItemXls.ResetBindings(false);

                }
            }
        }

        // ======================================
        // KEYPRESS ENTER
        // ======================================
        private void txtCCostos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CCostosE oCCosto = ObtenerCCostos(txtCCostos.Text);
                if (oCCosto != null)
                {
                    txtCCostos.Text = oCCosto.idCCostos;
                    txtDesCCostos.Text = oCCosto.desCCostos;
                }
                
            }
        }

        // ======================================
        // OBTENER 
        // ======================================
        CCostosE ObtenerCCostos(String CodCCostos){
            if (CodCCostos.Trim().Length > 0)
            {
                CCostosE oCCosto = AgenteMaestro.Proxy.ObtenerCCostos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, CodCCostos);

                if (oCCosto != null)
                {
                    return oCCosto;
                }
                else
                {
                    Global.MensajeAdvertencia("El centro de costos no existe");
                    txtCCostos.Focus();
                    return null;
                }

            }
            else
            {
                Global.MensajeAdvertencia("No ha ingreso el centro de costos");
                txtCCostos.Focus();
                return null;
            }
            
            
        }

        // =================================================
        // CONSTRUCTOR
        // =================================================
        public frmEEFFItemXls(List<EEFFItemXlsE> oLista)
            :this()
        {

            try
            {
                oListaXls = oLista;

                ActualizarDatos();

            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }

        }
        void ActualizarDatos()
        {
            // DATOS GRILLA 
            bsEEFFItemXls.DataSource = oListaXls;
            bsEEFFItemXls.ResetBindings(false);

            lblRegistros.Text = "Configuración - " + bsEEFFItemXls.Count.ToString() + " Registros";
        }
        // ============================================
        // KESPRESS
        // ============================================
        private void frmEEFFItemXls_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }


        void ColorGrilla() {

            foreach (DataGridViewRow row in dgvListadoEEFFitemXls.Rows)
            {
                DataGridViewTextBoxCell fila = (DataGridViewTextBoxCell)row.Cells[6];

                fila.Style.BackColor = Color.Yellow;

                row.Cells[6] = fila;
                /*
                DataGridViewTextBoxCell columna = (DataGridViewTextBoxCell)row.Cells[6];

                columna.Style.BackColor = Color.Yellow;

                row.Cells[7] = columna;*/

            }
        }
        // ==================================================
        // GRILLA CLICK
        // ==================================================
        private void dgvListadoEEFF_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                try
                {
                    if (bsEEFFItemXls.Count > 0)
                    {
                        EEFFItemXlsE oItemSeleccionado = (EEFFItemXlsE)bsEEFFItemXls.Current;

                        if (oItemSeleccionado.idEEFFItemXls != 0)
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

        // ============================================
        // AGREGAR TODOS
        // ============================================

        private void btnAgregarTodosCCostos_Click(object sender, EventArgs e)
        {
            List<CCostosE> ListaCostos  = AgenteMaestro.Proxy.ListarCCostosPorNivel(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,1);

            if (oListaXls.Count == 0 || Global.MensajeConfirmacion("Se perderan los datos actuales, desea continuar ?") == DialogResult.Yes)
            {
                AgregarTodos(ListaCostos);
            }
            /*else {
                if (Global.MensajeConfirmacion("Se perderan los datos actuales, desea continuar ?") == DialogResult.Yes) {
                    AgregarTodos(ListaCostos);
                }
            }*/
        }

        void AgregarTodos(List<CCostosE> ListaCostos)
        {
            oListaXls = null;
            oListaXls = new List<EEFFItemXlsE>();

            foreach(CCostosE oItemCostos in ListaCostos)
            {
                EEFFItemXlsE oItem = new EEFFItemXlsE();

                oItem.idEEFFItemXls = 0;
                oItem.codcCostos = oItemCostos.idCCostos;
                oItem.descCostos = oItemCostos.desCCostos;
                oItem.fila = 0;
                oItem.columna = 0;

                oListaXls.Add(oItem);
            }

            ActualizarDatos();
        }
        // ============================================
        // SHOW
        // ============================================
        private void frmEEFFItemXls_Shown(object sender, EventArgs e)
        {
            txtCCostos.Focus();
        }

        private void btCCosto_Click(object sender, EventArgs e)
        {
            FrmBusquedaCentroDeCosto oFrm = new FrmBusquedaCentroDeCosto();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.CentroCosto != null)
            {
                txtCCostos.Text = oFrm.CentroCosto.idCCostos;
                txtDesCCostos.Text = oFrm.CentroCosto.desCCostos;
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
        
        
        // ============================================
        // END
        // ============================================
    }
}
