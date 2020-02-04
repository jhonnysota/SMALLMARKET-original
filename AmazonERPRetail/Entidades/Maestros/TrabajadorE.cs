using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class TrabajadorE
    {

        public TrabajadorE()
        {
            Genero = "M";
            FechaRegPensionario = DateTime.Now.Date;
            FechaNacimiento = DateTime.Now.Date;
        }

        [DataMember]
		public Int32 idPersona { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public String Genero { get; set; }

        [DataMember]
        public DateTime FechaNacimiento { get; set; }

        [DataMember]
        public Int32 idPaisNacimiento { get; set; }

        [DataMember]
        public String idUbigeoNacimiento { get; set; }

        [DataMember]
        public Int32 idVia { get; set; }

        [DataMember]
        public String nomVia { get; set; }

        [DataMember]
        public String numero { get; set; }

        [DataMember]
        public String interior { get; set; }

        [DataMember]
        public Int32 idZona { get; set; }

        [DataMember]
        public String nomZona { get; set; }

        [DataMember]
        public String referencia { get; set; }

        [DataMember]
        public DateTime FechaRegPensionario { get; set; }

        [DataMember]
        public Int32 idCategoria { get; set; }

		[DataMember]
		public String CodigoTrabajador { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

        //EXTENSORES
        [DataMember]
        public Persona Persona { get; set; }

        //[DataMember]
        //public EstadoTrabajadorE Estado { get; set; }

        //[DataMember]
        //public PeriodoTrabajadorE Periodo { get; set; }

        //[DataMember]
        //public DerechoHabienteE DerechoHabiente { get; set; }

        //[DataMember]
        //public ExperienciaLaboralE ExperienciaLaboral { get; set; }

        [DataMember]
        public String ApePaterno { get; set; }

        [DataMember]
        public String ApeMaterno { get; set; }

        [DataMember]
        public String Nombres { get; set; }

        [DataMember]
        public String NroDocumento { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String Correo { get; set; }

        [DataMember]
        public String desCategoria { get; set; }

        [DataMember]
        public Boolean FlagPeriodo { get; set; }

        [DataMember]
        public String RutaImagen { get; set; }

        [DataMember]
        public String NombreReal { get; set; }

        [DataMember]
        public String NombreImagen { get; set; }

        [DataMember]
        public String Extension { get; set; }

        [DataMember]
        public Byte[] Imagen { get; set; }

        [DataMember]
        public String Archivo { get; set; }

        [DataMember]
        public String RutaFisica { get; set; }

        [DataMember]
        public Int32 idViaDNI { get; set; }

        [DataMember]
        public String nomViaDNI { get; set; }

        [DataMember]
        public String numeroDNI { get; set; }

        [DataMember]
        public String interiorDNI { get; set; }

        [DataMember]
        public Int32 idZonaDNI { get; set; }

        [DataMember]
        public String nomZonaDNI { get; set; }

        [DataMember]
        public String referenciaDNI { get; set; }

        [DataMember]
        public String DireccionCompletaDNI { get; set; }

        [DataMember]
        public Int32 SanguineoGrupo { get; set; }

        [DataMember]
        public Decimal Estatura { get; set; }

        [DataMember]
        public String TallaCamisa { get; set; }

        [DataMember]
        public Decimal TallaPantalon { get; set; }

        [DataMember]
        public Decimal TallaCalzado { get; set; }

        [DataMember]
        public String NomPais { get; set; }

        [DataMember]
        public String desPersona { get; set; }

        [DataMember]
        public String NomLocal { get; set; }

        [DataMember]
        public Int32 idBancoPago { get; set; }

        [DataMember]
        public Int32 idTipoCuentaPago { get; set; }

        [DataMember]
        public String idMonedaPago { get; set; }

        [DataMember]
        public String NumCuentaPago { get; set; }

        [DataMember]
        public Int32 idOcupacion { get; set; }

        [DataMember]
        public String nomOcupacion { get; set; }

        [DataMember]
        public String nomBancoPago { get; set; }

        [DataMember]
        public Decimal NetoPago { get; set; }

        [DataMember]
        public String tipDocumento { get; set; }

        [DataMember]
        public String Nemo { get; set; }

        [DataMember]
        public Boolean RefrigerioSudsidio { get; set; }

    }   
}