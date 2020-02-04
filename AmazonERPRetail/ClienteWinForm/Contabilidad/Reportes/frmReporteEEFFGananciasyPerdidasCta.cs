using System;
using System.Collections.Generic;
using Infraestructura.Enumerados;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteEEFFGananciasyPerdidasCta : FrmMantenimientoBase
    {

        #region Constructores

        public frmReporteEEFFGananciasyPerdidasCta()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            FormatoGrid(dgvListadoEEFF, true);
            FormatoGrid(dgvCuentas, true);
        }

        public frmReporteEEFFGananciasyPerdidasCta(List<EEFFItemCtaE> olista, String desItem, Int32 idEmpresa, Int32 idEF, Int32 idEFItem, String MostrarSaldo = "N", String Anio = "", String Mes = "")
            :this()
        {
            try
            {
                oListaCta = olista;
                Decimal valor = olista.Sum(x => x.SaldoActualSoles);
                Decimal valor1 = olista.Sum(x => x.SaldoActualDolares);

                txttotalsoles.Text = valor.ToString("N2");
                txttotaldolares.Text = valor1.ToString("N2");

                // GRILLA 
                bsEEFFItemCta.DataSource = oListaCta;
                bsEEFFItemCta.ResetBindings(false);

                //lblRegistros.Text = bsEEFFItemCta.Count.ToString() + " Registros";

                if (MostrarSaldo == "S")
                {
                    dgvListadoEEFF.Columns[9].Visible = false;
                    dgvListadoEEFF.Columns[10].Visible = false;
                    dgvListadoEEFF.Columns[11].Visible = false;
                    dgvListadoEEFF.Columns[12].Visible = false;
                    dgvListadoEEFF.Columns[13].Visible = true;
                    dgvListadoEEFF.Columns[14].Visible = true;

                    pnlDetalle.Width = 580;
                    this.Width = 1152;// 1155;
                    pnlCuentas.Visible = true;
                    btTransferir.Visible = true;
                    bsSinAsignacion.DataSource = oListaCtaNoAsigandas = AgenteContabilidad.Proxy.EEFFCtasNoAsignadas(idEmpresa, idEF, Anio, Mes);
                    bsSinAsignacion.ResetBindings(false);
                    AnioPeriodo = Anio;
                    MesPeriodo = Mes;
                }

                idEmpresaDato = idEmpresa;
                idEEFFDato = idEF;
                idEEFFItemDato = idEFItem;
                Descripcion = desItem;
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        public List<EEFFItemCtaE> oListaCta = new List<EEFFItemCtaE>();
        List<EEFFItemCtaE> oListaCtaNoAsigandas = null;
        String AnioPeriodo = String.Empty;
        String MesPeriodo = String.Empty;

        //Para el check del datagridview
        Int32 TotalChecks = 0;
        Int32 TotalCheckeados = 0;
        CheckBox CheckBoxCab = null;
        Boolean indClickCab = false;

        //Datos cuando no existe registros dgvListadoEEFF
        Int32 idEmpresaDato = 0;
        Int32 idEEFFDato = 0;
        Int32 idEEFFItemDato = 0;
        String Descripcion = String.Empty;

        #endregion

        #region Eventos y procedimientos checkBox

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            indClickCab = true;

            foreach (DataGridViewRow Row in dgvCuentas.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["Check"]).Value = HCheckBox.Checked;
            }

            dgvCuentas.RefreshEdit();
            TotalCheckeados = HCheckBox.Checked ? TotalChecks : 0;
            indClickCab = false;
        }

        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                HeaderCheckBoxClick((CheckBox)sender);
            }        
        }

        private void AñadirCheckBox()
        {
            CheckBoxCab = new CheckBox();
            CheckBoxCab.Size = new Size(15, 15);

            // Añadiendo el CheckBox dentro de la cabecera del datagridview
            dgvCuentas.Controls.Add(CheckBoxCab);
        }

        private void CambiarUbicacionCheckBox(Int32 ColumnIndex, Int32 RowIndex)
        {
            //Obtener limites de la celda de la cabecera que va a contener el checkbox
            Rectangle oRectangle = dgvCuentas.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

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

        #region Eventos

        private void frmEEFFItemCta_Load(object sender, EventArgs e)
        {
            Grid = false;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            dgvCuentas.ClearSelection();
            dgvCuentas.CurrentCell = null;
            dgvListadoEEFF.ClearSelection();
            dgvListadoEEFF.CurrentCell = null;

            AñadirCheckBox();
            CheckBoxCab.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            CheckBoxCab.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
            TotalChecks = dgvCuentas.RowCount;
            TotalCheckeados = 0;
        }

        private void dgvListadoEEFF_Click(object sender, EventArgs e)
        {
            try
            {
                CheckBoxCab.Checked = false;
                HeaderCheckBoxClick(CheckBoxCab);
                dgvCuentas.ClearSelection();
                dgvCuentas.CurrentCell = null;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvCuentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvListadoEEFF.ClearSelection();
                dgvListadoEEFF.CurrentCell = null;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btTransferir_Click(object sender, EventArgs e)
        {
            try
            {               
                Int32 CeldasSeleccionada = dgvListadoEEFF.Rows.GetRowCount(DataGridViewElementStates.Selected);

                if (bsEEFFItemCta.Current != null && CeldasSeleccionada > 0 && TotalCheckeados == 0)
                {
                    Int32 Posicion = bsEEFFItemCta.Position;
                    //Eliminando el item escogido
                    int resp = AgenteContabilidad.Proxy.EliminarEEFFItemCta(idEmpresaDato, oListaCta[Posicion].idEEFF, oListaCta[Posicion].idEEFFItem, oListaCta[Posicion].idEEFFItemCta);

                    if (resp > 0)
                    {
                        //Actualizando la lista de DGV EEFFItems
                        oListaCta.RemoveAt(Posicion);
                        bsEEFFItemCta.DataSource = oListaCta;
                        bsEEFFItemCta.ResetBindings(false);

                        //Actualizando la lista de DGV Cuentas no asignadas
                        bsSinAsignacion.DataSource = oListaCtaNoAsigandas = AgenteContabilidad.Proxy.EEFFCtasNoAsignadas(idEmpresaDato, idEEFFDato, AnioPeriodo, MesPeriodo);
                        bsSinAsignacion.ResetBindings(false);

                        //Limpiando la seleccion en el DGV de cuentas no asignadas
                        dgvCuentas.ClearSelection();
                        dgvCuentas.CurrentCell = null;

                        //Actualizando la variable global de los checks
                        TotalChecks = oListaCtaNoAsigandas.Count;

                        Global.MensajeComunicacion("Se transferió correctamente.");
                    }
                }
                else
                {
                    List<EEFFItemCtaE> ListaPorRemover = new List<EEFFItemCtaE>();

                    foreach (EEFFItemCtaE item in bsSinAsignacion.List)
                    {
                        if (item.Check)
                        {
                            //Item Nuevo
                            EEFFItemCtaE ItemNuevo = new EEFFItemCtaE
                            {
                                idEmpresa = idEmpresaDato,
                                idEEFF = idEEFFDato,
                                idEEFFItem = idEEFFItemDato,
                                CodPlaCta = item.CodPlaCta,
                                desCuenta = item.desCuenta,
                                NumPlaCta = item.NumPlaCta,
                                TipoCondicion = ">",
                                TipoNivel = "1",
                                SaldoActualSoles = item.SaldoActualSoles,
                                SaldoActualDolares = item.SaldoActualDolares,
                                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                            };

                            //Obteniendo el ID
                            ItemNuevo.idEEFFItemCta = AgenteContabilidad.Proxy.MaxIdConEEFFItemCta(ItemNuevo.idEmpresa, ItemNuevo.idEEFF, ItemNuevo.idEEFFItem);
                            //Insertando el nuevo item
                            ItemNuevo = AgenteContabilidad.Proxy.InsertarEEFFItemCta(ItemNuevo);
                            //Agregando el nuevo Item a la lista
                            oListaCta.Add(ItemNuevo);

                            //Agregando a la lista por remover de la lista principal
                            ListaPorRemover.Add(item);                            
                        }
                    }

                    //Actualizando el dgv EEFFItems
                    bsEEFFItemCta.DataSource = oListaCta;
                    bsEEFFItemCta.ResetBindings(false);

                    //Borrando el items escogidos de las cuentas no asignadas...
                    if (ListaPorRemover.Count > 0)
                    {
                        foreach (EEFFItemCtaE item in ListaPorRemover)
                        {
                            oListaCtaNoAsigandas.Remove(item);
                        }
                    }

                    //Actualizando el dgv Cuentas no asignadas
                    bsSinAsignacion.DataSource = oListaCtaNoAsigandas;
                    bsSinAsignacion.ResetBindings(false);

                    //Actualizando la variable global de los checks
                    TotalChecks = oListaCtaNoAsigandas.Count;
                    CheckBoxCab.Checked = false;
                    HeaderCheckBoxClick(CheckBoxCab);

                    //Limpiando la seleccion en el dg de EEFFE
                    dgvListadoEEFF.ClearSelection();
                    dgvListadoEEFF.CurrentCell = null;

                    Global.MensajeComunicacion("Se transfirió correctamente.");
                }

                //CeldasSeleccionada = dgvCuentas.Rows.GetRowCount(DataGridViewElementStates.Selected);

                //if (TotalCheckeados > 0)
                //{
                //    List<EEFFItemCtaE> ListaPorRemover = new List<EEFFItemCtaE>();

                //    foreach (EEFFItemCtaE item in bsSinAsignacion.List)
                //    {
                //        if (item.Check)
                //        {
                //            EEFFItemCtaE oItem = new EEFFItemCtaE
                //            {
                //                idEmpresa = idEmpresaDato,
                //                idEEFF = idEEFFDato,
                //                idEEFFItem = idEEFFItemDato,
                //                CodPlaCta = item.CodPlaCta,
                //                desCuenta = item.desCuenta,
                //                NumPlaCta = item.NumPlaCta,
                //                TipoCondicion = ">",
                //                TipoNivel = "1",
                //                SaldoActualSoles = item.SaldoActualSoles,
                //                SaldoActualDolares = item.SaldoActualDolares,
                //                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                //            };

                //            oItem.idEEFFItemCta = AgenteContabilidad.Proxy.MaxIdConEEFFItemCta(oItem.idEmpresa, oItem.idEEFF, oItem.idEEFFItem);
                //            oItem = AgenteContabilidad.Proxy.InsertarEEFFItemCta(oItem);

                //            //Agregando el nuevo Item
                //            oListaCta.Add(oItem);

                //            //Agregando a la lista por remover de la lista principal
                //            ListaPorRemover.Add(item);
                //            //Limpiando la seleccion en el dg de EEFFE
                //            //dgvListadoEEFF.ClearSelection();
                //            //dgvListadoEEFF.CurrentCell = null;
                //        }
                //    }

                //    bsEEFFItemCta.DataSource = oListaCta;
                //    bsEEFFItemCta.ResetBindings(false);

                //    Global.MensajeComunicacion("Se transfirió correctamente.");

                //    //Borrando el items escogidos de las cuentas no asignadas...
                //    //oListaCtaNoAsigandas.Remove((EEFFItemCtaE)bsSinAsignacion.Current);
                //    if (ListaPorRemover.Count > 0)
                //    {
                //        foreach (EEFFItemCtaE item in ListaPorRemover)
                //        {
                //            oListaCtaNoAsigandas.Remove(item);
                //        }
                //    }

                //    bsSinAsignacion.DataSource = oListaCtaNoAsigandas;
                //    bsSinAsignacion.ResetBindings(false);

                //    TotalChecks = oListaCtaNoAsigandas.Count;
                //    CheckBoxCab.Checked = false;
                //    HeaderCheckBoxClick(CheckBoxCab);
                //    //TotalCheckeados = 0;
                //}
                //else if (bsSinAsignacion.Current != null && CeldasSeleccionada > 0)
                //{
                //    EEFFItemCtaE oItem = new EEFFItemCtaE
                //    {
                //        idEmpresa = idEmpresaDato,
                //        idEEFF = idEEFFItemDato,
                //        idEEFFItem = idEEFFItemDato,
                //        CodPlaCta = ((EEFFItemCtaE)bsSinAsignacion.Current).CodPlaCta,
                //        desCuenta = ((EEFFItemCtaE)bsSinAsignacion.Current).desCuenta,
                //        NumPlaCta = ((EEFFItemCtaE)bsSinAsignacion.Current).NumPlaCta,
                //        TipoCondicion = ">",
                //        TipoNivel = "1",
                //        SaldoActualSoles = ((EEFFItemCtaE)bsSinAsignacion.Current).SaldoActualSoles,
                //        SaldoActualDolares = ((EEFFItemCtaE)bsSinAsignacion.Current).SaldoActualDolares,
                //        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                //    };

                //    //Int32 idEEFFItemCta = AgenteContabilidad.Proxy.MaxIdConEEFFItemCta(oItem.idEmpresa, oItem.idEEFF, oItem.idEEFFItem);
                //    //oItem.idEEFFItemCta = idEEFFItemCta;
                //    //oItem = AgenteContabilidad.Proxy.InsertarEEFFItemCta(oItem);

                //    //Agregando el nuevo Item
                //    oListaCta.Add(oItem);
                //    bsEEFFItemCta.DataSource = oListaCta;
                //    bsEEFFItemCta.ResetBindings(false);

                //    //Borrando el items escogido de las cuentas no asignadas...
                //    oListaCtaNoAsigandas.Remove((EEFFItemCtaE)bsSinAsignacion.Current);
                //    bsSinAsignacion.DataSource = oListaCtaNoAsigandas;
                //    bsSinAsignacion.ResetBindings(false);

                //    Global.MensajeComunicacion("Se transfirió correctamente.");

                //    //Limpiando la seleccion en el dg de EEFFE
                //    dgvListadoEEFF.ClearSelection();
                //    dgvListadoEEFF.CurrentCell = null;
                //}
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsSinAsignacion_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblCuentas.Text = "Cuentas - Registros " + bsSinAsignacion.List.Count;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvCuentas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                CambiarUbicacionCheckBox(e.ColumnIndex, e.RowIndex);
            }
        }

        private void dgvCuentas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCuentas.Rows.Count != 0)
            {
                if (!indClickCab && e.ColumnIndex == 0)
                {
                    FilaCheBoxClick((DataGridViewCheckBoxCell)dgvCuentas[e.ColumnIndex, e.RowIndex]);
                }
            }

            //dgvListadoEEFF.ClearSelection();
            //dgvListadoEEFF.CurrentCell = null;
            //dgvCuentas.ClearSelection();
            //dgvCuentas.CurrentCell = null;
        }

        private void dgvCuentas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCuentas.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvCuentas.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void bsEEFFItemCta_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = Descripcion + " - " + bsEEFFItemCta.Count.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
