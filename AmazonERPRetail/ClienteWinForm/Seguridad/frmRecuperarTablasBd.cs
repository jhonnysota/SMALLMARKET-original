using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using Presentadora.AgenteServicio;
using Entidades.Seguridad;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using HelperSql;
using Microsoft.SqlServer.Management.Smo;

namespace ClienteWinForm.Seguridad
{
    public partial class frmRecuperarTablasBd : FrmMantenimientoBase
    {
        public frmRecuperarTablasBd()
        {
            InitializeComponent();

            FormatoGrid(dgvTablas, true, false, 26, 20, false);
            AnchoColumnas();
            txtServidor.Text = ConfigurationManager.AppSettings.Get("ServidorSQL");
            txtNombreBD.Text = ConfigurationManager.AppSettings.Get("NombreBD");

        }

        #region Variables

        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<ClonacionTablasE> oListaGeneral = null;
        Database BaseDatos = UtilSQL.RecuperaServer(ConfigurationManager.AppSettings.Get("ServidorSQL"), 
                                                    ConfigurationManager.AppSettings.Get("UsuarioSQL"), 
                                                    ConfigurationManager.AppSettings.Get("ClaveSQL"), false).Databases[ConfigurationManager.AppSettings.Get("NombreBD")];

        #endregion Variables

        #region Procedimientos de Usuario

        List<ClonacionTablasE> RecuperarTablas(String nomBD)
        {            
            List<ClonacionTablasE> oListaDevuelta = new List<ClonacionTablasE>();
            ClonacionTablasE oTabla = null;
            
            LlenarComboGrid();

            foreach (String item in UtilSQL.ListarTablas(BaseDatos))
            {
                oTabla = new ClonacionTablasE
                {
                    Check = false,
                    TablaReal = item,
                    Descripcion = String.Empty,
                    Orden = (Nullable<Int32>)null,
                    idSistema = Variables.Cero,
                    Transferido = false,
                    idEmpresaTrans = Variables.Cero,
                    idEmpresa = Variables.Cero,
                    UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                };

                oListaDevuelta.Add(oTabla);
            }

            oListaGeneral = new List<ClonacionTablasE>(oListaDevuelta);
            return oListaDevuelta;
        }

        void AnchoColumnas()
        {
            dgvTablas.Columns[0].Width = 20;
            dgvTablas.Columns[1].Width = 155;
            dgvTablas.Columns[2].Width = 200;
            dgvTablas.Columns[3].Width = 45;
            dgvTablas.Columns[4].Width = 120;
        }

        void BuscarFiltro()
        {
            bsTablas.DataSource = (from x in oListaGeneral
                                   where x.TablaReal.ToUpper().Contains(txtBuscar.Text.ToUpper())
                                   select x).ToList();
        }

        void LlenarComboGrid()
        {
            DataGridViewComboBoxColumn oCombo = dgvTablas.Columns["idSistema"] as DataGridViewComboBoxColumn;
            List<SistemasE> oListaSistemas = AgenteGeneral.Proxy.ListarSistemas();
            SistemasE oItem = new SistemasE() { idSistema = 0, descripcion = Variables.Seleccione };
            oListaSistemas.Add(oItem);

            ComboHelper.RellenarCombos<SistemasE>(oCombo, (from x in oListaSistemas
                                                          orderby x.idSistema
                                                           select x).ToList(), "idSistema", "descripcion");
            oListaSistemas = null;
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Grabar()
        {
            try
            {
                if (dgvTablas.IsCurrentCellDirty)
                {
                    dgvTablas.CommitEdit(DataGridViewDataErrorContexts.Commit);
                } 

                if (oListaGeneral != null && oListaGeneral.Count > Variables.Cero)
                {
                    Int32 Registros = Variables.Cero;
                    List<ClonacionTablasE> oListaFinal = new List<ClonacionTablasE>();

                    foreach (ClonacionTablasE item in bsTablas.List)
                    {
                        if (item.Check && !String.IsNullOrEmpty(item.Descripcion) && !String.IsNullOrWhiteSpace(item.Orden.ToString()))
                        {
                            oListaFinal.Add(item);
                        }
                    }

                    if (oListaFinal.Count > Variables.Cero)
                    {
                        Registros = AgenteSeguridad.Proxy.GrabarVarios(oListaFinal);

                        if (Registros > Variables.Cero)
                        {
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                            oListaFinal = null;
                            oListaGeneral = null;
                            bsTablas.DataSource = null;
                            txtBuscar.Text = String.Empty;
                        }
                    }
                    else
                    {
                        Global.MensajeFault("La linea tiene que estar con check, colocar su descripción y el nro. orden.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Override

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //  Si el control DataGridView no tiene el foco...
            if (!dgvTablas.Focused && !dgvTablas.IsCurrentCellInEditMode)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            ////  Si la tecla presionada es distinta de la tecla Enter
            ////  abandonamos el procedimiento.
            if ((keyData != Keys.Return))
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            Int32 iColumnIndex = dgvTablas.CurrentCell.ColumnIndex;
            Int32 iRowIndex = dgvTablas.CurrentCell.RowIndex;

            if (keyData == Keys.Enter)
            {
                if (iColumnIndex == dgvTablas.Columns.Count - 1)
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
                else
                {
                    dgvTablas.CurrentCell = dgvTablas[iColumnIndex + 1, iRowIndex];
                }

                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        #endregion

        #region Eventos
        
        private void frmRecuperarTablasBd_Load(object sender, EventArgs e)
        {
            Grid = false;
            bFlag = true;
            BloquearOpcion(EnumOpcionMenuBarra.Grabar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
        }

        private void btRecuperarTablas_Click(object sender, EventArgs e)
        {
            try
            {
                bsTablas.DataSource = RecuperarTablas(txtNombreBD.Text);
                AnchoColumnas();

                if (!String.IsNullOrEmpty(txtBuscar.Text))
                {
                    BuscarFiltro();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (oListaGeneral != null && oListaGeneral.Count > Variables.Cero)
            {
                BuscarFiltro();
            }
        } 

        private void dgvTablas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                SendKeys.Send("{F4}");
            }
        }

        private void dgvTablas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dgvTablas.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        #endregion Eventos

    }
}
