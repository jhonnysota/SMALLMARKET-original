using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class SolicitudProveedorE
    {

        public SolicitudProveedorE()
        {
            oListaSolicitudes = new List<SolicitudProveedorDetE>();
        }

        [DataMember]
		public Int32 idSolicitud { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public String codSolicitud { get; set; }

		[DataMember]
		public DateTime Fecha { get; set; }

        [DataMember]
        public Int32 idProveedor { get; set; }

        [DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Decimal impTotal { get; set; }

		[DataMember]
		public String Descripcion { get; set; }

		[DataMember]
		public String Pedido { get; set; }

		[DataMember]
		public Int32? idOrdenPago { get; set; }

        [DataMember]
        public Int32? idConcepto { get; set; }

        [DataMember]
        public Decimal Saldo { get; set; }

        [DataMember]
        public String indEstado { get; set; }// C=Cancelado A=Aprobado P=Pendiente

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
        public List<SolicitudProveedorDetE> oListaSolicitudes { get; set; }

        [DataMember]
        public List<SolicitudProveedorDetE> oSolicitudesDel { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String codOrdenPago { get; set; }

        [DataMember]
        public String ctaBancaria { get; set; }

        [DataMember]
        public String desLocal { get; set; }

        [DataMember]
        public String TipoSolicitud { get; set; } //T=Terceros P=Personal R=Proveedor que viene del Concepto

    }   
}