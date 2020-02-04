using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class FlujoDeCajaAD : DbConection
    {
        
        public FlujoDeCajaE LlenarEntidad(IDataReader oReader)
        {
            FlujoDeCajaE abonosbancos = new FlujoDeCajaE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AÑO'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.AÑO = oReader["AÑO"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AÑO"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.MES = oReader["MES"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IDENTIFICADOR'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.IDENTIFICADOR = oReader["IDENTIFICADOR"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["IDENTIFICADOR"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='COD_PARTIDA'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.COD_PARTIDA = oReader["COD_PARTIDA"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["COD_PARTIDA"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PARTIDA'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.PARTIDA = oReader["PARTIDA"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PARTIDA"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SUB_PARTIDA'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.SUB_PARTIDA = oReader["SUB_PARTIDA"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SUB_PARTIDA"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SUB_PARTIDA_PRESU'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.SUB_PARTIDA_PRESU = oReader["SUB_PARTIDA_PRESU"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SUB_PARTIDA_PRESU"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MOV'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.MOV = oReader["MOV"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MOV"]); 

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IMPORTE'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.IMPORTE = oReader["IMPORTE"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["IMPORTE"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CLAVE'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.CLAVE = oReader["CLAVE"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CLAVE"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RANGO'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.RANGO = oReader["RANGO"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RANGO"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='COD_PARTIDA_PRES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.COD_PARTIDA_PRES = oReader["COD_PARTIDA_PRES"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["COD_PARTIDA_PRES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PARTIDA_PRESU'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.PARTIDA_PRESU = oReader["PARTIDA_PRESU"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PARTIDA_PRESU"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LIBRO'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.LIBRO = oReader["LIBRO"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LIBRO"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NFILE'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.NFILE = oReader["NFILE"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NFILE"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NUMERO'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.NUMERO = oReader["NUMERO"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NUMERO"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ITEM'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.ITEM = oReader["ITEM"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ITEM"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CUENTA'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.CUENTA = oReader["CUENTA"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CUENTA"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FECHA_COMP'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.FECHA_COMP = oReader["FECHA_COMP"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["FECHA_COMP"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GLOSA'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.GLOSA = oReader["GLOSA"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["GLOSA"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DOCUMENTO'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.DOCUMENTO = oReader["DOCUMENTO"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DOCUMENTO"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FECHA_EMIS'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.FECHA_EMIS = oReader["FECHA_EMIS"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["FECHA_EMIS"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DEBE'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.DEBE = oReader["DEBE"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["DEBE"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='HABER'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                abonosbancos.HABER = oReader["HABER"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["HABER"]);

            return abonosbancos;
        }

        public List<FlujoDeCajaE> ReporteFlujoCaja(Int32 idEmpresa, Int32 idLocal, String MesAnoIni, String MesAnoFin)
        {
            List<FlujoDeCajaE> listaEntidad = new List<FlujoDeCajaE>();
            FlujoDeCajaE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteFlujoCaja", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@MesAnoIni", SqlDbType.VarChar, 7).Value = MesAnoIni;
                    oComando.Parameters.Add("@MesAnoFin", SqlDbType.VarChar, 7).Value = MesAnoFin;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<FlujoDeCajaE> ReporteFlujoCajaDetalle(Int32 idEmpresa, Int32 idLocal, String Anio, String Mes, String Movimiento, String Partida)
        {
            List<FlujoDeCajaE> listaEntidad = new List<FlujoDeCajaE>();
            FlujoDeCajaE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteFlujoCajaDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@Movimiento", SqlDbType.VarChar, 1).Value = Movimiento;
                    oComando.Parameters.Add("@Partida", SqlDbType.VarChar, 20).Value = Partida;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }

            return listaEntidad;
        }



    }
}
