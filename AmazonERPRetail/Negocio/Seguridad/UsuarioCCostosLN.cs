using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Seguridad;
using Entidades.Maestros;
using AccesoDatos.Ventas;

namespace Negocio.Seguridad
{
    public class UsuarioCCostosLN
    {
        public UsuarioCCostosE InsertarUsuarioCCostos(UsuarioCCostosE usuarioccostos)
        {
            try
            {
                return new UsuarioCCostosAD().InsertarUsuarioCCostos(usuarioccostos);
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

        public UsuarioCCostosE ActualizarUsuarioCCostos(UsuarioCCostosE usuarioccostos)
        {
            try
            {
                return new UsuarioCCostosAD().ActualizarUsuarioCCostos(usuarioccostos);
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

        public int EliminarUsuarioCCostos(Int32 idPersona)
        {
            try
            {
                return new UsuarioCCostosAD().EliminarUsuarioCCostos(idPersona);
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

        public List<UsuarioCCostosE> ListarUsuarioCCostos(Int32 idPersona, Int32 idEmpresa)
        {
            try
            {
                List<UsuarioCCostosE> oListaCCostosUsuario = null;

                if (idPersona == 0)
                {
                    Int32 Nivel = 0;
                    Nivel = new CCostosAD().MaxNivelCCostos(idEmpresa);
                    UsuarioCCostosE oCostos = null;
                    List<CCostosE> oLista = new CCostosAD().ListarCCostosPorNivel(idEmpresa, Nivel);
                    oListaCCostosUsuario = new List<UsuarioCCostosE>();

                    foreach (CCostosE item in oLista)
                    {
                        oCostos = new UsuarioCCostosE()
                        {
                            idPersona = idPersona,
                            idCCostos = item.idCCostos,
                            desCCostos = item.desCCostos
                        };

                        oListaCCostosUsuario.Add(oCostos);
                    }
                }
                else
                {
                    oListaCCostosUsuario = new UsuarioCCostosAD().ListarUsuarioCCostos(idPersona, idEmpresa);
                }

                return oListaCCostosUsuario;
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

        public UsuarioCCostosE ObtenerUsuarioCCostos(Int32 idPersona, Int32 idCCostos)
        {
            try
            {
                return new UsuarioCCostosAD().ObtenerUsuarioCCostos(idPersona, idCCostos);
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
