using Entidades.Contabilidad;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
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
    public partial class frmPlanContableUsuario : FrmMantenimientoBase
    {
        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }

        List<PlanCuentasDifCambioUsuarioE> oListaPlanCuentasNoAsignadas;
        List<PlanCuentasDifCambioUsuarioE> oListaPlanCuentasAsignadas;
        Boolean Ordenar = false;

        #endregion

        public frmPlanContableUsuario()
        {
            InitializeComponent();

            FormatoGrid(dgvListaCuentas, false);
            FormatoGrid(dgvListaUsuario, false);
        }


        private void frmPlanContableUsuario_Load(object sender, EventArgs e)
        {
            

            Grid = true;
          
            BloquearOpcion(EnumOpcionMenuBarra.Grabar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);

            List<Usuario> ListaTipoComprobante = AgenteSeguridad.Proxy.ListarUsuarioPorEmpresa(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 0, "", "-1");
            List<Usuario> listatipocompalign = new List<Usuario>();
            string a = string.Empty;
            foreach (Usuario item in ListaTipoComprobante)
            {
                
                if (a != item.NombreCompleto)
                {
                    listatipocompalign.Add(item);
                }
                a = item.NombreCompleto;

               
            }
            ComboHelper.RellenarCombos<Usuario>(cboUsuario, listatipocompalign, "Credencial", "NombreCompleto", false);

            LlenarDocumentosGrid();

            string Credenciales = VariablesLocales.SesionUsuario.Credencial;

            cboUsuario.SelectedValue = Credenciales.Trim();

            CargarDatos(Credenciales);

        }

        void LlenarDocumentosGrid()
        {
            DataGridViewComboBoxColumn cbo01 = dgvListaUsuario.Columns["numFile"] as DataGridViewComboBoxColumn;
            //DataGridViewComboBoxColumn cbo02 = dgvListaCuentas.Columns["dgvCboFile02"] as DataGridViewComboBoxColumn;

            int idEmpresa =  VariablesLocales.SesionLocal.IdEmpresa;
            List<ComprobantesE> oListaComprobante = AgenteContabilidad.Proxy.ListarComprobantes(idEmpresa);
            oListaComprobante = oListaComprobante.Where(x => x.Descripcion.Contains("AJUSTE")==true).ToList();
            string idComprobante = oListaComprobante[0].idComprobante;

            
            List<ComprobantesFileE> ListaFiles = AgenteContabilidad.Proxy.ObtenerFilesPorIdComprobante(idEmpresa, idComprobante);
            
            ComprobantesFileE File = new ComprobantesFileE();
            File.numFile = Variables.Cero.ToString();
            File.Descripcion = "Ninguno";
            ListaFiles.Add(File);

            //ComboHelper.RellenarCombos<ComprobantesFileE>(cbo01, ListaFiles.OrderBy(x=>x.numFile).ToList(), "numFile", "Descripcion", false);
            //ComboHelper.RellenarCombos<ComprobantesFileE>(cbo02, ListaFiles.OrderBy(x => x.numFile).ToList(), "numFile", "Descripcion", false);
            ComboHelper.RellenarCombos<ComprobantesFileE>(cbo01, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "Descripcion", false);
            //ComboHelper.RellenarCombos<ComprobantesFileE>(cbo02, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "Descripcion", false);
        }

        void CargarDatos(string Credenciales)
        {
            oListaPlanCuentasNoAsignadas = new List<PlanCuentasDifCambioUsuarioE>();
            oListaPlanCuentasAsignadas = new List<PlanCuentasDifCambioUsuarioE>();

            int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            string PlanCuenta = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;


            List<PlanCuentasDifCambioUsuarioE> oListaPlanCuentas = AgenteContabilidad.Proxy.ListarPlanCuentasDifCambioUsuario(idEmpresa, PlanCuenta, "");

            oListaPlanCuentasNoAsignadas = oListaPlanCuentas.Where(x => x.UsuarioAsignado != Credenciales).OrderBy(x => x.codCuenta).ToList();
            oListaPlanCuentasAsignadas = AgenteContabilidad.Proxy.ObtenerPlanCuentasDifCambioUsuario(idEmpresa, PlanCuenta, Credenciales);

            bsCuentas.DataSource = oListaPlanCuentasNoAsignadas;
            bsCuentas.ResetBindings(false);
            bsCuentasUsuario.DataSource = oListaPlanCuentasAsignadas.OrderBy(x => x.codCuenta).ToList();
            bsCuentasUsuario.ResetBindings(false);

            lblRegistros.Text = "Cuentas - " + oListaPlanCuentasNoAsignadas.Count.ToString() + " Registros";
            lblRegistrosUsuario.Text = "Cuentas Asignadas - " + oListaPlanCuentasAsignadas.Count.ToString() + " Registros";

            Filtrar();
        }

        public override void Grabar()
        {
            try
            {
                if (oListaPlanCuentasAsignadas == null || oListaPlanCuentasAsignadas.Count == 0)
                {
                    Global.MensajeFault("No hay datos");
                    return;
                }

                if (Global.MensajeConfirmacion("Esta seguro grabar los datos") == DialogResult.Yes)
                {
                    foreach(PlanCuentasDifCambioUsuarioE Item in oListaPlanCuentasAsignadas)
                    {
                        Item.UsuarioAsignado = cboUsuario.SelectedValue.ToString();
                        Item.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    }

                    AgenteContabilidad.Proxy.GuardaPlanCuentasDifCambioUsuario(oListaPlanCuentasAsignadas);

                    Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Buscar()
        {
            try
            {
                if (Global.MensajeConfirmacion("Esta seguro de volver a cargar, se perderan los cambios realizados") == DialogResult.Yes)
                {
                    CargarDatos(cboUsuario.SelectedValue.ToString());
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
                if (bsCuentas.Current != null)
                {
                    if (bsCuentas.Count > 0)
                    {
                        
                        // OBTIENE SELECCIONADO
                        PlanCuentasDifCambioUsuarioE oCuentaSeleccionada = (PlanCuentasDifCambioUsuarioE)bsCuentas.Current;

                        // VERIFICA QUE NO SE EXISTA EN LA LISTA USUARIO
                        for (int i = 0; i < oListaPlanCuentasAsignadas.Count; i++)
                        {
                            if (oListaPlanCuentasAsignadas[i].codCuenta == oCuentaSeleccionada.codCuenta)
                            {
                                Global.MensajeFault("Cuenta " + oCuentaSeleccionada.codCuenta + " ya esta agregada");
                                return;
                            }
                        }

                        // ELIMINA SELECCIONADO
                        //oListaPlanCuentasNoAsignadas.RemoveAt(bsCuentas.Position);
                        for (int i = 0; i < oListaPlanCuentasNoAsignadas.Count; i++)
                        { 
                            if(oListaPlanCuentasNoAsignadas[i].codCuenta==oCuentaSeleccionada.codCuenta)
                                oListaPlanCuentasNoAsignadas.RemoveAt(i);
                        }

                        //bsCuentas.DataSource = oListaPlanCuentasNoAsignadas;
                        //bsCuentas.ResetBindings(false);

                        // AGREGA SELECCIONADO
                        oListaPlanCuentasAsignadas.Add(oCuentaSeleccionada);

                        bsCuentasUsuario.DataSource = oListaPlanCuentasAsignadas;
                        bsCuentasUsuario.ResetBindings(false);

                        //lblRegistros.Text = "Cuentas - " + oListaPlanCuentasNoAsignadas.Count.ToString() + " Registros";
                        lblRegistrosUsuario.Text = "Cuentas Asignadas - " + oListaPlanCuentasAsignadas.Count.ToString() + " Registros";

                        Filtrar();
                    }
                    else
                    {
                        Global.MensajeFault("No hay registros");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            try
            {

                if (bsCuentasUsuario.Current != null)
                {
                    if (bsCuentasUsuario.Count > 0)
                    {
                        
                        // OBTIENE SELECCIONADO
                        PlanCuentasDifCambioUsuarioE oCuentaSeleccionada = (PlanCuentasDifCambioUsuarioE)bsCuentasUsuario.Current;

                        for (int i = 0; i < oListaPlanCuentasAsignadas.Count; i++)
                        {
                            if (oListaPlanCuentasAsignadas[i].codCuenta == oCuentaSeleccionada.codCuenta)
                                oListaPlanCuentasAsignadas.RemoveAt(i);
                        }


                        bsCuentasUsuario.DataSource = oListaPlanCuentasAsignadas;
                        bsCuentasUsuario.ResetBindings(false);

                        lblRegistrosUsuario.Text = "Cuentas Asignadas - " + oListaPlanCuentasAsignadas.Count.ToString() + " Registros";

                        Filtrar();

                        // VERIFICA QUE NO SE EXISTA EN LA LISTA Cuenta
                        for (int i = 0; i < oListaPlanCuentasNoAsignadas.Count; i++)
                        {
                            if (oListaPlanCuentasNoAsignadas[i].codCuenta == oCuentaSeleccionada.codCuenta)
                            {
                                return;
                            }
                        }

                        // AGREGA SELECCIONADO
                        oListaPlanCuentasNoAsignadas.Add(oCuentaSeleccionada);

                    }
                    else
                    {
                        Global.MensajeFault("No hay registros");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void Filtrar()
        {
            //bsCuentas.DataSource = oListaPlanCuentasNoAsignadas.Where(x => x.codCuenta.Contains(txtCuenta.Text)).OrderBy(x => x.codCuenta).ToList();
            bsCuentas.DataSource = (from x in oListaPlanCuentasNoAsignadas where x.codCuenta.Contains(txtCuenta.Text) select x).ToList();
            bsCuentas.ResetBindings(false);

            lblRegistros.Text = "Cuentas - " + bsCuentas.Count.ToString() + " Registros";
        }

        private void txtCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dgvListaCuentas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dgvListaCuentas.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvListaCuentas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvListaCuentas.IsCurrentCellDirty)
            {
                dgvListaCuentas.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvListaUsuario_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dgvListaUsuario.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvListaUsuario_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvListaUsuario.IsCurrentCellDirty)
            {
                dgvListaUsuario.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void txtCuenta_KeyUp(object sender, KeyEventArgs e)
        {
            Filtrar();
        }

        private void cboUsuario_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {

                CargarDatos(cboUsuario.SelectedValue.ToString());

            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvListaUsuario_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (oListaPlanCuentasAsignadas != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (e.ColumnIndex == dgvListaUsuario.Columns["codCuenta"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaPlanCuentasAsignadas = (from x in oListaPlanCuentasAsignadas orderby x.codCuenta ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaPlanCuentasAsignadas = (from x in oListaPlanCuentasAsignadas orderby x.codCuenta descending select x).ToList();
                            Ordenar = true;
                        }
                    }
                    if (e.ColumnIndex == dgvListaUsuario.Columns["Descripcion"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaPlanCuentasAsignadas = (from x in oListaPlanCuentasAsignadas orderby x.Descripcion ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaPlanCuentasAsignadas = (from x in oListaPlanCuentasAsignadas orderby x.Descripcion descending select x).ToList();
                            Ordenar = true;
                        }
                    }
                   
                }

                bsCuentasUsuario.DataSource = oListaPlanCuentasAsignadas;
            }
        }

        private void dgvListaUsuario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                String nomColumn = dgvListaUsuario.Columns[e.ColumnIndex].Name;

                string des = dgvListaUsuario.Rows[e.RowIndex].Cells[7].Value.ToString();

                if (nomColumn == "numFile")
                {
                    if (nomColumn == "numFile")
                    {
                        dgvListaUsuario.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                    }

                }
                else
                {
                    dgvListaUsuario.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                }

                //if (nomColumn == "idMoneda")
                //{
                    if (des== "02")
                    {
                        e.CellStyle.BackColor = Color.GreenYellow;
                    }

                //}





            }
        }

        private void dgvListaCuentas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            String nomColumn = dgvListaCuentas.Columns[e.ColumnIndex].Name;

            string des = dgvListaCuentas.Rows[e.RowIndex].Cells[2].Value.ToString();
            
            //if (nomColumn == "idMoneda2")
            //{
                if (des == "02")
                {
                    e.CellStyle.BackColor = Color.GreenYellow;
                }

            //}
        }
    }
}
