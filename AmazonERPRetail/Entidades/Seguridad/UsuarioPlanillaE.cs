using System;
using System.Runtime.Serialization;

namespace Entidades.Seguridad
{
    [DataContract]
    [Serializable]
    public class UsuarioPlanillaE
    {
            
        [DataMember]







        [DataMember]
        public Boolean VerRemun { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

    }   
}