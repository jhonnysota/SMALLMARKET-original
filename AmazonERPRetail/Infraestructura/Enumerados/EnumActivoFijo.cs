using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Infraestructura.Enumerados
{
    [DataContract]
    public enum EnumMetodo
    {
        [EnumMember]
        Metodo = 280000
    }

    [DataContract]
    public enum EnumClase
    {
        [EnumMember]
        Clase = 282000
    }
}
