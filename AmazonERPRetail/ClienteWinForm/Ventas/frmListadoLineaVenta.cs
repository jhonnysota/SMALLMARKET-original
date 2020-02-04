using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoLineaVenta : FrmMantenimientoBase
    {
        
        public frmListadoLineaVenta()
        {
            InitializeComponent();
            FormatoGrid(dgvDocumentos, true);
            AnchoColumnas();
            
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<LineaE> ListaLinea = null;

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            dgvDocumentos.Columns[0].Width = 35; //cod Linea
            dgvDocumentos.Columns[1].Width = 80; //Descripcion
            dgvDocumentos.Columns[2].Width = 90; //UsuarioRegistro
            dgvDocumentos.Columns[3].Width = 126; //FechaRegistro
            dgvDocumentos.Columns[4].Width = 90; //UsuarioModificacion
            dgvDocumentos.Columns[5].Width = 126; //FechaModificacion
        }

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmLineaVenta);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmLineaVenta();
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
                ListaLinea = AgenteVentas.Proxy.ListarLinea(VariablesLocales.SesionLocal.IdEmpresa);

                Lineabs.DataSource = ListaLinea;
                Lineabs.ResetBindings(false);

                base.Buscar();
                LblTitulo.Text = Lineabs.Count.ToString() + " Registros";
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
                if (Lineabs.Count > 0)
                {

                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmLineaVenta);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }


                    oFrm = new frmLineaVenta(((LineaE)Lineabs.Current).idEmpresa, ((LineaE)Lineabs.Current).idLinea);
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
                if (Lineabs.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteVentas.Proxy.EliminarLinea(((LineaE)Lineabs.Current).idEmpresa, ((LineaE)Lineabs.Current).idLinea);
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

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmLineaVenta oFrm = sender as frmLineaVenta;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoLineaVenta_Load(object sender, EventArgs e)
        {
            Grid = true;
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void frmListadoLineaVenta_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        }

        #endregion                   
                       
                
    }
}
