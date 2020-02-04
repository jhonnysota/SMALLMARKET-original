using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class CategoriaVendedorE
    {
            
        [DataMember]










        public List<CategoriaVendedorLineaE> oListaDetalle { get; set; }
        [DataMember]
        public String codVendedor { get; set; }

        [DataMember]
        public String desVendedor { get; set; }

        [DataMember]
        public String codLinea { get; set; }

        [DataMember]
        public String desLinea { get; set; }
        
        //Adicional
        [DataMember]
        public String indRegistro { get; set; }
    }   
}