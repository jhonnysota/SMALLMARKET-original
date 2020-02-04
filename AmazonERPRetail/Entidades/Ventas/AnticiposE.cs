using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class AnticiposE
    {

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public String idDocAnticipo { get; set; }

        [DataMember]
        public String numSerieAnticipo { get; set; }

        [DataMember]
        public String numDocAnticipo { get; set; }

        [DataMember]
        public Int32 idPersona { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public Int32? idArticulo { get; set; }

        [DataMember]
        public String idDocFactura { get; set; }

        [DataMember]
        public String numSerieFactura { get; set; }

        [DataMember]
        public String numDocFactura { get; set; }

        [DataMember]
        public Decimal SubTotalAnticipo { get; set; }

        [DataMember]
        public Decimal IgvAnticipo { get; set; }

        [DataMember]
        public Decimal TotalAnticipo { get; set; }

        [DataMember]
        public Decimal SubTotalSaldo { get; set; }

        [DataMember]
        public Decimal IgvSaldo { get; set; }

        [DataMember]
        public Decimal TotalSaldo { get; set; }

        [DataMember]
        public Boolean Aplicado { get; set; }

        [DataMember]
        public String Tipo { get; set; }

        //Extensiones
        [DataMember]
        public DateTime fecEmision { get; set; }

        [DataMember]
        public String Banco { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public Decimal Debe { get; set; }

        [DataMember]
        public Decimal Haber { get; set; }
        
        [DataMember]
        public String codArticulo { get; set; }

        [DataMember]
        public String nomArticulo { get; set; }

        [DataMember]
        public String indEstado { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public Decimal TotalSaldoTmp { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public Int32 Orden { get; set; } //Para el anticipo

        [DataMember]
        public Boolean CambiarColor { get; set; } //Para el anticipo

    }   
}