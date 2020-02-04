using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class OrdenCompraDistriE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idOrdenCompra { get; set; }

		[DataMember]
		public String idCCostos { get; set; }

		[DataMember]
		public Decimal? Porcentaje { get; set; }

		[DataMember]
		public Decimal? Monto { get; set; }

        //Extensiones
        [DataMember]
        public String tipoCCosto { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public String desCCostos { get; set; }

    }   
}