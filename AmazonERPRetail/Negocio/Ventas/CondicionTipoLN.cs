using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Ventas;
using AccesoDatos.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;

namespace Negocio.Maestros
{
    public class CondicionTipoLN 
    {

        public CondicionTipoE GrabarCondicionTipo(CondicionTipoE CondicionTipo, EnumOpcionGrabar OpcionGrabacion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabacion)
                    {
                        case EnumOpcionGrabar.Insertar:

                            CondicionTipo = new CondicionTipoAD().InsertarCondicionTipo(CondicionTipo);

                            if (CondicionTipo.ListaCondicionTipo != null && CondicionTipo.ListaCondicionTipo.Count > 0)
                            {
                                foreach (CondicionE item in CondicionTipo.ListaCondicionTipo)
                                {
                                    item.idTipCondicion = CondicionTipo.idTipCondicion;
                                    new CondicionAD().InsertarCondicion(item);

                                    if (item.ListaDias.Count > Variables.Cero)
                                    {
                                        foreach (CondicionDiasE Dia in item.ListaDias)
                                        {
                                            Dia.idTipCondicion = item.idTipCondicion;
                                            Dia.idCondicion = item.idCondicion;

                                            new CondicionDiasAD().InsertarCondicionDias(Dia);
                                        }
                                    }
                                }
                            }

                            break;
                        case EnumOpcionGrabar.Actualizar:

                            CondicionTipo = new CondicionTipoAD().ActualizarCondicionTipo(CondicionTipo);

                            if (CondicionTipo.ListaCondicionTipo != null && CondicionTipo.ListaCondicionTipo.Count > 0)
                            {
                                foreach (CondicionE item in CondicionTipo.ListaCondicionTipo)
                                {
                                    item.idTipCondicion = CondicionTipo.idTipCondicion;

                                    if (item.Opcion == (Int32)EnumOpcionGrabar.Actualizar)
                                    {
                                        new CondicionAD().ActualizarCondicion(item);

                                        if (item.ListaDias != null)
                                        {
                                            new CondicionDiasAD().EliminarCondicionDias(item.idTipCondicion, item.idCondicion);

                                            foreach (CondicionDiasE Dia in item.ListaDias)
                                            {
                                                Dia.idTipCondicion = item.idTipCondicion;
                                                Dia.idCondicion = item.idCondicion;
                                                new CondicionDiasAD().InsertarCondicionDias(Dia);
                                            }
                                        }
                                    }
                                    else if (item.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                                    {
                                        Int32 idCondicionDev = new CondicionAD().MaxCondicion(item.idTipCondicion);
                                        idCondicionDev++;
                                        item.idCondicion = idCondicionDev;
                                        new CondicionAD().InsertarCondicion(item);

                                        if (item.ListaDias != null)
                                        {
                                            foreach (CondicionDiasE Dia in item.ListaDias)
                                            {
                                                Dia.idTipCondicion = item.idTipCondicion;
                                                Dia.idCondicion = item.idCondicion;
                                                new CondicionDiasAD().InsertarCondicionDias(Dia);
                                            }
                                        }
                                    }
                                }
                            }                                                     

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return CondicionTipo;
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

        public List<CondicionTipoE> ListarCondicionTipo()
        {
            try
            {
                return new CondicionTipoAD().ListarCondicionTipo();
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

        public CondicionTipoE ObtenerCondicionTipoCompleto(Int32 idTipCondicion)
        {
            try
            {
                CondicionTipoE CondicionTipo = new CondicionTipoAD().ObtenerCondicionTipo(idTipCondicion);
                CondicionTipo.ListaCondicionTipo = new CondicionAD().ListarCondicionPorTipo(idTipCondicion);

                foreach (CondicionE item in CondicionTipo.ListaCondicionTipo)
                {
                    if (item.indDias)
                    {
                        item.ListaDias = new CondicionDiasAD().ListarCondicionDias(item.idTipCondicion, item.idCondicion);
                    }
                }

                return CondicionTipo;
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
    

