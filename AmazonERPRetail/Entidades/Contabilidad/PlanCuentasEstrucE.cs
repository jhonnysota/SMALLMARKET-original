using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class PlanCuentasEstrucE
    {
            
        [DataMember]  
		public Int32 idEmpresa { get; set; }  
		
        [DataMember]  
		public String numVerPlanCuentas { get; set; }  
		
        [DataMember]  
		public Int32 numNivelEstruc { get; set; }  
		
        [DataMember]  
		public String Descripcion { get; set; }  
		
        [DataMember]  
		public Int32? numLongiEstruc { get; set; }  
		
        [DataMember]  
		public String indFteFinanciamiento { get; set; }  
		
        [DataMember]  
		public String indMoneda { get; set; }  
		
        [DataMember]  
		public String UsuarioRegistro { get; set; }  
		
        [DataMember]  
		public DateTime? FechaRegistro { get; set; }  
		
        [DataMember]  
		public String UsuarioModificacion { get; set; }  
		
        [DataMember]  
		public DateTime? FechaModificacion { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }


    }   
}