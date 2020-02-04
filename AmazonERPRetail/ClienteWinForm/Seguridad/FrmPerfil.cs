using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//INVOCAMOS
//using Negocio;
using Presentadora.AgenteServicio;
using Entidades.Seguridad;
//PARA HABILITAR LOS CONTROLES
using Infraestructura.Enumerados;

namespace ClienteWinForm.Seguridad
{
	public partial class FrmPerfil : FrmMantenimientoBase
	{

	#region VARIABLES
		
        //PerfilLN perfilLN = new PerfilLN();
        int variable = 0;


	#endregion

	#region CONSTRUCTOR
		
		public FrmPerfil()
		{
			InitializeComponent();
		}

	#endregion
	
	#region AGENTE
		SeguridadServiceAgent AgenteSeguridad
		{
			get
			{
				return new SeguridadServiceAgent();
			}
		}
	#endregion

	#region MANTENIMIENTO
		

		//PARA HABILITAR LOS CONTROLES
		public void habilitarcontrol()
		{
			BloquearOpcion(EnumOpcionMenuBarra.Grabar, false);
			BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
			BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
			BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
			BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
			//BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
			//BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
			//BloquearOpcion(EnumOpcionMenuBarra.Exportar, false);
			//BloquearOpcion(EnumOpcionMenuBarra.Imprimir, false);
		}


		//METODO PARA CANCELAR //YA ESTA
		public override void Cancelar()
		{
            if (MessageBox.Show("¿Desea Cancelar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                dgDetalle.Enabled = true;
                txtNombre.Enabled = false;
                txtNombre.Text = "";
                bindingPerfiles.DataSource = AgenteSeguridad.Proxy.ListarPerfil("");
                base.Cancelar();
            }
			
		}

		//METODO PARA CERRAR // YA ESTA
		public override void Cerrar()
		{
			this.Close();
			base.Cerrar();
		}

		//METODO PARA EDITAR //YA ESTA
		public override void Editar()
		{
            if (txtId.Text.Length == 0) return;
            dgDetalle.Enabled = false;
            txtNombre.Enabled = true;
            txtNombre.Focus();
			
			//idRolTextBox.Enabled = false;
			//estadoCheckBox.Enabled = false;
            variable = 2;
			base.Editar();
		}

		//METODO PARA NUEVO //YA ESTA
		public override void Nuevo()
		{
            DateTime dt = DateTime.Now;

            txtNombre.Enabled = true;
            bindingPerfiles.AddNew();
            

            txtNombre.Focus();
            txtFechaR.Text = dt.ToShortDateString();
			txtUsuario.Text = VariablesLocales.SesionUsuario.Credencial;
            txtFechaA.Text = dt.ToShortDateString();
            txtUsuarioA.Text = VariablesLocales.SesionUsuario.Credencial;

            dgDetalle.Enabled = false;
            variable = 1;

			base.Nuevo();
		}

        //METODO PARA ELIMINAR //YA ESTA
        public override void Anular()
        {
            if (txtId.Text.Length == 0) return;
            if (MessageBox.Show("¿Seguro de anular ELIMINAR el registro seleccionado?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                AgenteSeguridad.Proxy.EliminarPerfil(int.Parse(txtId.Text));
                bindingPerfiles.Clear();
                bindingPerfiles.DataSource = AgenteSeguridad.Proxy.ListarPerfil("");
            }
            base.Anular();
        }
        
        //METODO PARA GRABAR
        public override void Grabar()
        {
            if (variable == 1)
            {
                if (MessageBox.Show("¿Desea Registrar el Nuevo Perfil?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    dgDetalle.Enabled = true;

                    bindingPerfiles.EndEdit();
                    bindingPerfiles.DataSource = AgenteSeguridad.Proxy.InsertarPerfil((Perfil)bindingPerfiles.Current);//new PerfilLN().InsertarPerfil((Perfil)bindingPerfiles.Current);

                    bindingPerfiles.DataSource = AgenteSeguridad.Proxy.ListarPerfil("");
                    ControlBloqueado();
                    base.Grabar();
                }
                
            }
            else
            {
                if (MessageBox.Show("¿Desea Modificar el Perfil SeleccionadoS?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    dgDetalle.Enabled = true;
                    //Perfil
                    bindingPerfiles.EndEdit();
                    bindingPerfiles.DataSource = AgenteSeguridad.Proxy.ActualizarPerfil((Perfil)bindingPerfiles.Current);//new PerfilLN().InsertarPerfil((Perfil)bindingPerfiles.Current);
                    //bindingPerfiles.DataSource = new PerfilLN().InsertarPerfil(perfil);
                    bindingPerfiles.DataSource = AgenteSeguridad.Proxy.ListarPerfil("");
                    ControlBloqueado();
                    base.Grabar();
                }
            }



           
            
        }

	#endregion	

    #region EVENTOS
    
    //CONTROL BLOQUEADO
    private void ControlBloqueado()
    {
        txtId.Enabled = false;
        txtNombre.Enabled = false;
        txtUsuario.Enabled = false;
        txtUsuarioA.Enabled = false;
        txtFechaA.Enabled = false;
        txtFechaR.Enabled = false;
    }

    //CONTROL DESBLOQUEADO
    private void ControlDesbloqueado()
    {
        txtId.Enabled = true;
        txtNombre.Enabled = true;
        txtUsuario.Enabled = false;
        txtUsuarioA.Enabled = false;
        txtFechaA.Enabled = false;
        txtFechaR.Enabled = false;
    }

	//LOAD DEL FORMULARIO
	private void FrmPerfil_Load(object sender, EventArgs e)
	{
		BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
        BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
        BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
        ControlBloqueado();
        //dgDetalle.Enabled = false;
        bindingPerfiles.DataSource = AgenteSeguridad.Proxy.ListarPerfil("");
	}

    //VALIDACIONES
    private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
        {
            MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            e.Handled = true;
            return;
        }

    }


#endregion	

    private void txtId_TextChanged(object sender, EventArgs e)
    {

    }

    private void dtpFechaR_ValueChanged(object sender, EventArgs e)
    {

    }

    
	}
}
