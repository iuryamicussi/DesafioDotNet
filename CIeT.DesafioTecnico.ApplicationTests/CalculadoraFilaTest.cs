using NUnit.Framework;
using FluentAssertions;
using CIeT.DesafioTecnico.Application.Interfaces;
using CIeT.DesafioTecnico.Application.Implementacoes;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CIeT.DesafioTecnico.ApplicationTests
{
    public class CalculadoraFilaTest
    {
        private ICalculadoraFila _calculadoraFila;

        [SetUp]
        public void Setup()
        {
            _calculadoraFila = new CalculadoraFila();
        }

        private static IEnumerable<object> CarregarTestSample_01()
        {
            var arquivoTeste = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "SamplesTest_01.txt"));
            var arquivoRespostasTeste = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "SamplesTestResult_01.txt"));
            int indexResult = 0;
            for (int index = 1; index < arquivoTeste.Length; index+=3,indexResult++)
            {
                yield return new DadosTesteCalculadoraScore 
                {
                    ValorMaximo = Convert.ToInt32(arquivoTeste[index].Split(" ")[2]),
                    PilhaA = arquivoTeste[index+1].Split(" ").Select(s => Convert.ToInt32(s)).ToArray(),
                    PilhaB = arquivoTeste[index+2].Split(" ").Select(s => Convert.ToInt32(s)).ToArray(),
                    ResultadoEsperado = Convert.ToInt32(arquivoRespostasTeste[indexResult].Trim())
                };
            }
        }

        [Test]
        [TestCaseSource("CarregarTestSample_01")]
        public void CalcularMaiorScoreDesempilhando_Varios(DadosTesteCalculadoraScore dados)
        {
            //Act
            var resultado = _calculadoraFila.CalcularMaiorScoreDesempilhando(dados.ValorMaximo, dados.PilhaA, dados.PilhaB);

            //Assert
            resultado.Should().Be(dados.ResultadoEsperado);
        }

          
    }

    public class DadosTesteCalculadoraScore
    {
        public int ValorMaximo { get; set; }
        public int[] PilhaA { get; set; }
        public int[] PilhaB { get; set; }
        public int ResultadoEsperado { get; set; }
    }
}
