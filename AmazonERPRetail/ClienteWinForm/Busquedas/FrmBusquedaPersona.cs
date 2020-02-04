using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class FrmBusquedaPersona : FrmBusquedaBase
    {

        #region Constructores
        
        public FrmBusquedaPersona()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvPersona);
            LlenarCombo();
        }

        public FrmBusquedaPersona(String Tipo)
            : this()
        {
            TipoAuxiliar = Tipo;
        } 

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestro = new MaestrosServiceAgent();
        public Persona oPersona = new Persona();
        String TipoAuxiliar = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombo()
        {
            cboTipoAuxiliar.DataSource = Global.CargarTipoAuxiliar();
            cboTipoAuxiliar.DisplayMember = "nombre";
            cboTipoAuxiliar.ValueMember = "id";
        }

        void ValidarAuxiliar(Persona Fila)
        {
            if (TipoAuxiliar == "Clientes" && cboTipoAuxiliar.SelectedValue.ToString() != "CL")
            {
                if (Global.MensajeConfirmacion("Este auxiliar no esta ingresado como Cliente. Desea agregarlo ?") == DialogResult.Yes)
                {
                    //Int32 CanalVenta = Variables.Cero; // 0 = Nacional 1 = Exportación

                    //if (Fila.NemoTipPer == enumTipoAuxiliar.OTR.ToString())
                    //{
                    //    CanalVenta = 1;
                    //}

                    ClienteE oCliente = new ClienteE()
                    {
                        idPersona = Fila.IdPersona,
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        SiglaComercial = Fila.RazonSocial,
                        TipoCliente = 0,
                        fecInscripcion = (Nullable<DateTime>)null,
                        fecInicioEmpresa = (Nullable<DateTime>)null,
                        tipConstitucion = 0,
                        tipRegimen = 0,
                        catCliente = 0,
                        //idCanalVenta = CanalVenta,
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                    };

                    AgenteMaestro.Proxy.InsertarCliente(oCliente);
                }
            }
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            List<Persona> oListaPersona = new List<Persona>();
            String RazonSocial = txtRazonSocial.Text.Trim();
            String NroDocumento = txtNroDocumento.Text.Trim();

            if (cboTipoAuxiliar.SelectedValue.ToString() == "0")
            {
                Global.MensajeComunicacion("Tiene que escoger un tipo de auxiliar.");
                return;
            }

            if (TipoAuxiliar == "Refe")
            {
                oListaPersona = AgenteMaestro.Proxy.BusquedaPersonaPorTipo("CL", VariablesLocales.SesionUsuario.Empresa.IdEmpresa, RazonSocial, NroDocumento, true);
            }
            else
            {
                if (cboTipoAuxiliar.SelectedValue.ToString() == "PR")
                {
                    if (String.IsNullOrWhiteSpace(txtRazonSocial.Text.Trim()) && String.IsNullOrWhiteSpace(txtNroDocumento.Text.Trim()))
                    {
                        Global.MensajeComunicacion("Debe colocar un indicio en Razón Social o Nro de Documento.");
                        return;
                    }
                }

                oListaPersona = AgenteMaestro.Proxy.BusquedaPersonaPorTipo(cboTipoAuxiliar.SelectedValue.ToString(), VariablesLocales.SesionUsuario.Empresa.IdEmpresa, RazonSocial, NroDocumento);
            }

            bsBase.DataSource = oListaPersona;
            dgvPersona.AutoResizeColumns();

            if (oListaPersona.Count > Variables.Cero)
            {
                dgvPersona.Focus();
            }

            oListaPersona = null;
            
            base.Buscar();
        }

        protected override void Aceptar()
        {
            try
            {
                if (bsBase.Count > 0)
                {
                    if (!String.IsNullOrEmpty(TipoAuxiliar))
                    {
                        ValidarAuxiliar((Persona)bsBase.Current);
                    }

                    oPersona = (Persona)bsBase.Current;
                }

                base.Aceptar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void FrmBusquedaPersona_Load(object sender, EventArgs e)
        {
            try
            {
                cboTipoAuxiliar.Focus();

                if (TipoAuxiliar == "Clientes" || TipoAuxiliar == "Refe")
                {
                    cboTipoAuxiliar.SelectedValue = "CL";

                    if (TipoAuxiliar == "Refe")
                    {
                        cboTipoAuxiliar.Enabled = false;
                    }
                }

                //Fondo Fijo
                if (TipoAuxiliar == "005")
                {
                    cboTipoAuxiliar.SelectedValue = "FF";
                }
                // Ctas a rendir
                else if (TipoAuxiliar == "012")
                {
                    cboTipoAuxiliar.SelectedValue = "CR";
                }
                else
                {
                    cboTipoAuxiliar.SelectedValue = "PR";
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvPersona_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsBase.Count > Variables.Cero)
            {
                Aceptar();
            }
        }

        private void dgvPersona_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                EstiloCabeceras(dgvPersona, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void cboTipoAuxiliar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboTipoAuxiliar.SelectedValue != null)
            {
                txtRazonSocial.Focus();
            }
        }

        private void dgvPersona_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Aceptar();
            }
        }

        #endregion

    }
}
