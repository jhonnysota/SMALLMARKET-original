using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClienteWinForm
{
   public interface IMantenimiento
    {
        void Nuevo();
        void Editar();
        void Grabar();
        void Cerrar();
        void Exportar();
        void AgregarDetalle();
        void QuitarDetalle();
        void Imprimir();
        void Buscar();

        void Anular();
        void Cancelar();
    }
}
