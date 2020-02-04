using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class SalesPointE
    {
            
        [DataMember]
		public int IdSalesPoint { get; set; }

		[DataMember]
		public string Host { get; set; }

		[DataMember]
		public string Descripcion { get; set; }

		[DataMember]
		public string SerieCaja { get; set; }

        [DataMember]
        public string TipoImpresora { get; set; } //M=Matricial T=Térmica

        [DataMember]
		public string Impresora { get; set; }

		[DataMember]
		public Boolean PtoCobro { get; set; }

        [DataMember]
        public string TituloFac { get; set; }

        [DataMember]
        public string IdFactura { get; set; }

        [DataMember]
        public string SerieFactura { get; set; }

        [DataMember]
        public string TituloBol { get; set; }

        [DataMember]
        public string IdBoleta { get; set; }

        [DataMember]
        public string SerieBoleta { get; set; }

        [DataMember]
        public bool MostrarPrevio { get; set; }

        [DataMember]
        public int idAlmacen { get; set; }

        [DataMember]
        public string Head1 { get; set; }

        [DataMember]
        public string Head2 { get; set; }

        [DataMember]
        public string Head3 { get; set; }

        [DataMember]
        public string Head4 { get; set; }

        [DataMember]
        public string Head5 { get; set; }

        [DataMember]
        public string Head6 { get; set; }

        [DataMember]
        public string Foot1 { get; set; }

        [DataMember]
        public string Foot2 { get; set; }

        [DataMember]
        public string Foot3 { get; set; }

        [DataMember]
        public string Foot4 { get; set; }

        [DataMember]
        public string Foot5 { get; set; }

        [DataMember]
        public string Foot6 { get; set; }

        [DataMember]
        public string UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public string UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime FechaModificacion { get; set; }

    }   
}