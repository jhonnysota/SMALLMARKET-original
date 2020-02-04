using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class CostosMovimientosItemE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public Int32 idElemento { get; set; }
		[DataMember]		public String CodClasificacion { get; set; }

        [DataMember]
        public String Anio { get; set; }

        [DataMember]		public String Mes { get; set; }
		[DataMember]		public String Monto { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

    }   
}