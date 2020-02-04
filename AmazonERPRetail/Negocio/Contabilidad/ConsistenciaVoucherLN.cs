using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using Infraestructura;
using System.Transactions;

namespace Negocio.Contabilidad
{
    public class ConsistenciaVoucherLN
    {
        public List<ConsistenciaVoucherE> ConsistenciaVoucher(Int32 idEmpresa, String ano_ini, String ano_fin, String mes_ini, String mes_fin)
        {
            try
            {
                return new ConsistenciaVoucherAD().ConsistenciaVoucher( idEmpresa, ano_ini, ano_fin, mes_ini, mes_fin);

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
        public List<ConsistenciaVoucherE> ConsistenciaVoucherDiferencia(Int32 idEmpresa, String ano, String mes)
        {
            try
            {
                return new ConsistenciaVoucherAD().ConsistenciaVoucherDiferencia( idEmpresa,  ano,  mes);

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
