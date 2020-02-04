using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Recursos;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmTipoComprobantes : FrmMantenimientoBase
    {

        #region Constructores

        public frmTipoComprobantes()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvFiles, true);
        }

        public frmTipoComprobantes(int idEmpresa_, string idComprobante_)
            :this()
        {
            TipoComprobante = AgenteContabilidad.Proxy.ObtenerTipoComprobante(idEmpresa_, idComprobante_);
        }

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        GeneralesServiceAgent AgentesGeneral { get { return new GeneralesServiceAgent(); } }
        List<ComprobantesFileE> ListaFile = new List<ComprobantesFileE>();
        ComprobantesE TipoComprobante = null;
        List<ComprobantesFileE> FilesEliminados = null;
        
        int Opcion = 0;
        int posicion = 0;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombo()
        {
            List<ParTabla> ListaTipoDiario = AgentesGeneral.Proxy.RecuperarParTablaPorEnumerado(EnumParTabla.TipoDiario, false);
            ParTabla Inicio = new ParTabla() { IdParTabla = 0, Nombre = Variables.Seleccione };
            ListaTipoDiario.Add(Inicio);

            ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoDiario, ListaTipoDiario, "IdParTabla", "Nombre");
            cboTipoDiario.SelectedValue = 0;
        }

        void LlenarComboGrid()
        {
            DataGridViewComboBoxColumn oCombo = dgvFiles.Columns["cboDgvIdMoneda"] as DataGridViewComboBoxColumn;

            List<MonedasE> oListaMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(oCombo, (from x in oListaMonedas
                                                            where x.idMoneda == Variables.Soles || x.idMoneda == Variables.Dolares
                                                            orderby x.idMoneda select x).ToList(), "idMoneda", "desMoneda");
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (TipoComprobante != null)
            {
                LlenarComboGrid();
                TipoComprobante.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                TipoComprobante.FechaModificacion = VariablesLocales.FechaHoy;

                txtCodigo.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                Opcion = (int)EnumOpcionGrabar.Actualizar;
                txtDescripcion.Focus();
            }
            else
            {
                TipoComprobante = new ComprobantesE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idComprobante = Variables.Cero.ToString(),
                    UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                    FechaRegistro = VariablesLocales.FechaHoy,
                    UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                    FechaModificacion = VariablesLocales.FechaHoy,
                    indTCVenta = true
                };
                indTCVenta.Checked = true;
                //Files
                //TipoComprobante.ListaComprobantesFiles = new List<ComprobantesFileE>();

                Opcion = (int)EnumOpcionGrabar.Insertar;
                txtCodigo.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDescripcion.Focus();
                //FilesEliminados = new List<ComprobantesFileE>();
            }

            bsComprobantes.DataSource = TipoComprobante;
            bsComprobantesFile.DataSource = TipoComprobante.ListaComprobantesFiles;
            bsComprobantes.ResetBindings(false);
            bsComprobantesFile.ResetBindings(false);
            base.Nuevo();
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
            FilesEliminados = new List<ComprobantesFileE>();
        }

        public override void Editar()
        {
            Opcion = (int)EnumOpcionGrabar.Actualizar;
            panel1.Enabled = true;
            bFlag = true;
            base.Editar();
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
        }

        public override void Grabar()
        {
            try
            {
                if (dgvFiles.IsCurrentCellDirty)
                {
                    dgvFiles.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }

                if (!ValidarGrabacion())
                {
                    return;
                }

                bsComprobantes.EndEdit();
                bsComprobantesFile.EndEdit();

                TipoComprobante = (ComprobantesE)bsComprobantes.Current;
                TipoComprobante.ListaComprobantesFiles = (List<ComprobantesFileE>)bsComprobantesFile.List;

                if (TipoComprobante.ListaComprobantesFiles.Count > 0)
                {
                    foreach (ComprobantesFileE item in TipoComprobante.ListaComprobantesFiles)
                    {
                        item.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                        if (item.Opcion == 0)
                        {
                            item.Opcion = (int)EnumOpcionGrabar.Actualizar;
                        }
                    }
                }

                if (Opcion == (int)EnumOpcionGrabar.Insertar)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        TipoComprobante = AgenteContabilidad.Proxy.GrabarTipoComprobante(TipoComprobante, EnumOpcionGrabar.Insertar);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        TipoComprobante = AgenteContabilidad.Proxy.GrabarTipoComprobante(TipoComprobante, EnumOpcionGrabar.Actualizar);    
                        
                        //Si hay registros por eliminar
                        if (Opcion == (int)EnumOpcionGrabar.Eliminar)
                        {
                            if (FilesEliminados != null && FilesEliminados.Count > Variables.Cero)
                            {
                                ComprobantesE TipoTmp = (ComprobantesE)bsComprobantes.Current;
                                TipoTmp.ListaComprobantesFiles = FilesEliminados;
                                AgenteContabilidad.Proxy.GrabarTipoComprobante(TipoTmp, EnumOpcionGrabar.Actualizar);

                                FilesEliminados = new List<ComprobantesFileE>();
                            }
                        }

                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }

                //bsComprobantes.DataSource = TipoComprobante;
                //bsComprobantesFile.DataSource = TipoComprobante.ListaComprobantesFiles;
                //bsComprobantes.ResetBindings(false);
                //bsComprobantesFile.ResetBindings(false);

                //if (bsComprobantesFile.Count > 0)
                //{
                //    dgvFiles.Rows[posicion].Selected = true;    
                //}

                //Para los comprobantes y files de contabilidad...
                VariablesLocales.oListaComprobantes = new ContabilidadServiceAgent().Proxy.ListarComprobantesGeneral(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            String resp = ValidarEntidad<ComprobantesE>(TipoComprobante);

            if (!String.IsNullOrEmpty(resp))
            {
                Global.MensajeComunicacion(resp);
                return false;
            }

            if (TipoComprobante.ListaComprobantesFiles != null && TipoComprobante.ListaComprobantesFiles.Count > Variables.Cero)
            {
                foreach (ComprobantesFileE item in TipoComprobante.ListaComprobantesFiles)
                {
                    if (item.LLevaCuenta)
                    {
                        if (string.IsNullOrEmpty(item.codCuenta))
                        {
                            MessageBox.Show("El check de cuenta esta habilitado deberia colocar una cuenta.");
                            return false;
                        }
                    }
                    if (item.codCuentaSoles == null)
                    {
                        item.codCuentaSoles = "";
                    }
                    if (item.codCuentaDolar == null)
                    {
                        item.codCuentaDolar = "";
                    }
                }
            }

            return base.ValidarGrabacion();
        }

        public override void AgregarDetalle()
        {
            bsComprobantes.EndEdit();
            bsComprobantesFile.EndEdit();
            ComprobantesFileE FileNuevo = new ComprobantesFileE();
            List<ComprobantesFileE> ListaTmp = (List<ComprobantesFileE>)bsComprobantesFile.List;//TipoComprobante.ListaComprobantesFiles;

            LlenarComboGrid();
            int Totafilas = Convert.ToInt32(ListaTmp.Max(mx => mx.numFile)) + 1;//bsComprobantesFile.Count + 1;
            FileNuevo.DesLarga = "";
            FileNuevo.numFile = Totafilas.ToString("00");
            FileNuevo.idMoneda = Variables.Soles;
            FileNuevo.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
            FileNuevo.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            FileNuevo.FechaRegistro = VariablesLocales.FechaHoy;
            FileNuevo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            FileNuevo.FechaModificacion = VariablesLocales.FechaHoy;
            FileNuevo.Opcion = (int)EnumOpcionGrabar.Insertar;
            ListaFile.Add(FileNuevo);
            ListaTmp.Add(FileNuevo);
            bsComprobantesFile.DataSource = ListaTmp;
            bsComprobantesFile.ResetBindings(false);

            bsComprobantesFile.MoveLast();
            dgvFiles.Focus();

            base.AgregarDetalle();
            BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
        }

        public override void QuitarDetalle()
        {
            if (bsComprobantesFile.Current != null)
            {
                if (TipoComprobante.ListaComprobantesFiles != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) != DialogResult.Yes)
                        return;

                    bsComprobantes.EndEdit();
                    bsComprobantesFile.EndEdit();
                    ComprobantesFileE FileTemp = (ComprobantesFileE)bsComprobantesFile.Current;
                    FileTemp.Opcion = (int)EnumOpcionGrabar.Eliminar;

                    FilesEliminados.Add(FileTemp);
                    TipoComprobante.ListaComprobantesFiles.RemoveAt(bsComprobantesFile.Position);
                    bsComprobantesFile.DataSource = TipoComprobante.ListaComprobantesFiles;
                    bsComprobantesFile.ResetBindings(false);
                    Opcion = (int)EnumOpcionGrabar.Eliminar;
                }
            }

            base.QuitarDetalle();
        }

        #endregion

        #region Override

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //  Si el control DataGridView no tiene el foco...
            if (!dgvFiles.Focused && !dgvFiles.IsCurrentCellInEditMode)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            ////  Si la tecla presionada es distinta de la tecla Enter
            ////  abandonamos el procedimiento.
            if ((keyData != Keys.Return))
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            //DataGridViewCell cell = dgvFiles.CurrentCell;
            //Int32 columnIndex = cell.ColumnIndex;
            //Int32 rowIndex = cell.RowIndex;

            //if ((columnIndex == (dgvFiles.Columns.Count - 1)))
            //{
            //    if ((rowIndex == (dgvFiles.Rows.Count - 1)))
            //    {
            //        //  Seleccionamos la primera columna de la primera fila.
            //        cell = dgvFiles.Rows[0].Cells[0];
            //    }
            //    else
            //    {
            //        //  Selecionamos la primera columna de la siguiente fila.
            //        cell = dgvFiles.Rows[(rowIndex + 1)].Cells[0];
            //    }
            //}
            //else
            //{
            //    //  Seleccionamos la celda de la derecha de la celda actual.
            //    cell = dgvFiles.Rows[rowIndex].Cells[(columnIndex + 1)];
            //}
            //if (cell != null)
            //{
            //    dgvFiles.CurrentCell = cell;
            //    return true;    
            //}
            //else
            //{
            //    return false;
            //}
            int iColumnIndex = dgvFiles.CurrentCell.ColumnIndex;
            int iRowIndex = dgvFiles.CurrentCell.RowIndex;

            if (keyData == Keys.Enter)
            {
                if (iColumnIndex == dgvFiles.Columns.Count - 1)
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                    //dgvFiles.Rows.Add();
                    //dgvFiles.CurrentCell = dgvFiles[0, irow + 1];
                }
                else
                {
                    dgvFiles.CurrentCell = dgvFiles[iColumnIndex + 1, iRowIndex];
                }

                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        #endregion

        #region Eventos

        private void frmTipoComprobantes_Load(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
            LlenarCombo();
            Nuevo();
            dgvFiles.AutoResizeColumns();
            Grid = false;
            BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
        }

        private void dgvFiles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {            
            bsComprobantesFile.EndEdit();

            if (e.RowIndex != -1)
            {
                if (((ComprobantesFileE)bsComprobantesFile.Current).Opcion != (int)EnumOpcionGrabar.Insertar)
                {
                    ((ComprobantesFileE)bsComprobantesFile.Current).numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                    ((ComprobantesFileE)bsComprobantesFile.Current).UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    ((ComprobantesFileE)bsComprobantesFile.Current).FechaModificacion = VariablesLocales.FechaHoy;
                    ((ComprobantesFileE)bsComprobantesFile.Current).Opcion = (int)EnumOpcionGrabar.Actualizar;
                }
            }
        }
        
        private void bsComprobantesFile_CurrentChanged(object sender, EventArgs e)
        {
            if (bsComprobantesFile.Current != null)
            {
                posicion = bsComprobantesFile.Position;
            }
        }

        private void dgvFiles_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                SendKeys.Send("{F4}");
            }

            if (e.ColumnIndex == 7)
            {
                SendKeys.Send("{F4}");
            }
        }

        private void dgvFiles_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvFiles.CurrentRow != null)
            {
                dgvFiles.CurrentRow.Cells[3].Selected = true;
            }
        }

        private void dgvFiles_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dgvFiles.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvFiles_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validando la columna de cuenta para que acepte solo números
            if (dgvFiles.CurrentCell.ColumnIndex == 9)
            {
                if (e.KeyChar == (char)Keys.Back || char.IsNumber(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void dgvFiles_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvFiles.CurrentCell.ColumnIndex == 9)
            {
                TextBox txt = e.Control as TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dgvFiles_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(dgvFiles_KeyPress);
                }
            }
        }

        private void dgvFiles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvFiles.Rows[e.RowIndex].ErrorText = String.Empty;

                if (dgvFiles.CurrentCell.ColumnIndex == 10)
                {
                    DataGridViewCell cellCuenta = dgvFiles.Rows[e.RowIndex].Cells["codCuenta"];
                    DataGridViewCell cellDesCuenta = dgvFiles.Rows[e.RowIndex].Cells["desCuenta"];

                    if (!String.IsNullOrEmpty(cellCuenta.Value.ToString()))
                    {
                        if (VariablesLocales.ObtenerPlanCuenta(cellCuenta.Value.ToString()) != null)
                        {
                            cellDesCuenta.Value = VariablesLocales.ObtenerPlanCuenta(cellCuenta.Value.ToString()).Descripcion;
                        }
                        else
                        {
                            Global.MensajeFault("La cuenta ingresada no existe.");
                            cellCuenta.Value = String.Empty;
                        }
                    }
                }

                if (!((ComprobantesFileE)bsComprobantesFile.Current).LLevaCuenta)
                {
                    ((ComprobantesFileE)bsComprobantesFile.Current).numVerPlanCuentas = String.Empty;
                    ((ComprobantesFileE)bsComprobantesFile.Current).codCuenta = String.Empty;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1)
            {
                if (dgvFiles.Columns[e.ColumnIndex].Name == "DesLarga")
                {
                    ComprobantesFileE FILEDESCRIPCION = (ComprobantesFileE)bsComprobantesFile.Current;
                    frmDescripcionComprobantesFile oFrm = new frmDescripcionComprobantesFile(FILEDESCRIPCION);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Detalle != null)
                    {
                        TipoComprobante.ListaComprobantesFiles[e.RowIndex] = oFrm.Detalle;
                        bsComprobantesFile.DataSource = TipoComprobante.ListaComprobantesFiles;
                        bsComprobantesFile.ResetBindings(false);
                    }
                }
            }
        }

        private void dgvFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ListaFile.Count > Variables.Cero)
            {
                ComprobantesFileE comprobantefile =(ComprobantesFileE)bsComprobantesFile.Current;
                 
                if (comprobantefile.Opcion == (int)EnumOpcionGrabar.Insertar)
                {
                    if (e.RowIndex != -1)
                    {
                        if (dgvFiles.Columns[e.ColumnIndex].Name == "numFile")
                        {
                            dgvFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                        }
                    }
                }
            }

        }

        #endregion

    }
}
