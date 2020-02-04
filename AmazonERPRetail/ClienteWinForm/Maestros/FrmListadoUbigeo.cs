using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Winform;

namespace ClienteWinForm.Maestros
{
    public partial class FrmListadoUbigeo : FrmMantenimientoBase
    {
        #region Constructor

        public FrmListadoUbigeo()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvUbigeo, true);
            LlenarCombos();
        }

         #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            List<PaisesE> ListaUbigeo = AgenteGeneral.Proxy.ListarPaises();
            PaisesE p1 = new PaisesE() { idPais = Variables.Cero, Nombre = Variables.Seleccione };
            ListaUbigeo.Add(p1);
            ComboHelper.RellenarCombos<PaisesE>(cboidPais, (from x in ListaUbigeo orderby x.idPais select x).ToList(), "idPais", "Nombre", false);
        }

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmUbigeo);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new FrmUbigeo();
                oFrm.MdiParent = this.MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
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
                if (!chkIndBaja.Checked)
                {
                    bsUbigeo.DataSource = AgenteMaestro.Proxy.ListarUbigeo(Convert.ToInt32(cboidPais.SelectedValue), false, false);
                }
                else
                {
                    bsUbigeo.DataSource = AgenteMaestro.Proxy.ListarUbigeo(Convert.ToInt32(cboidPais.SelectedValue), true, false);
                }

                base.Buscar();
                lblRegistros.Text = "Registros " + bsUbigeo.Count.ToString();
                dgvUbigeo.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Editar()
        {
            try
            {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmUbigeo);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new FrmUbigeo((UbigeoE)bsUbigeo.Current);
                    oFrm.MdiParent = this.MdiParent;
                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                if (bsUbigeo.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteMaestro.Proxy.AnularUbigeo(((UbigeoE)bsUbigeo.Current).idUbigeo, ((UbigeoE)bsUbigeo.Current).UsuarioModificacion);
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

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            FrmUbigeo oFrm = sender as FrmUbigeo;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void FrmListadoUbigeo_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
        }

        private void dgvUbigeo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void dgvUbigeo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((Boolean)dgvUbigeo.Rows[e.RowIndex].Cells["indBaja"].Value == true)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado;
                }
            }
        }

        #endregion

    }
}
