using System;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class MovimientoBancosDetE
    {

        public MovimientoBancosDetE()
        {
            idCtaCte = 0;
            idCtaCteItem = 0;
        }

        [DataMember]
		public Int32 idMovBanco { get; set; }

		[DataMember]
		public Int32 Item { get; set; }

        [DataMember]
        public Int32 idConcepto { get; set; }

		[DataMember]
		public Int32? idPersona { get; set; }

		[DataMember]
		public String idCCostos { get; set; }

		[DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String serDocumento { get; set; }

		[DataMember]
		public String numDocumento { get; set; }

		[DataMember]
		public DateTime fecDocumento { get; set; }

		[DataMember]
		public DateTime? fecVencimiento { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
		public Decimal Importe { get; set; }

        [DataMember]
        public Decimal ImporteDolar { get; set; }

        [DataMember]
        public Boolean TicaAuto { get; set; }

        [DataMember]
        public Decimal tipCambio { get; set; }

        [DataMember]
		public String Glosa { get; set; }

		[DataMember]
		public String indReparable { get; set; }

		[DataMember]
		public Int32 idConceptoRep { get; set; }

		[DataMember]
		public String desReferenciaRep { get; set; }

        [DataMember]
        public String tipPartidaPresu { get; set; }

        [DataMember]
        public String codPartidaPresu { get; set; }

        [DataMember]
        public Int32? idMoviTrans { get; set; }

        [DataMember]
        public Int32? idEmpresaTrans { get; set; }

        [DataMember]
        public Int32? idBancoTrans { get; set; }

        [DataMember]
        public String idMonedaTrans { get; set; }

        [DataMember]
        public String ctaBancariaTrans { get; set; }

        [DataMember]
        public Int32? idCtaCte { get; set; }

        [DataMember]
        public Int32? idCtaCteItem { get; set; }

        [DataMember]
        public Boolean VieneApertura { get; set; }

        [DataMember]
        public Boolean indExceso { get; set; }

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
        public String RUC { get; set; }

        [DataMember]
        public String desBanco { get; set; }

        [DataMember]
        public String desCCostos { get; set; }

        [DataMember]
        public String desPartidaPresu { get; set; }

        [DataMember]
        public String numVerPlanCuentasTrans { get; set; }

        [DataMember]
        public String codCuentaTrans { get; set; }

        [DataMember]
        public String TipAccionCtaCte { get; set; }

    }   
}