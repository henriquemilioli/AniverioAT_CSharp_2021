using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaDeClasses
{
    public interface IRepositorio
    {
        void CadastrarPessoa(Pessoa pessoa);

        void Editar(Pessoa p);

        IEnumerable<Pessoa> BuscarTodasPessoas();

        void Deletar(int id);        

        IEnumerable<Pessoa> BuscarTodasPessoas(string nome);

        IEnumerable<Pessoa> BuscarTodasPessoas(DateTime data);

        void ApagaRecebeECria(List<Pessoa> listaPessoasAtt);

        void Salvar(Pessoa pessoa);

        bool PessoaExistente(Pessoa pessoa);

        Pessoa BuscarPessoaPorId(int id);

        string RecebeArquivo();       

        void MostrarPessoas();
        
    }
}

