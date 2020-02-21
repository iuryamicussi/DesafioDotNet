using CIeT.DesafioTecnico.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CIeT.DesafioTecnico.Application.Implementacoes
{
    public class MenuSistema : IMenuSistema
    {
        private ICalculadoraFila _calculadoraFila;
        private IValidadorInputUsuario _validadorInputUsuario;
        private IRegrasJogo _regras;

        public MenuSistema(ICalculadoraFila calculadoraFila, IValidadorInputUsuario validadorInputUsuario, IRegrasJogo regras)
        {
            _calculadoraFila = calculadoraFila;
            _validadorInputUsuario = validadorInputUsuario;
            _regras = regras;
        }

        public void IniciaJogo()
        {
            bool inputInvalido = true;
            string inputQuantidadeJogos = "0";
            string inputNMX = "", inputPilhaA = "", inputPilhaB = "";

            int quantidadeJogos = 0;
            int tamanhoPilhaA = 0;
            int tamanhoPilhaB = 0;
            int valorMaximo = 0;

            while (inputInvalido)
            {
                Console.WriteLine("Digite quantos jogos quer realizar:");
                inputQuantidadeJogos = Console.ReadLine();
                inputInvalido = !_validadorInputUsuario.ValidarInputUsuarioComoInteiro(inputQuantidadeJogos);
                if (inputInvalido)
                {
                    MensagemInputInvalido();
                }
                else
                {
                    quantidadeJogos = Convert.ToInt32(inputQuantidadeJogos);
                    if (quantidadeJogos > _regras.NumeroMaximoPartidas())
                    {
                        inputInvalido = true;
                        MensagemInputInvalido($"Número máximo[{_regras.NumeroMaximoPartidas()}] de partidas excedido.");
                    }
                }
            }


            for (int rodada = 0; rodada < quantidadeJogos; rodada++)
            {
                var valoresNMX = new int[3];
                inputInvalido = true;
                while (inputInvalido)
                {
                    Console.WriteLine("Digite a quantidade de números(N), números(M) e o valor máximo(X). [Ex.: 4 5 10]: ");
                    inputNMX = Console.ReadLine();
                    inputInvalido = !_validadorInputUsuario.ValidarInputUsuarioComoVetorInteiro(inputNMX, 3, out valoresNMX);
                    if (inputInvalido)
                    {
                        MensagemInputInvalido();
                    }
                    else
                    {
                        tamanhoPilhaA = valoresNMX[0];
                        tamanhoPilhaB = valoresNMX[1];
                        valorMaximo = valoresNMX[2];

                        var (minLimite, maxLimite) = _regras.ValorMinMaxLimite();
                        if (valorMaximo < minLimite || valorMaximo >maxLimite)
                        {
                            inputInvalido = true;
                            MensagemInputInvalido($"Valor máximo está fora do padrão. Min={minLimite}, Max={maxLimite}");
                        }

                        var (minTamanhoPilha, maxTamanhoPilha) = _regras.TamanhoMinMaxPilha();
                        if(tamanhoPilhaA < minTamanhoPilha || tamanhoPilhaA > maxTamanhoPilha || tamanhoPilhaB < minTamanhoPilha || tamanhoPilhaB > maxTamanhoPilha)
                        {
                            inputInvalido = true;
                            MensagemInputInvalido($"Tamanho dos Números estão fora do padrão. Min={minTamanhoPilha}, Max={maxTamanhoPilha}");
                        }
                    }
                }

                var valoresPilhaA = new int[tamanhoPilhaA];
                inputInvalido = true;
                while (inputInvalido)
                {
                    Console.WriteLine($"Digite os {tamanhoPilhaA} números correspondentes a Pilha A: ");
                    inputPilhaA = Console.ReadLine();
                    inputInvalido = !_validadorInputUsuario.ValidarInputUsuarioComoVetorInteiro(inputPilhaA, tamanhoPilhaA, out valoresPilhaA);
                    if (inputInvalido)
                    {
                        MensagemInputInvalido();
                    }
                    else
                    {
                        if(valoresPilhaA.Any(vpa => vpa < _regras.ValorMinMaxDadosPilha().Item1 || vpa > _regras.ValorMinMaxDadosPilha().Item2))
                        {
                            inputInvalido = true;
                            MensagemInputInvalido($"Números da pilha A estão fora do padrão. Min={_regras.ValorMinMaxDadosPilha().Item1}, Max={_regras.ValorMinMaxDadosPilha().Item2}");
                        }
                    }
                }

                var valoresPilhaB = new int[tamanhoPilhaB];
                inputInvalido = true;
                while (inputInvalido)
                {
                    Console.WriteLine($"Digite os {tamanhoPilhaB} números correspondentes a Pilha B: ");
                    inputPilhaB = Console.ReadLine();
                    inputInvalido = !_validadorInputUsuario.ValidarInputUsuarioComoVetorInteiro(inputPilhaB, tamanhoPilhaB, out valoresPilhaB);
                    if (inputInvalido)
                    {
                        MensagemInputInvalido();
                    }
                    else
                    {
                        if (valoresPilhaB.Any(vpa => vpa < _regras.ValorMinMaxDadosPilha().Item1 || vpa > _regras.ValorMinMaxDadosPilha().Item2))
                        {
                            inputInvalido = true;
                            MensagemInputInvalido($"Números da pilha B estão fora do padrão. Min={_regras.ValorMinMaxDadosPilha().Item1}, Max={_regras.ValorMinMaxDadosPilha().Item2}");
                        }
                    }
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

        public void MensagemInputInvalido(string mensagem = "")
        {
            Console.WriteLine("#########" + Environment.NewLine);
            Console.WriteLine("Falha ao interpretar input! Tente novamente.");
            Console.WriteLine(mensagem);
            Console.WriteLine("#########" + Environment.NewLine);

        }

    }

}
