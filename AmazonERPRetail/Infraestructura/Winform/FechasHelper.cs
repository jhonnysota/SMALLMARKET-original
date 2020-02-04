using System;
using System.Data;
using System.Globalization;

namespace Infraestructura.Winform
{
    public static class FechasHelper
    {

        public static String ObtenerPrimerdia()
        {
            String FechaInicial;
            Int32 MesActual = DateTime.Now.Month;
            Int32 AnioActual = DateTime.Now.Year;

            FechaInicial = ("01/" + MesActual.ToString("00") + "/" + AnioActual.ToString());

            return FechaInicial;
        }

        public static String ObtenerPrimerdia(String Mes, String Anio)
        {
            String FechaInicial;

            FechaInicial = ("01/" + Mes + "/" + Anio);

            return FechaInicial;
        }

        public static DateTime ObtenerUltimoDia(DateTime Fecha)
        {
            return Fecha.AddMonths(1).AddDays(-1);
            //var lastDayOfMonth = DateTime.DaysInMonth(date.Year, date.Month);
        }

        public static Int32 ObtenerDiasMes(Int32 Anio, Int32 Mes)
        {
            return DateTime.DaysInMonth(Anio, Mes);
        }

        public static String NombreMes(Int32 mes)
        {
            String NombreMes = "";

            if (mes == 0)
            {
                NombreMes = "APERTURA";
            }
            else if (mes == 13)
            {
                NombreMes = "CIERRE";
            }
            else
            {
                DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
                NombreMes = dtinfo.GetMonthName(mes);
            }

            return NombreMes;
        }

        public static String NumeroMes(String nomMes)
        {
            String Numero = "";

            if (nomMes.ToUpper() == "ENERO")
            {
                Numero = "01";
            }
            else if (nomMes.ToUpper() == "FEBRERO")
            {
                Numero = "02";
            }
            else if (nomMes.ToUpper() == "MARZO")
            {
                Numero = "03";
            }
            else if (nomMes.ToUpper() == "ABRIL")
            {
                Numero = "04";
            }
            else if (nomMes.ToUpper() == "MAYO")
            {
                Numero = "05";
            }
            else if (nomMes.ToUpper() == "JUNIO")
            {
                Numero = "06";
            }
            else if (nomMes.ToUpper() == "JULIO")
            {
                Numero = "07";
            }
            else if (nomMes.ToUpper() == "AGOSTO")
            {
                Numero = "08";
            }
            else if (nomMes.ToUpper() == "SETIEMBRE")
            {
                Numero = "09";
            }
            else if (nomMes.ToUpper() == "OCTUBRE")
            {
                Numero = "10";
            }
            else if (nomMes.ToUpper() == "NOVIEMBRE")
            {
                Numero = "11";
            }
            else
            {
                Numero = "12";
            }

            return Numero;
        }

        //public static String NombreMesCodInt(Int32 mes)
        //{
        //    String NombreMes = "";

        //        DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
        //        NombreMes = dtinfo.GetMonthName(mes);           

        //    return NombreMes;
        //}

        public static String NombreDia(DateTime Fecha)
        {
            return Fecha.ToString("dddd", new CultureInfo("es-ES"));
        }

        public static int NumeroDia(DateTime Fecha)
        {
            String Dia = Fecha.ToString("dddd", new CultureInfo("es-ES"));
            int nDia = -1;

            if (Dia.ToUpper().Equals("LUNES")) nDia = 1;
            if (Dia.ToUpper().Equals("MARTES")) nDia = 2;
            if (Dia.ToUpper().Equals("MIERCOLES")) nDia = 3;
            if (Dia.ToUpper().Equals("MIÉRCOLES")) nDia = 3;
            if (Dia.ToUpper().Equals("JUEVES")) nDia = 4;
            if (Dia.ToUpper().Equals("VIERNES")) nDia = 5;
            if (Dia.ToUpper().Equals("SABADO")) nDia = 6;
            if (Dia.ToUpper().Equals("SÁBADO")) nDia = 6;
            if (Dia.ToUpper().Equals("DOMINGO")) nDia = 7;

            return nDia;
        }

        public static DataTable CargarAnios(Int32 Desde, Int32 Hasta)
        {
            DataTable output = new DataTable();
            output.Columns.Add("AnioId");
            output.Columns.Add("AnioDes");

            for (Int32 i = Desde; i <= Hasta; i++)
            {
                DataRow dt;
                dt = output.NewRow();

                dt["AnioId"] = i;
                dt["AnioDes"] = i.ToString();

                output.Rows.Add(dt);
            }

            return output;
        }

        public static DataTable CargarMeses(Int32 Desde, Boolean ConCeroAdelante, String Tipo = "MA")
        {
            String mes = String.Empty;
            DataTable output = new DataTable();
            output.Columns.Add("MesId");
            output.Columns.Add("MesDes");

            if (Desde == 0)
            {
                return output;
            }
            else
            {
                for (Int32 i = Desde; i <= 12; i++)
                {
                    DateTime d = new DateTime(DateTime.Today.Year, i, 1);
                    DataRow dt;
                    dt = output.NewRow();

                    if (!ConCeroAdelante)
                    {
                        dt["MesId"] = i;
                    }
                    else
                    {
                        dt["MesId"] = String.Format("{0:00}", i);
                    }

                    //PM = Primera en mayuscula
                    //MA = Todas mayusculas
                    //MI = Todas minusculas
                    mes = String.Format("{0:MMMM}", d);

                    if (Tipo == "PM")
                    {
                        dt["MesDes"] = Global.PrimeraMayuscula(mes);
                    }
                    else if (Tipo == "MA")
                    {
                        dt["MesDes"] = mes.ToUpper();
                    }
                    else
                    {
                        dt["MesDes"] = mes.ToLower();
                    }

                    output.Rows.Add(dt);
                }

                return output;
            }
        }

        public static DataTable CargarMesesContable(String tipo)
        {
            DataTable output = new DataTable();
            output.Columns.Add("MesId");
            output.Columns.Add("MesDes");

            for (Int32 i = 0; i <= 13; i++)
            {
                DataRow dt;
                dt = output.NewRow();

                string mes;
                if (i > 0 && i < 13)
                {
                    DateTime d = new DateTime(DateTime.Today.Year, i, 1);
                    mes = String.Format("{0:MMMM}", d);
                }
                else if (i == 0)
                {
                    mes = "Apertura";
                }
                else
                {
                    mes = "Cierre";
                }

                //PM = Primera en mayúscula
                //MA = Todas mayúsculas
                //MI = Todas minúsculas
                dt["MesId"] = i.ToString("00");

                if (tipo == "PM")
                {
                    dt["MesDes"] = Global.PrimeraMayuscula(mes);
                }
                else if (tipo == "MA")
                {
                    dt["MesDes"] = mes.ToUpper();
                }
                else
                {
                    dt["MesDes"] = mes.ToLower();
                }

                output.Rows.Add(dt);
            }

            return output;
        }

        #region  Por Revisar

        public static Int32 CalcularDiasDeDiferencia(DateTime FechaIni, DateTime FechaFin)
        {
            TimeSpan Diferencia;
            Diferencia = FechaIni - FechaFin;

            return Diferencia.Days;
        }

        public static Int32 DiferenciaDias(DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                int[] DiasMes = new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

                DateTime FechaOrigen;
                DateTime FechaDestino;
                int Anio;
                int Mes;
                int Dia;
                int Incremento;

                //Determinamos cual es la fecha menor
                if (FechaIni > FechaFin)
                {
                    FechaOrigen = FechaFin;
                    FechaDestino = FechaIni;
                }
                else
                {
                    FechaOrigen = FechaIni;
                    FechaDestino = FechaFin;
                }

                // Calculamos los dias
                Incremento = 0;

                if (FechaOrigen.Day > FechaDestino.Day)
                {
                    Incremento = DiasMes[FechaOrigen.Month - 1];
                }

                if (Incremento == -1)
                {
                    if (DateTime.IsLeapYear(FechaOrigen.Year))
                    {
                        // Para los años bisiestos
                        Incremento = 29;
                    }
                    else
                    {
                        Incremento = 28;
                    }
                }

                if (Incremento != 0)
                {
                    Dia = (FechaDestino.Day + Incremento) - FechaOrigen.Day;
                    Incremento = 1;
                }
                else
                {
                    Dia = FechaDestino.Day - FechaOrigen.Day;
                }

                //Calculamos los meses
                if ((FechaOrigen.Month + Incremento) > FechaDestino.Month)
                {
                    Mes = (FechaDestino.Month + 12) - (FechaOrigen.Month + Incremento);
                    Incremento = 1;
                }
                else
                {
                    Mes = (FechaDestino.Month) - (FechaOrigen.Month + Incremento);
                    Incremento = 0;
                }

                ////Calculamos los años
                Anio = FechaDestino.Year - (FechaOrigen.Year + Incremento);
                //return Anio + " Año(s), " + Mes + " mes(es), " + Dia + " día(s)";

                return Dia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static String DiferenciaMeses(DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                int[] DiasMes = new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                DateTime FechaOrigen;
                DateTime FechaDestino;
                int Anio;
                int Mes;
                int Dia;
                int Incremento;

                //Determinamos cual es la fecha menor
                if (FechaIni > FechaFin)
                {
                    FechaOrigen = FechaFin;
                    FechaDestino = FechaIni;
                }
                else
                {
                    FechaOrigen = FechaIni;
                    FechaDestino = FechaFin;
                }

                // Calculamos los dias
                Incremento = 0;

                if (FechaOrigen.Day > FechaDestino.Day)
                {
                    Incremento = DiasMes[FechaOrigen.Month - 1];
                }

                if (Incremento == -1)
                {
                    if (DateTime.IsLeapYear(FechaOrigen.Year))
                    {
                        // Para los años bisiestos
                        Incremento = 29;
                    }
                    else
                    {
                        Incremento = 28;
                    }
                }

                if (Incremento != 0)
                {
                    Dia = (FechaDestino.Day + Incremento) - FechaOrigen.Day;
                    Incremento = 1;
                }
                else
                {
                    Dia = FechaDestino.Day - FechaOrigen.Day;
                }

                //Calculamos los meses
                if ((FechaOrigen.Month + Incremento) > FechaDestino.Month)
                {
                    Mes = (FechaDestino.Month + 12) - (FechaOrigen.Month + Incremento);
                    Incremento = 1;
                }
                else
                {
                    Mes = (FechaDestino.Month) - (FechaOrigen.Month + Incremento);
                    Incremento = 0;
                }
                //Calculamos los años
                Anio = FechaDestino.Year - (FechaOrigen.Year + Incremento);
                return Anio + " Año(s), " + Mes + " mes(es), " + Dia + " día(s)";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        #endregion

    }
}
