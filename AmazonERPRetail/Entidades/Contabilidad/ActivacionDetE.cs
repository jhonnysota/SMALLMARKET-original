using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class ActivacionDetE
    {
            
        [DataMember]		public Int32 idActivacion { get; set; }
        [DataMember]
        public Int32 Item { get; set; }        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]		public String codCuenta { get; set; }
		[DataMember]		public Decimal MontoDebe { get; set; }
		[DataMember]		public Decimal MontoHaber { get; set; }

        [DataMember]
        public Decimal MontoDebeDolares { get; set; }

        [DataMember]
        public Decimal MontoHaberDolares { get; set; }

        [DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String desCuenta { get; set; }
        
    }   
}