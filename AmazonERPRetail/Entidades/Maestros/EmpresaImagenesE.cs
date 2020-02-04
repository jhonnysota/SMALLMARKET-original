using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class EmpresaImagenesE
    {
            
        [DataMember]		public Int32 idImagen { get; set; }
		[DataMember]		public Int32? idEmpresa { get; set; }
		[DataMember]		public String Nombre { get; set; }
		[DataMember]		public String Extension { get; set; }
		[DataMember]		public Byte[] Imagen { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }


        //Extension

        [DataMember]
        public Int32 Opcion { get; set; }

    }   
}