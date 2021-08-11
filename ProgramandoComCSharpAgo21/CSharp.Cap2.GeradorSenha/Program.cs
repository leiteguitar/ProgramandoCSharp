using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Cap2.GeradorSenha
{
    class Program
    {
        static void Main(string[] args)
        {
            int qtdeDigitos = 0;
            bool senhaValida = false;

            while (!senhaValida)
            {
                Console.WriteLine("Informe a qtde de dígitos da senha entre 4 e 10: ");

                qtdeDigitos = Convert.ToInt32(Console.ReadLine());

                senhaValida = VerificaDigito(qtdeDigitos, senhaValida);
            }
            if (senhaValida)
            {
                Senha password = new Senha(qtdeDigitos);
                string novaSenha = password.GerarSenha();

                Console.WriteLine($"Sua senha é {novaSenha}");
                Console.ReadKey();
            }
            
        }

        private static bool VerificaDigito(int qtdeDigitos, bool senhaValida)
        {
            if (qtdeDigitos < 4 || qtdeDigitos > 10 || qtdeDigitos % 2 != 0)
            {
                Console.WriteLine("Valor de dígitos inválido. Digite um valor válido");
            }
            else
            {
                senhaValida = true;
            }

            return senhaValida;
        }
    }
}
