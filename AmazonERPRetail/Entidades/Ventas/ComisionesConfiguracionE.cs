using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class ComisionesConfiguracionE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }
		[DataMember]
		public Int32 idComision { get; set; }
        [DataMember]
        public Int32 idPeriodo { get; set; }
		[DataMember]
		public String NombreZona { get; set; }
		[DataMember]
		public String Estado { get; set; }
        [DataMember]
        public Int32 idComisionCategoria { get; set; }
        [DataMember]
        public Int32 idCategoria { get; set; }
        [DataMember]
        public Int32 idComisionTarifario { get; set; }
        [DataMember]
        public Int32 idComisionCriterio { get; set; }
        [DataMember]
        public Int32 idParTabla { get; set; }
        [DataMember]
        public Int32 idComisionVendedor { get; set; }
        [DataMember]
        public Int32 idVendedor { get; set; }
        [DataMember]
        public Int32 idComisionLinea { get; set; }
        [DataMember]
        public Int32 idLinea { get; set; }



        [DataMember]
        public Decimal Meta { get; set; }
        [DataMember]
        public Decimal Resultado { get; set; }
        [DataMember]
        public Decimal Porcentaje { get; set; }
        [DataMember]
        public Decimal Pago { get; set; }

        [DataMember]
        public Decimal RangoIni { get; set; }
        [DataMember]
        public Decimal RangoFin { get; set; }

        [DataMember]
        public Decimal Factor { get; set; }
        [DataMember]
        public Decimal Comision { get; set; }






        [DataMember]
        public String desCategoria { get; set; }
        [DataMember]
        public String desLinea { get; set; }
        [DataMember]
        public String desParTabla { get; set; }
        [DataMember]
        public String desPersona { get; set; }






		[DataMember]
		public String UsuarioRegistra { get; set; }
		[DataMember]
		public DateTime? FechaRegistra { get; set; }
		[DataMember]
		public String UsuarioModifica { get; set; }
		[DataMember]
		public DateTime? FechaModifica { get; set; }


         
         [DataMember]
         public List<ComisionesConfiguracionE> oListaCategoria { get; set; }
         [DataMember]
         public List<ComisionesConfiguracionE> oListaLinea { get; set; }
         [DataMember]
         public List<ComisionesConfiguracionE> oListaTarifario { get; set; }
         [DataMember]
         public List<ComisionesConfiguracionE> oListaCriterio { get; set; }
         [DataMember]
         public List<ComisionesConfiguracionE> oListaVendedor { get; set; }

         [DataMember]
         public String TipoTabla { get; set; }

    }   
}