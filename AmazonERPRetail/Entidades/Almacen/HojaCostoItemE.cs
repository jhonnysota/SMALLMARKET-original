using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class HojaCostoItemE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idHojaCosto { get; set; }

		[DataMember]
		public Int32 item { get; set; }

        [DataMember]
        public Int32 idItemOC { get; set; }

        [DataMember]
		public Int32? nNivel { get; set; }

		[DataMember]
		public String Nivel { get; set; }

		[DataMember]
		public String Nivelinv { get; set; }

		[DataMember]
		public String PartidaArancelaria { get; set; }

		[DataMember]
		public Int32 idArticulo { get; set; }

		[DataMember]
		public String Descripcion { get; set; }

		[DataMember]
		public Decimal Cantidad { get; set; }

		[DataMember]
		public Decimal Peso { get; set; }

		[DataMember]
		public Decimal PesoUnitario { get; set; }

        [DataMember]
        public Int32? idTipoUmedida { get; set; }

        [DataMember]
        public Int32? idUmedida { get; set; }

        [DataMember]
		public Decimal FobUnitario { get; set; }

		[DataMember]
		public Decimal ValorFob { get; set; }

		[DataMember]
		public Decimal? ValorPeso { get; set; }

		[DataMember]
		public Decimal? ValorVolumen { get; set; }

        [DataMember]
        public Decimal Flete { get; set; }

        [DataMember]
        public Decimal Seguro { get; set; }

        [DataMember]
		public Decimal OtrosCostos { get; set; }

		[DataMember]
		public Decimal? ValorCif { get; set; }

		[DataMember]
		public Decimal TCambio { get; set; }

        [DataMember]
        public Decimal ValorTotalDolares { get; set; }

        [DataMember]
		public Decimal? AdValorem { get; set; }

		[DataMember]
		public Decimal? GstoAduana { get; set; }

		[DataMember]
		public Decimal? GstoComision { get; set; }

		[DataMember]
		public Decimal? GstoSeguro { get; set; }

		[DataMember]
		public Decimal? GstoBancario { get; set; }

		[DataMember]
		public Decimal GstoOtros { get; set; }

        [DataMember]
        public Decimal GstoOtrosMN { get; set; }

        [DataMember]
		public Decimal CostoTotalMN { get; set; }

		[DataMember]
		public Decimal CostoUnitarioMN { get; set; }

		[DataMember]
		public Decimal CostoTotalME { get; set; }

		[DataMember]
		public Decimal CostoUnitarioME { get; set; }

		[DataMember]
		public Decimal? FactorVenta { get; set; }

		[DataMember]
		public Decimal? PrecioVenta { get; set; }

		[DataMember]
		public Decimal? Utilidad { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        //Extension
        [DataMember]
        public Int32 Opcion { get; set; }
        
        [DataMember]
        public String NomArticulo { get; set; }

        [DataMember]
        public String nomCorto { get; set; }

        [DataMember]
        public String desUmedida { get; set; }

        [DataMember]
        public String codArticulo { get; set; }

        [DataMember]
        public String Lote { get; set; }

    }   
}