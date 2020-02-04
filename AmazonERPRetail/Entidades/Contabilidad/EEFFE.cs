using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class EEFFE
    {            
        [DataMember]  
		public int idEmpresa { get; set; }

        [DataMember]
        public int idEEFF { get; set; }
        
		[DataMember]
        public string TipoSeccion { get; set; }

		[DataMember]
        public string desSeccion { get; set; }
        
        [DataMember]
        public string tipoReporte { get; set; }

        [DataMember]
        public string VerReporte { get; set; }

		[DataMember]
        public Boolean indComparativo { get; set; }

		[DataMember]
        public string indcCostos { get; set; }

        //Detalle
        [DataMember]
        public List<EEFFItemE> ListaEEFFItem { get; set; }


        // MODO
        [DataMember]
        public string indModo { get; set; }

        //SISTEMA
        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime? FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime? FechaModificacion { get; set; }


        //Extensiones Reporte

        [DataMember]
        public String AnioPeriodo { get; set; }

        [DataMember]
        public String MesPeriodo { get; set; }

        [DataMember]
        public String TipoTabla { get; set; }

        [DataMember]
        public String secitem { get; set; }

        [DataMember]
        public String desitem { get; set; }

        [DataMember]
        public Int32 Columna { get; set; }

        [DataMember]
        public String CodPlaCta { get; set; }

        [DataMember]
        public String Descripcion { get; set; }

        [DataMember]
        public Decimal MesAnterior { get; set; }

        [DataMember]
        public Decimal MesAnteriorAcumulado { get; set; }

        [DataMember]
        public Decimal MesActual { get; set; }

        [DataMember]
        public Decimal MesActualAcumulado { get; set; }

        [DataMember]
        public Decimal Deudor { get; set; }

        [DataMember]
        public Decimal Acreedor { get; set; }

    }   
}