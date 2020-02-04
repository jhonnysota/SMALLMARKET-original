using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Maestros;
using ClienteWinForm.Busquedas;
using Infraestructura;

namespace ClienteWinForm.Maestros
{
    public partial class FrmArticulosKit : frmResponseBase
    {

        public FrmArticulosKit()
        {
            InitializeComponent();
            FormatoGrid(dgvArticuloServ, true);
        }

        public FrmArticulosKit(ArticuloServE articuloServ)
            :this()
        {
            TxtCodigo.Tag = Convert.ToInt32(articuloServ.idArticulo);
            TxtCodigo.Text = articuloServ.codArticulo;
            TxtDescripcion.Text = articuloServ.nomArticulo;

            List<ArticuloKitE> Articulos = new MaestrosServiceAgent().Proxy.ListarArticuloKit(articuloServ.idArticulo);
            bsBase.DataSource = Articulos;
        }

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        private void FrmArticulosKit_Load(object sender, EventArgs e)
        {

        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            
        }

        private void btNuevoItem_Click(object sender, EventArgs e)
        {
            try
            {
                decimal.TryParse(Txtcantidad.Text, out decimal Cant);

                if (Cant > 0)
                {
                    AlmacenE almacen = new AlmacenServiceAgent().Proxy.ObtenerAlmacen(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 1);

                    if (almacen != null)
                    {
                        frmBuscarArticulo oFrm = new frmBuscarArticulo(almacen, "ArtAlmacen", "", "");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Articulo != null)
                        {
                            ArticuloKitE articulo = new ArticuloKitE()
                            {
                                idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                idArticulo = Convert.ToInt32(TxtCodigo.Tag),
                                idArticuloComponente = oFrm.Articulo.idArticulo,
                                CodArticulo = oFrm.Articulo.codArticulo,
                                NombreArticulo = oFrm.Articulo.nomArticulo,
                                Cantidad = Cant,
                                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                                FechaRegistro = VariablesLocales.FechaHoy,
                                UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                                FechaModificacion = VariablesLocales.FechaHoy,
                            };

                            AgenteMaestro.Proxy.InsertarArticuloKit(articulo);
                            bsBase.Add(articulo);
                            bsBase.ResetBindings(false);
                            Txtcantidad.Text = "0.00";
                        }
                    }
                }
                else
                {
                    Global.MensajeAdvertencia("Tiene que agregar la cantidad antes de agregar un nuevo elemento.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btEliminarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsBase.Current != null)
                {
                    int resp = AgenteMaestro.Proxy.EliminarArticuloKit(((ArticuloKitE)bsBase.Current).idEmpresa, ((ArticuloKitE)bsBase.Current).idArticulo, ((ArticuloKitE)bsBase.Current).idArticuloComponente);

                    if (resp > 0)
                    {
                        bsBase.RemoveCurrent();
                        bsBase.ResetBindings(false);
                        Global.MensajeComunicacion("Articulo elimnado");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void Txtcantidad_Leave(object sender, EventArgs e)
        {
            Txtcantidad.Text = Global.FormatoDecimal(Txtcantidad.Text, 2);
        }

    }
}
