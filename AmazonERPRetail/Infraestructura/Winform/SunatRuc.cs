using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Infraestructura.Winform
{
    public class SunatRuc
    {
        #region Constructor

        public SunatRuc()
        {
            try
            {
                myCookie = null;
                myCookie = new CookieContainer();
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                LeerCapcha();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        

        public enum Resul
        {
            Ok,
            NoResul,
            ErrorCapcha,
            Error,
            RucInvalido
        }

        #endregion

        #region Variables

        private Resul EstadoConsulta;
        private String _RazonSocial;
        private String _TipoContribuyente;
        private String _NombreComercial;
        private String _FechaInscripcion;
        private String _FechaActividades;
        private String _EstadoContribuyente;
        private String _CondicionContribuyente;
        private String _Direccion;
        private String _EmisionComprobante;
        private String _ActividadExterior;
        private String _SistemaContabilidad;
        private List<String> _ActividadEconomica;
        private List<String> _ComprobantesPago;
        private String _EmisionElectronica;
        private List<String> _ListaEmisionElectronica;
        private String _EmisorElectronico;
        private String _ComprobanteElectronico;
        private String _AfiliacionPle;
        private List<String> _Padrones;
        
        private String _Telefonos;
        private String _Dni;
        private String _Profesion;
        private String _Rus;
        private String _Web;
        private String _FecBaja;
        
        private CookieContainer myCookie;

        public Image ObtenerCapcha { get { return LeerCapcha(); } }
        public String RazonSocial { get { return this._RazonSocial; } }
        public String TipoContribuyente { get { return this._TipoContribuyente; } }
        public String NombreComercial { get { return this._NombreComercial; } }
        public String FechaInscripcion { get { return this._FechaInscripcion; } }
        public String FechaActividades { get { return this._FechaActividades; } }
        public String EstadoContribuyente { get { return this._EstadoContribuyente; } }
        public String CondicionContribuyente { get { return this._CondicionContribuyente; } }
        public String Direccion { get { return this._Direccion; } }
        public String EmisionComprobante { get { return this._EmisionComprobante; } }
        public String ActividadExterior { get { return this._ActividadExterior; } }
        public String SistemaContabilidad { get { return this._SistemaContabilidad; } }
        public List<String> ActividadEconomica { get { return this._ActividadEconomica; } }
        public List<String> ComprobantesPago { get { return this._ComprobantesPago; } }
        public String EmisionElectronica { get { return this._EmisionElectronica; } }
        public List<String> ListaEmisionElectronica { get { return _ListaEmisionElectronica; } }
        public String EmisorElectronico { get { return this._EmisorElectronico; } }
        public String ComprobanteElectronico { get { return this._ComprobanteElectronico; } }
        public String AfiliacionPle { get { return this._AfiliacionPle; } }
        public List<String> Padrones { get { return this._Padrones; } }

        public String Telefonos { get { return this._Telefonos; } }
        public String Dni { get { return this._Dni; } }
        public String Profesion { get { return this._Profesion; } }
        public String Rus { get { return _Rus; } }
        public String Web { get { return this._Web; } }
        public String FechaBaja { get { return _FecBaja; } }

        public Resul GetResul { get { return EstadoConsulta; } }

        #endregion

        #region Procedimientos Privados

        private bool ValidarCertificado(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private Image LeerCapcha()
        {
            Image result;

            try
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(this.ValidarCertificado);
                HttpWebRequest webSolicitud = (HttpWebRequest)WebRequest.Create("http://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/captcha?accion=image");
                webSolicitud.CookieContainer = myCookie;
                webSolicitud.Proxy = null;
                webSolicitud.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse webRespuesta = (HttpWebResponse)webSolicitud.GetResponse();
                Stream responseStream = webRespuesta.GetResponseStream();
                result = Image.FromStream(responseStream);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public void ObtenerInfo(String numRUC, String ImgCapcha)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(this.ValidarCertificado);
                String requestUriString = String.Format("http://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias?accion=consPorRuc&nroRuc={0}&codigo={1}&tipdoc=1", numRUC, ImgCapcha);
                
                HttpWebRequest webSolicitud = (HttpWebRequest)WebRequest.Create(requestUriString);
                webSolicitud.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135";
                webSolicitud.CookieContainer = this.myCookie;
                webSolicitud.Credentials = CredentialCache.DefaultCredentials;
                webSolicitud.Proxy = null;
                HttpWebResponse webRespuesta = (HttpWebResponse)webSolicitud.GetResponse();
                Stream responseStream = webRespuesta.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF7);
                String text = HttpUtility.HtmlDecode(streamReader.ReadToEnd());
                int length = text.Length;
                bool flag = length == 1754;
                String caracter = numRUC.Substring(0, 1); //Global.Izquierda(numRUC, 1);
                
                _Web = String.Empty;

                if (flag)
                {
                    EstadoConsulta = Resul.ErrorCapcha;
                }
                else
                {
                    flag = (length == 3207);

                    if (flag)
                    {
                        EstadoConsulta = Resul.RucInvalido;
                    }
                    else
                    {
                        flag = (length == 222);

                        if (flag)
                        {
                            EstadoConsulta = Resul.NoResul;
                        }
                        else
                        {
                            flag = (text.Length >= 15000);

                            if (flag)
                            {
                                EstadoConsulta = Resul.Ok;
                            }
                            else
                            {
                                EstadoConsulta = Resul.Error;
                            }
                        }
                    }
                }

                flag = (EstadoConsulta == Resul.Ok);
                
                if (flag)
                {
                    String Estado = String.Empty;
                    Int32 IndBuscarCondicion = 0;
                    Int32 IndBuscarSisEmision = 0;
                    Int32 IndBuscarActExterior = 0;
                    Int32 IndBuscarSisContabilidad = 0;
                    //Int32 IndBuscarProfesion = 0;
                    Int32 IndBuscarActEconomica = 0;
                    Int32 IndBuscarComPago = 0;

                    Int32 IndBuscarDatoTipoEmision = 0;

                    //Int32 IndBuscarEmiElectronica = 0;
                    //Int32 IndBuscarEmisorElectronico = 0;
                    //Int32 IndBuscarComElectronico = 0;
                    //Int32 IndBuscarAfiliacionPle = 0;
                    Int32 IndBuscarPadron = 0;

                    _Web = text;
                    text = text.Replace("     ", " ");
                    text = text.Replace("    ", " ");
                    text = text.Replace("   ", " ");
                    text = text.Replace("  ", " ");
                    text = text.Replace("( ", "(");
                    text = text.Replace(" )", ")");
                    text = text.Replace("\n", "");
                    text = text.Replace("\r", "");
                    text = text.Replace("\"", "'");
                    text = text.Replace("<tr>", "");
                    text = text.Replace("</td>", "");
                    text = text.Replace("</tr>", "");

                    int num = text.IndexOf("}</script>");
                    flag = (num > 0);

                    if (flag)
                    {
                        text = text.Substring(num + 10);
                    }
                    
                    //Colocando todos los valores en un array
                    List<String> array = new List<String>(Regex.Split(text, "<td "));

                    //Razón Social
                    flag = (num = array[2].IndexOf(">")) > 0;                              
                    if (flag)
                    {
                        array[2] = array[2].Substring(num + 15); 
                    }

                    //Tipo de Contribuyente
                    flag = (num = array[4].IndexOf(">")) > 0;
                    if (flag)
                    {
                        array[4] = array[4].Substring(num + 1);
                    }


                    //Nombre Comercial (Empresas)
                    if (caracter.Equals("2") == true)
                    {
                        flag = (num = array[6].IndexOf(">")) > 0;

                        if (flag)
                        {
                            array[6] = array[6].Substring(num + 1);
                        }
                    }

                    // Direccion Fiscal de la Empresa
                    if (caracter.Equals("2") == true)
                    {
                        array[17] = array[17].Replace("class='bg' colspan=3>", ""); //dirrecion
                    }

                    //Fecha Inscripcion (Empresas)
                    if (caracter.Equals("2") == true)
                    {
                        flag = (num = array[8].IndexOf(">")) > 0;

                        if (flag)
                        {
                            array[8] = array[8].Substring(num + 1);
                        }
                    }

                    //Fecha de Inicio de Actividades(Empresas)
                    if (caracter.Equals("2") == true)
                    {
                        flag = (num = array[10].IndexOf(">")) > 0;

                        if (flag)
                        {
                            array[10] = array[10].Substring(num + 1);
                        }
                    }

                    //Estado del contribuyente (Empresas)
                    if (caracter.Equals("2") == true)
                    {
                        flag = (num = array[12].IndexOf(">")) > 0;

                        if (flag)
                        {
                            array[12] = array[12].Substring(num + 1);
                            Estado = array[12].Trim();
                        }
                    }

                    // Numeracion de Campos 
                    if (caracter.Equals("2") == true)
                    {
                        if (Estado == "ACTIVO")
                        {
                            if (array[9] == "SI")
                            {
                                IndBuscarCondicion = 15;
                                IndBuscarSisEmision = 19;
                                IndBuscarActExterior = 21;
                                IndBuscarSisContabilidad = 23;

                                //IndBuscarProfesion = 20;
                                IndBuscarActEconomica = 26;
                                IndBuscarComPago = 28;
                                //IndBuscarEmiElectronica = 36;
                                //IndBuscarEmisorElectronico = 39;
                                //IndBuscarComElectronico = 41;
                                //IndBuscarAfiliacionPle = 45;
                                IndBuscarPadron = 38;
                            }
                            else
                            {
                                IndBuscarCondicion = 15;
                                IndBuscarSisEmision = 19;
                                IndBuscarActExterior = 21;
                                IndBuscarSisContabilidad = 23;

                                //IndBuscarProfesion = 20;
                                IndBuscarActEconomica = 26;
                                IndBuscarComPago = 28;
                                //IndBuscarEmiElectronica = 36;
                                //IndBuscarEmisorElectronico = 39;
                                //IndBuscarComElectronico = 41;
                                //IndBuscarAfiliacionPle = 45;
                                IndBuscarPadron = 38;
                            }

                        }
                        else
                        {
                            IndBuscarCondicion = 15;
                            IndBuscarSisEmision = 19;
                            IndBuscarActExterior = 21;
                            IndBuscarSisContabilidad = 23;

                            //IndBuscarProfesion = 20;
                            IndBuscarActEconomica = 26;
                            IndBuscarComPago = 28;
                            //IndBuscarEmiElectronica = 36;
                            //IndBuscarEmisorElectronico = 39;
                            //IndBuscarComElectronico = 41;
                            //IndBuscarAfiliacionPle = 45;
                            IndBuscarPadron = 38;

                        }
                    }

                    // Condicion del Contribuyente (Empresas)
                    if (caracter.Equals("2") == true)
                    {
                        flag = false;

                        //Condicion
                        if ((num = array[IndBuscarCondicion].IndexOf("NO HABIDO")) > 0)
                        {
                            array[IndBuscarCondicion] = "NO HABIDO";
                            flag = true;
                        }

                        if ((num = array[IndBuscarCondicion].IndexOf("NO HALLADO")) > 0)
                        {
                            array[IndBuscarCondicion] = "NO HALLADO";
                            flag = true;
                        }

                        if ((num = array[IndBuscarCondicion].IndexOf("HABIDO")) > 0)
                        {
                            array[IndBuscarCondicion] = "HABIDO";
                            flag = true;
                        }

                        if (!flag)
                        {
                            array[IndBuscarCondicion] = " - ";
                        }
                    }

                    //Sistema de Emision de Comprobantes (Empresas)
                    if (caracter.Equals("2") == true)
                    {
                     flag = (num = array[IndBuscarSisEmision].IndexOf(">")) > 0;

                     if (flag)
                     {
                      array[IndBuscarSisEmision] = array[IndBuscarSisEmision].Substring(num + 1);
                      array[IndBuscarSisEmision] = array[IndBuscarSisEmision].Trim();
                     }
                        
                    }

                    //Actividad de Comercio Exterior (Empresas)
                    if (caracter.Equals("2") == true)
                    {
                      flag = (num = array[IndBuscarActExterior].IndexOf(">")) > 0;

                     if (flag)
                      {
                      array[IndBuscarActExterior] = array[IndBuscarActExterior].Substring(num + 1);
                      array[IndBuscarActExterior] = array[IndBuscarActExterior].Trim();
                      }
                        
                    }

                    //Sistema de Contabilidad (Empresas)
                    if (caracter.Equals("2") == true)
                    {                
                            flag = (num = array[IndBuscarSisContabilidad].IndexOf(">")) > 0;

                            if (flag)
                            {
                                array[IndBuscarSisContabilidad] = array[IndBuscarSisContabilidad].Substring(num + 1);
                                array[IndBuscarSisContabilidad] = array[IndBuscarSisContabilidad].Replace(" \t \t   ", "");
                            }

                            flag = (num = array[IndBuscarSisContabilidad].IndexOf("\t")) > 0;

                            if (flag)
                            {
                                array[IndBuscarSisContabilidad] = array[IndBuscarSisContabilidad].Substring(0, num);
                            }
                                     
                    }

                    //Actividad Economica (Empresas)
                    if (caracter.Equals("2") == true)
                    {
                        if (array[12].Trim().Equals("ACTIVO"))
                        {
                           
                         List<String> Actividades = new List<String>(Regex.Split(array[IndBuscarActEconomica], "<option value='00' >"));
                         _ActividadEconomica = new List<String>();

                           for (int i = 1; i < Actividades.Count; i++)
                           {
                           flag = (num = Actividades[i].IndexOf(" </option>")) > 0;

                             if (flag)
                             {
                              _ActividadEconomica.Add(Actividades[i].Substring(1, num - 1));
                             }
                           }
                            
                        }
                        else
                        {
                            
                         List<String> Actividades = new List<String>(Regex.Split(array[IndBuscarActEconomica], "<option value='00' >"));
                         _ActividadEconomica = new List<String>();

                           for (int i = 1; i < Actividades.Count; i++)
                           {
                            flag = (num = Actividades[i].IndexOf(" </option>")) > 0;

                              if (flag)
                              {
                              _ActividadEconomica.Add(Actividades[i].Substring(1, num - 1));
                              }
                            }   
                        }
                    }

                    //Comprobantes de Pago
                    if (caracter.Equals("2") == true)
                    {
                        if (array[12].Trim().Equals("ACTIVO"))
                        {                  
                                List<String> Comprobantes = new List<String>(Regex.Split(array[IndBuscarComPago], "<option value='00' >"));
                                _ComprobantesPago = new List<String>();

                                for (int i = 1; i < Comprobantes.Count; i++)
                                {
                                    flag = (num = Comprobantes[i].IndexOf("</option>")) > 0;

                                    if (flag)
                                    {
                                        _ComprobantesPago.Add(Comprobantes[i].Substring(1, num - 1));
                                    }
                                }   
                        }
                        else
                        {
                            
                        List<String> Comprobantes = new List<String>(Regex.Split(array[IndBuscarComPago], "<option value='00' >"));
                        _ComprobantesPago = new List<String>();

                           for (int i = 1; i < Comprobantes.Count; i++)
                           {
                           flag = (num = Comprobantes[i].IndexOf("</option>")) > 0;

                             if (flag)
                             {
                              _ComprobantesPago.Add(Comprobantes[i].Substring(1, num - 1));
                             }
                           }
                            
                        }
                    }

                    //Sistema de Emision Electrónica (Empresas)
                    if (caracter.Equals("2X") == true)
                    {
                        if (array[12].Trim().Equals("ACTIVO"))
                        {
                            flag = String.Compare(array[33].Substring(0, 29), "class='bgn' colspan=1>Sistema", false) == 0;

                            if (flag)
                            {
                                flag = (num = array[34].IndexOf("select")) > 0;

                                if (flag)
                                {
                                    List<String> ListaEmisionElec = new List<String>(Regex.Split(array[34], "<option value='00' >"));
                                    _ListaEmisionElectronica = new List<String>();

                                    for (int i = 1; i < ListaEmisionElec.Count; i++)
                                    {
                                        flag = (num = ListaEmisionElec[i].IndexOf("</option>")) > 0;

                                        if (flag)
                                        {
                                            _ListaEmisionElectronica.Add(ListaEmisionElec[i].Substring(0, num));
                                        }
                                    }
                                }
                                else
                                {
                                    num = array[34].IndexOf(">");
                                    array[33] = array[34].Substring(num + 1);
                                    flag = (num = array[33].IndexOf(" <!--")) > 0;

                                    if (flag)
                                    {
                                        array[33] = array[33].Substring(1, num - 1);
                                    }
                                    _ListaEmisionElectronica = new List<String>();
                                }
                            }
                            else
                            {
                                array[33] = array[33].Substring(num + 1);
                                flag = (num = array[33].IndexOf(" <!--")) > 0;

                                if (flag)
                                {
                                    array[33] = array[33].Substring(1, num - 1);
                                }

                                _ListaEmisionElectronica = new List<String>();
                            }
                        }
                        else
                        {
                            flag = String.Compare(array[34].Substring(0, 29), "class='bgn' colspan=1>Sistema", false) == 0;

                            if (flag)
                            {
                                flag = (num = array[35].IndexOf("select")) > 0;

                                if (flag)
                                {
                                    List<String> ListaEmisionElec = new List<String>(Regex.Split(array[35], "<option value='00' >"));
                                    _ListaEmisionElectronica = new List<String>();

                                    for (int i = 1; i < ListaEmisionElec.Count; i++)
                                    {
                                        flag = (num = ListaEmisionElec[i].IndexOf("</option>")) > 0;

                                        if (flag)
                                        {
                                            _ListaEmisionElectronica.Add(ListaEmisionElec[i].Substring(0, num));
                                        }
                                    }
                                }
                                else
                                {
                                    flag = (num = array[35].IndexOf(">")) > 0;

                                    if (flag)
                                    {
                                        array[34] = array[35].Substring(num + 1);
                                        flag = (num = array[34].IndexOf(" <!--")) > 0;

                                        if (flag)
                                        {
                                            array[34] = array[34].Substring(1, num - 1);
                                        }
                                    }

                                    _ListaEmisionElectronica = new List<String>();
                                }
                            }
                            else
                            {
                                flag = (num = array[34].IndexOf(">")) > 0;

                                if (flag)
                                {
                                    array[34] = array[34].Substring(num + 1);
                                    flag = (num = array[34].IndexOf(" <!--")) > 0;

                                    if (flag)
                                    {
                                        array[34] = array[34].Substring(1, num - 1);
                                    }
                                }

                                _ListaEmisionElectronica = new List<String>();
                            }
                        }
                    }

                    //Padrones (Empresas)
                    if (caracter.Equals("2") == true)
                    {
                        if (Estado == "ACTIVO")
                        {
                         
                         List<String> Padrones = new List<String>(Regex.Split(array[IndBuscarPadron], "<option value='00' >"));
                         _Padrones = new List<String>();

                           for (int i = 1; i < Padrones.Count; i++)
                           {
                           flag = (num = Padrones[i].IndexOf("</option>")) > 0;

                              if (flag)
                              {
                               _Padrones.Add(Padrones[i].Substring(0, num));
                              }
                           }
                          
                        }
                        else
                        {
                         List<String> Padrones = new List<String>(Regex.Split(array[IndBuscarPadron], "<option value='00' >"));
                         _Padrones = new List<String>();

                           for (int i = 1; i < Padrones.Count; i++)
                           {
                            flag = (num = Padrones[i].IndexOf("</option>")) > 0;

                              if (flag)
                              {
                              _Padrones.Add(Padrones[i].Substring(0, num));
                              }
                           }
                        }
                    }

                


                    //Tipo Documento (Personas Naturales) DNI
                    if (caracter.Equals("1") == true)
                    {
                        flag = (num = array[6].IndexOf("DNI")) > 0;

                        if (flag)
                        {
                            array[6] = array[6].Substring(num + 4, 8);
                        }
                    }

                    //Nombre Comercial(Personas Naturales)
                    if (caracter.Equals("1") == true)
                    {
                        flag = (num = array[8].IndexOf(">")) > 0;

                        if (flag)
                        {
                            array[8] = array[8].Substring(num + 1);
                        }
                    }

                    // Fecha Inscripcion (Personas Naturales) o RUS
                    if (caracter.Equals("1") == true)
                    {
                        flag = (num = array[9].IndexOf("Afecto")) > 0;

                        if (flag)
                        {
                            num = array[10].IndexOf(">");

                            array[9] = array[10].Substring(num + 1, 2);

                            flag = (num = array[12].IndexOf(">")) > 0;

                            if (flag)
                            {
                                array[10] = array[12].Substring(num + 1);
                            }
                        }
                        else
                        {
                            flag = (num = array[10].IndexOf(">")) > 0;

                            if (flag)
                            {
                                array[10] = array[10].Substring(num + 1);
                            }
                        }
                    }

                    //Fecha de Inicio de Actividades (Personas Naturales)
                    if (caracter.Equals("1") == true)
                    {
                        if (array[9] == "SI")
                        {
                            flag = (num = array[14].IndexOf(">")) > 0;

                            if (flag)
                            {
                                array[12] = array[14].Substring(num + 1);
                            }
                        }
                        else
                        {
                            flag = (num = array[12].IndexOf(">")) > 0;

                            if (flag)
                            {
                                array[12] = array[12].Substring(num + 1);
                            }
                        }
                    }
                  
                    //Estado del contribuyente (Personas Naturales)
                    if (caracter.Equals("1") == true)
                    {
                        if (array[9] == "SI")
                        {
                            flag = (num = array[16].IndexOf(">")) > 0;

                            if (flag)
                            {
                                array[14] = array[16].Substring(num + 1);
                                Estado = array[14].Trim();
                            }
                        }
                        else
                        {
                            flag = (num = array[14].IndexOf(">")) > 0;

                            if (flag)
                            {
                                array[14] = array[14].Substring(num + 1);
                                Estado = array[14].Trim();
                            }
                        }                        
                    }

                    //Numeracion de Campos
                    if (caracter.Equals("1") == true)
                    {
                        if (Estado == "ACTIVO")
                        {
                            if (array[9] == "SI")
                            {
                                IndBuscarCondicion = 19;
                                IndBuscarSisEmision = 23;
                                IndBuscarActExterior = 25;
                                IndBuscarSisContabilidad = 27;
                                IndBuscarActEconomica = 32;
                                IndBuscarComPago = 34;
                                //IndBuscarEmiElectronica = 37;
                                //IndBuscarEmisorElectronico = 40;
                                //IndBuscarComElectronico = 42;
                                //IndBuscarAfiliacionPle = 46;
                                IndBuscarPadron = 44;
                            }
                            else
                            {
                                IndBuscarCondicion = 19 - 2;
                                IndBuscarSisEmision = 25 - 4;
                                IndBuscarActExterior = 27 - 4;
                                IndBuscarSisContabilidad = 29 - 4;
                                IndBuscarActEconomica = 32 - 4;
                                IndBuscarComPago = 34 - 4;
                                //IndBuscarEmiElectronica = 37 - 2;
                                //IndBuscarEmisorElectronico = 40 - 2;
                                //IndBuscarComElectronico = 42 - 2;
                                //IndBuscarAfiliacionPle = 46 - 2;
                                IndBuscarPadron = 44 - 2;
                            }

                        }
                        else
                        {
                            IndBuscarCondicion = 18;
                            IndBuscarSisEmision = 24;
                            IndBuscarActExterior = 26;
                            IndBuscarSisContabilidad = 28;
                            IndBuscarActEconomica = 31;
                            IndBuscarComPago = 33;
                            //IndBuscarEmiElectronica = 36;
                            //IndBuscarEmisorElectronico = 39;
                            //IndBuscarComElectronico = 41;
                            //IndBuscarAfiliacionPle = 45;
                            IndBuscarPadron = 43;

                        }
                    }

                    // Condicion del Contribuyente (Personas Naturales)
                    if (caracter.Equals("1") == true)
                    {
                        flag = false;

                        //Condicion
                        if ((num = array[IndBuscarCondicion].IndexOf("NO HABIDO")) > 0)
                        {
                            array[IndBuscarCondicion] = "NO HABIDO";
                            flag = true;
                        }
                        else
                        if ((num = array[IndBuscarCondicion].IndexOf("NO HALLADO")) > 0)
                        {
                            array[IndBuscarCondicion] = "NO HALLADO";
                            flag = true;
                        }
                        else
                        if ((num = array[IndBuscarCondicion].IndexOf("HABIDO")) > 0)
                        {
                            array[IndBuscarCondicion] = "HABIDO";
                            flag = true;
                        }
                        else
                        if (!flag)
                        {
                            array[IndBuscarCondicion] = " - ";
                        }

                    }

                    // Sistema de Emision de Comprobantes (Persona Natural)
                    if (caracter.Equals("1") == true)
                    {
                       
                        flag = (num = array[IndBuscarSisEmision].IndexOf(">")) > 0;

                        if (flag)
                        {
                            array[IndBuscarSisEmision] = array[IndBuscarSisEmision].Substring(num + 1);
                            array[IndBuscarSisEmision] = array[IndBuscarSisEmision].Trim();
                        }
                    }

                    //Actividad de Comercio Exterior (Persona Natural)
                    if (caracter.Equals("1") == true)
                    {
                        flag = (num = array[IndBuscarActExterior].IndexOf(">")) > 0;

                        if (flag)
                        {
                            array[IndBuscarActExterior] = array[IndBuscarActExterior].Substring(num + 1);
                            array[IndBuscarActExterior] = array[IndBuscarActExterior].Trim();
                        }

                    }

                    //Sistema de Contabilidad (Persona Natural)
                    if (caracter.Equals("1") == true)
                    {
                        flag = (num = array[IndBuscarSisContabilidad].IndexOf(">")) > 0;

                        if (flag)
                        {
                            array[IndBuscarSisContabilidad] = array[IndBuscarSisContabilidad].Substring(num + 1);
                            array[IndBuscarSisContabilidad] = array[IndBuscarSisContabilidad].Replace(" \t \t   ", "");
                        }

                        flag = (num = array[IndBuscarSisContabilidad].IndexOf("\t")) > 0;

                        if (flag)
                        {
                            array[IndBuscarSisContabilidad] = array[IndBuscarSisContabilidad].Substring(0, num);
                        }
                    }

                    // Actividad Economica (Persona Natural)
                    if (caracter.Equals("1X") == true)
                    {
                        flag = String.Compare(array[IndBuscarActEconomica-1].Substring(0, 22), "class='bgn' colspan=1>", false) == 0;

                        if (flag)
                        {
                            flag = String.Compare(array[IndBuscarActEconomica].Substring(0, 31), "class='bgn' colspan=1>Actividad", false) == 0;

                            if (flag)
                            {
                                List<String> Actividades = new List<String>(Regex.Split(array[IndBuscarActEconomica], "<option value='00' >"));
                                _ActividadEconomica = new List<String>();

                                for (int i = 1; i < Actividades.Count; i++)
                                {
                                    flag = (num = Actividades[i].IndexOf(" </option>")) > 0;

                                    if (flag)
                                    {
                                        _ActividadEconomica.Add(Actividades[i].Substring(1, num - 1));
                                    }
                                }
                            }
                            else
                            {
                                flag = String.Compare(array[IndBuscarActEconomica-1].Substring(0, 31), "class='bgn' colspan=1>Actividad", false) == 0;

                                if (flag)
                                {
                                    List<String> Actividades = new List<String>(Regex.Split(array[IndBuscarActEconomica], "<option value='00' >"));
                                    _ActividadEconomica = new List<String>();

                                    for (int i = 1; i < Actividades.Count; i++)
                                    {
                                        flag = (num = Actividades[i].IndexOf(" </option>")) > 0;

                                        if (flag)
                                        {
                                            _ActividadEconomica.Add(Actividades[i].Substring(1, num - 1));
                                        }
                                    }
                                }
                                else
                                {
                                    List<String> Actividades = new List<String>(Regex.Split(array[IndBuscarActEconomica], "<option value='00' >"));
                                    _ActividadEconomica = new List<String>();

                                    for (int i = 1; i < Actividades.Count; i++)
                                    {
                                        flag = (num = Actividades[i].IndexOf(" </option>")) > 0;

                                        if (flag)
                                        {
                                            _ActividadEconomica.Add(Actividades[i].Substring(1, num - 1));
                                        }
                                    }
                                }                                
                            }
                        }
                        else
                        {
                            flag = String.Compare(array[IndBuscarActEconomica-1].Substring(0, 31), "class='bgn' colspan=1>Actividad", false) == 0;

                            if (flag)
                            {
                                List<String> Actividades = new List<String>(Regex.Split(array[IndBuscarActEconomica], "<option value='00' >"));
                                _ActividadEconomica = new List<String>();

                                for (int i = 1; i < Actividades.Count; i++)
                                {
                                    flag = (num = Actividades[i].IndexOf(" </option>")) > 0;

                                    if (flag)
                                    {
                                        _ActividadEconomica.Add(Actividades[i].Substring(1, num - 1));
                                    }
                                }
                            }
                            else
                            {
                                List<String> Actividades = new List<String>(Regex.Split(array[IndBuscarActEconomica], "<option value='00' >")); //modificado 07-08-15
                                _ActividadEconomica = new List<String>();

                                for (int i = 1; i < Actividades.Count; i++)
                                {
                                    flag = (num = Actividades[i].IndexOf(" </option>")) > 0;

                                    if (flag)
                                    {
                                        _ActividadEconomica.Add(Actividades[i].Substring(1, num - 1));
                                    }
                                }
                            }
                        }
                    }

                    //Comprobantes de Pago (Persona Natural)
                    if (caracter.Equals("1") == true)
                    {
                        if (Estado == "ACTIVO")
                        {
                                List<String> Comprobantes = new List<String>(Regex.Split(array[IndBuscarComPago], "<option value='00' >"));
                                _ComprobantesPago = new List<String>();

                                for (int i = 1; i < Comprobantes.Count; i++)
                                {
                                    flag = (num = Comprobantes[i].IndexOf("</option>")) > 0;

                                    if (flag)
                                    {
                                        _ComprobantesPago.Add(Comprobantes[i].Substring(1, num - 1));
                                    }
                                }                                                  
                        }
                        else
                        {                                        
                              List<String> Comprobantes = new List<String>(Regex.Split(array[IndBuscarComPago], "<option value='00' >"));
                              _ComprobantesPago = new List<String>();

                              for (int i = 1; i < Comprobantes.Count; i++)
                               {
                                flag = (num = Comprobantes[i].IndexOf("</option>")) > 0;

                                if (flag)
                                {
                                 _ComprobantesPago.Add(Comprobantes[i].Substring(1, num - 1));
                                }
                              }                             
                        }                                            
                    }

                    //Sistema de Emision Electrónica (Persona Natural)
                    if (caracter.Equals("1X") == true)
                    {
                        flag = String.Compare(array[IndBuscarDatoTipoEmision].Substring(0, 29), "class='bgn' colspan=1>Sistema", false) == 0;
                        
                        if (flag)
                        {
                            flag = (num = array[38].IndexOf("select")) > 0;

                            if (flag)
                            {
                                List<String> ListaEmisionElec = new List<String>(Regex.Split(array[38], "<option value='00' >"));
                                _ListaEmisionElectronica = new List<String>();

                                for (int i = 1; i < ListaEmisionElec.Count; i++)
                                {
                                    flag = (num = ListaEmisionElec[i].IndexOf("</option>")) > 0;

                                    if (flag)
                                    {
                                        _ListaEmisionElectronica.Add(ListaEmisionElec[i].Substring(0, num));
                                    }
                                }
                            }
                            else
                            {
                                flag = (num = array[38].IndexOf(">")) > 0;

                                if (flag)
                                {
                                    array[37] = array[38].Substring(num + 1);
                                    flag = (num = array[37].IndexOf(" <!--")) > 0;

                                    if (flag)
                                    {
                                        array[37] = array[37].Substring(1, num - 1);
                                    }
                                }

                                _ListaEmisionElectronica = new List<String>();
                            }
                        }
                        else
                        {
                            if (array[14].Trim().Equals("ACTIVO"))
                            {
                                flag = String.Compare(array[34].Substring(0, 22), "class='bgn' colspan=1>", false) == 0;

                                if (flag)
                                {
                                    flag = (num = array[35].IndexOf(">")) > 0;

                                    if (flag)
                                    {
                                        array[35] = array[35].Substring(num + 3);
                                    }

                                    flag = (num = array[35].IndexOf("<!--")) > 0;

                                    if (flag)
                                    {
                                        array[35] = array[35].Substring(0, num - 2);
                                    }
                                }
                                else
                                {
                                    flag = (num = array[36].IndexOf(">")) > 0;

                                    if (flag)
                                    {
                                        array[36] = array[36].Substring(num + 1);
                                        flag = (num = array[36].IndexOf(" <!--")) > 0;

                                        if (flag)
                                        {
                                            array[36] = array[36].Substring(1, num - 1);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                flag = String.Compare(array[38].Substring(0, 22), "class='bgn' colspan=1>", false) == 0;

                                if (flag)
                                {
                                    flag = String.Compare(array[36].Substring(0, 29), "class='bgn' colspan=1>Sistema", false) == 0;

                                    if (flag)
                                    {
                                        flag = (num = array[37].IndexOf(">")) > 0;

                                        if (flag)
                                        {
                                            array[37] = array[37].Substring(num + 3);
                                        }

                                        flag = (num = array[37].IndexOf("<!--")) > 0;

                                        if (flag)
                                        {
                                            array[37] = array[37].Substring(0, num - 2);
                                        }
                                    }
                                    else
                                    {
                                        flag = (num = array[39].IndexOf(">")) > 0;

                                        if (flag)
                                        {
                                            array[39] = array[39].Substring(num + 3);
                                        }

                                        flag = (num = array[39].IndexOf("<!--")) > 0;

                                        if (flag)
                                        {
                                            //array[39] = array[39].Substring(0, num - 2);
                                        }
                                    }                                    
                                }
                            }
                            _ListaEmisionElectronica = new List<String>();
                        }
                    }

                    //Padrones (Persona Natural)
                    if (caracter.Equals("1") == true)
                    {
                        if (Estado == "ACTIVO")
                        {     
                         List<String> Padrones = new List<String>(Regex.Split(array[IndBuscarPadron], "<option value='00' >"));
                         _Padrones = new List<String>();

                            for (int i = 1; i < Padrones.Count; i++)
                            {
                            flag = (num = Padrones[i].IndexOf("</option>")) > 0;

                            if (flag)
                               {
                               _Padrones.Add(Padrones[i].Substring(0, num));
                               }
                            }
                        }
                        else
                        {
                         List<String> Padrones = new List<String>(Regex.Split(array[IndBuscarPadron], "<option value='00' >"));
                         _Padrones = new List<String>();

                            for (int i = 1; i < Padrones.Count; i++)
                            {
                            flag = (num = Padrones[i].IndexOf("</option>")) > 0;

                            if (flag)
                              {
                               _Padrones.Add(Padrones[i].Substring(0, num));
                              }
                            }
                        }
                    }


                    //if (false)
                    //{

                    //    //Emisor Electrónico (Empresas)
                    //    if (caracter.Equals("2") == true)
                    //{
                    //    if (array[12].Trim().Equals("ACTIVO"))
                    //    {
                    //        flag = String.Compare(array[35].Substring(0, 28), "class='bgn' colspan=1>Emisor", false) == 0;

                    //        if (flag)
                    //        {
                    //            flag = (num = array[36].IndexOf(">")) > 0;

                    //            if (flag)
                    //            {
                    //                array[35] = array[36].Substring(num + 1);
                    //                flag = (num = array[35].IndexOf(" <!--")) > 0;

                    //                if (flag)
                    //                {
                    //                    array[35] = array[35].Substring(0, num - 2);
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            flag = (num = array[35].IndexOf(">")) > 0;

                    //            if (flag)
                    //            {
                    //                array[35] = array[35].Substring(num + 1);
                    //                flag = (num = array[35].IndexOf(" <!--")) > 0;

                    //                if (flag)
                    //                {
                    //                    array[35] = array[35].Substring(0, num - 2);
                    //                }
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        flag = (num = array[36].IndexOf("class='bgn' colspan=1>Emisor")) > 0;

                    //        if (flag)
                    //        {
                    //            flag = (num = array[37].IndexOf(">")) > 0;

                    //            if (flag)
                    //            {
                    //                array[36] = array[37].Substring(num + 1);
                    //                flag = (num = array[36].IndexOf(" <!--")) > 0;

                    //                if (flag)
                    //                {
                    //                    array[36] = array[36].Substring(0, num - 2);
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            flag = (num = array[36].IndexOf(">")) > 0;

                    //            if (flag)
                    //            {
                    //                array[36] = array[36].Substring(num + 1);
                    //                flag = (num = array[36].IndexOf(" <!--")) > 0;

                    //                if (flag)
                    //                {
                    //                    array[36] = array[36].Substring(0, num - 2);
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                    //    else //Emisor Electrónico (Persona Natural)
                    //{
                    //    if (array[14].Trim().Equals("ACTIVO"))
                    //    {
                    //        flag = String.Compare(array[39].Substring(0, 28), "class='bgn' colspan=1>Emisor", false) == 0;

                    //        if (flag)
                    //        {
                    //            num = array[40].IndexOf(">");
                    //            array[39] = array[40].Substring(num + 1);
                    //            flag = (num = array[39].IndexOf(" <!--")) > 0;

                    //            if (flag)
                    //            {
                    //                array[39] = array[39].Substring(0, num - 2);
                    //            }
                    //        }
                    //        else
                    //        {
                    //            flag = String.Compare(array[39].Substring(0, 28), "class='bgn' colspan=1>Emisor", false) == 0;

                    //            if (flag)
                    //            {
                    //                num = array[39].IndexOf(">");
                    //                array[39] = array[39].Substring(num + 1);
                    //                flag = (num = array[39].IndexOf(" <!--")) > 0;

                    //                if (flag)
                    //                {
                    //                    array[39] = array[39].Substring(0, num - 2);
                    //                }   
                    //            }
                    //            else
                    //            {
                    //                num = array[38].IndexOf(">");
                    //                array[39] = array[38].Substring(num + 1);
                    //                flag = (num = array[39].IndexOf(" <!--")) > 0;

                    //                if (flag)
                    //                {
                    //                    array[39] = array[39].Substring(0, num - 2);
                    //                }
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        flag = String.Compare(array[40].Substring(0, 22), "class='bgn' colspan=1>", false) == 0;

                    //        if (flag)
                    //        {
                    //            flag = String.Compare(array[38].Substring(0, 28), "class='bgn' colspan=1>Emisor", false) == 0;

                    //            if (flag)
                    //            {
                    //                flag = (num = array[39].IndexOf(">")) > 0;

                    //                if (flag)
                    //                {
                    //                    array[39] = array[39].Substring(num + 1);
                    //                }
                    //            }
                    //            else
                    //            {
                    //                flag = (num = array[41].IndexOf(">")) > 0;

                    //                if (flag)
                    //                {
                    //                    array[41] = array[41].Substring(num + 1);
                    //                }
                    //            }                                
                    //        }
                    //        else
                    //        {
                    //            flag = String.Compare(array[39].Substring(0, 28), "class='bgn' colspan=1>Emisor", false) == 0;

                    //            if (flag)
                    //            {
                    //                num = array[40].IndexOf(">");
                    //                array[39] = array[40].Substring(num + 1);
                    //                flag = (num = array[39].IndexOf(" <!--")) > 0;

                    //                if (flag)
                    //                {
                    //                    array[39] = array[39].Substring(0, num - 2);
                    //                }
                    //            }
                    //            else
                    //            {
                    //                num = array[39].IndexOf(">");
                    //                array[39] = array[39].Substring(num + 1);
                    //                flag = (num = array[39].IndexOf(" <!--")) > 0;

                    //                if (flag)
                    //                {
                    //                    array[39] = array[39].Substring(0, num - 2);
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                 
                    //    //Comprobantes Electrónicos (Empresas)
                    //    if (caracter.Equals("2") == true)
                    //    {
                    //        if (array[12].Trim().Equals("ACTIVO"))
                    //        {
                    //            flag = String.Compare(array[37].Substring(0, 34), "class='bgn' colspan=1>Comprobantes", false) == 0;
                    //            flag = false;

                    //            if (flag)
                    //            {
                    //                flag = (num = array[38].IndexOf(">")) > 0;

                    //                if (flag)
                    //                {
                    //                    array[37] = array[38].Substring(num + 1);
                    //                    flag = (num = array[37].IndexOf(" <!--")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[37] = array[37].Substring(0, num);
                    //                    }
                    //                }
                    //            }
                    //            else
                    //            {
                    //                flag = (num = array[37].IndexOf(">")) > 0;
                    //                flag = false;

                    //                if (flag)
                    //                {
                    //                    array[37] = array[37].Substring(num + 1);
                    //                    flag = (num = array[37].IndexOf(" <!--")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[37] = array[37].Substring(0, num);
                    //                    }
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            flag = (num = array[38].IndexOf("class='bgn' colspan=1>Comprobantes")) > 0;
                    //            if (flag)
                    //            {
                    //                flag = (num = array[39].IndexOf(">")) > 0;

                    //                if (flag)
                    //                {
                    //                    array[38] = array[39].Substring(num + 1);
                    //                    flag = (num = array[38].IndexOf(" <!--")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[38] = array[38].Substring(0, num);
                    //                    }
                    //                }
                    //            }
                    //            else
                    //            {
                    //                flag = (num = array[38].IndexOf(">")) > 0;

                    //                if (flag)
                    //                {
                    //                    array[38] = array[38].Substring(num + 1);
                    //                    flag = (num = array[38].IndexOf(" <!--")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[38] = array[38].Substring(0, num);
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    } //Comprobantes Electrónicos (Persona Natural)
                    //    else
                    //    {
                    //        if (array[14].Trim().Equals("ACTIVO"))
                    //        {
                    //            flag = String.Compare(array[41].Substring(0, 34), "class='bgn' colspan=1>Comprobantes", false) == 0;

                    //            if (flag)
                    //            {
                    //                flag = (num = array[42].IndexOf(">")) > 0;

                    //                if (flag)
                    //                {
                    //                    array[41] = array[42].Substring(num + 1);
                    //                    flag = (num = array[41].IndexOf(" <!--")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[41] = array[41].Substring(0, num);
                    //                    }
                    //                }
                    //            }
                    //            else
                    //            {
                    //                flag = (num = array[40].IndexOf(">")) > 0; //modificado

                    //                if (flag)
                    //                {
                    //                    array[41] = array[40].Substring(num + 1);
                    //                    flag = (num = array[41].IndexOf(" <!--")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[41] = array[41].Substring(0, num);
                    //                    }
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            flag = String.Compare(array[42].Substring(0, 22), "class='bgn' colspan=1>", false) == 0; //modificado

                    //            if (flag)
                    //            {
                    //                flag = String.Compare(array[40].Substring(0, 34), "class='bgn' colspan=1>Comprobantes", false) == 0; //Agregado

                    //                if (flag)
                    //                {
                    //                    flag = (num = array[41].IndexOf(">")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[41] = array[41].Substring(num + 1);
                    //                        flag = (num = array[41].IndexOf(" <!--")) > 0;

                    //                        if (flag)
                    //                        {
                    //                            array[41] = array[41].Substring(0, num);
                    //                        }
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    flag = (num = array[43].IndexOf(">")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[43] = array[43].Substring(num + 1);
                    //                        flag = (num = array[43].IndexOf(" <!--")) > 0;

                    //                        if (flag)
                    //                        {
                    //                            array[43] = array[43].Substring(0, num);
                    //                        }
                    //                    }
                    //                }
                    //            }
                    //            else
                    //            {
                    //                //flag = String.Compare(array[41].Substring(0, 34), "class='bgn' colspan=1>Comprobantes", false) == 0;

                    //                foreach (string item in array)
                    //                {
                    //                    if (item.Substring(0, 34) == "class='bgn' colspan=1>Comprobantes")
                    //                    {
                    //                        flag = true;
                    //                    }
                    //                }

                    //                if (flag)
                    //                {
                    //                    flag = (num = array[42].IndexOf(">")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[41] = array[42].Substring(num + 1);
                    //                        flag = (num = array[41].IndexOf(" <!--")) > 0;

                    //                        if (flag)
                    //                        {
                    //                            array[41] = array[41].Substring(0, num);
                    //                        }
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    flag = (num = array[41].IndexOf(">")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[41] = array[41].Substring(num + 1);
                    //                        flag = (num = array[41].IndexOf(" <!--")) > 0;

                    //                        if (flag)
                    //                        {
                    //                            array[41] = array[41].Substring(0, num);
                    //                        }
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }

                    //    //Afiliado al PLE (Persona Juridica)
                    //    if (caracter.Equals("2") == true)
                    //    {
                    //        if (array[12].Trim().Equals("ACTIVO"))
                    //        {
                    //            flag = String.Compare(array[39].Substring(0, 30), "class='bgn' colspan=1>Afiliado", false) == 0;

                    //            if (flag)
                    //            {
                    //                flag = (num = array[40].IndexOf(">")) > 0;

                    //                if (flag)
                    //                {
                    //                    array[39] = array[40].Substring(num + 1);
                    //                    flag = (num = array[39].IndexOf(" <!--")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[39] = array[39].Substring(0, num - 4);
                    //                    }
                    //                }
                    //            }
                    //            else
                    //            {
                    //                flag = (num = array[39].IndexOf(">")) > 0;

                    //                if (flag)
                    //                {
                    //                    array[39] = array[39].Substring(num + 1);
                    //                    flag = (num = array[39].IndexOf(" <!--")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[39] = array[39].Substring(0, num - 4);
                    //                    }
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            flag = (num = array[40].IndexOf("class='bgn' colspan=1>Afiliado")) > 0;

                    //            if (flag)
                    //            {
                    //                flag = (num = array[41].IndexOf(">")) > 0;

                    //                if (flag)
                    //                {
                    //                    array[40] = array[41].Substring(num + 1);
                    //                    flag = (num = array[40].IndexOf(" <!--")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[40] = array[40].Substring(0, num - 4);
                    //                    }
                    //                }
                    //            }
                    //            else
                    //            {
                    //                flag = (num = array[40].IndexOf(">")) > 0;

                    //                if (flag)
                    //                {
                    //                    array[40] = array[40].Substring(num + 1);
                    //                    flag = (num = array[40].IndexOf(" <!--")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[40] = array[40].Substring(0, num - 4);
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }
                    //    else //Afiliado al PLE (Persona Natural)
                    //    {
                    //        if (array[14].Trim().Equals("ACTIVO"))
                    //        {
                    //            flag = String.Compare(array[43].Substring(0, 30), "class='bgn' colspan=1>Afiliado", false) == 0;

                    //            if (flag)
                    //            {
                    //                flag = (num = array[44].IndexOf(">")) > 0;

                    //                if (flag)
                    //                {
                    //                    array[43] = array[44].Substring(num + 1);
                    //                    flag = (num = array[43].IndexOf(" <!--")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[43] = array[43].Substring(0, num - 4);
                    //                    }
                    //                }
                    //            }
                    //            else
                    //            {
                    //                flag = (num = array[42].IndexOf(">")) > 0; //modificado

                    //                if (flag)
                    //                {
                    //                    array[43] = array[42].Substring(num + 1);
                    //                    flag = (num = array[43].IndexOf(" <!--")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[43] = array[43].Substring(0, num - 4);
                    //                    }
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            flag = String.Compare(array[44].Substring(0, 22), "class='bgn' colspan=1>", false) == 0; //modificado

                    //            if (flag)
                    //            {
                    //                flag = String.Compare(array[42].Substring(0, 30), "class='bgn' colspan=1>Afiliado", false) == 0;

                    //                if (flag)
                    //                {
                    //                    flag = (num = array[43].IndexOf(">")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[43] = array[43].Substring(num + 1);
                    //                    }

                    //                    flag = (num = array[43].IndexOf("<!--")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[43] = array[43].Substring(0, num - 2);
                    //                    }

                    //                    array[43] = array[43].Replace("\t", "");
                    //                }
                    //                else
                    //                {
                    //                    flag = (num = array[45].IndexOf(">")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[45] = array[45].Substring(num + 1);
                    //                    }

                    //                    flag = (num = array[45].IndexOf("<!--")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[45] = array[45].Substring(0, num - 2);
                    //                    }

                    //                    array[45] = array[45].Replace("\t", "");
                    //                }
                    //            }
                    //            else
                    //            {
                    //                flag = String.Compare(array[43].Substring(0, 30), "class='bgn' colspan=1>Afiliado", false) == 0;

                    //                if (flag)
                    //                {
                    //                    flag = (num = array[44].IndexOf(">")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[43] = array[44].Substring(num + 1);
                    //                        flag = (num = array[43].IndexOf(" <!--")) > 0;

                    //                        if (flag)
                    //                        {
                    //                            array[43] = array[43].Substring(0, num - 4);
                    //                        }
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    flag = (num = array[43].IndexOf(">")) > 0;

                    //                    if (flag)
                    //                    {
                    //                        array[43] = array[43].Substring(num + 1);
                    //                        flag = (num = array[43].IndexOf(" <!--")) > 0;

                    //                        if (flag)
                    //                        {
                    //                            array[43] = array[43].Substring(0, num - 4);
                    //                        }
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }

                    //}

                    String Rz = array[2];
                    String Dir= String.Empty;

                    // Direccion Fiscal de Empresa
                    if (caracter.Equals("2") == true) 
                    {
                        Dir = array[17];
                    }

                    // Direccion Fiscal de Personas
                    if (caracter.Equals("1") == true)
                    {
                        Dir = array[19];
                    }

                    Rz = Rz.Replace("&#209;", "Ñ");
                    Rz = Rz.Replace("&#xD1;", "Ñ");
                    Rz = Rz.Replace("&#193;", "Á");
                    Rz = Rz.Replace("&#201;", "É");
                    Rz = Rz.Replace("&#205;", "Í");
                    Rz = Rz.Replace("&#211;", "Ó");
                    Rz = Rz.Replace("&#218;", "Ú");
                    Rz = Rz.Replace("&#xC1;", "Á");
                    Rz = Rz.Replace("&#xC9;", "É");
                    Rz = Rz.Replace("&#xCD;", "Í");
                    Rz = Rz.Replace("&#xD3;", "Ó");
                    Rz = Rz.Replace("&#xDA;", "Ú");
                    Rz = Rz.Replace("   ", "");
                    Dir = Dir.Replace("&#209;", "Ñ");
                    Dir = Dir.Replace("&#xD1;", "Ñ");
                    Dir = Dir.Replace("&#193;", "Á");
                    Dir = Dir.Replace("&#201;", "É");
                    Dir = Dir.Replace("&#205;", "Í");
                    Dir = Dir.Replace("&#211;", "Ó");
                    Dir = Dir.Replace("&#218;", "Ú");
                    Dir = Dir.Replace("&#xC1;", "Á");
                    Dir = Dir.Replace("&#xC9;", "É");
                    Dir = Dir.Replace("&#xCD;", "Í");
                    Dir = Dir.Replace("&#xD3;", "Ó");
                    Dir = Dir.Replace("&#xDA;", "Ú");

                    _RazonSocial = Rz;
                    _TipoContribuyente = array[4].Trim();

                    // EMPRESAS
                    if (caracter.Equals("2") == true) //Para personas juridicas
                    {
                     _NombreComercial = array[6].Trim();
                     _FechaInscripcion = array[8].Trim();
                     _FechaActividades = array[10].Trim();
                     _EstadoContribuyente = array[12].Trim();
                     _CondicionContribuyente = array[IndBuscarCondicion].Trim();
                     _Direccion = Dir.Trim();
                     _EmisionComprobante = array[IndBuscarSisEmision].Trim();
                     _ActividadExterior = array[IndBuscarActExterior].Trim();
                     _SistemaContabilidad = array[IndBuscarSisContabilidad].Trim();
                     _EmisionElectronica = "-";
                     _EmisorElectronico = "-";
                     _ComprobanteElectronico = "-";
                     _AfiliacionPle = "-";
                     _Telefonos = String.Empty;
                    }

                    // PERSONA NATURALES
                    if (caracter.Equals("1") == true)
                    {
                     _Dni = array[6].Trim();
                     _NombreComercial = array[8].Trim();
                        
                    if (array[9] == "SI")
                     {
                      _Rus = array[9];

                     if (array[14].Trim() == "BAJA DEFINITIVA")
                       {
                        _FecBaja = array[18].Trim();
                       }
                     }
                     else
                     {
                            _Rus = "NO";
                     }

                     _FechaInscripcion = array[10].Trim();
                     _FechaActividades = array[12].Trim();
                     _EstadoContribuyente = array[14].Trim();
                     _CondicionContribuyente = array[IndBuscarCondicion].Trim();
                     _CondicionContribuyente = _CondicionContribuyente.Replace("       ", "");
                     _CondicionContribuyente = _CondicionContribuyente.Replace("  ", "");
                     _Direccion = "-";
                     _EmisionComprobante = array[IndBuscarSisEmision].Trim();
                     _ActividadExterior = array[IndBuscarActExterior].Trim();
                     _SistemaContabilidad = array[IndBuscarSisContabilidad].Trim();
                     _Profesion = "-";
                     _EmisionElectronica = "-";
                     _EmisorElectronico = "-";
                     _ComprobanteElectronico = "-";
                     _AfiliacionPle = "-";
                     _Telefonos = String.Empty;
                       
                    }

                }

                webRespuesta.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ObtenerInfoSunat(String numRUC, String ImgCapcha)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(this.ValidarCertificado);
                String requestUriString = String.Format("http://ww1.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias?accion=consPorRuc&nroRuc={0}&codigo={1}&tipdoc=1", numRUC, ImgCapcha);

                HttpWebRequest webSolicitud = (HttpWebRequest)WebRequest.Create(requestUriString);
                webSolicitud.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135";
                webSolicitud.CookieContainer = this.myCookie;
                webSolicitud.Credentials = CredentialCache.DefaultCredentials;
                webSolicitud.Proxy = null;
                HttpWebResponse webRespuesta = (HttpWebResponse)webSolicitud.GetResponse();
                Stream responseStream = webRespuesta.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF7);
                String text = HttpUtility.HtmlDecode(streamReader.ReadToEnd());
                int length = text.Length;
                bool flag = length == 1754;
                String caracter = numRUC.Substring(0, 1);

                _Web = String.Empty;

                #region Revisando si hay algún tipo de error

                if (flag)
                {
                    EstadoConsulta = Resul.ErrorCapcha;
                }
                else
                {
                    flag = (length == 3207);

                    if (flag)
                    {
                        EstadoConsulta = Resul.RucInvalido;
                    }
                    else
                    {
                        flag = (length == 222);

                        if (flag)
                        {
                            EstadoConsulta = Resul.NoResul;
                        }
                        else
                        {
                            flag = (text.Length >= 15000);

                            if (flag)
                            {
                                EstadoConsulta = Resul.Ok;
                            }
                            else
                            {
                                EstadoConsulta = Resul.Error;
                            }
                        }
                    }
                } 

                #endregion

                if (flag)
                {
                    _Web = text;
                    text = text.Replace("     ", " ");
                    text = text.Replace("    ", " ");
                    text = text.Replace("   ", " ");
                    text = text.Replace("  ", " ");
                    text = text.Replace("( ", "(");
                    text = text.Replace(" )", ")");
                    text = text.Replace("\n", "");
                    text = text.Replace("\r", "");
                    text = text.Replace("\"", "'");
                    text = text.Replace("<tr>", "");
                    text = text.Replace("</td>", "");
                    text = text.Replace("</tr>", "");

                    int num = text.IndexOf("}</script>");
                    flag = (num > 0);

                    if (flag)
                    {
                        text = text.Substring(num + 10);
                    }

                    //Colocando todos los valores en un array
                    List<String> array = new List<String>(Regex.Split(text, "<td "));

                    //Razón Social
                    flag = (num = array[2].IndexOf(">")) > 0;

                    if (flag)
                    {
                        array[2] = array[2].Substring(num + 15);
                    }

                    foreach (string item in array)
                    {
                        if (item.Contains(""))
                        {
                            
                        }
                    }

                }

                webRespuesta.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
