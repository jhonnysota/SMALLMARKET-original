using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Winform;
using Presentadora.AgenteServicio;

namespace ClienteWinForm.Ventas.Comisiones
{
    public partial class frmComisionesConfiguracionResponse : frmResponseBase
    {
        String TipoReporte;
        public ComisionesConfiguracionE oEntidad;
        List<ComisionesConfiguracionE> oListaValida = new List<ComisionesConfiguracionE>();
        public String Modo;

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }

        
        public frmComisionesConfiguracionResponse()
        {
            InitializeComponent();
        }

        public frmComisionesConfiguracionResponse(String TipoReporte_, String Modo_, ComisionesConfiguracionE oEntidad_, List<ComisionesConfiguracionE> oListaValida_)
            : this()
        {
            TipoReporte = TipoReporte_;
            Modo = Modo_;
            oEntidad = oEntidad_;
            oListaValida = oListaValida_;

        }

        private void frmComisionesConfiguracionResponse_Load(object sender, EventArgs e)
        {
            pnlVendedor.Visible = false;
            pnlCategoria.Visible = false;
            pnlLinea.Visible = false;
            pnlCriterio.Visible = false;
            pnlTarifario.Visible = false;


            if (TipoReporte == "vendedor")
            {
                pnlVendedor.Visible = true;


                List<VendedoresE> oListaVendedor = AgenteMaestros.Proxy.ListarVendedores(oEntidad.idEmpresa, "", false);
                foreach (VendedoresE item in oListaVendedor)
                {
                    item.Nombres = item.Nombres + " " + item.ApePaterno + " " + item.ApeMaterno;
                }
                oListaVendedor.Add(new VendedoresE() { idPersona = 0, Nombres = Variables.Seleccione });
                ComboHelper.RellenarCombos<VendedoresE>(cboVendedor, oListaVendedor.OrderBy(x => x.idPersona).ToList(), "idPersona", "Nombres");


                cboVendedor.SelectedValue = oEntidad.idVendedor;
            }
            
            if (TipoReporte == "categoria")
            {
                pnlCategoria.Visible = true;


                List<CategoriaVendedorE> oListaCategoria = AgenteVentas.Proxy.ListarCategoriaVendedor("");
                List<CategoriaVendedorE> oLista = new List<CategoriaVendedorE>();

                String codCategoria="";
                for (int i = 0; i < oListaCategoria.Count; i++)
                {
                    if (codCategoria == "")
                    {
                        codCategoria = oListaCategoria[i].codCategoria;
                        oLista.Add(oListaCategoria[i]);
                    }

                    if (codCategoria != oListaCategoria[i].codCategoria)
                    {
                        codCategoria = oListaCategoria[i].codCategoria;
                        oLista.Add(oListaCategoria[i]);
                    }
                }

                oLista.Add(new CategoriaVendedorE() { idCategoria = 0, desCategoria = Variables.Seleccione });
                ComboHelper.RellenarCombos<CategoriaVendedorE>(cboCategoria, oLista.OrderBy(x => x.desCategoria).ToList(), "idCategoria", "desCategoria");

                cboCategoria.SelectedValue = oEntidad.idCategoria;
            }

            if (TipoReporte == "linea")
            {
                pnlLinea.Visible = true;


                List<CategoriaVendedorLineaE> oLista = AgenteVentas.Proxy.ListarCategoriaVendedorLinea(oEntidad.idEmpresa, oEntidad.idCategoria);
                oLista.Add(new CategoriaVendedorLineaE() { idLinea = "00", desLinea = Variables.Seleccione });
                ComboHelper.RellenarCombos<CategoriaVendedorLineaE>(cboLinea, oLista.OrderBy(x => x.desLinea).ToList(), "idLinea", "desLinea");

                cboLinea.SelectedValue = oEntidad.idLinea.ToString("00");

                txtMeta.Text = oEntidad.Meta.ToString();

            }
            if (TipoReporte == "criterio")
            {
                pnlCriterio.Visible = true;
                
                List<ParTabla> oLista = AgenteGeneral.Proxy.ListarParTablaPorGrupo(309000, "");
                oLista.Add(new ParTabla() { IdParTabla = 0, Descripcion = Variables.Seleccione });
                ComboHelper.RellenarCombos<ParTabla>(cboCriterio, oLista.OrderBy(x => x.Descripcion).ToList(), "IdParTabla", "Descripcion");

                
                cboCriterio.SelectedValue = oEntidad.idParTabla;
                txtComisionCriterio.Text = oEntidad.Comision.ToString();
                //oListaValidaRuc = 
                
            }
            if (TipoReporte == "tarifario")
            {
                pnlTarifario.Visible = true;

                
                txtRangoIni.Text = oEntidad.RangoIni.ToString();
                txtRangoFin.Text = oEntidad.RangoFin.ToString();

                txtFactor.Text = oEntidad.Factor.ToString();
                txtComisionTarifario.Text = oEntidad.Comision.ToString();
                
            }

            if (oEntidad.idComision != 0)
            {
                txtUsuRegistro.Text = oEntidad.UsuarioRegistra;
                txtFechaRegistro.Text = oEntidad.FechaRegistra.ToString();
                txtUsuModificacion.Text = oEntidad.UsuarioModifica;
                txtFechaModificacion.Text = oEntidad.FechaModifica.ToString();
            }
            else
            {
                txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }
        }

        public override void Aceptar()
        {
            try
            {
                if (TipoReporte == "vendedor")
                {
                    if (cboVendedor.SelectedValue.ToString() == "0")
                    {
                        Global.MensajeFault("Debe de seleccionar un Vendedor");
                        return ;
                    }

                    if ((from x in oListaValida where x.idVendedor == Convert.ToInt32(cboVendedor.SelectedValue.ToString()) select x).ToList().Count > 0)
                    {
                        Global.MensajeFault("Vendedor seleccionado ya esta agregado");
                        return;
                    }
                    

                    oEntidad.idVendedor = Convert.ToInt32( cboVendedor.SelectedValue.ToString() );
                    oEntidad.desPersona = cboVendedor.Text;

                    if (Modo == "nuevo")
                    {
                        oEntidad.UsuarioRegistra = VariablesLocales.SesionUsuario.Credencial;
                        oEntidad.FechaRegistra = VariablesLocales.FechaHoy;
                        oEntidad.UsuarioModifica = VariablesLocales.SesionUsuario.Credencial;
                        oEntidad.FechaModifica = VariablesLocales.FechaHoy;
                    }
                    else
                    {
                        oEntidad.UsuarioModifica = VariablesLocales.SesionUsuario.Credencial;
                        oEntidad.FechaModifica = VariablesLocales.FechaHoy;
                    }
                }
                if (TipoReporte == "categoria")
                {
                    if (cboCategoria.SelectedValue.ToString() == "0")
                    {
                        Global.MensajeFault("Debe de seleccionar una Categoria");
                        return;
                    }

                    List<CategoriaVendedorLineaE> oLista = AgenteVentas.Proxy.ListarCategoriaVendedorLinea(oEntidad.idEmpresa,Convert.ToInt32( cboCategoria.SelectedValue.ToString() ));
                    
                    if(oLista==null || oLista.Count==0)
                    {
                        Global.MensajeFault("La Categoria seleccionada no tiene lineas asignadas");
                        return;
                    }

                    
                    if ((from x in oListaValida where x.idCategoria == Convert.ToInt32(cboCategoria.SelectedValue.ToString()) select x).ToList().Count > 0)
                    {
                        Global.MensajeFault("Categoria seleccionado ya esta agregado");
                        return;
                    }
                    

                    oEntidad.idCategoria = Convert.ToInt32(cboCategoria.SelectedValue.ToString());
                    oEntidad.desCategoria = cboCategoria.Text;

                    if (Modo == "nuevo")
                    {
                        oEntidad.UsuarioRegistra = VariablesLocales.SesionUsuario.Credencial;
                        oEntidad.FechaRegistra = VariablesLocales.FechaHoy;
                        oEntidad.UsuarioModifica = VariablesLocales.SesionUsuario.Credencial;
                        oEntidad.FechaModifica = VariablesLocales.FechaHoy;
                    }
                    else
                    {
                        oEntidad.UsuarioModifica = VariablesLocales.SesionUsuario.Credencial;
                        oEntidad.FechaModifica = VariablesLocales.FechaHoy;
                    }
                }

                if (TipoReporte == "linea")
                {
                    if (cboLinea.SelectedValue.ToString() == "00")
                    {
                        Global.MensajeFault("Debe de seleccionar una Línea");
                        return;
                    }

                    //if ((from x in oListaValida where x.idLinea == Convert.ToInt32(cboLinea.SelectedValue.ToString()) select x).ToList().Count > 0)
                    //{
                    //    Global.MensajeFault("Línea seleccionado ya esta agregado");
                    //    return;
                    //}
                    
                    oEntidad.idLinea = Convert.ToInt32(cboLinea.SelectedValue.ToString());
                    oEntidad.desLinea = cboLinea.Text;

                    oEntidad.Meta =Convert.ToDecimal( txtMeta.Text );
                    

                    if (oEntidad.idComisionLinea==0)
                    {
                        oEntidad.UsuarioRegistra = VariablesLocales.SesionUsuario.Credencial;
                        oEntidad.FechaRegistra = VariablesLocales.FechaHoy;
                        oEntidad.UsuarioModifica = VariablesLocales.SesionUsuario.Credencial;
                        oEntidad.FechaModifica = VariablesLocales.FechaHoy;
                    }
                    else
                    {
                        oEntidad.UsuarioModifica = VariablesLocales.SesionUsuario.Credencial;
                        oEntidad.FechaModifica = VariablesLocales.FechaHoy;
                    }
                }

                if (TipoReporte == "criterio")
                {
                    if (cboCriterio.SelectedValue.ToString() == "0")
                    {
                        Global.MensajeFault("Debe de seleccionar un Criterio");
                        return;
                    }

                    //if (Modo == "nuevo")
                    //{
                    //    if ((from x in oListaValida where x.idParTabla == Convert.ToInt32(cboCriterio.SelectedValue.ToString()) select x).ToList().Count > 0)
                    //    {
                    //        Global.MensajeFault("Elemento seleccionado ya esta agregado");
                    //        return;
                    //    }
                    //}

                    oEntidad.idParTabla = Convert.ToInt32(cboCriterio.SelectedValue.ToString());
                    oEntidad.desParTabla = cboCriterio.Text;
                    oEntidad.Comision =Convert.ToDecimal( txtComisionCriterio.Text.ToString() );

                    if (oEntidad.idComisionTarifario==0)
                    {
                        oEntidad.UsuarioRegistra = VariablesLocales.SesionUsuario.Credencial;
                        oEntidad.FechaRegistra = VariablesLocales.FechaHoy;
                        oEntidad.UsuarioModifica = VariablesLocales.SesionUsuario.Credencial;
                        oEntidad.FechaModifica = VariablesLocales.FechaHoy;
                    }
                    else
                    {
                        oEntidad.UsuarioModifica = VariablesLocales.SesionUsuario.Credencial;
                        oEntidad.FechaModifica = VariablesLocales.FechaHoy;
                    }
                }

                if (TipoReporte == "tarifario")
                {                    
                    oEntidad.RangoIni = Convert.ToDecimal(txtRangoIni.Text.ToString());
                    oEntidad.RangoFin = Convert.ToDecimal(txtRangoFin.Text.ToString());
                    oEntidad.Factor = Convert.ToDecimal(txtFactor.Text.ToString());
                    oEntidad.Comision = Convert.ToDecimal(txtComisionTarifario.Text.ToString());

                    if (Modo == "nuevo")
                    {
                        if ((from x in oListaValida where x.RangoIni == oEntidad.RangoIni && x.RangoFin == oEntidad.RangoFin select x).ToList().Count > 0)
                        {
                            Global.MensajeFault("Tarifario seleccionado ya esta agregado");
                            return;
                        }
                    }

                    if (Modo == "nuevo")
                    {
                        oEntidad.UsuarioRegistra = VariablesLocales.SesionUsuario.Credencial;
                        oEntidad.FechaRegistra = VariablesLocales.FechaHoy;
                        oEntidad.UsuarioModifica = VariablesLocales.SesionUsuario.Credencial;
                        oEntidad.FechaModifica = VariablesLocales.FechaHoy;
                    }
                    else
                    {
                        oEntidad.UsuarioModifica = VariablesLocales.SesionUsuario.Credencial;
                        oEntidad.FechaModifica = VariablesLocales.FechaHoy;
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }
    }
}
