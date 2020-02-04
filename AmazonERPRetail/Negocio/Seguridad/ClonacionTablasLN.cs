using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Seguridad;
using AccesoDatos.Seguridad;
using Infraestructura;

namespace Negocio.Seguridad
{
    public class ClonacionTablasLN
    {
        public ClonacionTablasE InsertarClonacionTablas(ClonacionTablasE clonaciontablas)
        {
            try
            {
                return new ClonacionTablasAD().InsertarClonacionTablas(clonaciontablas);
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

        public ClonacionTablasE ActualizarClonacionTablas(ClonacionTablasE clonaciontablas)
        {
            try
            {
                return new ClonacionTablasAD().ActualizarClonacionTablas(clonaciontablas);
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

        public Int32 EliminarClonacionTablas(Int32 idTabla)
        {
            try
            {
                return new ClonacionTablasAD().EliminarClonacionTablas(idTabla);
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

        public List<ClonacionTablasE> ListarClonacionTablas()
        {
            try
            {
                return new ClonacionTablasAD().ListarClonacionTablas();
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

        public ClonacionTablasE ObtenerClonacionTablas(Int32 idTabla)
        {
            try
            {
                return new ClonacionTablasAD().ObtenerClonacionTablas(idTabla);
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

        public Int32 GrabarVarios(List<ClonacionTablasE> oListaTablas)
        {
            String Tabla = String.Empty;
            Int32 resp = 0;

            try
            {
                foreach (ClonacionTablasE item in oListaTablas)
                {
                    Tabla = item.TablaReal;
                    new ClonacionTablasAD().InsertarClonacionTablas(item);
                    resp++;
                }

                return resp;
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    case 2627:
                        mensaje.Append(String.Format("La tabla {0} ya ha sido ingresada, vuelva a intentarlo otra vez.", Tabla));

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

        public List<ClonacionTablasE> ListarTablasPorSistema(Int32 idSistema)
        {
            try
            {
                return new ClonacionTablasAD().ListarTablasPorSistema(idSistema);
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

        public List<ClonacionTablasE> ListarTablasTransferidas(Int32 idEmpresaTrans, Boolean Transferido)
        {
            try
            {
                return new ClonacionTablasAD().ListarTablasTransferidas(idEmpresaTrans, Transferido);
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

        public Int32 ClonarTablas(List<ClonacionTablasE> oListaTablasPorTransferir)
        {
            Int32 resp = 0;
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    foreach (ClonacionTablasE item in oListaTablasPorTransferir)
                    {
                        new ClonacionTablasAD().ClonarTablas(Convert.ToInt32(item.idEmpresa), Convert.ToInt32(item.idEmpresaTrans), item.TablaReal, item.ListaColumnas);
                        new ClonacionTablasAD().ActualizarClonacionTablas(item);
                        resp++;
                    }

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

        public Int32 EliminarTablasTransferidas(Int32 idEmpresaTrans, String Tabla)
        {
            try
            {
                return new ClonacionTablasAD().EliminarTablasTransferidas(idEmpresaTrans, Tabla);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    case 547:
                        mensaje.Append("No puede eliminar esta tabla por estar relacionada con otras tablas. Siga la secuencia de mayor a menor.");
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

    }
}
