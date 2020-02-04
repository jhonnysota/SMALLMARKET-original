using System;
using System.Collections.Generic;

using Entidades.Ventas;

namespace ClienteWinForm.Impresion
{
    public class HelperImpresion
    {

        public static Int32 CantidadLineas(List<EmisionDocumentoDetE> oListaDocumentos, NumControlDetE ControlDocumento)
        {
            Int32 contador = 0;
            String nomTemp = String.Empty;
            Int32 totCaracteres = ControlDocumento.cantCaracteres;
            String[] SplitDetalle = null;

            foreach (EmisionDocumentoDetE item in oListaDocumentos)
            {
                if (item.nomArticulo.Length > totCaracteres)
                {
                    SplitDetalle = item.nomArticulo.Split(' ');

                    for (int i = 0; i < SplitDetalle.Length; i++)
                    {
                        if (nomTemp.Trim().Length < totCaracteres)
                        {
                            nomTemp += SplitDetalle[i].ToString() + " ";
                        }
                        else
                        {
                            nomTemp = String.Empty;
                            contador++;
                            nomTemp += SplitDetalle[i].ToString() + " ";
                        }
                    }
                }
                else
                {
                    contador++;
                }
            }

            return contador;
        }

    }
}
