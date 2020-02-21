using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace CIeT.DesafioTecnico.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite a quantidade de jogos:");
            //int g = Convert.ToInt32(Console.ReadLine());
            int g = Convert.ToInt32("1");

            for (int gItr = 0; gItr < g; gItr++)
            {
                Console.WriteLine("Digite os valores de N, M e X(separado por espaço):");
                //string[] nmx = Console.ReadLine().Split(' ');
                string[] nmx = { "5", "4", "10" };

                int n = Convert.ToInt32(nmx[0]);

                int m = Convert.ToInt32(nmx[1]);

                int x = Convert.ToInt32(nmx[2]);

                Console.WriteLine("Digite os inteiros do array A:");
                //int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
                int[] a = { 4,2,4,6,1 };

                Console.WriteLine("Digite os inteiros do array B:");
                //int[] b = Array.ConvertAll(Console.ReadLine().Split(' '), bTemp => Convert.ToInt32(bTemp));
                int[] b = { 2,1,8,5 };
                int result = twoStacks(x, a, b);

                Console.WriteLine($"Resultado(COMPROVADO): {twoStacks2(x, a, b)}");
                Console.WriteLine($"Resultado(IURY): {twoStacks(x, a, b)}");
            }
        }

        static int twoStacks2(int valorMaximo, int[] vetorA, int[] vetorB)
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

                if (totalizador > valorMaximo)
                {
                    break;
                }

                score = Math.Max(score, cursorA + cursorB);
            }
            return score;

        }

        static int twoStacks(int valorMaximo, int[] vetorA, int[] vetorB)
        {
            int somatoriaA = 0, somatoriaB = 0, somatoriaAB = 0, somatorioTemp = 0;
            int cursorA = 0, cursorB = 0, cursorTemp = 0;
            int cursorADecremento = 0, cursorBDecremento = 0;
            int score = 0;

            for (int index = 0; index < Math.Max(vetorA.Length,vetorB.Length); index++)
            {
                //Tratando Vetor A
                if(index < vetorA.Length)
                {
                    somatoriaA += vetorA[index];
                    if(somatoriaA <= valorMaximo)
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
                    score = cursorA + cursorB;
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

                    score = cursorA + cursorB - cursorADecremento - cursorBDecremento;
                }

            }

            return score;
        }
    }
}
