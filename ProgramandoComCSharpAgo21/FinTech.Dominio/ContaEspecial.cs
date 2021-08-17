using System;

namespace FinTech.Dominio
{
    public class ContaEspecial : ContaCorrente
    {
        public ContaEspecial(Agencia agencia, int numero, string digitoVerificador, decimal limite) : base(agencia, numero, digitoVerificador)
        {
            Limite = limite;
        }

        public decimal Limite { get; set; }

        public override void EfetuarOperação(decimal valor, Operacao operacao) //substitui ou overrida o corpo do metodo da classe de Conta, pq muda os parametros
        {
            bool IsSuccessful = true;
            switch (operacao)
            {
                case Operacao.Deposito:
                    Saldo += valor;
                    break;
                case Operacao.Saque:
                    if (Saldo + Limite >= valor) // não permite menor que o Saldo
                    {
                        Saldo -= valor;
                    }
                    else
                    {
                        IsSuccessful = false;
                    }
                    break;
            }
            if (IsSuccessful) Movimentos.Add(new Movimentacao(operacao, valor));
        }
    }
}