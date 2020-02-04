using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public class TipoPagoE
    {

        public TipoPagoE()
        {
            DetalleTipoPago = new List<TipoPagoDetE>();
        }

        [DataMember]
        public String codTipoPago { get; set; }

        [DataMember]
        public String desTipoPago { get; set; }

        [DataMember]
        public String indTipo { get; set; }

        [DataMember]
        public String codTipo { get; set; }

        [DataMember]
        public Boolean indDetalle { get; set; }

        [DataMember]
        public Boolean HabilitarDatos { get; set; }

        [DataMember]
        public Boolean indSolProv { get; set; }

        [DataMember]
        public Boolean indEstado { get; set; }

        [DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

        //Extensiones
        [DataMember]
        public List<TipoPagoDetE> DetalleTipoPago { get; set; }

        [DataMember]
        public Int32 idEmpresa { get; set; }

    }   
}