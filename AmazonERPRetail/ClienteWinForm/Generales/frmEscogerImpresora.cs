using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Generales
{
    public partial class frmEscogerImpresora : Form
    {

        #region Constructores

        public frmEscogerImpresora()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
        }

        public frmEscogerImpresora(String Dato)
            :this()
        {
            VieneDe = Dato;
        } 

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        public UsuarioImpresorasE oImpresora = null;
        String VieneDe = String.Empty;

        #endregion

        //void VerificaConexion(string Impresora)
        //{
        //    try
        //    {
        //        string query = string.Format("SELECT * from Win32_Printer WHERE Name LIKE '%{0}'", Impresora);

        //        //ManagementScope scope = new ManagementScope("\\root\\cimv2");
        //        //scope.Connect();

        //        ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

        //        //ManagementObject printer;// As ManagementObject

        //        foreach (ManagementObject printer in searcher.Get())
        //        {
        //            if (printer.GetPropertyValue("Status").ToString() == "Off-line")
        //            {
        //                MessageBox.Show("La impresora no está conectada " + printer.ToString().ToLower());
        //            }
        //            else
        //            {
        //                MessageBox.Show(printer["PrinterStatus"].ToString());//"La impresora está conectada " + printer.ToString().ToLower());
        //                MessageBox.Show(printer.GetPropertyValue("Status").ToString());
        //            }
        //            //foreach (PropertyData property in printer.Properties)
        //            //{
        //            //    MessageBox.Show(string.Format("{0}: {1}", property.Name, property.Value));
        //            //}
        //        }
        //    }
        //    catch (ManagementException e)
        //    {
        //        MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
        //    }
        //}

        #region Eventos

        private void frmEscogerImpresora_Load(object sender, EventArgs e)
        {
            List<UsuarioImpresorasE> oListaImpresoras = null;

            if (VieneDe == "Barras")
            {
                List<UsuarioImpresorasE> oListaImpresorasTmp = AgenteGeneral.Proxy.ListarUsuarioImpresorasBarras(VariablesLocales.SesionUsuario.IdPersona);
                oListaImpresoras = new List<UsuarioImpresorasE>();

                foreach (UsuarioImpresorasE item in oListaImpresorasTmp)
                {
                    if (item.cantEtiqueta > 0)
                    {
                        item.NombreImpresora = item.Descripcion + " x " + item.cantEtiqueta.ToString() + " Etiquetas";
                        oListaImpresoras.Add(item);
                    }
                }

                ComboHelper.LlenarCombos<UsuarioImpresorasE>(cboImpresoras, (from x in oListaImpresoras orderby x.idImpresora select x).ToList(), "idImpresora", "NombreImpresora");

                if (oListaImpresoras.Count == 0)
                {
                    Global.MensajeAdvertencia("No hay ninguna impresora para código de barras.");
                    btAceptar.Enabled = false;
                }
            }
            else
            {
                oListaImpresoras = AgenteGeneral.Proxy.ListarUsuarioImpresoras(VariablesLocales.SesionUsuario.IdPersona);
                ComboHelper.LlenarCombos<UsuarioImpresorasE>(cboImpresoras, (from x in oListaImpresoras orderby x.idImpresora select x).ToList(), "idImpresora", "Descripcion");
            }

            UsuarioImpresorasE printer = oListaImpresoras.Find
            (
                delegate (UsuarioImpresorasE ui) { return ui.PorDefecto == true; }
            );

            if (printer != null)
            {
                cboImpresoras.SelectedValue = Convert.ToInt32(printer.idImpresora);
            }

            btAceptar.Focus();
        }

        private void cboImpresoras_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //VerificaConexion(((UsuarioImpresorasE)cboImpresoras.SelectedItem).Descripcion);
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (cboImpresoras.SelectedItem != null)
            {
                oImpresora = (UsuarioImpresorasE)cboImpresoras.SelectedItem;

                if (VieneDe == "Barras")
                {
                    if (oImpresora.AnchoEtiqueta == 0)
                    {
                        Global.MensajeAdvertencia("La impresora con la etiqueta no tiene el Ancho de la Etiqueta.");
                        return;
                    }

                    if (oImpresora.AltoEtiqueta == 0)
                    {
                        Global.MensajeAdvertencia("La impresora con la etiqueta no tiene el Alto de la Etiqueta.");
                        return;
                    }

                    if (oImpresora.cantEtiqueta == 0)
                    {
                        Global.MensajeAdvertencia("La impresora con la etiqueta no tiene cantidad de Etiqueta.");
                        return;
                    }

                    if (oImpresora.Gap == 0)
                    {
                        Global.MensajeAdvertencia("La impresora con la etiqueta no tiene el Espacio entre Etiquetas.");
                        return;
                    } 
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            oImpresora = null;
            DialogResult = DialogResult.Cancel;
            Close();
        } 

        #endregion

    }
}
