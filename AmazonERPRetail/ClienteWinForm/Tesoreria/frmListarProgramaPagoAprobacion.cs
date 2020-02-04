using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmListarProgramaPagoAprobacion : FrmMantenimientoBase
    {

        public frmListarProgramaPagoAprobacion()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvPagos, true, false, 35);
            AnchoColumnas();
            
        }

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }

        Int32 TotalChecks = 0;
        Int32 TotalCheckeados = 0;
        CheckBox CheckBoxCab = null;
        Boolean indClickCab = false;

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            //dgvPagos.Columns[0].Width = 35; //Aprobacion
            //dgvPagos.Columns[1].Width = 35; //Id
            //dgvPagos.Columns[2].Width = 60; //Cuenta
            //dgvPagos.Columns[3].Width = 50; //Id Personal
            //dgvPagos.Columns[4].Width = 250; //Razón Social
            //dgvPagos.Columns[5].Width = 150; //Banco
            //dgvPagos.Columns[6].Width = 100; //Cuenta del Banco
            //dgvPagos.Columns[7].Width = 20; //Grupo
            //dgvPagos.Columns[8].Width = 120; //Número de cheque
            //dgvPagos.Columns[9].Width = 65; //Emisión
            //dgvPagos.Columns[10].Width = 40; //Tipo de Cambio
            //dgvPagos.Columns[11].Width = 65; //Vencimiento
            //dgvPagos.Columns[12].Width = 80; //Cargo Soles
            //dgvPagos.Columns[13].Width = 80; //Abono Soles
            //dgvPagos.Columns[14].Width = 80; //Cargo Dólares
            //dgvPagos.Columns[15].Width = 80; //Abono Dólares
            //dgvPagos.Columns[16].Width = 150; //Glosa
        }

        #region Eventos y procedimientos checkBox

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            indClickCab = true;

            foreach (DataGridViewRow Row in dgvPagos.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["FlagAprobacion"]).Value = HCheckBox.Checked;
            }

            dgvPagos.RefreshEdit();
            TotalCheckeados = HCheckBox.Checked ? TotalChecks : 0;
            indClickCab = false;
        }

        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender);
        }

        private void AñadirCheckBox()
        {
            CheckBoxCab = new CheckBox();
            CheckBoxCab.Size = new Size(15, 15);

            // Añadiendo el CheckBox dentro de la cabecera del datagridview
            dgvPagos.Controls.Add(CheckBoxCab);
        }

        private void CambiarUbicacionCheckBox(Int32 ColumnIndex, Int32 RowIndex)
        {
            //Obtener limites de la celda de la cabecera que va a contener el checkbox
            Rectangle oRectangle = dgvPagos.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - CheckBoxCab.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - CheckBoxCab.Height) / 2 + 1;

            //Cambiar la ubicacion del checkbox para que se quede en la cabecera
            CheckBoxCab.Location = oPoint;
        }

        private void FilaCheBoxClick(DataGridViewCheckBoxCell RCheckBox)
        {
            if (RCheckBox != null)
            {
                //Modificando el contador de los check
                if ((bool)RCheckBox.Value && TotalCheckeados < TotalChecks)
                {
                    TotalCheckeados++;
                }
                else if (TotalCheckeados > 0)
                {
                    TotalCheckeados--;
                }

                //Cambiar estado de la casilla de la cabecera si es que se llenan todas las filas o viceversa.
                if (TotalCheckeados < TotalChecks)
                {
                    CheckBoxCab.Checked = false;
                }
                else if (TotalCheckeados == TotalChecks)
                {
                    CheckBoxCab.Checked = true;
                }
            }
        }

        #endregion

        #endregion

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {
                String Aprobacion = "N";

                if (cboEstados.SelectedIndex == 1)
                {
                    Aprobacion = "S";
                }

                List<ProgramaPagoE> oListaAprobacion = AgenteTesoreria.Proxy.ListarPagosParaAprobacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal,
                                                                                                        dtpFecIni.Value.Date, dtpFecFin.Value.Date, Aprobacion);
                bsProgramaPago.DataSource = oListaAprobacion;
                TotalChecks = oListaAprobacion.Count;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmListarProgramaPagoAprobacion_Load(object sender, EventArgs e)
        {
            Grid = true;

            AñadirCheckBox();

            CheckBoxCab.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            CheckBoxCab.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);

            BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            cboEstados.SelectedIndex = 0;
            cboEstados_SelectionChangeCommitted(new Object(), new EventArgs());
        }

        private void dgvPagos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                CambiarUbicacionCheckBox(e.ColumnIndex, e.RowIndex);
            }
        }

        private void dgvPagos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPagos.Rows.Count != 0)
            {
                if (!indClickCab)
                {
                    FilaCheBoxClick((DataGridViewCheckBoxCell)dgvPagos[e.ColumnIndex, e.RowIndex]);
                }
            }
        }

        private void dgvPagos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvPagos.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvPagos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btAprobar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TotalCheckeados > Variables.Cero)
                {
                    List<ProgramaPagoE> oListaAprobacion = new List<ProgramaPagoE>();

                    foreach (ProgramaPagoE item in bsProgramaPago.List)
                    {
                        if (item.FlagAprobacion)
                        {
                            if (!String.IsNullOrEmpty(item.nomBanco))
                            {
                                item.Aprobado = Variables.SI;
                                item.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                                oListaAprobacion.Add(item);
                            }
                            else
                            {
                                Global.MensajeComunicacion(String.Format("Este item {0} {1} no se le ha asignado ningún Banco", item.idProgramaPago.ToString(), item.RazonSocial));
                            }
                        }
                    }

                    if (oListaAprobacion.Count > Variables.Cero)
                    {
                        AgenteTesoreria.Proxy.ActualizarProgramaPagoAprobacion(oListaAprobacion);
                        Global.MensajeComunicacion("Se aprobaron todos los registros escogidos...");
                        Buscar();
                        
                        CheckBoxCab.Checked = false;
                        HeaderCheckBoxClick(CheckBoxCab);
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Tiene que seleccionar algún item antes de aprobar.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btDesaprobar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TotalCheckeados > Variables.Cero)
                {
                    List<ProgramaPagoE> oListaAprobacion = new List<ProgramaPagoE>();

                    foreach (ProgramaPagoE item in bsProgramaPago.List)
                    {
                        if (item.FlagAprobacion && item.Aprobado == Variables.SI)
                        {
                            if (!String.IsNullOrEmpty(item.nomBanco))
                            {
                                item.Aprobado = Variables.NO;
                                item.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                                oListaAprobacion.Add(item);
                            }
                            else
                            {
                                Global.MensajeComunicacion(String.Format("Este item {0} {1} no se le ha asignado ningún Banco", item.idProgramaPago.ToString(), item.RazonSocial));
                            }
                        }
                    }

                    if (oListaAprobacion.Count > Variables.Cero)
                    {
                        AgenteTesoreria.Proxy.ActualizarProgramaPagoAprobacion(oListaAprobacion);
                        Global.MensajeComunicacion("Se desaprobaron los registros...");
                        Buscar();
                        CheckBoxCab.Checked = false;
                        HeaderCheckBoxClick(CheckBoxCab);
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Tiene que seleccionar algún item para  poder desaprobar.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvPagos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((String)dgvPagos.Rows[e.RowIndex].Cells["Aprobado"].Value == "N")
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Valores.ColorInabilitado;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboEstados_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboEstados.SelectedIndex == 0)
            {
                btAprobar.Enabled = true;
                btDesaprobar.Enabled = false;
            }
            else if (cboEstados.SelectedIndex == 1)
            {
                btAprobar.Enabled = false;
                btDesaprobar.Enabled = true;
            }
        }

        private void bsProgramaPago_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = String.Format("Registros {0}", bsProgramaPago.List.Count.ToString());
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
