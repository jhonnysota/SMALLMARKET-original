using System;
using System.IO;
using System.Windows.Forms;

namespace Infraestructura.Winform
{
    public static class CuadrosDialogo
    {
        public static String BuscarArchivo(String Titulo = "Buscar", String Extensiones = "Todos los archivos (*.*)|*.*")
        {
            String Res = String.Empty;

            using (OpenFileDialog oFd = new OpenFileDialog())
            {
                try
                {
                    //Ejemplo para el filtro "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                    oFd.Title = Titulo;
                    oFd.Filter = Extensiones;
                    oFd.CheckFileExists = true;
                    oFd.CheckPathExists = true;
                    
                    if (oFd.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(oFd.FileName))
                        {
                            Res = oFd.FileName;
                        }
                        else
                        {
                            MessageBox.Show(string.Format("El fichero {0} no se encuenta", oFd.FileName));
                        }
                    }
                }
                catch (ArgumentException argEx)
                {
                    throw new ArgumentException(argEx.Message);
                }
                catch (IOException ioEx)
                {
                    throw new IOException(ioEx.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return Res;
        }

        public static String SeleccionarCarpeta()
        {
            try
            {
                String Res = String.Empty;

                using (FolderBrowserDialog oFb = new FolderBrowserDialog())
                {
                    oFb.ShowNewFolderButton = true;

                    if (oFb.ShowDialog() == DialogResult.OK)
                    {
                        Res = oFb.SelectedPath;
                        Environment.SpecialFolder root = oFb.RootFolder;
                    }
                }

                return Res;
            }
            catch (ArgumentException argEx)
            {
                throw new ArgumentException(argEx.Message);
            }
            catch (IOException ioEx)
            {
                throw new IOException(ioEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static String GuardarDocumento(String Titulo, String NombreArchivo, String Filtros = "Todos los archivos (*.*)|*.*", Int32 FiltroIndex = 1)
        {
            try
            {
                String Res = String.Empty;

                using (SaveFileDialog oSfd = new SaveFileDialog())
                {
                    oSfd.Filter = Filtros;//"Archivos Excel (*.xlsx)|*.xlsx";
                    oSfd.FilterIndex = FiltroIndex;
                    oSfd.Title = Titulo;
                    oSfd.FileName = NombreArchivo;

                    if (oSfd.ShowDialog() == DialogResult.OK)
                    {
                        Res = oSfd.FileName;
                    }
                }

                return Res;
            }
            catch (ArgumentException argEx)
            {
                throw new ArgumentException(argEx.Message);
            }
            catch (IOException ioEx)
            {
                throw new IOException(ioEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
