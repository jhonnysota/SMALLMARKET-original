using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class DatosAuditoriaE
    {
        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public DateTime fecIni { get; set; }

        [DataMember]
        public DateTime fecFin { get; set; } 

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
        public String GlosaGeneral { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public String indDebeHaber { get; set; }

        [DataMember]
        public Decimal impSoles { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime FechaModificacion { get; set; }

    }
}
