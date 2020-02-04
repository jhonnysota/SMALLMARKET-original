using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class KardexValorizadoE
    {

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idAlmacen { get; set; }

        [DataMember]
        public DateTime Inicio { get; set; }

        [DataMember]
        public DateTime Fin { get; set; }

        [DataMember]
        public String TipoExistencia { get; set; }

        [DataMember]
        public String NomExistencia { get; set; }

        [DataMember]
        public Int32 Articulo { get; set; }

        [DataMember]
        public String DesArticulo { get; set; }

        [DataMember]
        public Int32 UndMedida { get; set; }

        [DataMember]
        public String NomMedida { get; set; }

        [DataMember]
        public String Metodo { get; set; }

        [DataMember]
        public string fecProceso { get; set; }

        [DataMember]
        public string Fecha { get; set; }

        [DataMember]
        public String Documento { get; set; }

        [DataMember]
        public String Serie { get; set; }

        [DataMember]
        public String Numero { get; set; }

        [DataMember]
        public String idDocumentoRef { get; set; }

        [DataMember]
        public String serDocumentoRef { get; set; }

        [DataMember]
        public String numDocumentoRef { get; set; }

        [DataMember]
        public Int32 Operacion { get; set; }

        [DataMember]
        public Decimal CantEntradaInicial { get; set; }

        [DataMember]
        public Decimal CantEntradaNoInicial { get; set; }

        [DataMember]
        public Decimal CantEntrada { get; set; }

        [DataMember]
        public Decimal CostEntrada { get; set; }

        [DataMember]
        public Decimal TotalEntrada { get; set; }

        [DataMember]
        public Decimal CantSalida { get; set; }

        [DataMember]
        public Decimal CostSalida { get; set; }

        [DataMember]
        public Decimal TotalSalida { get; set; }

        [DataMember]
        public Decimal CantFinal { get; set; }

        [DataMember]
        public Decimal CostFinal { get; set; }

        [DataMember]
        public Decimal TotalFinal { get; set; }

        [DataMember]
        public String NomOperacion { get; set; }

        [DataMember]
        public String Estado { get; set; }

        [DataMember]
        public String CodSunat { get; set; }

        //Extensiones
        [DataMember]
        public string codArticulo { get; set; }

        [DataMember]
        public int Tipo { get; set; }

        [DataMember]
        public Decimal cantAnte { get; set; }

        [DataMember]
        public Decimal CostoAnte { get; set; }

        [DataMember]
        public Decimal CostoActual { get; set; }

        [DataMember]
        public KardexValorizadoE SaldoAnterior { get; set; }

        [DataMember]
        public DateTime? fecPrueba { get; set; }

        [DataMember]
        public DateTime? FechaProceso { get; set; }

        [DataMember]
        public Decimal PorcentajeGerminacion { get; set; }

        [DataMember]
        public String Batch { get; set; }

        [DataMember]
        public String LoteProveedor { get; set; }

        [DataMember]
        public String LoteAlmacen { get; set; }
        

        [DataMember]
        public String Lote { get; set; }

        [DataMember]
        public String DesUniMedAlmacen { get; set; }

        [DataMember]
        public String DesUniMedEnvase { get; set; }

        [DataMember]
        public String DesUniMedPres { get; set; }

        [DataMember]
        public String DesArticuloLargo { get; set; }

        [DataMember]
        public String DesArticuloCorto { get; set; }

        [DataMember]
        public Decimal PesoUnit { get; set; }

        [DataMember]
        public Decimal Contenido { get; set; }

        [DataMember]
        public String nomArticulo { get; set; }

        [DataMember]
        public String TipDoc { get; set; }

        [DataMember]
        public String codsunatmed { get; set; }

        [DataMember]
        public String Asiento { get; set; }        

        [DataMember]
        public String CodPeriodo { get; set; }

        [DataMember]
        public String CUO { get; set; }

        [DataMember]
        public String NumCorrelativo { get; set; }

        [DataMember]
        public String CodEstablecimiento { get; set; }

        [DataMember]
        public String CodCatalogo { get; set; }

        [DataMember]
        public String TipExistencia { get; set; }

        [DataMember]
        public String CodExistencia { get; set; }

        [DataMember]
        public DateTime FechaEmision { get; set; }

        [DataMember]
        public String TipDocumento { get; set; }

        [DataMember]
        public String NumSerie { get; set; }

        [DataMember]
        public String NumDocum { get; set; }

        [DataMember]
        public String TipOperacion { get; set; }

        [DataMember]
        public String DesExistencia { get; set; }

        [DataMember]
        public String CodUniMed { get; set; }

        [DataMember]
        public String CodMetodo { get; set; }

        [DataMember]
        public String CantIngresado { get; set; }

        [DataMember]
        public String CostoUnitarioIng { get; set; }

        [DataMember]
        public String CostoTotalIng { get; set; }

        [DataMember]
        public String CantRetirado { get; set; }

        [DataMember]
        public String CostoUnitarioRet { get; set; }

        [DataMember]
        public String CantSalFinal { get; set; }

        [DataMember]
        public String CostoFinal { get; set; }

        [DataMember]
        public String CostoTotalFin { get; set; }

        [DataMember]
        public String indOperacion { get; set; }

        [DataMember]
        public String desCortaAlmacen { get; set; }
        

    }
}
