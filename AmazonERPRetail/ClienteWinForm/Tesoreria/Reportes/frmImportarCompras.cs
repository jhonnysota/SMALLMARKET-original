using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClienteWinForm.Almacen.Procesos
{
    public partial class frmImportarCompras : FrmMantenimientoBase
    {

        GeneralesServiceAgent AgenteContabilidad { get { return new GeneralesServiceAgent(); } }

        public frmImportarCompras()
        {
            InitializeComponent();
        }

        private void frmProcesoCierrePreLiminar_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            AgenteContabilidad.Proxy.ImportarCompras("","","",txtfecDesde.Value, txtfecHasta.Value,0);

            Global.MensajeComunicacion("Se proceso con exito");
        }
    }
}
