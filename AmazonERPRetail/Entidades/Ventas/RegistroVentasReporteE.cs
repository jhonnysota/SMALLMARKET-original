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
    public partial class RegistroVentasReporteE
    {
        [DataMember]
        public String NomMes { get; set; }

        [DataMember]
        public String Mov { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String DesDocumento { get; set; }

        [DataMember]
        public String numSerie { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public DateTime? fecEmision { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String Ruc { get; set; }

        [DataMember]
        public Decimal tipCambio { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public Decimal BaseAfecta { get; set; }

        [DataMember]
        public Decimal BaseInafecta { get; set; }

        [DataMember]
        public Decimal BaseExportacion { get; set; }

        [DataMember]
        public Decimal dctoBaseImponible { get; set; }

        [DataMember]
        public Decimal Isc { get; set; }

        [DataMember]
        public Decimal Igv { get; set; }

        [DataMember]
        public Decimal Total { get; set; }

        [DataMember]
        public Decimal TotalME { get; set; }
        

    }
}
