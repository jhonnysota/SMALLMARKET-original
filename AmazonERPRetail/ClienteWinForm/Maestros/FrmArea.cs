using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Entidades.Maestros;
using Infraestructura.Recursos;
using Infraestructura;
using Infraestructura.Enumerados;
using Presentadora.AgenteServicio;
//using Microsoft.Reporting.WinForms;

namespace ClienteWinForm.Maestros
{
    public partial class FrmArea : FrmMantenimientoBase
    {
        public FrmArea()
        {
            InitializeComponent();
            FormatoGrid(dgvAreas, true);
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        Area oArea = null;
        //bool flag = false;

        #endregion

        #region Procedimientos Usuario

        //void pFormatoGridAreas()
        //{
        //    //Inicializar propiedades básicas DataGridView.
        //    dgvAreas.BackgroundColor = Color.LightSteelBlue;
        //    //dgvDetalle.BorderStyle = BorderStyle.None;

        //    //Establecer el estilo de las filas y columnas del encabezado
        //    dgvAreas.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
        //    dgvAreas.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
        //    dgvAreas.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
        //    dgvAreas.RowsDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);

        //    //Valores de propiedad, conjunto adecuado para la visualización.
        //    dgvAreas.AllowUserToAddRows = false;
        //    dgvAreas.AllowUserToDeleteRows = false;
        //    dgvAreas.AllowUserToOrderColumns = false;
        //    dgvAreas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dgvAreas.MultiSelect = false;

        //    dgvAreas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
        //    dgvAreas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        //    // establecer ajuste de altura automático para las filas
        //    dgvAreas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        //    // establecer ajuste de anchura automático para las columnas
        //    dgvAreas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        //    ////Para que la primera columan no aparesca
        //    ////dgvdetalle.RowHeadersVisible = false;
        //    dgvAreas.RowHeadersWidth = 20;

        //    //// Attach a handler to the CellFormatting event.
        //    dgvAreas.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvAreas_CellFormatting);
        //}

        void pListarAreas()
        {
            bsListadoAreas.DataSource = AgenteMaestro.Proxy.ListarTodasAreas(VariablesLocales.SesionLocal.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);
            //pFormatoGridAreas();
        }

        void pNuevoRegistro()
        {
            oArea = new Area()
            {
                idArea = 0,
                idEmpresa = VariablesLocales.SesionLocal.IdEmpresa,
                idLocal = VariablesLocales.SesionLocal.IdLocal,
                descripcion = string.Empty,
                estado = 1
            };

            txtIdArea.Text = "0";

            bsAreas.DataSource = oArea;
            bsAreas.ResetBindings(false);

            txtDescripcion.Focus();
        }

        void pGrabarArea()
        {
            try
            {
                bsAreas.EndEdit();

                oArea = (Area)bsAreas.Current;

                if (oArea != null)
                {
                    if (ValidarGrabacion() == true)
                    {
                        if (oArea.idArea == 0)
                        {
                            if (Global.MensajeConfirmacion(Mensajes.MSG_GBL_CONFIRMA_GRABACION) == DialogResult.Yes)
                            {
                                oArea.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                                oArea.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;

                                oArea = AgenteMaestro.Proxy.GrabarAreas(oArea, EnumOpcionGrabar.Insertar);

                                Global.MensajeComunicacion("Los datos fueron grabados correctamente...");
                            }
                        }
                        else
                        {
                            oArea.estado = chkEstado.Checked == true ? 1 : 0;
                            oArea.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                            oArea = AgenteMaestro.Proxy.GrabarAreas(oArea, EnumOpcionGrabar.Actualizar);

                            Global.MensajeComunicacion("Los datos fueron actualizados correctamente...");
                        }

                        bsAreas.DataSource = oArea;
                        bsAreas.ResetBindings(false);
                        pListarAreas();
                        
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de prueba" + ex.Message);
            }            
        }

        #endregion

        #region Procedimientos Herededados

        public override void Nuevo()
        {
            pNuevoRegistro();
            panel1.Enabled = false;
            //flag = true;
            base.Nuevo();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
        }

        public override void Grabar()
        {
            //if (pGrabarArea() = true)
            //{
                pGrabarArea();
                panel1.Enabled = true;
                //flag = false;

                BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
                BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
                BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
                BloquearOpcion(EnumOpcionMenuBarra.Grabar, false);
            //}
        }

        public override void Cancelar()
        {
            panel1.Enabled = true;
            //flag = false;
            pListarAreas();
            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
            BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
            BloquearOpcion(EnumOpcionMenuBarra.Grabar, false);
        }

        public override void Editar()
        {
            panel1.Enabled = false;
            //flag = true;
            txtIdArea.Enabled = false;
            base.Editar();
            BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
        }

        public override void Imprimir()
        {
            //List<ReportParameter> Lista = new List<ReportParameter>();
            
            //Lista.Add(new ReportParameter("idEmpresa", VariablesLocales.SesionLocal.IdEmpresa.ToString()));
            //Lista.Add(new ReportParameter("idLocal", VariablesLocales.SesionLocal.IdLocal.ToString()));

            //FrmImpresionGenerica oFrm = new FrmImpresionGenerica("Reporte de Areas", "rptListadoAreas", Lista);
            //oFrm.MdiParent = this.MdiParent;
            //oFrm.Show();

            //base.Imprimir();
        }

        public override bool ValidarGrabacion()
        {
            string resultado = ValidarEntidad<Area>(oArea);

            if (!string.IsNullOrEmpty(resultado))
            {
                Global.MensajeComunicacion(resultado);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        private void FrmArea_Load(object sender, EventArgs e)
        {                        
            pListarAreas();

            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
            BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
        }        

        private void bsListadoAreas_CurrentChanged(object sender, EventArgs e)
        {
            if (bsListadoAreas.Current != null)
            {
                bsAreas.DataSource = oArea = (Area)bsListadoAreas.Current;
                //bsAreas.ResetBindings(false);

                txtIdArea.Text = ((Area)bsListadoAreas.Current).idArea.ToString("000");

                if (((Area)bsListadoAreas.Current).estado == 1)
                {
                    chkEstado.Checked = true;
                }
                else
                {
                    chkEstado.Checked = false;
                }
            }
        }

        private void dgvAreas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvAreas.Columns[0].DefaultCellStyle.Format = "000";
        }

        private void FrmArea_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.KeyCode)
            //{
            //    case Keys.F2: //Nuevo Registro
            //        Nuevo();
            //        break;
            //    case Keys.F3: //Editar Registro
            //        Editar();
            //        break;
            //    case Keys.F5: //Grabar y Actualizar Registro
            //        if (flag == true)
            //        {
            //            Grabar();    
            //        }                                 
            //        break;
            //    case Keys.F6: //Cancelar Nuevo y Editar
            //        Cancelar();
            //        break;
            //    case Keys.F8: //Imprimir
            //        Imprimir();
            //        break;
            //    case Keys.Escape: //Salir del Sistema
            //        Cerrar();
            //        break;
            //    default:
            //        break;
            //}
        }

    }
}
