using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class Con_SaldosCostosE
    {
        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public String idCCostos { get; set; }

        [DataMember]
        public String AnioPeriodo { get; set; }

        [DataMember]
        public String MesPeriodo { get; set; }

        [DataMember]
        public Decimal SAL_ANTERIOR_SOLES { get; set; }

        [DataMember]
        public Decimal SAL_ANTERIOR_DOLARES { get; set; }

        [DataMember]
        public Decimal TOT_DEBE_SOLES { get; set; }

        [DataMember]
        public Decimal TOT_DEBE_DOLARES { get; set; }

        [DataMember]
        public Decimal TOT_HABER_SOLES { get; set; }

        [DataMember]
        public Decimal TOT_HABER_DOLARES { get; set; }

        [DataMember]
        public Decimal SAL_ACTUAL_SOLES { get; set; }

        [DataMember]
        public Decimal SAL_ACTUAL_DOLARES { get; set; }

        [DataMember]
        public Boolean IND_PROCESADO { get; set; }

        #region resumen Detalle Centro De Costo

        [DataMember]
        public String descripcion { get; set; }

        [DataMember]
        public String indNaturalezaCta { get; set; }

        [DataMember]
        public String desCosto { get; set; }

        #endregion
    }
}
