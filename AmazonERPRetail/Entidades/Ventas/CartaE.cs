using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class CartaE
    {
        public CartaE()
        {
            ListaCartaProductoDet = new List<CartaProductoDetE>();
        }

        [DataMember]










        [DataMember]
        public List<CartaProductoDetE> ListaCartaProductoDet { get; set; }

        
    }   
}