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

        public Movimentacao EfetuarOperação(decimal valor, Operacao operacao) //substitui ou overrida o corpo do metodo da classe de Conta, pq muda os parametros
        {
            return base.EfetuarOperação(valor, operacao, Limite);//base vai pra classe pai, this é a propria classe 
        }
    }
}