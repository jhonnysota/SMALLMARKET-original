using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using Negocio;
using Presentadora.AgenteServicio;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Generales
{
    public partial class frmMonedas : FrmMantenimientoBase
    {
        
        public frmMonedas()
        {
            InitializeComponent();

            FormatoGrid(dgvMonedas, true);
            
        }

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MonedasE oMoneda = null;

        #endregion

        #region Procedimientos Usuario

        void pListarMonedas()
        {
            bsListado.DataSource = AgenteGeneral.Proxy.ListarMonedas();
            dgvMonedas.AutoResizeColumns();

            lblRegistro.Text = bsListado.Count.ToString() + " Registros.";
        }

        void pNuevaMoneda()
        {
            oMoneda = new MonedasE();

            oMoneda.idMoneda = txtIdMoneda.Text = Variables.Cero.ToString();
            oMoneda.desMoneda = txtDescripcion.Text = String.Empty;
            oMoneda.desAbreviatura = txtAbreviatura.Text = String.Empty;
            oMoneda.ISO = txtIso.Text = String.Empty;
            oMoneda.UsuarioRegistro = txtUsuReg.Text = VariablesLocales.SesionUsuario.Credencial;
            oMoneda.FechaRegistro = VariablesLocales.FechaHoy;
            txtFecReg.Text = oMoneda.FechaRegistro.ToString();
            oMoneda.UsuarioModificacion = txtUsuMod.Text = VariablesLocales.SesionUsuario.Credencial;
            oMoneda.FechaModifica = VariablesLocales.FechaHoy;
            txtFecMod.Text = oMoneda.FechaModifica.ToString();

            bsDatos.DataSource = oMoneda;
        }

        void pGrabarMoneda()
        {
            try
            {
                if (oMoneda != null)
                {
                    if (oMoneda.idMoneda == Variables.Cero.ToString())
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) != DialogResult.Yes) { return; }

                        oMoneda = AgenteGeneral.Proxy.GrabarMoneda(oMoneda, EnumOpcionGrabar.Insertar);

                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                    else
                    {
                        oMoneda.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        oMoneda = AgenteGeneral.Proxy.GrabarMoneda(oMoneda, EnumOpcionGrabar.Actualizar);

                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }

                    VariablesLocales.ListaMonedas = AgenteGeneral.Proxy.ListarMonedas();
                }

                bsDatos.DataSource = oMoneda;
                bsDatos.ResetBindings(false);
                pListarMonedas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message);
            }
        }

        void Datos()
        {
            oMoneda.desMoneda = txtDescripcion.Text;
            oMoneda.desAbreviatura = txtAbreviatura.Text;
            oMoneda.ISO = txtIso.Text;
        }

        void ajustarResolucion(Form formulario)
        {
            String ancho = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Width.ToString();//Obtengo el ancho de la pantalla
            String alto = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Height.ToString();//Obtengo el alto de la pantalla
            String tamano = ancho + "x" + alto;//Concateno para utilizarlo en el switch
            switch (tamano)
            {
                case "800x600":
                    cambiarResolucion(formulario, 110F, 110F);//Hago el ajuste con esta función
                    break;
                case "1024x600":
                    cambiarResolucion(formulario, 96F, 110F);
                    break;
                default:
                    cambiarResolucion(formulario, 96F, 96F);
                    break;
            }
        }

        private static void cambiarResolucion(Form formulario, float ancho, float alto)
        {
            formulario.AutoScaleDimensions = new System.Drawing.SizeF(ancho, alto); //Ajusto la resolución
            formulario.PerformAutoScale(); //Escalo el control contenedor y sus elementos secundarios.
        }

        #endregion

        #region Procedimientos Heredados

        public override bool ValidarGrabacion()
        {
            String resultado = ValidarEntidad<MonedasE>(oMoneda);

            if (!String.IsNullOrEmpty(resultado))
            {
                Global.MensajeComunicacion(resultado);
                return false;
            }

            return base.ValidarGrabacion();
        }

        public override void Nuevo()
        {
            pNuevaMoneda();
            panel3.Enabled = false;
            txtDescripcion.Focus();
            base.Nuevo();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
        }

        public override void Grabar()
        {
            Datos();
            if (ValidarGrabacion() == true)
            {
                pGrabarMoneda();
                panel3.Enabled = true;
                base.Grabar();
                //BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
                //BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
                //BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
                //BloquearOpcion(EnumOpcionMenuBarra.Grabar, false);
            }            
        }

        public override void Cancelar()
        {
            panel3.Enabled = true;
            //bFlag = false;
            base.Cancelar();
            pListarMonedas();
            //BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
            //BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
            //BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
            //BloquearOpcion(EnumOpcionMenuBarra.Grabar, false);
        }

        public override void Editar()
        {
            oMoneda = (MonedasE)bsListado.Current;
            panel3.Enabled = false;
            base.Editar();
            BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
        }

        public override void Cerrar()
        {
            this.Dispose();
            base.Cerrar();
        }

        #endregion

        #region Eventos

        private void frmMonedas_Load(object sender, EventArgs e)
        {
            pListarMonedas();

            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
            BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
        }        

        private void bsListado_CurrentChanged(object sender, EventArgs e)
        {
            if (bsListado.Current != null)
            {
                //bsDatos.DataSource = Moneda = (MonedasE)bsListado.Current;
                txtIdMoneda.Text = ((MonedasE)bsListado.Current).idMoneda;
                txtDescripcion.Text = ((MonedasE)bsListado.Current).desMoneda;
                txtAbreviatura.Text = ((MonedasE)bsListado.Current).desAbreviatura;
                txtIso.Text = ((MonedasE)bsListado.Current).ISO;
                txtUsuReg.Text = ((MonedasE)bsListado.Current).UsuarioRegistro;
                txtFecReg.Text = ((MonedasE)bsListado.Current).FechaRegistro.ToString();
                txtUsuMod.Text = ((MonedasE)bsListado.Current).UsuarioModificacion;
                txtFecMod.Text = ((MonedasE)bsListado.Current).FechaModifica.ToString();
            }
        }

        private void frmMonedas_Resize(object sender, EventArgs e)
        {
            ajustarResolucion(this);
        }

        private void dgvMonedas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsListado.Count > Variables.Cero)
            {
                Editar();
            }
        }

        #endregion
    }
}
