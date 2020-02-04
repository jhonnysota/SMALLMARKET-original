using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using Infraestructura;
using System.Transactions;
using Infraestructura.Extensores;

namespace Negocio.Contabilidad
{
    public class RegistroVentasLN
    {
        public RegistroVentasE ActualizarRegistroVentas(RegistroVentasE registroventas)
        {
            try
            {
                return new RegistroVentasAD().ActualizarRegistroVentas(registroventas);
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

        public Int32 EliminarRegistroVentas(Int32 idRegistro)
        {
            try
            {
                return new RegistroVentasAD().EliminarRegistroVentas(idRegistro);
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

        public List<RegistroVentasE> ListarRegistroVentas()
        {
            try
            {
                return new RegistroVentasAD().ListarRegistroVentas();
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

        public RegistroVentasE ObtenerRegistroVentas(Int32 idRegistro)
        {
            try
            {
                return new RegistroVentasAD().ObtenerRegistroVentas(idRegistro);
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

        public Int32 InsertarRegistroVentasPorVolumen(List<RegistroVentasE> oListaVentas, DateTime fecInicial, DateTime fecFinal, Boolean Eliminar)
        {
            try
            {
                Int32 Reg = Variables.Cero;
                TransactionOptions Opciones = new TransactionOptions();
                Opciones.Timeout = TimeSpan.FromMinutes(120);

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    if (Eliminar)
                    {
                        //Elimando Registros de ventas por fechas
                        Reg = EliminarRegistroVentas(oListaVentas[0].idEmpresa, oListaVentas[0].idLocal, fecInicial, fecFinal);//new RegistroVentasAD().EliminarRegistroVentasPorFechas(oListaVentas[0].idEmpresa, oListaVentas[0].idLocal, fecInicial, fecFinal); 
                    }

                    //Insertando los registros nuevos...
                    using (DataTable oDt = Colecciones.ToDataTable<RegistroVentasE>(oListaVentas))
                    {
                        Reg = new RegistroVentasAD().InsertarRegistroVentas(oDt);    
                    }

                    //Cerrando la transaccion
                    oTrans.Complete();
                }

                return Reg;
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

        public List<RegistroVentasE> RegistroDeVentasLe(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String idMoneda)
        {
            try
            {
                return new RegistroVentasAD().RegistroDeVentasLe(idEmpresa, idLocal, fecIni, fecFin, idMoneda);
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

        private Int32 EliminarRegistroVentas(Int32 idEmpresa, Int32 idLocal, DateTime fecInicial, DateTime fecFinal)
        {
            Int32 Reg;

            using (TransactionScope oTrans = new TransactionScope())
            {
                //Elimando Registros de ventas por fechas
                Reg = new RegistroVentasAD().EliminarRegistroVentasPorFechas(idEmpresa, idLocal, fecInicial, fecFinal);
                
                //Cerrando la transaccion
                oTrans.Complete();
            }

            return Reg;
        }

        public List<RegistroVentasE> RegistroDeVentasDaot(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String idMoneda)
        {
            try
            {
                return new RegistroVentasAD().RegistroDeVentasDaot(idEmpresa, idLocal, fecIni, fecFin, idMoneda);
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
