using CIeT.DesafioTecnico.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIeT.DesafioTecnico.Application.Implementacoes
{
    public class RegrasJogo : IRegrasJogo
    {
        public int NumeroMaximoPartidas() => 50;

        public (int, int) TamanhoMinMaxPilha() => (1,Convert.ToInt32(Math.Pow(10,5)));

        public (int, int) ValorMinMaxDadosPilha() => (0, Convert.ToInt32(Math.Pow(10, 6)));

        public (int, int) ValorMinMaxLimite() => (1, Convert.ToInt32(Math.Pow(10, 9)));
    }
}
