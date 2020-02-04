using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{

    [DataContract]
    [Serializable]
    public partial class OrdenCompraParametrosE
    {

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 tipOrdenCompra { get; set; }

        [DataMember]
        public Int32 tipSecuenciaFlujo { get; set; }

        [DataMember]
        public Int32 tipModalCompra { get; set; }

        [DataMember]
        public Int32 idMoneda { get; set; }

        [DataMember]
        public Boolean indPartPresupuestal { get; set; }

    }
}
