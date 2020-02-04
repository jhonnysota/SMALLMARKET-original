using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades;
using AccesoDatos;
using Infraestructura;
using Entidades.Ventas;
using AccesoDatos.Ventas;
//using Negocio.Base;

namespace Negocio.Maestros
{
    public class ComisionesCalLN
    {
        public List<ComisionesCalE> CalculoComision(Int32 idEmpresa, Int32 idPeriodo, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {


                return new ComisionesCalAD().CalculoComision(idEmpresa, idPeriodo, FechaInicial, FechaFinal);

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

        public List<ComisionesCalE> PagarComision(Int32 idEmpresa, Int32 idPeriodoInicio, Int32 idPeriodoFinal, DateTime FechaProceso)
        {
            try
            {


                return new ComisionesCalAD().PagarComision(idEmpresa, idPeriodoInicio, idPeriodoFinal, FechaProceso);

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

        public ComisionesCalE ObtenerPeriodoComisioncal(Int32 idEmpresa, Int32 idPeriodo)
        {
            try
            {
                return new ComisionesCalAD().ObtenerPeriodoComisioncal(idEmpresa, idPeriodo);
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

        public List<ComisionesCalE> ListarComisionCal(Int32 idEmpresa, Int32 idPeriodo, Int32 idVendedor)
        {
            try
            {


                return new ComisionesCalAD().ListarComisionCal(idEmpresa, idPeriodo, idVendedor);

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

        public List<ComisionesCalE> ListarComisionPag(Int32 idEmpresa, Int32 idVendedor, DateTime FechaProceso)
        {
            try
            {


                return new ComisionesCalAD().ListarComisionPag(idEmpresa, idVendedor, FechaProceso);

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

        public List<ComisionesCalE> ListarComisionPendientePeriodo(Int32 idEmpresa, Int32 idPeriodoPago, String Estado, Int32 idVendedor)
        {
            try
            {


                return new ComisionesCalAD().ListarComisionPendientePeriodo(idEmpresa, idPeriodoPago, Estado, idVendedor);

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
