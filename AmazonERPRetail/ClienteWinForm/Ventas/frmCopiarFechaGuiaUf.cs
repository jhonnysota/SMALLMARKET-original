using ClienteWinForm.Busquedas;
using Entidades.Contabilidad;
using Entidades.Generales;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmCopiarFechaGuiaUf : frmResponseBase
    {
        public frmCopiarFechaGuiaUf()
        {
            InitializeComponent();
        }

        public frmCopiarFechaGuiaUf(EmisionDocumentoE Emision_)
            : this()
        {
            Emision = Emision_;
        }

        public EmisionDocumentoE Emision = new EmisionDocumentoE();

        public override bool ValidarGrabacion()
        {          

            return base.ValidarGrabacion();
        }

        public override void Aceptar()
        {
            try
            {
                if (ValidarGrabacion())
                {

                    Emision.fecDespacho = dtpDespacho.Value;                   

                    base.Aceptar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void frmCancelacionVoucherCompras_Load(object sender, EventArgs e)
        {
        }

    }
}
