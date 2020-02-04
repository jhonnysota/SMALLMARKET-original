using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public class RequisicionE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idRequisicion { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

        [DataMember]
        public Int32 idLocalAtencion { get; set; }       

        [DataMember]
        public String SiglaSucursal { get; set; }

        [DataMember]
        public String DesLocal { get; set; }

        [DataMember]
        public String DesLocalAtencion { get; set; }

        [DataMember]
        public String numRequisicion { get; set; }

		[DataMember]
		public Int32 tipRequisicion { get; set; }

		[DataMember]
		public String tipCompra { get; set; }

		[DataMember]
		public String idCCostos { get; set; }

        [DataMember]
        public String desCCostos { get; set; }

        [DataMember]
		public DateTime? FechaSolicitud { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Decimal impCostoEstimado { get; set; }

		[DataMember]
		public String Justificacion { get; set; }

		[DataMember]
		public String Observacion { get; set; }

		[DataMember]
		public DateTime? FechaRequerida { get; set; }

		[DataMember]
		public String tipEstado { get; set; }

		[DataMember]
		public String tipEstadoOC { get; set; }

		[DataMember]
		public String tipEstadoAtencion { get; set; }

		[DataMember]
		public String numLicitacion { get; set; }

		[DataMember]
		public String indLicitacion { get; set; }

        [DataMember]
        public Int32 idAlmacenEntrega { get; set; }

        [DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }


        //Detalle
        [DataMember]
        public List<RequisicionItemE> ListaRequisicionItem { get; set; }

        [DataMember]
        public List<RequisicionProveedorE> ListaRequisionProveedor { get; set; }

        [DataMember]
        public String DesTipRequisicion { get; set; }

        [DataMember]
        public String DesTipModalCompra { get; set; }

        [DataMember]
        public String DesMoneda { get; set; }

        [DataMember]
        public String Nombre { get; set; }

        [DataMember]
        public String tipoCCosto { get; set; }
        

    }   
}