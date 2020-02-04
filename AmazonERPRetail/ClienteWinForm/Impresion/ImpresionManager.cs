using System;

namespace ClienteWinForm.Impresion
{
    public class ImpresionManager
    {
        //public static IImpresion RecuperarUtilImpresion(String RucEmpresa)
        //{
        //    switch (RucEmpresa)
        //    {
        //        case "20452630886": //Fundo San Miguel
        //            return new Mercantil.Impresion();
        //        case "20251352292": //Aldeasa
        //            return new Aldeasa.ImpresionAldeasa();
        //        //case "20502647009":
        //            //return new AgroGenesis.ImpresionAgro();
        //        case "20523020561":
        //            return new AgroGenesis.ImpresionHuerto();
        //        case "20517933318":
        //            return new AgroGenesis.ImpresionViveros();
        //        case "20552695217":
        //            return new AgroGenesis.ImpresionJeri();
        //        case "20552186681":
        //            return new AgroGenesis.ImpresionAyV();
        //        case "20552690410":
        //            return new AgroGenesis.ImpresionPower();
        //        case "20523201868":
        //            return new Intermetal.ImpresionInter();
        //        case "20601328179":
        //            return new Intermetal.ImpresionFfs();
        //        case "20536039717":
        //            return new Nevados.ImpresionNevados(); //Nevados
        //        case "20476115711":
        //            return new SCIngenieros.ImpresionSC(); //SCIngenieria
        //        case "20535703214":
        //            return new Fitocorp.ImpresionFito(); //FITOCORP
        //        case "20509606766":
        //            return new Sergensur.ImpresionSergen(); //Sergensur
        //        case "20513445700":
        //            return new Enzo.ImpresionEnzo(); //ENZO FERRE
        //        case "20602659594":
        //            return new AgroGenesis.ImpresionAgro();//Herrajes store
        //        default:
        //            return null;
        //    }
        //}
        public static IImpresion RecuperarUtilImpresion(String RucEmpresa = "")
        {
            return new AgroGenesis.ImpresionAgro();//Herrajes store
            }
    }
}
