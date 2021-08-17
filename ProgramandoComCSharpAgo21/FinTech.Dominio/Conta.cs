using System;
using System.Collections.Generic;

namespace FinTech.Dominio
{
    public abstract class Conta
    {
        protected Conta(Agencia agencia, int numero, string digitoVerificador)
        {
            Agencia = agencia;
            Numero = numero;
            DigitoVerificador = digitoVerificador;
        }
        public List<Movimentacao> Movimentos { get; set; } = new List<Movimentacao>();
        public decimal Saldo { get; protected set; }
        public Agencia Agencia { get; set; }
        public Cliente Cliente { get; set; }
        public string DigitoVerificador { get; set; }
        public int Numero { get; set; }
        public virtual void EfetuarOperação(decimal valor, Operacao operacao)
        {
            bool IsSuccessful = true;
            switch (operacao)
            {
                case Operacao.Deposito:
                    Saldo += valor;
                    break;
                case Operacao.Saque:
                    if (Saldo >= valor) // não permite menor que o Saldo
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

            //var saques = Conta.Movimentos.Where(mbox => mbox.Operacao == Operacao.)
        }
    }
}
