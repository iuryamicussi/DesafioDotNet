using System;
using System.Collections.Generic;
using System.Text;

namespace CIeT.DesafioTecnico.Application.Interfaces
{
    public interface IMenuSistema
    {
        void IniciaJogo();
        void MensagemInputInvalido(string mensagem = "");
    }
}
