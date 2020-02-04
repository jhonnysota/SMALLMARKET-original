using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class DifCambioE
    {
        [DataMember]
        public String CodCuenta { get; set; }

        [DataMember]
        public String Descripcion { get; set; }

        [DataMember]
        public String indCambio_X_Compra { get; set; }

        [DataMember]
        public Decimal Historico { get; set; }

        [DataMember]
        public Decimal Ajuste { get; set; }

        [DataMember]
        public Decimal salActualSoles { get; set; }

        [DataMember]
        public Decimal salAactualDolares { get; set; }

        [DataMember]
        public Decimal tipCambioVt { get; set; }

        [DataMember]
        public Decimal tipCambioCp { get; set; }

        [DataMember]
        public String desTipoAjuste { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String desAbreviatura { get; set; }

    }
}
