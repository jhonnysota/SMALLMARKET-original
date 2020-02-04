using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarGuia : FrmBusquedaBase
    {

        public frmBuscarGuia()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.AjustarResolucion(this);

            FormatoGrid(dgvDocumentos);
            AnchoColumnas();
            LlenarCombo();
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        public List<EmisionDocumentoE> oListaGuias = null;
        //public EmisionDocumentoE oDocumento = null;
        public List<EmisionDocumentoE> oListaDocumentos = null;

        Int32 TotalChecks = 0;
        Int32 TotalCheckeados = 0;
        CheckBox CheckBoxCab = null;
        Boolean indClickCab = false;

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            dgvDocumentos.Columns[0].Width = 20; //Checkbox
            dgvDocumentos.Columns[1].Width = 40; //id Documento
            dgvDocumentos.Columns[2].Width = 60; //Serie
            dgvDocumentos.Columns[3].Width = 80; //Número
            dgvDocumentos.Columns[4].Width = 80; //Fecha de Emisión
            dgvDocumentos.Columns[5].Width = 200; //Razón Social
        }

        void LlenarCombo()
        {
            List<NumControlDetE> ListaGuias = AgenteVentas.Proxy.ListarNumControlDetPorGrupo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 
                                                VariablesLocales.SesionLocal.IdLocal, EnumGrupoDocumentos.G.ToString());
            ComboHelper.RellenarCombos<NumControlDetE>(cboTipoDocumento, ListaGuias, "idDocumento", "desDocumento");
        }

        void BuscarFiltro()
        {
            bsBase.DataSource = (from x in oListaGuias
                                        where x.RazonSocial.ToUpper().Contains(txtFiltro.Text.ToUpper())
                                        select x).ToList();
            
            
            //lblTitulo.Text = "Documentos [ " + bsDocumentos.Count.ToString() + " Registros ]";
        }

        #endregion

        #region Eventos y procedimientos checkBox

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            indClickCab = true;

            foreach (DataGridViewRow Row in dgvDocumentos.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["myCheck"]).Value = HCheckBox.Checked;
            }

            dgvDocumentos.RefreshEdit();
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
            dgvDocumentos.Controls.Add(CheckBoxCab);
        }

        private void CambiarUbicacionCheckBox(Int32 ColumnIndex, Int32 RowIndex)
        {
            //Obtener limites de la celda de la cabecera que va a contener el checkbox
            Rectangle oRectangle = dgvDocumentos.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

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

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                if (((NumControlDetE)cboTipoDocumento.SelectedItem).idDocumento == EnumTipoDocumentoVenta.GV.ToString())
                {
                    bsBase.DataSource = oListaGuias = AgenteVentas.Proxy.ListarDocumentosEmitidos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, EnumTipoDocumentoVenta.GV.ToString());
                }
                else if(((NumControlDetE)cboTipoDocumento.SelectedItem).idDocumento == EnumTipoDocumentoVenta.GT.ToString())
                {
                    bsBase.DataSource = oListaGuias = AgenteVentas.Proxy.ListarDocumentosEmitidos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, EnumTipoDocumentoVenta.GT.ToString());
                }
                else if (((NumControlDetE)cboTipoDocumento.SelectedItem).idDocumento == "ST")
                {
                    bsBase.DataSource = oListaGuias = AgenteVentas.Proxy.ListarDocumentosEmitidos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, "ST");
                }

                if (bsBase.Count > 0)
                {
                    dgvDocumentos.Enabled = true;

                    if (!String.IsNullOrEmpty(txtFiltro.Text))
                    {
                        BuscarFiltro();
                    }
                }
                else
                {
                    dgvDocumentos.Enabled = false;
                }

                TotalChecks = dgvDocumentos.RowCount;
                TotalCheckeados = 0;
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                Int32 Contador = Variables.Cero;
                oListaDocumentos = new List<EmisionDocumentoE>();

                foreach (EmisionDocumentoE item in bsBase.List)
                {
                    if (item.Check)
                    {
                        EmisionDocumentoE doc = new EmisionDocumentoE();

                        doc = AgenteVentas.Proxy.RecuperarGuiaCompleta(item.idEmpresa, item.idLocal, item.idDocumento, item.numSerie, item.numDocumento);

                        if (doc != null)
                        {
                            oListaDocumentos.Add(doc);
                        }

                        Contador++;
                    }                                 
                }

                if (Contador != Variables.Cero)
                {
                    var ListaTemp = oListaDocumentos.GroupBy(x => x.RazonSocial).Select(p => p.First()).ToList();

                    if (ListaTemp.ToList().Count > 1)
                    {
                        Global.MensajeComunicacion("Las guias deben ser del mismo cliente.");
                        return;
                    }

                    base.Aceptar();
                }
                else
                {
                    Global.MensajeFault("No hay ningún registro con check. Escoja uno o Presione Cancelar.");
                }
            }
        }

        protected override void Cancelar()
        {
            base.Cancelar();
        }

        #endregion

        #region Eventos

        private void frmBuscarGuia_Load(object sender, EventArgs e)
        {
            cboTipoDocumento.SelectedValue = EnumTipoDocumentoVenta.GV.ToString();
            AñadirCheckBox();

            CheckBoxCab.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            CheckBoxCab.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
        }

        private void dgvDocumentos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                CambiarUbicacionCheckBox(e.ColumnIndex, e.RowIndex);
            }

            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvDocumentos, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dgvDocumentos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDocumentos.Rows.Count != 0)
            {
                if (!indClickCab)
                {
                    FilaCheBoxClick((DataGridViewCheckBoxCell)dgvDocumentos[e.ColumnIndex, e.RowIndex]);
                }
            }
        }

        private void dgvDocumentos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDocumentos.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvDocumentos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            if (oListaGuias != null && oListaGuias.Count > Variables.Cero)
            {
                BuscarFiltro();
            }
        }

        #endregion

    }
}
