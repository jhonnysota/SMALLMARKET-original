using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;

namespace ClienteWinForm.Ventas
{
    public partial class frmListaPrecio : FrmMantenimientoBase
    {

        #region Constructores

        public frmListaPrecio()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();


            FormatoGrid(dgvPrecios, false);
        }

        //Nuevo
        public frmListaPrecio(List<ListaPrecioE> oListaTemp)
            : this()
        {
            oListaValidacion = oListaTemp;
        }

        //Edición
        public frmListaPrecio(List<ListaPrecioE> oListaTemp, Int32 idEmpresa, Int32 idListaPrecio)
            : this()
        {
            oListaValidacion = oListaTemp;
            oPrecioLista = AgenteVentas.Proxy.RecuperarListaPrecio(idEmpresa, idListaPrecio);
            Text = "Lista de Precio (" + oPrecioLista.Nombre + ")";
        }

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        ListaPrecioE oPrecioLista = null;
        List<ListaPrecioItemE> oListaEliminados = new List<ListaPrecioItemE>(); //Para saber si hay eliminados.
        List<ListaPrecioE> oListaValidacion = new List<ListaPrecioE>(); //Para hacer algunas validaciones de lista predeterminadas.
        Int32 OpcionGrabar;
        Boolean Ordenar = false;
        Boolean Bloqueo = false;
        Boolean cerra = false;

        #endregion

        #region Procedimientos de Usuario

        private void LlenarCombos()
        {
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListaMoneda
                                                             orderby x.idMoneda
                                                             select x).ToList(), "idMoneda", "desMoneda", false);
        }

        private void GuardarDatos()
        {
            oPrecioLista.idMoneda = Convert.ToString(cboMoneda.SelectedValue);
            oPrecioLista.Nombre = txtNombre.Text;
            oPrecioLista.NombreCorto = txtNombreCorto.Text.Trim();
            oPrecioLista.ParaTicket = chkTicket.Checked;
            oPrecioLista.Principal = chkPrincipal.Checked;
            oPrecioLista.indBaja = false;
            oPrecioLista.NroLista = Convert.ToInt32(NumUPDown.Value);

            if (OpcionGrabar == (Int32)EnumOpcionGrabar.Insertar)
            {
                oPrecioLista.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oPrecioLista.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        private void EditarDetalle(DataGridViewCellEventArgs e, ListaPrecioItemE oPrecio)
        {
            try
            {
                if (bsListaPrecioItem.Count > 0)
                {
                    frmDetalleListaPrecioItem oFrm = new frmDetalleListaPrecioItem(oPrecio, Bloqueo);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oPrecioLista.ListaPreciosItem[e.RowIndex] = oFrm.oPrecioItem;
                        bsListaPrecioItem.DataSource = oPrecioLista.ListaPreciosItem;
                        bsListaPrecioItem.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private bool BuscarArticulo(string TextoABuscar, string Columna, DataGridView grid)
        {
            bool encontrado = false;
            Int32 fila = 0;
            if (TextoABuscar == string.Empty) return false;
            if (grid.RowCount == 0) return false;
            fila = grid.CurrentRow.Index;
            grid.ClearSelection();

            if (Columna == string.Empty)
            {
                IEnumerable<DataGridViewRow> obj = (from DataGridViewRow row in grid.Rows.Cast<DataGridViewRow>()
                                                    from DataGridViewCell cells in row.Cells
                                                    where cells.OwningRow.Equals(row) && cells.Value.ToString().ToUpper() == TextoABuscar
                                                    select row);
                if (obj.Any())
                {
                    grid.Rows[obj.FirstOrDefault().Index].Selected = true;
                    return true;
                }

            }
            else
            {
                IEnumerable<DataGridViewRow> obj = (from DataGridViewRow row in grid.Rows.Cast<DataGridViewRow>()
                                                    where row.Cells[Columna].Value.ToString().ToUpper().Contains(TextoABuscar) && row.Index > fila
                                                    select row);
                if (obj.Any())
                {

                    grid.Rows[obj.FirstOrDefault().Index].Selected = true;
                    grid.Focus();
                    grid.CurrentCell = grid.Rows[obj.FirstOrDefault().Index].Cells[3];

                    return true;
                }
                else
                {
                    Global.MensajeFault("No se Encontraron Coincidencias.");
                    grid.Rows[0].Selected = true;
                    grid.Focus();
                    grid.CurrentCell = grid.Rows[0].Cells[3];
                }
            }

            return encontrado;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oPrecioLista == null)
            {
                oPrecioLista = new ListaPrecioE
                {
                    idListaPrecio = 0,
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                };

                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                OpcionGrabar = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                cboMoneda.SelectedValue = Convert.ToString(oPrecioLista.idMoneda);
                txtNombre.Text = oPrecioLista.Nombre;
                txtNombreCorto.Text = oPrecioLista.NombreCorto;
                chkTicket.Checked = oPrecioLista.ParaTicket;
                chkPrincipal.Checked = oPrecioLista.Principal;
                NumUPDown.Value = oPrecioLista.NroLista;

                txtUsuarioRegistro.Text = oPrecioLista.UsuarioRegistro;
                txtFechaRegistro.Text = oPrecioLista.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oPrecioLista.UsuarioModificacion;
                txtFechaModificacion.Text = oPrecioLista.FechaModificacion.ToString();

                OpcionGrabar = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsListaPrecioItem.DataSource = oPrecioLista.ListaPreciosItem;
            bsListaPrecioItem.ResetBindings(false);

            if (!Bloqueo)
            {
                base.Nuevo();
            }
            else
            {
                pnlDetalle.Enabled = false;
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            }
        }

        public override void Grabar()
        {
            try
            {
                if (oPrecioLista != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (OpcionGrabar == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oPrecioLista = AgenteVentas.Proxy.GrabarListaPrecio(oPrecioLista, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            if (oListaEliminados != null && oListaEliminados.Count > Variables.Cero)
                            {
                                foreach (ListaPrecioItemE item in oListaEliminados)
                                {
                                    oPrecioLista.ListaPreciosItem.Add(item);
                                } 
                            }

                            oPrecioLista = AgenteVentas.Proxy.GrabarListaPrecio(oPrecioLista, EnumOpcionGrabar.Actualizar);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                            oListaEliminados = null;
                        }
                    }
                }

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<ListaPrecioE>(oPrecioLista);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            if (oListaValidacion != null && oListaValidacion.Count > 0)
            {
                if (chkTicket.Checked)
                {
                    if (chkPrincipal.Checked)
                    {
                        foreach (ListaPrecioE item in (from x in oListaValidacion where x.ParaTicket == true select x).ToList())
                        {
                            if (OpcionGrabar == (Int32)EnumOpcionGrabar.Actualizar)
                            {
                                if (chkPrincipal.Checked && item.Principal && item.idListaPrecio != oPrecioLista.idListaPrecio)
                                {
                                    Global.MensajeComunicacion("Ya hay una Lista de Precios predeterminada para el Punto de Ventas.");
                                    return false;
                                }
                            }
                            if(OpcionGrabar == (Int32)EnumOpcionGrabar.Insertar)
                            {
                                if (chkPrincipal.Checked && item.Principal )
                                {
                                    Global.MensajeComunicacion("Ya hay una Lista de Precios predeterminada para el Punto de Ventas.");
                                    return false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (chkPrincipal.Checked)
                    {
                        foreach (ListaPrecioE item in (from x in oListaValidacion
                                                       where x.ParaTicket == false
                                                       && x.idListaPrecio != oPrecioLista.idListaPrecio
                                                       select x).ToList())
                        {
                            if (item.Principal == chkPrincipal.Checked)
                            {
                                Global.MensajeComunicacion("Ya hay una Lista de Precios predeterminada para las ventas.");
                                return false; 
                            }
                        }
                    }
                }
            }

            return base.ValidarGrabacion();
        }

        public override void AgregarDetalle()
        {
            try
            {
                List<ListaPrecioItemE> oListaTemp = new List<ListaPrecioItemE>(oPrecioLista.ListaPreciosItem);
                frmDetalleListaPrecioItem oFrm = new frmDetalleListaPrecioItem(oListaTemp);

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    ListaPrecioItemE oPrecioItem = oFrm.oPrecioItem;
                    oPrecioLista.ListaPreciosItem.Add(oPrecioItem);
                    bsListaPrecioItem.DataSource = oPrecioLista.ListaPreciosItem;
                    bsListaPrecioItem.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (bsListaPrecioItem.Current != null)
                {
                    if (oPrecioLista.ListaPreciosItem != null && oPrecioLista.ListaPreciosItem.Count > Variables.Cero)
                    {
                        bsListaPrecioItem.EndEdit();

                        if (!((ListaPrecioItemE)bsListaPrecioItem.Current).Estado)
                        {
                            Int32 resp = AgenteVentas.Proxy.RevisarPrecioItem(((ListaPrecioItemE)bsListaPrecioItem.Current).idEmpresa, VariablesLocales.SesionLocal.IdLocal, ((ListaPrecioItemE)bsListaPrecioItem.Current).idTipoArticulo, ((ListaPrecioItemE)bsListaPrecioItem.Current).idArticulo, ((ListaPrecioItemE)bsListaPrecioItem.Current).idListaPrecio);

                            if (resp > Variables.Cero)
                            {
                                Global.MensajeComunicacion("No se puede eliminar porque el item esta relacionado con otras tablas de ventas.");

                                if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                                {
                                    ((ListaPrecioItemE)bsListaPrecioItem.Current).Estado = true;
                                    ((ListaPrecioItemE)bsListaPrecioItem.Current).Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                                    base.QuitarDetalle();
                                }
                            }
                            else
                            {
                                if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                                {
                                    //Actualizando el campo para saber que se va a realizar...
                                    ((ListaPrecioItemE)bsListaPrecioItem.Current).Opcion = (Int32)EnumOpcionGrabar.Eliminar;
                                    //Agregando a la lista de eliminados
                                    oListaEliminados.Add((ListaPrecioItemE)bsListaPrecioItem.Current);
                                    //Removiendo de la lista principal(temporalmente)...
                                    oPrecioLista.ListaPreciosItem.RemoveAt(bsListaPrecioItem.Position);
                                    //Actualizando la lista...
                                    bsListaPrecioItem.DataSource = oPrecioLista.ListaPreciosItem;
                                    bsListaPrecioItem.ResetBindings(false);

                                    base.QuitarDetalle(); 
                                }
                            }                           
                        }
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

        private void frmListaPrecio_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();

            if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
            {
                dgvPrecios.Columns["idArticulo"].Visible = false;
            }
        }             

        private void dgvPrecios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditarDetalle(e, ((ListaPrecioItemE)bsListaPrecioItem.Current));
            }
        }

        private void dgvPrecios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((Boolean)dgvPrecios.Rows[e.RowIndex].Cells["Estado"].Value == true)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado;
                }
            }
        }

        private void dgvPrecios_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (oPrecioLista.ListaPreciosItem != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // POR desTipoArticulo
                    if (e.ColumnIndex == dgvPrecios.Columns["desTipoArticulo"].Index)
                    {
                        if (Ordenar)
                        {
                            oPrecioLista.ListaPreciosItem = (from x in oPrecioLista.ListaPreciosItem orderby x.desTipoArticulo ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oPrecioLista.ListaPreciosItem = (from x in oPrecioLista.ListaPreciosItem orderby x.desTipoArticulo descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR idArticulo
                    if (e.ColumnIndex == dgvPrecios.Columns["idArticulo"].Index)
                    {
                        if (Ordenar)
                        {
                            oPrecioLista.ListaPreciosItem = (from x in oPrecioLista.ListaPreciosItem orderby x.idArticulo ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oPrecioLista.ListaPreciosItem = (from x in oPrecioLista.ListaPreciosItem orderby x.idArticulo descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR codArticulo
                    if (e.ColumnIndex == dgvPrecios.Columns["codArticulo"].Index)
                    {
                        if (Ordenar)
                        {
                            oPrecioLista.ListaPreciosItem = (from x in oPrecioLista.ListaPreciosItem orderby x.codArticulo ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oPrecioLista.ListaPreciosItem = (from x in oPrecioLista.ListaPreciosItem orderby x.codArticulo descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR desArticulo
                    if (e.ColumnIndex == dgvPrecios.Columns["desArticulo"].Index)
                    {
                        if (Ordenar)
                        {
                            oPrecioLista.ListaPreciosItem = (from x in oPrecioLista.ListaPreciosItem orderby x.desArticulo ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oPrecioLista.ListaPreciosItem = (from x in oPrecioLista.ListaPreciosItem orderby x.desArticulo descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR PrecioBruto
                    if (e.ColumnIndex == dgvPrecios.Columns["PrecioBruto"].Index)
                    {
                        if (Ordenar)
                        {
                            oPrecioLista.ListaPreciosItem = (from x in oPrecioLista.ListaPreciosItem orderby x.PrecioBruto ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oPrecioLista.ListaPreciosItem = (from x in oPrecioLista.ListaPreciosItem orderby x.PrecioBruto descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR MontoDscto1
                    if (e.ColumnIndex == dgvPrecios.Columns["MontoDscto1"].Index)
                    {
                        if (Ordenar)
                        {
                            oPrecioLista.ListaPreciosItem = (from x in oPrecioLista.ListaPreciosItem orderby x.MontoDscto1 ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oPrecioLista.ListaPreciosItem = (from x in oPrecioLista.ListaPreciosItem orderby x.MontoDscto1 descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    //// POR MontoDscto2
                    //if (e.ColumnIndex == dgvPrecios.Columns["MontoDscto2"].Index)
                    //{
                    //    if (Ordenar)
                    //    {
                    //        oPrecioLista.ListaPreciosItem = (from x in oPrecioLista.ListaPreciosItem orderby x.MontoDscto2 ascending select x).ToList();
                    //        Ordenar = false;
                    //    }
                    //    else
                    //    {
                    //        oPrecioLista.ListaPreciosItem = (from x in oPrecioLista.ListaPreciosItem orderby x.MontoDscto2 descending select x).ToList();
                    //        Ordenar = true;
                    //    }
                    //}

                }

                bsListaPrecioItem.DataSource = oPrecioLista.ListaPreciosItem;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (NumUPDown.Value > 3)
            {
                NumUPDown.Value = 3;
            }
        }
        
        private void btBuscarTexto_Click(object sender, EventArgs e)
        {
            BuscarArticulo(txtDescripcion.Text.ToUpper(), "desArticulo", dgvPrecios);
        }

        private void TxtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            Global.EventoEnter(e, btBuscarTexto);
        }

        #endregion
       
    }
}
