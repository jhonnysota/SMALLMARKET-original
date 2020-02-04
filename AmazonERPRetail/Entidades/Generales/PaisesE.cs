using System;
using System.Runtime.Serialization;

namespace Entidades.Generales
{
    [DataContract]
    [Serializable]
    public class PaisesE
    {
            
        [DataMember]
		public Int32 idPais { get; set; }

		[DataMember]
		public String Nombre { get; set; }

        [DataMember]
        public String CodigoSunat { get; set; }

        [DataMember]
        public String CodIso { get; set; }

        [DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        [DataMember]
        public String Gentilicio { get; set; }

    }   
}