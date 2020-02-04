using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class PresupuestoDeVentasXLSE
    {

        [DataMember]
        public Int32 Linea { get; set; }

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public String Anio { get; set; }

        [DataMember]
        public String idTipoArticulo { get; set; }

        [DataMember]
        public String Moneda { get; set; }

        [DataMember]
        public String NroDocumento { get; set; }

        [DataMember]
        public Int32 idVendedor { get; set; }

        [DataMember]
        public String Zona { get; set; }

        [DataMember]
        public String Articulo { get; set; }

        [DataMember]
        public Decimal Cantidad { get; set; }

        [DataMember]
        public Decimal Precio { get; set; }

        [DataMember]
        public String Mes { get; set; }

        
    }
}
