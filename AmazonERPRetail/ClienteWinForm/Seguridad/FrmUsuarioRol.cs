using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Seguridad;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Seguridad.Busquedas;

namespace ClienteWinForm.Seguridad
{
    public partial class FrmUsuarioRol : FrmMantenimientoBase
    {

        public FrmUsuarioRol()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarEmpresas();
            FormatoGrid(dgvUsuario, true);
            FormatoGrid(dgvRol, true);
        }

        #region Variables

        Rol rol = new Rol();
        List<Usuario> listaUsuario = null;
        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        #endregion

        #region Procedimientos de Usuario

        void LlenarEmpresas()
        {
            List<Empresa> oListaEmpresa = AgenteMaestro.Proxy.ListarEmpresa("");
            ComboHelper.LlenarCombos<Empresa>(cboEmpresa, oListaEmpresa, "IdEmpresa", "RazonSocial");
            oListaEmpresa = null;

            cboEmpresa.SelectedValue = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
        }

        #endregion

        #region Procedimientos Usuario

        //private void pFormatoGrid()
        //{
        //    //Inicializar propiedades básicas DataGridView.
        //    dgvUsuario.BackgroundColor = Color.LightSteelBlue;
        //    dgvUsuario.BorderStyle = BorderStyle.None;

        //    //Establecer el estilo de las filas y columnas del encabezado
        //    //dgvLocales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        //    dgvUsuario.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
        //    dgvUsuario.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
        //    dgvUsuario.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;

        //    //Valores de propiedad, conjunto adecuado para la visualización.
        //    dgvUsuario.AllowUserToAddRows = false;
        //    dgvUsuario.AllowUserToDeleteRows = false;
        //    dgvUsuario.AllowUserToOrderColumns = false;
        //    dgvUsuario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dgvUsuario.MultiSelect = false;

        //    dgvUsuario.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
        //    dgvUsuario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        //    // establecer ajuste de altura automático para las filas
        //    //this.dgvLocales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        //    // establecer ajuste de anchura automático para las columnas
        //    //this.dgvLocales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        //    ////Para que la primera columan no aparesca
        //    ////dgvdetalle.RowHeadersVisible = false;
        //    dgvUsuario.RowHeadersWidth = 20;

        //    //Estableciendo el el alto de los titulos
        //    dgvUsuario.ColumnHeadersHeight = 30;
        //    //Estableciendo el ancho de las columnas
        //    //dgvUsuario.Columns[0].Width = 35;
        //    //dgvUsuario.Columns[1].Width = 350;
        //    //dgvUsuario.Columns[2].Width = 65;
        //    //dgvUsuario.Columns[3].Width = 65;
        //    //dgvUsuario.Columns[4].Width = 65;
        //    //dgvUsuario.Columns[5].Width = 350;
        //    //dgvUsuario.Columns[6].Width = 90;
        //    //dgvUsuario.Columns[7].Width = 120;
        //    //dgvUsuario.Columns[8].Width = 90;
        //    //dgvUsuario.Columns[9].Width = 120;

        //    //Formato para las filas
        //    DataGridViewRow lineas = dgvUsuario.RowTemplate; //Establece la plantilla para todas las filas.
        //    lineas.Height = 20;
        //    lineas.MinimumHeight = 10;
        //    dgvUsuario.Refresh();

        //    //Estableciendo alineaciones
        //    //dgvLocales.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    //dgvLocales.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    //dgvLocales.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    //dgvLocales.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    // Attach a handler to the CellFormatting event.
        //    //dgvLocales.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvLocales_CellFormatting);
        //}

        //private void pFormatoGrid2()
        //{
        //    //Inicializar propiedades básicas DataGridView.
        //    dgvRol.BackgroundColor = Color.LightSteelBlue;
        //    dgvRol.BorderStyle = BorderStyle.None;

        //    //Establecer el estilo de las filas y columnas del encabezado
        //    dgvRol.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
        //    dgvRol.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
        //    dgvRol.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;

        //    //Valores de propiedad, conjunto adecuado para la visualización.
        //    dgvRol.AllowUserToAddRows = false;
        //    dgvRol.AllowUserToDeleteRows = false;
        //    dgvRol.AllowUserToOrderColumns = false;
        //    dgvRol.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dgvRol.MultiSelect = false;

        //    dgvRol.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
        //    dgvRol.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        //    // establecer ajuste de altura automático para las filas
        //    //this.dgvLocales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        //    // establecer ajuste de anchura automático para las columnas
        //    //this.dgvLocales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        //    ////Para que la primera columan no aparesca
        //    ////dgvdetalle.RowHeadersVisible = false;
        //    dgvRol.RowHeadersWidth = 20;

        //    //Estableciendo el el alto de los titulos
        //    dgvRol.ColumnHeadersHeight = 30;
        //    //Estableciendo el ancho de las columnas
        //    //dgvUsuario.Columns[0].Width = 35;
        //    //dgvUsuario.Columns[1].Width = 350;
        //    //dgvUsuario.Columns[2].Width = 65;
        //    //dgvUsuario.Columns[3].Width = 65;
        //    //dgvUsuario.Columns[4].Width = 65;
        //    //dgvUsuario.Columns[5].Width = 350;
        //    //dgvUsuario.Columns[6].Width = 90;
        //    //dgvUsuario.Columns[7].Width = 120;
        //    //dgvUsuario.Columns[8].Width = 90;
        //    //dgvUsuario.Columns[9].Width = 120;

        //    //Formato para las filas
        //    DataGridViewRow lineas = dgvRol.RowTemplate; //Establece la plantilla para todas las filas.
        //    lineas.Height = 20;
        //    lineas.MinimumHeight = 10;
        //    dgvRol.Refresh();

        //    //Estableciendo alineaciones
        //    //dgvLocales.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    //dgvLocales.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    //dgvLocales.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    //dgvLocales.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    // Attach a handler to the CellFormatting event.
        //    //dgvLocales.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvLocales_CellFormatting);
        //}

        #endregion

        #region Procedimientos Heredados

        public override void Anular()
        {
            base.Anular();
        }

        public override void Buscar()
        {
            listaUsuario = AgenteSeguridad.Proxy.ListarUsuario("", false, false);

            foreach (Usuario u in listaUsuario) 
            {
                Int32 empresa = Convert.ToInt32(cboEmpresa.SelectedValue);
                u.Roles = AgenteSeguridad.Proxy.ListarRolUsuario(u.IdPersona, empresa);
            }

            usuarioBindingSource.DataSource = listaUsuario;
            
            base.Buscar();
            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
        }

        public override void Cancelar()
        {
            base.Cancelar();
            button1.Enabled = false;
            button2.Enabled = false;
            
            Buscar();
            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
            BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
        }

        public override void Editar()
        {
            button1.Enabled = true;
            button2.Enabled = true;
           
            base.Editar();
            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
            BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
            BloquearOpcion(EnumOpcionMenuBarra.Editar, false);          
        }

        public override void Grabar()
        {
            Int32 idEmpresa = Convert.ToInt32(cboEmpresa.SelectedValue.ToString());

            String i = AgenteSeguridad.Proxy.InsertarUsuarioRol(listaUsuario, idEmpresa);
            Global.MensajeComunicacion(i);
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
            BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
            BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
            button1.Enabled = false;
            button2.Enabled = false;
        }

        public override void Nuevo()
        {
            base.Nuevo();
        }

        #endregion

        #region Eventos

        private void FrmUsuarioRol_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
          
            base.Cancelar();
            //BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
            //BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
            ////BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
            //BloquearOpcion(EnumOpcionMenuBarra.Editar, false);
        }

        private void usuarioBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (usuarioBindingSource.Count > 0) {
                Usuario u= (from x in listaUsuario where x.IdPersona.Equals(((Usuario)usuarioBindingSource.Current).IdPersona) 
                            select x).FirstOrDefault();
                rolBindingSource.DataSource = u.Roles;
                rolBindingSource.ResetBindings(false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmBusquedaRol frm = new FrmBusquedaRol();
            if (frm.ShowDialog() == DialogResult.OK && frm.rol != null)
            {
                Rol res = (from x in ((List<Rol>)rolBindingSource.DataSource)
                              where x.IdRol.Equals(frm.rol.IdRol)
                              select x).FirstOrDefault();

                if (res == null)
                {
                    frm.rol.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    frm.rol.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    frm.rol.FechaModificacion = DateTime.Now;
                    frm.rol.FechaRegistro = DateTime.Now;
                    ((Usuario)usuarioBindingSource.Current).Roles.Add(frm.rol);
                    rolBindingSource.ResetBindings(false);
                }
                else
                {
                    Global.MensajeComunicacion("Este Rol ya esta asignado");
                    return;
                }
                //listaopciones.Add(frm.opcion);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rolBindingSource.RemoveCurrent();
            rolBindingSource.ResetBindings(false);
        }

        private void cboEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Buscar();
        }

        #endregion

    }
}
