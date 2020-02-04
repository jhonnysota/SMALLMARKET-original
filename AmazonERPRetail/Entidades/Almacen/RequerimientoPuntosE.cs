using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class RequerimientoPuntosE
    {
            
        [DataMember]
		public Int32 idPuntoReq { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public String Descripcion { get; set; }

		[DataMember]
		public String Observacion { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime FechaModificacion { get; set; }

    }   
}