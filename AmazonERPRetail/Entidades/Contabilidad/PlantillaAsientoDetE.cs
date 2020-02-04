using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class PlantillaAsientoDetE
    {
            
        [DataMember]
		public Int32 idPlantilla { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 Item { get; set; }

		[DataMember]
		public String numVerPlanCuentas { get; set; }

		[DataMember]
		public String codCuenta { get; set; }

		[DataMember]
		public String indDebeHaber { get; set; }

		[DataMember]
		public Int32? codColumnaCoven { get; set; }

        [DataMember]
        public String Calculo { get; set; }

        [DataMember]
        public Boolean indDetalle { get; set; }

        [DataMember]
        public Int32? Hoja { get; set; }

        [DataMember]
        public String Refe1 { get; set; }

        [DataMember]
        public String Refe2 { get; set; }

        [DataMember]
        public Boolean QuitarDH { get; set; }

        [DataMember]
        public Boolean indContraPart { get; set; }

        [DataMember]
        public String ctaContraPart { get; set; }

        [DataMember]
        public Boolean Seguir { get; set; }

        [DataMember]
        public Boolean Saltar { get; set; }

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
        public PlanCuentasE oPlanCuentas { get; set; }

        [DataMember]
        public String idCCostos { get; set; }

        [DataMember]
        public Decimal Monto { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String desDocumento { get; set; }

        [DataMember]
        public String Serie { get; set; }

        [DataMember]
        public String Numero { get; set; }

        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public Int32 idPersona { get; set; }

        [DataMember]
        public String nroDocumento { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

    }   
}