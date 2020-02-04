using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class PersonaDireccionE
    {
            
        [DataMember]		public Int32 IdPersona { get; set; }
		[DataMember]		public Int32 IdDireccion { get; set; }
		[DataMember]		public String DescripcionSucursal { get; set; }
		[DataMember]		public String DireccionCompleta { get; set; }

        [DataMember]
        public Boolean Estado { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime FechaModificacion { get; set; }

        //Campos Adicional
        [DataMember]
        public Int32 Opcion { get; set; }

    }   
}