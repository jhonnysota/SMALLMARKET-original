using System;
using System.Collections.Generic;

using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmDocImportadosConciliacion : FrmMantenimientoBase
    {

        public frmDocImportadosConciliacion()
        {
            InitializeComponent();
            Global.AjustarResolucion(this);
            FormatoGrid(dgvConciliados, true);
        }

        public frmDocImportadosConciliacion(List<BancosConciliarE> ListaConcialiacion)
            :this()
        {
            if (ListaConcialiacion.Count > 0)
            {
                bsConciliacion.DataSource = ListaConcialiacion;
                bsConciliacion.ResetBindings(false);
            }
            else
            {
                Global.MensajeComunicacion("No hay datos que mostrar...");
            }
        }

        private void frmDocImportadosConciliacion_Load(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
        }

    }
}
