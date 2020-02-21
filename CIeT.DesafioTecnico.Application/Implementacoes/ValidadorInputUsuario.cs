using CIeT.DesafioTecnico.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CIeT.DesafioTecnico.Application.Implementacoes
{
    public class ValidadorInputUsuario : IValidadorInputUsuario
    {
        public bool ValidarInputUsuarioComoInteiro(string inputUsuario) => int.TryParse(inputUsuario, out _);

        public bool ValidarInputUsuarioComoVetorInteiro(string inputUsuario, int numeroPosicoes, out int[] vetorInteiro, string separador = " ")
        {
            var inputSegregado = inputUsuario.Split(separador);
            var resultadoValidacao = inputSegregado.All(ValidarInputUsuarioComoInteiro) && inputSegregado.Length == numeroPosicoes;

            if (resultadoValidacao)
                vetorInteiro = inputSegregado.Select(s => Convert.ToInt32(s)).ToArray();
            else
                vetorInteiro = new int[0];
            return resultadoValidacao;
        }
    }
}
