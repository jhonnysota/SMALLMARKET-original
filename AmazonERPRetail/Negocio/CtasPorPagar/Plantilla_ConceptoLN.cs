using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Infraestructura;
using Entidades.CtasPorPagar;
using AccesoDatos.CtasPorPagar;
using Infraestructura.Enumerados;
using System.Transactions;
//using Negocio.Base;

namespace Negocio.CtasPorPagar
{
    public class Plantilla_ConceptoLN //: BaseLN
    {
        public Plantilla_ConceptoE GrabarPlantilla(Plantilla_ConceptoE PlantillaCompleta, EnumOpcionGrabar OpcionGrabacion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabacion)
                    {
                        case EnumOpcionGrabar.Insertar:

                            PlantillaCompleta = new Plantilla_ConceptoAD().InsertarPlantilla_Concepto(PlantillaCompleta);

                            if (PlantillaCompleta.ListaPlantillaItem != null && PlantillaCompleta.ListaPlantillaItem.Count > 0)
                            {
                                foreach (Plantilla_Concepto_itemE item in PlantillaCompleta.ListaPlantillaItem)
                                {
                                    item.idEmpresa = PlantillaCompleta.idEmpresa;
                                    item.idPlantilla = PlantillaCompleta.idPlantilla;

                                    new Plantilla_Concepto_itemAD().InsertarPlantilla_Concepto_item(item);
                                }
                            }


                            break;
                        case EnumOpcionGrabar.Actualizar:

                            PlantillaCompleta = new Plantilla_ConceptoAD().ActualizarPlantilla_Concepto(PlantillaCompleta);

                            if (PlantillaCompleta.ListaPlantillaItem != null && PlantillaCompleta.ListaPlantillaItem.Count > 0)
                            {
                                new Plantilla_Concepto_itemAD().EliminarPlantilla_Concepto_item(PlantillaCompleta.idEmpresa, PlantillaCompleta.idPlantilla);

                                foreach (Plantilla_Concepto_itemE item in PlantillaCompleta.ListaPlantillaItem)
                                {
                                    item.idEmpresa = PlantillaCompleta.idEmpresa;
                                    item.idPlantilla = PlantillaCompleta.idPlantilla;

                                    //item.idItem = corItem;

                                    new Plantilla_Concepto_itemAD().InsertarPlantilla_Concepto_item(item);
                                    //corItem++;
                                }
                            }


                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return PlantillaCompleta;
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

        public Plantilla_ConceptoE InsertarPlantilla_Concepto(Plantilla_ConceptoE plantilla_concepto)
        {
            try
            {
                return new Plantilla_ConceptoAD().InsertarPlantilla_Concepto(plantilla_concepto);
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

        public Plantilla_ConceptoE ActualizarPlantilla_Concepto(Plantilla_ConceptoE plantilla_concepto)
        {
            try
            {
                return new Plantilla_ConceptoAD().ActualizarPlantilla_Concepto(plantilla_concepto);
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

        public int EliminarPlantilla_Concepto(Int32 idEmpresa, Int32 idPlantilla)
        {
            try
            {
                return new Plantilla_ConceptoAD().EliminarPlantilla_Concepto(idEmpresa, idPlantilla);
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

        public List<Plantilla_ConceptoE> ListarPlantilla_Concepto(Int32 idEmpresa)
        {
            try
            {
                return new Plantilla_ConceptoAD().ListarPlantilla_Concepto(idEmpresa);
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

        public Plantilla_ConceptoE ObtenerPlantilla_Concepto(Int32 idEmpresa, Int32 idPlantilla)
        {
            try
            {

                return new Plantilla_ConceptoAD().ObtenerPlantilla_Concepto(idEmpresa, idPlantilla);
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

        public Plantilla_ConceptoE RecuperarPlantilla_ConceptoPorId(Int32 idEmpresa, Int32 idPlantilla)
        {
            try
            {
                //Cabecera
                Plantilla_ConceptoE oPlantilla = new Plantilla_ConceptoAD().RecuperarPlantilla_ConceptoPorId(idEmpresa, idPlantilla);
                ////Detalle
                oPlantilla.ListaPlantillaItem = new Plantilla_Concepto_itemAD().RecuperarPlantilla_Concepto_itemPorId(idEmpresa, idPlantilla);
                
                return oPlantilla;
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
