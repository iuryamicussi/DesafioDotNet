using CIeT.DesafioTecnico.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIeT.DesafioTecnico.Application.Implementacoes
{
    public class MenuSistema : IMenuSistema
    {
        private ICalculadoraFila _calculadoraFila;
        private IValidadorInputUsuario _validadorInputUsuario;

        public MenuSistema(ICalculadoraFila calculadoraFila, IValidadorInputUsuario validadorInputUsuario)
        {
            _calculadoraFila = calculadoraFila;
            _validadorInputUsuario = validadorInputUsuario;
        }

        public void IniciaJogo()
        {
            bool inputInvalido = true;
            string inputQuantidadeJogos = "0";
            string inputNMX = "", inputPilhaA = "", inputPilhaB = "";

            while (inputInvalido)
            {
                Console.WriteLine("Digite quantos jogos quer realizar:");
                inputQuantidadeJogos = Console.ReadLine();
                inputInvalido = !_validadorInputUsuario.ValidarInputUsuarioComoInteiro(inputQuantidadeJogos);
                if (inputInvalido) MensagemInputInvalido();
            }

            int quantidadeJogos = Convert.ToInt32(inputQuantidadeJogos);

            for (int rodada = 0; rodada < quantidadeJogos; rodada++)
            {
                var valoresNMX = new int[3];
                inputInvalido = true;
                while (inputInvalido)
                {
                    Console.WriteLine("Digite a quantidade de números(N), números(M) e o valor máximo(X). [Ex.: 4 5 10]: ");
                    inputNMX = Console.ReadLine();
                    inputInvalido = !_validadorInputUsuario.ValidarInputUsuarioComoVetorInteiro(inputNMX, 3, out valoresNMX);
                    if (inputInvalido) MensagemInputInvalido();
                }

                int tamanhoPilhaA = valoresNMX[0];
                int tamanhoPilhaB = valoresNMX[1];
                int valorMaximo = valoresNMX[2];

                var valoresPilhaA = new int[tamanhoPilhaA];
                inputInvalido = true;
                while (inputInvalido)
                {
                    Console.WriteLine($"Digite os {tamanhoPilhaA} números correspondentes a Pilha A: ");
                    inputPilhaA = Console.ReadLine();
                    inputInvalido = !_validadorInputUsuario.ValidarInputUsuarioComoVetorInteiro(inputPilhaA, tamanhoPilhaA, out valoresPilhaA);
                    if (inputInvalido) MensagemInputInvalido();
                }

                var valoresPilhaB = new int[tamanhoPilhaB];
                inputInvalido = true;
                while (inputInvalido)
                {
                    Console.WriteLine($"Digite os {tamanhoPilhaB} números correspondentes a Pilha B: ");
                    inputPilhaB = Console.ReadLine();
                    inputInvalido = !_validadorInputUsuario.ValidarInputUsuarioComoVetorInteiro(inputPilhaB, tamanhoPilhaB, out valoresPilhaB);
                    if (inputInvalido) MensagemInputInvalido();
                }

                try
                {
                    Console.WriteLine($"Resultado do jogo(Score Máximo): {_calculadoraFila.CalcularMaiorScoreDesempilhando(valorMaximo, valoresPilhaA, valoresPilhaB)}");
                    Console.WriteLine("-----------------");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Falha ao calcular maior Score." + Environment.NewLine + ex.Message);
                    rodada = quantidadeJogos;
                }
            }
        }

        public void MensagemInputInvalido()
        {
            Console.WriteLine("#########");
            Console.WriteLine("Falha ao interpretar input! Tente novamente.");
            Console.WriteLine("#########" + Environment.NewLine);

        }

    }

}
