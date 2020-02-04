using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Entidades.Seguridad;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class Persona
    {

        public Persona()
        {
            ListaPersonaDireccion = new List<PersonaDireccionE>();
        }

        #region Entidad

        [DataMember]
        public Int32 IdPersona { get; set; }

        [DataMember]
        public Int32 TipoPersona { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String ApePaterno { get; set; }

        [DataMember]
        public String ApeMaterno { get; set; }

        [DataMember]
        public String Nombres { get; set; }

        [DataMember]
        public Int32 TipoDocumento { get; set; }

        [DataMember]
        public String NroDocumento { get; set; }

        [DataMember]
        public String Telefonos { get; set; }

        [DataMember]
        public String Fax { get; set; }

        [DataMember]
        public String Correo { get; set; }        

        [DataMember]
        public String Web { get; set; }

        [DataMember]
        public String DireccionCompleta { get; set; }

        [DataMember]
        public Int32 idPais { get; set; }

        [DataMember]
        public String idUbigeo { get; set; }

        [DataMember]
        public Boolean PrincipalContribuyente { get; set; }

        [DataMember]
        public Boolean AgenteRetenedor { get; set; }

        [DataMember]
        public Int32? idCanalVenta { get; set; }

        [DataMember]
        public Boolean Estado { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime FechaModificacion { get; set; }

        #endregion

        #region Extensiones

        [DataMember]
        public List<PersonaDireccionE> ListaPersonaDireccion { get; set; }

        [DataMember]
        public String TipoPersonaDes { get; set; }

        [DataMember]
        public String TipoDocumentoDes { get; set; }

        [DataMember]
        public Int32 TipoRelacionPersona { get; set; }

        [DataMember]
        public String DirecCompleta { get; set; }

        [DataMember]
        public String CodigoTrabajador { get; set; }

        [DataMember]
        public List<UsuarioEmpresaLocal> ListaPersonaEmpresaLocal { get; set; }

        [DataMember]
        public Int32 TipoCliente { get; set; }

        [DataMember]
        public Boolean Cli { get; set; }

        [DataMember]
        public Boolean Pro { get; set; }

        [DataMember]
        public Boolean Tra { get; set; }

        [DataMember]
        public Boolean Ban { get; set; }

        [DataMember]
        public String NemoTipPer { get; set; }

        [DataMember]
        public Int32? idAsociado { get; set; }

        [DataMember]
        public List<ClienteAvalE> oListaAvales { get; set; }

        [DataMember]
        public Boolean ManejaCartera { get; set; }

        [DataMember]
        public Int32 idPersonaResponsable { get; set; }

        [DataMember]
        public String desResponsable { get; set; }

        [DataMember]
        public String nroDocResponsable { get; set; }

        [DataMember]
        public Int32 idBancoPago { get; set; }

        [DataMember]
        public Int32 idTipoCuentaPago { get; set; }

        [DataMember]
        public String idMonedaPago { get; set; }

        [DataMember]
        public String NumCuentaPago { get; set; }

        [DataMember]
        public Int32 idDivision { get; set; }

        [DataMember]
        public String desPais { get; set; }

        [DataMember]
        public String desDep { get; set; }

        [DataMember]
        public String desDis { get; set; }

        [DataMember]
        public String desPro { get; set; }

        [DataMember]
        public String idMoneda { get; set; }


        #endregion

    }
}
