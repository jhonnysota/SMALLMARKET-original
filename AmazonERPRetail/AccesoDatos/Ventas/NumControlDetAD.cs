using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class NumControlDetAD : DbConection
    {

        public NumControlDetE LlenarEntidad(IDataReader oReader)
        {
            NumControlDetE numcontroldet = new NumControlDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idControl'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.idControl = oReader["idControl"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idControl"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='item'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                numcontroldet.item = oReader["item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["item"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Serie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.Serie = oReader["Serie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Serie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cantDigSerie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.cantDigSerie = oReader["cantDigSerie"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["cantDigSerie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numInicial'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.numInicial = oReader["numInicial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numInicial"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFinal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.numFinal = oReader["numFinal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFinal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCorrelativo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                numcontroldet.numCorrelativo = oReader["numCorrelativo"] == DBNull.Value ? "0" : Convert.ToString(oReader["numCorrelativo"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cantDigNumero'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.cantDigNumero = oReader["cantDigNumero"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["cantDigNumero"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecInicio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.fecInicio = oReader["fecInicio"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecInicio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecFinal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                numcontroldet.fecFinal = oReader["fecFinal"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecFinal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstadoInicial'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.indEstadoInicial = oReader["indEstadoInicial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indEstadoInicial"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCondicion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.idCondicion = oReader["idCondicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCondicion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idVendedor'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.idVendedor = oReader["idVendedor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idVendedor"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTransporte'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.idTransporte = oReader["idTransporte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTransporte"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipTraslado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.idTipTraslado = oReader["idTipTraslado"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipTraslado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstadoDocu'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.indEstadoDocu = oReader["indEstadoDocu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indEstadoDocu"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FlagCantUnit'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.FlagCantUnit = oReader["FlagCantUnit"] == DBNull.Value ? false : Convert.ToBoolean(oReader["FlagCantUnit"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ListaPrecio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.ListaPrecio = oReader["ListaPrecio"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["ListaPrecio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCliente'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.idCliente = oReader["idCliente"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCliente"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Formato'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.Formato = oReader["Formato"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Formato"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsGuia'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.EsGuia = oReader["EsGuia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["EsGuia"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PuntoPartida'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.PuntoPartida = oReader["PuntoPartida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PuntoPartida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PuntoLlegada'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                numcontroldet.PuntoLlegada = oReader["PuntoLlegada"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PuntoLlegada"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PuntoVenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.PuntoVenta = oReader["PuntoVenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PuntoVenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoAsiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.TipoAsiento = oReader["TipoAsiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoAsiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cantCopias'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.cantCopias = oReader["cantCopias"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["cantCopias"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cantItems'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.cantItems = oReader["cantItems"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["cantItems"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCaja'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.numCaja = oReader["numCaja"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCaja"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerieCaja'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.numSerieCaja = oReader["numSerieCaja"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerieCaja"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsContado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.EsContado = oReader["EsContado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["EsContado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ExigirGuia'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.ExigirGuia = oReader["ExigirGuia"] == DBNull.Value ? false : Convert.ToBoolean(oReader["ExigirGuia"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ExigirDatos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.ExigirDatos = oReader["ExigirDatos"] == DBNull.Value ? false : Convert.ToBoolean(oReader["ExigirDatos"]);
			
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Grupo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                numcontroldet.Grupo = oReader["Grupo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Grupo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cantDigDecimales'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                numcontroldet.cantDigDecimales = oReader["cantDigDecimales"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["cantDigDecimales"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cantCaracteres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                numcontroldet.cantCaracteres = oReader["cantCaracteres"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["cantCaracteres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Orden'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                numcontroldet.Orden = oReader["Orden"] == DBNull.Value ? 1 : Convert.ToInt32(oReader["Orden"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontroldet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			
            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                numcontroldet.desDocumento = oReader["desDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tipo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                numcontroldet.Tipo = oReader["Tipo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Tipo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoTraslado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                numcontroldet.desTipoTraslado = oReader["desTipoTraslado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoTraslado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomVendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                numcontroldet.nomVendedor = oReader["nomVendedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomVendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDocCompuesto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                numcontroldet.desDocCompuesto = oReader["desDocCompuesto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDocCompuesto"]);

            return  numcontroldet;
        }

        public NumControlDetE InsertarNumControlDet(NumControlDetE numcontroldet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarNumControlDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = numcontroldet.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = numcontroldet.idLocal;
					oComando.Parameters.Add("@idControl", SqlDbType.Int).Value = numcontroldet.idControl;
                    oComando.Parameters.Add("@item", SqlDbType.Int).Value = numcontroldet.item;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = numcontroldet.idDocumento;
					oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 20).Value = numcontroldet.Serie;
					oComando.Parameters.Add("@cantDigSerie", SqlDbType.TinyInt).Value = numcontroldet.cantDigSerie;
					oComando.Parameters.Add("@numInicial", SqlDbType.VarChar, 20).Value = numcontroldet.numInicial;
					oComando.Parameters.Add("@numFinal", SqlDbType.VarChar, 20).Value = numcontroldet.numFinal;
                    oComando.Parameters.Add("@numCorrelativo", SqlDbType.VarChar, 20).Value = numcontroldet.numCorrelativo;
					oComando.Parameters.Add("@cantDigNumero", SqlDbType.TinyInt).Value = numcontroldet.cantDigNumero;
					oComando.Parameters.Add("@fecInicio", SqlDbType.SmallDateTime).Value = numcontroldet.fecInicio;
					oComando.Parameters.Add("@fecFinal", SqlDbType.SmallDateTime).Value = numcontroldet.fecFinal;
					oComando.Parameters.Add("@indEstadoInicial", SqlDbType.Char, 1).Value = numcontroldet.indEstadoInicial;
					oComando.Parameters.Add("@idCondicion", SqlDbType.TinyInt).Value = numcontroldet.idCondicion;
					oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = numcontroldet.idVendedor;
					oComando.Parameters.Add("@idTransporte", SqlDbType.Int).Value = numcontroldet.idTransporte;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = numcontroldet.idMoneda;
					oComando.Parameters.Add("@idTipTraslado", SqlDbType.Int).Value = numcontroldet.idTipTraslado;
					oComando.Parameters.Add("@indEstadoDocu", SqlDbType.Char, 1).Value = numcontroldet.indEstadoDocu;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = numcontroldet.idAlmacen;
					oComando.Parameters.Add("@FlagCantUnit", SqlDbType.Bit).Value = numcontroldet.FlagCantUnit;
					oComando.Parameters.Add("@ListaPrecio", SqlDbType.Int).Value = numcontroldet.ListaPrecio;
					oComando.Parameters.Add("@idCliente", SqlDbType.Int).Value = numcontroldet.idCliente;
					oComando.Parameters.Add("@Formato", SqlDbType.VarChar, 50).Value = numcontroldet.Formato;
					oComando.Parameters.Add("@EsGuia", SqlDbType.Char, 1).Value = numcontroldet.EsGuia;
					oComando.Parameters.Add("@PuntoPartida", SqlDbType.VarChar, 100).Value = numcontroldet.PuntoPartida;
                    oComando.Parameters.Add("@PuntoLlegada", SqlDbType.VarChar, 100).Value = numcontroldet.PuntoLlegada;
					oComando.Parameters.Add("@PuntoVenta", SqlDbType.VarChar, 2).Value = numcontroldet.PuntoVenta;
					oComando.Parameters.Add("@TipoAsiento", SqlDbType.Char, 2).Value = numcontroldet.TipoAsiento;
					oComando.Parameters.Add("@cantCopias", SqlDbType.Int).Value = numcontroldet.cantCopias;
					oComando.Parameters.Add("@cantItems", SqlDbType.Int).Value = numcontroldet.cantItems;
					oComando.Parameters.Add("@numCaja", SqlDbType.VarChar, 2).Value = numcontroldet.numCaja;
					oComando.Parameters.Add("@numSerieCaja", SqlDbType.VarChar, 2).Value = numcontroldet.numSerieCaja;
					oComando.Parameters.Add("@EsContado", SqlDbType.Char, 1).Value = numcontroldet.EsContado;
					oComando.Parameters.Add("@ExigirGuia", SqlDbType.Bit).Value = numcontroldet.ExigirGuia;
					oComando.Parameters.Add("@ExigirDatos", SqlDbType.Bit).Value = numcontroldet.ExigirDatos;
                    oComando.Parameters.Add("@Grupo", SqlDbType.Char, 1).Value = numcontroldet.Grupo;
                    oComando.Parameters.Add("@cantDigDecimales", SqlDbType.Int).Value = numcontroldet.cantDigDecimales;
                    oComando.Parameters.Add("@cantCaracteres", SqlDbType.Int).Value = numcontroldet.cantCaracteres;
                    oComando.Parameters.Add("@Orden", SqlDbType.Int).Value = numcontroldet.Orden;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = numcontroldet.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return numcontroldet;
        }
        
        public NumControlDetE ActualizarNumControlDet(NumControlDetE numcontroldet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarNumControlDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = numcontroldet.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = numcontroldet.idLocal;
					oComando.Parameters.Add("@idControl", SqlDbType.Int).Value = numcontroldet.idControl;
                    oComando.Parameters.Add("@item", SqlDbType.Int).Value = numcontroldet.item;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = numcontroldet.idDocumento;
					oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 20).Value = numcontroldet.Serie;
					oComando.Parameters.Add("@cantDigSerie", SqlDbType.TinyInt).Value = numcontroldet.cantDigSerie;
					oComando.Parameters.Add("@numInicial", SqlDbType.VarChar, 20).Value = numcontroldet.numInicial;
					oComando.Parameters.Add("@numFinal", SqlDbType.VarChar, 20).Value = numcontroldet.numFinal;
                    oComando.Parameters.Add("@numCorrelativo", SqlDbType.VarChar, 20).Value = numcontroldet.numCorrelativo;
                    oComando.Parameters.Add("@cantDigNumero", SqlDbType.TinyInt).Value = numcontroldet.cantDigNumero;                    
					oComando.Parameters.Add("@fecInicio", SqlDbType.SmallDateTime).Value = numcontroldet.fecInicio;
					oComando.Parameters.Add("@fecFinal", SqlDbType.SmallDateTime).Value = numcontroldet.fecFinal;
					oComando.Parameters.Add("@indEstadoInicial", SqlDbType.Char, 1).Value = numcontroldet.indEstadoInicial;
					oComando.Parameters.Add("@idCondicion", SqlDbType.TinyInt).Value = numcontroldet.idCondicion;
					oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = numcontroldet.idVendedor;
					oComando.Parameters.Add("@idTransporte", SqlDbType.Int).Value = numcontroldet.idTransporte;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = numcontroldet.idMoneda;
					oComando.Parameters.Add("@idTipTraslado", SqlDbType.Int).Value = numcontroldet.idTipTraslado;
					oComando.Parameters.Add("@indEstadoDocu", SqlDbType.Char, 1).Value = numcontroldet.indEstadoDocu;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = numcontroldet.idAlmacen;
					oComando.Parameters.Add("@FlagCantUnit", SqlDbType.Bit).Value = numcontroldet.FlagCantUnit;
					oComando.Parameters.Add("@ListaPrecio", SqlDbType.Int).Value = numcontroldet.ListaPrecio;
					oComando.Parameters.Add("@idCliente", SqlDbType.Int).Value = numcontroldet.idCliente;
					oComando.Parameters.Add("@Formato", SqlDbType.VarChar, 50).Value = numcontroldet.Formato;
					oComando.Parameters.Add("@EsGuia", SqlDbType.Char, 1).Value = numcontroldet.EsGuia;
					oComando.Parameters.Add("@PuntoPartida", SqlDbType.VarChar, 100).Value = numcontroldet.PuntoPartida;
                    oComando.Parameters.Add("@PuntoLlegada", SqlDbType.VarChar, 100).Value = numcontroldet.PuntoLlegada;
					oComando.Parameters.Add("@PuntoVenta", SqlDbType.VarChar, 2).Value = numcontroldet.PuntoVenta;
					oComando.Parameters.Add("@TipoAsiento", SqlDbType.Char, 2).Value = numcontroldet.TipoAsiento;
					oComando.Parameters.Add("@cantCopias", SqlDbType.Int).Value = numcontroldet.cantCopias;
					oComando.Parameters.Add("@cantItems", SqlDbType.Int).Value = numcontroldet.cantItems;
					oComando.Parameters.Add("@numCaja", SqlDbType.VarChar, 2).Value = numcontroldet.numCaja;
					oComando.Parameters.Add("@numSerieCaja", SqlDbType.VarChar, 2).Value = numcontroldet.numSerieCaja;
					oComando.Parameters.Add("@EsContado", SqlDbType.Char, 1).Value = numcontroldet.EsContado;
					oComando.Parameters.Add("@ExigirGuia", SqlDbType.Bit).Value = numcontroldet.ExigirGuia;
					oComando.Parameters.Add("@ExigirDatos", SqlDbType.Bit).Value = numcontroldet.ExigirDatos;
                    oComando.Parameters.Add("@Grupo", SqlDbType.Char, 1).Value = numcontroldet.Grupo;
                    oComando.Parameters.Add("@cantDigDecimales", SqlDbType.Int).Value = numcontroldet.cantDigDecimales;
                    oComando.Parameters.Add("@cantCaracteres", SqlDbType.Int).Value = numcontroldet.cantCaracteres;
                    oComando.Parameters.Add("@Orden", SqlDbType.Int).Value = numcontroldet.Orden;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = numcontroldet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return numcontroldet;
        }

        public Int32 EliminarNumControlDet(Int32 idEmpresa, Int32 idLocal, Int32 idControl, Int32 item)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarNumControlDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idControl", SqlDbType.Int).Value = idControl;
                    oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<NumControlDetE> ListarNumControlDet(Int32 idEmpresa, Int32 idLocal, Int32 idControl)
        {
            List<NumControlDetE> listaEntidad = new List<NumControlDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarNumControlDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idControl", SqlDbType.Int).Value = idControl;

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
        
        public NumControlDetE ObtenerNumControlDet(Int32 idEmpresa, Int32 idLocal, Int32 idControl, Int32 item)
        {
            NumControlDetE numcontroldet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerNumControlDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idControl", SqlDbType.Int).Value = idControl;
                    oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            numcontroldet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return numcontroldet;
        }

        public NumControlDetE ObtenerNumControlDetPorIdDocumento(Int32 idEmpresa, Int32 idLocal, Int32 idControl, String idDocumento, String Serie)
        {
            NumControlDetE numcontroldet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerNumControlDetPorIdDocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idControl", SqlDbType.Int).Value = idControl;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 20).Value = Serie;
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            numcontroldet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return numcontroldet;
        }

        public List<NumControlDetE> ListarNumControlDetPorGrupo(Int32 idEmpresa, Int32 idLocal, String Grupo)
        {
            List<NumControlDetE> listaEntidad = new List<NumControlDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarNumControlDetPorGrupo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Grupo", SqlDbType.Char, 1).Value = Grupo;

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

        public List<NumControlDetE> ListarSeriesNumControlDet(Int32 idEmpresa, Int32 idLocal, Int32 idControl, String idDocumento)
        {
            List<NumControlDetE> listaEntidad = new List<NumControlDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarSeriesNumControlDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idControl", SqlDbType.Int).Value = idControl;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;

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

        public void ActualizarCorrelativoNumControlDet(Int32 idEmpresa, Int32 idLocal, String idDocumento, String Serie, String numCorrelativo)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCorrelativoNumControlDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 20).Value = Serie;
                    oComando.Parameters.Add("@numCorrelativo", SqlDbType.VarChar, 20).Value = numCorrelativo;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarCorrelativoNumControlDetRet(Int32 idEmpresa, Int32 idLocal, String idDocumento, String Serie, String numCorrelativo)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCorrelativoNumControlDetRet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 20).Value = Serie;
                    oComando.Parameters.Add("@numCorrelativo", SqlDbType.VarChar, 20).Value = numCorrelativo;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }

        public List<NumControlDetE> ListarNumControlDetPorEmpresa(Int32 idEmpresa, Int32 idLocal)
        {
            List<NumControlDetE> listaEntidad = new List<NumControlDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarNumControlDetPorEmpresa", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;

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

        public NumControlDetE NumControlDetTipoDocSerie(Int32 idEmpresa, Int32 idLocal, String idDocumento, String Serie)
        {
            NumControlDetE numcontroldet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_NumControlDetTipoDocSerie", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 20).Value = Serie;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            numcontroldet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return numcontroldet;
        }

    }
}