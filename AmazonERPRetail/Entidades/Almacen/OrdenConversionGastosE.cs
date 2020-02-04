using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class OrdenConversionGastosE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idOrdenConversion { get; set; }

		[DataMember]
		public Int32 item { get; set; }

		[DataMember]
		public String Descripcion { get; set; }

		[DataMember]
		public Int32? idPersona { get; set; }

		[DataMember]
		public DateTime Fecha { get; set; }

		[DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String serDocumento { get; set; }

		[DataMember]
		public String numDocumento { get; set; }

		[DataMember]
		public Decimal TipoCambio { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Decimal Monto { get; set; }

		[DataMember]
		public Decimal MontoDolares { get; set; }

		[DataMember]
		public Boolean DistribuirItem { get; set; }

		[DataMember]
		public String ItemADistribuir { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String DesMoneda { get; set; }

        [DataMember]
        public String desDocumento { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String Ruc { get; set; }

    }   
}