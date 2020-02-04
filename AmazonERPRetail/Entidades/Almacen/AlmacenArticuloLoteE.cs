using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public class AlmacenArticuloLoteE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public String AnioPeriodo { get; set; }

		[DataMember]
		public String MesPeriodo { get; set; }

		[DataMember]
		public Int32 idAlmacen { get; set; }

		[DataMember]
		public Int32 idArticulo { get; set; }

		[DataMember]
		public String Lote { get; set; }

		[DataMember]
		public Decimal canStock { get; set; }

		[DataMember]
		public Decimal CostoUnitPromBase { get; set; }

		[DataMember]
		public Decimal CostoUnitPromSecu { get; set; }

        //Extensiones
        [DataMember]
        public String desArticulo { get; set; }

        [DataMember]
        public String desAlmacen { get; set; }

        [DataMember]
        public String LoteProveedor { get; set; }

        [DataMember]
        public String codArticulo { get; set; }

        [DataMember]
        public String codCuentaDestino { get; set; }

        [DataMember]
        public String desCtaDestino { get; set; }

        [DataMember]
        public Decimal TotalSoles { get; set; }

        [DataMember]
        public Decimal TotalDolar { get; set; }

    }   
}