using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class RequisicionItemE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public Int32 idRequisicion { get; set; }
		[DataMember]		public Int32 idItem { get; set; }
		[DataMember]		public Int32? idLocal { get; set; }
		[DataMember]		public Int32 idArticulo { get; set; }

        [DataMember]
        public String Lote { get; set; }

        [DataMember]		public Decimal CantidadRequerida { get; set; }		[DataMember]		public Decimal? MontoEstimado { get; set; }

        [DataMember]
        public Decimal? MontoTotal { get; set; }

        [DataMember]		public String Especificacion { get; set; }
		[DataMember]		public Decimal CantidadOrdenada { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

        //extensiones

        [DataMember]
        public String DesArticulo { get; set; }

    }   
}