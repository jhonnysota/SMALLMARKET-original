using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Entidades.Ventas;
using Infraestructura;

namespace ClienteWinForm.Ventas
{
    public partial class frmDocRelacionados : Form
    {

        public frmDocRelacionados(List<CanjeGuiasE> ListaCanjes)
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            oListaCanjeGuias = ListaCanjes;
        }

        List<CanjeGuiasE> oListaCanjeGuias = null;

        private void frmDocRelacionados_Load(object sender, EventArgs e)
        {
            if (oListaCanjeGuias != null && oListaCanjeGuias.Count > 0)
            {
                foreach (CanjeGuiasE item in oListaCanjeGuias)
                {
                    if (item.idDocumentoGuia == "ST")
                    {
                        lbDocumentos.Items.Add("SOL " + item.numSerieGuia + " - " + item.numDocumentoGuia);
                    }
                    else
                    {
                        lbDocumentos.Items.Add("GUIA " + item.numSerieGuia + " - " + item.numDocumentoGuia);
                    }
                }
            }
        }

    }
}
