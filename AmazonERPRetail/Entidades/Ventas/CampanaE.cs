using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class CampanaE
    {
         [DataMember]
         public Int32 idCampana { get; set; }

         [DataMember]
         public Int32 idEmpresa { get; set; }

         [DataMember]
         public String Nombre { get; set; }

         [DataMember]
         public DateTime? Inicio { get; set; }

         [DataMember]
         public DateTime? Fin { get; set; }

         [DataMember]
         public String Estado { get; set; }

         [DataMember]
         public Boolean Focus { get; set; }

         [DataMember]
         public Boolean EstadoPrecio { get; set; }

         [DataMember]
         public Boolean EstadoDirectoras { get; set; }

         [DataMember]
         public String Tipo { get; set; }

         [DataMember]
         public String Titulo { get; set; }

         [DataMember]
         public Boolean MostrarPedWeb { get; set; }

         [DataMember]
         public Boolean MostrarDevWeb { get; set; }

         [DataMember]
         public Boolean EsDiferido { get; set; }

         [DataMember]
         public Int32 idTipoCampana { get; set; }

         [DataMember]
         public String EstadoCampana { get; set; }

         [DataMember]
         public Boolean EstadoActivarArticulo { get; set; }

         [DataMember]
         public String UsuarioRegistro { get; set; }

         [DataMember]
         public DateTime? FechaRegistro { get; set; }

         [DataMember]
         public String UsuarioModificacion { get; set; }

         [DataMember]
         public DateTime? FechaModificacion { get; set; }
    }
}
