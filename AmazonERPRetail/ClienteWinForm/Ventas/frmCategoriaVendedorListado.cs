using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClienteWinForm.Ventas
{
    public partial class frmCategoriaVendedorListado : FrmMantenimientoBase
    {

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<CategoriaVendedorE> oListaCategoria;

        public frmCategoriaVendedorListado()
        {
            InitializeComponent();
            FormatoGrid(dgvListado, true);
            
        }

        private void frmCategoriaVendedorListado_Load(object sender, EventArgs e)
        {
            Grid = true;

            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
            BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            
        }

        public override void Buscar()
        {
            try
            {
                oListaCategoria = AgenteVentas.Proxy.ListarCategoriaVendedor(txtBuscar.Text);

                // ================

                List<CategoriaVendedorE> oLista = new List<CategoriaVendedorE>();

                oListaCategoria = oListaCategoria.OrderBy(x => x.codCategoria).ToList();

                // ================
                string codCategoria = "";

                if (!chbVerDetalle.Checked)
                {
                    for (int i = 0; i < oListaCategoria.Count; i++)
                    {
                        if (codCategoria == "")
                        {
                            codCategoria = oListaCategoria[i].codCategoria;

                            oLista.Add(oListaCategoria[i]);
                        }

                        if (codCategoria != oListaCategoria[i].codCategoria)
                        {
                            codCategoria = oListaCategoria[i].codCategoria;

                            oLista.Add(oListaCategoria[i]);
                        }
                    }

                }
                else
                {

                    for (int i = 0; i < oListaCategoria.Count; i++)
                    {
                        if (codCategoria == "")
                        {
                            codCategoria = oListaCategoria[i].codCategoria;

                            oLista.Add(oListaCategoria[i]);

                            //if (oListaCategoria[i].codLinea.Trim().Length > 0)
                            //    oLista.Add(new CategoriaVendedorE() { desCategoria = oListaCategoria[i].codLinea + " - " + oListaCategoria[i].desLinea });
                        }

                        if (codCategoria != oListaCategoria[i].codCategoria)
                        {
                            codCategoria = oListaCategoria[i].codCategoria;

                            oLista.Add(oListaCategoria[i]);

                            //if(oListaCategoria[i].codLinea.Trim().Length>0)
                            //    oLista.Add(new CategoriaVendedorE() { desCategoria = oListaCategoria[i].codLinea + " - " + oListaCategoria[i].desLinea });
                        }

                        //if (i > 0 )
                        //{
                            if (oListaCategoria[i].codLinea.Trim().Length > 0)
                                oLista.Add(new CategoriaVendedorE() { desCategoria = oListaCategoria[i].codLinea + " - " + oListaCategoria[i].desLinea });
                        //}

                    }
                }
                // ================

                bsCategoriaVendedor.DataSource = oLista;
                bsCategoriaVendedor.ResetBindings(false);

                base.Buscar();
                lblRegistros.Text = "Categorias - " + bsCategoriaVendedor.Count.ToString() + " Registros ";
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
                if (bsCategoriaVendedor.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        int idempresa = ((CategoriaVendedorE)bsCategoriaVendedor.Current).idEmpresa;
                        int idCategoria = ((CategoriaVendedorE)bsCategoriaVendedor.Current).idCategoria;

                        AgenteVentas.Proxy.EliminarCategoriaVendedor(idempresa, idCategoria);
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

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        // ===================================================================================
        // EDITAR ITEM
        // ===================================================================================
        public override void Editar()
        {
            try
            {
                if (bsCategoriaVendedor.Count > 0)
                {

                    if (((CategoriaVendedorE)bsCategoriaVendedor.Current).codCategoria != null)
                    {
                        Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCategoriaVendedor);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmCategoriaVendedor((CategoriaVendedorE)bsCategoriaVendedor.Current);
                        oFrm.MdiParent = this.MdiParent;
                        oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                        oFrm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }

        }
        // ==================
        // CLOSING
        // ==================
        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmCategoriaVendedor oFrm = sender as frmCategoriaVendedor;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        // ==================
        // NUEVO
        // ==================
        public override void Nuevo()
        {
            try
            {
                if (!ValidarIngresoVentana())
                {
                    return;
                }

                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCategoriaVendedor);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                CategoriaVendedorE oNuevo = new CategoriaVendedorE();
                
                oNuevo.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                oNuevo.idCategoria = 0;

                oFrm = new frmCategoriaVendedor(oNuevo);

                oFrm.MdiParent = this.MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        int oRow =-1;

        private void dgvListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (chbVerDetalle.Checked)
            {
                if (dgvListado.Columns[e.ColumnIndex].Name == "codCategoriaDataGridViewTextBoxColumn")
                {
                    if (dgvListado.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                        oRow = e.RowIndex;
                    else
                        oRow=-1;
                }


                if (oRow ==e.RowIndex)
                    dgvListado.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = e.CellStyle.BackColor = Color.Bisque;
            }
        }

        private void chbVerDetalle_CheckedChanged(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
