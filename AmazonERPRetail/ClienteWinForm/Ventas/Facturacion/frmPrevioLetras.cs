using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using ClienteWinForm.Generales;
using ClienteWinForm.Impresion;

namespace ClienteWinForm.Ventas.Facturacion
{
    public partial class frmPrevioLetras : FrmMantenimientoBase
    {

        #region Constructores

        public frmPrevioLetras()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
        }

        public frmPrevioLetras(LetrasE oLetra)
            : this()
        {
            oLetraImpresa = oLetra;

            oEmpresaImagen = new MaestrosServiceAgent().Proxy.ObtenerEmpresaSinImagenes(3, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

            if (!Directory.Exists(RutaImagen))
            {
                Directory.CreateDirectory(RutaImagen);
            }

            if (oEmpresaImagen != null)
            {
                RutaImagen += oEmpresaImagen.Nombre + " " + VariablesLocales.SesionUsuario.Empresa.RazonSocial + oEmpresaImagen.Extension;

                if (!File.Exists(RutaImagen))
                {
                    oEmpresaImagen = new MaestrosServiceAgent().Proxy.ObtenerEmpresaConImagenes(3, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                    if (oEmpresaImagen.Imagen != null)
                    {
                        Global.EscribirImagenEnFile(oEmpresaImagen.Imagen, RutaImagen);
                    }
                    else
                    {
                        RutaImagen = String.Empty;
                    }
                }
            }
            else
            {
                RutaImagen = String.Empty;
            }

            //Cargar el Logo de la empresa...
            if (File.Exists(RutaImagen))
            {
                BackgroundImage = Image.FromFile(RutaImagen);
            }
        } 
        
        #endregion

        #region Variables

        LetrasE oLetraImpresa = null;
        String RutaImagen = @"C:\AmazonErp\Logo\";
        EmpresaImagenesE oEmpresaImagen = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarLetra()
        {
            if (oLetraImpresa != null)
            {
                lblLetra.Text = oLetraImpresa.Numero + "-" + oLetraImpresa.Corre;

                if (oLetraImpresa.ListaFacturas.Count > 1)
                {
                    lblReferencia.Text = oLetraImpresa.ListaFacturas[0].idDocumento + "/" + oLetraImpresa.ListaFacturas[0].numSerie + "-" + Global.Derecha(oLetraImpresa.ListaFacturas[0].numDocumento, 6) + "\n\r";
                    lblReferencia.Text = oLetraImpresa.ListaFacturas[1].idDocumento + "/" + oLetraImpresa.ListaFacturas[1].numSerie + "-" + Global.Derecha(oLetraImpresa.ListaFacturas[1].numDocumento, 6);
                }
                else
                {
                    lblReferencia.Text = oLetraImpresa.ListaFacturas[0].idDocumento + "/" + oLetraImpresa.ListaFacturas[0].numSerie + "-" + Global.Derecha(oLetraImpresa.ListaFacturas[0].numDocumento, 6);
                }

                String MonedaFinal = (from x in VariablesLocales.ListaMonedas where x.idMoneda == oLetraImpresa.idMoneda select x.desMoneda).SingleOrDefault();

                lblFecha.Text = oLetraImpresa.Fecha.ToString("d");
                lblLugarGiro.Text = oLetraImpresa.desPlazaGirador;
                lblFecVenc.Text = oLetraImpresa.FechaVenc.ToString("d");
                lblMontoMoneda.Text = oLetraImpresa.desMoneda + " " + oLetraImpresa.MontoOrigen.ToString("N2");
                lblMontoLetra.Text = NumeroLetras.enLetras(oLetraImpresa.MontoOrigen.ToString()) + " " + MonedaFinal.ToUpper();
                lblAceptante.Text = oLetraImpresa.GiradoA;
                lblDomicilio.Text = oLetraImpresa.Direccion;
                lblLocalidad.Text = oLetraImpresa.desPlazaGiradoA;
                lblDocIdentidad.Text = oLetraImpresa.RUC;
                lblAval.Text = oLetraImpresa.Aval;
                lblDomicilioAval.Text = oLetraImpresa.DireccionAval;
                lblDocIdenAval.Text = oLetraImpresa.DoiAval;
            }
        }

        Boolean VerificarImpresora(string Nombre)
        {
            try
            {
                Boolean Encontro = false;

                if (String.IsNullOrEmpty(Nombre))
                {
                    Global.MensajeComunicacion("El documento no tiene asignado una impresora...");
                    return false;
                }

                foreach (String NombreImpresora in PrinterSettings.InstalledPrinters)
                {
                    if (Nombre == NombreImpresora)
                    {
                        Encontro = true;
                        break;
                    }
                }

                if (!Encontro)
                {
                    Global.MensajeComunicacion("La impresora asignada a este documento no se encuentra.\n\rVerifique si se encuentra encendida.");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
                return false;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Imprimir()
        {
            try
            {
                frmEscogerImpresora oFrm = new frmEscogerImpresora();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oImpresora != null)
                {
                    String NombreImpresora = oFrm.oImpresora.Descripcion;

                    if (!VerificarImpresora(NombreImpresora))
                    {
                        return;
                    }

                    ImpresionManager.RecuperarUtilImpresion(VariablesLocales.SesionUsuario.Empresa.RUC).ImprimirLetras(oLetraImpresa, NombreImpresora);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmPrevioLetras_Load(object sender, EventArgs e)
        {
            try
            {
                LlenarLetra();
                BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        } 

        #endregion

    }
}
