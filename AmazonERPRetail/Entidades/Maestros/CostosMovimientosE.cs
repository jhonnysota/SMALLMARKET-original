using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class CostosMovimientosE
    {
            
        [DataMember]



        [DataMember]






        //Detalle
        [DataMember]
        public List<CostosMovimientosItemE> ListaCostosMovimientos { get; set; }

    }   
}