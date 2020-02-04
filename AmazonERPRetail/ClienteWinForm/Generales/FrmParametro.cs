using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Entidades.Generales;
using Presentadora;
using Presentadora.AgenteServicio;
using Infraestructura;
using Infraestructura.Recursos;
using ClienteWinForm.Generales.Busqueda;

namespace ClienteWinForm.Generales
{
    public partial class FrmParametro : FrmMantenimientoBase
    {

        ParametroE temp = null;

        public FrmParametro()
        {
            InitializeComponent();
        }

        ParametroE parametro = null;

        public GeneralesServiceAgent AgenteGenerales
        {
            get
            {
                return new GeneralesServiceAgent();
            }
        }

        private void FrmParametro_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void valorDecimalTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Int32 a = Convert.ToInt32(e.KeyChar);

            if ((a >= 48 && a <= 57) || a == 8 || a==46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public override void Nuevo()
        {
            parametro = new ParametroE();
            parametro.IdEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            parametro.IdParametro = 0;
            parametro.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            parametro.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            parametro.FechaRegistro = VariablesLocales.FechaHoy;
            parametro.FechaModificacion = VariablesLocales.FechaHoy;
            parametro.Estado = true;
            parametroBindingSource.DataSource = parametro;
            pnlDetalle.Enabled = true;
            pnlAuditoria.Enabled = false;
            estadoCheckBox.Enabled = false;
            parametro.Estado= true;
            nombreTextBox.Focus();
            idParametroTextBox.Enabled = false;
            base.Nuevo();            
        }

        public override void Editar()
        {
            pnlDetalle.Enabled = true;
            idParametroTextBox.Enabled = false;
            estadoCheckBox.Enabled = true;
            base.Editar();
        }

        public override void Buscar()
        {
            FrmBusquedaParametro frm = new FrmBusquedaParametro();

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK && frm.parametro != null)
            {
                parametro = frm.parametro;
                temp = parametro;
                parametroBindingSource.DataSource = parametro;
                base.Buscar();
                pnlDetalle.Enabled = false;
                BloquearOpcion(Infraestructura.Enumerados.EnumOpcionMenuBarra.Anular, true);
            }

        }

        public override void Cancelar()
        {
            if (((ParametroE)parametroBindingSource.Current).IdParametro != 0)
            {
                //parametroBindingSource.DataSource = AgenteGenerales.Proxy.RecuperarParametroPorID(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, ((ParametroE)parametroBindingSource.Current).IdParametro);
            }
            pnlDetalle.Enabled = false;
            base.Cancelar();
        }

        public override bool ValidarGrabacion()
        {
            string resultado = ValidarEntidad<ParametroE>(parametro);

            if (!string.IsNullOrEmpty(resultado))
            {
                Global.MensajeComunicacion(resultado);

                return false;
            }

            return base.ValidarGrabacion();
        }
        
        public override void Grabar()
        {
            parametroBindingSource.EndEdit();

            if (Global.MensajeConfirmacion("Desea grabar el parámetro") != DialogResult.Yes)
            {
                return;
            }

            if (!ValidarGrabacion())
            {
                return;
            }   

            try
            {
                parametro.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                parametro.IdEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;

                parametro = AgenteGenerales.Proxy.GrabarParametro(((ParametroE)parametroBindingSource.Current));
                parametroBindingSource.DataSource = parametro;
                pnlDetalle.Enabled = false;

                //TODO: Miguel Salvador, La gestion del mensaje tengo que optimizarlo
                MessageBox.Show(Infraestructura.Recursos.Mensajes.GrabacionExitosa);            
            }
            catch (Exception ex)
            {
                //TODO: Miguel Salvador, La gestion del error tengo que optimizarlo
                throw ex;
            }

            base.Grabar();

        }

        public override void Anular()
        {
            if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.No)
            {
                return;
            }

            try
            {
                parametro.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                AgenteGenerales.Proxy.ActualizarEstadoParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,int.Parse(idParametroTextBox.Text), false, VariablesLocales.SesionUsuario.Credencial, DateTime.Now);
                //parametroBindingSource.DataSource = new Parametro();
                Nuevo();
                MessageBox.Show(Infraestructura.Recursos.Mensajes.GrabacionExitosa);
                BloquearOpcion(Infraestructura.Enumerados.EnumOpcionMenuBarra.Nuevo, false);
                BloquearOpcion(Infraestructura.Enumerados.EnumOpcionMenuBarra.Grabar, true);
                BloquearOpcion(Infraestructura.Enumerados.EnumOpcionMenuBarra.Editar, false);
                pnlDetalle.Enabled = true;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
           
            //base.Anular();
        }
    
    
    }
}
