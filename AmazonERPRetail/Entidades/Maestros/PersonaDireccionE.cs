using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class PersonaDireccionE
    {
            
        [DataMember]




        [DataMember]
        public Boolean Estado { get; set; }





        //Campos Adicional
        [DataMember]
        public Int32 Opcion { get; set; }

    }   
}