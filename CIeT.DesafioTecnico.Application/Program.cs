using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autofac;
using Autofac.Core;
using CIeT.DesafioTecnico.Application.Implementacoes;
using CIeT.DesafioTecnico.Application.Interfaces;
using MoreLinq;

namespace CIeT.DesafioTecnico.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = GetIocContainer();
            using(var scope = container.BeginLifetimeScope())
            {
                scope.Resolve<IMenuSistema>().IniciaJogo();
            }
        }
        static IContainer GetIocContainer()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterType<ValidadorInputUsuario>().As<IValidadorInputUsuario>();
            builder.RegisterType<CalculadoraFila>().As<ICalculadoraFila>();

            builder.RegisterType<MenuSistema>().As<IMenuSistema>()
                .WithParameter(
                    new ResolvedParameter(
                       (pi, ctx) => pi.ParameterType == typeof(ICalculadoraFila),
                       (pi, ctx) => ctx.Resolve<ICalculadoraFila>()))
                .WithParameter(
                    new ResolvedParameter(
                       (pi, ctx) => pi.ParameterType == typeof(IValidadorInputUsuario),
                       (pi, ctx) => ctx.Resolve<IValidadorInputUsuario>()));
            return builder.Build();
        }
    }
}
