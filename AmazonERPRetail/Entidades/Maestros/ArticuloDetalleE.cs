using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public partial class ArticuloDetalleE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idArticulo { get; set; }

		[DataMember]
		public Int32 idCaracteristica { get; set; }

		[DataMember]
		public String Descripcion { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? fechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? fechaModificacion { get; set; }

        //Extensores
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String DesArticulo { get; set; }
        
    }   
}