using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using AccesoDatos.Generales;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;

namespace Negocio.Generales
{
    public class ParTablaLN
    {

        public Int32 InsertarParTabla(ParTabla partabla)
        {
            try 
	        {
                if (!String.IsNullOrEmpty(partabla.NemoTecnico.Trim()))
                {
                    ParTabla oParTabla = new ParTablaAD().ParTablaPorNemo(partabla.NemoTecnico);

                    if (oParTabla != null)
                    {
                        throw new Exception(String.Format("El Nemotecnico ingresado {0} ya existe en {1} con código {2}", oParTabla.NemoTecnico, oParTabla.Nombre, oParTabla.IdParTabla));
                    }
                }

		        partabla.FechaModificacion = DateTime.Now;
                partabla.FechaRegistro = DateTime.Now;
                return new ParTablaAD().InsertarParTabla(partabla);
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

        public Int32 ActualizarParTabla(ParTabla partabla)
        {
            try 
	        {
                if (!String.IsNullOrEmpty(partabla.NemoTecnico.Trim()))
                {
                    if (partabla.NemoTecnico != partabla.NemoTemp)
                    {
                        ParTabla oParTabla = new ParTablaAD().ParTablaPorNemo(partabla.NemoTecnico);

                        if (oParTabla != null)
                        {
                            throw new Exception(String.Format("El Nemotecnico ingresado {0} ya existe en {1} con código {2}", oParTabla.NemoTecnico, oParTabla.Nombre, oParTabla.IdParTabla));
                        } 
                    }
                }

                return new ParTablaAD().ActualizarParTabla(partabla);
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

        public List<ParTabla> ListarParTablaCabecera(String parametro)
        {
            try 
	        {	        
		        return new ParTablaAD().ListarParTablaCabecera(parametro);
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

        public List<ParTabla> ListarParTabla(String parametro, Boolean activo, Boolean inactivo)
        {
            try 
	        {	        
		        return new ParTablaAD().ListarParTabla(parametro, activo, inactivo);
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

        public List<ParTabla> ListarParTablaPorGrupo(Int32 grupo, String parametro)
        {
            try 
	        {	        
		        return new ParTablaAD().ListarParTablaPorGrupo(grupo, parametro);
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

        public Int32 AnularParTabla(Int32 idPartabla)
        {
            try 
	        {	        
		        return new ParTablaAD().AnularParTabla(idPartabla);
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

        public ParTabla RecuperarParTablaPorId(Int32 idPartabla)
        {
            try 
	        {	        
		        return new ParTablaAD().RecuperarParTablaPorId(idPartabla);
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

        public Int32 RecuperarMaxIdParTablaPorGrupo(Int32 grupo)
        {
            try 
	        {	        
		        return new ParTablaAD().RecuperarMaxIdParTablaPorGrupo(grupo);
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

        public Int32 RecuperarMaxGrupoPartabla()
        {
            try 
	        {	        
		        return new ParTablaAD().RecuperarMaxGrupoPartabla();
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

        public String RecuperarNombreGrupoParTabla(Int32 IdParTabla)
        {
            try 
	        {	        
		        return new ParTablaAD().RecuperarNombreGrupoParTabla(IdParTabla);
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

        public Dictionary<EnumParTabla, List<ParTabla>> ListarParTablaPorListaGrupo(List<EnumParTabla> listaGrupo)
        {
            try 
	        {	        
		        return new ParTablaAD().ListarParTablaPorListaGrupo(listaGrupo);
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

        public List<ParTabla> RecuperarParTablaPorEnumerado(EnumParTabla enumParTabla, Boolean todos)
        {
            try 
	        {	        
		        List<ParTabla> lista = new ParTablaAD().ListarParTablaPorGrupo((Int32)enumParTabla, "");

                if (todos)
                {
                    lista.Insert(0, CargarParTablaCero());
                }

                return lista;
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

        public Dictionary<EnumParTabla, List<ParTabla>> RecuperarParTablaPorGrupoEnumeradoOpcionVacio(Dictionary<EnumParTabla, Boolean> listaEnumParTabla)
        {
            try 
	        {	        
		        List<EnumParTabla> lista = new List<EnumParTabla>();

                foreach (var item in listaEnumParTabla)
                {
                    lista.Add(item.Key);
                }

                Dictionary<EnumParTabla, List<ParTabla>> listaRes = new ParTablaAD().ListarParTablaPorListaGrupo(lista);

                foreach (var item in listaRes)
                {
                    if ((from x in listaEnumParTabla where (Int32)x.Key == (Int32)item.Key && x.Value select x).Count() > 0)
                    {
                        item.Value.Insert(0, CargarParTablaCero());
                    }
                }
                return listaRes;
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

        public ParTabla CargarParTablaCero()
        {
            return new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Todos };
        }

        public List<ParTabla> ListarParTablaxGrupoXestado(Int32 grupo, Boolean activo, Boolean inactivo)
        {
            try 
	        {	        
		        return new ParTablaAD().ListarParTablaxGrupoXestado(grupo, activo, inactivo);
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

        public List<ParTabla> ListarParTablaCorrelativo()
        {
            try
            {
                return new ParTablaAD().ListarParTablaCorrelativo();
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

        public List<ParTabla> ListarParTablaEnlace(Int32 ValorCadena)
        {
            try
            {
                return new ParTablaAD().ListarParTablaEnlace(ValorCadena);
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

        public List<ParTabla> ListarParTablaTemperaturas(Int32 grupo)
        {
            try
            {
                return new ParTablaAD().ListarParTablaTemperaturas(grupo);
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

        public List<ParTabla> ListarParTablaPorNemo(String NemoTecnico)
        {
            try
            {
                return new ParTablaAD().ListarParTablaPorNemo(NemoTecnico);
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

        public Int32 ObtenerIdCalibre(String NemoTecnico)
        {
            try
            {
                return new ParTablaAD().ObtenerIdCalibre(NemoTecnico);
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

        public Int32 ObtenerIdCategoria(String Nombre)
        {
            try
            {
                return new ParTablaAD().ObtenerIdCategoria(Nombre);
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

        public Int32 ObtenerIdColor(String Descripcion)
        {
            try
            {
                return new ParTablaAD().ObtenerIdColor(Descripcion);
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

        public ParTabla ParTablaPorNemo(String NemoTecnico)
        {
            try
            {
                return new ParTablaAD().ParTablaPorNemo(NemoTecnico);
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

        public List<ParTabla> ListarParTablaPorValorCadena(String ValorCadena)
        {
            try
            {
                return new ParTablaAD().ListarParTablaPorValorCadena(ValorCadena);
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

        public List<ParTabla> ListarParTablaPorValorEntero(Int32 ValorEntero)
        {
            try
            {
                return new ParTablaAD().ListarParTablaPorValorEntero(ValorEntero);
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
