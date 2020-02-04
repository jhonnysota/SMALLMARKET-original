using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Maestros;
using AccesoDatos.Maestros;
using Infraestructura.Enumerados;

namespace Negocio.Maestros
{
    public class ImpresionBarrasLN
    {

        public ImpresionBarrasE InsertarImpresionBarras(ImpresionBarrasE impresionbarras)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    impresionbarras = new ImpresionBarrasAD().InsertarImpresionBarras(impresionbarras);

                    if (impresionbarras.oListaArticulos != null)
                    {
                        foreach (ImpresionBarrasDetE itemDet in impresionbarras.oListaArticulos)
                        {
                            itemDet.idImpresion = impresionbarras.idImpresion;
                            new ImpresionBarrasDetAD().InsertarImpresionBarrasDet(itemDet);

                            if (itemDet.oListaBarras != null)
                            {
                                foreach (ImpresionBarrasDetDetE item in itemDet.oListaBarras)
                                {
                                    item.idImpresion = itemDet.idImpresion;
                                    item.idArticulo = itemDet.idArticulo;
                                    new ImpresionBarrasDetDetAD().InsertarImpresionBarrasDetDet(item);
                                }
                            }
                        }
                    }

                    oTrans.Complete();
                }

                return impresionbarras;
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

        public ImpresionBarrasE ActualizarImpresionBarras(ImpresionBarrasE impresionbarras)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    impresionbarras = new ImpresionBarrasAD().ActualizarImpresionBarras(impresionbarras);

                    if (impresionbarras.oListaArticulos != null)
                    {
                        //Revisando si existe algun Item eliminado para borrar tambien su detalle
                        if (impresionbarras.oListaArticulosEliminados != null && impresionbarras.oListaArticulosEliminados.Count > 0)
                        {
                            //Recorriendo los Items eliminados
                            foreach (ImpresionBarrasDetE item in impresionbarras.oListaArticulosEliminados)
                            {
                                //Recorriendo el detalle del Item
                                foreach (ImpresionBarrasDetDetE itemDet in item.oListaBarras)
                                {
                                    //Eliminando el detalle del Item
                                    new ImpresionBarrasDetDetAD().EliminarImpresionBarrasDetDet(itemDet.idImpresion, itemDet.idArticulo, itemDet.Item);
                                }

                                //Eliminando el Item
                                new ImpresionBarrasDetAD().EliminarImpresionBarrasDet(item.idImpresion, item.idArticulo);
                            }
                        }

                        //Recorriendo los Items para su actualización
                        foreach (ImpresionBarrasDetE item in impresionbarras.oListaArticulos)
                        {
                            //Revisando si hay eliminadas en el detalle del Item
                            if (item.oListaBarrasEliminadas != null && item.oListaBarrasEliminadas.Count > 0)
                            {
                                //Recorriendo el detalle del Item
                                foreach (ImpresionBarrasDetDetE itemDet in item.oListaBarrasEliminadas)
                                {
                                    //Eliminando el detalle del Item
                                    new ImpresionBarrasDetDetAD().EliminarImpresionBarrasDetDet(itemDet.idImpresion, itemDet.idArticulo, itemDet.Item);
                                }
                            }

                            switch (item.Opcion)
                            {
                                case (Int32)EnumOpcionGrabar.Insertar:

                                    item.idImpresion = impresionbarras.idImpresion;
                                    new ImpresionBarrasDetAD().InsertarImpresionBarrasDet(item);

                                    if (item.oListaBarras != null)
                                    {
                                        foreach (ImpresionBarrasDetDetE itemDet in item.oListaBarras)
                                        {
                                            itemDet.idImpresion = item.idImpresion;
                                            itemDet.idArticulo = item.idArticulo;
                                            new ImpresionBarrasDetDetAD().InsertarImpresionBarrasDetDet(itemDet);
                                        }
                                    }

                                    break;
                                case (Int32)EnumOpcionGrabar.Actualizar:

                                    item.idImpresion = impresionbarras.idImpresion;
                                    new ImpresionBarrasDetAD().ActualizarImpresionBarrasDet(item);

                                    if (item.oListaBarras != null)
                                    {
                                        foreach (ImpresionBarrasDetDetE itemDet in item.oListaBarras)
                                        {
                                            itemDet.idImpresion = item.idImpresion;
                                            itemDet.idArticulo = item.idArticulo;

                                            switch (itemDet.Opcion)
                                            {
                                                case (Int32)EnumOpcionGrabar.Insertar:
                                                    new ImpresionBarrasDetDetAD().InsertarImpresionBarrasDetDet(itemDet);
                                                    break;

                                                case (Int32)EnumOpcionGrabar.Actualizar:
                                                    new ImpresionBarrasDetDetAD().ActualizarImpresionBarrasDetDet(itemDet);
                                                    break;
                                            }
                                        }
                                    }

                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    oTrans.Complete();
                }

                return impresionbarras;
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

        public int EliminarImpresionBarras(Int32 idImpresion)
        {
            try
            {
                return new ImpresionBarrasAD().EliminarImpresionBarras(idImpresion);
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

        public List<ImpresionBarrasE> ListarImpresionBarras(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                return new ImpresionBarrasAD().ListarImpresionBarras(idEmpresa, idLocal, fecIni, fecFin);
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

        public ImpresionBarrasE ObtenerImpresionBarras(Int32 idImpresion)
        {
            try
            {
                ImpresionBarrasE oImpresion = new ImpresionBarrasAD().ObtenerImpresionBarras(idImpresion);

                if (oImpresion != null)
                {
                    oImpresion.oListaArticulos = new ImpresionBarrasDetAD().ListarImpresionBarrasDet(idImpresion);

                    if (oImpresion.oListaArticulos != null && oImpresion.oListaArticulos.Count > 0)
                    {
                        foreach (ImpresionBarrasDetE item in oImpresion.oListaArticulos)
                        {
                            item.oListaBarras = new ImpresionBarrasDetDetAD().ListarImpresionBarrasDetDet(idImpresion, item.idArticulo);
                        }
                    }
                }

                return oImpresion;
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
