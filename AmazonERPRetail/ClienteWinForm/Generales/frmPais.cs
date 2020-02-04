using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Entidades.Generales;
using System.Globalization;

namespace ClienteWinForm.Generales
{
    public partial class frmPais : FrmMantenimientoBase
    {
        #region Constructores

        public frmPais()
        {
            InitializeComponent();
        }

        public frmPais(PaisesE p)
            : this()
        {
            oPais = p;
        } 

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        PaisesE oPais = null;

        #endregion

        #region Procedimientos de Usuario

        void EsNuevo()
        {
            if (oPais == null)
            {
                oPais = new PaisesE();
                txtcodIso.Text = String.Empty;
                txtCodigo.Text = oPais.idPais.ToString();
                txtNombrePais.Text = String.Empty;
                txtCodSunat.Text = String.Empty;
                txtUsuarioReg.Text = oPais.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oPais.FechaRegistro = VariablesLocales.FechaHoy;
                txtFecReg.Text = oPais.FechaRegistro.ToString();
                txtUsuarioMod.Text = oPais.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oPais.FechaModificacion = VariablesLocales.FechaHoy;
                txtFecMod.Text = oPais.FechaModificacion.ToString();
            }
            else
            {
                txtGentilicios.Text = oPais.Gentilicio;
                txtCodigo.Text = oPais.idPais.ToString("000");
                txtcodIso.Text = oPais.CodIso;
                txtNombrePais.Text = oPais.Nombre;
                txtCodSunat.Text = oPais.CodigoSunat;
                txtUsuarioReg.Text = oPais.UsuarioRegistro;
                txtFecReg.Text = oPais.FechaRegistro.ToString();
                txtUsuarioMod.Text = oPais.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oPais.FechaModificacion = VariablesLocales.FechaHoy;
                txtFecMod.Text = oPais.FechaModificacion.ToString();
            }

            base.Nuevo();
        }

        List<String> Paises()
        {
            List<String> ListaPaises = new List<String>();
            String nomPais = String.Empty;
            
            foreach (CultureInfo item in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo nombre = new RegionInfo(item.Name);

                nomPais = nombre.DisplayName;
                nomPais = nomPais.Replace("á", "a");
                nomPais = nomPais.Replace("é", "e");
                nomPais = nomPais.Replace("í", "i");
                nomPais = nomPais.Replace("ó", "o");
                nomPais = nomPais.Replace("ú", "u");

                if (!ListaPaises.Contains(nomPais.ToUpper()))
                {
                    ListaPaises.Add(nomPais.ToUpper());
                    ListaPaises.Sort();
                }
            }

            return ListaPaises;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oPais != null)
                {
                    oPais.Nombre = txtNombrePais.Text.Trim();
                    oPais.CodigoSunat = txtCodSunat.Text;
                    oPais.CodIso = txtcodIso.Text;
                    oPais.Gentilicio = txtGentilicios.Text; 
                    if (!ValidarGrabacion()) { return; }

                    if (oPais.idPais == Variables.Cero)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oPais = AgenteGeneral.Proxy.InsertarPaises(oPais);
                            txtCodigo.Text = oPais.idPais.ToString("000");
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oPais = AgenteGeneral.Proxy.ActualizarPaises(oPais);

                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                }

                base.Grabar();
                this.DialogResult = DialogResult.OK;
                this.Close();
                
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<PaisesE>(oPais);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmPais_Load(object sender, EventArgs e)
        {
            Grid = false;
            EsNuevo();
        }

        private void btObtenerPaises_Click(object sender, EventArgs e)
        {
            try
            {
                List<String> oListaPais = Paises();

                if (oListaPais != null && oListaPais.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion("Desea agregar los paises del sistema... ?") == DialogResult.Yes)
                    {
                        foreach (String item in oListaPais)
                        {
                            oPais.Nombre = item;
                            oPais.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                            oPais.FechaRegistro = VariablesLocales.FechaHoy;
                            oPais.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                            oPais.FechaModificacion = VariablesLocales.FechaHoy;

                            oPais = AgenteGeneral.Proxy.InsertarPaises(oPais);
                            txtCodigo.Text = oPais.idPais.ToString("000");
                            txtNombrePais.Text = oPais.Nombre;
                            txtGentilicios.Text = oPais.Gentilicio;
                        }
                    }

                }

                Global.MensajeComunicacion("Proceso Terminado");
                this.DialogResult = DialogResult.OK;
                Cerrar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        } 

        #endregion
    }
}
