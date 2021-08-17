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
        public DateTime Data { get; set; } = DateTime.Now;
        public Operacao Operacao { get; set; }
        public decimal Valor { get; set; }
    }
}
