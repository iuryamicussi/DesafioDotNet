using System;
using System.Collections.Generic;
using System.Text;

namespace CIeT.DesafioTecnico.Application.Interfaces
{
    public interface IValidadorInputUsuario
    {
        bool ValidarInputUsuarioComoInteiro(string inputUsuario);
        bool ValidarInputUsuarioComoVetorInteiro(string inputUsuario, int numeroPosicoes, out int[] vetorInteiro, string separador = " ");
    }
}
