using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Enumerados;
using Entidades.Generales;

namespace ClienteWinForm.Generales
{
    public partial class frmListadoImpuestos : FrmMantenimientoBase
    {
        
        public frmListadoImpuestos()
        {
            InitializeComponent();
            FormatoGrid(dgvControl, true, false, 28, 23);
            AnchoColumnas();
            
        }

        #region Variables

        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }

        #endregion

        #region Procedimientos de Usuario

       void AnchoColumnas()
        {
            dgvControl.Columns[0].Width = 45; //Impuestos
            dgvControl.Columns[1].Width = 120; //Empresa
            dgvControl.Columns[2].Width = 100; //PlanCuentas
            dgvControl.Columns[3].Width = 100; //CodigoCuenta
            dgvControl.Columns[4].Width = 120; //desImpuestos
            dgvControl.Columns[5].Width = 100; //DesAbreviatura
            dgvControl.Columns[6].Width = 120; //Usuario Registro
      
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
           {
               try
               {
                   Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpuestos);

                   if (oFrm != null)
                   {
                       if (oFrm.WindowState == FormWindowState.Minimized)
                       {
                           oFrm.WindowState = FormWindowState.Normal;
                       }

                       oFrm.BringToFront();
                       return;
                   }

                   oFrm = new frmImpuestos();
                   oFrm.MdiParent = this.MdiParent;
                   oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                   oFrm.Show();
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
                   if (bsImpuestos.Count > 0)
                   {
                       Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpuestos);

                       if (oFrm != null)
                       {
                           if (oFrm.WindowState == FormWindowState.Minimized)
                           {
                               oFrm.WindowState = FormWindowState.Normal;
                           }

                           oFrm.BringToFront();
                           return;
                       }

                       ImpuestosE ImpuestosTmp = (ImpuestosE)bsImpuestos.Current;

                       oFrm = new frmImpuestos(ImpuestosTmp);
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
                       if (bsImpuestos.Count > Variables.Cero)
                       {
                           if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                           {
                               AgenteGenerales.Proxy.EliminarImpuestos(((ImpuestosE)bsImpuestos.Current).idImpuesto);
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

        public override void Buscar()
           {
               try
               {
                   bsImpuestos.DataSource = AgenteGenerales.Proxy.ListarImpuestos();
                   bsImpuestos.ResetBindings(false);

                   lblRegistros.Text = "Impuestos - " + bsImpuestos.Count.ToString() + " Registros";
               }
               catch (Exception ex)
               {
                   Global.MensajeError(ex.Message);
               }
               base.Buscar();
           }

        public override void Imprimir()
           {
               base.Imprimir();
           }
        
        #endregion

        #region Eventos

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmImpuestos oFrm = sender as frmImpuestos;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoImpuestos_Load(object sender, EventArgs e)
        {
            Grid = true;
        }

        private void frmListadoImpuestos_Activated(object sender, EventArgs e)
        {
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
        }

        private void dgvControl_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void dgvControl_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvControl.Columns[0].DefaultCellStyle.Format = "00";
            }
        }

        #endregion

    }
}
