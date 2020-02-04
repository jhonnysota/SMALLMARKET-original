using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using Entidades.Maestros;
using AccesoDatos.Maestros;

namespace Negocio.Contabilidad
{
    public class RegistroComprasLN
    {

        public List<RegistroComprasE> RegistroDeComprasLe(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String idMoneda, String indComprasVarias)
        {
            try
            {   
                List<RegistroComprasE> oListaDeCompras = new RegistroComprasAD().RegistroDeComprasLe(idEmpresa, idLocal, fecIni, fecFin, idMoneda, indComprasVarias);
                Empresa oEmpresa = new EmpresaAD().RecuperarEmpresaPorID(idEmpresa);
                // Quitar los Recibos por Honorarios si no es Fontela ni Panaca
                if (oEmpresa.RUC != "20219613882" && oEmpresa.RUC != "20600628357")
                {
                    oListaDeCompras = (from x in oListaDeCompras where x.tipDocumentoVenta != "02" select x).ToList(); //sin 02 = Recibos por Honorarios
                }

                return oListaDeCompras;
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

        public List<RegistroComprasE> RegistroDeComprasLeNoDom(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String idMoneda)
        {
            try
            {
                List<RegistroComprasE> oListaDeCompras = new RegistroComprasAD().RegistroDeComprasLeNoDom(idEmpresa, idLocal, fecIni, fecFin, idMoneda);

                //Solo documentos de no domiciliados...
                oListaDeCompras = (from x in oListaDeCompras
                                   where x.tipDocumentoVenta == "91"
                                   || x.tipDocumentoVenta == "97"
                                   || x.tipDocumentoVenta == "98"
                                   select x).ToList();

                return oListaDeCompras;
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

        //Especial
        public List<RegistroComprasE> ReporteDetalleComprasEspecial(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String numVerPlanCuenta, String AnioPeriodo, String MesIni, String MesFin, String idMoneda)
        {
            try
            {
                return new RegistroComprasAD().ReporteDetalleComprasEspecial(idEmpresa, idLocal, idPersona, numVerPlanCuenta, AnioPeriodo, MesIni, MesFin, idMoneda);
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

        public List<RegistroComprasE> ReporteResumenComprasEspecial(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String numVerPlanCuenta, String AnioPeriodo, String MesIni, String MesFin, String idMoneda)
        {
            try
            {
                return new RegistroComprasAD().ReporteResumenComprasEspecial(idEmpresa, idLocal, idPersona, numVerPlanCuenta, AnioPeriodo, MesIni, MesFin, idMoneda);
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

        public List<RegistroComprasE> ReporteNaturalezaComprasEspecial(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String numVerPlanCuenta, String AnioPeriodo, String MesIni, String MesFin, String idMoneda)
        {
            try
            {
                return new RegistroComprasAD().ReporteNaturalezaComprasEspecial(idEmpresa, idLocal, idPersona, numVerPlanCuenta, AnioPeriodo, MesIni, MesFin, idMoneda);
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

        public List<RegistroComprasE> ReporteCuentaComprasEspecial(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String numVerPlanCuenta, String AnioPeriodo, String MesIni, String MesFin, String idMoneda)
        {
            try
            {
                return new RegistroComprasAD().ReporteCuentaComprasEspecial(idEmpresa, idLocal, idPersona, numVerPlanCuenta, AnioPeriodo, MesIni, MesFin, idMoneda);
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
