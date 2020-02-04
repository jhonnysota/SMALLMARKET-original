using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class EEFFItemE
    {            

        [DataMember]  
		public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idEEFF { get; set; }

        [DataMember]
        public Int32 idEEFFItem { get; set; }
        
        [DataMember]
        public String secItem { get; set; }

		[DataMember]
        public String desItem { get; set; }

		[DataMember]
        public String TipoTabla { get; set; }

        [DataMember]
        public String TipoCaracteristica { get; set; }

        [DataMember]
        public String TipoColumna { get; set; }

        [DataMember]
        public String TipoItem { get; set; }

        [DataMember]
        public String desTabla { get; set; }

        [DataMember]
        public String desCaracteristica { get; set; }

		[DataMember]
        public String indPorcentaje { get; set; }

        [DataMember]
        public String indImprimir { get; set; }

        [DataMember]
        public String indEnviaExcel { get; set; }

        [DataMember]
        public Boolean indMostrar { get; set; }

        [DataMember]
        public String codSunat { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime? FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime? FechaModificacion { get; set; }

        // Extensiones
        [DataMember]
        public List<EEFFItemCtaE> ListaEEFFItemCta { get; set; } //Detalle CTA
        
        [DataMember]
        public List<EEFFItemForE> ListaEEFFItemFor { get; set; } //Detalle FOR
        
        [DataMember]
        public List<EEFFItemXlsE> ListaEEFFItemXls { get; set; } //Detalle XLS

        //BOTON
        [DataMember]
        public String btnDetalle { get; set; }

        //BOTON XLS
        [DataMember]
        public String btnXls { get; set; }

    }   
}