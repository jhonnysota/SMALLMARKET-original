using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class Empresa
    {

        #region Entidad

        public Empresa()
        {
            ListaEmpresaImagenes = new List<EmpresaImagenesE>();
        }
        
        [DataMember]
        public Int32 IdEmpresa { get; set; }

        [DataMember]
        //[Required(ErrorMessage = "Debe llenar el Nombre Comercial")]
        //[StringLength(100, ErrorMessage = "El nombre debe tener menos de 100 caracteres")]
        public String NombreComercial { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String DireccionCompleta { get; set; }

        [DataMember]
        //[Min(1, ErrorMessage = "Debe escoger el ubigeo(Departamento, Provincia y Distrito)")]
        public String idUbigeo { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String RepresentanteLegal { get; set; }

        [DataMember]
        public String sNumDocRepresentante { get; set; }

        [DataMember]
        public String sTelefonos { get; set; }

        [DataMember]
        public String sFax { get; set; }

        [DataMember]
        public String sEmail { get; set; }

        [DataMember]
        public String sEmailFe { get; set; }

        [DataMember]
        public String sEmailOtros { get; set; }

        [DataMember]
        public String ClaveOtros { get; set; }

        [DataMember]
        public Int32 PuertoOtros { get; set; }

        [DataMember]
        public String ServidorSalienteOtros { get; set; }

        [DataMember]
        public Boolean HabilitaSslOtros { get; set; }

        [DataMember]
        public String sWeb { get; set; }

        [DataMember]
        public String Fda { get; set; }

        [DataMember]
        public Boolean PrincipalContribuyente { get; set; }

        [DataMember]
        public Boolean AgenteRetenedor { get; set; }

        [DataMember]
        public byte[] UsuarioSol { get; set; }

        [DataMember]
        public byte[] ClaveSol { get; set; }

        [DataMember]
        public Boolean indCalzado { get; set; }

        [DataMember]
        public Boolean Estado { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime FechaModificacion { get; set; }

        #endregion

        #region Extensiones

        [DataMember]
        public String Departamento { get; set; }

        [DataMember]
        public String Provincia { get; set; }

        [DataMember]
        public String Distrito { get; set; }

        [DataMember]
        public String Direccion { get; set; }

        [DataMember]
        public List<EmpresaImagenesE> ListaEmpresaImagenes { get; set; }

        #endregion

    }
}
