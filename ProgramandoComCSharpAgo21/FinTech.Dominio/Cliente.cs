using System;
using System.Collections.Generic;

namespace FinTech.Dominio
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public string EnderecoResidencial { get; set; }
        public List<Conta> Contas { get; set; } = new List<Conta>();// todas as classes que herdam de conta podem ser incluídas aqui 
    }
}