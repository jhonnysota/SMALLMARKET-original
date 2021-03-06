using System;
using System.Runtime.Serialization;

namespace Entidades.Generales
{
    [DataContract]
    [Serializable]
    public partial class TasasDetraccionesDetalleE
    {
            
        [DataMember]		public String idTipoDetraccion { get; set; }
		[DataMember]		public Int32 item { get; set; }
		[DataMember]		public DateTime fecInicio { get; set; }
		[DataMember]		public DateTime fecFin { get; set; }
		[DataMember]		public Decimal Porcentaje { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String Nombre { get; set; }

        [DataMember]
        public Boolean Excluido { get; set; }

        [DataMember]
        public String NombreTemp { get; set; }

        [DataMember]
        public Decimal BaseAfecta { get; set; }

    }   
}