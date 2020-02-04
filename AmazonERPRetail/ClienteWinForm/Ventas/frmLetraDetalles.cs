using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Entidades.Ventas;
using Entidades.CtasPorCobrar;

namespace ClienteWinForm.Ventas
{
    public partial class frmLetraDetalles : frmResponseBase
    {

        #region Constructores

        public frmLetraDetalles()
        {
            InitializeComponent();
            FormatoGrid(dgvLetras, false);
        }

        public frmLetraDetalles(List<LetrasEstadoE> Estados)
            : this()
        {
            lblTituloPrincipal.Text = "Estados de Letras";
            ListaEstados = Estados;
        }

        public frmLetraDetalles(List<CobranzasItemDetE> Cobranzas)
            :this()
        {
            lblTituloPrincipal.Text = "Cobranzas";
            ListaCobranzas = Cobranzas;
        }

        #endregion

        #region Variables

        List<LetrasEstadoE> ListaEstados = null;
        List<CobranzasItemDetE> ListaCobranzas = null;

        #endregion

        #region Procedimientos de Usuario

        void FormatoEstados()
        {
            dgvLetras.Columns["tipCanje"].HeaderText = "Tip.Canje";
            dgvLetras.Columns["codCanje"].HeaderText = "Cód.Canje";
            dgvLetras.Columns["desEstado"].HeaderText = "Estado";
            dgvLetras.Columns["RazonSocial"].HeaderText = "Banco";
            dgvLetras.Columns["numUnico"].HeaderText = "N° Unico";

            dgvLetras.AutoResizeColumns();
        }

        void FormatoCobranzas()
        {
            dgvLetras.Columns["codPlanilla"].HeaderText = "Cód.Planilla";
            dgvLetras.Columns["NroOperacion"].HeaderText = "N° Operación";
            dgvLetras.Columns["Moneda"].HeaderText = "Mon.";
            dgvLetras.Columns["Monto"].HeaderText = "Importe";
            dgvLetras.Columns["MonedaReci"].HeaderText = "Mon.Rec.";
            dgvLetras.Columns["MontoReci"].HeaderText = "Importe Rec.";

            dgvLetras.AutoResizeColumns();
        }

        #endregion

        #region Eventos

        private void frmLetraDetalles_Load(object sender, EventArgs e)
        {
            if (ListaEstados != null)
            {
                var ListaEstadoTmp = (from x in ListaEstados
                                      select new { x.tipCanje, x.codCanje, Letra = x.Numero + x.Corre, x.Fecha, x.desEstado, x.RazonSocial, x.numUnico });

                dgvLetras.DataSource = ListaEstadoTmp.ToList();
                FormatoEstados();
            }

            if (ListaCobranzas != null)
            {
                var ListaEstadoTmp = (from x in ListaCobranzas
                                      select new { x.codPlanilla, x.NroOperacion, Letra = x.idDocumento + x.numDocumento, x.Moneda, x.Monto, x.MonedaReci, x.MontoReci });

                dgvLetras.DataSource = ListaEstadoTmp.ToList();
                FormatoCobranzas();
            }
        } 

        #endregion

    }
}
