using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.SqlServer.Management.Smo;

using Presentadora.AgenteServicio;
using Entidades.Seguridad;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using HelperSql;


namespace ClienteWinForm.Seguridad
{
    public partial class frmClonarTablas : FrmMantenimientoBase
    {
        public frmClonarTablas()
        {
            InitializeComponent();

            LlenarCombos();
            FormatoGrid(dgvTablas, true);
            FormatoGrid(dgvTransferidos, false);
            AnchoColumnas();
            AnchoColumnasTrans();
            txtIdEmpresa.Text = VariablesLocales.SesionUsuario.Empresa.IdEmpresa.ToString();
            txtRazonSocial.Text = VariablesLocales.SesionUsuario.Empresa.RazonSocial;
        }

        #region Variables

        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }

        Database BaseDatos = UtilSQL.RecuperaServer(ConfigurationManager.AppSettings.Get("ServidorSQL"),
                                                    ConfigurationManager.AppSettings.Get("UsuarioSQL"),
                                                    ConfigurationManager.AppSettings.Get("ClaveSQL"), false).Databases[ConfigurationManager.AppSettings.Get("NombreBD")];
        #endregion Variables

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            ComboHelper.LlenarCombos<Empresa>(cboEmpresa1, AgenteMaestro.Proxy.ListarEmpresa(""), "IdEmpresa", "NombreComercial");

            List<SistemasE> oListaSistemas = AgenteGeneral.Proxy.ListarSistemas();
            SistemasE oItem = new SistemasE() { idSistema = 0, descripcion = Variables.Seleccione };
            oListaSistemas.Add(oItem);

            ComboHelper.RellenarCombos<SistemasE>(cboSistemas, (from x in oListaSistemas
                                                                orderby x.idSistema
                                                                select x).ToList(), "idSistema", "descripcion");
            oListaSistemas = null;
        }

        void AnchoColumnas()
        {
            dgvTablas.Columns[0].Width = 20;
            dgvTablas.Columns[1].Width = 320;
            dgvTablas.Columns[2].Width = 45;
        }

        void AnchoColumnasTrans()
        {
            dgvTransferidos.Columns[1].Width = 20;
            dgvTransferidos.Columns[2].Width = 180;
            dgvTransferidos.Columns[3].Width = 250;
            dgvTransferidos.Columns[4].Width = 250;
        }

        void ListarTablasTransferidas()
        {
            List<ClonacionTablasE> oListaTransferidas = AgenteSeguridad.Proxy.ListarTablasTransferidas(Convert.ToInt32(cboEmpresa1.SelectedValue), true);
            bsTransferidos.DataSource = oListaTransferidas;
            dgvTransferidos.DataSource = bsTransferidos;
        }

        #endregion Procedimientos de Usuario

        #region Eventos

        private void frmClonarTablas_Load(object sender, EventArgs e)
        {
            Grid = false;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            cboEmpresa1_SelectionChangeCommitted(new Object(), new EventArgs());
        }

        private void cboSistemas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            List<ClonacionTablasE> oListaTablas = AgenteSeguridad.Proxy.ListarTablasPorSistema(Convert.ToInt32(cboSistemas.SelectedValue));

            bsTablas.DataSource = oListaTablas;
            dgvTablas.DataSource = bsTablas;
        }

        private void btTransferir_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 EmpresaOrigen = Convert.ToInt32(txtIdEmpresa.Text);
                Int32 EmpresaDestino = Convert.ToInt32(cboEmpresa1.SelectedValue);

                if (EmpresaOrigen == EmpresaDestino)
                 {
                    Global.MensajeComunicacion("Error No se Puede Transferir en la Misma Empresa ");
                    return;
                }


                List<ClonacionTablasE> oListaFinal = new List<ClonacionTablasE>();
                List<CampoTabla> ListaColumnas = null;
                StringBuilder sbCadenaCol = new StringBuilder();
                Int32 Registros = Variables.Cero;

                foreach (ClonacionTablasE item in bsTablas.List)
                {
                    if (item.Check)
                    {
                        ListaColumnas = UtilSQL.ListarCamposTabla(BaseDatos, item.TablaReal);

                        foreach (CampoTabla Campito in ListaColumnas)
                        {
                            sbCadenaCol.Append(Campito.NombreCampo).Append(", ");
                        }

                        item.ListaColumnas = Global.Izquierda(sbCadenaCol.ToString(), sbCadenaCol.ToString().Length - 2);
                        item.idEmpresa = Convert.ToInt32(txtIdEmpresa.Text);
                        item.idEmpresaTrans = Convert.ToInt32(cboEmpresa1.SelectedValue);
                        item.Transferido = true;
                        item.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        oListaFinal.Add(item);
                        sbCadenaCol.Clear();
                    }
                }

                sbCadenaCol.Clear();
                ListaColumnas = null;

                if (oListaFinal.Count > Variables.Cero)
                {
                    Registros = AgenteSeguridad.Proxy.ClonarTablas(oListaFinal);
                }

                if (Registros > Variables.Cero)
                {
                    Global.MensajeComunicacion("La transferencia fue un éxito.");
                    ListarTablasTransferidas();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvTablas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvTablas.IsCurrentCellDirty)
            {
                dgvTablas.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void cboEmpresa1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ListarTablasTransferidas();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvTransferidos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvTransferidos.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = dgvTransferidos.Rows[e.RowIndex].Cells["Eliminar"] as DataGridViewButtonCell;
                Icon Icono = new Icon(Environment.CurrentDirectory + @"\BorrarLinea.ico"); 
                e.Graphics.DrawIcon(Icono, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                dgvTransferidos.Rows[e.RowIndex].Height = Icono.Height + 8;
                dgvTransferidos.Columns[e.ColumnIndex].Width = Icono.Width + 8;

                e.Handled = true;
            }
        }

        private void dgvTransferidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvTransferidos.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    if (Global.MensajeConfirmacion("Desea eliminar la información transferida ?") == DialogResult.Yes)
                    {
                        Int32 idEmpresaTrans = Convert.ToInt32(((ClonacionTablasE)bsTransferidos.Current).idEmpresaTrans);
                        String Tabla = ((ClonacionTablasE)bsTransferidos.Current).TablaReal;
                        Int32 Resp = AgenteSeguridad.Proxy.EliminarTablasTransferidas(idEmpresaTrans, Tabla);

                        if (Resp > Variables.Cero)
                        {
                            Global.MensajeComunicacion("La información de la tabla se eliminó correctamente.");
                            ((ClonacionTablasE)bsTransferidos.Current).Transferido = false;
                            ((ClonacionTablasE)bsTransferidos.Current).UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                            AgenteSeguridad.Proxy.ActualizarClonacionTablas((ClonacionTablasE)bsTransferidos.Current);
                            ListarTablasTransferidas();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Eventos

    }
}
