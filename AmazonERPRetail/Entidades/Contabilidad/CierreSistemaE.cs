using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class CierreSistemaE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public String AnioPeriodo { get; set; }
		[DataMember]		public String MesPeriodo { get; set; }
		[DataMember]		public Int32 idSistema { get; set; }
		[DataMember]		public Boolean indCierre { get; set; }
		[DataMember]		public DateTime? FechaCierre { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }



        [DataMember]
        public String DesSistema { get; set; }

    }   
}