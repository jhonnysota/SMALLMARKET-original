using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class LibroConcarE
    {
            
        [DataMember]









        //Extensiones        
        [DataMember]
        public String IdComprobanteDes { get; set; }

        [DataMember]
        public String numFileDes { get; set; }


    }   
}