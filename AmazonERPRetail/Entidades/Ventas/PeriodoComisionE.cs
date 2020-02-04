using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class PeriodoComisionE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public Int32 idPeriodo { get; set; }
		[DataMember]		public String Anio { get; set; }
		[DataMember]		public String Mes { get; set; }
		[DataMember]		public DateTime FechaInicial { get; set; }
		[DataMember]		public DateTime FechaFinal { get; set; }
		[DataMember]		public Boolean Estado { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }
		
        //Extensores 
        [DataMember]
        public String Nombre { get; set; }
    }   
}