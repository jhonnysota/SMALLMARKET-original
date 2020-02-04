using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class MedioPagoE
    {
        [DataMember]
        public Int32 idMedioPago { get; set; }

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public String Codigo { get; set; }

        [DataMember]
        public String Nombre { get; set; }

        [DataMember]
        public String indDebeHaber { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public Boolean indAuxiliar { get; set; }

        [DataMember]
        public Int32? idAuxiliar { get; set; }

        [DataMember]
        public Boolean indPtoVta { get; set; }

        [DataMember]
        public bool indCredito { get; set; }

        [DataMember]
        public Boolean indBaja { get; set; }

        [DataMember]
        public DateTime? FechaBaja { get; set; }

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
        public String desCuenta { get; set; }

        [DataMember]
        public String Ruc { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public int idMedSunat { get; set; }

    }
}
