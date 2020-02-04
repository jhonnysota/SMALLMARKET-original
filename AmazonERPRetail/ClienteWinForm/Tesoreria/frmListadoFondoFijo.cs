using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using ClienteWinForm.Maestros;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmListadoFondoFijo : FrmMantenimientoBase
    {

        #region Constructor

        public frmListadoFondoFijo()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            
            FormatoGrid(dgvFondoFijo, true);
        }

        #endregion

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        List<FondoFijoE> ListaFondoFijo = null;

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                String TipoFondo = String.Empty;

                if (rbFijos.Checked)
                {
                    TipoFondo = "102";
                }

                if (rbRendir.Checked)
                {
                    TipoFondo = "168";
                }

                if (rbRendir.Checked)
                {
                    FrmDlgPersona oFrm = new FrmDlgPersona(TipoFondo);

                    if (oFrm.ValidarIngresoVentana())
                    {
                        oFrm.Enumerado = EnumTipoRolPersona.FondosFijos;
                        oFrm.OpcionVentana = (Int32)EnumTipoRolPersona.FondosFijos;
                        oFrm.MdiParent = MdiParent;
                        oFrm.Show();
                    } 
                }
                else
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmFondoFijo);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        //si la instancia existe la pongo en primer plano
                        oFrm.BringToFront();
                        return;
                    }

                    //sino existe la instancia se crea una nueva
                    FondoFijoE F = new FondoFijoE() { TipoFondo = "102" };
                    F.Persona.TipoPersona = Convert.ToInt32(enumTipoPersona.Otros);
                    F.Persona.TipoDocumento = (Int32)EnumTipoDocumento.Otros;
                    F.Persona.idPais = 90; ///Perú

                    oFrm = new frmFondoFijo(F, F.Persona, (Int32)EnumOpcionGrabar.Insertar, "")
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Buscar()
        {
            try
            {
                if (rbFijos.Checked)
                {
                    ListaFondoFijo = AgenteTesoreria.Proxy.ListarFondoFijo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, "102");
                }

                if (rbRendir.Checked)
                {
                    ListaFondoFijo = AgenteTesoreria.Proxy.ListarFondoFijo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, "168");
                }

                bsFondoFijo.DataSource = ListaFondoFijo;
                bsFondoFijo.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Editar()
        {
            try
            {
                if (bsFondoFijo.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmFondoFijo);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        //si la instancia existe la pongo en primer plano
                        oFrm.BringToFront();
                        return;
                    }

                    //sino existe la instancia se crea una nueva
                    Persona per = AgenteMaestros.Proxy.RecuperarPersonaPorID(((FondoFijoE)bsFondoFijo.Current).idPersona);
                    oFrm = new frmFondoFijo(((FondoFijoE)bsFondoFijo.Current).idEmpresa, ((FondoFijoE)bsFondoFijo.Current).idLocal, ((FondoFijoE)bsFondoFijo.Current).idPersona, per)
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                if (bsFondoFijo.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteTesoreria.Proxy.EliminarFondoFijo(((FondoFijoE)bsFondoFijo.Current).idEmpresa, ((FondoFijoE)bsFondoFijo.Current).idLocal, ((FondoFijoE)bsFondoFijo.Current).idPersona);
                        Buscar();
                        Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                        base.Anular();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmFondoFijo oFrm = sender as frmFondoFijo;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoFondoFijo_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            Buscar();
        }

        private void dgvFondoFijo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void rbRendir_CheckedChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void rbFijos_CheckedChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void bsFondoFijo_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                if (bsFondoFijo.Current != null)
                {
                    lblRegistros.Text = String.Format("Registros {0}", ListaFondoFijo.Count.ToString());
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
