using Entidades.Maestros;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClienteWinForm.Ventas
{
    public partial class frmCategoriaVendedor : FrmMantenimientoBase
    {

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }

        CategoriaVendedorE Entidad;
        List<LineaE> oListaLinea;
        List<CategoriaVendedorLineaE> oListaDetalle;
        List<VendedoresE> oListaVendedor = null;

        public frmCategoriaVendedor()
        {
            InitializeComponent();

            FormatoGrid(dgvLineas, true);
            FormatoGrid(dgvLineasAsignadas, true);
        }

        private void frmCategoriaVendedor_Load(object sender, EventArgs e)
        {
            Grid = true;

            base.Grabar();
            base.AgregarDetalle();
            base.QuitarDetalle();

            BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            //oListaVendedor = AgenteMaestros.Proxy.ListarVendedores(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "", false);

            foreach( VendedoresE item in oListaVendedor)
            {
                item.Nombres = item.Nombres + " " + item.ApePaterno + " " + item.ApeMaterno;
            }

            oListaVendedor.Add(new VendedoresE() { idPersona = 0,Nombres=Variables.Seleccione });

            ComboHelper.RellenarCombos<VendedoresE>(cboVendedor, oListaVendedor.OrderBy(x => x.idPersona).ToList(), "idPersona", "Nombres");

            // ==============

            oListaLinea = AgenteVentas.Proxy.ListarLinea(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

            if (oListaLinea != null)
            {
                bsLinea.DataSource = oListaLinea;
                bsLinea.ResetBindings(false);

                lblasignados.Text = "Líneas - " + bsLinea.Count.ToString() + " Registros ";
            }
            else
            {
                lblasignados.Text = "No hay Registros ";
            }

            // ==============

            if (Entidad.idCategoria != 0)
            {
                txtCodigo.Text = Entidad.codCategoria;
                txtCategoria.Text = Entidad.desCategoria;
                chbTodos.Checked = Entidad.indCatagoria;
                cboVendedor.SelectedValue = Entidad.idVendedor;

                if (chbTodos.Checked)
                    cboVendedor.Enabled = false;

                // ==============

                txtUsuRegistra.Text = Entidad.UsuarioRegistro;
                txtRegistro.Text = Entidad.FechaRegistro.ToString();
                txtUsuModifica.Text = Entidad.UsuarioModificacion;
                txtModifica.Text = Entidad.FechaModificacion.ToString();

                // ==============

                oListaDetalle = AgenteVentas.Proxy.ListarCategoriaVendedorLinea(Entidad.idEmpresa, Entidad.idCategoria);

                bsLineaAsignadas.DataSource = oListaDetalle;
                bsLineaAsignadas.ResetBindings(false);

                lblRegistros.Text = "Líneas Asignadas - " + bsLineaAsignadas.Count.ToString() + " Registros ";

                List<LineaE> oLineaTmp = new List<LineaE>(oListaLinea);

                // ==============

                foreach (CategoriaVendedorLineaE item in oListaDetalle)
                {
                    foreach (LineaE oLinea in oLineaTmp)
                    {
                        if (item.idLinea == oLinea.idLinea)
                            oListaLinea.Remove(oLinea);
                    }
                }

                bsLinea.DataSource = oListaLinea;
                bsLinea.ResetBindings(false);

                lblasignados.Text = "Líneas - " + bsLinea.Count.ToString() + " Registros ";

            }
            else
            {
                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();
            }

            // ==============

           

        }

        public frmCategoriaVendedor(CategoriaVendedorE Entidad_)
            :this()
        {
            Entidad = Entidad_;

        }

        // ===============
        // AGREGAR 
        // ===============
        public override void AgregarDetalle()
        {
            try
            {
                Boolean Existe = true;

                if (oListaLinea != null )
                {
                    if (oListaLinea.Count > 0)
                    {
                        LineaE oLineaSeleccionada = (LineaE)bsLinea.Current;

                        if (oListaDetalle != null)
                        {
                            foreach (CategoriaVendedorLineaE item in oListaDetalle)
                            {

                                // EXISTE
                                if (item.idLinea == oLineaSeleccionada.idLinea)
                                {
                                    //item.codLinea = oLineaSeleccionada.idLinea;
                                    //item.desLinea = oLineaSeleccionada.Descripcion;

                                    //item.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                                    //item.FechaModificacion = VariablesLocales.FechaHoy;

                                    Existe = false;
                                }
                            }
                        }
                        else
                        {
                            oListaDetalle = new List<CategoriaVendedorLineaE>();
                        }

                        //NO EXISTE
                        if (Existe)
                        {
                            CategoriaVendedorLineaE oNuevo = new CategoriaVendedorLineaE();

                            oNuevo.idEmpresa = Entidad.idEmpresa;
                            oNuevo.idCategoria = Entidad.idCategoria;

                            oNuevo.idLinea = oLineaSeleccionada.idLinea;
                            oNuevo.desLinea = oLineaSeleccionada.Descripcion;

                            oNuevo.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                            oNuevo.FechaRegistro = VariablesLocales.FechaHoy;

                            oListaDetalle.Add(oNuevo);

                            // ================

                            oListaLinea.Remove(oLineaSeleccionada);

                            bsLinea.DataSource = oListaLinea;
                            bsLinea.ResetBindings(false);
                        }
                        

                        bsLineaAsignadas.DataSource = oListaDetalle;
                        bsLineaAsignadas.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
            //base.Editar();
        }

        // ===================================================================================
        // QUITAR DETALLE
        // ===================================================================================
        public override void QuitarDetalle()
        {

            if (bsLineaAsignadas.Current != null)
            {
                if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                {
                    CategoriaVendedorLineaE oLineaSeleccionada = (CategoriaVendedorLineaE)bsLineaAsignadas.Current;

                    Boolean oExiste = true;

                    foreach (LineaE item in oListaLinea)
                    {
                        if (item.idLinea.Trim() == oLineaSeleccionada.idLinea.Trim())
                            oExiste = false;
                    }

                    if(oExiste)
                        oListaLinea.Add(new LineaE() { idLinea = oLineaSeleccionada.idLinea, Descripcion = oLineaSeleccionada.desLinea });

                    bsLinea.DataSource = oListaLinea;
                    bsLinea.ResetBindings(false);

                    // ======================

                    oListaDetalle.RemoveAt(bsLineaAsignadas.Position);

                    bsLineaAsignadas.DataSource = oListaDetalle;
                    bsLineaAsignadas.ResetBindings(false);

                    
                }
            }

        }

        // ==============
        // GRABAR
        // ==============
        public override void Grabar()
        {
            try
            {

                // VALIDAMOS DATA
                if (txtCodigo.Text.Trim().Length == 0)
                {
                    Global.MensajeAdvertencia("Debe de ingresar el código de la categoria");
                    txtCodigo.Focus();
                }
                else if (txtCategoria.Text.Trim().Length == 0)
                {
                    Global.MensajeAdvertencia("Debe de ingresar la descripción de la categoria");
                    txtCategoria.Focus();
                }
                else if (validaExiteCodigo())
                {
                    Global.MensajeAdvertencia("El codigo ya existe");
                    txtCodigo.Focus();
                }
                else if (!chbTodos.Checked && cboVendedor.SelectedValue.ToString()== "0")
                {
                        Global.MensajeAdvertencia("Debe de seleccionar un Vendedor");
                        cboVendedor.Focus();
                 
                }
                else
                {
                    // CARGAMOS VARIABLES

                    Entidad.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;

                    Entidad.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    Entidad.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;

                    Entidad.idVendedor = (chbTodos.Checked ? 0 : Convert.ToInt32(cboVendedor.SelectedValue.ToString()));
                    Entidad.codCategoria = txtCodigo.Text;
                    Entidad.desCategoria = txtCategoria.Text;
                    Entidad.indCatagoria = chbTodos.Checked;

                    Entidad.oListaDetalle = ( oListaDetalle==null?new List<CategoriaVendedorLineaE>() :oListaDetalle);
                    

                    Boolean isNuevo = false;

                    if (Entidad.idCategoria == 0)
                        isNuevo = true;

                    // ACTUALIZAR SQL
                    AgenteVentas.Proxy.GrabarCategoriaVendedor(Entidad);

                    //MENSAJE
                    if (isNuevo)
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    else
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);

                    // SISTEMA
                    base.Grabar();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTodos.Checked)
            {
                cboVendedor.SelectedValue = 0;
                cboVendedor.Enabled = false;
            }
            else
            {
                cboVendedor.Enabled = true;
            }
        }

        Boolean validaExiteCodigo()
        {

            CategoriaVendedorE oValidar = AgenteVentas.Proxy.ObtenerCategoriaVendedor(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,Entidad.idCategoria,txtCodigo.Text);

            if (oValidar != null)
            {
                return true;
            }

            return false;
        }

    }
}
