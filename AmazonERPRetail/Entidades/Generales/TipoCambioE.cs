using System;
using System.Runtime.Serialization; 

namespace Entidades.Generales
{
    [DataContract]
    [Serializable]
    public partial class TipoCambioE
    {
        
		[DataMember]
		public String idMoneda { get; set; }  

		[DataMember]  
		public Int32 idCambio { get; set; }  

		[DataMember]
		public string fecCambio { get; set; }

		[DataMember]
		public Decimal valCompra { get; set; }

		[DataMember]
		public Decimal valVenta { get; set; }
 
		[DataMember]  
		public Decimal valVentaCaja { get; set; }
  
		[DataMember]  
		public Decimal valCompraCaja { get; set; }
 
		[DataMember]  
		public String UsuarioRegistro { get; set; }

		[DataMember]  
		public DateTime FechaRegistro { get; set; }

		[DataMember]  
		public String UsuarioModificacion { get; set; }

		[DataMember]  
		public DateTime FechaModificacion { get; set; }

    }   
}