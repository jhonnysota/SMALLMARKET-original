using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class ComprobantesFileE
    {

        [DataMember]
        public int idEmpresa { get; set; }

        [DataMember]
        public String idComprobante { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public String Descripcion { get; set; }

        [DataMember]
        public String DesLarga { get; set; }

        [DataMember]
        public Boolean flagAutomatico { get; set; }

        [DataMember]
        public Boolean flagIndFlujo { get; set; }

        [DataMember]
        public String IndForma { get; set; }

        [DataMember]
        public Boolean flagIndPartidaPres { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public Boolean LLevaCuenta { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public String codCuentaSoles { get; set; }

        [DataMember]
        public String codCuentaDolar { get; set; }

        [DataMember]
        public Boolean indPorExtornar { get; set; }

        [DataMember]  
		public String UsuarioRegistro { get; set; }  

		[DataMember]  
		public DateTime? FechaRegistro { get; set; }  

		[DataMember]  
		public String UsuarioModificacion { get; set; }  

		[DataMember]  
		public DateTime? FechaModificacion { get; set; }

        #region Campos Adicionales

        [DataMember]
        public Int32 Opcion { get; set; } //Para saber si la fila del detalle se inserta o se actualiza

        [DataMember]
        public String desFileComp { get; set; }

        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public String desCuentaSoles { get; set; }

        [DataMember]
        public String desCuentaDolar { get; set; }

        [DataMember]
        public Int32 idBanco { get; set; }

        #endregion

    }
}