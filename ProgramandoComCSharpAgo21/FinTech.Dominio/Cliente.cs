using System;

namespace FinTech.Dominio
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public Endereco EnderecoResidencial { get; set; }
    }
}