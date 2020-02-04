using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{

    [DataContract]
    [Serializable]
    public partial class TipoTrasladoE
    {
        [DataMember]
		public Int32 idTraslado { get; set; }

		[DataMember]
		public String desTraslado { get; set; }

		[DataMember]
		public String codSunat { get; set; }

		[DataMember]
		public Boolean flagFact { get; set; }

		[DataMember]
		public Boolean flagCtaCte { get; set; }

		[DataMember]
		public Int32? codFmtp { get; set; }

		[DataMember]
		public Boolean PonerCeroVenta { get; set; }

		[DataMember]
		public Boolean indAlmacen { get; set; }

        [DataMember]
        public String codSunatOpe { get; set; } //cód. de sunat de la operacion de almacen...

        [DataMember]
		public Boolean indEstado { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        [DataMember]
        public String desCodSunatOpe { get; set; } //cód. de sunat de la operacion de almacen...

    }
}