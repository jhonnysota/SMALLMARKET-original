using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Entidades.Contabilidad
{

    [DataContract]
    [Serializable]
    public  class PlanCuentasE21
    {
               
        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public String codCuentaSunat { get; set; }

        [DataMember]
        public Int32? tipAjuste { get; set; }

        [DataMember]
        public String Descripcion { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public Int32? numNivel { get; set; }

        [DataMember]
        public String indNaturalezaCta { get; set; }

        [DataMember]
        public String indCuentaGastos { get; set; }

        [DataMember]
        public Int32? indBalance { get; set; }

        [DataMember]
        public String indSolicitaAnexo { get; set; }

        [DataMember]
        public String indSolicitaCentroCosto { get; set; }

        [DataMember]
        public String indAjuste_X_Cambio { get; set; }

        [DataMember]
        public String indCambio_X_Compra { get; set; }

        [DataMember]
        public String codCuentaSup { get; set; }

        [DataMember]
        public String codCuentaDestino { get; set; }

        [DataMember]
        public String codCuentaTransferencia { get; set; }

        [DataMember]
        public String codCuentaGanancia { get; set; }

        [DataMember]
        public String codCuentaPerdida { get; set; }

        [DataMember]
        public String indSolicitaDcto { get; set; }

        [DataMember]
        public String indCtaCte { get; set; }

        [DataMember]
        public String tipTituloNodo { get; set; }

        [DataMember]
        public String indUltNodo { get; set; }

        [DataMember]
        public String tipPartidaPresu { get; set; }

        [DataMember]
        public String codPartidaPresu { get; set; }

        [DataMember]
        public String indCuentaCierre { get; set; }

        [DataMember]
        public String codCuentaCieDeb { get; set; }

        [DataMember]
        public Int32? codColumnaCoven { get; set; }

        [DataMember]
        public String indNotaIngreso { get; set; }

        [DataMember]
        public String indAnexoReferencial { get; set; }

        [DataMember]
        public String indCajaChica { get; set; }

        [DataMember]
        public Int32? tipoCajaChica { get; set; }

        [DataMember]
        public String indCtaIngreso { get; set; }

        [DataMember]
        public String UsuarioAsignado { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public bool indTasaRenta { get; set; }

        [DataMember]
        public String idTasaRenta { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime? FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime? FechaModificacion { get; set; }

        // Extensiones...
        [DataMember]
        public String Digitos { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String indAutomatico { get; set; }

        [DataMember]
        public Boolean Afecto { get; set; }

        [DataMember]
        public String desPartidaPresu { get; set; }

        [DataMember]
        public String desColumnaCoVen { get; set; }

        [DataMember]
        public String desBalance { get; set; }

        [DataMember]
        public String desTipAjuste { get; set; }

        [DataMember]
        public String Periodo { get; set; }

        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public String codPlan { get; set; }

        [DataMember]
        public String desPlan { get; set; }

        [DataMember]
        public decimal TasaRenta { get; set; }

        [DataMember]
        public String desCuentaTemp { get; set; }

        [DataMember]
        public String Nemo { get; set; }

        [DataMember]
        public String desCuentaSup { get; set; }

        [DataMember]
        public String desCuentaDestino { get; set; }

        [DataMember]
        public String desCuentaTransfe { get; set; }

        [DataMember]
        public String desCuentaGanancia { get; set; }

        [DataMember]
        public String desCuentaPerdida { get; set; }

        [DataMember]
        public String desCuentaCieDeb { get; set; }

        [DataMember]
        public String nomCuentaSunat { get; set; }

        [DataMember]
        public Decimal SaldoInicialDebe { get; set; }

        [DataMember]
        public Decimal SaldoInicialHaber { get; set; }

        [DataMember]
        public Decimal MovimientoDebe { get; set; }

        [DataMember]
        public Decimal MovimientoHaber { get; set; }

        [DataMember]
        public Decimal SumasMayorDebe { get; set; }

        [DataMember]
        public Decimal SumasMayorHaber { get; set; }

        [DataMember]
        public Decimal SaldoHaber { get; set; }

        [DataMember]
        public Decimal SaldoDebe { get; set; }

        [DataMember]
        public Decimal TransCancDebe { get; set; }

        [DataMember]
        public Decimal TransCancHaber { get; set; }

        [DataMember]
        public Decimal BalanceActivo { get; set; }

        [DataMember]
        public Decimal BalancePasivo { get; set; }

        [DataMember]
        public Decimal RPNaturalezaPerdida { get; set; }

        [DataMember]
        public Decimal RPNaturalezaGanancia { get; set; }

        [DataMember]
        public Decimal Adiciones { get; set; }

        [DataMember]
        public Decimal Deducciones { get; set; }

        [DataMember]
        public String Estado { get; set; }

        [DataMember]
        public String Abrev { get; set; }

        [DataMember]
        public List<CuentaTasaRentaE> oListaTasaRenta { get; set; }
    }
}
