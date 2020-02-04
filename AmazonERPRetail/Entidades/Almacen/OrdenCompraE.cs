using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class OrdenCompraE
    {

        public OrdenCompraE()
        {
            ListaOrdenesCompras = new List<OrdenCompraItemE>();
        }
            
        [DataMember]
	    public Int32 idEmpresa { get; set; }

	    [DataMember]
	    public Int32 idOrdenCompra { get; set; }

	    [DataMember]
	    public String idMigrar { get; set; }

	    [DataMember]
	    public Int32 idLocal { get; set; }

	    [DataMember]
	    public String numOrdenCompra { get; set; }

        [DataMember]
        public Int32 idRequisicion { get; set; }

        [DataMember]
	    public String numRequisicion { get; set; }

	    [DataMember]
	    public String numCotizacion { get; set; }

	    [DataMember]
	    public Int32 idProveedor { get; set; }

	    [DataMember]
	    public String RUC { get; set; }

	    [DataMember]
	    public String RazonSocial { get; set; }

	    [DataMember]
	    public Int32 tipOrdenCompra { get; set; }
    
	    [DataMember]
	    public Int32 tipSecuenciaFlujo { get; set; }

	    [DataMember]
	    public Int32 tipModalCompra { get; set; }

	    [DataMember]
	    public String idCCostos { get; set; }

	    [DataMember]
	    public DateTime fecEmision { get; set; }

	    [DataMember]
	    public Int32 idArticulo { get; set; }

	    [DataMember]
	    public String tipPartidaPresu { get; set; }

	    [DataMember]
	    public String codPartidaPresu { get; set; }

	    [DataMember]
	    public String idMoneda { get; set; }

	    [DataMember]
	    public DateTime? fecRequerida { get; set; }

	    [DataMember]
	    public String tipEstado { get; set; } //PENDIENTE=PN, APROBADO TOTAL=AT, CERRADO=CE, ANULADO=AN

        [DataMember]
	    public String tipEstadoAtencion { get; set; } //PN=Pendiente AP=Atención Parcial AT=Atendido Total

        [DataMember]
        public String tipEstadoPorFacturar { get; set; } //PN=Pendiente FP= Facturado Parcial FT=Facturado Total

        [DataMember]
        public decimal MontoRecepFactura { get; set; }

        [DataMember]
	    public Int32? numPlazoPago { get; set; }

	    [DataMember]
	    public Int32? numPlazoEntrega { get; set; }

	    [DataMember]
	    public Int32? tipFormaPago { get; set; }

	    [DataMember]
	    public String desFormaPago { get; set; }

	    [DataMember]
	    public Decimal impVenta { get; set; }

	    [DataMember]
	    public Decimal porIsc { get; set; }

	    [DataMember]
	    public Decimal impIsc { get; set; }

	    [DataMember]
	    public Decimal porIgv { get; set; }

	    [DataMember]
	    public Decimal impIgv { get; set; }

	    [DataMember]
	    public Decimal impTotal { get; set; }

	    [DataMember]
	    public String Observacion { get; set; }

	    [DataMember]
	    public String numLicitacion { get; set; }

	    [DataMember]
	    public Boolean indLicitacion { get; set; }

	    [DataMember]
	    public Boolean indConPresu { get; set; }

	    [DataMember]
	    public String UsuarioAprobacion { get; set; }

	    [DataMember]
	    public DateTime? fecAprobacion { get; set; }

	    [DataMember]
	    public String tipCompra { get; set; }

	    [DataMember]
	    public Boolean indIngAlm { get; set; }

	    [DataMember]
	    public Boolean indCampana { get; set; }

	    [DataMember]
	    public Int32 codCampana { get; set; }

	    [DataMember]
	    public String ModoCompra { get; set; }

	    [DataMember]
	    public Int32 idAlmacenEntrega { get; set; }

	    [DataMember]
	    public String LugarEntrega { get; set; }

	    [DataMember]
	    public String Via { get; set; }

	    [DataMember]
	    public String Seguro { get; set; }

	    [DataMember]
	    public Int32? SemanaEmbarqueDe { get; set; }

	    [DataMember]
	    public Int32? SemanaEmbarqueA { get; set; }

	    [DataMember]
	    public String PuertoDescarga { get; set; }

	    [DataMember]
	    public String CondicionEntrega { get; set; }

	    [DataMember]
	    public String codAgencia { get; set; }

	    [DataMember]
	    public Int32 codContacto { get; set; }

	    [DataMember]
	    public String desResponsable { get; set; }

	    [DataMember]
	    public String AnioRequerimiento { get; set; }

	    [DataMember]
	    public String PeriodoRequerimiento { get; set; }

	    [DataMember]
	    public String tipRequerimiento { get; set; }

	    [DataMember]
	    public String numRequerimiento { get; set; }

	    [DataMember]
	    public DateTime? fecAnulacion { get; set; }

        [DataMember]
        public Boolean indDistribucion { get; set; }

	    [DataMember]
	    public String UsuarioRegistro { get; set; }

	    [DataMember]
	    public DateTime? FechaRegistro { get; set; }

	    [DataMember]
	    public String UsuarioModificacion { get; set; }

	    [DataMember]
	    public DateTime? FechaModificacion { get; set; }

        [DataMember]
        public String TipoOrdenCompra { get; set; }

        //Extensiones
        [DataMember]
        public List<OrdenCompraItemE> ListaOrdenesCompras { get; set; }

        [DataMember]
        public List<OrdenCompraDistriE> ListaDistribucion { get; set; }

        [DataMember]
        public String desArticulo { get; set; }

        [DataMember]
        public Decimal CanOrdenada { get; set; }
        
        [DataMember]
        public Decimal impPrecioUnitario { get; set; }

        [DataMember]
        public Decimal impigv { get; set; }

        [DataMember]
        public Decimal impTotalitem { get; set; }

        [DataMember]
        public String deslarga { get; set; }

        [DataMember]
        public String desTipOrdenCompra { get; set; }

        [DataMember]
        public String desTipSecuenciaFlujo { get; set; }

        [DataMember]
        public String desTipModalCompra { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String desTipEstado { get; set; }

        [DataMember]
        public String desTipEstadoAtencion { get; set; }

        [DataMember]
        public String desTipCompra { get; set; }

        [DataMember]
        public String desCCostos { get; set; }

        [DataMember]
        public String tipoCCosto { get; set; }

        [DataMember]
        public String desPartidaPresu { get; set; }

        [DataMember]
        public String desCampana { get; set; }

        [DataMember]
        public String Correo { get; set; }

        [DataMember]
        public String CorreoContacto { get; set; }

        [DataMember]
        public String NomContacto { get; set; }

        [DataMember]
        public string desTipEstadoFacturar { get; set; }

        [DataMember]
        public decimal Saldo { get; set; }

        [DataMember]
        public String DesAlm { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String numSerie { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public DateTime? fecDocumento { get; set; }

        [DataMember]
        public String dirProveedor { get; set; } //Dirección del proveedor

        //Los otros campos que faltan estan en la parte superior...
        #region Campos Faltantes de la Orden de Compra

        [DataMember]
        public Int32 idDocumentoAlmacen { get; set; }

        [DataMember]
        public String numItem { get; set; }

        [DataMember]
        public String codArticulo { get; set; }

        [DataMember]
        public DateTime fecAlmacen { get; set; }

        [DataMember]
        public Decimal impCostoS { get; set; }

        [DataMember]
        public Decimal impCostoD { get; set; }

        [DataMember]
        public Decimal impCostoTotS { get; set; }

        [DataMember]
        public Decimal impCostoTotD { get; set; }

        [DataMember]
        public Decimal impDocSoles { get; set; }

        [DataMember]
        public Decimal impDocDolar { get; set; }

        [DataMember]
        public String Voucher { get; set; }

        [DataMember]
        public String Cuenta { get; set; }

        [DataMember]
        public String CuentaDestino { get; set; }

        [DataMember]
        public String Moneda { get; set; }

        #endregion

    }
}