using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class NumControlDetE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idControl { get; set; }

        [DataMember]
        public Int32 item { get; set; }

		[DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String Serie { get; set; }

		[DataMember]
		public Int32? cantDigSerie { get; set; }

		[DataMember]
		public String numInicial { get; set; }

		[DataMember]
		public String numFinal { get; set; }

        [DataMember]
        public String numCorrelativo { get; set; }

		[DataMember]
		public Int32? cantDigNumero { get; set; }

		[DataMember]
		public DateTime? fecInicio { get; set; }

		[DataMember]
		public DateTime? fecFinal { get; set; }

		[DataMember]
		public String indEstadoInicial { get; set; }

		[DataMember]
		public Int32? idCondicion { get; set; }

		[DataMember]
		public Int32? idVendedor { get; set; }

		[DataMember]
		public Int32? idTransporte { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Int32? idTipTraslado { get; set; }

		[DataMember]
		public String indEstadoDocu { get; set; }

		[DataMember]
		public Int32? idAlmacen { get; set; }

		[DataMember]
		public Boolean FlagCantUnit { get; set; }

		[DataMember]
		public Int32? ListaPrecio { get; set; }

		[DataMember]
		public Int32? idCliente { get; set; }

		[DataMember]
		public String Formato { get; set; }

		[DataMember]
		public String EsGuia { get; set; }

		[DataMember]
		public String PuntoPartida { get; set; }

        [DataMember]
        public String PuntoLlegada { get; set; }

		[DataMember]
		public String PuntoVenta { get; set; }

		[DataMember]
		public String TipoAsiento { get; set; }

		[DataMember]
		public Int32? cantCopias { get; set; }

		[DataMember]
		public Int32? cantItems { get; set; }

		[DataMember]
		public String numCaja { get; set; }

		[DataMember]
		public String numSerieCaja { get; set; }

		[DataMember]
		public String EsContado { get; set; }

		[DataMember]
		public Boolean ExigirGuia { get; set; }

		[DataMember]
		public Boolean ExigirDatos { get; set; }

		[DataMember]
		public String nomImpresora { get; set; }

        [DataMember]
        public String Grupo { get; set; }

        [DataMember]
        public Int32 cantDigDecimales { get; set; }

        [DataMember]
        public Int32 cantCaracteres { get; set; }

        [DataMember]
        public Int32 Orden { get; set; }

        [DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public String desDocumento { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String Tipo { get; set; }

        [DataMember]
        public String desTipoTraslado { get; set; }

        [DataMember]
        public String nomVendedor { get; set; }

        [DataMember]
        public String desDocCompuesto { get; set; }

    }   
}