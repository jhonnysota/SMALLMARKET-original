using System;
using System.Configuration;

namespace Infraestructura.WCF
{
    internal static class ConexionHelperWCF
    {
        public static Uri GetUri(string serviceName)
        {
            try
            {
                string serviceUri = ConfigurationManager.AppSettings.Get(serviceName);

                var uri = new Uri(serviceUri);

                return uri;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("No se pudo crear el URI de conexion al servicio: {0}", serviceName), ex);
            }
        }

        public static UriType GetUriType(Uri uri)
        {
            UriType tipo = UriType.Tcp;

            if (uri.Scheme.Equals("http"))
            {
                tipo = UriType.Http;
            }
            else if (uri.Scheme.Equals("https"))
            {
                tipo = UriType.Https;
            }
            else if (uri.Scheme.Equals("net.tcp"))
            {
                tipo = UriType.Tcp;
            }
            else if (uri.Scheme.Equals("net.pipe"))
            {
                tipo = UriType.Pipe;
            }

            return tipo;
        }

        public static TimeSpan ReceiveTimeout
        {
            get
            {
                string valor = ConfigurationManager.AppSettings["ReceiveTimeout"];
                if (!TimeSpan.TryParse(valor, out TimeSpan ts))
                {
                    ts = new TimeSpan(0, 10, 0);
                }

                return ts;
            }
        }

        public static TimeSpan OpenTimeout
        {
            get
            {
                string valor = ConfigurationManager.AppSettings["OpenTimeout"];
                if (!TimeSpan.TryParse(valor, out TimeSpan ts))
                {
                    ts = new TimeSpan(0, 4, 0);
                }

                return ts;
            }
        }

        public static TimeSpan CloseTimeout
        {
            get
            {
                string valor = ConfigurationManager.AppSettings["CloseTimeout"];
                if (!TimeSpan.TryParse(valor, out TimeSpan ts))
                {
                    ts = new TimeSpan(0, 2, 0);
                }

                return ts;
            }
        }

        public static TimeSpan SendTimeout
        {
            get
            {
                string valor = ConfigurationManager.AppSettings["SendTimeout"];
                if (!TimeSpan.TryParse(valor, out TimeSpan ts))
                {
                    ts = new TimeSpan(0, 4, 0);
                }

                return ts;
            }
        }
    }
}
