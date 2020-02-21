using System;
using System.Collections.Generic;
using System.Text;

namespace CIeT.DesafioTecnico.Application.Interfaces
{
    public interface IRegrasJogo
    {
        int NumeroMaximoPartidas();

        (int,int) TamanhoMinMaxPilha();

        (int,int) ValorMinMaxDadosPilha();

        (int, int) ValorMinMaxLimite();
    }
}
