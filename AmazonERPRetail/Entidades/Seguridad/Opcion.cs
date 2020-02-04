using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Seguridad
{
    [DataContract]
    [Serializable]
    public partial class Opcion
    {

        public Opcion()
        {    
            Descripcion = String.Empty;
            Ubicacion = String.Empty;      
            GrupoOpcion = 1;
            Observacion = String.Empty;
            Total = true;
            
        }

        [DataMember]
        public Int32 IdOpcion { get; set; }

        [DataMember]
        public String Nombre { get; set; }

        [DataMember]        
        public String Descripcion { get; set; }

        [DataMember]
        public String Ubicacion { get; set; }

        [DataMember]
        public Int32 TipoAplicacion { get; set; }

        [DataMember]
        public Int32 GrupoOpcion { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime FechaActualizacion { get; set; }

        [DataMember]
        public String UsuarioActualizacion { get; set; }
        
        #region Extension

        [DataMember]
        public Boolean control { get; set; }

        [DataMember]
        public Int32 Orden { get; set; }

        [DataMember]
        public String Observacion { get; set; }

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public String nombreTipoAplicacion { get; set; }

        [DataMember]
        public String nombreGrupo { get; set; }

        [DataMember]
        public Boolean OK { get; set; }

        [DataMember]
        public Boolean Total { get; set; } //Para los permisos

        [DataMember]
        public Boolean Agregar { get; set; } //Para los permisos

        [DataMember]
        public Boolean Modificar { get; set; } //Para los permisos

        [DataMember]
        public Boolean Consultar { get; set; } //Para los permisos

        [DataMember]
        public Boolean Eliminar { get; set; } //Para los permisos

        #endregion       

    }

}
