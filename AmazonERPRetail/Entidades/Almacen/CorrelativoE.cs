using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public class CorrelativoE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public Int32 idCorrelativo { get; set; }

        [DataMember]
        public Int32 idTipo { get; set; }
		[DataMember]		public String Descripción { get; set; }
		[DataMember]		public String numSerie { get; set; }
		[DataMember]		public String numCorrelativo { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }
              [DataMember]
        public String formato { get; set; }        //Extensiones        [DataMember]
        public String desTipo { get; set; }        
    }   
}