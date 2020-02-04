using System;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class TipoLineaCreditoE
    {
            
        [DataMember]
		public Int32 idLinea { get; set; }

		[DataMember]
		public String Descripcion { get; set; }

        [DataMember]
        public String desCorta { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
		public String numVerPlanCuentas { get; set; }

		[DataMember]
		public String codCuenta { get; set; }

		[DataMember]
		public String idComprobante { get; set; }

		[DataMember]
		public String numFile { get; set; }

		[DataMember]
		public DateTime? fecBaja { get; set; }

		[DataMember]
		public Boolean indEstado { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime FechaModificacion { get; set; }

		//Extensiones
        [DataMember]
        public String desCuenta { get; set; }
        
    }   
}