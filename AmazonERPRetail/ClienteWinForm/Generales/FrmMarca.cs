using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClienteWinForm.Generales.Busqueda;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Enumerados;
using Entidades.Generales;
using Presentadora.AgenteServicio;

namespace ClienteWinForm.Generales
{
    public partial class FrmMarca : FrmMantenimientoBase
    {

        public FrmMarca()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvSistemas, true);
            FormatoGrid(dgvMarcas, true);
            
        }

        #region Variables

        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        Marca oMarca = null;
        bool flag = false;

        #endregion

        #region Metodos de Usuario

        void pFormatoGridMarcas()
        {
            //Inicializar propiedades básicas DataGridView.
            dgvMarcas.BackgroundColor = Color.LightSteelBlue;
            //dgvDetalle.BorderStyle = BorderStyle.None;

            //Establecer el estilo de las filas y columnas del encabezado
            dgvMarcas.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgvMarcas.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvMarcas.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvMarcas.RowsDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);

            //Valores de propiedad, conjunto adecuado para la visualización.
            dgvMarcas.AllowUserToAddRows = false;
            dgvMarcas.AllowUserToDeleteRows = false;
            dgvMarcas.AllowUserToOrderColumns = false;
            dgvMarcas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMarcas.MultiSelect = false;

            dgvMarcas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            dgvMarcas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            // establecer ajuste de altura automático para las filas
            dgvMarcas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            // establecer ajuste de anchura automático para las columnas
            dgvMarcas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            ////Para que la primera columan no aparesca
            ////dgvdetalle.RowHeadersVisible = false;
            dgvMarcas.RowHeadersWidth = 20;

            //// Attach a handler to the CellFormatting event.
            dgvMarcas.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvMarcas_CellFormatting);
        }

        void pFormatoGridSistemas()
        {
            //Inicializar propiedades básicas DataGridView.
            dgvSistemas.BackgroundColor = Color.LightSteelBlue;
            //dgvDetalle.BorderStyle = BorderStyle.None;

            //Establecer el estilo de las filas y columnas del encabezado
            dgvSistemas.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgvSistemas.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvSistemas.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvSistemas.RowsDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);

            //Valores de propiedad, conjunto adecuado para la visualización.
            dgvSistemas.AllowUserToAddRows = false;
            dgvSistemas.AllowUserToDeleteRows = false;
            dgvSistemas.AllowUserToOrderColumns = false;
            dgvSistemas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSistemas.MultiSelect = false;

            dgvSistemas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            dgvSistemas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            // establecer ajuste de altura automático para las filas
            //dgvSistemas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            // establecer ajuste de anchura automático para las columnas
            //dgvSistemas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            ////Para que la primera columan no aparesca
            ////dgvdetalle.RowHeadersVisible = false;
            dgvSistemas.RowHeadersWidth = 20;

            //Estableciendo el el alto de los titulos
            dgvSistemas.ColumnHeadersHeight = 30;
            //Estableciendo el ancho de las columnas
            dgvSistemas.Columns[0].Width = 50;
            dgvSistemas.Columns[1].Width = 150;

            //Formato para las filas
            DataGridViewRow lineas = dgvSistemas.RowTemplate; //Establece la plantilla para todas las filas.
            lineas.Height = 20;
            lineas.MinimumHeight = 5;
            dgvSistemas.Refresh();

            //// Attach a handler to the CellFormatting event.
            dgvSistemas.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvSistemas_CellFormatting);
        }

        void pListarMarcas()
        {
            bsMarcasListado.DataSource = AgenteGenerales.Proxy.ListarMarca(((SistemasE)bsSistemas.Current).idSistema);
            //bsMarcasListado.ResetBindings(false);
            pFormatoGridMarcas();
        }

        void pListarSistemas()
        {
            bsSistemas.DataSource = AgenteGenerales.Proxy.ListarSistemas();
            //bsSistemas.ResetBindings(false);
            pFormatoGridSistemas();
        }

        #endregion

        #region Metodos Herededados

        //public override void Anular()
        //{
        //    if (Infraestructura.Global.MensajeConfirmacion(Mensajes.AnularRegistro) == DialogResult.No)
        //    {
        //        return;
        //    }
        //    marca=(Marca)bsMarcasDetalle.Current;
        //    marca.FechaModificacion = VariablesLocales.FechaHoy;
        //    marca.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;

        //    AgenteGenerales.Proxy.ActualizarMarca(marca);
        //    Nuevo();
        //    Infraestructura.Global.MensajeComunicacion("Tarea Anulada");
        //    BloquearOpcion(Infraestructura.Enumerados.EnumOpcionMenuBarra.Nuevo, false);
        //    BloquearOpcion(Infraestructura.Enumerados.EnumOpcionMenuBarra.Grabar, true);
        //    BloquearOpcion(Infraestructura.Enumerados.EnumOpcionMenuBarra.Editar, false);
        //    pnlDetalle.Enabled = true;
        //    txtNombre.Focus();
        //    //base.Anular();
        //}

        public override bool ValidarGrabacion()
        {
            string resultado = ValidarEntidad<Marca>(oMarca);

            if (!string.IsNullOrEmpty(resultado))
            {
                Global.MensajeComunicacion(resultado);
                return false;
            }

            return base.ValidarGrabacion();
        }

        public override void Cancelar()
        {
            panel1.Enabled = true;
            pnlSistemas.Enabled = true;
            pListarMarcas();
            //pnlDetalle.Enabled = false;
            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
            BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
            BloquearOpcion(EnumOpcionMenuBarra.Grabar, false);

        }

        public override void Cerrar()
        {
            this.Dispose();
            base.Cerrar();
        }

        public override void Editar()
        {
            if (bsMarcasListado.Count == 0)
            {
                Global.MensajeFault("El sistema escogido no tiene ninguna marca para editar.");
                return;
            }

            pnlDetalle.Enabled = true;
            pnlSistemas.Enabled = false;
            panel1.Enabled = false;
            txtIdMarca.Enabled = false;
            flag = true;
            //marca = (Marca)marcaBindingSource.Current;
            base.Editar();
            BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
        }

        public override void Grabar()
        {
            bsMarcasDetalle.EndEdit();

            oMarca = (Marca)bsMarcasDetalle.Current;

            if (oMarca != null)
            {
                if (ValidarGrabacion() == true)
                {
                    if (oMarca.idMarca == 0)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.MSG_GBL_CONFIRMA_GRABACION) != DialogResult.Yes) { return; }

                        oMarca.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        oMarca.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;

                        oMarca = AgenteGenerales.Proxy.GrabarMarcas(oMarca, EnumOpcionGrabar.Insertar);
                        Global.MensajeComunicacion("Los datos fueron grabados correctamente...");

                    }
                    else
                    {
                        oMarca.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;

                        oMarca = AgenteGenerales.Proxy.GrabarMarcas(oMarca, EnumOpcionGrabar.Actualizar);
                        Global.MensajeComunicacion("Los datos fueron actualizados correctamente...");
                    }

                    bsMarcasDetalle.DataSource = oMarca;
                    bsMarcasDetalle.ResetBindings(false);

                    panel1.Enabled = true;
                    pnlSistemas.Enabled = true;
                    pListarMarcas();

                    BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
                    BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
                    BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Grabar, false);
                    flag = false;
                }
            }
        }

        public override void Nuevo()
        {
            if (bsSistemas.Count == 0) 
            {
                Global.MensajeFault("No hay ningun sistema.");
                return;
            }

            oMarca = new Marca();

            oMarca.idMarca = 0;
            txtIdMarca.Text = "0";
            oMarca.nombre = string.Empty;
            oMarca.nombreCorto = string.Empty;
            oMarca.idSistema = ((SistemasE)bsSistemas.Current).idSistema;

            bsMarcasDetalle.DataSource = oMarca;
            bsMarcasDetalle.ResetBindings(false);

            panel1.Enabled = false;
            pnlSistemas.Enabled = false;
            flag = true;
            txtNombre.Focus();
            base.Nuevo();

            BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
        }

        #endregion

        #region Eventos

        private void FrmMarca_Load(object sender, EventArgs e)
        {
            pListarSistemas();

            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
            BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
        }

        private void bsMarcasListado_CurrentChanged(object sender, EventArgs e)
        {
            if (bsMarcasListado.Current != null)
            {
                bsMarcasDetalle.DataSource = (Marca)bsMarcasListado.Current;
                //bsMarcasDetalle.ResetBindings(false);

                txtIdMarca.Text = ((Marca)bsMarcasListado.Current).idMarca.ToString("000");
            }
            else
            {
                txtIdMarca.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtNombreCorto.Text = string.Empty;
                txtUsuarioRegistro.Text = string.Empty;
                txtFecRegistro.Text = string.Empty;
                txtUsuarioModif.Text = string.Empty;
                txtFecModif.Text = string.Empty;
            }

        }

        private void bsSistemas_CurrentChanged(object sender, EventArgs e)
        {
            if (bsSistemas.Current != null)
            {
                pListarMarcas();
            }
        }

        private void dgvMarcas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvMarcas.Columns[0].DefaultCellStyle.Format = "000";
        }

        private void dgvSistemas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvSistemas.Columns[0].DefaultCellStyle.Format = "00";
        }

        private void FrmMarca_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2: //Nuevo Registro
                    Nuevo();
                    break;
                case Keys.F3: //Editar Registro
                    Editar();
                    break;
                case Keys.F5: //Grabar Registro
                    if (flag == true)
                    {
                        Grabar();    
                    }                    
                    break;
                case Keys.F6: //Cancelar Nuevo y Editar
                    Cancelar();
                    break;
                case Keys.F7: //Eliminar o Anular
                    
                    break;
                case Keys.F8: //Imprimier
                    Imprimir();
                    break;
                case Keys.Escape: //Salir del Sistema
                    Cerrar();
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}
