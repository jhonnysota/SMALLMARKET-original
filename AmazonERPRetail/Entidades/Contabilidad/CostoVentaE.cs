using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class CostoVentaE
    {
        [DataMember]
        public String nomCategoria { get; set; }

        [DataMember]
        public String codCuentaConsumo { get; set; }

        [DataMember]
        public String codCuentaDestino { get; set; }

        [DataMember]
        public String codArticulo { get; set; }

        [DataMember]
        public String nomArticulo { get; set; }

        [DataMember]
        public Decimal Cantidad { get; set; }

        [DataMember]
        public Decimal impCostoPromUnitarioBase { get; set; }

        [DataMember]
        public Decimal totCosto { get; set; }

        [DataMember]
        public String desTipMovimiento { get; set; }

        [DataMember]
        public String codMovAlmacen { get; set; }

        [DataMember]
        public DateTime fecProceso { get; set; }

        [DataMember]
        public String Lote { get; set; }

        [DataMember]
        public String desAlmacen { get; set; }

        [DataMember]
        public Decimal impCostoPromUnitarioRefe { get; set; }

        [DataMember]
        public Decimal totCostoRefe { get; set; }
    }
}
