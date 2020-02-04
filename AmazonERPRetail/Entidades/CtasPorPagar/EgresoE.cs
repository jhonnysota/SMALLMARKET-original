using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class EgresoE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idNumEgreso { get; set; }

		[DataMember]
		public String NumEgreso { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

        [DataMember]
        public String codTipoPago { get; set; }

        [DataMember]
        public Int32 idConcepto { get; set; }

        [DataMember]
		public String codFormaPago { get; set; }

		[DataMember]
		public DateTime? fechaProceso { get; set; }

		[DataMember]
		public Decimal tipCambio { get; set; }

		[DataMember]
		public Decimal impEgresoBase { get; set; }

		[DataMember]
		public Int32? idPersona { get; set; }

		[DataMember]
		public Decimal impEgresoSecun { get; set; }

		[DataMember]
		public String tipEstado { get; set; }

		[DataMember]
		public String glosaPago { get; set; }

		[DataMember]
		public String AnioPeriodo { get; set; }

		[DataMember]
		public String MesPeriodo { get; set; }

		[DataMember]
		public String numVoucher { get; set; }

		[DataMember]
		public String idComprobante { get; set; }

		[DataMember]
		public String numFile { get; set; }

		[DataMember]
		public DateTime FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime FechaModificacion { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

        //Extensiones
        [DataMember]
        public List<EgresoItemE> ListaEgresos { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String idDocumentoBanco { get; set; }

        [DataMember]
        public String SerieBanco { get; set; }

        [DataMember]
        public String NumeroBanco { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public Decimal Monto { get; set; }

    }   
}