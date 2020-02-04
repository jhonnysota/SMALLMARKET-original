using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Ventas;
using Entidades.Maestros;
using AccesoDatos.Ventas;

namespace Negocio.Ventas
{
    public class LetrasLN
    {

        public LetrasE InsertarLetras(LetrasE letras)
        {
            try
            {
                return new LetrasAD().InsertarLetras(letras);
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

        public LetrasE ActualizarLetras(LetrasE letras)
        {
            try
            {
                return new LetrasAD().ActualizarLetras(letras);
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

        //public int EliminarLetras(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String Numero, String Corre)
        //{
        //    try
        //    {
        //        return new LetrasAD().EliminarLetras(idEmpresa, idLocal, tipCanje, codCanje, Numero, Corre);
        //    }
        //    catch (SqlException ex)
        //    {
        //        SqlError err = ex.Errors[0];
        //        StringBuilder mensaje = new StringBuilder();

        //        switch (err.Number)
        //        {                    
        //            default:
        //                mensaje.Append("Mensaje: " + err.Message + "\n");
        //                mensaje.Append("N° Linea: " + err.LineNumber + "\n");
        //                mensaje.Append("Origen: " + err.Source + "\n");
        //                mensaje.Append("Procedimiento: " + err.Procedure + "\n");
        //                mensaje.Append("N° Error: " + err.Number);
        //                break;
        //        }

        //        throw new Exception(mensaje.ToString());
        //    }
        //}

        public List<LetrasE> ListarLetras(Int32 idEmpresa, Int32 idLocal, String tipCanje, Int32 idPersona, String Estado, String TipoFecha, DateTime fecIni, DateTime fecFinal)
        {
            try
            {
                return new LetrasAD().ListarLetras(idEmpresa, idLocal, tipCanje, idPersona, Estado, TipoFecha, fecIni, fecFinal);
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

        public LetrasE ObtenerLetras(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String Numero, String Corre, String ConFacturas = "N")
        {
            try
            {
                LetrasE LetraDevuelta = new LetrasAD().ObtenerLetras(idEmpresa, idLocal, tipCanje, codCanje, Numero, Corre);

                if (ConFacturas == "S")
                {
                    LetraDevuelta.ListaFacturas = new LetrasCanjeAD().ListarLetrasCanje(idEmpresa, idLocal, tipCanje, codCanje);
                }

                return LetraDevuelta;
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

        public List<LetrasE> ListarLetrasPorCanje(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje)
        {
            try
            {
                return new LetrasAD().ListarLetrasPorCanje(idEmpresa, idLocal, tipCanje, codCanje);
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

        public List<UbigeoE> ListarPlazas()
        {
            try
            {
                List<UbigeoE> oListaDepartamentos = new UbigeoAD().ListarDepartamentos();
                Int16 id = 1;

                foreach (UbigeoE item in oListaDepartamentos)
                {
                    item.idUbigeo = String.Format("{0:00}", id);
                    id++;
                }

                return oListaDepartamentos;
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

        public int ActualizarEstadoDeLetra(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String Numero, String Corre, Int32? idCtaCte, Int32? idCtaCteItem, String Estado, String UsuarioModificacion)
        {
            try
            {
                return new LetrasAD().ActualizarEstadoDeLetra(idEmpresa, idLocal, tipCanje, codCanje, Numero, Corre, idCtaCte, idCtaCteItem, Estado, UsuarioModificacion);
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
