using CIeT.DesafioTecnico.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIeT.DesafioTecnico.Application.Implementacoes
{
    public class CalculadoraFila : ICalculadoraFila
    {
        public int CalcularMaiorScoreDesempilhando(int valorMaximo, int[] vetorA, int[] vetorB)
        {
            int cursorB = 0;
            int totalizador = 0;
            while (cursorB < vetorB.Length && totalizador + vetorB[cursorB] <= valorMaximo)
            {
                totalizador += vetorB[cursorB];
                cursorB++;
            }

            int score = cursorB;
            for (int cursorA = 1; cursorA <= vetorA.Length; cursorA++)
            {
                totalizador += vetorA[cursorA - 1];

                while (totalizador > valorMaximo && cursorB > 0)
                {
                    cursorB--;
                    totalizador -= vetorB[cursorB];
                }

                if (totalizador > valorMaximo) break;

                score = Math.Max(score, cursorA + cursorB);
            }
            return score;
        }
    }
}
