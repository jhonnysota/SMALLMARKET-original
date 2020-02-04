using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class SemanaE
    {
            
        [DataMember]
		public Int32 idSemana { get; set; }

		[DataMember]
		public String codAnio { get; set; }

		[DataMember]
		public String codSemana { get; set; }

		[DataMember]
		public DateTime fecInicio { get; set; }

		[DataMember]
		public DateTime fecFinal { get; set; }
        
    }   
}