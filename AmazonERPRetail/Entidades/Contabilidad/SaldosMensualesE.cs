using System;
using System.Runtime.Serialization;


namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class SaldosMensualesE
    {
        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idPersona { get; set; }

        [DataMember]
        public String numVerPlanCuenta { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public String AnioPeriodo { get; set; }

        [DataMember]
        public String codCuentaIni { get; set; }

        [DataMember]
        public String codCuentaFin { get; set; }

        [DataMember]
        public Int32 NivelCuenta { get; set; }


        //Extensiones

        [DataMember]
        public String codCuenta { get; set; }

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
        public String desCuenta { get; set; }

        [DataMember]
        public String desPeriodo { get; set; }
                
        [DataMember]
        public String DES_PERIODO { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public Decimal Monto { get; set; }
        

    }
}
