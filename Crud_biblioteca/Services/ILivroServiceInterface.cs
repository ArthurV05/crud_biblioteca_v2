using Crud_biblioteca.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Crud_biblioteca.Service
{
    internal interface ILivroInterface
    {
        public Livro Inserir(Livro livro);

        public List<Livro> ListarLivros();

        public Livro BuscarPorId(int id);

        public Livro AtualizarLivro(Livro livro);

        public int AtualizarEstoque(int id, int estoque);

        public int AtualizarValor(int id, int valor);
    }
}
