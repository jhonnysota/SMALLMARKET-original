using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Generales
{
    [DataContract]
    [Serializable]
    public class ImpuestosE
    {
            
        [DataMember]
		public Int32 idImpuesto { get; set; }

        //[DataMember]
        //public Int32 idEmpresa { get; set; }

		[DataMember]
		public String numVerPlanCuentas { get; set; }

		[DataMember]
		public String codCuenta { get; set; }

		[DataMember]
		public String desImpuesto { get; set; }

		[DataMember]
		public String desAbreviatura { get; set; }

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
        public List<ImpuestosPeriodoE>listaImpuestosPeriodo  { get; set; }

        [DataMember]
        public String desCuenta { get; set; }

    }   
}