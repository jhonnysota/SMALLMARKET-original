using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class OrdenTrabajoServicioE
    {

        public OrdenTrabajoServicioE()
        {
            ListaItemsOrdenTrabajo = new List<OrdenTrabajoServicioItemE>();

            NombreReal = String.Empty;
            NombreImagen = String.Empty;
            Extension = String.Empty;
            ConImagen = false;
            CambioImagen = false;
        }

        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idOT { get; set; }

		[DataMember]
		public String numeroOT { get; set; }

        [DataMember]
        public DateTime FechaEmision { get; set; }

        [DataMember]
		public Int32? idArea { get; set; }

		[DataMember]
		public Int32? idPersona { get; set; }

		[DataMember]
		public String Observacion { get; set; }

        [DataMember]
        public String Cotizacion { get; set; }


        [DataMember]
        public String NombreReal { get; set; }

        [DataMember]
        public String NombreImagen { get; set; }

        [DataMember]
        public String Extension { get; set; }

        [DataMember]
		public String Estado { get; set; }

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
        public List<OrdenTrabajoServicioItemE> ListaItemsOrdenTrabajo { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String desArea { get; set; }

        [DataMember]
        public String Direccion { get; set; }

        [DataMember]
        public String desEstado { get; set; }

        #region Imagen

        [DataMember]
        public Byte[] Imagen { get; set; }

        [DataMember]
        public String RutaDirectorioServer { get; set; }

        [DataMember]
        public String RutaImagenServer { get; set; }

        [DataMember]
        public Boolean ConImagen { get; set; }

        [DataMember]
        public Boolean CambioImagen { get; set; } 

        [DataMember]
        public String RutaBorrarImagenLocal { get; set; }

        #endregion

    }   
}