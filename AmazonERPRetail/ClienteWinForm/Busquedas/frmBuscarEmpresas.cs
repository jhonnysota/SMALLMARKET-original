using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Entidades.CtasPorCobrar;
using Entidades.Almacen;
using Infraestructura;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarEmpresas : frmResponseBase
    {

        #region Constructores

        public frmBuscarEmpresas()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvEmpresas, false);
        }

        public frmBuscarEmpresas(List<TipoIngresosE> oListaEmpresas)
            :this()
        {
            var NuevaLista = (from x in oListaEmpresas
                              select new
                              {
                                  ID = x.idEmpresa,
                                  RazonSocial = x.NombreEmpresa
                              });

            dgvEmpresas.DataSource = NuevaLista.ToList();
            dgvEmpresas.Columns[0].Width = 50;
            dgvEmpresas.Columns[1].Width = 250;
            oEmpresaTipoIngreso = new TipoIngresosE();
        }

        //Conceptos varios
        public frmBuscarEmpresas(List<ConceptosVariosE> oListaEmpresas)
            :this()
        {
            var NuevaLista = (from x in oListaEmpresas
                              select new
                              {
                                  ID = x.idEmpresa,
                                  RazonSocial = x.NombreEmpresa
                              });

            dgvEmpresas.DataSource = NuevaLista.ToList();
            dgvEmpresas.Columns[0].Width = 50;
            dgvEmpresas.Columns[1].Width = 250;
            oEmpresaConceptoVarios = new ConceptosVariosE();
        }

        public frmBuscarEmpresas(List<OperacionE> oListaEmpresas)
          : this()
        {
            var NuevaLista = (from x in oListaEmpresas
                              select new
                              {
                                  ID = x.idEmpresa,
                                  RazonSocial = x.NombreEmpresa,
                                  ContaReg = x.ContaReg
                              });

            dgvEmpresas.DataSource = NuevaLista.ToList();
            dgvEmpresas.Columns[0].Width = 50;
            dgvEmpresas.Columns[1].Width = 250;
            dgvEmpresas.Columns[2].Width = 90;
            oEmpresaOperacion = new OperacionE();
        }

        #endregion

        #region Variables

        public TipoIngresosE oEmpresaTipoIngreso = null;
        public ConceptosVariosE oEmpresaConceptoVarios = null;
        public OperacionE oEmpresaOperacion = null;

        #endregion

        #region Procedimientos Heredados

        public override void Aceptar()
        {
            try
            {
                if (dgvEmpresas.CurrentRow != null)
                {
                    if (dgvEmpresas.Rows.Count > 0)
                    {
                        if (oEmpresaTipoIngreso != null)
                        {
                            oEmpresaTipoIngreso = new TipoIngresosE()
                            {
                                idEmpresa = Convert.ToInt32(dgvEmpresas.CurrentRow.Cells["ID"].Value),
                                NombreEmpresa = Convert.ToString(dgvEmpresas.CurrentRow.Cells["RazonSocial"].Value)
                            };
                        }

                        if (oEmpresaConceptoVarios != null)
                        {
                            oEmpresaConceptoVarios = new ConceptosVariosE()
                            {
                                idEmpresa = Convert.ToInt32(dgvEmpresas.CurrentRow.Cells["ID"].Value),
                                NombreEmpresa = Convert.ToString(dgvEmpresas.CurrentRow.Cells["RazonSocial"].Value)
                            };
                        }

                        if (oEmpresaOperacion != null)
                        {
                            oEmpresaOperacion = new OperacionE()
                            {
                                idEmpresa = Convert.ToInt32(dgvEmpresas.CurrentRow.Cells["ID"].Value),
                                NombreEmpresa = Convert.ToString(dgvEmpresas.CurrentRow.Cells["RazonSocial"].Value),
                                ContaReg = Convert.ToInt32(dgvEmpresas.CurrentRow.Cells["ContaReg"].Value)
                            };
                        }

                        base.Aceptar();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmBusquedaEmpresas_Load(object sender, EventArgs e)
        {

        }

        private void dgvEmpresas_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        } 

        #endregion

    }
}
