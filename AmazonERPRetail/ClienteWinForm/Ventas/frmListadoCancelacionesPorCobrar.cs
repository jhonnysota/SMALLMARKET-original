using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoCancelacionesPorCobrar : FrmMantenimientoBase
    {

        public frmListadoCancelacionesPorCobrar()
        {
            InitializeComponent();
            LlenarCombos();
            FormatoGrid(dgvCobranzas, true);
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }

        //Para el check del datagridview
        Int32 TotalChecks = 0;
        Int32 TotalCheckeados = 0;
        CheckBox CheckBoxCab = null;
        Boolean indClickCab = false;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            ////// Documentos ///////
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                                      where x.indBaja == false
                                                                      select x).ToList();
            ListaDocumentos.Add(new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione });
            ComboHelper.RellenarCombos<DocumentosE>(cboDocumentoRec, (from x in ListaDocumentos
                                                                      orderby x.desDocumento
                                                                      select x).ToList(), "idDocumento", "desDocumento", false);
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

            foreach (DataGridViewRow Row in dgvCobranzas.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["Marcar"]).Value = HCheckBox.Checked;
            }

            dgvCobranzas.RefreshEdit();
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
            CheckBoxCab = new CheckBox
            {
                Size = new Size(15, 15)
            };

            // Añadiendo el CheckBox dentro de la cabecera del datagridview
            dgvCobranzas.Controls.Add(CheckBoxCab);
        }

        private void CambiarUbicacionCheckBox(Int32 ColumnIndex, Int32 RowIndex)
        {
            //Obtener limites de la celda de la cabecera que va a contener el checkbox
            Rectangle oRectangle = dgvCobranzas.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point
            {
                X = oRectangle.Location.X + (oRectangle.Width - CheckBoxCab.Width) / 2 + 1,
                Y = oRectangle.Location.Y + (oRectangle.Height - CheckBoxCab.Height) / 2 + 1
            };

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

        public override void Buscar()
        {
            String idDoc = cboDocumentoRec.SelectedValue.ToString() == "0" ? "%" : cboDocumentoRec.SelectedValue.ToString();
            string fecIni = chkCobranza.Checked ? dtpFecInicio.Value.ToString("yyyyMMdd") : string.Empty;
            string fecFin = chkCobranza.Checked ? dtpFecFin.Value.ToString("yyyyMMdd") : string.Empty;

            bsCancelaciones.DataSource = AgenteVentas.Proxy.ListarEmisionDocumentoCancelacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idDoc, txtSerieRec.Text.Trim(), txtNumRec.Text.Trim(), fecIni, fecFin);
            bsCancelaciones.ResetBindings(false);

            //Inicializando el checkbox del datagridview
            CheckBoxCab.Checked = false;
            HeaderCheckBoxClick(CheckBoxCab);

            TotalChecks = bsCancelaciones.Count;
            TotalCheckeados = 0;
        }

        #endregion

        #region Eventos

        private void frmListadoCancelacionesPorCobrar_Load(object sender, EventArgs e)
        {
            dtpFecInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            AñadirCheckBox();
            CheckBoxCab.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            CheckBoxCab.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
        }

        private void btGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsCancelaciones.List.Count == 0)
                {
                    Global.MensajeAdvertencia("No existen registros para la generación de ka cobranza.");
                    return;
                }

                Int32 Contador = 0;

                foreach (EmisionDocumentoCancelacionE item in bsCancelaciones.List)
                {
                    if (item.Marcar)
                    {
                        Contador++;
                    }
                }

                if (Contador == 0)
                {
                    Global.MensajeAdvertencia("Tiene que escoger registros antes de generar la cobranza.");
                    return;
                }

                Int32 resp = AgenteVentas.Proxy.GenerarCobranzas((List<EmisionDocumentoCancelacionE>)bsCancelaciones.List, VariablesLocales.SesionUsuario.Credencial);

                if (resp > 0)
                {
                    Buscar();
                    Global.MensajeComunicacion("Cobranza registrada... !!!");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsCancelaciones_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = "Registros " + bsCancelaciones.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvCobranzas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                CambiarUbicacionCheckBox(e.ColumnIndex, e.RowIndex);
            }
        }

        private void dgvCobranzas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCobranzas.Rows.Count != 0)
            {
                if (!indClickCab)
                {
                    FilaCheBoxClick((DataGridViewCheckBoxCell)dgvCobranzas[e.ColumnIndex, e.RowIndex]);
                }
            }
        }

        private void dgvCobranzas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCobranzas.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvCobranzas.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        } 

        #endregion

    }
}
