using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmEmpresaComprasFile : frmResponseBase
    {
        public frmEmpresaComprasFile()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvEmpresas, false);
        }

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        public List<ComprasFileE> oListaFile = null;

        private void frmEmpresaComprasFile_Load(object sender, EventArgs e)
        {
            bsBase.DataSource = AgenteContabilidad.Proxy.ComprasFileEmpresas();
            bsBase.ResetBindings(false);
        }

        private void dgvEmpresas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (bsBase.List.Count > 0)
                {
                    DataGridViewRow Fila = dgvEmpresas.CurrentRow;
                    oListaFile = AgenteContabilidad.Proxy.InsertComprasFileOtraEmpresa(((ComprasFileE)Fila.DataBoundItem).idEmpresa, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                    if (oListaFile.Count > 0)
                    {
                        base.Aceptar();
                    }
                }
            }
        }

    }
}
