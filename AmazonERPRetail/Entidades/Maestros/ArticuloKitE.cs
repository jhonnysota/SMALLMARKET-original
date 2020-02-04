using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class ArticuloKitE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public Int32 idArticulo { get; set; }
		[DataMember]		public Int32 idArticuloComponente { get; set; }
		[DataMember]		public Decimal Cantidad { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime FechaModificacion { get; set; }

		//Extensiones
		[DataMember]		public String CodArticulo { get; set; }

		[DataMember]		public String NombreArticulo { get; set; }

	}   
}