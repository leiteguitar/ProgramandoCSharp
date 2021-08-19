using System;
using System.Collections.Generic;

namespace FinTech.Dominio.Interfaces
{
    //Especificacao da Classe
    public interface IMovimentoRepositorio
    {
        void Insere(Movimentacao movimento);
        void Atualiza(Movimentacao movimento);
        List<Movimentacao> Seleciona(int numeroAgencia, int numeroConta);
        Movimentacao Seleciona(Guid id);
        //void Exclui(Guid id)
        //{
        //    throw new InvalidOperationException();
        //}
    }
}
