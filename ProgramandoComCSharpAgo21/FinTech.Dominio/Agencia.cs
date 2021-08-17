namespace FinTech.Dominio
{
    public class Agencia
    {
        public int Numero { get; set; }
        public string DigitoVerificador { get; set; }
        public Banco Banco { get; set; }
        public Cliente Cliente { get; set; }
    }
}