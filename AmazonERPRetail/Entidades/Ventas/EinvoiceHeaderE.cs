using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class EinvoiceHeaderE
    {
        [DataMember]
        public String numeroDocumentoAdquiriente { get; set; }

        [DataMember]
        public String serieNumero { get; set; }

        [DataMember]
        public String tipoDocumento { get; set; }

        [DataMember]
        public String estado { get; set; }

    }
}
