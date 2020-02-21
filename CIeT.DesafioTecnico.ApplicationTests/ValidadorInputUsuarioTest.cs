using NUnit.Framework;
using FluentAssertions;
using CIeT.DesafioTecnico.Application.Interfaces;
using CIeT.DesafioTecnico.Application.Implementacoes;

namespace CIeT.DesafioTecnico.ApplicationTests
{
    public class ValidadorInputUsuarioTest
    {
        private IValidadorInputUsuario _validadorInputUsuario;

        [SetUp]
        public void Setup()
        {
            _validadorInputUsuario = new ValidadorInputUsuario();
        }

        [Test]
        public void ValidarInputUsuarioComoInteiro_PassandoStringComNumeroInteiro_DeveRetornarVerdadeiro()
        {
            //Arrange
            var stringTeste = "489498";
            
            //Act
            var resultado =_validadorInputUsuario.ValidarInputUsuarioComoInteiro(stringTeste);

            //Assert
            resultado.Should().BeTrue();
        }

        [Test]
        public void ValidarInputUsuarioComoInteiro_PassandoStringComAlfanumerico_DeveRetornarFalso()
        {
            //Arrange
            var stringTeste = "48SAsa9498";

            //Act
            var resultado = _validadorInputUsuario.ValidarInputUsuarioComoInteiro(stringTeste);

            //Assert
            resultado.Should().BeFalse();
        }

        [Test]
        public void ValidarInputUsuarioComoInteiro_PassandoStringVazia_DeveRetornarFalso()
        {
            //Arrange
            var stringTeste = string.Empty;

            //Act
            var resultado = _validadorInputUsuario.ValidarInputUsuarioComoInteiro(stringTeste);

            //Assert
            resultado.Should().BeFalse();
        }

        [Test]
        public void ValidarInputUsuarioComoVetorInteiro_PassandoStringComVetorDeInteirosENumeroPosicoesCorreta_DeveRetornarVerdadeiro()
        {
            //Arrange
            var stringTeste = "1 2 3";
            var numeroPosicoes = 3;

            //Act
            var resultado = _validadorInputUsuario.ValidarInputUsuarioComoVetorInteiro(stringTeste, numeroPosicoes, out _);

            //Assert
            resultado.Should().BeTrue();
        }

        [Test]
        public void ValidarInputUsuarioComoVetorInteiro_PassandoStringComVetorDeInteirosENumeroPosicoesIncorreta_DeveRetornarFalso()
        {
            //Arrange
            var stringTeste = "1 2 3";
            var numeroPosicoes = 4;

            //Act
            var resultado = _validadorInputUsuario.ValidarInputUsuarioComoVetorInteiro(stringTeste, numeroPosicoes, out _);

            //Assert
            resultado.Should().BeFalse();
        }

        [Test]
        public void ValidarInputUsuarioComoVetorInteiro_PassandoStringComVetorDeAlfanumericosENumeroPosicoesCorreta_DeveRetornarFalso()
        {
            //Arrange
            var stringTeste = "a 2 3 ç";
            var numeroPosicoes = 4;

            //Act
            var resultado = _validadorInputUsuario.ValidarInputUsuarioComoVetorInteiro(stringTeste, numeroPosicoes, out _);

            //Assert
            resultado.Should().BeFalse();
        }

        [Test]
        public void ValidarInputUsuarioComoVetorInteiro_PassandoStringComVetorDeAlfanumericosENumeroPosicoesIncorreta_DeveRetornarFalso()
        {
            //Arrange
            var stringTeste = "a 2 3 ç";
            var numeroPosicoes = 99;

            //Act
            var resultado = _validadorInputUsuario.ValidarInputUsuarioComoVetorInteiro(stringTeste, numeroPosicoes, out _);

            //Assert
            resultado.Should().BeFalse();
        }

        [Test]
        public void ValidarInputUsuarioComoVetorInteiro_PassandoStringVazia_DeveRetornarFalso()
        {
            //Arrange
            var stringTeste = "";
            var numeroPosicoes = 99;

            //Act
            var resultado = _validadorInputUsuario.ValidarInputUsuarioComoVetorInteiro(stringTeste, numeroPosicoes, out _);

            //Assert
            resultado.Should().BeFalse();
        }

        [Test]
        public void ValidarInputUsuarioComoVetorInteiro_PassandoNumeroPosicoesNegativo_DeveRetornarFalso()
        {
            //Arrange
            var stringTeste = "";
            var numeroPosicoes = -99;

            //Act
            var resultado = _validadorInputUsuario.ValidarInputUsuarioComoVetorInteiro(stringTeste, numeroPosicoes, out _);

            //Assert
            resultado.Should().BeFalse();
        }

    }
}