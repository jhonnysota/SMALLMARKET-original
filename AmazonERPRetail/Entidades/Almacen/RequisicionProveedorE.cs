using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public class RequisicionProveedorE
    {
            
        [DataMember]







        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String DesPersona { get; set; }

    }   
}