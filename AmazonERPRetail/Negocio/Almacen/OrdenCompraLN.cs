using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;

using Entidades.Almacen;
using AccesoDatos.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;
using AccesoDatos.Maestros;

namespace Negocio.Almacen
{
    public class OrdenCompraLN
    {

        public OrdenCompraE GrabarOrdenDeCompra(OrdenCompraE OC, EnumOpcionGrabar Opcion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (Opcion == EnumOpcionGrabar.Insertar)
                    {
                        Int64 nroOrdenCompra = new OrdenCompraAD().GenerarNroOrdenCompra(OC.idEmpresa, OC.idLocal, Convert.ToDateTime(OC.fecEmision) , OC.TipoOrdenCompra);
                        OC.numOrdenCompra = nroOrdenCompra.ToString();

                        OC = new OrdenCompraAD().InsertarOrdenCompra(OC);

                        if (OC.ListaOrdenesCompras != null && OC.ListaOrdenesCompras.Count > 0)
                        {
                            foreach (OrdenCompraItemE item in OC.ListaOrdenesCompras)
                            {
                                item.idEmpresa = OC.idEmpresa;
                                item.idOrdenCompra = OC.idOrdenCompra;

                                new OrdenCompraItemAD().InsertarOrdenCompraItem(item);
                            }
                        }                        

                        if (OC.ListaDistribucion != null && OC.ListaDistribucion.Count > 0)
                        {
                            if (!OC.indDistribucion)
                            {
                                new OrdenCompraDistriAD().EliminarOrdenCompraDistri(OC.idEmpresa, OC.idOrdenCompra);
                            }
                            else
                            {
                                foreach (OrdenCompraDistriE item in OC.ListaDistribucion)
                                {
                                    item.idEmpresa = OC.idEmpresa;
                                    item.idOrdenCompra = OC.idOrdenCompra;
                                    new OrdenCompraDistriAD().InsertarOrdenCompraDistri(item);
                                }
                            }
                        }
                    }
                    else
                    {
                        Int32 Correlativo = Variables.ValorUno;
                        OC = new OrdenCompraAD().ActualizarOrdenCompra(OC);
                        new OrdenCompraItemAD().EliminarOrdenCompraItem(OC.idEmpresa, OC.idOrdenCompra);

                        if (OC.ListaOrdenesCompras != null && OC.ListaOrdenesCompras.Count > Variables.Cero)
                        {
                            foreach (OrdenCompraItemE item in OC.ListaOrdenesCompras)
                            {
                                item.idEmpresa = OC.idEmpresa;
                                item.idOrdenCompra = OC.idOrdenCompra;
                                item.numItem = String.Format("{0:0000}", Correlativo);

                                new OrdenCompraItemAD().InsertarOrdenCompraItem(item);
                                Correlativo++;
                            }
                        }

                        if (OC.ListaDistribucion != null && OC.ListaDistribucion.Count > 0)
                        {
                            Int32 resp = new OrdenCompraDistriAD().EliminarOrdenCompraDistri(OC.idEmpresa, OC.idOrdenCompra);

                            foreach (OrdenCompraDistriE item in OC.ListaDistribucion)
                            {
                                item.idEmpresa = OC.idEmpresa;
                                item.idOrdenCompra = OC.idOrdenCompra;
                                new OrdenCompraDistriAD().InsertarOrdenCompraDistri(item);
                            }
                        }
                    }

                    oTrans.Complete();
                }

                return OC;
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public OrdenCompraE ObtenerOrdenDeCompraCompleto(Int32 idEmpresa, Int32 idOrdenCompra, String VieneAlmacen = "N")
        {
            try
            {
                OrdenCompraE OrdenCompra = new OrdenCompraAD().ObtenerOrdenCompra(idEmpresa, idOrdenCompra);

                if (OrdenCompra != null)
                {
                    OrdenCompra.ListaOrdenesCompras = new OrdenCompraItemAD().ListarOrdenCompraItem(idEmpresa, idOrdenCompra);

                    foreach (OrdenCompraItemE item in OrdenCompra.ListaOrdenesCompras)
                    {
                        item.ArticuloServ = new ArticuloServAD().ObtenerArticuloServ(item.idEmpresa, item.idArticuloServ);
                    }

                    if (VieneAlmacen == Variables.SI)
                    {
                        List<OrdenCompraItemE> oListaOtros = new List<OrdenCompraItemE>(from x in OrdenCompra.ListaOrdenesCompras where x.Nemo == "O10" select x).ToList();

                        if (oListaOtros.Count > 0)
                        {
                            OrdenCompra.ListaOrdenesCompras = new List<OrdenCompraItemE>(OrdenCompra.ListaOrdenesCompras.Except(oListaOtros).ToList());

                            Decimal TotalInvoice = OrdenCompra.ListaOrdenesCompras.Sum(x => x.impTotalItem);
                            Decimal TotalCargos = oListaOtros.Sum(x => x.impTotalItem);
                            //var tmp = OrdenCompra.ListaOrdenesCompras.GroupBy(x => x.codCategoria).Select(y => new { codCategoria = y.Key, Total = y.Sum(x => x.impTotalItem) });

                            foreach (OrdenCompraItemE itemOtros in oListaOtros)
                            {
                                foreach (OrdenCompraItemE item in OrdenCompra.ListaOrdenesCompras)
                                {
                                    if (itemOtros.codCategoriaAsoc == item.codCategoria)
                                    {
                                        //Decimal totCategoria = Convert.ToDecimal((from x in tmp.ToList()
                                        //                                          where x.codCategoria == item.codCategoria
                                        //                                          select x.Total).Single());

                                        item.OtrosCargos = Decimal.Round((item.impTotalItem * TotalCargos) / TotalInvoice, 2);
                                        item.CostoTotal = item.impTotalItem + item.OtrosCargos;

                                        if (item.CanOrdenada - item.CanIngresada > 0)
                                        {
                                            item.PrecioCosto = item.CostoTotal / (item.CanOrdenada - item.CanIngresada);
                                        }
                                        else
                                        {
                                            item.PrecioCosto = 0;
                                        }

                                        item.CalculoCosto = true;
                                    }
                                }
                            }
                        }
                    }

                    OrdenCompra.ListaDistribucion = new OrdenCompraDistriAD().ListarOrdenCompraDistri(idEmpresa, idOrdenCompra); 
                }

                return OrdenCompra;
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public OrdenCompraE InsertarOrdenCompra(OrdenCompraE ordencompra)
        {
            try
            {
                return new OrdenCompraAD().InsertarOrdenCompra(ordencompra);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {                    
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public OrdenCompraE ActualizarOrdenCompra(OrdenCompraE ordencompra)
        {
            try
            {
                return new OrdenCompraAD().ActualizarOrdenCompra(ordencompra);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {                    
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public int EliminarOrdenCompra(Int32 idEmpresa, Int32 idOrdenCompra)
        {
            try
            {
                return new OrdenCompraAD().EliminarOrdenCompra(idEmpresa, idOrdenCompra);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {                    
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public List<OrdenCompraE> ListarOrdenCompra(Int32 idEmpresa, Int32 idLocal, Int32 idProveedor, DateTime fecIni, DateTime fecFin, string desProveedor, String TipoOrdenCompra)
        {
            try
            {
                return new OrdenCompraAD().ListarOrdenCompra(idEmpresa, idLocal, idProveedor, fecIni, fecFin, desProveedor, TipoOrdenCompra);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {                    
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public List<OrdenCompraE> ListarOrdenCompraActivos(Int32 idEmpresa, Int32 idLocal, Int32 idProveedor, DateTime fecIni, DateTime fecFin, string desProveedor, String tipEstado)
        {
            try
            {
                return new OrdenCompraAD().ListarOrdenCompraActivos(idEmpresa, idLocal, idProveedor, fecIni, fecFin,desProveedor, tipEstado);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public OrdenCompraE ActivarOrdenCompraActivos(OrdenCompraE ordencompra)
        {
            try
            {
                return new OrdenCompraAD().ActivarOrdenCompraActivos(ordencompra);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public OrdenCompraE ObtenerOrdenCompra(Int32 idEmpresa, Int32 idOrdenCompra)
        {
            try
            {
                return new OrdenCompraAD().ObtenerOrdenCompra(idEmpresa, idOrdenCompra);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {                    
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public List<OrdenCompraE> ListarOCPendientes(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String Filtro, string Tipo = "N")
        {
            try
            {
                return new OrdenCompraAD().ListarOCPendientes(idEmpresa, idLocal, fecIni, fecFin, Filtro, Tipo);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public Int32 ActualizarEstadoPorFacturar(Int32 idEmpresa, Int32 idLocal, Int32 idOrdenCompra, String tipEstadoPorFacturar, Decimal MontoRecepFactura, String UsuarioModificacion)
        {
            try
            {
                return new OrdenCompraAD().ActualizarEstadoPorFacturar(idEmpresa, idLocal, idOrdenCompra, tipEstadoPorFacturar, MontoRecepFactura, UsuarioModificacion);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public List<OrdenCompraE> ListarOrdenCompraPendientes(Int32 idEmpresa, Int32 tipo, Int32 idPersona)
        {
            try
            {
                return new OrdenCompraAD().ListarOrdenCompraPendientes(idEmpresa, tipo, idPersona);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public List<OrdenCompraE> OrdenCompraPorNotaIngreso(Int32 idEmpresa, String numVerPlanCuentas, string fecIni, string fecFin)
        {
            try
            {
                List<OrdenCompraE> oListaOCdevuelta = new List<OrdenCompraE>();
                List<OrdenCompraE> oListaOC = new OrdenCompraAD().OrdenCompraPorNotaIngreso(idEmpresa, numVerPlanCuentas, fecIni, fecFin);
                List<OrdenCompraE> oListaTemp = oListaOC.GroupBy(g => new { g.idOrdenCompra }).Select(g => new OrdenCompraE()
                {
                    idOrdenCompra = g.Key.idOrdenCompra,
                    impCostoS = g.Sum(x => x.impCostoS),
                    impCostoD = g.Sum(x => x.impCostoD),
                    impCostoTotS = g.Sum(x => x.impCostoTotS),
                    impCostoTotD = g.Sum(x => x.impCostoTotD),
                }).ToList();

                Int32 numOCTemp = oListaTemp != null ? oListaTemp[0].idOrdenCompra : 0;

                foreach (OrdenCompraE item in oListaOC)
                {
                    if (String.IsNullOrWhiteSpace(item.Voucher))
                    {
                        item.Cuenta = String.Empty;
                        item.CuentaDestino = String.Empty;
                    }

                    if (item.idOrdenCompra != numOCTemp)
                    {
                        OrdenCompraE ItemTotal = new OrdenCompraE()
                        {
                            numOrdenCompra = "X",
                            RazonSocial = String.Empty,
                            tipCompra = String.Empty,
                            idDocumentoAlmacen = 0,
                            numItem = String.Empty,
                            codArticulo = String.Empty,
                            desArticulo = String.Empty,
                            CanOrdenada = 0,
                            impCostoS = Convert.ToDecimal((from x in oListaTemp where x.idOrdenCompra == numOCTemp select x.impCostoS).First()),
                            impCostoD = Convert.ToDecimal((from x in oListaTemp where x.idOrdenCompra == numOCTemp select x.impCostoD).First()),
                            impCostoTotS = Convert.ToDecimal((from x in oListaTemp where x.idOrdenCompra == numOCTemp select x.impCostoTotS).First()),
                            impCostoTotD = Convert.ToDecimal((from x in oListaTemp where x.idOrdenCompra == numOCTemp select x.impCostoTotD).First()),
                        };

                        oListaOCdevuelta.Add(ItemTotal);
                        oListaOCdevuelta.Add(item);
                        numOCTemp = item.idOrdenCompra;
                    }
                    else
                    {
                        oListaOCdevuelta.Add(item);
                    }
                }

                OrdenCompraE ItemUltimo = new OrdenCompraE()
                {
                    numOrdenCompra = "X",
                    RazonSocial = String.Empty,
                    tipCompra = String.Empty,
                    idDocumentoAlmacen = 0,
                    numItem = String.Empty,
                    codArticulo = String.Empty,
                    desArticulo = String.Empty,
                    CanOrdenada = 0,
                    impCostoS = Convert.ToDecimal((from x in oListaTemp where x.idOrdenCompra == numOCTemp select x.impCostoS).First()),
                    impCostoD = Convert.ToDecimal((from x in oListaTemp where x.idOrdenCompra == numOCTemp select x.impCostoD).First()),
                    impCostoTotS = Convert.ToDecimal((from x in oListaTemp where x.idOrdenCompra == numOCTemp select x.impCostoTotS).First()),
                    impCostoTotD = Convert.ToDecimal((from x in oListaTemp where x.idOrdenCompra == numOCTemp select x.impCostoTotD).First()),
                };

                oListaOCdevuelta.Add(ItemUltimo);

                OrdenCompraE ItemGranTotal = new OrdenCompraE()
                {
                    numOrdenCompra = "XX",
                    RazonSocial = String.Empty,
                    tipCompra = String.Empty,
                    idDocumentoAlmacen = 0,
                    numItem = String.Empty,
                    codArticulo = String.Empty,
                    desArticulo = String.Empty,
                    CanOrdenada = 0,
                    impCostoS = Convert.ToDecimal((from x in oListaOCdevuelta where x.numOrdenCompra == "X" select x.impCostoS).Sum()),
                    impCostoD = Convert.ToDecimal((from x in oListaOCdevuelta where x.numOrdenCompra == "X" select x.impCostoD).Sum()),
                    impCostoTotS = Convert.ToDecimal((from x in oListaOCdevuelta where x.numOrdenCompra == "X" select x.impCostoTotS).Sum()),
                    impCostoTotD = Convert.ToDecimal((from x in oListaOCdevuelta where x.numOrdenCompra == "X" select x.impCostoTotD).Sum()),
                };

                oListaOCdevuelta.Add(ItemGranTotal);

                return oListaOCdevuelta;
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

    }
}
