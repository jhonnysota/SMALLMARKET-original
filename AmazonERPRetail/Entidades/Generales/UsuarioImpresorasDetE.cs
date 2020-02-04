using System;
using System.Runtime.Serialization;

namespace Entidades.Generales
{
    [DataContract]
    [Serializable]
    public partial class UsuarioImpresorasDetE
    {
            
        [DataMember]
		public Int32 idImpresora { get; set; }

		[DataMember]
		public Int32 Item { get; set; }

		[DataMember]
		public Boolean PorDefecto { get; set; }

		[DataMember]
		public Decimal AnchoEtiqueta { get; set; }

		[DataMember]
		public Decimal AltoEtiqueta { get; set; }

		[DataMember]
		public Int32 cantEtiqueta { get; set; }

		[DataMember]
		public Int32 Gap { get; set; }

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
        public Int32 Opcion { get; set; }
        
    }   
}