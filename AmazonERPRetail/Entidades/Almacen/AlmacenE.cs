using System;
using System.Runtime.Serialization;
//using System.ComponentModel.DataAnnotations;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class AlmacenE
    {
        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idAlmacen { get; set; }

        [DataMember]
        public Int32? Clase { get; set; }

        [DataMember]
        public Int32? tipAlmacen { get; set; }

        [DataMember]
        public String desAlmacen { get; set; }

        [DataMember]
        public String desCorta { get; set; }

        [DataMember]
        public String Direccion { get; set; }

        [DataMember]
        public Boolean VerificaStock { get; set; }

        [DataMember]
        public Boolean VerificaLote { get; set; }

        [DataMember]
        public String TipoNumeracion { get; set; }

        [DataMember]
        public String desResponsable { get; set; }

        [DataMember]
        public String EmailResponsable { get; set; }

        [DataMember]
        public String tlfResponsable { get; set; }

        [DataMember]
        public String idCCostos { get; set; }

        [DataMember]
        public Boolean indEstado { get; set; }

        [DataMember]
        public DateTime? fecBaja { get; set; }

        [DataMember]
        public String indUbiGenerica { get; set; }

        [DataMember]
        public String idUbicacion { get; set; }

        [DataMember]
        public String SiglaLoteAlmacen { get; set; }

        [DataMember]
        public String CodEstablecimiento { get; set; }

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
        public String desCostos { get; set; }

        [DataMember]
        public String desUbicacion { get; set; }

        [DataMember]
        public Boolean EsCalzado { get; set; }

        [DataMember]
        public String TipoAlmacen { get; set; }

        [DataMember]
        public String desTipAlmacen { get; set; }

        [DataMember]
        public String desTemporal { get; set; }

    }   
}