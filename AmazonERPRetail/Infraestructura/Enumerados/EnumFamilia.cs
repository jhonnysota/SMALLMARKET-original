using System.Runtime.Serialization;

namespace Infraestructura.Enumerados
{
    [DataContract]
    public enum EnumFamilia
    {
        [EnumMember]
        Mercaderia = 0500,
        [EnumMember]
        Insumos = 0100,
        [EnumMember]
        TarjetaProduccion = 0200,
        //[EnumMember] //PARA DESARROLLO
        //Horma = 01070,
        [EnumMember]// PARA PRODUCCION
        Horma = 0600,
        [EnumMember]
        Falsa = 01050,
        [EnumMember]
        Taco = 01030,
        [EnumMember]
        CalzadoDama = 050101,
        [EnumMember]
        CarterasDama = 050102,
        [EnumMember]
        BilleterasDama = 050103,
        [EnumMember]
        MonederosDama = 050104,
        [EnumMember]
        CalzadoCaballero = 050201,
        [EnumMember]
        CalzadoNino = 050301


    }
}
