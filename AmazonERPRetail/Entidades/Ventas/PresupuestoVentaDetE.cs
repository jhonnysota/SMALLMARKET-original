using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class PresupuestoVentaDetE
    {

        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public String AnioPresupuesto { get; set; }
		[DataMember]		public Int32 idVendedor { get; set; }
		[DataMember]		public Int32 idEstablecimiento { get; set; }
		[DataMember]		public Int32 idArticulo { get; set; }

       	[DataMember]		public Int32 idTipoArticulo { get; set; }
		[DataMember]		public String Mes { get; set; }

        [DataMember]
        public String NombreMes { get; set; }        

        [DataMember]		public Decimal? Cantidad { get; set; }
		[DataMember]		public Decimal? PrecioUnit { get; set; }
		[DataMember]		public Decimal? Total { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String Vendedor { get; set; }

        [DataMember]
        public String DesTipoArticulo { get; set; }

        [DataMember]
        public String DesEstablecimiento { get; set; }

        [DataMember]
        public String codArticulo { get; set; }

    }   
}