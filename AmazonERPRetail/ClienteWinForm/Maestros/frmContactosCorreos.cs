using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Maestros
{
    public partial class frmContactosCorreos : frmResponseBase
    {

        #region Constructores

        public frmContactosCorreos()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            LlenarCombo();
        }

        public frmContactosCorreos(Int32 idEmpresa_, Int32 idPedido_, String codPedido_)
            : this()
        {
            idEmpresa = idEmpresa_;
            idPedido = idPedido_;

            FormatoGrid(dgvContactos, false);
            codPedido = codPedido_;
        } 

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<ContactosCorreosE> oListaCorreos = null;

        Int32 idEmpresa = Variables.Cero;
        Int32 idPedido = Variables.Cero;
        String codPedido = String.Empty;
        public String Correo = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombo()
        {
            List<ContactosCorreosGrupoE> ListaGrupos = AgenteGeneral.Proxy.ListarContactosCorreosGrupo(VariablesLocales.SesionUsuario.IdPersona);
            //oListaExoneracion.Add(new ParTabla() { IdParTabla = Variables.Cero, desTemporal = Variables.Seleccione });
            ComboHelper.LlenarCombos<ContactosCorreosGrupoE>(cboGrupo, ListaGrupos, "idGrupo", "Descripcion");
        }

        void OtroFormato()
        {
            dgvContactos.Columns[1].HeaderText = "Apellidos y Nombres";
            dgvContactos.AutoResizeColumns();
        }

        #endregion

        #region Eventos

        private void frmContactosCorreos_Load(object sender, EventArgs e)
        {
            try
            {
                if (idEmpresa != 0 && idPedido != 0)
                {
                    //dgvContactos.Visible = true;
                    //ContactosCorreos = AgenteVentas.Proxy.RecuperarPedidoMailContactoId(idEmpresa, idPedido);

                    //var Lista = (from x in ContactosCorreos
                    //             select new { Correo = x.mailContacto, NombresApellidos = x.apePaterno + ' ' + x.apeMaterno + ' ' + x.Nombres });

                    //dgvContactos.DataSource = Lista.ToList();
                    //OtroFormato();
                }
                else
                {
                    Size = new System.Drawing.Size(500, 423); //378, 423
                    dgvContactos.Visible = true;
                    oListaCorreos = AgenteGeneral.Proxy.ListarContactosCorreosPorGrupo(Convert.ToInt32(cboGrupo.SelectedValue));

                    if (oListaCorreos.Count > Variables.Cero)
                    {
                        var Lista = (from x in oListaCorreos
                                     select new { x.Correo, x.Nombres });

                        dgvContactos.DataSource = Lista.ToList();
                        OtroFormato();
                        //var oGrupoCorreos = oListaCorreos.GroupBy(MiGrupo => MiGrupo.RazonSocial);
                        //lvCorreos.Items.Clear();
                        //String group = "";
                        //ListViewGroup lvGrupo = new ListViewGroup();

                        //foreach (var itemCorreo in oGrupoCorreos)
                        //{
                        //if (itemCorreo.Key.ToString() != group)
                        //{
                        //    lvGrupo = new ListViewGroup(itemCorreo.Key.ToString());
                        //    group = itemCorreo.Key.ToString();
                        //    lvCorreos.Groups.Add(lvGrupo);
                        //}

                        //foreach (ContactosCorreosE Correos in oListaCorreos)
                        //{
                        //    ListViewItem lvItem = new ListViewItem("");
                        //    lvItem.SubItems.Add(Correos.Correo);
                        //    lvItem.SubItems.Add(Correos.Nombres);
                        //    //lvItem.Group = lvGrupo;
                        //    lvCorreos.Items.Add(lvItem);
                        //}
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvContactos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Correo = dgvContactos.Rows[e.RowIndex].Cells[0].Value.ToString();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void lvCorreos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (lvCorreos.SelectedItems.Count > Variables.Cero)
                {
                    Correo = lvCorreos.SelectedItems[0].SubItems[1].Text;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
