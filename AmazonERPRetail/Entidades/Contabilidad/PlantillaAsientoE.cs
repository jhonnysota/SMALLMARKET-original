using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class PlantillaAsientoE
    {
        public PlantillaAsientoE()
        {
            ListaPlantillas = new List<PlantillaAsientoDetE>();
        }
            
        [DataMember]
		public Int32 idPlantilla { get; set; }

		[DataMember]
		public Int32? idEmpresa { get; set; }

        [DataMember]
        public Int32? idLocal { get; set; }

		[DataMember]
		public String Descripcion { get; set; }

		[DataMember]
		public String idComprobante { get; set; }

		[DataMember]
		public String numFile { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Int32? TipoVoucher { get; set; }

		[DataMember]
		public Boolean indExcel { get; set; }

        [DataMember]
        public Int32? Hoja { get; set; }

		[DataMember]
		public Int32? filInicial { get; set; }

		[DataMember]
		public Int32? colInicial { get; set; }

		[DataMember]
		public Int32? filFinal { get; set; }

		[DataMember]
		public Int32? colFinal { get; set; }

        [DataMember]
        public String GlosaGeneral { get; set; }

        [DataMember]
        public Boolean sumCCostos { get; set; }

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
        public List<PlantillaAsientoDetE> ListaPlantillas { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public String Anio { get; set; }

        [DataMember]
        public String Mes { get; set; }

    }   
}