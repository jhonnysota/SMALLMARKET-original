using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public class FormaPagoE
    {

        public FormaPagoE()
        {
            ListaTipoPago = new List<FormaTipoPagoE>();
        }

		[DataMember]
		public String codFormaPago { get; set; }

		[DataMember]
		public String desFormaPago { get; set; }

		[DataMember]
		public String indForma { get; set; }

		[DataMember]
		public String CodForma { get; set; }

		[DataMember]
		public Decimal MontoTope { get; set; }

        [DataMember]
        public Boolean indDatosBancoAuxi { get; set; }

        [DataMember]
        public Int32? codMedioPago { get; set; }

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
        public List<FormaTipoPagoE> ListaTipoPago { get; set; }

        [DataMember]
        public List<FormaTipoPagoE> oListaFormaTipoEliminados { get; set; }

    }   
}