using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public partial class VendedoresCarteraE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idVendedor { get; set; }

		[DataMember]
		public Int32 idCliente { get; set; }

		[DataMember]
		public DateTime FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime FechaModificacion { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

        //Extensiones
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String desVendedor { get; set; }

        [DataMember]
        public String desCliente { get; set; }

        [DataMember]
        public String RUC { get; set; }

    }   
}