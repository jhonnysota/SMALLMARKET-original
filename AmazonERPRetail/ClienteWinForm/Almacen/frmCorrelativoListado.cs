using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Recursos;

namespace ClienteWinForm.Almacen
{
    public partial class frmCorrelativoListado : FrmMantenimientoBase
    {
        public frmCorrelativoListado()
        {
            InitializeComponent();
            FormatoGrid(dgvCorrelativo, true);
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        List<CorrelativoE> ListaCorrelativos = null;

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCorrelativo);

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
                oFrm = new frmCorrelativo();
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
                ListaCorrelativos = AgenteAlmacen.Proxy.ListarCorrelativo();

                bsCorrelativo.DataSource = ListaCorrelativos;
                bsCorrelativo.ResetBindings(false);

                base.Buscar();
                lblRegistros.Text = "Correlativo [ " + bsCorrelativo.Count.ToString() + " Registros ]";
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
                if (bsCorrelativo.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCorrelativo);

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
                    oFrm = new frmCorrelativo(((CorrelativoE)bsCorrelativo.Current).idEmpresa, ((CorrelativoE)bsCorrelativo.Current).idCorrelativo);
                    oFrm.MdiParent = this.MdiParent;
                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
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
                if (bsCorrelativo.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteAlmacen.Proxy.EliminarCorrelativo(((CorrelativoE)bsCorrelativo.Current).idEmpresa, ((CorrelativoE)bsCorrelativo.Current).idCorrelativo);
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

        #region Eventos

        private void frmCorrelativoListado_Load(object sender, EventArgs e)
        {
            Grid = true;
            Buscar();
        }

        private void frmCorrelativoListado_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        }

        private void dgvCorrelativo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmCorrelativo oFrm = sender as frmCorrelativo;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion
    }
}
