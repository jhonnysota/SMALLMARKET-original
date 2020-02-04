using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

using Entidades.Maestros;
using AccesoDatos.Maestros;
using Infraestructura.Enumerados;
using Infraestructura;
using System.Transactions;

namespace Negocio.Maestros
{
    public class ArticuloServLN
    {

        public ArticuloServE GrabarArticuloServ(ArticuloServE articulo, EnumOpcionGrabar Opcion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (Opcion == EnumOpcionGrabar.Insertar)
                    {
                        //Insertando el articulo
                        articulo = new ArticuloServAD().InsertarArticuloServ(articulo);

                        //Insertando detalle si hubiera
                        if (articulo.ListaArticuloCaracteristica != null && articulo.ListaArticuloCaracteristica.Count > 0)
                        {
                            foreach (ArticuloDetalleE oitem in articulo.ListaArticuloCaracteristica)
                            {
                                oitem.idArticulo = articulo.idArticulo;
                                new ArticuloDetalleAD().InsertarArticuloDetalle(oitem);
                            }
                        }
                    }
                    else
                    {
                        //Actualizando el articulo
                        new ArticuloServAD().ActualizarArticuloServ(articulo);

                        //Actualizando detalle si hubiera
                        if (articulo.ListaArticuloCaracteristica != null && articulo.ListaArticuloCaracteristica.Count > 0)
                        {
                            foreach (ArticuloDetalleE oitem in articulo.ListaArticuloCaracteristica)
                            {
                                oitem.idArticulo = articulo.idArticulo;

                                switch (oitem.Opcion)
                                {
                                    case (Int32)EnumOpcionGrabar.Insertar:
                                        new ArticuloDetalleAD().InsertarArticuloDetalle(oitem);
                                        break;
                                    case (Int32)EnumOpcionGrabar.Actualizar:
                                        new ArticuloDetalleAD().ActualizarArticuloDetalle(oitem);
                                        break;
                                    case (Int32)EnumOpcionGrabar.Eliminar:
                                        new ArticuloDetalleAD().EliminarArticuloDetalle(oitem.idEmpresa, oitem.idArticulo, oitem.idCaracteristica);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        if (!String.IsNullOrEmpty(articulo.NombreReal) && !String.IsNullOrEmpty(articulo.NombreImagen) && !String.IsNullOrEmpty(articulo.Extension))
                        {
                            if (articulo.RutaImagen != null)
                            {
                                String RutaFisica = articulo.RutaImagen;

                                Image MiImagen = Global.ObtenerByteImagen(articulo.Imagen);
                                if (!Directory.Exists(RutaFisica))
                                {
                                    Directory.CreateDirectory(RutaFisica);
                                }

                                RutaFisica += @"\" + articulo.NombreImagen + articulo.Extension;

                                if (articulo.Imagen != null)
                                {
                                    Global.EscribirImagenEnFile(articulo.Imagen, RutaFisica);
                                }
                            }
                        }
                    }

                    oTrans.Complete();
                }

                return articulo;
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

        public ArticuloServE ObtenerImagenArticulo(ArticuloServE Articulo)
        {
            try
            {
                string RutaFisica = Articulo.RutaImagen;
                RutaFisica += @"\" + Articulo.NombreImagen + Articulo.Extension;

                byte[] fileBytes = File.ReadAllBytes(RutaFisica);
                Articulo.Imagen = fileBytes;

                if (File.Exists(RutaFisica))
                {
                    File.WriteAllBytes(RutaFisica, Articulo.Imagen);
                }

                return Articulo;
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

        public ArticuloServE BorrarImagenArticulo(ArticuloServE Articulo)
        {
            try
            {
                if (Articulo.Imagen != null)
                {
                    if (Articulo != null)
                    {
                        if (File.Exists(Articulo.RutaImagen + Articulo.Archivo))
                        {
                            File.Delete(Articulo.RutaImagen + Articulo.Archivo);

                        }
                    }
                }

                return Articulo;
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

        public ArticuloServE BorrarImagenArticuloLocal(ArticuloServE Articulo)
        {
            try
            {
                if (Articulo.Imagen != null)
                {
                    if (Articulo != null)
                    {
                        if (File.Exists(Articulo.RutaFisica + Articulo.Archivo))
                        {
                            File.Delete(Articulo.RutaFisica + Articulo.Archivo);
                        }
                    }
                }
                
                return Articulo;
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

        public ArticuloServE InsertarArticuloServ(ArticuloServE articuloserv)
        {
            try
            {
                return new ArticuloServAD().InsertarArticuloServ(articuloserv);
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

        public ArticuloServE ActualizarArticuloServ(ArticuloServE articuloserv)
        {
            try
            {
                return new ArticuloServAD().ActualizarArticuloServ(articuloserv);
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

        public List<ArticuloServE> ListarArticuloServ(Int32 idEmpresa, Int32 idTipoArticulo, String codCategoria, string nomArticulo, Boolean Incluir)
        {
            try
            {
                return new ArticuloServAD().ListarArticuloServ(idEmpresa, idTipoArticulo, codCategoria, nomArticulo, Incluir);
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

        public List<ArticuloServE> ListarArticuloServDetalle(Int32 idEmpresa, Int32 idTipoArticulo, Int32 idTipo, String codCategoria, Boolean Incluir)
        {
            try
            {
                return new ArticuloServAD().ListarArticuloServDetalle(idEmpresa, idTipoArticulo, idTipo, codCategoria, Incluir);
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

        public List<ArticuloServE> ListarArticulosBusqueda(Int32 idEmpresa, Int32 idTipoArticulo, String Filtro)
        {
            try
            {
                return new ArticuloServAD().ListarArticulosBusqueda(idEmpresa, idTipoArticulo,Filtro);
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

        public Int32 EliminarArticuloServ(Int32 idEmpresa, Int32 idArticulo)
        {
            try
            {
                return new ArticuloServAD().EliminarArticuloServ(idEmpresa, idArticulo);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    case 547:
                        mensaje.Append("El articulo no se puede eliminar porque se encuentra relacionado con otras tablas.");

                        break;
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

        public ArticuloServE ObtenerArticuloServ(Int32 idEmpresa, Int32 idArticulo)
        {
            try
            {
                return new ArticuloServAD().ObtenerArticuloServ(idEmpresa, idArticulo);
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

        public ArticuloServE ObteneridArticuloPorCodArticulo(Int32 idEmpresa, String CodArticulo)
        {
            try
            {
                return new ArticuloServAD().ObteneridArticuloPorCodArticulo(idEmpresa,CodArticulo);
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

        public List<ArticuloServE> BuscarArticuloDescripcion(Int32 idEmpresa, String descripcion)
        {
            try
            {
                return new ArticuloServAD().BuscarArticuloDescripcion(idEmpresa, descripcion);
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

        public List<ArticuloServE> ArticuloReporteExportacion(Int32 idEmpresa, Int32 tipoArticulo)
        {
            try
            {
                return new ArticuloServAD().ArticuloReporteExportacion(idEmpresa, tipoArticulo);
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

        public List<ArticuloServE> ListarArticuloServReporte(Int32 idEmpresa, Int32 idTipoArticulo)
        {
            try
            {
                return new ArticuloServAD().ListarArticuloServReporte(idEmpresa, idTipoArticulo);
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

        public Int32 AnularArticuloServ(Int32 idEmpresa, Int32 idArticulo)
        {
            try
            {
                return new ArticuloServAD().AnularArticuloServ(idEmpresa, idArticulo);
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

        public Int32 CorrelativoArticulo(Int32 idEmpresa, String codCategoria)
        {
            try
            {
                return new ArticuloServAD().CorrelativoArticulo(idEmpresa, codCategoria);
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

        public ArticuloServE ObtenerArticuloPorCodBarra(Int32 idEmpresa, String CodBarra)
        {
            try
            {
                return new ArticuloServAD().ObtenerArticuloPorCodBarra(idEmpresa, CodBarra);
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

        public List<ArticuloServE> ListarArticulosPorFiltro(Int32 idEmpresa, Int32 idTipoArticulo, String codArticulo, String nomArticulo)
        {
            try
            {
                return new ArticuloServAD().ListarArticulosPorFiltro(idEmpresa, idTipoArticulo, codArticulo, nomArticulo);
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

        public List<ArticuloServE> ListarArticulosPorFiltroArticuloYLote(Int32 idEmpresa, Int32 idTipoArticulo, String codArticulo, String nomArticulo, String Lote)
        {
            try
            {
                return new ArticuloServAD().ListarArticulosPorFiltroArticuloYLote(idEmpresa, idTipoArticulo, codArticulo, nomArticulo, Lote);
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

        public List<ArticuloServE> ListarArticulosPV(Int32 idEmpresa, String Nemo, Int32 idListaPrecio)
        {
            try
            {
                return new ArticuloServAD().ListarArticulosPV(idEmpresa, Nemo, idListaPrecio);
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

        public List<ArticuloServE> ListarCodBarrasArticuloServ(List<ArticuloServE> oListaArticulo)
        {
            try
            {
                //List<ArticuloServE> oListaRetorno = new List<ArticuloServE>();

                foreach (ArticuloServE item in oListaArticulo)
                {
                    item.Barras = new ArticuloServAD().ObtenerCodigoBarras(item.idEmpresa, item.idArticulo);
                }

                return oListaArticulo;
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

        public List<ArticuloServE> ArticulosPorListaPrecio(Int32 idEmpresa, Int32 idTipoArticulo, String codArticulo, String nomArticulo, Int32 idListaPrecio)
        {
            try
            {
                return new ArticuloServAD().ArticulosPorListaPrecio(idEmpresa, idTipoArticulo, codArticulo, nomArticulo, idListaPrecio);
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

        public List<ArticuloServE> ArticulosPorListaPrecioStock(Int32 idEmpresa, Int32 idAlmacen, Int32 idTipoArticulo, String Anio, String Mes, String codArticulo, String nomArticulo, Int32 idListaPrecio, Boolean conLote)
        {
            try
            {
                return new ArticuloServAD().ArticulosPorListaPrecioStock(idEmpresa, idAlmacen, idTipoArticulo, Anio, Mes, codArticulo, nomArticulo, idListaPrecio, conLote);
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

        public List<ArticuloServE> ArticulosPorArticuloCodArticulo(Int32 idEmpresa, Int32 idAlmacen, String Anio, String Mes, Int32 idArticulo, String codArticulo)
        {
            try
            {
                return new ArticuloServAD().ArticulosPorArticuloCodArticulo(idEmpresa, idAlmacen, Anio, Mes, idArticulo, codArticulo);
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

        public List<ArticuloServE> ArticulosPorListaPrecioStock2(Int32 idEmpresa, String Anio, String Mes, Int32 idListaPrecio, string nomArticulo, int idAlmacen)
        {
            try
            {
                return new ArticuloServAD().ArticulosPorListaPrecioStock2(idEmpresa, Anio, Mes, idListaPrecio, nomArticulo, idAlmacen);
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

        public List<ArticuloServE> ArticulosListaPrecioStockPa(Int32 idEmpresa, String Anio, String Mes, Int32 idListaPrecio, string PrincipioActivo, int idAlmacen)
        {
            try
            {
                return new ArticuloServAD().ArticulosListaPrecioStockPa(idEmpresa, Anio, Mes, idListaPrecio, PrincipioActivo, idAlmacen);
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

        /************************************************************************************ CALZADOS **********************************************************************************************/

        public ArticuloServE GrabarArticuloCalzado(ArticuloServE articulo, EnumOpcionGrabar Opcion)
        {
            try
            {
                if (Opcion == EnumOpcionGrabar.Insertar)
                {
                    //Insertando el articulo
                    articulo = new ArticuloServAD().InsertarArticuloCalzado(articulo);   
                }
                else
                {
                    //Actualizando el articulo
                    new ArticuloServAD().ActualizarArticuloCalzado(articulo);

                    if (!String.IsNullOrEmpty(articulo.NombreReal) && !String.IsNullOrEmpty(articulo.NombreImagen) && !String.IsNullOrEmpty(articulo.Extension))
                    {
                        if (articulo.RutaImagen != null)
                        {
                            string RutaFisica = articulo.RutaImagen;
                            Image MiImagen = Global.ObtenerByteImagen(articulo.Imagen);

                            if (!Directory.Exists(RutaFisica))
                            {
                                Directory.CreateDirectory(RutaFisica);
                            }

                            RutaFisica += @"\" + articulo.NombreImagen + articulo.Extension;

                            if (articulo.Imagen != null)
                            {
                                Global.EscribirImagenEnFile(articulo.Imagen, RutaFisica);
                            }
                        }
                    }
                }

                return articulo;
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

        public ArticuloServE ObtenerArticuloCalzado(Int32 idEmpresa, Int32 idArticulo)
        {
            try
            {
                return new ArticuloServAD().ObtenerArticuloCalzado(idEmpresa, idArticulo);
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

        public List<ArticuloServE> ListarArticuloCalzado(Int32 idEmpresa, Int32 idTipoArticulo, String codCategoria, Boolean Incluir)
        {
            try
            {
                return new ArticuloServAD().ListarArticuloCalzado(idEmpresa, idTipoArticulo, codCategoria, Incluir);
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

        public List<ArticuloServE> ListarArtiCalzadoBusqueda(Int32 idEmpresa, Int32 idTipoArticulo, String Filtro, Int32 codMarca, Int32 codModelo)
        {
            try
            {
                return new ArticuloServAD().ListarArtiCalzadoBusqueda(idEmpresa, idTipoArticulo, Filtro, codMarca, codModelo);
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

        public List<ArticuloServE> ListarArtiCalzadoBusqueda2(Int32 idEmpresa, Int32 idTipoArticulo, String Filtro, Int32 codMarca, Int32 codModelo)
        {
            try
            {
                return new ArticuloServAD().ListarArtiCalzadoBusqueda2(idEmpresa, idTipoArticulo, Filtro, codMarca, codModelo);
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

        public ArticuloServE ObtenerArticuloPorCodArticulo(Int32 idEmpresa, String CodArticulo)
        {
            try
            {
                return new ArticuloServAD().ObtenerArticuloPorCodArticulo(idEmpresa, CodArticulo);
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
