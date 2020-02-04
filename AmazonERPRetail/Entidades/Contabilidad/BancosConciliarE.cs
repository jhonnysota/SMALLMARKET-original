using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class BancosConciliarE
    {








        [DataMember]
        public Int32? idLocal { get; set; }

        [DataMember]
        public String AnioPeriodo { get; set; }

        [DataMember]
        public String MesPeriodo { get; set; }

        [DataMember]
        public String numVoucher { get; set; }

        [DataMember]
        public String idComprobante { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public String numItem { get; set; }

        [DataMember]
        public String CodCuenta { get; set; }

        //Extensiones
        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public Boolean Conciliado { get; set; }

        [DataMember]
        public Boolean chkEscoger { get; set; } //Para el check de conciliados manualmente en contabilidad...

    }   
}