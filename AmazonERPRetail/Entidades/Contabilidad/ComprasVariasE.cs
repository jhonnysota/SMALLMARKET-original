using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class ComprasVariasE
    {
        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public String AnioPeriodo { get; set; }

        [DataMember]
        public String MesPeriodo { get; set; }

        [DataMember]
        public Int32 idComprobante { get; set; }

        [DataMember]
        public Int32 idProveedor { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public DateTime fecOperacion { get; set; }

        [DataMember]
        public String tipDocumento { get; set; }
        
        [DataMember]
        public String serDocumento { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public Decimal? tipCambio { get; set; }

        [DataMember]
        public Decimal montAfecto { get; set; }

        [DataMember]
        public Decimal montInafecto { get; set; }

        [DataMember]
        public Decimal montIGV { get; set; }

        [DataMember]
        public Decimal montTotal { get; set; }

        [DataMember]
        public String numRegistro { get; set; }

        [DataMember]
        public String flagGravado { get; set; }

        [DataMember]
        public DateTime? fecRef { get; set; }

        [DataMember]
        public String tipDocRef { get; set; }

        [DataMember]
        public String serDocRef { get; set; }

        [DataMember]
        public String numDocRef { get; set; }

        [DataMember]
        public Boolean indRectificacion { get; set; }

        [DataMember]
        public DateTime? fecRectificacion { get; set; }

        [DataMember]
        public Decimal impAfectoRef { get; set; }

        [DataMember]
        public Decimal impIGVRef { get; set; }

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
        public String NomDocumento { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String DesPersona { get; set; }
        
    }
}
