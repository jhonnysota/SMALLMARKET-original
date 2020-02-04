using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class PartidaPresupuestariaE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public String tipPartidaPresu { get; set; }

		[DataMember]
		public String codPartidaPresu { get; set; }

		[DataMember]
		public String desPartidaPresu { get; set; }

		[DataMember]
		public String abrevPartidaPresu { get; set; }

		[DataMember]
		public Int32 numNivel { get; set; }

		[DataMember]
		public String codPartidaPresuSup { get; set; }

		[DataMember]
		public String tipTituloNodo { get; set; }

		[DataMember]
		public String indUltNodo { get; set; }

		[DataMember]
		public Boolean indBaja { get; set; }

		[DataMember]
		public DateTime? FechaBaja { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? fechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? fechaModificacion { get; set; }

    }   
}