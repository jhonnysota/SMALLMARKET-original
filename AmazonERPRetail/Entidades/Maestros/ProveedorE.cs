using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public partial class ProveedorE
    {

        #region Entidad

        public ProveedorE()
        {
            Persona = new Persona();
        }

        [DataMember]
        public int IdPersona { get; set; }

        [DataMember]
        public int IdEmpresa { get; set; }

        [DataMember]
        public int? TipoProveedor { get; set; }

        [DataMember]
        public String SiglaComercial { get; set; }

        [DataMember]
        public DateTime? fecInscripcion { get; set; }

        [DataMember]
        public DateTime? fecInicioActividad { get; set; }

        [DataMember]
        public int? tipConstitucion { get; set; }

        [DataMember]
        public int? tipRegimen { get; set; }

        [DataMember]
        public int? catProveedor { get; set; }

        [DataMember]
        public String indBaja { get; set; }

        [DataMember]
        public DateTime? fecBaja { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime FechaModificacion { get; set; }

        //ListaDetalle
        [DataMember]
        public List<ProveedorContactoE> ListaProveedorContacto { get; set; }

        //ListaDetalle2
        [DataMember]
        public List<ProveedorCuentaE> ListaProveedorCuenta { get; set; }

        #endregion

        #region Extensiones

        [DataMember]
        public Persona Persona { get; set; }

        [DataMember]
        public String TipoDocumento { get; set; }

        [DataMember]
        public String NombreCompleto { get; set; }

        [DataMember]
        public String NroDocumento { get; set; } 

        [DataMember]
        public String NombreTipoProveedor { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String DireccionCompleta { get; set; }

        [DataMember]
        public Int32 idCanalVenta { get; set; }

        #endregion

    }
}
