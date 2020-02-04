using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.CtasPorPagar
{
    [DataContract]
    [Serializable]
    public class NumControlCompraE
    {

        public NumControlCompraE()
        {
            ListaNumControlCompra = new List<NumControlCompraDetE>();
        }

        [DataMember]









        //Detalle
        [DataMember]
        public List<NumControlCompraDetE> ListaNumControlCompra { get; set; }

    }   
}