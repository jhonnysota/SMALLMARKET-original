using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Seguridad
{
    [DataContract]
    [Serializable]
    public partial class RolOpcion
    {

        [DataMember]
        public int IdRol { get; set; }

        [DataMember]
        public int IdOpcion { get; set; }

        [DataMember]
        public bool Acceso { get; set; }     

    }
}