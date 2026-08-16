using System;
using System.Collections.Generic;
using System.Text;

namespace Crud_biblioteca.Model
{
    internal class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "Não informado";
        public int Quantidade { get; set; }
        public double Valor { get; set; }

        public Livro(int id, string nome, int quantidade, double valor)
        {
            Id = id;
            Nome = nome;
            Quantidade = quantidade;
            Valor = valor;
        }
        public Livro() 
        { 
        
        }

        public override string ToString() 
        { 
            return $"Id: {Id} - Nome: {Nome} - Quantidade: {Quantidade} - Valor: {Valor}";
        }

    }

}
