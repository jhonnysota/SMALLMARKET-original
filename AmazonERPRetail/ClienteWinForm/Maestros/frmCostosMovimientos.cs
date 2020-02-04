using ClienteWinForm.Busquedas;
using Entidades.Generales;
using Entidades.Maestros;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Maestros
{
    public partial class frmCostosMovimientos : FrmMantenimientoBase
    {
        #region Constructor

        public frmCostosMovimientos()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();
            FormatoGrid(dgvCostosMovItem, false);
        }
        
        public frmCostosMovimientos(String Anio_,Int32 Elementos_)
           : this()
        {
            Anio = Anio_;
            Elementos = Elementos_;
        }
         
        public frmCostosMovimientos(CostosMovimientosE oCostosMov_)
            :this()
        {
            oCostosMov = oCostosMov_; 
        }

        #endregion

        #region Variables

        Boolean ValidaMeses = true;
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        CostosMovimientosE oCostosMov = null;
        List<CostosMovimientosItemE> oListaEliminados = null;
        Int32 Opcion = Variables.Cero;
        Int32 Elementos;
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        //int anioInicio = 0;
        //int anioFin = 0;
        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {

            List<ParTabla> ListaTipoArticulo = AgenteGeneral.Proxy.ListarParTablaPorNemo("ELEM");
            ParTabla p1 = new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione };
            ListaTipoArticulo.Add(p1);
            ComboHelper.RellenarCombos<ParTabla>(cboElem, (from x in ListaTipoArticulo orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);

        }

        void EditarDetalle(DataGridViewCellEventArgs e, CostosMovimientosItemE oCostosMovItem)
        {
            try
            {
                if (bsCostosMovItem.Count > 0)
                {
                    frmCostosMovimientosDetalle oFrm = new frmCostosMovimientosDetalle(oCostosMovItem);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oCostosMov.ListaCostosMovimientos[e.RowIndex] = oFrm.oCostosMovItem;
                        bsCostosMovItem.DataSource = oCostosMov.ListaCostosMovimientos;
                        bsCostosMovItem.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void Datos()
        {
            if (oCostosMov != null)
            {

                oCostosMov.Nombre = txtNombre.Text;
                oCostosMov.Anio = Anio;
                oCostosMov.idElemento = Convert.ToInt32(cboElem.SelectedValue);
                oCostosMov.CodClasificacion = txtCodClas.Text;
                if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    oCostosMov.UsuarioRegistro = txtUsuarioRegistro.Text;
                    oCostosMov.FechaRegistro = Convert.ToDateTime(txtFechaRegistro.Text);
                    oCostosMov.UsuarioModificacion = txtUsuarioModificacion.Text;
                    oCostosMov.FechaModificacion = Convert.ToDateTime(txtFechaModificacion.Text);
                }
                else
                {
                    oCostosMov.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                }
            }
        }


        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oCostosMov == null)
            {
                oCostosMov = new CostosMovimientosE();
                if (oCostosMov.ListaCostosMovimientos == null)
                {
                    oCostosMov.ListaCostosMovimientos = new List<CostosMovimientosItemE>();
                }
                 
                oCostosMov.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                cboElem.SelectedValue = Elementos;
                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {

                if (oCostosMov.ListaCostosMovimientos == null)
                {
                    oCostosMov.ListaCostosMovimientos = new List<CostosMovimientosItemE>();
                }
                txtNombre.Text = oCostosMov.Nombre;
                cboElem.SelectedValue = oCostosMov.idElemento;
                txtUsuarioRegistro.Text = oCostosMov.UsuarioRegistro;
                txtFechaRegistro.Text = oCostosMov.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oCostosMov.UsuarioModificacion;
                txtFechaModificacion.Text = oCostosMov.FechaModificacion.ToString();
                txtCodClas.Text = oCostosMov.CodClasificacion;
                btCodClas.Enabled = false;

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsCostosMovItem.DataSource = oCostosMov.ListaCostosMovimientos;
            bsCostosMovItem.ResetBindings(false);

            base.Nuevo();
        }

        public override void Cancelar()
        {
            pnlDetalle.Enabled = false;
            pnlAuditoria.Focus();
            bFlag = false;
            base.Cancelar();
        }

        public override void Grabar()
        {
            try
            {
                Datos();

                if (ValidarGrabacion())
                {
                    if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oCostosMov = AgenteMaestros.Proxy.GrabarCostosMovimientos(oCostosMov, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            if (oListaEliminados != null && oListaEliminados.Count > Variables.Cero)
                            {
                                foreach (CostosMovimientosItemE item in oListaEliminados)
                                {
                                    oCostosMov.ListaCostosMovimientos.Add(item);
                                }
                            }

                            oCostosMov = AgenteMaestros.Proxy.GrabarCostosMovimientos(oCostosMov, EnumOpcionGrabar.Actualizar);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }

                    base.Grabar();
                    oCostosMov = null;
                    oListaEliminados = null;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Cerrar()
        {
            base.Cerrar();
        }

        public override bool ValidarGrabacion()
        {
            String resultado = ValidarEntidad<CostosMovimientosE>(oCostosMov);

            if (!String.IsNullOrEmpty(resultado))
            {
                Global.MensajeComunicacion(resultado);
                return false;
            }

            return base.ValidarGrabacion();
        }

        public override void Editar()
        {
            pnlDetalle.Enabled = true;
            bFlag = true;

            base.Editar();
        }

        public override void AgregarDetalle()
        {
            try
            {
                    frmCostosMovimientosDetalle oFrm = new frmCostosMovimientosDetalle(Convert.ToString(txtCodClas.Text));

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        CostosMovimientosItemE oDetalle = oFrm.oCostosMovItem;                        

                        foreach (CostosMovimientosItemE item in oCostosMov.ListaCostosMovimientos)
                        {
                              if (item.Mes == oDetalle.Mes)
                              {
                                 ValidaMeses = false;
                                Global.MensajeComunicacion("No Se Puede Duplicar el Mes de un Movimiento");
                              }
                        }
                        if (ValidaMeses == true)
                        {
                            oCostosMov.ListaCostosMovimientos.Add(oDetalle);
                            bsCostosMovItem.DataSource = oCostosMov.ListaCostosMovimientos;
                            bsCostosMovItem.ResetBindings(false);
                        }
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
                if (bsCostosMovItem.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        if (oListaEliminados == null)
                        {
                            oListaEliminados = new List<CostosMovimientosItemE>();
                        }
                        base.QuitarDetalle();
                        //Actualizando el campo para saber que se va a realizar...
                        ((CostosMovimientosItemE)bsCostosMovItem.Current).Opcion = (Int32)EnumOpcionGrabar.Eliminar;
                        //Agregando a la lista de eliminados
                        oListaEliminados.Add((CostosMovimientosItemE)bsCostosMovItem.Current);
                        //Removiendo de la lista principal(temporalmente)...
                        oCostosMov.ListaCostosMovimientos.RemoveAt(bsCostosMovItem.Position);
                        //Actualizando la lista...
                        bsCostosMovItem.DataSource = oCostosMov.ListaCostosMovimientos;
                        bsCostosMovItem.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }


        #endregion

        #region Eventos

        private void frmCostosMovimientos_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();

            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
        }

        private void dgvCostosMovItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditarDetalle(e, ((CostosMovimientosItemE)bsCostosMovItem.Current));
            }
        }
        
        private void btCodClas_Click(object sender, EventArgs e)
        {

            frmBuscarCostosClasificacion oFrm = new frmBuscarCostosClasificacion();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCostosClasificacion != null)
            {
                txtCodClas.Text = oFrm.oCostosClasificacion.CodClasificacion;
            }
        }

        #endregion
    }
}
