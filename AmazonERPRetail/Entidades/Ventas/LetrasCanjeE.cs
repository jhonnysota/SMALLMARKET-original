using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class LetrasCanjeE
    {
        public LetrasCanjeE()
        {
            Opcion = 0;
        }

        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public String tipCanje { get; set; }

		[DataMember]
		public String codCanje { get; set; }

		[DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String numSerie { get; set; }

		[DataMember]
		public String numDocumento { get; set; }

		[DataMember]
		public Int32 idPersona { get; set; }

		[DataMember]
		public DateTime? fecDocumento { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

        [DataMember]
        public Decimal tipCambioDoc { get; set; }

        [DataMember]
		public Decimal? SaldoDoc { get; set; }

		[DataMember]
		public String idComprobante { get; set; }

		[DataMember]
		public String numFile { get; set; }

		[DataMember]
		public String AnioPeriodo { get; set; }

		[DataMember]
		public String MesPeriodo { get; set; }

		[DataMember]
		public String numVoucher { get; set; }

		[DataMember]
		public DateTime fecProceso { get; set; }

		[DataMember]
		public String Glosa { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public Int32? idCtaCte { get; set; }

        [DataMember]
        public Int32? idCtaCteItem { get; set; }

        [DataMember]
        public DateTime? fecAprobacion { get; set; }

        [DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String Ruc { get; set; }

        [DataMember]
        public String desDocumento { get; set; }

        [DataMember]
        public Decimal SaldoTemp { get; set; } //Para que el monto de las letras cuando se modifique no pueda pasar al valor rela...

    }   
}