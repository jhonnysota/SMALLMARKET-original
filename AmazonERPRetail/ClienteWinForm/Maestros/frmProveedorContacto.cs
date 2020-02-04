using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
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
    public partial class frmProveedorContacto : frmResponseBase
    {
        public frmProveedorContacto()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();         

        }

        //Nuevo
        public frmProveedorContacto(List<ProveedorContactoE> oLista = null)
            : this()
        {
            oListaContactos = oLista;
        }

        //Editar
        public frmProveedorContacto(ProveedorContactoE oPrecioTemp_, List<ProveedorContactoE> oLista = null)
            : this()
        {
            ProveedorContactosItem = oPrecioTemp_;
            oListaContactos = oLista;
        }

        #region Variables

        public ProveedorContactoE ProveedorContactosItem = null;
        List<ProveedorContactoE> oListaContactos = null;
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (ProveedorContactosItem == null)
            {
                ProveedorContactosItem = new ProveedorContactoE();

                ProveedorContactosItem.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                ProveedorContactosItem.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                if (ProveedorContactosItem.Opcion == 0)
                {
                    ProveedorContactosItem.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }

                txtDocumento.Text = ProveedorContactosItem.NroDocumento;
                txtPaterno.Text = ProveedorContactosItem.ApePaterno;
                txtNombres.Text = ProveedorContactosItem.Nombres;
                txtMaterno.Text = ProveedorContactosItem.ApeMaterno;
                txtTelefono1.Text = ProveedorContactosItem.Telefono1;
                txtTelefono2.Text = ProveedorContactosItem.Telefono2;
                txtCorreo1.Text = ProveedorContactosItem.Correo1;
                txtCorreo2.Text = ProveedorContactosItem.Correo2;
                txtCelular1.Text = ProveedorContactosItem.Celular1;
                txtCelular2.Text = ProveedorContactosItem.Celular2;


                txtUsuRegistra.Text = ProveedorContactosItem.UsuarioRegistro;
                txtRegistro.Text = Convert.ToString(ProveedorContactosItem.FechaRegistro);
                txtUsuModifica.Text = ProveedorContactosItem.UsuarioModificacion;
                txtModifica.Text = Convert.ToString(ProveedorContactosItem.FechaModificacion);


            }

            base.Nuevo();
        }

        public override void Aceptar()
        {
            try
            {

                if (ProveedorContactosItem != null)
                {
                    ProveedorContactosItem.NroDocumento = txtDocumento.Text;
                    ProveedorContactosItem.ApePaterno = txtPaterno.Text;
                    ProveedorContactosItem.Nombres = txtNombres.Text;
                    ProveedorContactosItem.ApeMaterno = txtMaterno.Text;
                    ProveedorContactosItem.Telefono1 = txtTelefono1.Text;
                    ProveedorContactosItem.Telefono2 = txtTelefono2.Text;
                    ProveedorContactosItem.Correo1 = txtCorreo1.Text;
                    ProveedorContactosItem.Correo2 = txtCorreo2.Text;
                    ProveedorContactosItem.Celular1 = txtCelular1.Text;
                    ProveedorContactosItem.Celular2 = txtCelular2.Text;                   
                    
                    ProveedorContactosItem.Opcion = ProveedorContactosItem.Opcion;

                    if (ProveedorContactosItem.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        ProveedorContactosItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        ProveedorContactosItem.FechaRegistro = VariablesLocales.FechaHoy;
                        ProveedorContactosItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        ProveedorContactosItem.FechaModificacion = VariablesLocales.FechaHoy;
                    }
                    else
                    {
                        ProveedorContactosItem.UsuarioModificacion = txtUsuModifica.Text;
                        ProveedorContactosItem.FechaModificacion = Convert.ToDateTime(txtModifica.Text);
                    }
                    
                    base.Aceptar();
                }

            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }


        #endregion

        private void frmProveedorContacto_Load(object sender, EventArgs e)
        {
            Nuevo();
        }
    }
}
