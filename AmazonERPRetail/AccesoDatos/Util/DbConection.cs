using System.Data.SqlClient;
using System.Configuration;

namespace AccesoDatos.Util
{
    public abstract class DbConection
    {

        public DbConection()
        {
            sCadena = ConfigurationManager.ConnectionStrings["Cnx"].ConnectionString;
        }

        private readonly string sCadena;
        public string Esquema = string.Empty;

        protected SqlConnection ConexionSql()
        {
            //string cadConex = sCadena.Replace("1?", "Data Source=192.168.1.10").Replace("2?", "Initial Catalog=AMAZONERP").Replace("3?", "User ID=amazonerp.user").Replace("4?", "Password=12$34$Com");
            //string cadConex = sCadena.Replace("1?", "Data Source=amazontic.database.windows.net").Replace("2?", "Initial Catalog=AMAZONERP_ROAL").Replace("3?", "User ID=amazonerp.user").Replace("4?", "Password=2019.aticbd");
            
            
           //// string cadConex = sCadena.Replace("1?", "Data Source=amazontic.database.windows.net").Replace("2?", "Initial Catalog=AMAZONERP_STOREH").Replace("3?", "User ID=amazonerp.user").Replace("4?", "Password=2019.aticbd");
            //string cadConex = sCadena.Replace("1?", "Data Source=amazontic.database.windows.net").Replace("2?", "Initial Catalog=AMAZONERP_ROAL").Replace("3?", "User ID=jose.salazar").Replace("4?", "Password=putito.69");
            //string cadConex = sCadena.Replace("1?", "Data Source=amazonticpe.database.windows.net").Replace("2?", "Initial Catalog=AMAZONERP").Replace("3?", "User ID=jose.salazar").Replace("4?", "Password=putito.69");
            string cadConex = sCadena.Replace("1?", "Data Source=amazonticpe.database.windows.net").Replace("2?", "Initial Catalog=AMAZONERP_SH").Replace("3?", "User ID=jhonny.sota").Replace("4?", "Password=amazon.js2019");

            return new SqlConnection(cadConex);
        }

    }
}
