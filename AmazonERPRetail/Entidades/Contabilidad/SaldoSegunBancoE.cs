using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class SaldoSegunBancoE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public String AnioPeriodo { get; set; }
		[DataMember]		public String MesPeriodo { get; set; }
		[DataMember]		public String numVerPlanCuentas { get; set; }
		[DataMember]		public String codCuenta { get; set; }
		[DataMember]		public Decimal? Saldo { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }
		
        
    }   
}