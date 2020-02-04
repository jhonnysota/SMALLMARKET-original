using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

using System.Drawing;

namespace Infraestructura.Winform
{
    public static class Valores
    {
        public static Color ColorInabilitado { get { return Color.FromArgb(126, 212, 255); } }

        public static Color ColorHabilitado { get { return Color.FromArgb(255, 255, 255, 255); } }

        public static Color ColorDescuadrado { get { return Color.FromArgb(255, 150, 150); } }

        public static Color ColorAnulado { get { return Color.FromArgb(250, 134, 134); } } //Rojo

        public static Color ColorEmitido { get { return Color.FromArgb(211, 211, 211); } } //Gris

        public static Color ColorCerrado { get { return Color.FromArgb(255, 224, 125); } } //Anaranjado amarillento

        public static Color ColorSunat { get { return Color.FromArgb(221, 235, 247); } } //Celeste

        public static Color ColorFacturado { get { return Color.FromArgb(198, 224, 180); } } //Verde Claro

        public static Color ColorColumnas { get { return Color.FromArgb(142, 169, 219); } } //Azul Claro 40%

    }
}
