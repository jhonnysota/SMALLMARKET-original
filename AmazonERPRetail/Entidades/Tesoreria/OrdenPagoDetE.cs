using System;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class OrdenPagoDetE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idOrdenPago { get; set; }

		[DataMember]
		public Int32 idOrdenPagoItem { get; set; }

        [DataMember]
        public String codTipoPago { get; set; }

        [DataMember]
        public Int32 idConcepto { get; set; }

        [DataMember]
        public String codFormaPago { get; set; }

        [DataMember]
		public DateTime Fecha { get; set; }

		[DataMember]
		public Int32 idProveedor { get; set; }

		[DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String serDocumento { get; set; }

		[DataMember]
		public String numDocumento { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Decimal Monto { get; set; }

        [DataMember]
        public String idMonedaPago { get; set; }

        [DataMember]
        public Decimal MontoPago { get; set; }

        [DataMember]
        public String TipPartidaPresu { get; set; }

        [DataMember]
        public String CodPartidaPresu { get; set; }

        [DataMember]
		public String Concepto { get; set; }

		[DataMember]
		public String Descripcion { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public Int32? idBanco { get; set; }

        [DataMember]
        public Int32? tipCuenta { get; set; }

        [DataMember]
        public String idMonedaBanco { get; set; }

        [DataMember]
        public String numCtaBancaria { get; set; }

        [DataMember]
        public Boolean indPago { get; set; }

        [DataMember]
        public Boolean indAuto { get; set; } //--0=Manual 1=Automatico

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
        public String desProveedor { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String RucProv { get; set; }

        [DataMember]
        public String desMonedaBanco { get; set; }

        [DataMember]
        public String desBanco { get; set; }

        [DataMember]
        public String DesPartida { get; set; }

        #region Para la detracciones de compras

        [DataMember]
        public Decimal porDetraccion { get; set; }

        [DataMember]
        public Decimal MontoDetraS { get; set; }

        [DataMember]
        public Decimal MontoDetraD { get; set; }

        [DataMember]
        public Int32 Dias { get; set; } 

        #endregion

        [DataMember]
        public Decimal tipCambio { get; set; }

        [DataMember]
        public Decimal MontoSecu { get; set; }

        [DataMember]
        public String codOrdenPago { get; set; }

    }   
}