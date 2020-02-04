using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class LetrasE
    {

        public LetrasE()
        {
            Opcion = 0;
        }

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public String tipCanje { get; set; }

        [DataMember]
        public String codCanje { get; set; }

        [DataMember]
        public String Numero { get; set; }

        [DataMember]
        public String Corre { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public DateTime FechaVenc { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public Decimal MontoOrigen { get; set; }

        [DataMember]
        public Decimal MontoRefe { get; set; }

        [DataMember]
        public Int32 idPersona { get; set; }

        [DataMember]
        public String GiradoA { get; set; }

        [DataMember]
        public String Direccion { get; set; }

        [DataMember]
        public String Plaza { get; set; }

        [DataMember]
        public String Doi { get; set; }

        [DataMember]
        public String Telefono { get; set; }

        [DataMember]
        public String Aval { get; set; }

        [DataMember]
        public String DoiAval { get; set; }

        [DataMember]
        public String TelefAval { get; set; }

        [DataMember]
        public String DireccionAval { get; set; }

        [DataMember]
        public String Representante { get; set; }

        [DataMember]
        public Decimal? tipCambio { get; set; }

        [DataMember]
        public String Observacion { get; set; }

        [DataMember]
        public Int32? idPlanillaBanco { get; set; }

        [DataMember]
        public Int32? idCtaCte { get; set; }

        [DataMember]
        public Int32? idCtaCteItem { get; set; }

        [DataMember]
        public Int32? idVendedor { get; set; }

        [DataMember]
        public Int32? idTipCondicion { get; set; }

        [DataMember]
        public Int32? idCondicion { get; set; }

        [DataMember]
        public String Estado { get; set; } //Estado P=PorAceptar A=Aceptado B=Borrado-Anulado

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
        public Int32 Opcion { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String AnioPeriodo { get; set; }

        [DataMember]
        public String MesPeriodo { get; set; }

        [DataMember]
        public String idComprobante { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public String numVoucher { get; set; }

        [DataMember]
        public String Letra { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public Decimal MontoDolares { get; set; }

        [DataMember]
        public Decimal MontoSoles { get; set; }

        [DataMember]
        public String desEstado { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public DateTime fecProceso { get; set; } //De la cabecera ven_LetrasCanje

        [DataMember]
        public String desPlazaGirador { get; set; }

        [DataMember]
        public String desPlazaGiradoA { get; set; }

        [DataMember]
        public List<LetrasCanjeE> ListaFacturas { get; set; }

        [DataMember]
        public String codPlanillaBanco { get; set; }

        [DataMember]
        public String EstadoPlanillaBanco { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String CuentaContable { get; set; }

    }   
}