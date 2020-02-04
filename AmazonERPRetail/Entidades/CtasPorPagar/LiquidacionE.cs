using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.CtasPorPagar
{
    [DataContract]
    [Serializable]
    public partial class LiquidacionE
    {

        public LiquidacionE()
        {
            ListaLiquidacionDet = new List<LiquidacionDetE>();
        }

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public Int32 idLiquidacion { get; set; }

        [DataMember]
        public Int32 idPersona { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public String AnioPeriodo { get; set; }

        [DataMember]
        public String MesPeriodo { get; set; }

        [DataMember]
        public String idComprobante { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public String numVoucher { get; set; }

        [DataMember]
        public DateTime PeriodoIni { get; set; }

        [DataMember]
        public DateTime PeriodoFin { get; set; }

        [DataMember]
        public Int32 idOrdenPago { get; set; }

        [DataMember]
        public Boolean Estado { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
		public DateTime? FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
		public DateTime? FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public List<LiquidacionDetE> ListaLiquidacionDet { get; set; }

        [DataMember]
        public List<LiquidacionDetE> ListaEliminados{ get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String desEstado { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public String desTipoCuentaLiq { get; set; }

        [DataMember]
        public String TipoFondo { get; set; }

        [DataMember]
        public String Tipo168 { get; set; }

        [DataMember]
        public Decimal TotalLiqui { get; set; }

        [DataMember]
        public String codOrdenPago { get; set; }

        [DataMember]
        public String Titulo { get; set; }

        [DataMember]
        public String desEmpresa { get; set; }

    }
}