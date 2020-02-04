using Infraestructura.Enumerados;
using System;
using System.Drawing;

namespace ClienteWinForm.Ventas.Facturacion
{
    public partial class frmPrevioDocElectronico : FrmMantenimientoBase
    {
        public frmPrevioDocElectronico(String Ruta)
        {
            InitializeComponent();

            if (!String.IsNullOrEmpty(Ruta))
            {
                wbNavegador.Navigate(Ruta);
            }
        }

        private void frmPrevioDocElectronico_Load(object sender, EventArgs e)
        {
            Grid = false;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            //Nuevo ubicación del reporte y nuevo tamaño de acuerdo al tamaño del menu
            this.Location = new Point(0, 0);
            this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
        }

    }
}
