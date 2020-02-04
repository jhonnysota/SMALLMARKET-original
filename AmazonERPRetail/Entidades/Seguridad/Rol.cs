using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Seguridad
{
    [DataContract]
    [Serializable]
    public class Rol
    {
        public Rol() 
        {            
            Descripcion = "";
            OpcionesRol = new List<Opcion>();
        }

        [DataMember]
        public int IdRol { get; set; }
        
        [DataMember]
        public string Nombre { get; set; }
        
        [DataMember]        
        public string Descripcion { get; set; }
        
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        
        [DataMember]
        public string UsuarioRegistro { get; set; }
        
        [DataMember]
        public Boolean Estado { get; set; }
        
        [DataMember]
        public DateTime FechaModificacion { get; set; }
        
        [DataMember]
        public string UsuarioModificacion { get; set; }
        
        //Extensiones
        [DataMember]
        public List<Opcion> OpcionesRol { get; set; }

    }



}