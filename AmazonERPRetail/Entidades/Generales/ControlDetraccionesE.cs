using System;
using System.Runtime.Serialization;

namespace Entidades.Generales
{
    [DataContract]
    [Serializable]
    public partial class ControlDetraccionesE
    {
            
        [DataMember]
		public Int32 idControl { get; set; }

		[DataMember]
		public Int32? idEmpresa { get; set; }

		[DataMember]
		public Int32? idSistema { get; set; }

		[DataMember]
		public Int32? idOrdenPago { get; set; }

        [DataMember]
        public Int32 idPersona { get; set; }

        [DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String numSerie { get; set; }

		[DataMember]
		public String numDocumento { get; set; }

		[DataMember]
		public String NombreArchivo { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public String FechaRegistro { get; set; }

    }   
}