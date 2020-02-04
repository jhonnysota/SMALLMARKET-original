using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Entidades.Maestros;

namespace Entidades.Seguridad
{
    [DataContract]
    [Serializable]
    public class Usuario
    {

        public Usuario()
        {
            ListaUsuarioEmpresaLocal = new List<UsuarioEmpresaLocal>();
            listaUsuarioCCostos = new List<UsuarioCCostosE>();
            ListaUsuarioPlanilla = new List<UsuarioPlanillaE>();
            ListaSeries = new List<UsuarioSeriesE>();
            ListaPuntosReq = new List<UsuarioPuntoRequeE>();
            ListaUsuarioAreas = new List<UsuarioAreasE>();
            ListaUsuarioAlmacen = new List<UsuarioAlmacenE>();
            ListaUsuarioFondoFijo = new List<UsuarioFondoFijoE>();
        }

        [DataMember]
        public int IdPersona { get; set; }

        [DataMember]
        public string Credencial { get; set; }

        [DataMember]
        public String NombreCorto { get; set; }

        [DataMember]
        public byte[] Clave { get; set; }

        [DataMember]
        public bool Estado { get; set; }

        [DataMember]
        public bool Reset { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public string UsuarioRegistro { get; set; }

        [DataMember]
        public string UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime FechaModificacion { get; set; }

        #region Extensiones

        [DataMember]
        public List<Rol> Roles { get; set; }

        [DataMember]
        public List<AccionE> Acciones { get; set; }

        [DataMember]
        public List<Empresa> UsuarioEmpresas { get; set; }

        [DataMember]
        public List<LocalE> UsuarioLocales { get; set; }

        [DataMember]
        public List<Opcion> UsuarioOpciones { get; set; }

        [DataMember]
        public List<Area> UsuarioAreas { get; set; }

        [DataMember]
        public List<UsuarioEmpresaLocal> ListaUsuarioEmpresaLocal { get; set; }

        [DataMember]
        public List<UsuarioEmpresaLocalPerfil> ListaUsuarioEmpresaLocalPerfil { get; set; }

        [DataMember]
        public List<UsuarioCCostosE> listaUsuarioCCostos { get; set; }

        [DataMember]
        public List<UsuarioPlanillaE> ListaUsuarioPlanilla { get; set; }

        [DataMember]
        public List<AsignarTipoCobranzaE> ListaTipoCobranzas { get; set; }

        [DataMember]
        public List<UsuarioSeriesE> ListaSeries { get; set; }

        [DataMember]
        public List<UsuarioPuntoRequeE> ListaPuntosReq { get; set; }

        [DataMember]
        public List<UsuarioAreasE> ListaUsuarioAreas { get; set; }

        [DataMember]
        public List<UsuarioAlmacenE> ListaUsuarioAlmacen { get; set; }

        [DataMember]
        public List<UsuarioFondoFijoE> ListaUsuarioFondoFijo { get; set; }

        [DataMember]
        public Empresa Empresa { get; set; }

        [DataMember]
        public Persona Persona { get; set; }

        [DataMember]
        public string TipoDocumento { get; set; }

        [DataMember]
        public string NombreCompleto { get; set; }

        [DataMember]
        public string NroDocumento { get; set; }

        [DataMember]
        public string Correo { get; set; }

        [DataMember]
        public String NombreCompuesto { get; set; }

        #endregion

    }
}
