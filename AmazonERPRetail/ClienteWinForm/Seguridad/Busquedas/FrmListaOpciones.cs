using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades.Seguridad;
using Presentadora.AgenteServicio;
using Infraestructura;

namespace ClienteWinForm.Seguridad.Busquedas
{
    public partial class FrmListaOpciones : Form
    {
        List<Opcion> listaopciones = null;
        public Opcion opcion = null;
        public Rol rol = null;
        bool estadoCheck = true;
        //List<RolOpcion> ListaRolOpcion = null;

        public FrmListaOpciones()
        {
            InitializeComponent();
        }

        private void FrmListaOpciones_Load(object sender, EventArgs e)
        {
            opcionDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon;
            listaopciones = new SeguridadServiceAgent().Proxy.ListarOpcion(textBox1.Text);
            opcionBindingSource.DataSource = listaopciones;

            foreach (Opcion item in listaopciones)
            {   
                    Opcion op = (from x in rol.OpcionesRol
                                                where x.IdOpcion == item.IdOpcion
                                                select x).FirstOrDefault();
                    if (op != null)
                        item.OK = true;
            }

        }

        #region Agentes

        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //this.textBox1.Text.ToUpper();
            List<Opcion> res = (from x in listaopciones
                                where x.nombreGrupo.Contains(textBox1.Text.ToUpper()) || x.Nombre.Contains(textBox1.Text.ToUpper())
                                select x).ToList();
            opcionBindingSource.DataSource = res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rol.OpcionesRol.Clear();
            //foreach (DataGridViewRow mRow in opcionDataGridView.Rows)
            //{
            //    if (Convert.ToBoolean(mRow.Cells["OK"].Value))
            //    {
            //        Opcion mItem = new Opcion();
            //        mItem = AgenteSeguridad.Proxy.RecuperarOpcionPorCodigo(Convert.ToInt32(mRow.Cells["IdOpcion"].Value));
            //        rol.OpcionesRol.Add(mItem);
            //    }
            //}

            foreach (Opcion item in listaopciones)
            {
                if (item.OK == true)
                {
                    Opcion mItem = new Opcion();
                    mItem = AgenteSeguridad.Proxy.RecuperarOpcionPorCodigo(item.IdOpcion);
                    rol.OpcionesRol.Add(mItem);
                }
            }

            //opcion = (Opcion)opcionBindingSource.Current;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void ChkMarcarTodosItems_CheckedChanged(object sender, EventArgs e)
        {
            if(estadoCheck==true)
            {
                Opcion vOpcion =(Opcion)opcionBindingSource.Current;
                //int cant = 0;
                if (vOpcion != null)
                {
                    if (ChkMarcarTodosItems.Checked == true)
                    {
                        foreach (Opcion item in listaopciones)
                        {
                            item.OK = true;
                           // cant += 1;
                        }
                    }
                    else
                    {
                        //cant = 0;
                        foreach (Opcion item in listaopciones)
                        {
                            item.OK = false;
                        }
                    }
                    opcionBindingSource.DataSource = listaopciones;
                    opcionBindingSource.ResetBindings(false);
                }
            }  
        }     


    }
}
