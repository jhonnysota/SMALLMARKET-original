using Entidades.Contabilidad;
using Entidades.Generales;
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

namespace ClienteWinForm.Contabilidad
{
    public partial class frmPresupuesto : FrmMantenimientoBase
    {
        public frmPresupuesto()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvPresupuestoDet, true);
            LlenarCombos();
        }

        public frmPresupuesto(PresupuestoE PE)
            :this()
        {
            oPresupuesto = AgenteContabilidad.Proxy.ObtenerPresupuestoCompleto(PE.idEmpresa, PE.idPresupuesto);
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        public PresupuestoE oPresupuesto = null;
        List<PresupuestoDetE> ListPresuspuestoDet = null;
        List<PresupuestoDetE> oListaEliminados = new List<PresupuestoDetE>(); //Para saber si hay eliminados
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;
        Int32 OpcionGrabar;
        #endregion

        #region Procedimientos de Usuario

        void NuevoRegistro()
        {
            if (oPresupuesto == null)
            {
                oPresupuesto = new PresupuestoE();
                oPresupuesto.ListaPresupuestoDet = new List<PresupuestoDetE>();


                oPresupuesto.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                txtUsuRegistra.Text = oPresupuesto.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oPresupuesto.FechaRegistro = VariablesLocales.FechaHoy;
                txtRegistro.Text = oPresupuesto.FechaRegistro.ToString();
                txtUsuModifica.Text = oPresupuesto.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oPresupuesto.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oPresupuesto.FechaModificacion.ToString();

                OpcionGrabar = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {

                txtDescripcion.Text = oPresupuesto.Descripcion;
                cboAnio.SelectedValue = oPresupuesto.Anio;
                cboMon.SelectedValue = oPresupuesto.idMoneda;
                cboEEFF.SelectedValue = oPresupuesto.idEEFF;
                txtUsuRegistra.Text = oPresupuesto.UsuarioRegistro;
                txtRegistro.Text = oPresupuesto.FechaRegistro.ToString();
                txtUsuModifica.Text = oPresupuesto.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oPresupuesto.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oPresupuesto.FechaModificacion.ToString();
                if (oPresupuesto.ListaPresupuestoDet == null)
                {
                    oPresupuesto.ListaPresupuestoDet = new List<PresupuestoDetE>();
                }
                OpcionGrabar = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsPresupuestoDet.DataSource = oPresupuesto.ListaPresupuestoDet;
            bsPresupuestoDet.ResetBindings(false);
            ListPresuspuestoDet = new List<PresupuestoDetE>();

            base.Nuevo();
        }

        void LlenarCombos()
        {
            //////Moneda///////
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMon, (from x in ListaMoneda
                                                             orderby x.idMoneda
                                                             select x).ToList(), "idMoneda", "desMoneda", false);

            List<EEFFE> ListaEEFFItem = AgenteContabilidad.Proxy.ListarEEFFParaPres(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            EEFFE p95 = new EEFFE();
            p95.idEEFF = Variables.Cero;
            p95.desSeccion = Variables.Seleccione;
            ListaEEFFItem.Add(p95);

            ComboHelper.RellenarCombos<EEFFE>(cboEEFF, (from x in ListaEEFFItem orderby x.idEEFF select x).ToList(), "idEEFF", "desSeccion", false);


            /////ANIOS/////
            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 10;

            cboAnio.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboAnio.ValueMember = "AnioId";
            cboAnio.DisplayMember = "AnioDes";
        }

        void GuardarDatos()
        {
            oPresupuesto.Descripcion = txtDescripcion.Text;
            oPresupuesto.Anio = Convert.ToString(cboAnio.SelectedValue);
            oPresupuesto.idMoneda = Convert.ToString(cboMon.SelectedValue);
            oPresupuesto.idEEFF = Convert.ToInt32(cboEEFF.SelectedValue);
            if (OpcionGrabar == (Int32)EnumOpcionGrabar.Insertar)
            {
                oPresupuesto.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oPresupuesto.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlDatos.Enabled = Flag;
            pnlDetalles.Enabled = Flag;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Grabar()
        {
             try
            {
                if (oPresupuesto != null)
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
                            oPresupuesto = AgenteContabilidad.Proxy.GrabarPresupuesto(oPresupuesto, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            if (oListaEliminados != null && oListaEliminados.Count > Variables.Cero)
                            {
                                foreach (PresupuestoDetE item in oListaEliminados)
                                {
                                    oPresupuesto.ListaPresupuestoDet.Add(item);
                                } 
                            }

                            oPresupuesto = AgenteContabilidad.Proxy.GrabarPresupuesto(oPresupuesto, EnumOpcionGrabar.Actualizar);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
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

        public override void Editar()
        {
            BloquearPaneles(true);
            base.Editar();
        }

        public override void Cancelar()
        {
            bsPresupuestoDet.CancelEdit();
            BloquearPaneles(false);
            base.Cancelar();
        }

        public override bool ValidarGrabacion()
        {

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                Global.MensajeFault("Debe ingresar la descripción del documento.");
                txtDescripcion.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(cboAnio.Text))
            {
                Global.MensajeFault("Debe ingresar el Año.");
                txtDescripcion.Focus();
                return false;
            }

            //if (String.IsNullOrEmpty(cboMon.SelectedText))
            //{
            //    Global.MensajeFault("Debe ingresar el idMoneda.");
            //    txtDescripcion.Focus();
            //    return false;
            //}

                return base.ValidarGrabacion();
      }

        void EditarDetalle(DataGridViewCellEventArgs e, PresupuestoDetE oPresupuestoDet)
        {
            try
            {
                if (bsPresupuestoDet.Count > 0)
                {
                    frmPresupuestoDetalle oFrm = new frmPresupuestoDetalle(oPresupuestoDet, oPresupuesto.idEEFF,oPresupuesto.Anio);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oPresupuesto.ListaPresupuestoDet[e.RowIndex] = oFrm.oPrecioItem;
                        bsPresupuestoDet.DataSource = oPresupuesto.ListaPresupuestoDet;
                        bsPresupuestoDet.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void AgregarDetalle()
        {
            try
            {
                PresupuestoDetE oPresupuestoDet = new PresupuestoDetE();
                oPresupuesto.idEEFF = Convert.ToInt32(cboEEFF.SelectedValue);
                frmPresupuestoDetalle oFrm = new frmPresupuestoDetalle(oPresupuestoDet,oPresupuesto.idEEFF,oPresupuesto.Anio);

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    PresupuestoDetE oPrecioItem = oFrm.oPrecioItem;


                    for (Int32 i = 1; i < 13; i++)
                     {
                        PresupuestoDetE oPresDetTMP = new PresupuestoDetE();

                        string Mes = String.Empty;

                        if (i<10)
                        {
                            Mes = ("00"+ Convert.ToString(i)).ToString().Substring(1, 2);

                        }
                        else
                        {
                            Mes = ("0" + Convert.ToString(i).ToString()).Substring(1, 2);
                        }



                        oPresDetTMP = AgenteContabilidad.Proxy.ObtenerPresupuestosDetPorMes(oPresupuesto.idEmpresa, oPresupuesto.Anio, Mes);

                        if (oPresDetTMP == null)
                        {
                            oPresDetTMP = new PresupuestoDetE();
             
                            oPresDetTMP.idEmpresa = oPrecioItem.idEmpresa;
                            oPresDetTMP.idPresupuesto = oPresupuesto.idPresupuesto;
                            oPresDetTMP.Anio = oPrecioItem.Anio;
                            oPresDetTMP.Mes = Mes;
                            oPresDetTMP.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                            if (Mes == "01")
                            {
                                oPresDetTMP.NomMes = "ENERO";
                            }
                            if (Mes == "02")
                            {
                                oPresDetTMP.NomMes = "FEBRERO";
                            }
                            if (Mes == "03")
                            {
                                oPresDetTMP.NomMes = "MARZO";
                            }

                            if (Mes == "04")
                            {
                                oPresDetTMP.NomMes = "ABRIL";
                            }

                            if (Mes == "05")
                            {
                                oPresDetTMP.NomMes = "MAYO";
                            }
                            if (Mes == "06")
                            {
                                oPresDetTMP.NomMes = "JUNIO";
                            }
                            if (Mes == "07")
                            {
                                oPresDetTMP.NomMes = "JULIO";
                            }

                            if (Mes == "08")
                            {
                                oPresDetTMP.NomMes = "AGOSTO";
                            }
                            if (Mes == "09")
                            {
                                oPresDetTMP.NomMes = "SETIEMBRE";
                            }
                            if (Mes == "10")
                            {
                                oPresDetTMP.NomMes = "OCTUBRE";
                            }
                            if (Mes == "11")
                            {
                                oPresDetTMP.NomMes = "NOVIEMBRE";
                            }
                            if (Mes == "12")
                            {
                                oPresDetTMP.NomMes = "DICIEMBRE";
                            }
                            oPresDetTMP.idEEFFItem = oPrecioItem.idEEFFItem;
                            oPresDetTMP.Monto = oPrecioItem.Monto;
                            oPresDetTMP.DesItem = oPrecioItem.DesItem;

                            oPresDetTMP.UsuarioRegistro = oPrecioItem.UsuarioRegistro;
                            oPresDetTMP.FechaRegistro = oPrecioItem.FechaRegistro;
                            oPresDetTMP.UsuarioModificacion = oPrecioItem.UsuarioModificacion;
                            oPresDetTMP.FechaModificacion = oPrecioItem.FechaModificacion;

                            oPresupuesto.ListaPresupuestoDet.Add(oPresDetTMP);
                        }
                       
                    }
                    bsPresupuestoDet.DataSource = oPresupuesto.ListaPresupuestoDet;
                    bsPresupuestoDet.ResetBindings(false);
                    
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
                if (bsPresupuestoDet.Current != null)
                {
                    if (oPresupuesto.ListaPresupuestoDet != null && oPresupuesto.ListaPresupuestoDet.Count > Variables.Cero)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                        {
                            //Actualizando el campo para saber que se va a realizar...
                            ((PresupuestoDetE)bsPresupuestoDet.Current).Opcion = (Int32)EnumOpcionGrabar.Eliminar;
                            //Agregando a la lista de eliminados
                            oListaEliminados.Add((PresupuestoDetE)bsPresupuestoDet.Current);
                            //Removiendo de la lista principal(temporalmente)...
                            oPresupuesto.ListaPresupuestoDet.RemoveAt(bsPresupuestoDet.Position);
                            //Actualizando la lista...
                            bsPresupuestoDet.DataSource = oPresupuesto.ListaPresupuestoDet;
                            bsPresupuestoDet.ResetBindings(false);

                            base.QuitarDetalle();
                        }
                        base.QuitarDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }


        public override void Cerrar()
        {
            bsPresupuestoDet.EndEdit();
            base.Cerrar();
        }

        #endregion

        #region Eventos

        private void frmPresupuesto_Load(object sender, EventArgs e)
        {
            Grid = false;
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
            cboAnio.SelectedValue = Convert.ToInt32(Anio);
            NuevoRegistro();
        }

        private void frmPresupuesto_Activated(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
        }

        private void dgvPresupuestoDet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditarDetalle(e, ((PresupuestoDetE)bsPresupuestoDet.Current));
            }
        }

        #endregion


    }
}
