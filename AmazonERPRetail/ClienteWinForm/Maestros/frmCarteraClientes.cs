using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;

namespace ClienteWinForm.Maestros
{
    public partial class frmCarteraClientes : FrmMantenimientoBase
    {

        #region Constructores

        public frmCarteraClientes()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvVendedor, true);
        }

        public frmCarteraClientes(VendedoresE Vendedores_, Persona persona)
            :this()
        {
            oVendedor = Vendedores_;
            oPersona = persona;

            Text = "Cartera de Clientes de " + oVendedor.Nombres + " " + oVendedor.ApePaterno;
        }

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        VendedoresE oVendedor = null;
        List<VendedoresCarteraE> oListaEliminados = new List<VendedoresCarteraE>();
        Persona oPersona = null;

        #endregion

        #region Procedimientos de Usuario

        void EditarDetalle(DataGridViewCellEventArgs e, VendedoresCarteraE oVendedoresCartera, List<VendedoresCarteraE> ListaTemp)
        {
            try
            {
                if (bsCarteraClientes.Count > 0)
                {
                    frmDetalleCarteraCliente oFrm = new frmDetalleCarteraCliente(oVendedoresCartera, ListaTemp);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oVendedor.ListaVendedoresCartera[e.RowIndex] = oFrm.oDetalleCliente;
                        bsCarteraClientes.DataSource = oVendedor.ListaVendedoresCartera;
                        bsCarteraClientes.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oVendedor.ListaVendedoresCartera == null)
            {
                oVendedor.ListaVendedoresCartera = new List<VendedoresCarteraE>();
            }
            else
            {
                oVendedor.Persona = oPersona;
                oVendedor.Persona.RazonSocial = oVendedor.Persona.ApePaterno + " " + oVendedor.Persona.ApeMaterno + " " + oVendedor.Persona.Nombres;
                bsCarteraClientes.DataSource = oVendedor.ListaVendedoresCartera;
                bsCarteraClientes.ResetBindings(false);
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oVendedor.ListaVendedoresCartera != null && oVendedor.ListaVendedoresCartera.Count > 0)
                {
                    if (!ValidarGrabacion())
                    {
                        return;
                    }
                  
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        if (oListaEliminados != null && oListaEliminados.Count > Variables.Cero)
                        {
                            foreach (VendedoresCarteraE item in oListaEliminados)
                            {
                                oVendedor.ListaVendedoresCartera.Add(item);
                            }
                        }

                        oVendedor = AgenteMaestros.Proxy.GrabarVendedor(oVendedor, EnumOpcionGrabar.Actualizar);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }
                else
                {
                    Global.MensajeError("No existe Registros de Clientes para guardar");
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

        public override void Cancelar()
        {
            bsCarteraClientes.CancelEdit();
            base.Cancelar();
        }

        public override void AgregarDetalle()
        {
            try
            {
                frmDetalleCarteraCliente oFrm = new frmDetalleCarteraCliente(oVendedor.Nombres + " " + oVendedor.ApePaterno, oPersona.IdPersona, oVendedor.ListaVendedoresCartera);

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    oVendedor.ListaVendedoresCartera.Add(oFrm.oDetalleCliente);
                    bsCarteraClientes.DataSource = oVendedor.ListaVendedoresCartera;
                    bsCarteraClientes.ResetBindings(false);
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
                if (bsCarteraClientes.Current != null)
                {
                    if (oVendedor.ListaVendedoresCartera != null && oVendedor.ListaVendedoresCartera.Count > Variables.Cero)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                        {
                            //Actualizando el campo para saber que se va a realizar...
                            ((VendedoresCarteraE)bsCarteraClientes.Current).Opcion = (Int32)EnumOpcionGrabar.Eliminar;
                            //Agregando a la lista de eliminados
                            oListaEliminados.Add((VendedoresCarteraE)bsCarteraClientes.Current);
                            //Removiendo de la lista principal(temporalmente)...
                            oVendedor.ListaVendedoresCartera.RemoveAt(bsCarteraClientes.Position);
                            //Actualizando la lista...
                            bsCarteraClientes.DataSource = oVendedor.ListaVendedoresCartera;
                            bsCarteraClientes.ResetBindings(false);

                            base.QuitarDetalle();
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

        private void frmCarteraClientes_Load(object sender, EventArgs e)
        {
            Grid = false;
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
            Nuevo();
        }

        private void dgvVendedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditarDetalle(e, ((VendedoresCarteraE)bsCarteraClientes.Current), oVendedor.ListaVendedoresCartera);
            }
        }

        #endregion

    }
}
