using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Cap2.GeradorSenha
{
    public class Senha
    {
        public int TamanhoSenha { get; set; }
        public string ValorSenha { get; set; }

        public Senha(int tamanho)
        {
            TamanhoSenha = tamanho;
        }
        public string GerarSenha()
        {
            string novaSenha = String.Empty;

            var rnd = new Random();

            for (int i = 0; i < TamanhoSenha; i++)
            {
                var numRandom = rnd.Next(0, 9);
                novaSenha += numRandom;
            }
            return novaSenha;
        }
    }

}
