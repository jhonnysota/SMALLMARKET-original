using System.Runtime.Serialization;

namespace Infraestructura.Enumerados
{
    [DataContract]
    public enum EnumEstadoOC
    {
        PN, //Pendiente
        AT, //Aprobado Total
        CE, //OC Cerrado
        AN //Anulado
    }

    [DataContract]
    public enum EnumOrigenCompras
    {
        [EnumMember]
        ConRequision = 186001,

        [EnumMember]
        ConAdjudicacion = 186002,

        [EnumMember]
        SinRequesicion = 186003
    }

    [DataContract]
    public enum EnumEstadoAtencionOC
    { 
        PN, //OC Pendiente
        AT, //Atendido Total
        AP //Atendido Parcial
    }

    [DataContract]
    public enum EnumModalidadOC
    {
        [EnumMember]
        ComprasSS = 144001,

        [EnumMember]
        ComprasCS = 144002
    }
}
