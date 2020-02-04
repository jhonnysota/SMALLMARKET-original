using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class RequerimientosItemE
    {

        public RequerimientosItemE()
        {
            cantTemporal = 0;
        }

        [DataMember]
		public Int32 idRequerimiento { get; set; }

		[DataMember]
		public Int32 Item { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

        [DataMember]
        public Int32 idTipoArticulo { get; set; }

        [DataMember]
		public Int32 idArticulo { get; set; }

        [DataMember]
        public String Lote { get; set; }

		[DataMember]
		public Int32? idUMedida { get; set; }

		[DataMember]
		public Decimal cantRequerida { get; set; }

		[DataMember]
		public Decimal cantAtendida { get; set; }

		[DataMember]
		public String Observacion { get; set; }

		[DataMember]
		public String indEstadoDet { get; set; }

		[DataMember]
		public Decimal Stock { get; set; }

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
        public String codArticulo { get; set; }

        [DataMember]
        public String nomArticulo { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public Decimal cantTemporal { get; set; }

    }   
}