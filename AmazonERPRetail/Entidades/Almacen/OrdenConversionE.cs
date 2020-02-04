using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{

    [DataContract]
    [Serializable]
    public partial class OrdenConversionE
    {
        public OrdenConversionE()
        {
            ListaConverDetalle = new List<OrdenConversionDetalleE>();
            ListaConverSalida = new List<OrdenConversionSalidaE>();
            ListaGastos = new List<OrdenConversionGastosE>();
        }

        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idOrdenConversion { get; set; }

        [DataMember]
        public DateTime FechaOperacion { get; set; }

        [DataMember]
		public DateTime Fecha { get; set; }

		[DataMember]
		public String Numero { get; set; }

		[DataMember]
		public Boolean indGenerada { get; set; }

        [DataMember]
        public Decimal TotalPeso { get; set; }

        [DataMember]
        public Int32 idConcepto { get; set; } // 0=Producción 1=Cambio de código 2=Transformación

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public Decimal TotalCosto { get; set; }

        [DataMember]
        public Decimal TotalCostoRefe { get; set; }

        [DataMember]
        public String Observacion { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String numSerie { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public Int64 idOrdenCompra { get; set; }

        [DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        //Extensiones
        //Detalle 1
        [DataMember]
        public List<OrdenConversionDetalleE> ListaConverDetalle { get; set; }

        //Detalle 2
        [DataMember]
        public List<OrdenConversionSalidaE> ListaConverSalida { get; set; }

        //Detalle 3
        [DataMember]
        public List<OrdenConversionGastosE> ListaGastos { get; set; }

        //Detalle Eliminados Gastos
        [DataMember]
        public List<OrdenConversionGastosE> ListaGastosEliminados { get; set; }

        [DataMember]
        public String codArticulo { get; set; }

        [DataMember]
        public String NombreArt { get; set; }

        [DataMember]
        public Decimal Contenido { get; set; }

        [DataMember]
        public String nomAlmacen { get; set; }

        [DataMember]
        public String nomUMedidaPres { get; set; }

        [DataMember]
        public String nomUMedidaEnv { get; set; }

        [DataMember]
        public String nomTipoMov { get; set; }

        [DataMember]
        public String NombreCompleto { get; set; }

        [DataMember]
        public Boolean indIngreso { get; set; }

        [DataMember]
        public Decimal CostoUnitario { get; set; }

    }   
}