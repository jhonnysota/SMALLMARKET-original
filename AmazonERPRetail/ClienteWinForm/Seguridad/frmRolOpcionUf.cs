using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Seguridad;
using Infraestructura;

namespace ClienteWinForm.Seguridad
{
    public partial class frmRolOpcionUf : FrmMantenimientoBase
    {

        public frmRolOpcionUf()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvOpciones, false);
            FormatoGrid(dgvRoles, true);
        }

        #region Variables

        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        List<Opcion> oListaPrincipal = null;
        List<Opcion> oListaTemporal = null;
        List<Rol> oListaRoles = null;

        Int32 TotalChecks = 0;
        Int32 TotalCheckeados = 0;
        CheckBox CheckBoxCab = null;
        Boolean indClickCab = false;

        #endregion

        #region Procedimientos de Usuario

        public void LlenaOpciones(Opcion ItemOpcion)
        {
            if ((from x in oListaTemporal where x.GrupoOpcion == ItemOpcion.IdOpcion select x).Count() > 0)
            {
                foreach (Opcion item in (from x in oListaTemporal where x.GrupoOpcion == ItemOpcion.IdOpcion orderby x.Orden select x).ToList())
                {
                    oListaPrincipal.Add(item);
                    LlenaOpciones(item);
                }
            }
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

            foreach (DataGridViewRow Row in dgvOpciones.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["OK"]).Value = HCheckBox.Checked;
            }

            dgvOpciones.RefreshEdit();
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
            dgvOpciones.Controls.Add(CheckBoxCab);
        }

        private void CambiarUbicacionCheckBox(Int32 ColumnIndex, Int32 RowIndex)
        {
            //Obtener limites de la celda de la cabecera que va a contener el checkbox
            Rectangle oRectangle = dgvOpciones.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

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
            try
            {
                oListaRoles = AgenteSeguridad.Proxy.RecuperarRolOpcion("", false, false);
                oListaTemporal = AgenteSeguridad.Proxy.ListarOpcionesParaRol("");

                if (oListaTemporal != null && oListaTemporal.Count > 0)
                {
                    oListaPrincipal = new List<Opcion>();

                    foreach (Opcion itemGrupo in (from x in oListaTemporal where x.GrupoOpcion == 0 select x).ToList())
                    {
                        oListaPrincipal.Add(itemGrupo);
                        LlenaOpciones(itemGrupo);
                    }

                    bsOpciones.DataSource = oListaPrincipal;
                    bsOpciones.ResetBindings(false);

                    dgvOpciones.AutoResizeColumns();
                }

                bsRoles.DataSource = oListaRoles;
                lblRoles.Text = "Registros " + oListaRoles.Count.ToString();
                lblRegistros.Text = "Registros " + oListaPrincipal.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Grabar()
        {
            try
            {
                Rol oRol = (Rol)bsRoles.Current;
                oRol.OpcionesRol = new List<Opcion>();

                foreach (DataGridViewRow Fila in dgvOpciones.Rows)
                {
                    if (Convert.ToBoolean(Fila.Cells[0].Value) == true)
                    {
                        oRol.OpcionesRol.Add((Opcion)Fila.DataBoundItem);
                    }
                }

                String Respuesta = AgenteSeguridad.Proxy.GrabarRolOpcion(oRol);
                Global.MensajeComunicacion(Respuesta);

                base.Grabar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        } 

        #endregion

        #region Eventos

        private void frmRolOpcionUf_Load(object sender, EventArgs e)
        {
            AñadirCheckBox();

            CheckBoxCab.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            CheckBoxCab.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);

            BloquearOpcion(Infraestructura.Enumerados.EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(Infraestructura.Enumerados.EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(Infraestructura.Enumerados.EnumOpcionMenuBarra.Grabar, true);
        }

        private void dgvOpciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((int)dgvOpciones.Rows[e.RowIndex].Cells["GrupoOpcion"].Value == 0)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 230, 153);
                    e.CellStyle.SelectionBackColor = Color.FromArgb(38, 38, 38);
                    e.CellStyle.SelectionForeColor = Color.FromArgb(255, 255, 255);
                    e.CellStyle.Font = new Font(dgvOpciones.DefaultCellStyle.Font, FontStyle.Bold);
                }
            }
        }

        private void dgvOpciones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (dgvOpciones.Rows.Count != 0)
            {
                if (e.RowIndex == -1 && e.ColumnIndex == 0)
                {
                    CambiarUbicacionCheckBox(e.ColumnIndex, e.RowIndex);
                }
            }
        }

        private void dgvOpciones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOpciones.Rows.Count != 0)
            {
                if (!indClickCab)
                {
                    FilaCheBoxClick((DataGridViewCheckBoxCell)dgvOpciones[e.ColumnIndex, e.RowIndex]);
                }
            }
        }

        private void dgvOpciones_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvOpciones.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvOpciones.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void bsRoles_CurrentChanged(object sender, EventArgs e)
        {
            if (oListaRoles.Count > 0 && oListaPrincipal.Count > 0)
            {
                List<Opcion> oListaTemp = new List<Opcion>(oListaPrincipal);
                Rol oRol = (Rol)bsRoles.Current;

                foreach (Opcion item in oListaTemp)
                {
                    Opcion op = (from x in oRol.OpcionesRol
                                 where x.IdOpcion == item.IdOpcion
                                 select x).FirstOrDefault();

                    item.OK = op != null ? true : false;
                }

                bsOpciones.DataSource = oListaTemp;
                bsOpciones.ResetBindings(false);

                TotalChecks = oListaPrincipal.Count;
                TotalCheckeados = (from x in oListaTemp where x.OK == true select x).Count();
                oListaTemp = null;
                oRol = null;
            }
        } 

        #endregion

    }
}
