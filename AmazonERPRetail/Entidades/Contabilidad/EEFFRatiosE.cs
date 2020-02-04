using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class EEFFRatiosE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public Int32 idItem { get; set; }
		[DataMember]		public String secItem { get; set; }
		[DataMember]		public String desItem { get; set; }
		[DataMember]		public String desGlosa { get; set; }
		[DataMember]		public String TipoTabla { get; set; }
		[DataMember]		public String Formula { get; set; }
		[DataMember]		public Boolean flagActivo { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }
        //Extensiones		[DataMember]
        public Decimal Monto { get; set; } //Para almacenar los montos calculados al sacar el reporte de los Ratios...
        
    }   
}