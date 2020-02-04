using Entidades.Contabilidad;
using Infraestructura.Enumerados;
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
    public partial class frmDescripcionComprobantesFile : FrmMantenimientoBase
    {
        public frmDescripcionComprobantesFile()
        {
            InitializeComponent();
        }

        public frmDescripcionComprobantesFile(ComprobantesFileE Detalle_)
            : this()
        {
            Detalle = Detalle_;
            txtDescripcion.Text = Detalle.DesLarga;
        }


        public ComprobantesFileE Detalle;


        private void frmDescripcionComprobantesFile_Load(object sender, EventArgs e)
        {
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Detalle.DesLarga = txtDescripcion.Text;

            if (Detalle.Opcion == 0)
            {
                Detalle.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            this.Close();
        }
    }
}
