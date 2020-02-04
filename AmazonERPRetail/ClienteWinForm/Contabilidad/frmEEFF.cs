using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Infraestructura.Winform;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Recursos;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmEEFF : FrmMantenimientoBase
    {

        #region Constructores

        public frmEEFF()
        {
            InitializeComponent();

            FormatoGrid(dgvListadoEEFF, true);
            entidad = new EEFFE();
            entidad.idEEFF = 0;
            entidad.idEmpresa = 0;  
        }

        public frmEEFF(Int32 idEmpresa, Int32 idEEFF)
            : this()
        {
            try
            {
                entidad = AgenteContabilidad.Proxy.ObtenerEEFFCompleto(idEmpresa, idEEFF);

                if (entidad.ListaEEFFItem != null)
                {
                    DataTable oTabla1 = Global.CargarTipoTablaEEFFItem();
                    DataTable oTabla2 = Global.CargarTipoCaracteristicaEEFFItem();

                    foreach (EEFFItemE oItem in entidad.ListaEEFFItem)
                    {
                        foreach (DataRow row in oTabla1.Rows)
                        {
                            if (oItem.TipoTabla == row[0].ToString())
                            {
                                oItem.desTabla = row[1].ToString();
                            }
                        }
                        foreach (DataRow row in oTabla2.Rows)
                        {
                            if (oItem.TipoCaracteristica == row[0].ToString())
                            {
                                oItem.desCaracteristica = row[1].ToString();
                            }
                        }
                    }
                }

                // DATOS EEFF
                txtTipoSeccion.Text = entidad.TipoSeccion;
                txtdesSeccion.Text = entidad.desSeccion;

                // DATOS SISTEMA
                txtUsuRegistro.Text = entidad.UsuarioRegistro;
                txtFechaRegistro.Text = entidad.FechaRegistro.ToString();
                txtUsuModificacion.Text = entidad.UsuarioModificacion;
                txtFechaModificacion.Text = entidad.FechaModificacion.ToString();

                // CHECKBOX
                chbComparativo.Checked = entidad.indComparativo;
                chbCCostos.Checked = (entidad.indcCostos == "True" ? true : false);
                chbVerReporte.Checked = (entidad.VerReporte == "True" ? true : false);

                // DATOS GRILLA 
                bsEEFFItem.DataSource = entidad.ListaEEFFItem;
                bsEEFFItem.ResetBindings(false);

                lblRegistros.Text = "Items - " + bsEEFFItem.Count.ToString() + " Registros";
                txtTipoSeccion.Focus();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        EEFFE entidad = null;
        EEFFItemE oItemSel = null;

        #endregion 

        #region Procedimientos de Usuario

        void CargarCombos()
        {
            ComboHelper.RellenarCombos<DataTable>(cboTipoReporte, Global.CargarTipoReporteEEFF(), "IdTipoReporte", "TipoReporte", false);
        }

        Boolean validaExite()
        {
            Boolean result = true;
            List<EEFFE> oValida = AgenteContabilidad.Proxy.ListarEEFF(entidad.idEmpresa, entidad.idEEFF, txtdesSeccion.Text.Trim(), false);

            if (oValida.Count > 0)
            {
                if (entidad.idEEFF == 0 && entidad.idEmpresa == 0)
                {
                    if (oValida.Count == 0)
                        result = false;
                }
                else
                {
                    if (((EEFFE)oValida[0]).idEEFF == entidad.idEEFF && ((EEFFE)oValida[0]).idEmpresa == entidad.idEmpresa)
                        result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        public DataTable TablaEEFFItem(List<EEFFItemE> oLista)
         {
             DataTable output = new DataTable();
             output.Columns.Add("IdEmpresa");
             output.Columns.Add("IdEEFF");
             output.Columns.Add("IdEEFFItem");
             output.Columns.Add("EEFFItem");
             output.Columns.Add("secItem");
             output.Columns.Add("desItem");

             DataRow dt;

             foreach (EEFFItemE oItem in oLista)
             {
                 dt = output.NewRow();
                 dt["IdEmpresa"] = oItem.idEmpresa;
                 dt["IdEEFF"] = oItem.idEEFF;
                 dt["IdEEFFItem"] = oItem.idEEFFItem;
                 dt["EEFFItem"] = oItem.secItem + " - " + oItem.desItem;
                 dt["secItem"] = oItem.secItem;
                 dt["desItem"] = oItem.desItem;
                 output.Rows.Add(dt);
             }

             return output;
         }

        void MostrarBotonGrilla() 
        {
            foreach (DataGridViewRow row in dgvListadoEEFF.Rows)
            {
                DataGridViewTextBoxCell TipoTabla = (DataGridViewTextBoxCell)row.Cells[5];

                if (TipoTabla.Value.ToString().Equals("TIT"))
                {
                    //DataGridViewButtonCell btn = (DataGridViewButtonCell)row.Cells[9];
                    //DataGridViewTextBoxCell btn2 = new DataGridViewTextBoxCell();
                    //row.Cells[9] = btn2;
                }

                DataGridViewTextBoxCell EnviaXls = (DataGridViewTextBoxCell)row.Cells[13];

                if (EnviaXls.Value.ToString().Equals("False"))
                {
                    DataGridViewButtonCell btn = (DataGridViewButtonCell)row.Cells[10];
                    DataGridViewTextBoxCell btn2 = new DataGridViewTextBoxCell();
                    row.Cells[10] = btn2;
                }  
            }
        }

        public void Agregar(EEFFItemE oEEFFItem)
        {
            bsEEFFItem.DataSource = null;
            Boolean Existe = true;

            if (entidad.ListaEEFFItem != null)
            {
                foreach (EEFFItemE item in entidad.ListaEEFFItem)
                {
                    // EXISTE
                   // if (item.secItem == oEEFFItem.secItem)
                    if (item.idEEFFItem == oEEFFItem.idEEFFItem)
                    {
                        item.secItem = oEEFFItem.secItem;
                        item.desItem = oEEFFItem.desItem;
                        item.TipoTabla = oEEFFItem.TipoTabla;
                        item.TipoCaracteristica = oEEFFItem.TipoCaracteristica;

                        item.TipoItem = oEEFFItem.TipoItem;
                        item.TipoColumna = oEEFFItem.TipoColumna;

                        item.desTabla = oEEFFItem.desTabla;
                        item.desCaracteristica = oEEFFItem.desCaracteristica;
                        item.codSunat = oEEFFItem.codSunat;

                        item.indImprimir = oEEFFItem.indImprimir;
                        item.indPorcentaje = oEEFFItem.indPorcentaje;
                        item.indEnviaExcel = oEEFFItem.indEnviaExcel;
                        item.indMostrar = oEEFFItem.indMostrar;

                        oEEFFItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        oEEFFItem.FechaModificacion = VariablesLocales.FechaHoy;

                        Existe = false;
                    }
                }
            }
            else
            {
                entidad.ListaEEFFItem = new List<EEFFItemE>();
            }

            //NO EXISTE
            if (Existe)
            {
                oEEFFItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oEEFFItem.FechaRegistro = VariablesLocales.FechaHoy;
                entidad.ListaEEFFItem.Add(oEEFFItem);
            }

            // SISTEMA
            bsEEFFItem.DataSource = entidad.ListaEEFFItem;
            bsEEFFItem.ResetBindings(false);
        }

        #endregion

        #region Procedimientos Heredadas

        public override void Editar()
        {
            try
            {
                if (bsEEFFItem.Count > 0)
                {
                    // FORMULARIO
                    frmEEFFItem oFrm = new frmEEFFItem(((EEFFItemE)bsEEFFItem.Current));

                    // CIERRE FORMULARIO
                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        Agregar(oFrm.oEEFFItem);
                        MostrarBotonGrilla();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void AgregarDetalle()
        {
            try
            {
                //FORMULARIO
                frmEEFFItem oFrm = new frmEEFFItem(entidad.ListaEEFFItem);

                // CIERRE FORMULARIO
                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    Agregar(oFrm.oEEFFItem);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            if (bsEEFFItem.Current != null)
            {
                if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                {
                    base.QuitarDetalle();
                    entidad.ListaEEFFItem.RemoveAt(bsEEFFItem.Position);
                    bsEEFFItem.DataSource = entidad.ListaEEFFItem;
                    bsEEFFItem.ResetBindings(false);

                    MostrarBotonGrilla();
                }
            }
        }

        public override void Grabar()
        {
            try
            {
                // VALIDAMOS DATA
                if (txtTipoSeccion.Text.Trim().Length == 0)
                {
                    Global.MensajeAdvertencia("Debe de ingresar el Tipo de sección");
                    txtTipoSeccion.Focus();
                }
                else if (txtdesSeccion.Text.Trim().Length == 0)
                {
                    Global.MensajeAdvertencia("Debe de ingresar la descripción de sección");
                    txtdesSeccion.Focus();
                }
                else if (validaExite())
                {
                    Global.MensajeAdvertencia("La descripción ya esta ingresada");
                    txtdesSeccion.Focus();
                }
                else
                {
                    // CARGAMOS VARIABLES
                    entidad.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    entidad.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    entidad.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    entidad.TipoSeccion = txtTipoSeccion.Text;
                    entidad.desSeccion = txtdesSeccion.Text;
                    entidad.tipoReporte = cboTipoReporte.SelectedValue.ToString();
                    entidad.indComparativo = chbComparativo.Checked;
                    entidad.indcCostos = (chbCCostos.Checked ? "True" : "False");
                    entidad.VerReporte = (chbVerReporte.Checked ? "True" : "False");

                    Boolean isNuevo=false;

                    if (entidad.idEEFF == 0)
                        isNuevo = true;

                    // ACTUALIZAR SQL
                    AgenteContabilidad.Proxy.GuardarEEFF(entidad);

                    //MENSAJE
                    if (isNuevo)
                    {
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                    else
                    {
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }

                    // SISTEMA
                    base.Grabar();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion 

        #region Eventos

        private void frmEEFF_Load(object sender, EventArgs e)
        {
            Grid = false;
            base.Nuevo();
            base.AgregarDetalle();

            CargarCombos();

            if (entidad.idEEFF != 0)
            {
                cboTipoReporte.SelectedValue = entidad.tipoReporte.Trim();
            }
            else
            {
                txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }

            MostrarBotonGrilla();
        }

        private void dgvListadoEEFF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void dgvListadoEEFF_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            oItemSel = ((EEFFItemE)bsEEFFItem.Current);
            
            #region XLS

            if (dgvListadoEEFF.Columns[e.ColumnIndex].Name == "btnXls")
            {
                if (oItemSel.indEnviaExcel.Equals("True"))
                {
                    if (oItemSel.ListaEEFFItemXls == null)
                    {
                        oItemSel.ListaEEFFItemXls = AgenteContabilidad.Proxy.ListarEEFFItemXls(oItemSel.idEmpresa, oItemSel.idEEFF, oItemSel.idEEFFItem);
                    }

                    frmEEFFItemXls oFrm = new frmEEFFItemXls(oItemSel.ListaEEFFItemXls);
                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing_Xls);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        
                    }
                }
            }
            
            #endregion 

            if (dgvListadoEEFF.Columns[e.ColumnIndex].Name == "btnDetalle")
            {   
                #region CTA

                if (oItemSel.TipoTabla == "DET")
                {
                    if (oItemSel.ListaEEFFItemCta == null)
                    {
                        oItemSel.ListaEEFFItemCta = AgenteContabilidad.Proxy.ListarEEFFItemCta(oItemSel.idEmpresa, oItemSel.idEEFF, oItemSel.idEEFFItem, 0, "", "");
                    }

                    frmEEFFItemCta oFrm = new frmEEFFItemCta(oItemSel.ListaEEFFItemCta);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
                
                #endregion

                #region Formúla

                if (oItemSel.TipoTabla == "TOT")
                {
                    if (oItemSel.ListaEEFFItemFor == null)
                    {
                        oItemSel.ListaEEFFItemFor = AgenteContabilidad.Proxy.ListarEEFFItemFor(oItemSel.idEmpresa, oItemSel.idEEFF, oItemSel.idEEFFItem);
                    }
                    else
                    {
                        if (oItemSel.ListaEEFFItemFor.Count == 0)
                        {
                            oItemSel.ListaEEFFItemFor = AgenteContabilidad.Proxy.ListarEEFFItemFor(oItemSel.idEmpresa, oItemSel.idEEFF, oItemSel.idEEFFItem);
                        }
                    }

                    frmEEFFItemFor oFrm = new frmEEFFItemFor(oItemSel.ListaEEFFItemFor, TablaEEFFItem(entidad.ListaEEFFItem));

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
                
                #endregion
            }
        }
      
        #region Eventos Closing

        private void oFrm_FormClosing_Xls(Object sender, FormClosingEventArgs e)
        {
            frmEEFFItemXls oFrm = sender as frmEEFFItemXls;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                foreach (EEFFItemE oItem in entidad.ListaEEFFItem)
                {
                    if (oItem.secItem == oItemSel.secItem)
                    {
                        oItem.ListaEEFFItemXls = oFrm.oListaXls;
                    }
                }
            }
        }

        private void oFrm_FormClosing_Cta(Object sender, FormClosingEventArgs e)
        {
            frmEEFFItemCta oFrm = sender as frmEEFFItemCta;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                foreach (EEFFItemE oItem in entidad.ListaEEFFItem)
                {

                    if (oItem.secItem == oItemSel.secItem)
                    {

                        oItem.ListaEEFFItemCta = oFrm.oListaCta;
                    }
                }
            }
        }

        private void oFrm_FormClosing_For(Object sender, FormClosingEventArgs e)
        {
            frmEEFFItemFor oFrm = sender as frmEEFFItemFor;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                foreach(EEFFItemE oItem in entidad.ListaEEFFItem) {

                    if (oItem.secItem == oItemSel.secItem) {

                        oItem.ListaEEFFItemFor = oFrm.oListaFor;
                    }
                }
            }
        }

        #endregion

        private void frmEEFF_Shown(object sender, EventArgs e)
        {
            txtTipoSeccion.Focus();
        }

        private void dgvListadoEEFF_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                dgvListadoEEFF.Columns[1].DefaultCellStyle.Format = "";
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

        #endregion

    }
}
 