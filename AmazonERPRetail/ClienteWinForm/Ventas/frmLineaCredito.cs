using Entidades.Ventas;
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

namespace ClienteWinForm.Ventas
{
    public partial class frmLineaCredito : FrmMantenimientoBase
    {
        public frmLineaCredito()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        public frmLineaCredito(Int32 _idPersona, Int32 _idEmpresa,Int32 _item)
            : this()
        {
            oLinea = AgenteVentas.Proxy.ObtenerLineaCredito(_idPersona, _idEmpresa, _item);
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        LineaCreditoE oLinea = null;
        //Int32 opcion;

        #endregion
    }
}
