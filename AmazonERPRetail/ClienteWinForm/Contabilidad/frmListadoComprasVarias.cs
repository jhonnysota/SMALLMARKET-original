using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmListadoComprasVarias : FrmMantenimientoBase
    {
        public frmListadoComprasVarias()
        {
            InitializeComponent();

            if (VariablesLocales.PeriodoContable == null)
            {
                Global.MensajeComunicacion("El año vigente no se encuentra aperturado.");
                panel1.Enabled = false; 
                panel3.Enabled = false;

            }
            else
            {
                LlenarCombos();
            }

            FormatoGrid(dgvDocumentos, true);
            AnchoColumnas();
            
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<ComprasVariasE> ListaComprasVarias = null;
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;
        Boolean Orden = true;

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            dgvDocumentos.Columns[0].Width = 250; //RazonSocial
            dgvDocumentos.Columns[1].Width = 30; //Moneda
            dgvDocumentos.Columns[2].Width = 80; //fecOperacion
            dgvDocumentos.Columns[3].Width = 65; //Acta
            dgvDocumentos.Columns[4].Width = 30; //tipDocumento
            dgvDocumentos.Columns[5].Width = 50; //serie
            dgvDocumentos.Columns[6].Width = 90; //Número
            dgvDocumentos.Columns[7].Width = 40; //tipCambio
            dgvDocumentos.Columns[8].Width = 90; //montAfecto
            dgvDocumentos.Columns[9].Width = 90; //montInafecto
            dgvDocumentos.Columns[10].Width = 70; //Montigv
            dgvDocumentos.Columns[11].Width = 90; ///montTotal
            dgvDocumentos.Columns[12].Width = 20; // indRectificacion
            dgvDocumentos.Columns[13].Width = 80; //fecRectificacion
            dgvDocumentos.Columns[14].Width = 90; //usuario registro
            dgvDocumentos.Columns[15].Width = 126; //fecha registro
            dgvDocumentos.Columns[16].Width = 90; //usuario mod
            dgvDocumentos.Columns[17].Width = 126; //fecha mod
        }

        void LlenarCombos()
        {
            /////PERIODO////
            //DataTable oDt = Global.CargarMesesContable("MA");
            //DataRow Fila = oDt.NewRow();
            //Fila["MesId"] = "0";
            //Fila["MesDes"] = Variables.TextoTodos;
            //oDt.Rows.Add(Fila);

            //oDt.DefaultView.Sort = "MesId";
            cboPeriodo.DataSource = FechasHelper.CargarMesesContable("MA"); ;
            cboPeriodo.ValueMember = "MesId";
            cboPeriodo.DisplayMember = "MesDes";
            cboPeriodo.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            /////ANIOS/////
            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 10 ;

            cboAnio.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboAnio.ValueMember = "AnioId";
            cboAnio.DisplayMember = "AnioDes";
            cboAnio.SelectedValue = Convert.ToInt32(Anio);
        }

        void BuscarFiltro()
        {
            bsComprasVarias.DataSource = (from x in ListaComprasVarias
                                          where x.numRegistro.Contains(txtNroActa.Text)
                                          select x).ToList();

            lblRegistros.Text = "Compras Varias " + bsComprasVarias.Count.ToString() + " Registros";
        }

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmComprasVarias);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmComprasVarias(cboAnio.SelectedValue.ToString(), cboPeriodo.SelectedValue.ToString());
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
                String Periodo = cboPeriodo.SelectedValue.ToString();

                if (Periodo == Variables.Cero.ToString())
                {
                    Periodo = "%%";
                }

                String anio = cboAnio.SelectedValue.ToString();

                ListaComprasVarias = AgenteContabilidad.Proxy.ListarComprasVarias(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, anio, Periodo);

                if (String.IsNullOrEmpty(txtNroActa.Text))
                {
                    bsComprasVarias.DataSource = ListaComprasVarias;
                    bsComprasVarias.ResetBindings(false);
                }
                else
                {
                    if (ListaComprasVarias.Count > Variables.Cero)
                    {
                        BuscarFiltro();
                    }
                } 

                lblRegistros.Text = "Compras Varias " + bsComprasVarias.Count.ToString() + " Registros";
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
                if (bsComprasVarias.Count > 0)
                {

                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmComprasVarias);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new frmComprasVarias(((ComprasVariasE)bsComprasVarias.Current).idEmpresa, ((ComprasVariasE)bsComprasVarias.Current).idLocal, ((ComprasVariasE)bsComprasVarias.Current).AnioPeriodo, ((ComprasVariasE)bsComprasVarias.Current).MesPeriodo, ((ComprasVariasE)bsComprasVarias.Current).idComprobante);
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
                if (bsComprasVarias.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteContabilidad.Proxy.EliminarComprasVarias(((ComprasVariasE)bsComprasVarias.Current).idEmpresa, ((ComprasVariasE)bsComprasVarias.Current).idLocal, ((ComprasVariasE)bsComprasVarias.Current).AnioPeriodo, ((ComprasVariasE)bsComprasVarias.Current).MesPeriodo, ((ComprasVariasE)bsComprasVarias.Current).idComprobante);
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
            frmComprasVarias oFrm = sender as frmComprasVarias;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoComprasVarias_Load(object sender, EventArgs e)
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

        private void frmListadoComprasVarias_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        }

        private void txtNroActa_TextChanged(object sender, EventArgs e)
        {
            if (ListaComprasVarias != null && ListaComprasVarias.Count > Variables.Cero)
            {
                BuscarFiltro();
            }
        }

        private void dgvDocumentos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (ListaComprasVarias != null && ListaComprasVarias.Count > Variables.Cero)
            {
                if (e.Button == MouseButtons.Left)
                {
                    //Por Razón Social
                    if (dgvDocumentos.Columns[e.ColumnIndex].Name == "RazonSocial")
                    {
                        if (Orden)
                        {
                            ListaComprasVarias = (from x in ListaComprasVarias orderby x.RazonSocial ascending select x).ToList();
                            Orden = false;
                        }
                        else
                        {
                            ListaComprasVarias = (from x in ListaComprasVarias orderby x.RazonSocial descending select x).ToList();
                            Orden = true;
                        } 
                    }

                    //Por Fecha
                    if (dgvDocumentos.Columns[e.ColumnIndex].Name == "fecOperacion")
                    {
                        if (Orden)
                        {
                            ListaComprasVarias = (from x in ListaComprasVarias orderby x.fecOperacion ascending select x).ToList();
                            Orden = false;
                        }
                        else
                        {
                            ListaComprasVarias = (from x in ListaComprasVarias orderby x.fecOperacion descending select x).ToList();
                            Orden = true;
                        }
                    }

                    //Por Acta
                    if (dgvDocumentos.Columns[e.ColumnIndex].Name == "numRegistro")
                    {
                        if (Orden)
                        {
                            ListaComprasVarias = (from x in ListaComprasVarias orderby x.numRegistro ascending select x).ToList();
                            Orden = false;
                        }
                        else
                        {
                            ListaComprasVarias = (from x in ListaComprasVarias orderby x.numRegistro descending select x).ToList();
                            Orden = true;
                        }
                    }

                    //Por tipo de Documento
                    if (dgvDocumentos.Columns[e.ColumnIndex].Name == "tipDocumento")
                    {
                        if (Orden)
                        {
                            ListaComprasVarias = (from x in ListaComprasVarias orderby x.tipDocumento ascending select x).ToList();
                            Orden = false;
                        }
                        else
                        {
                            ListaComprasVarias = (from x in ListaComprasVarias orderby x.tipDocumento descending select x).ToList();
                            Orden = true;
                        }
                    }

                    //Por serie de Documento
                    if (dgvDocumentos.Columns[e.ColumnIndex].Name == "serDocumento")
                    {
                        if (Orden)
                        {
                            ListaComprasVarias = (from x in ListaComprasVarias orderby x.serDocumento ascending select x).ToList();
                            Orden = false;
                        }
                        else
                        {
                            ListaComprasVarias = (from x in ListaComprasVarias orderby x.serDocumento descending select x).ToList();
                            Orden = true;
                        }
                    }

                    //Por número de Documento
                    if (dgvDocumentos.Columns[e.ColumnIndex].Name == "numDocumento")
                    {
                        if (Orden)
                        {
                            ListaComprasVarias = (from x in ListaComprasVarias orderby x.numDocumento ascending select x).ToList();
                            Orden = false;
                        }
                        else
                        {
                            ListaComprasVarias = (from x in ListaComprasVarias orderby x.numDocumento descending select x).ToList();
                            Orden = true;
                        }
                    }

                    //Monto Afecto
                    if (dgvDocumentos.Columns[e.ColumnIndex].Name == "montAfecto")
                    {
                        if (Orden)
                        {
                            ListaComprasVarias = (from x in ListaComprasVarias orderby x.montAfecto ascending select x).ToList();
                            Orden = false;
                        }
                        else
                        {
                            ListaComprasVarias = (from x in ListaComprasVarias orderby x.montAfecto descending select x).ToList();
                            Orden = true;
                        }
                    }

                    //Monto Inafecto
                    if (dgvDocumentos.Columns[e.ColumnIndex].Name == "montInafecto")
                    {
                        if (Orden)
                        {
                            ListaComprasVarias = (from x in ListaComprasVarias orderby x.montInafecto ascending select x).ToList();
                            Orden = false;
                        }
                        else
                        {
                            ListaComprasVarias = (from x in ListaComprasVarias orderby x.montInafecto descending select x).ToList();
                            Orden = true;
                        }
                    }

                    //Monto Total
                    if (dgvDocumentos.Columns[e.ColumnIndex].Name == "montTotal")
                    {
                        if (Orden)
                        {
                            ListaComprasVarias = (from x in ListaComprasVarias orderby x.montTotal ascending select x).ToList();
                            Orden = false;
                        }
                        else
                        {
                            ListaComprasVarias = (from x in ListaComprasVarias orderby x.montTotal descending select x).ToList();
                            Orden = true;
                        }
                    }

                    bsComprasVarias.DataSource = ListaComprasVarias;
                }
            }
        }

        #endregion

    }
}
