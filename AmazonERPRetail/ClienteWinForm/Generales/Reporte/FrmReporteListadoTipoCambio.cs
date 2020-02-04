using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Infraestructura;
using Infraestructura.Enumerados;
//using Microsoft.Reporting.WinForms;

namespace ClienteWinForm.Generales.Reporte
{
    public partial class FrmReporteListadoTipoCambio : FrmMantenimientoBase
    {

        #region CONSTRUCTOR
        public FrmReporteListadoTipoCambio()
        {
            InitializeComponent();
        }
        #endregion

        #region VARIABLE
        //NO HAY
        #endregion

        #region AGENTE
        //NO HAY
        #endregion

        #region EVENTOS

        private void FrmReporteListadoTipoCambio_Load(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            //this.rptReporte.RefreshReport();
            dtpDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        public void Reporte()
        {
            //List<ReportParameter> lista = new List<ReportParameter>();
            //lista.Add(new ReportParameter("FechaInicio", dtpDesde.Value.ToString("yyyy-MM-dd")));
            //lista.Add(new ReportParameter("FechaFin", dtpHasta.Value.ToString("yyyy-MM-dd")));

            //VariablesLocales.RenderizarReporte(rptReporte, "RptListadoTipoCambio", lista);
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value > dtpHasta.Value)
            {
                //Global.MensajeComunicacion("La fecha Hasta NO puede ser menor a la fecha desde");
                //rptReporte.Clear();
                return;
            }

            Reporte();
        }

        #endregion



    }
}
