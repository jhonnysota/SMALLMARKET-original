using System;
using System.Runtime.Serialization;

namespace Entidades.Generales
{
    [DataContract]
    [Serializable]
    public class ImpuestosPeriodoE
    {
            
        [DataMember]
		public Int32 idImpuesto { get; set; }

		[DataMember]
		public Int32 Item { get; set; }

		[DataMember]
		public DateTime? fecInicio { get; set; }

		[DataMember]
		public DateTime? fecFin { get; set; }

		[DataMember]
		public Decimal Porcentaje { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        //Extensiones...
        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

    }   
}