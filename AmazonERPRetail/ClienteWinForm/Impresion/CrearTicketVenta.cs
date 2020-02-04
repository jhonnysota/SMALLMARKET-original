using System;
using System.Text;

//Agregamos las librerias que utilizaremos.
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.IO;

namespace ClienteWinForm.Impresion
{
    public class CrearTicketVenta
    {

        //Creamos un objeto de la clase StringBuilder, en este objeto agregaremos las lineas del ticket
        public StringBuilder Linea = new StringBuilder();
        //Creamos una variable para almacenar el numero maximo de caracteres que permitiremos en el ticket.
        int maxCaracter = 40, cortar;//Para una impresora ticketera que imprime a 40 columnas. La variable cortar cortara el texto cuando rebase el limite.

        //Creamos el primer metodo, este dibujara lineas con guion.
        public String LineasGuion()
        {
            String lineasGuion = "";

            for (int i = 0; i < maxCaracter; i++)
            {
                lineasGuion += "-";//Agregara un guio hasta llegar la numero maximo de caracteres.
            }

            return Linea.AppendLine(lineasGuion).ToString(); //Devolvemos la lineaGuion
        }

        //Metodo para dibujar una linea con asteriscos
        public String LineasAsteriscos()
        {
            String lineasAsterisco = "";

            for (int i = 0; i < maxCaracter; i++)
            {
                lineasAsterisco += "*";//Agregara un asterisco hasta llegar la numero maximo de caracteres.
            }

            return Linea.AppendLine(lineasAsterisco).ToString(); //Devolvemos la linea con asteriscos
        }

        //Realizamos el mismo procedimiento para dibujar una lineas con el signo igual
        public String LineasIgual()
        {
            String lineasIgual = "";

            for (int i = 0; i < maxCaracter; i++)
            {
                lineasIgual += "=";//Agregara un igual hasta llegar la numero maximo de caracteres.
            }

            return Linea.AppendLine(lineasIgual).ToString(); //Devolvemos la lienas con iguales
        }

        //Creamos el encabezado para los articulos
        public void EncabezadoVenta(String EncabezadoDetalle = "ARTICULO            |CANT|PRECIO|IMPORTE")
        {
            //Escribimos los espacios para mostrar el articulo. En total tienen que ser 40 caracteres
            Linea.AppendLine(EncabezadoDetalle);
        }

        //Creamos un metodo para poner el texto a la izquierda
        public void TextoIzquierda(String texto)
        {
            //Si la longitud del texto es mayor al numero maximo de caracteres permitidos, realizar el siguiente procedimiento.
            if (texto.Length > maxCaracter)
            {
                int caracterActual = 0;//Nos indicara en que caracter se quedo al bajar el texto a la siguiente linea

                for (int longitudTexto = texto.Length; longitudTexto > maxCaracter; longitudTexto -= maxCaracter)
                {
                    //Agregamos los fragmentos que salgan del texto
                    Linea.AppendLine(texto.Substring(caracterActual, maxCaracter));
                    caracterActual += maxCaracter;
                }

                //agregamos el fragmento restante
                Linea.AppendLine(texto.Substring(caracterActual, texto.Length - caracterActual));
            }
            else
            {
                //Si no es mayor solo agregarlo.
                Linea.AppendLine(texto);
            }
        }

        //Creamos un metodo para poner texto a la derecha.
        public void TextoDerecha(String texto)
        {
            //Si la longitud del texto es mayor al numero maximo de caracteres permitidos, realizar el siguiente procedimiento.
            if (texto.Length > maxCaracter)
            {
                int caracterActual = 0;//Nos indicara en que caracter se quedo al bajar el texto a la siguiente linea

                for (int longitudTexto = texto.Length; longitudTexto > maxCaracter; longitudTexto -= maxCaracter)
                {
                    //Agregamos los fragmentos que salgan del texto
                    Linea.AppendLine(texto.Substring(caracterActual, maxCaracter));
                    caracterActual += maxCaracter;
                }

                //Variable para poner espacios restantes
                String espacios = "";

                //Obtenemos la longitud del texto restante.
                for (int i = 0; i < (maxCaracter - texto.Substring(caracterActual, texto.Length - caracterActual).Length); i++)
                {
                    espacios += " ";//Agrega espacios para alinear a la derecha
                }

                //agregamos el fragmento restante, agregamos antes del texto los espacios
                Linea.AppendLine(espacios + texto.Substring(caracterActual, texto.Length - caracterActual));
            }
            else
            {
                String espacios = "";
                //Obtenemos la longitud del texto restante.

                for (int i = 0; i < (maxCaracter - texto.Length); i++)
                {
                    espacios += " ";//Agrega espacios para alinear a la derecha
                }

                //Si no es mayor solo agregarlo.
                Linea.AppendLine(espacios + texto);
            }
        }

        //Metodo para centrar el texto
        public void TextoCentro(String texto)
        {
            if (texto.Length > maxCaracter)
            {
                int caracterActual = 0;//Nos indicara en que caracter se quedo al bajar el texto a la siguiente linea

                for (int longitudTexto = texto.Length; longitudTexto > maxCaracter; longitudTexto -= maxCaracter)
                {
                    //Agregamos los fragmentos que salgan del texto
                    Linea.AppendLine(texto.Substring(caracterActual, maxCaracter));
                    caracterActual += maxCaracter;
                }

                //Variable para poner espacios restantes
                String espacios = "";
                //sacamos la cantidad de espacios libres y el resultado lo dividimos entre dos
                int centrar = (maxCaracter - texto.Substring(caracterActual, texto.Length - caracterActual).Length) / 2;

                //Obtenemos la longitud del texto restante.
                for (int i = 0; i < centrar; i++)
                {
                    espacios += " ";//Agrega espacios para centrar
                }

                //agregamos el fragmento restante, agregamos antes del texto los espacios
                Linea.AppendLine(espacios + texto.Substring(caracterActual, texto.Length - caracterActual));
            }
            else
            {
                String espacios = "";
                //sacamos la cantidad de espacios libres y el resultado lo dividimos entre dos
                int centrar = (maxCaracter - texto.Length) / 2;

                //Obtenemos la longitud del texto restante.
                for (int i = 0; i < centrar; i++)
                {
                    espacios += " ";//Agrega espacios para centrar
                }

                //agregamos el fragmento restante, agregamos antes del texto los espacios
                Linea.AppendLine(espacios + texto);
            }
        }

        //Metodo para poner texto a los extremos
        public void TextoExtremos(String textoIzquierdo, String textoDerecho)
        {
            //variables que utilizaremos
            String textoIzq, textoDer, textoCompleto = "", espacios = "";

            //Si el texto que va a la izquierda es mayor a 18, cortamos el texto.
            if (textoIzquierdo.Length > 18)
            {
                cortar = textoIzquierdo.Length - 18;
                textoIzq = textoIzquierdo.Remove(18, cortar);
            }
            else
            {
                textoIzq = textoIzquierdo;
            }

            textoCompleto = textoIzq;//Agregamos el primer texto.

            if (textoDerecho.Length > 20)//Si es mayor a 20 lo cortamos
            {
                cortar = textoDerecho.Length - 20;
                textoDer = textoDerecho.Remove(20, cortar);
            }
            else
            {
                textoDer = textoDerecho;
            }

            //Obtenemos el numero de espacios restantes para poner textoDerecho al final
            int nroEspacios = maxCaracter - (textoIzq.Length + textoDer.Length);

            for (int i = 0; i < nroEspacios; i++)
            {
                espacios += " ";//agrega los espacios para poner textoDerecho al final
            }

            textoCompleto += espacios + textoDerecho;//Agregamos el segundo texto con los espacios para alinearlo a la derecha.
            Linea.AppendLine(textoCompleto);//agregamos la linea al ticket, al objeto en si.
        }

        //Metodo para agregar los totales de la venta
        public void AgregarTotales(String texto, Decimal total)
        {
            //Variables que usaremos
            String resumen, valor, textoCompleto, espacios = "";

            if (texto.Length > 25)//Si es mayor a 25 lo cortamos
            {
                cortar = texto.Length - 25;
                resumen = texto.Remove(25, cortar);
            }
            else
            {
                resumen = texto;
            }

            textoCompleto = resumen;
            valor = total.ToString("###,##0.00");//Agregamos el total previo formateo.

            //Obtenemos el numero de espacios restantes para alinearlos a la derecha
            int nroEspacios = maxCaracter - (resumen.Length + valor.Length);

            //agregamos los espacios
            for (int i = 0; i < nroEspacios; i++)
            {
                espacios += " ";
            }

            textoCompleto += espacios + valor;
            Linea.AppendLine(textoCompleto);
        }

        //Metodo para agreagar articulos al ticket de venta
        public void AgregaArticulo(String articulo, Decimal cant, Decimal precio, Decimal importe)
        {
            //Valida que cant precio e importe esten dentro del rango.
            if (cant.ToString().Length <= 5 && precio.ToString().Length <= 7 && importe.ToString().Length <= 8)
            {
                String elemento = "", espacios = "";
                bool bandera = false;//Indicara si es la primera linea que se escribe cuando bajemos a la segunda si el nombre del articulo no entra en la primera linea
                int nroEspacios;

                //Si el nombre o descripcion del articulo es mayor a 20, bajar a la siguiente linea
                if (articulo.Length > 20)
                {
                    //Colocar la cantidad a la derecha.
                    nroEspacios = (5 - cant.ToString().Length);
                    espacios = "";

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";//Generamos los espacios necesarios para alinear a la derecha
                    }

                    elemento += espacios + cant.ToString();//agregamos la cantidad con los espacios

                    //Colocar el precio a la derecha.
                    nroEspacios = (7 - precio.ToString().Length);
                    espacios = "";

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";//Genera los espacios
                    }

                    //el operador += indica que agregar mas cadenas a lo que ya existe.
                    elemento += espacios + precio.ToString();//Agregamos el precio a la variable elemento

                    //Colocar el importe a la derecha.
                    nroEspacios = (8 - importe.ToString().Length);
                    espacios = "";

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }

                    elemento += espacios + importe.ToString();//Agregamos el importe alineado a la derecha

                    int caracterActual = 0;//Indicara en que caracter se quedo al bajae a la siguiente linea

                    //Por cada 20 caracteres se agregara una linea siguiente
                    for (int longitudTexto = articulo.Length; longitudTexto > 20; longitudTexto -= 20)
                    {
                        if (bandera == false)//si es false o la primera linea en recorrerer, continuar...
                        {
                            //agregamos los primeros 20 caracteres del nombre del articulos, mas lo que ya tiene la variable elemento
                            Linea.AppendLine(articulo.Substring(caracterActual, 20) + elemento);
                            bandera = true;//cambiamos su valor a verdadero
                        }
                        else
                        {
                            Linea.AppendLine(articulo.Substring(caracterActual, 20));//Solo agrega el nombre del articulo
                        }

                        caracterActual += 20;//incrementa en 20 el valor de la variable caracterActual
                    }

                    //Agrega el resto del fragmento del nombre del articulo
                    Linea.AppendLine(articulo.Substring(caracterActual, articulo.Length - caracterActual));
                }
                else //Si no es mayor solo agregarlo, sin dar saltos de lineas
                {
                    for (int i = 0; i < (20 - articulo.Length); i++)
                    {
                        espacios += " "; //Agrega espacios para completar los 20 caracteres
                    }

                    elemento = articulo + espacios;

                    //Colocar la cantidad a la derecha.
                    nroEspacios = (5 - cant.ToString().Length);// +(20 - elemento.Length);
                    espacios = "";

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }

                    elemento += espacios + cant.ToString();

                    //Colocar el precio a la derecha.
                    nroEspacios = (7 - precio.ToString().Length);
                    espacios = "";

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }

                    elemento += espacios + precio.ToString();

                    //Colocar el importe a la derecha.
                    nroEspacios = (8 - importe.ToString().Length);
                    espacios = "";

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }

                    elemento += espacios + importe.ToString();
                    Linea.AppendLine(elemento);//Agregamos todo el elemento: nombre del articulo, cant, precio, importe.
                }
            }
            else
            {
                Linea.AppendLine("Los valores ingresados para esta fila");
                Linea.AppendLine("superan las columnas soportadas por éste.");
                throw new Exception("Los valores ingresados para algunas filas del ticket\nsuperan las columnas soportadas por éste.");
            }
        }

        public void AgregaArticuloS2(Decimal cant, string Umed, String articulo, Decimal precio)
        {
            //Valida que cant precio e importe esten dentro del rango.
            if (Umed.Length <= 5 && cant.ToString().Length <= 6 && precio.ToString().Length <= 9)
            {
                string elemento;
                bool bandera = false;//Indicara si es la primera linea que se escribe cuando bajemos a la segunda si el nombre del articulo no entra en la primera linea
                int nroEspacios;
                string espacios;
                string Cantidad;
                string Umedida;
                string PrecioTot;

                //Si el nombre o descripcion del articulo es mayor a 20, bajar a la siguiente linea
                if (articulo.Length > 20)
                {
                    #region Cantidad

                    nroEspacios = (6 - cant.ToString().Length);
                    espacios = string.Empty;

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";//Generamos los espacios necesarios para alinear a la derecha
                    }

                    Cantidad = espacios + cant.ToString();//agregamos la cantidad con los espacios 

                    #endregion

                    #region Unidad de Medida

                    nroEspacios = (4 - Umed.ToString().Length);
                    espacios = string.Empty;

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " "; //Agrega espacios para completar los 20 caracteres
                    }

                    Umedida = " " + Umed + espacios;

                    #endregion

                    #region Precio Total

                    nroEspacios = (9 - precio.ToString().Length);
                    espacios = string.Empty;

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }

                    PrecioTot = espacios + precio.ToString();

                    #endregion

                    #region Articulo

                    int caracterActual = 0;//Indicara en que caracter se quedo al bajar a la siguiente linea

                    //Por cada 20 caracteres se agregara una linea siguiente
                    for (int longitudTexto = articulo.Length; longitudTexto > 20; longitudTexto -= 20)
                    {
                        if (bandera == false)//si es false o la primera linea en recorrerer, continuar...
                        {
                            //agregamos los primeros 19 caracteres del nombre del articulos, mas lo que ya tiene la variable elemento
                            Linea.AppendLine(Cantidad + Umedida + articulo.Substring(caracterActual, 20) + PrecioTot);
                            bandera = true;//cambiamos su valor a verdadero
                        }
                        else
                        {
                            Linea.AppendLine(articulo.Substring(caracterActual, 20));//Solo agrega el nombre del articulo
                        }

                        caracterActual += 20;//incrementa en 20 el valor de la variable caracterActual
                    }

                    nroEspacios = 11;
                    espacios = string.Empty;

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }

                    //Agrega el resto del fragmento del nombre del articulo
                    Linea.AppendLine(espacios + articulo.Substring(caracterActual, articulo.Length - caracterActual)); 

                    #endregion
                }
                else //Si no es mayor solo agregarlo, sin dar saltos de lineas
                {
                    #region Cantidad

                    nroEspacios = (6 - cant.ToString().Length);// +(20 - elemento.Length);
                    espacios = string.Empty;

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }

                    elemento = espacios + cant.ToString();

                    #endregion

                    #region Unidad de Medida

                    nroEspacios = (4 - Umed.ToString().Length);
                    espacios = string.Empty;

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " "; //Agrega espacios para completar los 20 caracteres
                    }

                    elemento += " " + Umed + espacios;

                    #endregion

                    #region Articulo

                    nroEspacios = (19 - articulo.ToString().Length);
                    espacios = string.Empty;

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " "; //Agrega espacios para completar los 20 caracteres
                    }

                    elemento += articulo + espacios;

                    #endregion

                    #region Precio Total

                    nroEspacios = (10 - precio.ToString().Length);
                    espacios = string.Empty;

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }

                    elemento += espacios + precio.ToString(); 

                    #endregion

                    Linea.AppendLine(elemento);//Agregamos todo el elemento: nombre del articulo, cant, precio, importe.
                }
            }
            else
            {
                Linea.AppendLine("Los valores ingresados para esta fila");
                Linea.AppendLine("superan las columnas soportadas por éste.");
                throw new Exception("Los valores ingresados para algunas filas del ticket\nsuperan las columnas soportadas por éste.");
            }
        }

        //Metodo para agreagar articulos al ticket de venta
        public void AgregaArticuloS3(Decimal cant, String articulo, Decimal Total)
        {
            //35
            //Valida que cant precio e importe esten dentro del rango.
            if (cant.ToString().Length <= 6 && Total.ToString().Length <= 10)
            {
                string elemento = "";
                bool bandera = false;//Indicara si es la primera linea que se escribe cuando bajemos a la segunda si el nombre del articulo no entra en la primera linea
                string espacios;
                int nroEspacios;
                //Si el nombre o descripcion del articulo es mayor a 20, bajar a la siguiente linea
                if (articulo.Length > 21)
                {
                    //Colocar la cantidad a la derecha.
                    nroEspacios = (6 - cant.ToString().Length);
                    espacios = "";

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";//Generamos los espacios necesarios para alinear a la derecha
                    }

                    elemento += cant.ToString() + espacios;//agregamos la cantidad con los espacios

                    int caracterActual = 0;//Indicara en que caracter se quedo al bajae a la siguiente linea

                    //Por cada 20 caracteres se agregara una linea siguiente
                    for (int longitudTexto = articulo.Length; longitudTexto > 20; longitudTexto -= 20)
                    {
                        if (bandera == false)//si es false o la primera linea en recorrerer, continuar...
                        {
                            nroEspacios = (13 - Total.ToString().Length);
                            espacios = "";

                            for (int i = 0; i < nroEspacios; i++)
                            {
                                espacios += " ";//Generamos los espacios necesarios para alinear a la derecha
                            }

                            //agregamos los primeros 20 caracteres del nombre del articulos, mas lo que ya tiene la variable elemento
                            Linea.AppendLine(elemento + articulo.Substring(caracterActual, 20) + espacios + Total);
                            bandera = true;//cambiamos su valor a verdadero
                        }
                        else
                        {
                            nroEspacios = (6);
                            espacios = "";

                            for (int i = 0; i < nroEspacios; i++)
                            {
                                espacios += " ";//Generamos los espacios necesarios para alinear a la derecha
                            }

                            Linea.AppendLine(espacios + articulo.Substring(caracterActual, 20));//Solo agrega el nombre del articulo
                        }

                        caracterActual += 20;//incrementa en 20 el valor de la variable caracterActual
                    }

                    nroEspacios = (6);
                    espacios = "";

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";//Generamos los espacios necesarios para alinear a la derecha
                    }

                    //Agrega el resto del fragmento del nombre del articulo
                    Linea.AppendLine(espacios + articulo.Substring(caracterActual, articulo.Length - caracterActual));
                }
                else //Si no es mayor solo agregarlo, sin dar saltos de lineas
                {
                    //Cantidad
                    nroEspacios = (6 - cant.ToString().Length);
                    espacios = "";

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }

                    elemento = cant.ToString() + espacios;

                    //Descripción del Articulo
                    espacios = "";

                    for (int i = 0; i < (21 - articulo.Length); i++)
                    {
                        espacios += " "; //Agrega espacios para completar los 20 caracteres
                    }

                    elemento += articulo + espacios;

                    //Colocar el Total a la derecha.
                    nroEspacios = (13 - Total.ToString().Length);
                    espacios = "";

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }

                    elemento += espacios + Total.ToString();
                    Linea.AppendLine(elemento);//Agregamos todo el elemento: cant, nombre del articulo, Total.
                }
            }
            else
            {
                Linea.AppendLine("Los valores ingresados para esta fila");
                Linea.AppendLine("superan las columnas soportadas por éste.");
                throw new Exception("Los valores ingresados para algunas filas del ticket\nsuperan las columnas soportadas por éste.");
            }
        }

        public void ImprimeTresColumnas(int maxText1, string sText1, bool bConEspacios1 = false, bool bTextRight1 = false, int maxText2 = 0, string sText2 = "", bool bConEspacios2 = false, bool bTextRight2 = false, int maxText3 = 0, string sText3 = "", bool bConEspacios3 = false, bool bTextRight3 = false)
        {
            string cadena = string.Empty;
            string espacios = string.Empty;
            int nroEspacios;

            if (maxText1 + maxText2 + maxText3 > maxCaracter)
            {
                throw new Exception("El limite de caracteres por linea a sobrepasado los 40 caracteres, revise.");
            }

            #region Texto 1

            if (!string.IsNullOrWhiteSpace(sText1) && sText1 != null)
            {
                if (!bConEspacios1)
                {
                    sText1 = sText1.Trim();
                }

                if (sText1.Length >= maxText1)
                {
                    cadena += sText1.Substring(0, maxText1);
                }
                else
                {
                    nroEspacios = maxText1 - sText1.Length;

                    for (int i = 1; i <= nroEspacios; i++)
                    {
                        espacios += " ";//Genera los espacios
                    }

                    if (bTextRight1)
                    {
                        cadena += espacios + sText1;
                    }
                    else
                    {
                        cadena += sText1 + espacios;
                    }
                }
            }
            else
            {
                for (int i = 1; i <= maxText1; i++)
                {
                    espacios += " ";//Genera los espacios
                }

                cadena += espacios;
            }

            #endregion

            #region Texto 2

            espacios = string.Empty;
            nroEspacios = 0;

            if (!string.IsNullOrWhiteSpace(sText2) && sText2 != null)
            {
                if (!bConEspacios2)
                {
                    sText2 = sText2.Trim();
                }

                if (sText2.Length >= maxText2)
                {
                    cadena += sText2.Substring(0, maxText2);
                }
                else
                {
                    nroEspacios = maxText2 - sText2.Length;

                    for (int i = 1; i <= nroEspacios; i++)
                    {
                        espacios += " ";//Genera los espacios
                    }

                    if (bTextRight2)
                    {
                        cadena += espacios + sText2;
                    }
                    else
                    {
                        cadena += sText2 + espacios;
                    }
                }
            }
            else
            {
                for (int i = 1; i <= maxText2; i++)
                {
                    espacios += " ";//Genera los espacios
                }

                cadena += espacios;
            }

            #endregion

            #region Texto 3

            espacios = string.Empty;
            nroEspacios = 0;

            if (!string.IsNullOrWhiteSpace(sText3) && sText3 != null)
            {
                if (!bConEspacios3)
                {
                    sText3 = sText3.Trim();
                }

                if (sText3.Length >= maxText3)
                {
                    cadena += sText3.Substring(0, maxText3);
                }
                else
                {
                    nroEspacios = maxText3 - sText3.Length;

                    for (int i = 1; i <= nroEspacios; i++)
                    {
                        espacios += " ";//Genera los espacios
                    }

                    if (bTextRight3)
                    {
                        cadena += espacios + sText3;
                    }
                    else
                    {
                        cadena += sText3 + espacios;
                    }
                }
            }
            else
            {
                for (int i = 1; i <= maxText3; i++)
                {
                    espacios += " ";//Genera los espacios
                }

                cadena += espacios;
            }

            #endregion

            Linea.AppendLine(cadena);
        }

        //Metodos para enviar secuencias de escape a la impresora
        //Para cortar el ticket
        public void CortaTicket()
        {
            Linea.AppendLine("\x1B" + "m"); //Caracteres de corte. Estos comando varian segun el tipo de impresora
            //Linea.AppendLine("??? Chr(27)+ Chr(109) &&Corte Parcial");
            Linea.AppendLine("\x1B" + "d" + "\x02"); //Avanza 9 renglones, Tambien varian
        }

        //Para abrir el cajon
        public void AbreCajon()
        {
            //Estos tambien varian, tienen que ever el manual de la impresora para poner los correctos.
            Linea.AppendLine("\x1B" + "p" + "\x00" + "\x0F" + "\x96"); //Caracteres de apertura cajon 0
            //linea.AppendLine("\x1B" + "p" + "\x01" + "\x0F" + "\x96"); //Caracteres de apertura cajon 1
        }

        //Para mandara a imprimir el texto a la impresora que le indiquemos.
        public void ImprimirTicket(String impresora, Int16 Metodo, String RutaArchivoTexto = "")
        {
            if (Metodo == 1)
            {
                //Este metodo recibe el nombre de la impresora a la cual se mandara a imprimir y el texto que se imprimira.
                RawPrinterHelper.EnviarCadenaImprimir(impresora, Linea.ToString()); //Imprime texto.
            }
            else
            {
                //Este metodo recibe el nombre de la impresora y la ruta del archivo que se va a imprimir.
                using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto, false, Encoding.UTF8))//Encoding.GetEncoding(850)))
                {
                    oSw.WriteLine(Linea.ToString());
                }

                RawPrinterHelper.EnviarArchivoImprimir(impresora, RutaArchivoTexto);
            }

            Linea.Clear();//Al cabar de imprimir limpia la linea de todo el texto agregado.
        }

        public string VistaPrevia(String RutaArchivoTexto)
        {
            //Este metodo recibe el nombre de la impresora y la ruta del archivo que se va a imprimir.
            using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto, false, Encoding.UTF8))//Encoding.GetEncoding(850)))
            {
                oSw.WriteLine(Linea.ToString());
            }

            string Cadena = Linea.ToString();
            //Linea.Clear();//Limpiar la linea de todo el texto agregado.
            return Cadena;
        }

    }

    //Clase para mandara a imprimir texto plano a la impresora
    public class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public String pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public String pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public String pDataType;
        }

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] String szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // Cuando se da a la función un nombre de impresora y un arreglo no administrado
        // de bytes, la función envía esos bytes a la cola de impresión.
        // Devuelve true en caso de éxito, false en caso de error.
        public static bool SendBytesToPrinter(String szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Para saber si hubo algún error

            di.pDocName = "Ticket de Venta";//Este es el nombre con el que guarda el archivo en caso de no imprimir a la impresora fisica.
            di.pDataType = "RAW";//de tipo texto plano

            // Abrir la impresora.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Iniciar el documento.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Iniciar una página.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Escribir los bytes
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }

                    EndDocPrinter(hPrinter);
                }

                ClosePrinter(hPrinter);
            }

            // Si no imprimió, GetLastError proporcionara el error.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }

            return bSuccess;
        }

        public static bool EnviarArchivoImprimir(string szPrinterName, string szFileName)
        {
            bool bSuccess = false;

            // Abrir archivo
            using (FileStream oFs = new FileStream(szFileName, FileMode.Open))
            {
                // Cree un BinaryReader en el archivo.
                using (BinaryReader oBr = new BinaryReader(oFs))
                {
                    //Declarar una matriz suficientemente grande para contener el contenido del archivo...
                    Byte[] bytes = new Byte[oFs.Length];

                    // Un puntero no administrado
                    IntPtr pUnmanagedBytes = new IntPtr(0);
                    int nLength = Convert.ToInt32(oFs.Length);

                    // Leer el contenido del archivo de la matriz.
                    bytes = oBr.ReadBytes(nLength);
                    // Asignar memoria no administrado para los bytes
                    pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
                    // Copiar la matriz de bytes admnistrados en la matriz no administrada
                    Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
                    // Enviar a la impresora los bytes no administrados
                    bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
                    // Liberar la memoria...
                    Marshal.FreeCoTaskMem(pUnmanagedBytes);
                }
            }
            
            return bSuccess;
        }

        public static bool EnviarCadenaImprimir(String szPrinterName, String szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // ¿Cuántos caracteres hay en la cadena?
            dwCount = szString.Length;
            // Suponga que la impresora está esperando texto ANSI, convertir la cadena a texto ANSI.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Envar la cadena ANSI convertida a la impresora.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }

    }
}
