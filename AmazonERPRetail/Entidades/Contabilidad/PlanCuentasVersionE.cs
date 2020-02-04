using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class PlanCuentasVersionE
    {
        public PlanCuentasVersionE()
        {
            ListaEstructura = new List<PlanCuentasEstrucE>();
        }
            
        [DataMember]  
		public Int32 idEmpresa { get; set; }  
		
        [DataMember]  
		public String numVerPlanCuentas { get; set; }  
		
        [DataMember]  
		public String Descripcion { get; set; }  
		
        [DataMember]  
		public DateTime? fecInicio { get; set; }  
		
        [DataMember]  
		public DateTime? fecFinal { get; set; }

        [DataMember]
        public Int32? UltimoNivel { get; set; }

        [DataMember]  
		public String indVigente { get; set; }  
		
        [DataMember]  
		public String UsuarioRegistro { get; set; }  
		
        [DataMember]  
		public DateTime? FechaRegistro { get; set; }  
		
        [DataMember]  
		public String UsuarioModificacion { get; set; }  
		
        [DataMember]  
		public DateTime? FechaModificacion { get; set; }  
		
        //Campos Adicionales
        [DataMember]
        public List<PlanCuentasEstrucE> ListaEstructura { get; set; }

        [DataMember]
        public Int32 Longitud { get; set; }
    }   
}