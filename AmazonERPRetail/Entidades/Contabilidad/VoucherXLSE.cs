using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class VoucherXLSE
    {

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public Int32 Linea { get; set; }

        [DataMember]
        public String Anio { get; set; }

        [DataMember]
        public String Mes { get; set; }

        [DataMember]
        public String Diario { get; set; }

        [DataMember]
        public String NumFile { get; set; }

        [DataMember]
        public String Numero { get; set; }

        [DataMember]
        public DateTime FechaOperacion { get; set; }

        [DataMember]
        public String Moneda { get; set; }

        [DataMember]
        public String GlosaGeneral { get; set; }

        [DataMember]
        public String Item { get; set; }

        [DataMember]
        public String Cuenta { get; set; }

        [DataMember]
        public String Descripcion { get; set; }

        [DataMember]
        public String CtaDes { get; set; }

        [DataMember]
        public String CompraVenta { get; set; }

        [DataMember]
        public Int32 Codigo { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String DescripcionLarga { get; set; }

        [DataMember]
        public String TipoDoc { get; set; }

        [DataMember]
        public String Serie { get; set; }

        [DataMember]
        public String Documentos { get; set; }

        [DataMember]
        public DateTime? Fecha { get; set; }

        [DataMember]
        public DateTime? FechaVen { get; set; }

        [DataMember]
        public String indTipoCambio { get; set; }

        [DataMember]
        public Decimal TipoCambio { get; set; }

        [DataMember]
        public String CentroCosto { get; set; }

        [DataMember]
        public String indDH { get; set; }

        [DataMember]
        public Decimal MontoSoles { get; set; }

        [DataMember]
        public Decimal MontoDolares { get; set; }

        [DataMember]
        public String TipoDocRef { get; set; }

        [DataMember]
        public String SerieDocRef { get; set; }

        [DataMember]
        public String NumDocRef { get; set; }

        [DataMember]
        public DateTime? FechaRef { get; set; }

        [DataMember]
        public String Glosa { get; set; }

        [DataMember]
        public String indReparable { get; set; }

    }
}
