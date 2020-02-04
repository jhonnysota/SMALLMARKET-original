using System;
using System.Runtime.Serialization;

namespace Entidades.Generales
{
    [DataContract]
    [Serializable]
    public class MonedasE
    {
        [DataMember]
        public String idMoneda { get; set; }  

		[DataMember]
        public String desMoneda { get; set; }  

		[DataMember]
        public String desAbreviatura { get; set; }

        [DataMember]
        public String ISO { get; set; }

		[DataMember]
        public String UsuarioRegistro { get; set; }  

		[DataMember]  
		public DateTime FechaRegistro { get; set; }  

		[DataMember]
        public String UsuarioModificacion { get; set; }  

		[DataMember]  
		public DateTime FechaModifica { get; set; }  		

    }   
}