using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class LetrasCanjeUnionE
    {

        public LetrasCanjeUnionE()
        {
            oListaCanjes = new List<LetrasCanjeE>();
            oListaLetras = new List<LetrasE>();
        }

        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public String tipCanje { get; set; }

		[DataMember]
		public String codCanje { get; set; }

        [DataMember]
        public String nomZona { get; set; }

        [DataMember]
        public String nomVendedor { get; set; }

        [DataMember]
        public String ruc { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String numSerie { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public DateTime fecDocumento { get; set; }

        [DataMember]
        public DateTime fecVencimiento { get; set; }

        [DataMember]
        public String NomMoneda { get; set; }

        [DataMember]
        public Decimal Importe { get; set; }

        [DataMember]
        public Decimal SaldoDoc { get; set; }

        [DataMember]
        public String EstadoDocumento { get; set; }

        [DataMember]
		public Boolean Estado { get; set; }

        //Extensiones
        [DataMember]
        public List<LetrasCanjeE> oListaCanjes { get; set; }

        [DataMember]
        public List<LetrasE> oListaLetras { get; set; }

        [DataMember]
        public List<LetrasE> LetrasEliminadas { get; set; }

        [DataMember]
        public List<LetrasCanjeE> CanjesEliminados { get; set; }

    }   
}