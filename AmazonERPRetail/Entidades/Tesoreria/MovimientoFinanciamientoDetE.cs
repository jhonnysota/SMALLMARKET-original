using System;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class MovimientoFinanciamientoDetE
    {

        public MovimientoFinanciamientoDetE()
        {
            Cambio = "D";
        }

        [DataMember]
		public Int32 idMovimiento { get; set; }

        [DataMember]
        public Int32 Item { get; set; }

        [DataMember]
		public Decimal Tea { get; set; }

		[DataMember]
		public Decimal Tem { get; set; }

		[DataMember]
		public Decimal ImporteAmortizado { get; set; }

        [DataMember]
        public Decimal Amortizacion { get; set; }

        [DataMember]
        public Decimal Interes { get; set; }

        [DataMember]
        public Decimal ValorCuota { get; set; }

        [DataMember]
        public Decimal Comision { get; set; }

        [DataMember]
        public Decimal Total { get; set; }

        [DataMember]
        public DateTime fecVenc { get; set; }

        [DataMember]
		public Int32 DiasCuota { get; set; }

        [DataMember]
        public Int32 DiasAcumulados { get; set; }

        [DataMember]
        public Decimal InteresPorDa { get; set; }

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
        public Decimal DeudaCapital { get; set; }

        [DataMember]
        public Int32 Cuotas { get; set; }

        [DataMember]
        public Int32 AumentoDias { get; set; }

        [DataMember]
        public DateTime fecEmision { get; set; }

        [DataMember]
        public String Cambio { get; set; } //D=Control DateTimePicker T=TextBox

    }   
}