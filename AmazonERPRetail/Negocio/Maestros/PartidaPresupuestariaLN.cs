using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Maestros;
using AccesoDatos.Ventas;

namespace Negocio.Maestros
{
    public class PartidaPresupuestariaLN
    {
        public PartidaPresupuestariaE InsertarPartidaPresupuestaria(PartidaPresupuestariaE partidapresupuestaria)
        {
            try
            {
                return new PartidaPresupuestariaAD().InsertarPartidaPresupuestaria(partidapresupuestaria);
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

        public PartidaPresupuestariaE ActualizarPartidaPresupuestaria(PartidaPresupuestariaE partidapresupuestaria)
        {
            try
            {
                return new PartidaPresupuestariaAD().ActualizarPartidaPresupuestaria(partidapresupuestaria);
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

        public Int32 EliminarPartidaPresupuestaria(Int32 idEmpresa, String tipPartidaPresu, String codPartidaPresu)
        {
            try
            {
                return new PartidaPresupuestariaAD().EliminarPartidaPresupuestaria(idEmpresa, tipPartidaPresu, codPartidaPresu);
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

        public List<PartidaPresupuestariaE> ListarPartidaPresupuestaria()
        {
            try
            {
                return new PartidaPresupuestariaAD().ListarPartidaPresupuestaria();
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

        public PartidaPresupuestariaE ListarPartidaPresupuestariaPorCodigo(Int32 idEmpresa, String codPartidaPresu)
        {
            try
            {
                return new PartidaPresupuestariaAD().ListarPartidaPresupuestariaPorCodigo(idEmpresa, codPartidaPresu);
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


        public PartidaPresupuestariaE ObtenerPartidaPresupuestaria(Int32 idEmpresa, String tipPartidaPresu, String codPartidaPresu)
        {
            try
            {
                return new PartidaPresupuestariaAD().ObtenerPartidaPresupuestaria(idEmpresa, tipPartidaPresu, codPartidaPresu);
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

        public List<PartidaPresupuestariaE> ListarPartidaPresupuestariaPorTipo(Int32 idEmpresa, String tipPartidaPresu, String desPartidaPresu, Int32 numNivel)
        {
            try
            {
                return new PartidaPresupuestariaAD().ListarPartidaPresupuestariaPorTipo(idEmpresa, tipPartidaPresu, desPartidaPresu, numNivel);
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

        public Int32 ObtenerNivelPartida(Int32 idEmpresa)
        {
            try
            {
                return new PartidaPresupuestariaAD().ObtenerNivelPartida(idEmpresa);
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

        public Int32 EliminarPartidaPresupuestariaTodo(Int32 idEmpresa, String tipPartidaPresu, String codPartidaPresuSup)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    //Eliminando el detalle
                    resp = new PartidaPresupuestariaAD().EliminarPartidaPresupuestariaDetalle(idEmpresa, tipPartidaPresu, codPartidaPresuSup);
                    //Eliminando la cabecera
                    resp += new PartidaPresupuestariaAD().EliminarPartidaPresupuestaria(idEmpresa, tipPartidaPresu, codPartidaPresuSup);

                    oTrans.Complete();
                }

                return resp;
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
