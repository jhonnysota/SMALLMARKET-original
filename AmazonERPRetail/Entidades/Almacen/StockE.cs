using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class StockE
    {

        [DataMember]
        public Int32 idTipoArticulo { get; set; } //Campo 0

        [DataMember]
        public Int32 idArticulo { get; set; } //Campo 1

        [DataMember]
        public String codArticulo { get; set; } //Campo 2

        [DataMember]
        public String desArticulo { get; set; } //Campo 3

        [DataMember]
        public Int32 idPaisOrigen { get; set; } //Campo 4

        [DataMember]
        public String NombreOrigen { get; set; } //Campo 5

        [DataMember]
        public Int32 idPaisProcedencia { get; set; } //Campo 6

        [DataMember]
        public String NombreProcedencia { get; set; } //Campo 7

        [DataMember]
        public Int32 idPersona { get; set; } //Campo 8

        [DataMember]
        public String RazonSocial { get; set; } //Campo 9

        [DataMember]
        public Decimal canStock { get; set; } //Campo 10

        [DataMember]
        public Decimal canStockUD { get; set; } //Campo 10

        [DataMember]
        public String Batch { get; set; } //Campo 11

        [DataMember]
        public Decimal? PorcentajeGerminacion { get; set; } //Campo 12

        [DataMember]
        public DateTime? fecPrueba { get; set; } //Campo 13

        [DataMember]
        public DateTime? fecProceso { get; set; } //Campo 14

        [DataMember]
        public String Lote { get; set; } //Campo 15

        [DataMember]
        public String LoteProveedor { get; set; } //Campo 16

        [DataMember]
        public Decimal CostoUnitPromBase { get; set; } //Campo 17

        [DataMember]
        public Decimal CostoTotPromBase { get; set; } //Campo 17

        [DataMember]
        public Decimal CostoUnitPromSecu { get; set; } //Campo 18

        [DataMember]
        public Decimal CostoTotPromSecu { get; set; } //Campo 18

        [DataMember]
        public String nomUMedida { get; set; } //Campo 19

        [DataMember]
        public Int32 codTipoMedAlmacen { get; set; } //Campo 20

        [DataMember]
        public Int32 codUniMedAlmacen { get; set; } //Campo 21

        [DataMember]
        public Decimal Contenido { get; set; } //Campo 23

        [DataMember]
        public String nomUMedidaPres { get; set; } //Campo 24

        [DataMember]
        public Decimal StockFisico { get; set; } //Campo 24

        //Extensiones
        [DataMember]
        public Boolean EsComprometido { get; set; } //Campo 26

        [DataMember]
        public String NomEspecie { get; set; }

        [DataMember]
        public decimal PesoUnitario { get; set; }

        [DataMember]
        public String nomUMedidaEnv { get; set; }

        [DataMember]
        public String nomcomercial { get; set; }

        [DataMember]
        public String nomColor { get; set; }

        [DataMember]
        public String hibop { get; set; }

        [DataMember]
        public String otros { get; set; }

        [DataMember]
        public String cacm { get; set; }

        [DataMember]
        public String patron { get; set; }

        [DataMember]
        public String Observacion { get; set; }

        [DataMember]
        public String EntregadoPor { get; set; }

        [DataMember]
        public String Nivel1 { get; set; }

        [DataMember]
        public String Nivel2 { get; set; }

        [DataMember]
        public String Nivel3 { get; set; }

        [DataMember]
        public String nomCorto { get; set; }

        [DataMember]
        public Int32 idAlmacen { get; set; }

        [DataMember]
        public String Nombre { get; set; }

        [DataMember]
        public String NombreExterior { get; set; }

        [DataMember]
        public String LoteAlmacen { get; set; }

        [DataMember]
        public String DesMoneda { get; set; }

        [DataMember]
        public Decimal ValorVenta { get; set; }

        [DataMember]
        public Decimal ValorVentaL1 { get; set; }

        [DataMember]
        public Decimal ValorVentaL2 { get; set; }

        [DataMember]
        public Decimal ValorVentaL3 { get; set; }

        [DataMember]
        public Boolean indDetraccion { get; set; }

        [DataMember]
        public String tipDetraccion { get; set; }

        [DataMember]
        public Decimal TasaDetraccion { get; set; }

        [DataMember]
        public Decimal Costo { get; set; }

        [DataMember]
        public int idTipoMedEnvase { get; set; }

        [DataMember]
        public int idUniMedEnvase { get; set; }

        [DataMember]
        public string Marca { get; set; }

    }
}
