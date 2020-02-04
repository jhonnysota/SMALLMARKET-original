using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class MovimientoFinanciamientoE
    {

        public MovimientoFinanciamientoE()
        {
            oListaMovimientos = new List<MovimientoFinanciamientoDetE>();
        }

        [DataMember]
		public Int32 idMovimiento { get; set; }

		[DataMember]
		public String codMovimiento { get; set; }

		[DataMember]
		public Int32 idFinanciamiento { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32? idLinea { get; set; }

		[DataMember]
		public DateTime fecEmision { get; set; }

		[DataMember]
		public DateTime? fecVencimiento { get; set; }

		[DataMember]
		public String nroCuenta { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Decimal impSolicitado { get; set; }

		[DataMember]
		public String nroDocumento { get; set; }

		[DataMember]
		public Decimal ComisionDesem { get; set; }

        [DataMember]
        public Decimal ComisionVar { get; set; }

        [DataMember]
        public Int32 Periodicidad { get; set; }

        [DataMember]
		public Decimal Portes { get; set; }

		[DataMember]
		public Decimal segDesgravamen { get; set; }

		[DataMember]
		public Decimal porTea { get; set; }

		[DataMember]
		public Int32 Plazo { get; set; }

		[DataMember]
		public Int32 nroCuotas { get; set; }

		[DataMember]
		public Decimal impDesembolso { get; set; }

		[DataMember]
		public Decimal CuotaPago { get; set; }

        [DataMember]
        public Decimal MontoCredito { get; set; }

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
        public List<MovimientoFinanciamientoDetE> oListaMovimientos { get; set; }

        [DataMember]
        public String desLinea { get; set; }

        [DataMember]
        public String desBanco { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String desCtaBanco { get; set; }

        [DataMember]
        public Int32 idBanco { get; set; }

    }   
}