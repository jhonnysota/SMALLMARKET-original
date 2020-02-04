using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;
using Infraestructura.Recursos;

namespace ClienteWinForm.Maestros
{
    public partial class frmListadoEstablecimientos : FrmMantenimientoBase
    {
        public frmListadoEstablecimientos()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            pFormatoGrid(dgvEstablecimientos, true);
            lblRazon.Text = VariablesLocales.SesionUsuario.Empresa.RazonSocial;
            lblCodigoEmpresa.Text = VariablesLocales.SesionUsuario.Empresa.IdEmpresa.ToString();
            lblRuc.Text = VariablesLocales.SesionUsuario.Empresa.RUC;

            LlenarCombo();
            cboSucursal.SelectedValue = Convert.ToInt32(VariablesLocales.SesionLocal.IdLocal);
            
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<EstablecimientosE> oListaEstablecimientosCombo = null;
        string NuevoItem = string.Empty;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombo()
        {
            cboSucursal.DataSource = null;
            List<LocalE> ListaLocales = AgenteMaestro.Proxy.ListarLocal("", false, false, Convert.ToInt32(lblCodigoEmpresa.Text));
            ComboHelper.RellenarCombos<LocalE>(cboSucursal, ListaLocales, "idLocal", "Nombre", false);
            ListaLocales = null;

            cboSucursal_SelectionChangeCommitted(new object(), new EventArgs());
        }

        public void pFormatoGrid(DataGridView oDgv, bool PrimerCol, Boolean EscogerVariasFilas = false, Int32 AltoFilas = 20, float tamLetraCabecera = 8.25f, float tamLetraDetalle = 8)
        {
            ////Para que la primera columan no aparesca
            oDgv.RowHeadersVisible = PrimerCol;
            oDgv.RowHeadersWidth = 20;
            oDgv.BorderStyle = BorderStyle.None;

            //Establecer el estilo de las filas y columnas del encabezado
            oDgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", tamLetraCabecera * 96f / CreateGraphics().DpiX, FontStyle.Bold, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            oDgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;
            oDgv.RowHeadersDefaultCellStyle.BackColor = Color.Silver;
            oDgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            oDgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            oDgv.RowsDefaultCellStyle.Font = new Font("Tahoma", tamLetraDetalle * 96f / CreateGraphics().DpiX, FontStyle.Regular, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            //Valores de propiedad, conjunto adecuado para la visualización.
            oDgv.AllowUserToAddRows = false;
            oDgv.AllowUserToDeleteRows = false;
            oDgv.AllowUserToOrderColumns = false;
            oDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            oDgv.MultiSelect = EscogerVariasFilas;

            oDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            oDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            //Estableciendo el el alto de los titulos
            oDgv.ColumnHeadersHeight = 30;

            //Formato para las filas
            DataGridViewRow lineas = oDgv.RowTemplate; //Establece la plantilla para todas las filas.
            lineas.Height = AltoFilas;
            lineas.MinimumHeight = 10;

            oDgv.Refresh();
        }

        void OtroFormato()
        {
            dgvEstablecimientos.Columns[0].Visible = false;
            dgvEstablecimientos.Columns[1].Visible = false;
            dgvEstablecimientos.Columns[2].Visible = false;

            dgvEstablecimientos.Columns[3].HeaderText = "Descripción Zona";
            dgvEstablecimientos.Columns[4].HeaderText = "Id.Zona F.";
            dgvEstablecimientos.Columns[5].HeaderText = "Zona de Influencia";

            dgvEstablecimientos.Columns[3].Width = 250;
            dgvEstablecimientos.Columns[4].Width = 70;
            dgvEstablecimientos.Columns[5].Width = 200;
        }

        void EditarZona()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmDetalleZonas);

                if (oFrm != null)
                {
                    oFrm.BringToFront();
                    return;
                }

                DataGridViewRow Fila = dgvEstablecimientos.CurrentRow;

                if (Fila != null)
                {
                    int idEmpresa = Convert.ToInt32(Fila.Cells[0].Value);
                    int idLocal = Convert.ToInt32(Fila.Cells[1].Value);
                    int idEstablecimiento = Convert.ToInt32(Fila.Cells[2].Value);
                    int idZona = Convert.ToInt32(Fila.Cells[4].Value);
                    string desZona = Convert.ToString(Fila.Cells[5].Value);

                    oFrm = new frmDetalleZonas(idEmpresa, idLocal, idEstablecimiento, idZona, EnumOpcionGrabar.Actualizar, desZona);
                    oFrm.MdiParent = this.MdiParent;
                    oFrm.FormClosing += new FormClosingEventHandler(oFrmZonas_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Editar()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmEstablecimientos);

                if (oFrm != null)
                {
                    oFrm.BringToFront();
                    return;
                }
                
                DataGridViewRow Fila = dgvEstablecimientos.CurrentRow;

                if (Fila != null)
                {
                    int idEmpresa = Convert.ToInt32(Fila.Cells[0].Value);
                    int idLocal = Convert.ToInt32(Fila.Cells[1].Value);
                    int idEstablecimiento = Convert.ToInt32(Fila.Cells[2].Value);
                    NuevoItem = "M";

                    oFrm = new frmEstablecimientos(idEmpresa, idLocal, idEstablecimiento, EnumOpcionGrabar.Actualizar, ((EstablecimientosE)cboEstablecimiento.SelectedItem).Descripcion);
                    oFrm.MdiParent = this.MdiParent;
                    oFrm.FormClosing += new FormClosingEventHandler(oFrmEstablecimiento_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Buscar()
        {
            List<EstablecimientosE> oListaEstablecimientos = AgenteMaestro.Proxy.ListarEstablecimientosZonas(Convert.ToInt32(lblCodigoEmpresa.Text), Convert.ToInt32(cboSucursal.SelectedValue), Convert.ToInt32(cboEstablecimiento.SelectedValue));

            var NuevoReporte = (from x in oListaEstablecimientos
                                select new { x.idEmpresa, x.idLocal, x.idEstablecimiento, Establecimiento = x.idEstablecimiento + " - " + x.Descripcion, x.idZona, x.desZona });

            dgvEstablecimientos.DataSource = NuevoReporte.ToList();
            OtroFormato();

            dgvEstablecimientos.GrupoColumnas = new String[] { "Establecimiento" };
            lblRegistros.Text = "Registros " + oListaEstablecimientos.Count.ToString();
        }

        public override void Anular()
        {
            try
            {
                if (dgvEstablecimientos.Rows.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        //AgenteMaestro.Proxy.EliminarEstablecimientos(((EstablecimientosE)bsEstablecimientos.Current).idEmpresa, ((EstablecimientosE)bsEstablecimientos.Current).idLocal, ((EstablecimientosE)bsEstablecimientos.Current).idEstablecimiento);
                        Buscar();
                        Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                        base.Anular();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        private void oFrmEstablecimiento_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmEstablecimientos oFrm = sender as frmEstablecimientos;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                if (NuevoItem == "N")
                {
                    oListaEstablecimientosCombo.Add(oFrm.oEstablecimiento);
                    ComboHelper.RellenarCombos<EstablecimientosE>(cboEstablecimiento, (from x in oListaEstablecimientosCombo orderby x.idEstablecimiento select x).ToList(), "idEstablecimiento", "Descripcion", false);
                }
                
                Buscar();
            }
        }

        private void oFrmZonas_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmDetalleZonas oFrm = sender as frmDetalleZonas;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion Eventos de Usuario

        #region Eventos

        private void frmListadoEstablecimientos_Load(object sender, EventArgs e)
        {
            Grid = true;
            //base.Grabar();
            //BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
        }

        private void btBuscarEmpresa_Click(object sender, EventArgs e)
        {
            FrmBusquedaEmpresa oFrm = new FrmBusquedaEmpresa();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.empresa != null)
            {
                lblCodigoEmpresa.Text = oFrm.empresa.IdEmpresa.ToString();
                lblRazon.Text = oFrm.empresa.RazonSocial;
                lblRuc.Text = oFrm.empresa.RUC;

                LlenarCombo();
                cboSucursal_SelectionChangeCommitted(new Object(), new EventArgs());
            }
        }

        private void cboSucursal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                oListaEstablecimientosCombo = AgenteMaestro.Proxy.ListarEstablecimientos(Convert.ToInt32(lblCodigoEmpresa.Text), Convert.ToInt32(cboSucursal.SelectedValue));
                ComboHelper.RellenarCombos<EstablecimientosE>(cboEstablecimiento, (from x in oListaEstablecimientosCombo orderby x.idEstablecimiento select x).ToList(), "idEstablecimiento", "Descripcion", false);
                Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvEstablecimientos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 3)
                {
                    Editar();
                }
                else
                {
                    EditarZona();
                }
            }
        }

        private void btInsertarZona_Click(object sender, EventArgs e) //Establecimiento
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmEstablecimientos);

                if (oFrm != null)
                {
                    oFrm.BringToFront();
                    return;
                }

                NuevoItem = "N";
                oFrm = new frmEstablecimientos(Convert.ToInt32(lblCodigoEmpresa.Text), Convert.ToInt32(cboSucursal.SelectedValue), 0, EnumOpcionGrabar.Insertar, "");
                oFrm.MdiParent = MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrmEstablecimiento_FormClosing);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btBorrarZona_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEstablecimientos.Rows.Count == 0)
                {
                    int idEmpresa = Convert.ToInt32(lblCodigoEmpresa.Text);
                    int idLocal = Convert.ToInt32(cboSucursal.SelectedValue);
                    int idEstablecimiento = Convert.ToInt32(cboEstablecimiento.SelectedValue);

                    if (idEstablecimiento == 0)
                    {
                        Global.MensajeComunicacion("Debe escoger una zona antes de eliminar.");
                        return;
                    }

                    if (Global.MensajeConfirmacion("Desea eliminar la Zona eligida.") == DialogResult.Yes)
                    {
                        Int32 resp = AgenteMaestro.Proxy.EliminarEstablecimientos(idEmpresa, idLocal, idEstablecimiento);

                        if (resp > 0)
                        {
                            oListaEstablecimientosCombo.Remove(((EstablecimientosE)cboEstablecimiento.SelectedItem));
                            ComboHelper.RellenarCombos<EstablecimientosE>(cboEstablecimiento, (from x in oListaEstablecimientosCombo orderby x.idEstablecimiento select x).ToList(), "idEstablecimiento", "Descripcion", false);
                            //Buscar();
                        }
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Debe eliminar los items antes de eliminar la Zona escogida");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btInsertarInfluencia_Click(object sender, EventArgs e) //Zonas de Influencia
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmDetalleZonas);

                if (oFrm != null)
                {
                    oFrm.BringToFront();
                    return;
                }

                int Codigo = 0;

                if (dgvEstablecimientos.Rows.Count > 0)
                {
                    Codigo = dgvEstablecimientos.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["idZona"].Value));
                    Codigo++;
                }
                else
                {
                    Codigo = 1;
                }
                
                oFrm = new frmDetalleZonas(Convert.ToInt32(lblCodigoEmpresa.Text), Convert.ToInt32(cboSucursal.SelectedValue), Convert.ToInt32(cboEstablecimiento.SelectedValue), Codigo, EnumOpcionGrabar.Insertar, "");
                oFrm.MdiParent = MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrmZonas_FormClosing);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btQuitarInfluencia_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEstablecimientos.Rows.Count > 0)
                {
                    DataGridViewRow Fila = dgvEstablecimientos.CurrentRow;

                    if (Fila != null)
                    {
                        int idEmpresa = Convert.ToInt32(Fila.Cells[0].Value);
                        int idLocal = Convert.ToInt32(Fila.Cells[1].Value);
                        int idEstablecimiento = Convert.ToInt32(Fila.Cells[2].Value);
                        int idZona = Convert.ToInt32(Fila.Cells[4].Value);

                        if (Global.MensajeConfirmacion("Desea eliminar la Zona de Influencia eligida.") == DialogResult.Yes)
                        {
                            Int32 resp = new VentasServiceAgent().Proxy.EliminarZonaTrabajo(idEmpresa, idLocal, idEstablecimiento, idZona);

                            if (resp > 0)
                            {
                                Buscar();
                            }
                        }
                    } 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboEstablecimiento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Eventos

    }
}
