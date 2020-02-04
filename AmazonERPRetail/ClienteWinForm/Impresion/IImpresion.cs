using System;

using Entidades.Ventas;

namespace ClienteWinForm.Impresion
{
    public interface IImpresion
    {

        void ImprimirGuiaRemision(EmisionDocumentoE Documento, String RutaImpresion, Int32 TipoGuia);
        void ImprimirFacturas(EmisionDocumentoE Documento, String RutaImpresion);
        void ImprimirBoletas(EmisionDocumentoE Documento, String RutaImpresion);
        void ImprimirNotaDeCredito(EmisionDocumentoE Documento, String RutaImpresion);
        void ImprimirNotaDeDebito(EmisionDocumentoE Documento, String RutaImpresion);
        void ImprimirLetras(LetrasE oLetra, String RutaImpresion);

    }
}
