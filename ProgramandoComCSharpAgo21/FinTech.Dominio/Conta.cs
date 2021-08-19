using System;
using System.Collections.Generic;
using System.Linq;

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
        public decimal TotalDepositos 
        { 
            get 
            {
                return Movimentos.Where(mbox => mbox.Operacao == Operacao.Deposito).Sum(mbox => mbox.Valor);
            } 
        }
        public Movimentacao EfetuarOperação(decimal valor, Operacao operacao, decimal limite = 0) // parametro opcional
        {
            bool IsSuccessful = true;
            Movimentacao movimento = null;

            switch (operacao)
            {
                case Operacao.Deposito:
                    Saldo += valor;
                    break;
                case Operacao.Saque:
                    if (Saldo + limite >= valor) // não permite menor que o Saldo e tema  regra do conta especial
                    {
                        Saldo -= valor;
                    }
                    else
                    {
                        IsSuccessful = false;
                    }
                    break;
            }
            if (IsSuccessful)
            {
                movimento = new Movimentacao(operacao, valor, this);
                Movimentos.Add(movimento);
            }

            return movimento;

            //var saques = Conta.Movimentos.Where(mbox => mbox.Operacao == Operacao.)
        }
    }
}
