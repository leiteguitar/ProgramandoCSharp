using System;

namespace FinTech.Dominio
{
    public class ContaCorrente
    {
        public decimal Saldo { get; set; }
        public Agencia Agencia { get; set; }
        public Cliente Cliente { get; set; }
        public int DigitoVerificador { get; set; }
        public int Numero { get; set; }
        public void EfetuarOperação(decimal valor, Operacao operacao)
        {
            switch (operacao)
            {
                case Operacao.Deposito:
                    Saldo += valor;
                    break;
                case Operacao.Saque:
                    Saldo -= valor;
                    break;
            }
        }
    }
}
