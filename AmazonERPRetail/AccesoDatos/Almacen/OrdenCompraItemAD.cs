using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class OrdenCompraItemAD : DbConection
    {

        public OrdenCompraItemE LlenarEntidad(IDataReader oReader)
        {
            OrdenCompraItemE ordencompraitem = new OrdenCompraItemE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenCompra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.idOrdenCompra = oReader["idOrdenCompra"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenCompra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.idItem = oReader["idItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.numItem = oReader["numItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticuloServ'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.idArticuloServ = oReader["idArticuloServ"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticuloServ"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.Lote = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaEntrega'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.FechaEntrega = oReader["FechaEntrega"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaEntrega"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CanOrdenada'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.CanOrdenada = oReader["CanOrdenada"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CanOrdenada"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CanIngresada'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.CanIngresada = oReader["CanIngresada"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CanIngresada"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='canProvisionada'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompraitem.canProvisionada = oReader["canProvisionada"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["canProvisionada"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impPrecioUnitario'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.impPrecioUnitario = oReader["impPrecioUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impPrecioUnitario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impVentaItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompraitem.impVentaItem = oReader["impVentaItem"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impVentaItem"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porDescuento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.porDescuento = oReader["porDescuento"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porDescuento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porIsc'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.porIsc = oReader["porIsc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porIsc"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impIsc'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.impIsc = oReader["impIsc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impIsc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompraitem.indIgv = oReader["indIgv"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porIgv'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.porIgv = oReader["porIgv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porIgv"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impIgv'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.impIgv = oReader["impIgv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impIgv"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impTotalItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.impTotalItem = oReader["impTotalItem"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impTotalItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desLarga'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.desLarga = oReader["desLarga"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desLarga"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUMedidaCompra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.idUMedidaCompra = oReader["idUMedidaCompra"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUMedidaCompra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desArticulo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.desArticulo = oReader["desArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desArticulo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PartidaArancelaria'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.PartidaArancelaria = oReader["PartidaArancelaria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PartidaArancelaria"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRecepcionFinal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.FechaRecepcionFinal = oReader["FechaRecepcionFinal"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRecepcionFinal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipEstadoAtencion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.tipEstadoAtencion = oReader["tipEstadoAtencion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipEstadoAtencion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipEstadoProvision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompraitem.tipEstadoProvision = oReader["tipEstadoProvision"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipEstadoProvision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indPasoProv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompraitem.indPasoProv = oReader["indPasoProv"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indPasoProv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impPrecioUltimaCompra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.impPrecioUltimaCompra = oReader["impPrecioUltimaCompra"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impPrecioUltimaCompra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numItemRequerimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.numItemRequerimiento = oReader["numItemRequerimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numItemRequerimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroParteProduccion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.nroParteProduccion = oReader["nroParteProduccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nroParteProduccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraitem.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompraitem.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompraitem.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompraitem.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompraitem.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nemo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompraitem.Nemo = oReader["Nemo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nemo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCategoria'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompraitem.codCategoria = oReader["codCategoria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCategoria"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCategoriaAsoc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompraitem.codCategoriaAsoc = oReader["codCategoriaAsoc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCategoriaAsoc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompraitem.indCCostos = oReader["indCCostos"] == DBNull.Value ? "N" : Convert.ToString(oReader["indCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompraitem.nomUMedida = oReader["nomUMedida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaPres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompraitem.nomUMedidaPres = oReader["nomUMedidaPres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaPres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaEnv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompraitem.nomUMedidaEnv = oReader["nomUMedidaEnv"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaEnv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Contenido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompraitem.Contenido = oReader["Contenido"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Contenido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PesoAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompraitem.PesoAlmacen = oReader["PesoAlmacen"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PesoAlmacen"]);

            return  ordencompraitem;        
        }

        public OrdenCompraItemE InsertarOrdenCompraItem(OrdenCompraItemE ordencompraitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarOrdenCompraItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordencompraitem.idEmpresa;
					oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = ordencompraitem.idOrdenCompra;
					oComando.Parameters.Add("@numItem", SqlDbType.VarChar, 4).Value = ordencompraitem.numItem;
					oComando.Parameters.Add("@idArticuloServ", SqlDbType.Int).Value = ordencompraitem.idArticuloServ;
					oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = ordencompraitem.Lote;
					oComando.Parameters.Add("@FechaEntrega", SqlDbType.SmallDateTime).Value = ordencompraitem.FechaEntrega;
					oComando.Parameters.Add("@CanOrdenada", SqlDbType.Decimal).Value = ordencompraitem.CanOrdenada;
					oComando.Parameters.Add("@CanIngresada", SqlDbType.Decimal).Value = ordencompraitem.CanIngresada;
                    oComando.Parameters.Add("@canProvisionada", SqlDbType.Decimal).Value = ordencompraitem.canProvisionada;
                    oComando.Parameters.Add("@impPrecioUnitario", SqlDbType.Decimal).Value = ordencompraitem.impPrecioUnitario;
                    oComando.Parameters.Add("@impVentaItem", SqlDbType.Decimal).Value = ordencompraitem.impVentaItem;
					oComando.Parameters.Add("@porDescuento", SqlDbType.Decimal).Value = ordencompraitem.porDescuento;
                    oComando.Parameters.Add("@impDscto", SqlDbType.Decimal).Value = ordencompraitem.impDscto;
                    oComando.Parameters.Add("@porIsc", SqlDbType.Decimal).Value = ordencompraitem.porIsc;
					oComando.Parameters.Add("@impIsc", SqlDbType.Decimal).Value = ordencompraitem.impIsc;
                    oComando.Parameters.Add("@indIgv", SqlDbType.Bit).Value = ordencompraitem.indIgv;
                    oComando.Parameters.Add("@porIgv", SqlDbType.Decimal).Value = ordencompraitem.porIgv;
					oComando.Parameters.Add("@impIgv", SqlDbType.Decimal).Value = ordencompraitem.impIgv;
					oComando.Parameters.Add("@impTotalItem", SqlDbType.Decimal).Value = ordencompraitem.impTotalItem;
					oComando.Parameters.Add("@desLarga", SqlDbType.VarChar, 800).Value = ordencompraitem.desLarga;
					oComando.Parameters.Add("@idUMedidaCompra", SqlDbType.Int).Value = ordencompraitem.idUMedidaCompra;
					oComando.Parameters.Add("@desArticulo", SqlDbType.VarChar, 100).Value = ordencompraitem.desArticulo;
					oComando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 20).Value = ordencompraitem.PartidaArancelaria;
					oComando.Parameters.Add("@FechaRecepcionFinal", SqlDbType.SmallDateTime).Value = ordencompraitem.FechaRecepcionFinal;
					oComando.Parameters.Add("@tipEstadoAtencion", SqlDbType.VarChar, 2).Value = ordencompraitem.tipEstadoAtencion;
					oComando.Parameters.Add("@impPrecioUltimaCompra", SqlDbType.Decimal).Value = ordencompraitem.impPrecioUltimaCompra;
					oComando.Parameters.Add("@numItemRequerimiento", SqlDbType.VarChar, 4).Value = ordencompraitem.numItemRequerimiento;
					oComando.Parameters.Add("@nroParteProduccion", SqlDbType.VarChar, 20).Value = ordencompraitem.nroParteProduccion;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = ordencompraitem.UsuarioRegistro;

                    oConexion.Open();
                    ordencompraitem.idItem = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return ordencompraitem;
        }
        
        public OrdenCompraItemE ActualizarOrdenCompraItem(OrdenCompraItemE ordencompraitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarOrdenCompraItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordencompraitem.idEmpresa;
					oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = ordencompraitem.idOrdenCompra;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = ordencompraitem.idItem;
					oComando.Parameters.Add("@numItem", SqlDbType.VarChar, 4).Value = ordencompraitem.numItem;
					oComando.Parameters.Add("@idArticuloServ", SqlDbType.Int).Value = ordencompraitem.idArticuloServ;
					oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = ordencompraitem.Lote;
					oComando.Parameters.Add("@FechaEntrega", SqlDbType.SmallDateTime).Value = ordencompraitem.FechaEntrega;
					oComando.Parameters.Add("@CanOrdenada", SqlDbType.Decimal).Value = ordencompraitem.CanOrdenada;
					oComando.Parameters.Add("@CanIngresada", SqlDbType.Decimal).Value = ordencompraitem.CanIngresada;
                    oComando.Parameters.Add("@canProvisionada", SqlDbType.Decimal).Value = ordencompraitem.canProvisionada;
                    oComando.Parameters.Add("@impPrecioUnitario", SqlDbType.Decimal).Value = ordencompraitem.impPrecioUnitario;
                    oComando.Parameters.Add("@impVentaItem", SqlDbType.Decimal).Value = ordencompraitem.impVentaItem;
					oComando.Parameters.Add("@porDescuento", SqlDbType.Decimal).Value = ordencompraitem.porDescuento;
                    oComando.Parameters.Add("@impDscto", SqlDbType.Decimal).Value = ordencompraitem.impDscto;
                    oComando.Parameters.Add("@porIsc", SqlDbType.Decimal).Value = ordencompraitem.porIsc;
					oComando.Parameters.Add("@impIsc", SqlDbType.Decimal).Value = ordencompraitem.impIsc;
                    oComando.Parameters.Add("@indIgv", SqlDbType.Bit).Value = ordencompraitem.indIgv;
                    oComando.Parameters.Add("@porIgv", SqlDbType.Decimal).Value = ordencompraitem.porIgv;
					oComando.Parameters.Add("@impIgv", SqlDbType.Decimal).Value = ordencompraitem.impIgv;
					oComando.Parameters.Add("@impTotalItem", SqlDbType.Decimal).Value = ordencompraitem.impTotalItem;
					oComando.Parameters.Add("@desLarga", SqlDbType.VarChar, 800).Value = ordencompraitem.desLarga;
					oComando.Parameters.Add("@idUMedidaCompra", SqlDbType.Int).Value = ordencompraitem.idUMedidaCompra;
					oComando.Parameters.Add("@desArticulo", SqlDbType.VarChar, 100).Value = ordencompraitem.desArticulo;
					oComando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 20).Value = ordencompraitem.PartidaArancelaria;
					oComando.Parameters.Add("@FechaRecepcionFinal", SqlDbType.SmallDateTime).Value = ordencompraitem.FechaRecepcionFinal;
					oComando.Parameters.Add("@tipEstadoAtencion", SqlDbType.VarChar, 2).Value = ordencompraitem.tipEstadoAtencion;
					oComando.Parameters.Add("@impPrecioUltimaCompra", SqlDbType.Decimal).Value = ordencompraitem.impPrecioUltimaCompra;
					oComando.Parameters.Add("@numItemRequerimiento", SqlDbType.VarChar, 4).Value = ordencompraitem.numItemRequerimiento;
					oComando.Parameters.Add("@nroParteProduccion", SqlDbType.VarChar, 20).Value = ordencompraitem.nroParteProduccion;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ordencompraitem.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ordencompraitem;
        }        

        public Int32 EliminarOrdenCompraItem(Int32 idEmpresa, Int32 idOrdenCompra)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarOrdenCompraItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = idOrdenCompra;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<OrdenCompraItemE> ListarOrdenCompraItem(Int32 idEmpresa, Int32 idOrdenCompra)
        {
            List<OrdenCompraItemE> listaEntidad = new List<OrdenCompraItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOrdenCompraItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = idOrdenCompra;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            OrdenCompraItemE entidad = LlenarEntidad(oReader);
                            entidad.CalculoCosto = false;
                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }

            return listaEntidad;
        }
        
        public OrdenCompraItemE ObtenerOrdenCompraItem(Int32 idEmpresa, Int32 idOrdenCompra, Int32 idItem)
        {
            OrdenCompraItemE ordencompraitem = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerOrdenCompraItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = idOrdenCompra;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ordencompraitem = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ordencompraitem;
        }

        public Int32 ActualizarCantIngOc(OrdenCompraItemE ordencompraitem)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCantIngOc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordencompraitem.idEmpresa;
                    oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = ordencompraitem.idOrdenCompra;
                    oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = ordencompraitem.idItem;
                    oComando.Parameters.Add("@idArticuloServ", SqlDbType.VarChar, 20).Value = ordencompraitem.idArticuloServ;
                    oComando.Parameters.Add("@CanIngresada", SqlDbType.Decimal).Value = ordencompraitem.CanIngresada;
                    oComando.Parameters.Add("@tipEstadoAtencion", SqlDbType.VarChar, 2).Value = ordencompraitem.tipEstadoAtencion;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ordencompraitem.UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 ActualizarCantProvOc(OrdenCompraItemE ordencompraitem)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCantProvOc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordencompraitem.idEmpresa;
                    oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = ordencompraitem.idOrdenCompra;
                    oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = ordencompraitem.idItem;
                    oComando.Parameters.Add("@idArticuloServ", SqlDbType.VarChar, 20).Value = ordencompraitem.idArticuloServ;
                    oComando.Parameters.Add("@canProvisionada", SqlDbType.Decimal).Value = ordencompraitem.canProvisionada;
                    oComando.Parameters.Add("@tipEstadoProvision", SqlDbType.VarChar, 2).Value = ordencompraitem.tipEstadoProvision;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ordencompraitem.UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}