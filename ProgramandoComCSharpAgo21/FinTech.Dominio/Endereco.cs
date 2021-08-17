namespace FinTech.Dominio
{
    public class Endereco
    {
        public Endereco(string logradouro, string cep, string cidade, string numero)
        {
            Logradouro = logradouro;
            CEP = cep;
            Cidade = cidade;
            Numero = numero;
        }

        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Numero { get; set; }



    }
}