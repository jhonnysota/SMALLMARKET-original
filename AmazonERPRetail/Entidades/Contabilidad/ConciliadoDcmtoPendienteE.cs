using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class ConciliadoDcmtoPendienteE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public String AnioPeriodo { get; set; }

		[DataMember]
		public String MesPeriodo { get; set; }

		[DataMember]
		public String numVerPlanCuentas { get; set; }

		[DataMember]
		public String codCuenta { get; set; }

		[DataMember]
		public Int32 idPersona { get; set; }

		[DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String serDocumento { get; set; }

		[DataMember]
		public String numDocumento { get; set; }

		[DataMember]
		public DateTime? fecDocumento { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Decimal impMonto { get; set; }

		[DataMember]
		public String desGlosa { get; set; }

		[DataMember]
		public String indConciliado { get; set; }

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
        public String RazonSocial { get; set; }

        [DataMember]
        public String Ruc { get; set; }

        [DataMember]
        public Decimal Debe { get; set; }

        [DataMember]
        public Decimal Haber { get; set; }

        [DataMember]
        public Decimal Movimiento { get; set; }

        [DataMember]
        public String Orden { get; set; }

        [DataMember]
        public Boolean indConciliadoBool { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public Boolean Ignorar { get; set; }

    }   
}