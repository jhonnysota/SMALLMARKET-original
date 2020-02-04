using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Infraestructura.Enumerados
{
    [DataContract]
    public enum EnumArea
    {
        [EnumMember]
        AreaProduccion = 1
    }
    [DataContract]
    public enum EnumAreaProductiva
    {
        //PARA PRODUCCION
        [EnumMember]
        Prefinito = 4,
        [EnumMember]
        Corte = 1
        //PARA DESARROLLO
        //[EnumMember]
        //Prefinito = 5
    }
}
