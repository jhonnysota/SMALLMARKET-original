using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class RegVentasDetXLSE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idUsuario { get; set; }

		[DataMember]
		public Int32 Linea { get; set; }

		[DataMember]
		public String idCCostos { get; set; }

		[DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String numSerie { get; set; }

		[DataMember]
		public String numDocumentoIni { get; set; }

		[DataMember]
		public String numDocumentoFin { get; set; }

		[DataMember]
		public String SerieMaquina { get; set; }

		[DataMember]
		public DateTime FechaReal { get; set; }

		[DataMember]
		public DateTime FechaTurno { get; set; }

        [DataMember]
        public Int32? idArticulo { get; set; }

        [DataMember]
        public String Producto { get; set; }

        [DataMember]
        public Int32? idPersona { get; set; }

        [DataMember]
		public String Ruc { get; set; }

		[DataMember]
		public String RazonSocial { get; set; }

		[DataMember]
		public String Placa { get; set; }

		[DataMember]
		public String OpeInafecta { get; set; }

		[DataMember]
		public Decimal BaseImponible { get; set; }

		[DataMember]
		public Decimal Igv { get; set; }

		[DataMember]
		public Decimal Total { get; set; }

		[DataMember]
		public Decimal Recaudo { get; set; }

		[DataMember]
		public Decimal Cantidad { get; set; }

        [DataMember]
        public Int32? idUmedida { get; set; }

        [DataMember]
		public String desUmed { get; set; }

		[DataMember]
		public String idDocumentoRef { get; set; }

		[DataMember]
		public String numSerieRef { get; set; }

		[DataMember]
		public String numDocumentoRef { get; set; }

        [DataMember]
        public DateTime? FechaRef { get; set; }

    }   
}