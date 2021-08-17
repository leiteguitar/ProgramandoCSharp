using System;

namespace FinTech.Dominio
{
    public class Poupanca : Conta // Herda de Conta
    {
        public Poupanca(Agencia agencia, int numero, string digitoVerificador) : base(agencia, numero, digitoVerificador)
        {
        }

        public decimal TaxaRendimento { get; set; }
    }
}
