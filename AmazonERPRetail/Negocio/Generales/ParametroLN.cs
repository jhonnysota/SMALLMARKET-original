using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using AccesoDatos.Generales;
using Entidades.Generales;

namespace Negocio.Generales
{
  public  class ParametroLN
  {

      public ParametroE GrabarParametro(ParametroE parametro)
      {
          try
          {
              if (parametro.IdParametro == 0)
              {
                  parametro.IdParametro = new ParametroAD().RecuperarMaxParametroPorIdEmpresa(parametro.IdEmpresa);
                  return new ParametroAD().InsertarParametro(parametro);
              }
              else
              {
                  return new ParametroAD().ActualizarParametro(parametro);
              }   
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

      public Int32 EliminarParametro(Int32 IdEmpresa, Int32 IdParametro, Int32 idUsuario)
      {
          try
          {
              return new ParametroAD().EliminarParametro(IdEmpresa, IdParametro, idUsuario);
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

      public List<ParametroE> ListarParametro()
      {
          try
          {
              return new ParametroAD().ListarParametro();
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

      public Int32 ActualizarEstadoParametro(int idEmpresa, int idParametro, bool estado, string usuarioModificacion, DateTime fechaModificacion)
      {
          try
          {
              return new ParametroAD().ActualizarEstadoParametro(idEmpresa, idParametro, estado, usuarioModificacion, fechaModificacion);
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

      public ParametroE ObtenerParametro(Int32 IdEmpresa, Int32 IdParametro, Int32 idUsuario)
      {
          try
          {
              return new ParametroAD().ObtenerParametro(IdEmpresa, IdParametro, idUsuario);
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

      public List<ParametroE> ListarParametroPorUsuario(Int32 IdEmpresa, Int32 idUsuario)
      {
          try
          {
              return new ParametroAD().ListarParametroPorUsuario(IdEmpresa, idUsuario);
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
