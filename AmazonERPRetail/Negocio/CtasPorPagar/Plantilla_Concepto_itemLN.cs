using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades;
using AccesoDatos;
using Infraestructura;
using Entidades.CtasPorPagar;
using AccesoDatos.CtasPorPagar;
//using Negocio.Base;

namespace Negocio.CtasPorPagar
{
    public class Plantilla_Concepto_itemLN //: BaseLN
    {
        public Plantilla_Concepto_itemE InsertarPlantilla_Concepto_item(Plantilla_Concepto_itemE plantilla_concepto_item)
        {
            try
            {
                return new Plantilla_Concepto_itemAD().InsertarPlantilla_Concepto_item(plantilla_concepto_item);
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

        public Plantilla_Concepto_itemE ActualizarPlantilla_Concepto_item(Plantilla_Concepto_itemE plantilla_concepto_item)
        {
            try
            {
                return new Plantilla_Concepto_itemAD().ActualizarPlantilla_Concepto_item(plantilla_concepto_item);
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

        public int EliminarPlantilla_Concepto_item(Int32 idEmpresa, Int32 idPlantilla )
        {
            try
            {
                return new Plantilla_Concepto_itemAD().EliminarPlantilla_Concepto_item(idEmpresa, idPlantilla);
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

        public List<Plantilla_Concepto_itemE> ListarPlantilla_Concepto_item()
        {
            try
            {
                return new Plantilla_Concepto_itemAD().ListarPlantilla_Concepto_item();
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

        public Plantilla_Concepto_itemE ObtenerPlantilla_Concepto_item(Int32 idEmpresa, Int32 idPlantilla, Int32 idItem)
        {
            try
            {
                return new Plantilla_Concepto_itemAD().ObtenerPlantilla_Concepto_item(idEmpresa, idPlantilla, idItem);
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
