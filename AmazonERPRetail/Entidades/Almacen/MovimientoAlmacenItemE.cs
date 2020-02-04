using System;
using System.Runtime.Serialization;

using Entidades.Maestros;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class MovimientoAlmacenItemE
    {

        public MovimientoAlmacenItemE()
        {
            codSerie = 0;
            Revisar = false;
        }

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 tipMovimiento { get; set; }

        [DataMember]
        public Int32 idDocumentoAlmacen { get; set; }

        [DataMember]
        public Int32 idItem { get; set; }

        [DataMember]
        public String numItem { get; set; }

        [DataMember]
        public Int32 idArticulo { get; set; }
        
        [DataMember]
        public String Lote { get; set; }

        [DataMember]
        public Int32 idUbicacion { get; set; }

        [DataMember]
        public Decimal Cantidad { get; set; }

        [DataMember]
        public Decimal PesoUnitario { get; set; }

        [DataMember]
        public Decimal ImpCostoUnitarioBase { get; set; }

        [DataMember]
        public Decimal ImpCostoUnitarioRefe { get; set; }

        [DataMember]
        public Decimal ImpTotalBase { get; set; }

        [DataMember]
        public Decimal ImpTotalRefe { get; set; }

        [DataMember]
        public Boolean indCalidad { get; set; }

        [DataMember]
        public Boolean indConformidad { get; set; }

        [DataMember]
        public String idCCostos { get; set; }

        [DataMember]
        public String idCCostosUso { get; set; }

        [DataMember]
        public String desCCostos { get; set; }

        [DataMember]
        public Int32 idArticuloUso { get; set; }

        [DataMember]
        public Int32 nroEnvases { get; set; }

        [DataMember]
        public Boolean Valorizado { get; set; }

        [DataMember]
        public String nroParteProd { get; set; }

        [DataMember]
        public Int32? idItemCompra { get; set; }

        [DataMember]
        public String UsuarioAnula { get; set; }

        [DataMember]
        public DateTime? FechaAnula { get; set; }

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
        public Int32 codSerie { get; set; }

        [DataMember]
        public ArticuloServE oArticulo { get; set; } //Para la impresion de la nota de ingreso/salida del almacén.

        //Extenciones Henry
        [DataMember]
        public LoteE oLoteEntidad { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String LoteProveedor { get; set; }

        //Para actualizar el lote cuando se trata de salidas por ventas
        [DataMember]
        public Boolean Revisar { get; set; }

        [DataMember]
        public String LoteAnterior { get; set; }

    }
}
