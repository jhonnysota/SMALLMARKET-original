using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class RentabilidadE
    {
        [DataMember]
        public String nomCategoria { get; set; }

        [DataMember]
        public String nomArticulo { get; set; }

        [DataMember]
        public Decimal Cantidad { get; set; }

        [DataMember]
        public Decimal PrecioUniProm { get; set; }

        [DataMember]
        public Decimal ValorVenta { get; set; }

        [DataMember]
        public Decimal TotalCosto { get; set; }

        [DataMember]
        public Decimal UtilidadBruta { get; set; }

        [DataMember]

        public String codArticulo { get; set; }


    }
}
