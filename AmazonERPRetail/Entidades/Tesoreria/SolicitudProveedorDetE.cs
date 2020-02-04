using System;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class SolicitudProveedorDetE
    {
            
        [DataMember]
		public Int32 idSolicitud { get; set; }

		[DataMember]
		public Int32 Item { get; set; }

		[DataMember]
		public Int32 idConcepto { get; set; }

		[DataMember]
		public Decimal Cantidad { get; set; }

        [DataMember]
        public Boolean indIgv { get; set; }

        [DataMember]
        public Decimal porIgv { get; set; }

        [DataMember]
        public Decimal Igv { get; set; }

        [DataMember]
		public Decimal Importe { get; set; }

		[DataMember]
		public Boolean indDetraccion { get; set; }

		[DataMember]
		public Boolean indRetencion { get; set; }

		[DataMember]
		public Decimal Tasa { get; set; }

		[DataMember]
		public Decimal impImpuesto { get; set; }

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
        public String desConcepto { get; set; }

        [DataMember]
        public String codConcepto { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public DateTime fecOpeSol { get; set; } //Dato de la cabecera

        [DataMember]
        public String idMonedaSol { get; set; } //Dato de la cabecera

        [DataMember]
        public String codCuentaCompras { get; set; }

    }   
}