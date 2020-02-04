using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Infraestructura.Enumerados
{
    [DataContract]
    public enum EnumMarca
    {
        [EnumMember]
        MOLECA = 1,
        [EnumMember]
        BEIRA_RIO = 2,
        [EnumMember]
        VIZZANO = 3,
        [EnumMember]
        MOLEKINHA = 4,
        [EnumMember]
        KILDARE = 5,
        [EnumMember]
        COCA_COLA = 6,
        [EnumMember]
        MODARE = 7,
        [EnumMember]
        BR_SPORT = 8
    }
}
