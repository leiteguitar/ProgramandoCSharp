using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Repositorio.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinTech.Dominio;

namespace Fintech.Repositorio.FileSystem.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {
        [TestMethod()]
        public void InsereTest()
        {
            ContaCorrente account = new ContaCorrente(new Agencia() { Numero = 1 }, 2, "X");

            var movimento = new Movimentacao(Operacao.Saque, 10, account);
            movimento.Data = new DateTime(2021, 9, 18);

            MovimentoRepositorio testeInsere = new MovimentoRepositorio("Dados\\Movimento.txt");
            testeInsere.Insere(movimento);
        }

        [TestMethod()]
        public void SelecionaTest()
        {
            MovimentoRepositorio testeInsere = new MovimentoRepositorio("Dados\\Movimento.txt");
            var movimentos = testeInsere.Seleciona(1,2);

            foreach (var item in movimentos)
            {
                Console.WriteLine($"{item.Guid} - {item.Data} - {item.Operacao} - {item.Valor:c}");
            }
        }
    }
}