using System;
using System.Collections.Generic;
using System.IO;
using FinTech.Dominio;
using FinTech.Dominio.Interfaces;

namespace Fintech.Repositorio.FileSystem
{
    public class MovimentoRepositorio : IMovimentoRepositorio // implementa Interface, e força, ou obriga, ter as instruções
    {
        private const string DirectoryBase = "Dados";
        public string Caminho { get; } // removeu o set, então permite apenas get em outros arquivos. O set é apenas no construtor
        public MovimentoRepositorio(string caminho)
        {
            Caminho = caminho;
        }

        public void Atualiza(Movimentacao movimento)
        {
            throw new NotImplementedException();
        }

        public void Insere(Movimentacao movimento)
        {
            string registro = $"{movimento.Guid};{movimento.Conta.Agencia.Numero};{movimento.Conta.Numero};" +
                $"{movimento.Data};{(int)movimento.Operacao};{movimento.Valor}";
            if (!Directory.Exists(DirectoryBase))
            {
                Directory.CreateDirectory(DirectoryBase);
            }
            File.AppendAllText($"{Caminho}", registro + Environment.NewLine);
        }

        public List<Movimentacao> Seleciona(int numeroAgencia, int numeroConta)
        {
            List<Movimentacao> movimentosList = new List<Movimentacao>();

            foreach (string line in File.ReadAllLines(Caminho))
            {
                if (line.Trim() == string.Empty) continue; // trim remove whitespaces no começo e fim da String
                string[] propriedades = line.Split(';');

                Guid guidMovimentacao = new Guid(propriedades[0]);
                int numeroDaAgencia = Convert.ToInt32(propriedades[1]);
                int numeroDaConta = Convert.ToInt32(propriedades[2]);
                DateTime data = Convert.ToDateTime(propriedades[3]);
                Operacao operacao = (Operacao)Convert.ToInt32(propriedades[4]);
                decimal valor = Convert.ToDecimal(propriedades[5]);

                if (numeroAgencia == numeroDaAgencia && numeroConta == numeroDaConta)
                {
                    //ContaCorrente conta = new ContaCorrente();
                    //Sobrecarga de método construtor na Movimentacao, pois a instancia abaixo nao precisa de Conta conta
                    Movimentacao movimento = new Movimentacao(operacao, valor);
                    movimento.Data = data;
                    movimento.Guid = guidMovimentacao;

                    movimentosList.Add(movimento);
                }
            }

            return movimentosList;
        }

        public Movimentacao Seleciona(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
