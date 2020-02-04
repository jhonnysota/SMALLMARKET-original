using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class KardexValorizadoAD : DbConection
    {

        public KardexValorizadoE LlenarEntidad(IDataReader oReader)
        {
            KardexValorizadoE KardexValorizado = new KardexValorizadoE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Inicio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.Inicio = oReader["Inicio"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Inicio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fin'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.Fin = oReader["Fin"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fin"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoExistencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.TipoExistencia = oReader["TipoExistencia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoExistencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomExistencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.NomExistencia = oReader["NomExistencia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomExistencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Articulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.Articulo = oReader["Articulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Articulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.DesArticulo = oReader["DesArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UndMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.UndMedida = oReader["UndMedida"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["UndMedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.NomMedida = oReader["NomMedida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomMedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Metodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.Metodo = oReader["Metodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Metodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecProceso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.fecProceso = oReader["fecProceso"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["fecProceso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.Fecha = oReader["Fecha"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["Fecha"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Documento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.Documento = oReader["Documento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Documento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Serie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.Serie = oReader["Serie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Serie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Numero'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.Numero = oReader["Numero"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Numero"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.idDocumentoRef = oReader["idDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.serDocumentoRef = oReader["serDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.numDocumentoRef = oReader["numDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Operacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.Operacion = oReader["Operacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Operacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CantEntradaInicial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.CantEntradaInicial = oReader["CantEntradaInicial"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CantEntradaInicial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CantEntradaNoInicial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.CantEntradaNoInicial = oReader["CantEntradaNoInicial"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CantEntradaNoInicial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CantEntrada'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.CantEntrada = oReader["CantEntrada"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CantEntrada"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostEntrada'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.CostEntrada = oReader["CostEntrada"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostEntrada"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalEntrada'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.TotalEntrada = oReader["TotalEntrada"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalEntrada"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CantSalida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.CantSalida = oReader["CantSalida"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CantSalida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostSalida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.CostSalida = oReader["CostSalida"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostSalida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalSalida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.TotalSalida = oReader["TotalSalida"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalSalida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CantFinal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.CantFinal = oReader["CantFinal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CantFinal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostFinal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.CostFinal = oReader["CostFinal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostFinal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalFinal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.TotalFinal = oReader["TotalFinal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalFinal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.NomOperacion = oReader["NomOperacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.CodSunat = oReader["CodSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodSunat"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);            

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tipo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.Tipo = oReader["Tipo"] == DBNull.Value ? 0 : Convert.ToInt16(oReader["Tipo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cantAnte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.cantAnte = oReader["cantAnte"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["cantAnte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoAnte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.CostoAnte = oReader["CostoAnte"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoAnte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoActual'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.CostoActual = oReader["CostoActual"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoActual"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Batch'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.Batch = oReader["Batch"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Batch"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LoteProveedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.LoteProveedor = oReader["LoteProveedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LoteProveedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LoteAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.LoteAlmacen = oReader["LoteAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LoteAlmacen"]);            

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.Lote = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorcentajeGerminacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.PorcentajeGerminacion = oReader["PorcentajeGerminacion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorcentajeGerminacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecPrueba'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.fecPrueba = oReader["fecPrueba"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecPrueba"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaProceso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.FechaProceso = oReader["FechaProceso"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["FechaProceso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesUniMedAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.DesUniMedAlmacen = oReader["DesUniMedAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesUniMedAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesUniMedEnvase'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.DesUniMedEnvase = oReader["DesUniMedEnvase"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesUniMedEnvase"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesUniMedPres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.DesUniMedPres = oReader["DesUniMedPres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesUniMedPres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesArticuloLargo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.DesArticuloLargo = oReader["DesArticuloLargo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesArticuloLargo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesArticuloCorto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.DesArticuloCorto = oReader["DesArticuloCorto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesArticuloCorto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PesoUnit'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.PesoUnit = oReader["PesoUnit"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PesoUnit"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Contenido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.Contenido = oReader["Contenido"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Contenido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.nomArticulo = oReader["nomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipDoc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.TipDoc = oReader["TipDoc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipDoc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codsunatmed'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.codsunatmed = oReader["codsunatmed"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codsunatmed"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Asiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.Asiento = oReader["Asiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Asiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodEstablecimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.CodEstablecimiento = oReader["CodEstablecimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodEstablecimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCortaAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                KardexValorizado.desCortaAlmacen = oReader["desCortaAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCortaAlmacen"]);
            

            return KardexValorizado;
        }

        public List<KardexValorizadoE> ListarKardexValorizado(Int32 idEmpresa, Int32 idAlmacen, string Inicio, string Fin)
        {
            List<KardexValorizadoE> listaEntidad = new List<KardexValorizadoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarKardexValorizado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@Inicio", SqlDbType.VarChar, 8).Value = Inicio;
                    oComando.Parameters.Add("@Fin", SqlDbType.VarChar, 8).Value = Fin;
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<KardexValorizadoE> ListarKardexValorizadoFilt(Int32 idEmpresa, Int32 idAlmacen, string Inicio, string Fin, Int32 idArticulo, String idMoneda, Int32 idTipoArticulo)
        {
            List<KardexValorizadoE> listaEntidad = new List<KardexValorizadoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarKardexValorizadoFilt", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@Inicio", SqlDbType.VarChar, 8).Value = Inicio;
                    oComando.Parameters.Add("@Fin", SqlDbType.VarChar, 8).Value = Fin;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar,2).Value = idMoneda;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<KardexValorizadoE> ListarKardexValorizadoFiltPorLote(Int32 idEmpresa, Int32 idAlmacen, string Inicio, string Fin, Int32 idArticulo,String Lote, String LoteAlmacen, Int32 idTipoArticulo)
        {
            List<KardexValorizadoE> listaEntidad = new List<KardexValorizadoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarKardexValorizadoFiltPorLote", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@Inicio", SqlDbType.VarChar, 8).Value = Inicio;
                    oComando.Parameters.Add("@Fin", SqlDbType.VarChar, 8).Value = Fin;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 40).Value = Lote;
                    oComando.Parameters.Add("@LoteAlmacen", SqlDbType.VarChar, 40).Value = LoteAlmacen;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

    }
}
