using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class PresupuestoVentaE
    {

        public PresupuestoVentaE()
        {
            ListaPresupuestoVentaDet = new List<PresupuestoVentaDetE>();
        }

        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public String AnioPresupuesto { get; set; }
		[DataMember]		public Int32 idVendedor { get; set; }
		[DataMember]		public Int32? idTipoArticulo { get; set; }
		[DataMember]		public String idMoneda { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }

        [DataMember]
        public String Vendedor { get; set; }

        [DataMember]
        public String DesTipoArticulo { get; set; }

        [DataMember]
        public String DesMoneda { get; set; }


        [DataMember]
        public List<PresupuestoVentaDetE> ListaPresupuestoVentaDet { get; set; }
    }   
}