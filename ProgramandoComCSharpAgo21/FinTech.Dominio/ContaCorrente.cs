using System;

namespace FinTech.Dominio
{
    public class ContaCorrente : Conta
    {
        public ContaCorrente(Agencia agencia, int numero, string digitoVerificador) :
            base(agencia, numero, digitoVerificador) //passa os dados par ao construtor da classe base 
        {
            //Numero = numero;
        }

        public decimal ValorPacoteServico { get; set; }
    }
}
