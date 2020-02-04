using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClienteWinForm.Seguridad.Busquedas;
using Entidades.Seguridad;
using Presentadora.AgenteServicio;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Seguridad
{
    public partial class FrmRolOpcion : FrmMantenimientoBase
    {
        public FrmRolOpcion()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvRol, true);
            FormatoGrid(dgvOpcion, false);
        }

        #region Variables 

        Rol rol = new Rol();
        List<Rol> listaroles = null; 
        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }

        #endregion

        #region Procedimientos Usuario

        

        #endregion

        #region Procedimientos Heredados

        public override void Anular()
        {
            base.Anular();
        }

        public override void Buscar()
        {
            listaroles = AgenteSeguridad.Proxy.ListarRol("", false, false);

            foreach (Rol r in listaroles)
            {
                r.OpcionesRol = AgenteSeguridad.Proxy.ListarOpcionRol(r.IdRol);
            }

            rolBindingSource.DataSource = listaroles;
            
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            base.Buscar();
            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
            BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
            pnlDetalle.Enabled = true;
        }

        public override void Cancelar()
        {
            base.Cancelar();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            Buscar();
            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
            BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
            //BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
        }

        public override void Cerrar()
        {
            base.Cerrar();
        }

        public override void Editar()
        {
            pnlDetalle.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            base.Editar();
            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
            BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
            BloquearOpcion(EnumOpcionMenuBarra.Editar, false);            
        }      
  
        public override void Grabar()
        {            
            String i = AgenteSeguridad.Proxy.InsertarRolOpcion(listaroles,VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            Global.MensajeComunicacion(i);
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
            BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
            BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            pnlDetalle.Enabled = true;
        }       

        #endregion

        #region Eventos

        private void FrmRolOpcion_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            base.Cancelar();
        }       

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (((Opcion)opcionBindingSource.Current).control == true)
                {
                    ((Opcion)opcionBindingSource.Current).control = false;
                }
                else
                {
                    ((Opcion)opcionBindingSource.Current).control = true;
                }
                rolBindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
            //op.control=true;                        

            //var res = (from x in listaopciones
            //               where x.IdOpcion)

            //DataGridViewRow row = opcionDataGridView.CurrentRow as DataGridViewRow;

            //for (int i = 0; i < opcionDataGridView.Rows.Count; i++)
            //{
            //    if (Convert.ToBoolean(opcionDataGridView.Rows[i].Cells["control"].Value) == true)
            //    {
            //        listaopciones[i].control = false;
            //        opcionBindingSource.DataSource = listaopciones;
            //    }
            //}

            //string jo = ((Opcion)opcionBindingSource.Current).Descripcion.ToString();
            //MessageBox.Show(jo);
            //if (((Opcion)opcionBindingSource.Current).control)
            //{
            //    ((Opcion)opcionBindingSource.Current).control = false;

            //    var res = (from x in listarolOpcion
            //               where x.IdOpcion.Equals(((Opcion)opcionBindingSource.Current).IdOpcion) &&
            //               x.IdRol.Equals(((Rol)rolBindingSource.Current).IdRol)
            //               select x).FirstOrDefault();
            //    res.Acceso = true;
            //    //

            //}
            //else
            //{
            //    //((Opcion)opcionBindingSource.Current).control = true;
            //    //var res = (from x in listarolOpcion
            //    //           where x.IdOpcion.Equals(((Opcion)opcionBindingSource.Current).IdOpcion) &&
            //    //           x.IdRol.Equals(((Rol)rolBindingSource.Current).IdRol)
            //    //           select x).FirstOrDefault();
            //    //res.Acceso = true;
            //    ////
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FrmListaOpciones frm = new FrmListaOpciones();

                frm.rol = ((Rol)rolBindingSource.Current);
                frm.rol.OpcionesRol = ((Rol)rolBindingSource.Current).OpcionesRol;

                if (frm.ShowDialog() == DialogResult.OK && frm.rol != null)
                {
                    //Opcion res = (from x in ((List<Opcion>)opcionBindingSource.DataSource)
                    //              where x.IdOpcion.Equals(frm.opcion.IdOpcion)
                    //              select x).FirstOrDefault();

                    //if (res == null)
                    //{ 
                    //    ((Rol)rolBindingSource.Current).OpcionesRol.Add(frm.opcion);
                    //    rolBindingSource.ResetBindings(false);
                    //}
                    //else 
                    //{
                    //    Global.MensajeComunicacion("Esta opcion ya esta asignada");
                    //    return;
                    //}

                    opcionBindingSource.DataSource = rol.OpcionesRol = frm.rol.OpcionesRol;
                    opcionBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                opcionBindingSource.RemoveCurrent();
                rolBindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void rolBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (rolBindingSource.Count > 0)
                {
                    //    Rol rol = (from x in listaroles
                    //               where x.IdRol.Equals(((Rol)rolBindingSource.Current).IdRol)
                    //               select x).FirstOrDefault();

                    opcionBindingSource.DataSource = ((Rol)rolBindingSource.Current).OpcionesRol;
                    opcionBindingSource.ResetBindings(false);

                    dgvOpcion.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvOpcion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (opcionBindingSource.Count > Variables.Cero)
            {
                Editar();
            }
        }

        #endregion
    }
}
