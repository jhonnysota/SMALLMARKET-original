using System;
using System.Runtime.Serialization;

namespace Entidades.CtasPorPagar
{
    [DataContract]
    [Serializable]
    public partial class RetencionItemE
    {
        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public String serieCompRete { get; set; }

        [DataMember]
        public String numeroCompRete { get; set; }

        [DataMember]
        public String Item { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String serDocumento { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public DateTime fecDocumento { get; set; }

        [DataMember]
        public Decimal porcRetencion { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public Decimal MontoOrigen { get; set; }

        [DataMember]
        public Decimal MontoRetenidoOrigen { get; set; }

        [DataMember]
        public Decimal MontoSoles { get; set; }

        [DataMember]
        public Decimal MontoRetenidoSoles { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime FechaModificacion { get; set; }

        //Detalle
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String desDocumento { get; set; }
        
    }
}
