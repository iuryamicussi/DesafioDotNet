using CIeT.DesafioTecnico.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CIeT.DesafioTecnico.Application.Implementacoes
{
    public class CalculadoraFilaV2 : ICalculadoraFila
    {
        [Obsolete("Primeiro teste para calcular. Marcado como obsoleto pois está incompleto.", true)]
        public int CalcularMaiorScoreDesempilhando(int valorMaximo, int[] vetorA, int[] vetorB)
        {
            int somatoriaA = 0, somatoriaB = 0, somatoriaAB = 0, somatorioTemp = 0;
            int cursorA = 0, cursorB = 0, cursorTemp = 0;
            int cursorADecremento = 0, cursorBDecremento = 0;
            var score = new HashSet<int>();
            score.Add(0);

            for (int index = 0; index < Math.Max(vetorA.Length, vetorB.Length); index++)
            {
                //Tratando Vetor A
                if (index < vetorA.Length)
                {
                    somatoriaA += vetorA[index];
                    if (somatoriaA <= valorMaximo)
                    {
                        cursorA++;
                    }
                }

                //Tratando Vetor B
                if (index < vetorB.Length)
                {
                    somatoriaB += vetorB[index];
                    if (somatoriaB <= valorMaximo)
                    {
                        cursorB++;
                    }
                }

                somatoriaAB = somatoriaA + somatoriaB;

                if (somatoriaAB <= valorMaximo)
                {
                    score.Add(cursorA + cursorB);
                }
                else if (somatoriaA <= valorMaximo && somatoriaB > valorMaximo)
                {
                    score.Add(cursorA);
                }
                else if (somatoriaB <= valorMaximo && somatoriaA > valorMaximo)
                {
                    score.Add(cursorB);
                }
                else
                {
                    //Fazendo regração no Vetor A
                    cursorTemp = cursorA - 1;
                    somatorioTemp = somatoriaAB;
                    cursorADecremento = 0;
                    while (cursorTemp >= 0 && somatorioTemp > valorMaximo)
                    {
                        somatorioTemp -= vetorA[cursorTemp];
                        cursorTemp--;
                        cursorADecremento++;
                    };

                    //Fazendo regração no Vetor B                    
                    cursorTemp = cursorB - 1;
                    somatorioTemp = somatoriaAB;
                    cursorBDecremento = 0;
                    while (cursorTemp >= 0 && somatorioTemp > valorMaximo)
                    {
                        somatorioTemp -= vetorB[cursorTemp];
                        cursorTemp--;
                        cursorBDecremento++;
                    };

                    cursorADecremento = cursorADecremento <= cursorBDecremento ? cursorADecremento : 0;
                    cursorBDecremento = cursorADecremento == 0 ? cursorBDecremento : 0;

                    score.Add(cursorA + cursorB - cursorADecremento - cursorBDecremento);
                }

            }

            return score.Max();
        }
    }
}
