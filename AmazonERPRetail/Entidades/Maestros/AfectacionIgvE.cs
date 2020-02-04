using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public partial class AfectacionIgvE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idAfectacion { get; set; }

		[DataMember]
		public String DesAfectacion { get; set; }

        [DataMember]
        public String EquivalenciaSunat { get; set; }

        [DataMember]
		public Boolean indIgv { get; set; }

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

        //Extensiones
        [DataMember]
        public String desTemporal { get; set; }
        
    }   
}