using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class OrdenPagoE
    {

        public OrdenPagoE()
        {
            ListaOrdenPago = new List<OrdenPagoDetE>();
        }

        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

        [DataMember]
        public Int32 idOrdenPago { get; set; }

        [DataMember]
        public String codOrdenPago { get; set; }

        [DataMember]
        public String codTipoPago { get; set; }

        [DataMember]
        public Int32 idConcepto { get; set; }

        [DataMember]
        public String codFormaPago { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public Int32? idPersona { get; set; }

		[DataMember]
		public Int32? idPersonaBeneficiario { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Decimal Monto { get; set; }

        [DataMember]
        public Decimal MontoDolar { get; set; }

        [DataMember]
        public String idMonedaPago { get; set; }

        [DataMember]
		public String Glosa { get; set; }

        [DataMember]
        public String indEstado { get; set; } // P=Pendiente C=Cerrado A=Anulado

        [DataMember]
        public String VieneDe { get; set; } //-- M=Manual L=Liquidacion S=Solicitud Adelanto Proveedor D=Declaracion de Detracciones A=Autodetracciones P=Planillas

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
        public List<OrdenPagoDetE> ListaOrdenPago { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String desMonedaPago { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String RucBen { get; set; }

        [DataMember]
        public String NombreBen { get; set; }

        [DataMember]
        public Boolean Seleccionar { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public String desTipoPago { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String serDocumento { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public DateTime FecDocumento { get; set; }

        [DataMember]
        public String numCtaBancaria { get; set; }

        [DataMember]
        public Int32 idBanco { get; set; }

        [DataMember]
        public Int32 tipCuenta { get; set; }

        [DataMember]
        public string idMonedaBanco { get; set; }

        [DataMember]
        public Decimal MontoPago { get; set; } //Para saber cuanto se a pagar...

        [DataMember]
        public Decimal MontoPagoDet { get; set; } //Monto del detale a pagar ..

        [DataMember]
        public String TipPartidaPresu { get; set; }

        [DataMember]
        public String CodPartidaPresu { get; set; }

        [DataMember]
        public String DesPartida { get; set; }

        [DataMember]
        public string desBanco { get; set; }

        [DataMember]
        public Int32 indPP { get; set; } //Para saber si la OP se encuentra en el programa de pagos...

        [DataMember]
        public String desVieneDe { get; set; } //-- VieneDe => M=Manual L=Liquidacion S=Solicitud Adelanto Proveedor D=Declaracion de Detracciones.

    }   
}