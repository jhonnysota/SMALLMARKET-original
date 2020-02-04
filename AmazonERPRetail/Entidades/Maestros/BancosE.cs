using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public partial class BancosE
    {

        public BancosE()
        {
            Persona = new Persona();
            ListaCuentas = new List<BancosCuentasE>();
        }

        [DataMember]
		public Int32 idPersona { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public String SiglaComercial { get; set; }

		[DataMember]
		public String codSunat { get; set; }

		[DataMember]
		public Boolean indBaja { get; set; }

		[DataMember]
		public DateTime? fecBaja { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        // Campos Adicionales
        [DataMember]
        public List<BancosCuentasE> ListaCuentas { get; set; }

        [DataMember]
        public Persona Persona { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String DireccionCompleta { get; set; }

    }   
}