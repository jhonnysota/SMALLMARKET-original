using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class kardexXLSE
    {
        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idAlmacen { get; set; }

        [DataMember]
        public Int32 idArticulo { get; set; }

        [DataMember]
        public Int32 idOperacion { get; set; }

        [DataMember]
        public DateTime fecProceso { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String serDocumento { get; set; }

        [DataMember]
        public String numDocumento { get; set; }
        
        [DataMember]
        public String idDocumentoRef { get; set; }

        [DataMember]
        public String serDocumentoRef { get; set; }

        [DataMember]
        public String numDocumentoRef { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public Decimal Cantidad { get; set; }

        [DataMember]
        public Decimal ImpCostoUnitarioBase { get; set; }

        [DataMember]
        public Decimal ImpTotalBase { get; set; }
        
        [DataMember]
        public String Lote { get; set; }

        [DataMember]
        public String LoteProveedor { get; set; }

        [DataMember]
        public Int32 idPaisOrigen { get; set; }

        [DataMember]
        public Int32 idPaisProcedencia { get; set; }

        [DataMember]
        public String Batch { get; set; }

        [DataMember]
        public Decimal PorcentajeGerminacion { get; set; }

        [DataMember]
        public DateTime fecPrueba { get; set; }

        [DataMember]
        public Int32 Linea { get; set; }       

    }
}
