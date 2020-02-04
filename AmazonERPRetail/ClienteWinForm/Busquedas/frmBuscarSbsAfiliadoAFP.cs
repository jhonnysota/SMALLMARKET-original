using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Infraestructura;
using AFPLibreria;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarSbsAfiliadoAFP : FrmMantenimientoBase
    {

        #region Constructores

        public frmBuscarSbsAfiliadoAFP()
        {
            InitializeComponent();
        }

        public frmBuscarSbsAfiliadoAFP(string _TipoDocumento, string _Dni)
            : this()
        {
            TipoDocumento = _TipoDocumento;
            Dni = _Dni;
            txtNroDocumento.Text = Dni;
        } 

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }

        String TipoDocumento = "";
        String Dni= "";
        public Int32 idParTabla = 0;
        public string CusPP = "";

        #endregion

        #region Procedimientos de Usuario

        void RecuperarCaptcha()
        {
            var request = WebRequest.Create(ConfigurationManager.AppSettings["urlCaptcha"]);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                pbCaptcha.Image = Bitmap.FromStream(stream);
            }
        }

        void pAceptar()
        {
            if (!String.IsNullOrWhiteSpace(lblNombre.Text) || lblNombre.Text != "...")
            {
                DialogResult = DialogResult.OK;
                Dispose();
            }
            else
            {
                MessageBox.Show("No hay datos presione Cancelar por favor.");
                btCancelar.Focus();
            }
        }

        void pCancelar()
        {
            DialogResult = DialogResult.Cancel;
            Dispose();
        }

        #endregion

        #region Eventos

        private void frmBuscarSbsAfiliadoAFP_Load(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            RecuperarCaptcha();
            txtCaptcha.Focus();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            AFPUtil afpUtil = new AFPUtil();

            try
            {
                Dni = txtNroDocumento.Text;

                if (Dni.Length != 8)
                {
                    MessageBox.Show("La cantidad de digitos de un DNI de ser 8 digitos.");
                    txtNroDocumento.Focus();
                    return;
                }

                if (String.IsNullOrWhiteSpace(txtCaptcha.Text))
                {
                    MessageBox.Show("Debe ingresar cualquier caracter antes enviar datos.");
                    txtCaptcha.Focus();
                    return;
                }

                if (!String.IsNullOrWhiteSpace(Dni))
                {
                    string respuesta = afpUtil.SBSAFPConectar(TipoDocumento, Dni, txtCaptcha.Text);
                    string respuestaTemp = "";
                    string nombre = "";
                    string codigoSPP = "";
                    string tipoComision = "";
                    string Afp = "";
                    string NombreParTabla = "";

                    int posF = 0;

                    Int32 PosicionInicial = respuesta.IndexOf("cuyo nombre completo es el siguiente:");

                    if (PosicionInicial > 0)
                    {
                        //Obteniendo Nombre Completo:
                        respuestaTemp = respuesta;
                        respuestaTemp = respuestaTemp.Substring(respuestaTemp.IndexOf("cuyo nombre completo es el siguiente:"));
                        nombre = respuestaTemp.Substring(respuestaTemp.IndexOf("align=\"center\">") + 15);
                        posF = nombre.IndexOf("</td>");
                        nombre = nombre.Substring(0, posF).Trim().Replace("\n", "").Replace("\r", "").Replace("\t", "");

                        //Obteniendo Cod Identificacion 
                        respuestaTemp = respuesta;
                        respuestaTemp = respuestaTemp.Substring(respuestaTemp.IndexOf("del SPP es"));
                        codigoSPP = respuestaTemp.Substring(respuestaTemp.IndexOf("APLI_txtActualizado_Rep\" >") + 26);
                        posF = codigoSPP.IndexOf("</td>");
                        codigoSPP = codigoSPP.Substring(0, posF);
                        CusPP = codigoSPP;

                        //Obteniendo Tipo Comision 
                        respuestaTemp = respuesta;
                        respuestaTemp = respuestaTemp.Substring(respuestaTemp.IndexOf("Su Tipo de Comisi"));
                        tipoComision = respuestaTemp.Substring(respuestaTemp.IndexOf("APLI_txtActualizado_Rep\" >") + 26);
                        posF = tipoComision.IndexOf("</td>");
                        tipoComision = tipoComision.Substring(0, posF);

                        //Obteniendo Afp
                        respuestaTemp = respuesta;
                        respuestaTemp = respuestaTemp.Substring(respuestaTemp.IndexOf("Actualmente se encuentra afiliado(a) a"));
                        Int32 Posicion = respuestaTemp.IndexOf("padding-right:10px");
                        Afp = respuestaTemp.Substring(Posicion + 20);
                        posF = Afp.IndexOf("</td>");
                        Afp = Afp.Substring(0, posF);

                        String Nemo = "";
                        idParTabla = 0;

                        if (tipoComision.IndexOf("Mixta") > 0)
                        {
                            Nemo = "SPP" + Afp.ToUpper() + "M";
                        }
                        else
                        {
                            Nemo = "SPP" + Afp.ToUpper();
                        }

                        List<ParTabla> oListaRegimen = new List<ParTabla>();
                        oListaRegimen = AgenteGenerales.Proxy.ListarParTablaPorNemo("REGPEN");

                        idParTabla = (from x in oListaRegimen where x.NemoTecnico == Nemo select x.IdParTabla).FirstOrDefault();
                        NombreParTabla = (from x in oListaRegimen where x.NemoTecnico == Nemo select x.Nombre).FirstOrDefault();
                    }
                    else
                    {
                        nombre = "No Afiliado a AFP";
                        codigoSPP = "";
                        tipoComision = "";
                        Afp = "";
                        NombreParTabla = "";
                    }

                    StringBuilder datosResponse = new StringBuilder();
                    datosResponse.AppendFormat("- Nombre  : {0} \n", Global.DejarSoloUnEspacio(nombre));
                    datosResponse.AppendFormat("- Cuspp   : {0} \n", codigoSPP);
                    datosResponse.AppendFormat("- Comision: {0} \n", tipoComision);
                    datosResponse.AppendFormat("- Afp     : {0} \n", Afp);
                    datosResponse.AppendFormat("- Afp     : {0} \n", NombreParTabla);

                    lblNombre.Text = HttpUtility.HtmlDecode(datosResponse.ToString());
                    txtCaptcha.Text = String.Empty;
                    RecuperarCaptcha();
                    txtCaptcha.Focus();
                }
                else
                {
                    MessageBox.Show("Debe ingresar un N° de DNI antes de enviar...");
                    lblNombre.Text = "...";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            pAceptar();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            pCancelar();

        } 

        #endregion

    }
}
