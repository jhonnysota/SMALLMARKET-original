using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class venParametrosE
    {
                
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Boolean GeneraAsiento { get; set; }

        [DataMember]
        public Boolean indFacElec { get; set; }

        [DataMember]
        public DateTime? FechaFacElec { get; set; }

        [DataMember]
        public Decimal MontoBoleta { get; set; }

        [DataMember]
        public Boolean Comprometido { get; set; }

        [DataMember]
        public Int32 digArticulo { get; set; }

        [DataMember]
        public String Glosa { get; set; }

        [DataMember]
        public Int32? ClienteVarios { get; set; }

        [DataMember]
        public Boolean EnvioFactEle { get; set; }

        [DataMember]
        public Boolean indListaPrecio { get; set; }

        [DataMember]
        public String monPedido { get; set; }

        [DataMember]
        public String CorreoCobranza { get; set; }

        [DataMember]
        public Boolean indIgv { get; set; }

        [DataMember]
        public String LetraImpresion { get; set; }

        [DataMember]
        public Int32 SizeLetra { get; set; }

        [DataMember]
        public Boolean indZona { get; set; }

        [DataMember]
        public Boolean indAfectacionIgv { get; set; }

        [DataMember]
        public String TipoFacturacion { get; set; }

        [DataMember]
        public String FontPrintLetra { get; set; }

        [DataMember]
        public Int32 SizeFontLetra { get; set; }

        [DataMember]
        public Boolean indNomArtCompuesto { get; set; }

        [DataMember]
        public String FontPrintBarras { get; set; }

        [DataMember]
        public Int32 digBarras { get; set; }

        [DataMember]
        public String nomArticuloCal { get; set; }

        [DataMember]
        public Boolean indVendedor { get; set; }

        [DataMember]
        public Int32? razonExoIgv { get; set; }

        [DataMember]
        public Boolean indBanco { get; set; }

        [DataMember]
        public Int32 idUbl { get; set; }

        [DataMember]
        public Int32 TipoPed { get; set; }

        [DataMember]
        public string SeriePed { get; set; }

        [DataMember]
        public Int32 CorrelativoPed { get; set; }

        [DataMember]
        public string FormatoPed { get; set; }

        //Extensiones
        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

    }   
}