using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Infraestructura;
using Presentadora.AgenteServicio;
using Entidades.Generales;
using Infraestructura.Recursos;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Generales
{

    public partial class FrmParTabla2 : FrmMantenimientoBase
    {
        
        public FrmParTabla2()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            
        }

        #region Variables

        List<ParTabla> listapartabla = null;
        Int32 it = 0;
        Int32 n = 0;

        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        TreeNode nodo, nodo2;
        ParTabla partable = null;
        List<TreeNode> lista;
        String TextoOriginal = String.Empty;
        String Nemo = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        List<TreeNode> Buscar(String Texto)
        {
            List<TreeNode> list = new List<TreeNode>();

            foreach (TreeNode item in tvParTabla.Nodes)
            {
                if (item.Text.Contains(Texto))
                {
                    list.Add(item);
                }

                if (item.Nodes.Count > 0)
                {
                    list.AddRange(BuscarEnHijo(item.Nodes, Texto));
                }
            }

            return list;
        }

        List<TreeNode> BuscarEnHijo(TreeNodeCollection nodes, String Texto)
        {
            List<TreeNode> list = new List<TreeNode>();

            foreach (TreeNode item in nodes)
            {
                if (item.Text.Contains(Texto))
                {
                    list.Add(item);
                }

                if (item.Nodes.Count > 0)
                {
                    BuscarEnHijo(item.Nodes, Texto);
                }
            }

            return list;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Anular()
        {
            if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.No)
            {
                return;
            }
            
            AgenteGenerales.Proxy.AnularParTabla(partable.IdParTabla);
            pnlDetalles.Enabled = false;
            Buscar();
            base.Anular();
        }

        public override void Buscar()
        {
            try
            {
                tvParTabla.Nodes.Clear();
                Int32 idx = 0;
                Int32 n1 = 0;
                Int32 idx2 = 0;

                if (!checkBox1.Checked)
                {
                    listapartabla = AgenteGenerales.Proxy.ListarParTabla("", true, true);
                }
                else
                {
                    listapartabla = AgenteGenerales.Proxy.ListarParTabla("", true, false);
                }

                tvParTabla.BeginUpdate();
                foreach (ParTabla Padre in (from x in listapartabla where x.IdParTabla.Equals(x.Grupo) select x).ToList())
                {
                    nodo = new TreeNode(Padre.Nombre);
                    nodo.Tag = Padre.IdParTabla;
                    nodo.ImageIndex = 0;
                    nodo.SelectedImageIndex = 1;

                    Int32 n2 = 0;
                    foreach (ParTabla Hijo in (from y in listapartabla where y.Grupo.Equals(Padre.IdParTabla) && y.IdParTabla > y.Grupo select y).ToList())
                    {
                        nodo2 = new TreeNode(Hijo.Nombre);
                        nodo2.Tag = Hijo.IdParTabla;
                        nodo2.ImageIndex = 2;
                        nodo2.SelectedImageIndex = 3;

                        nodo.Nodes.Add(nodo2);

                        if (partable != null)
                        {
                            if (Hijo.IdParTabla == partable.IdParTabla)
                            {
                                idx2 = n2;
                            }
                        }

                        n2 += 1;
                    }

                    tvParTabla.Nodes.Add(nodo);

                    if (partable != null)
                    {
                        if (Padre.IdParTabla == partable.Grupo)
                        {
                            idx = n1;
                            nodo.Expand();
                        }
                    }

                    n1 += 1;
                }
                tvParTabla.EndUpdate();
                if (partable != null)
                {
                    if (idx2 > 0)
                    {
                        tvParTabla.SelectedNode = tvParTabla.Nodes[idx].Nodes[idx2];
                    }
                    else
                    {
                        tvParTabla.SelectedNode = tvParTabla.Nodes[idx];
                    }
                }

                it = 0;
                base.Buscar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void Cancelar()
        {
            if (((ParTabla)parTablaBindingSource.Current).IdParTabla != 0)
            {
                parTablaBindingSource.DataSource = AgenteGenerales.Proxy.RecuperarParTablaPorId(((ParTabla)parTablaBindingSource.Current).IdParTabla);
            }

            pnlLista.Enabled = true;
            pnlDetalles.Enabled = false;
            Buscar();
            base.Cancelar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
        }

        public override void Editar()
        {
            pnlDetalles.Enabled = true;
            pnlLista.Enabled = false;
            grupoTextBox.Enabled = false;
            Nemo = partable.NemoTecnico;
            nemoTecnicoTextBox.Focus();
            base.Editar();
        }

        public override void Grabar()
        {
            try
            {
                parTablaBindingSource.EndEdit();

                //List<ParTabla> vParTabla = AgenteGenerales.Proxy.ListarParTablaPorGrupo(Convert.ToInt32(tvParTabla.Nodes[tvParTabla.SelectedNode.Parent.Index].Tag), nombreTextBox.Text);
                //if (tvParTabla.SelectedNode.Text.Trim().ToUpper() != nombreTextBox.Text.Trim().ToUpper())
                //{
                //    if (vParTabla.Count > 0)
                //    {
                //        Global.MensajeComunicacion("El atributo ingresado ya existe en el Grupo");
                //        return;
                //    }
                //}
                if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) != DialogResult.Yes)
                {
                    return;
                }

                if (!ValidarGrabacion())
                {
                    return;
                }

                partable = (ParTabla)parTablaBindingSource.Current;

                Int32 ing = 0;

                if (partable.Grupo != 0)
                {
                    ing = Convert.ToInt32(partable.Grupo.ToString().Substring(3, 3)) + it;
                }

                if (partable.IdParTabla == 0)
                {
                    if (ing > 0)
                    {
                        partable.Grupo = Convert.ToInt32(partable.Grupo.ToString().Substring(0, 3) + "000");
                        AgenteGenerales.Proxy.InsertarParTabla(partable);
                    }
                    else
                    {
                        partable.IdParTabla = AgenteGenerales.Proxy.RecuperarMaxGrupoPartabla();
                        partable.Grupo = partable.IdParTabla;
                        AgenteGenerales.Proxy.InsertarParTabla(partable);
                    }
                }
                else
                {
                    partable.NemoTemp = Nemo;
                    partable.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    AgenteGenerales.Proxy.ActualizarParTabla(partable);
                }

                Buscar();
                pnlDetalles.Enabled = false;
                pnlLista.Enabled = true;
                base.Grabar();
                it = 0;
                pnlLista.Focus();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Nuevo()
        {
            if (it == 0 && n == 0)
            {
                txtNombreGrupo.Visible = false;
                label1.Visible = false;

                partable = new ParTabla();
                partable.Estado = true;
                partable.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                partable.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                partable.FechaModificacion = DateTime.Now;
                partable.FechaRegistro = DateTime.Now;
                partable.ValorCadena = "0";
                parTablaBindingSource.DataSource = partable;
                pnlLista.Enabled = false;
                pnlDetalles.Enabled = true;
                estadoCheckBox.Enabled = false;
                grupoTextBox.Enabled = false;
            }
            else
            {
                txtNombreGrupo.Text = AgenteGenerales.Proxy.RecuperarNombreGrupoParTabla(partable.IdParTabla);
                txtNombreGrupo.Visible = true;
                label1.Visible = true;

                if (n == 1)
                {
                    it = 1;
                    partable.Grupo = partable.Grupo;
                }

                partable.Estado = true;
                partable.Nombre = String.Empty;
                partable.NemoTecnico = String.Empty;
                partable.Descripcion = String.Empty;
                partable.EquivalenciaSunat = String.Empty;
                partable.IdParTabla = 0;
                partable.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                partable.FechaRegistro = DateTime.Now;
                parTablaBindingSource.DataSource = new ParTabla();
                parTablaBindingSource.DataSource = partable;
                pnlLista.Enabled = false;
                pnlDetalles.Enabled = true;
                estadoCheckBox.Enabled = false;
                grupoTextBox.Enabled = false;
            }

            nemoTecnicoTextBox.Focus();
            base.Nuevo();
        }

        public override bool ValidarGrabacion()
        {
            string resultado = ValidarEntidad<ParTabla>(partable);

            if (!string.IsNullOrEmpty(resultado))
            {
                Global.MensajeComunicacion(resultado);
                return false;
            }
            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void FrmParTabla2_Load(object sender, EventArgs e)
        {
            tvParTabla.ImageList = imageList1;
            Buscar();
            pnlDetalles.Enabled = false;
            Grid = false;
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
        }

        private void tvParTabla_AfterSelect(object sender, TreeViewEventArgs e)
        {
            partable = (from x in listapartabla where x.IdParTabla.Equals(e.Node.Tag) select x).FirstOrDefault();
            parTablaBindingSource.DataSource = partable;
            n = e.Node.Level;

            if (partable.IdParTabla != partable.Grupo)
            {
                txtNombreGrupo.Text = e.Node.Parent.Text;
                txtNombreGrupo.Visible = true;
                label1.Visible = true;
            }
            else
            {
                txtNombreGrupo.Visible = false;
                label1.Visible = false;
            }
        }

        private void tvParTabla_MouseUp(object sender, MouseEventArgs e)
        {
            //TreeNode NodoSeleccionado = tvParTabla.GetNodeAt(e.X, e.Y);
            //partable = (from x in listapartabla where x.IdParTabla.Equals(NodoSeleccionado.Tag) select x).FirstOrDefault();
            //parTablaBindingSource.DataSource = partable;
            //n = NodoSeleccionado.Level;

            //if (partable.IdParTabla != partable.Grupo)
            //{
            //    txtNombreGrupo.Text = NodoSeleccionado.Parent.Text;
            //    txtNombreGrupo.Visible = true;
            //    label1.Visible = true;
            //}
            //else
            //{
            //    txtNombreGrupo.Visible = false;
            //    label1.Visible = false;
            //}
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void anularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Anular();
        }

        private void nuevoGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            it = 1;
            Nuevo();
        }        

        private void txtValorEntero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Int32 a = Convert.ToInt32(e.KeyChar);

            if ((a >= 48 && a <= 57) || a == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tsBtBuscar_Click(object sender, EventArgs e)
        {
            if (lista != null && lista.Count > 0)
            {
                foreach (TreeNode item in lista)
                {
                    tvParTabla.SelectedNode = item;
                    lista.Remove(item);
                    break;
                }
            }
            else
            {
                lista = new List<TreeNode>();
                lista = Buscar(tsTxtBuscar.Text);

                foreach (TreeNode item in lista)
                {
                    tvParTabla.SelectedNode = item;
                    lista.Remove(item);
                    break;
                }
            }
        }

        private void tsmiExpandir_Click(object sender, EventArgs e)
        {
            tvParTabla.ExpandAll();
        }

        private void tsmiContraer_Click(object sender, EventArgs e)
        {
            tvParTabla.CollapseAll();
        }

        private void tsmiIncluir_Click(object sender, EventArgs e)
        {
            if (tsmiIncluir.Text == "No Incluir Anulados")
            {
                tsmiIncluir.Text = "Incluir Anulados";
                checkBox1.Checked = false;
            }
            else
            {
                tsmiIncluir.Text = "No Incluir Anulados";
                checkBox1.Checked = true;
            }
        }

        private void tsTxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TextoOriginal != tsTxtBuscar.Text)
            {
                lista = new List<TreeNode>();
            }
        }

        private void pnlDetalles_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tsTxtBuscar_Leave(object sender, EventArgs e)
        {
            TextoOriginal = tsTxtBuscar.Text;
        }

        #endregion

    }
}
