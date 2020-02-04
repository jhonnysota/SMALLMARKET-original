using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class RegistroVentasDetE
    {
            
        [DataMember]
		public Int32 idVentas { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public String idCCostos { get; set; }

		[DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String numSerie { get; set; }

		[DataMember]
		public String numDocumentoIni { get; set; }

		[DataMember]
		public String numDocumentoFin { get; set; }

		[DataMember]
		public String SerieMaquina { get; set; }

		[DataMember]
		public DateTime FechaReal { get; set; }

		[DataMember]
		public DateTime FechaTurno { get; set; }

        [DataMember]
        public Int32 idArticulo { get; set; }

        [DataMember]
		public Int32 idPersona { get; set; }

		[DataMember]
		public String Placa { get; set; }

		[DataMember]
		public String OpeInafecta { get; set; }

		[DataMember]
		public Decimal BaseImponible { get; set; }

		[DataMember]
		public Decimal Igv { get; set; }

		[DataMember]
		public Decimal Total { get; set; }

		[DataMember]
		public Decimal Recaudo { get; set; }

		[DataMember]
		public Decimal Cantidad { get; set; }

		[DataMember]
		public Int32? idTipoUmedida { get; set; }

		[DataMember]
		public Int32? idUmedida { get; set; }

		[DataMember]
		public String idDocumentoRef { get; set; }

		[DataMember]
		public String numSerieRef { get; set; }

		[DataMember]
		public String numDocumentoRef { get; set; }

        [DataMember]
        public DateTime FechaRef { get; set; }

        [DataMember]
        public String Sistema { get; set; }

        [DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime FechaModificacion { get; set; }
        
        //Extensiones
        public String codCuentaVenta { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public Int32 Correlativo { get; set; }

        [DataMember]
        public String AbrevCCostos { get; set; }

        //Extensiones
        public String codCuentaVenta12 { get; set; }

    }

    [DataContract]
    [Serializable]
    public partial class RegistroVentasDetAgrupado
    {

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public String Sistema { get; set; }

        [DataMember]
        public String idCCostos { get; set; }

        [DataMember]
        public DateTime fecTurno { get; set; }

        [DataMember]
        public String tipCuenta { get; set; }

        [DataMember]
        public Int32 idArticulo { get; set; }


        [DataMember]
        public Int32? idPersona { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String numSerie { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public Decimal Monto { get; set; }

        [DataMember]
        public String codCuentaVenta { get; set; }

        [DataMember]
        public String AbrevCCostos { get; set; }

        [DataMember]
        public String codCuentaVenta12 { get; set; }

        [DataMember]
        public String idDocumentoRef { get; set; }

        [DataMember]
        public String numSerieRef { get; set; }

        [DataMember]
        public String numDocumentoRef { get; set; }

        [DataMember]
        public DateTime FechaRef { get; set; }

    }

}