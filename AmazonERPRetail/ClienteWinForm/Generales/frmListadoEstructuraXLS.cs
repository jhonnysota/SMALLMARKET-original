using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Infraestructura;

namespace ClienteWinForm.Generales
{
    public partial class frmListadoEstructuraXLS : FrmMantenimientoBase
    {

        public frmListadoEstructuraXLS()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvTipo, true);
            FormatoGrid(dgvDetalle, true);
            
        }

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<EstructuraXLSE> oListaEstructuras = null;

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmEstructuraXLS);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                List<EstructuraXLSE> oListaRevision = new List<EstructuraXLSE>();
                EstructuraXLSE ItemEstruc = null;

                foreach (EstructuraXLSE item in oListaEstructuras)
                {
                    ItemEstruc = new EstructuraXLSE()
                    {
                        NombreCampo = item.NombreCampo
                    };

                    oListaRevision.Add(ItemEstruc);
                }

                oFrm = new frmEstructuraXLS(oListaRevision);
                oFrm.MdiParent = MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Editar()
        {
            try
            {
                if (bsEstructura.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmEstructuraXLS);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        //si la instancia existe la pongo en primer plano
                        oFrm.BringToFront();
                        return;
                    }

                    //sino existe la instancia se crea una nueva
                    oFrm = new frmEstructuraXLS((EstructuraXLSE)bsEstructura.Current);
                    oFrm.MdiParent = MdiParent;
                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Buscar()
        {
            try
            {
                oListaEstructuras = AgenteGeneral.Proxy.ListarEstructuraXLS(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                if (oListaEstructuras.Count > 0)
                {
                    var Lista1 = oListaEstructuras.GroupBy(x => x.Tipo).Select(p => p.First()).ToList();
                    bsTipo.DataSource = Lista1.ToList();
                    bsTipo.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmEstructuraXLS oFrm = sender as frmEstructuraXLS;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion Eventos de Usuario

        #region Eventos

        private void frmListadoEstructuraXLS_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            //BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
            //BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
            //BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
            //BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            //BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            Buscar();
        }

        private void bsTipo_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (oListaEstructuras.Count > 0)
                {
                    List<EstructuraXLSE> Lista2 = new List<EstructuraXLSE>(from x in oListaEstructuras
                                                                           where x.Tipo == ((EstructuraXLSE)bsTipo.Current).Tipo
                                                                           select x).ToList();
                    bsEstructura.DataSource = Lista2;
                    bsEstructura.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        } 

        #endregion

    }
}
