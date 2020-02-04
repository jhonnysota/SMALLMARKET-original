using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Infraestructura.Enumerados
{
    [DataContract]
    public enum EnumGlobal
    {
      //[EnumMember]
      //  ClienteTanguis = 2155,
        [EnumMember]
        MarcaTanguis = 1,
        [EnumMember]
        Horma = 100
        //[EnumMember]
        //DireccionTanguis = 31
    }
}
