using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Recursos;
using Presentadora.AgenteServicio;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Entidades.Seguridad;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmCierre : FrmMantenimientoBase
    {

        public frmCierre()
        {
            Global.AjustarResolucion(this);
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvSistema, false);
            FormatoGrid(dgvAlm, false);
        }

        public frmCierre(PeriodosE Periodos)
            : this()
        {
            Periodo = Periodos;
        }

        #region Variables

        //MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        //GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        PeriodosE Periodo = null;
        //Int32 opcion;

        #endregion

        void Editar1()
        {
            try
            {
                if (bsCierreAlmacen.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCierreAlmacen);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        //si la instancia existe la pongo en primer plano
                        oFrm.BringToFront();
                        return;
                    }

                    //sino existe la instancia se crea una nueva
                    oFrm = new frmCierreAlmacen((CierreAlmacenE)bsCierreAlmacen.Current)
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void Editar2()
        {
            try
            {
                if (bsCierreSistema.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCierreSistema);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        //si la instancia existe la pongo en primer plano
                        oFrm.BringToFront();
                        return;
                    }

                    //sino existe la instancia se crea una nueva
                    oFrm = new frmCierreSistema(((CierreSistemaE)bsCierreSistema.Current))
                    {
                        MdiParent = MdiParent
                    };
                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing2);
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
            try
            {
                Periodo.ListaCierreAlmacen = AgenteContabilidad.Proxy.ListarCierreAlmacen(Periodo.idEmpresa, Periodo.AnioPeriodo, Periodo.MesPeriodo);
                Periodo.ListaCierreSistema = AgenteContabilidad.Proxy.ListarCierreSistema(Periodo.idEmpresa, Periodo.AnioPeriodo, Periodo.MesPeriodo);

                bsCierreAlmacen.DataSource = Periodo.ListaCierreAlmacen;
                bsCierreAlmacen.ResetBindings(false);

                bsCierreSistema.DataSource = Periodo.ListaCierreSistema;
                bsCierreSistema.ResetBindings(false);

                lblReg1.Text = "Registros " + bsCierreAlmacen.Count.ToString();

                lblReg2.Text = "Registros " + bsCierreSistema.Count.ToString();

                base.Buscar();
                
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btnAgregarAlm_Click(object sender, EventArgs e)
        {
            try
            {

                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCierreAlmacen);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }
                oFrm = new frmCierreAlmacen(Periodo.AnioPeriodo, Periodo.MesPeriodo);
                oFrm.MdiParent = this.MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();

            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsCierreAlmacen.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteContabilidad.Proxy.EliminarCierreAlmacen(((CierreAlmacenE)bsCierreAlmacen.Current).idEmpresa, ((CierreAlmacenE)bsCierreAlmacen.Current).AnioPeriodo, ((CierreAlmacenE)bsCierreAlmacen.Current).MesPeriodo, ((CierreAlmacenE)bsCierreAlmacen.Current).idAlmacen);
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

        private void btnAgreSis_Click(object sender, EventArgs e)
        {
            try
            {

                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCierreSistema);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }
                oFrm = new frmCierreSistema(Periodo.AnioPeriodo, Periodo.MesPeriodo);
                oFrm.MdiParent = this.MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing2);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btnEliSis_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsCierreSistema.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteContabilidad.Proxy.EliminarCierreSistema(((CierreSistemaE)bsCierreSistema.Current).idEmpresa, ((CierreSistemaE)bsCierreSistema.Current).AnioPeriodo, ((CierreSistemaE)bsCierreSistema.Current).MesPeriodo, ((CierreSistemaE)bsCierreSistema.Current).idSistema);
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

        private void dgvAlm_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar1();
            }
        }

        private void dgvSistema_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar2();
            }
        }

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmCierreAlmacen oFrm = sender as frmCierreAlmacen;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void oFrm_FormClosing2(Object sender, FormClosingEventArgs e)
        {
            frmCierreSistema oFrm = sender as frmCierreSistema;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmCierre_Load(object sender, EventArgs e)
        {
            Grid = true;
            Buscar();
        }
    }
}
