using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;

namespace ClienteWinForm.Busquedas
{
    public partial class frmListarPersonasPorFiltro : frmResponseBase
    {

        #region Constructores
        
        public frmListarPersonasPorFiltro()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvPersonas, false);
            AnchoColumnas();
        }

        public frmListarPersonasPorFiltro(List<Persona> oListaTemporal, String Tipo = "")
            :this()
        {
            TipoAuxiliar = Tipo;
            bsBase.DataSource = oListaPersonas = oListaTemporal;
            bsBase.ResetBindings(false);

            lblTitPnlBase.Text = "Registros " + oListaTemporal.Count.ToString();
            EsconderColumnas();
        }

        public frmListarPersonasPorFiltro(List<TrabajadorE> oListaTemporal)
            : this()
        {
            //oListaTrabajadores = oListaTemporal;
            bsBase.DataSource = oListaTrabajadores = oListaTemporal;
            bsBase.ResetBindings(false);

            EsconderColumnas();
        }

        #endregion Constructores

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<Persona> oListaPersonas = null;
        List<TrabajadorE> oListaTrabajadores = null;
        public Persona oPersona = null;
        String TipoAuxiliar = String.Empty;

        #endregion Variables

        #region Procedimientos de Usuario

        void EsconderColumnas()
        {
            if (oListaTrabajadores != null)
            {
                dgvPersonas.Columns[7].Visible = true;
            }

            if (TipoAuxiliar == "Vendedor" || TipoAuxiliar == "Refe")
            {
                dgvPersonas.Columns[0].Visible = false;
                dgvPersonas.Columns[1].Visible = false;
                dgvPersonas.Columns[2].Visible = false;
                dgvPersonas.Columns[3].Visible = false;
            }
        }

        void AnchoColumnas()
        {
            dgvPersonas.Columns[0].Width = 20;
            dgvPersonas.Columns[1].Width = 20;
            dgvPersonas.Columns[2].Width = 20;
            dgvPersonas.Columns[3].Width = 20;
            dgvPersonas.Columns[4].Width = 350;
            dgvPersonas.Columns[5].Width = 80;
            dgvPersonas.Columns[6].Width = 350;
            dgvPersonas.Columns[7].Width = 100;
        }

        void ValidarAuxiliar(Persona Fila)
        {
            if (TipoAuxiliar == "Clientes")
            {
                if (!Fila.Cli)
                {
                    if (Global.MensajeConfirmacion("Este auxiliar no esta ingresado como Cliente. Desea agregarlo ?") == DialogResult.Yes)
                    {
                        ClienteE oCliente = new ClienteE() 
                        { 
                            idPersona= Fila.IdPersona,
                            idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                            SiglaComercial = Fila.RazonSocial,
                            TipoCliente = 0,
                            fecInscripcion = (Nullable<DateTime>)null,
                            fecInicioEmpresa = (Nullable<DateTime>)null,
                            tipConstitucion = 0,
                            tipRegimen = 0,
                            catCliente = 0,
                            UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                        };

                        AgenteMaestro.Proxy.InsertarCliente(oCliente);
                    }
                }
            }
            else if (TipoAuxiliar == "Prov")
            {
                if (!Fila.Pro)
                {
                    if (Global.MensajeConfirmacion("Este auxiliar no esta ingresado como Proveedor. Desea agregarlo ?") == DialogResult.Yes)
                    {
                        ProveedorE oProveedor = new ProveedorE()
                        {
                            IdPersona = Fila.IdPersona,
                            IdEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                            SiglaComercial = Fila.RazonSocial,
                            TipoProveedor = 0,
                            fecInscripcion = (Nullable<DateTime>)null,
                            fecInicioActividad = (Nullable<DateTime>)null,
                            tipConstitucion = 0,
                            tipRegimen = 0,
                            catProveedor = 0,
                            indBaja = Variables.NO,
                            UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                        };

                        AgenteMaestro.Proxy.InsertarProveedor(oProveedor);
                    }
                }
            }
        }

        void BuscarFiltro()
        {
            if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
            {
                bsBase.DataSource = (from x in oListaPersonas
                                     where x.RUC.ToUpper().Contains(txtRuc.Text.ToUpper())
                                     select x).ToList();
            }
            else if (String.IsNullOrEmpty(txtRuc.Text.Trim()) && !String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
            {
                bsBase.DataSource = (from x in oListaPersonas
                                     where x.RazonSocial.ToUpper().Contains(txtRazonSocial.Text.ToUpper())
                                     select x).ToList();
            }
            else
            {
                bsBase.DataSource = (from x in oListaPersonas
                                     where x.RUC.ToUpper().Contains(txtRuc.Text.ToUpper()) &&
                                     x.RazonSocial.ToUpper().Contains(txtRazonSocial.Text.ToUpper())
                                     select x).ToList();
            }

            lblTitPnlBase.Text = "Registros " + oListaPersonas.Count.ToString();
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Aceptar()
        {
            try
            {
                if (bsBase.Count > Variables.Cero)
                {
                    if (!String.IsNullOrEmpty(TipoAuxiliar))
                    {
                        ValidarAuxiliar((Persona)bsBase.Current);    
                    }
                    
                    oPersona = (Persona)bsBase.Current;
                    base.Aceptar(); 
                }
                else
                {
                    Global.MensajeFault("No hay datos. Cierre la ventana.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmListarPersonasPorFiltro_Load(object sender, EventArgs e)
        {
            dgvPersonas.Focus();
        }

        private void dgvPersonas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Aceptar();
            }
        } 

        private void dgvPersonas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((oListaPersonas != null && oListaPersonas.Count > Variables.Cero) || (oListaTrabajadores != null && oListaTrabajadores.Count > 0))
            {
                Aceptar();
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (oListaPersonas != null && oListaPersonas.Count > Variables.Cero)
                {
                    BuscarFiltro();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (oListaPersonas != null && oListaPersonas.Count > Variables.Cero)
                {
                    BuscarFiltro();
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
