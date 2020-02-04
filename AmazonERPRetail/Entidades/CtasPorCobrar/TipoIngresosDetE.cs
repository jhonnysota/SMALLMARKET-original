using System;
using System.Runtime.Serialization;

namespace Entidades.CtasPorCobrar
{
    [DataContract]
    [Serializable]
    public partial class TipoIngresosDetE
    {

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public String TipoCobro { get; set; }

        [DataMember]
        public Int32 TipoPlanilla { get; set; }

        [DataMember]
        public String idComprobante { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String desTipoCobro { get; set; }

        [DataMember]
        public String desComprobante { get; set; }

        [DataMember]
        public String desTipoPlanilla { get; set; }

        [DataMember]
        public String desFile { get; set; }

    }
}
