using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class PlanCuentasDifCambioUsuarioE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public String numVerPlanCuentas { get; set; }
        
        [DataMember]
		public String codCuenta { get; set; }
        
        [DataMember]
		public String Descripcion { get; set; }  
		
        [DataMember]
        public String UsuarioAsignado { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public bool indSeleccionado { get; set; }



        [DataMember]  
		public String UsuarioRegistro { get; set; }  
		
        [DataMember]  
		public DateTime? FechaRegistro { get; set; }  
		
        [DataMember]  
		public String UsuarioModificacion { get; set; }  
		
        [DataMember]  
		public DateTime? FechaModificacion { get; set; }


        //extensiones 

        [DataMember]
        public String idMoneda { get; set; }
        


    }   
}