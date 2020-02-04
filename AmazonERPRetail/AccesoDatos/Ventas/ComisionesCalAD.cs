using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class ComisionesCalAD : DbConection
    {
        
        public ComisionesCalE LlenarEntidad(IDataReader oReader)
        {
            ComisionesCalE ComisionesCal = new ComisionesCalE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ComisionesCal.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ComisionesCal.idPeriodo = oReader["idPeriodo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaInicial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ComisionesCal.FechaInicial = oReader["FechaInicial"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaInicial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaFinal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ComisionesCal.FechaFinal = oReader["FechaFinal"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaFinal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Comision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ComisionesCal.Comision = oReader["Comision"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Comision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ComisionesCal.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ComisionesCal.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ComisionesCal.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ComisionesCal.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FecEmision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ComisionesCal.FecEmision = oReader["FecEmision"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FecEmision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numRuc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ComisionesCal.numRuc = oReader["numRuc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numRuc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocialDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ComisionesCal.RazonSocialDocumento = oReader["RazonSocialDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocialDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ComisionesCal.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotTotal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ComisionesCal.TotTotal = oReader["TotTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotTotal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ComisionDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ComisionesCal.ComisionDocumento = oReader["ComisionDocumento"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ComisionDocumento"]);



            return ComisionesCal;
        }

        public List<ComisionesCalE> CalculoComision(Int32 idEmpresa, Int32 idPeriodo, DateTime FechaInicial, DateTime FechaFinal)
        {
            List<ComisionesCalE> ListaBalance = new List<ComisionesCalE>();
            ComisionesCalE Item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CalcularComision", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPeriodo", SqlDbType.Int).Value = idPeriodo;
                    oComando.Parameters.Add("@FechaInicial", SqlDbType.DateTime).Value = FechaInicial;
                    oComando.Parameters.Add("@FechaFinal", SqlDbType.DateTime).Value = FechaFinal;


                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Item = LlenarEntidad(oReader);
                            ListaBalance.Add(Item);
                        }
                    }
                }

                oConexion.Close();
            }

            return ListaBalance;
        }

        public List<ComisionesCalE> PagarComision(Int32 idEmpresa, Int32 idPeriodoInicio, Int32 idPeriodoFinal ,DateTime FechaProceso)
        {
            List<ComisionesCalE> ListaBalance = new List<ComisionesCalE>();
            ComisionesCalE Item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_PagarComision", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPeriodoInicio", SqlDbType.Int).Value = idPeriodoInicio;
                    oComando.Parameters.Add("@idPeriodoFinal", SqlDbType.Int).Value = idPeriodoFinal;
                    oComando.Parameters.Add("@FechaProceso", SqlDbType.DateTime).Value = FechaProceso;


                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Item = LlenarEntidad(oReader);
                            ListaBalance.Add(Item);
                        }
                    }
                }

                oConexion.Close();
            }

            return ListaBalance;
        }


        public ComisionesCalE ObtenerPeriodoComisioncal(Int32 idEmpresa, Int32 idPeriodo)
        {
            ComisionesCalE periodocomisioncal = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPeriodoComisionCal", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPeriodo", SqlDbType.Int).Value = idPeriodo;
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            periodocomisioncal = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return periodocomisioncal;
        }

        public List<ComisionesCalE> ListarComisionCal(Int32 idEmpresa, Int32 idPeriodo, Int32 idVendedor)
        {
            List<ComisionesCalE> ComisionCal = new List<ComisionesCalE>();
            ComisionesCalE Item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarComisionCalculada", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPeriodo", SqlDbType.Int).Value = idPeriodo;
                    oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = idVendedor;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Item = LlenarEntidad(oReader);
                            ComisionCal.Add(Item);
                        }
                    }
                }

                oConexion.Close();
            }

            return ComisionCal;
        }

        public List<ComisionesCalE> ListarComisionPag(Int32 idEmpresa, Int32 idVendedor,DateTime FechaProceso)
        {
            List<ComisionesCalE> ComisionPag = new List<ComisionesCalE>();
            ComisionesCalE Item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarComisionParaPagar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                 
                    oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = idVendedor;
                    oComando.Parameters.Add("@FechaProceso", SqlDbType.DateTime).Value = FechaProceso;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Item = LlenarEntidad(oReader);
                            ComisionPag.Add(Item);
                        }
                    }
                }

                oConexion.Close();
            }

            return ComisionPag;
        }

        public List<ComisionesCalE> ListarComisionPendientePeriodo(Int32 idEmpresa, Int32 idPeriodoPago, String Estado, Int32 idVendedor)
        {
            List<ComisionesCalE> ComisionPendientePeriodo = new List<ComisionesCalE>();
            ComisionesCalE Item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarComisionPendientePeriodo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPeriodoPago", SqlDbType.Int).Value = idPeriodoPago;
                    oComando.Parameters.Add("@Estado", SqlDbType.VarChar, 1).Value = Estado;
                    oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = idVendedor;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Item = LlenarEntidad(oReader);
                            ComisionPendientePeriodo.Add(Item);
                        }
                    }
                }

                oConexion.Close();
            }

            return ComisionPendientePeriodo;
        }
    }
}
