using System;
using System.Collections.Generic;
using System.Text;

namespace CIeT.DesafioTecnico.Application.Interfaces
{
    public interface ICalculadoraFila
    {
        int CalcularMaiorScoreDesempilhando(int valorMaximoPermitido, int[] pilhaA, int[] pilhaB);
    }
}
