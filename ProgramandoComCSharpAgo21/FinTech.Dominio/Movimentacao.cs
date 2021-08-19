using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTech.Dominio
{
    public class Movimentacao
    {
        public Movimentacao(Operacao operacao, decimal valor)
        {
            Operacao = operacao;
            Valor = valor;
        }

        //Sobrecarga de método Construtor
        public Movimentacao(Operacao operacao, decimal valor, Conta conta)
        {
            Operacao = operacao;
            Valor = valor;
            Conta = conta;
        }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public DateTime Data { get; set; } = DateTime.Now;
        public Operacao Operacao { get; set; }
        public decimal Valor { get; set; }
        public Conta Conta { get; set; }
    }
}
