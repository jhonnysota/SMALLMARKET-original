using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;

namespace ClienteWinForm.Maestros
{
    public partial class frmListadoEmpresas : FrmMantenimientoBase
    {
        
        public frmListadoEmpresas()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvEmpresas, true);
            AnchoColumnas();
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<Empresa> ListaEmpresas = null;
        Empresa Emp = new Empresa();

        String sParametro = String.Empty;

        #endregion

        #region Procedimiento Usuario

        private void AnchoColumnas()
        {
            dgvEmpresas.Columns[0].Width = 80; //RUC
            dgvEmpresas.Columns[1].Width = 320; //Razón social
            dgvEmpresas.Columns[2].Width = 200; //Dirección
            dgvEmpresas.Columns[3].Width = 100; //Departamento
            dgvEmpresas.Columns[4].Width = 100; //Provincia
            dgvEmpresas.Columns[5].Width = 100; //Distrito
            dgvEmpresas.Columns[6].Width = 90; //Usuario registro
            dgvEmpresas.Columns[7].Width = 120; //Fecha registro
            dgvEmpresas.Columns[8].Width = 90; //Usuario Modificacion
            dgvEmpresas.Columns[9].Width = 120; //Fecha Modificación            
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmEmpresa);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new FrmEmpresa()
                {
                    MdiParent = MdiParent
                };

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
            sParametro = txtBuscar.Text;

            if (String.IsNullOrEmpty(sParametro))
            {
                sParametro = String.Empty;
            }

            ListaEmpresas = AgenteMaestro.Proxy.ListarEmpresa(sParametro);

            if (ListaEmpresas != null)
            {
                bsEmpresas.DataSource = ListaEmpresas;
                bsEmpresas.ResetBindings(false);
            }
        }

        public override void Editar()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmEmpresa);
                
                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                if (bsEmpresas.Current != null)
                {
                    oFrm = new FrmEmpresa(((Empresa)bsEmpresas.Current).IdEmpresa, ((Empresa)bsEmpresas.Current).Departamento, ((Empresa)bsEmpresas.Current).Provincia)
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        #endregion

        #region Eventos de Usuario

        void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            FrmEmpresa oFrm = sender as FrmEmpresa;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoEmpresas_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
        }

        private void dgvEmpresas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();    
            }            
        }

        private void BsEmpresas_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                LblRegistros.Text = "Registros " + bsEmpresas.List.Count;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
