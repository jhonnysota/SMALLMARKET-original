using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class CostosClasificacionE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public String CodClasificacion { get; set; }

        [DataMember]
        public String CodCategoriaAnte { get; set; }

        [DataMember]		public String nombreClasificacion { get; set; }
		[DataMember]		public Int32 numNivel { get; set; }
		[DataMember]		public String indUltimoNivel { get; set; }
		[DataMember]		public String CodCategoriaSup { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }
		
        
    }   
}