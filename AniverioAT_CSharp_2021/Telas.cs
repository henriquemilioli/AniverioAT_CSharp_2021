using BibliotecaDeClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AniverioAT_CSharp_2021
{
    class Telas
    {
        public static void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Aniversariantes do dia!");
            Console.WriteLine("*************************************");
            AniversarianteDoDia();
            Console.WriteLine("*************************************");
            Console.WriteLine("Escolha uma das opcões: ");
            Console.WriteLine("1 -> Adicionar Pessoa ");
            Console.WriteLine("2 -> Pesquisar Pessoa ");
            Console.WriteLine("3 -> Editar Pessoa ");
            Console.WriteLine("4 -> Deletar Pessoa ");
            Console.WriteLine("5 -> Mostrar todas as Pessoas ");
            Console.WriteLine("6 -> Sair ");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CadastrarPessoa();
                    break;
                case 2:
                    BuscaPessoa();                    
                    break;
                case 3:
                    EditarPessoa();
                    break;
                case 4:
                    DeletarPessoa();
                    break;
                case 5:
                    MostrarPessoa();
                    break;
                case 6:
                    Console.WriteLine("Ate mais!");
                    break;
                default:
                    Console.WriteLine("Opcão inválida!");
                    break;
            }
        }

        private static void AniversarianteDoDia()
        {
            DateTime hj = DateTime.Today;
            var niverToday = Repositorio.BuscarTodasPessoas(hj);
            if (niverToday.Count() == 0)
            {
                Console.WriteLine("Sem aniversarios hoje!");
            }
            else
            {
                foreach (var pessoa in niverToday)
                {
                    Console.WriteLine(pessoa.Id + " - " + pessoa._nome + " " + pessoa._sobreNome);
                }
            }
        }

        public static void CadastrarPessoa()
        {
            Console.Clear();

            Console.WriteLine("Digite o nome: ");
            String nome = Console.ReadLine();
            Console.WriteLine("Digite o sobrenome: ");
            String sobreNome = Console.ReadLine();

            DateTime DiaAniversario = RecebeETransformaData();

            var pessoas = Repositorio.BuscarTodasPessoas();

            Pessoa p = new Pessoa(nome, sobreNome, DiaAniversario);

            foreach (var pessoa in pessoas)
            {
                Pessoa ultima = pessoas.Last(x => x.Id == pessoa.Id);
                p.Id = ultima.Id + 1;
            }

            Console.WriteLine(p);
            Console.WriteLine("");
            Console.WriteLine("Os dados estao corretos? Sim(s)/Não(n)");
            string opcao = Console.ReadLine();
            if (opcao == "s")
            {
                Console.WriteLine("Adicionando pessoa...");
                Repositorio.Salvar(p);
            }
            else
            {
                CadastrarPessoa();
            }
            VoltarProMenu();
        }

        public static void BuscaPessoa()
        {
            Console.Clear();
            Console.WriteLine("Digite o nome ou sobrenome da pessoa que deseja buscar:");
            string[] nomePessoa = Console.ReadLine().Split(' ');
            string nome = nomePessoa[0];

            var listaDePessoasEncontradas = Repositorio.BuscarTodasPessoas(nome);

            if (listaDePessoasEncontradas.Count() == 0)
            {
                Console.WriteLine("Nenhuma pessoa encontrada!!");
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("Pesssoas Encontradas: ");

                foreach (var pessoa in listaDePessoasEncontradas)
                {
                    Console.WriteLine(pessoa.Id + " - " + pessoa._nome + " " + pessoa._sobreNome);
                }

                Console.WriteLine(" ");
                Console.WriteLine("Digite o numero ID correspondente para ver mais detalhes: ");
                int escolha = int.Parse(Console.ReadLine());

                foreach (var pessoa in listaDePessoasEncontradas)
                {
                    if (pessoa.Id == escolha)
                    {
                        Console.WriteLine(Repositorio.BuscarPessoaPorId(escolha));

                    }
                }
            }
            VoltarProMenu();
        }

        private static void EditarPessoa()
        {
            Console.Clear();
            Console.WriteLine("Digite o nome da pessoa que deseja editar: ");
            string[] nomeESobrenome = Console.ReadLine().Split(' ');
            string nome = nomeESobrenome[0];


            var listaDePessoasEncontradas = Repositorio.BuscarTodasPessoas(nome);

            if (listaDePessoasEncontradas.Count() == 0)
            {
                Console.WriteLine("Nenhuma pessoa encontrada!");
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("Pesssoas encontradas: ");

                foreach (var pessoa in listaDePessoasEncontradas)
                {
                    Console.WriteLine(pessoa.Id + " - " + pessoa._nome + " " + pessoa._sobreNome);
                }

                Console.WriteLine(" ");
                Console.WriteLine("Digite o numero correspondente a pessoa que deseja editar: ");
                int escolha = int.Parse(Console.ReadLine());

                foreach (var pessoa in listaDePessoasEncontradas)
                {
                    if (pessoa.Id == escolha)
                    {
                        Pessoa pessoaEscolhida = Repositorio.BuscarPessoaPorId(escolha);
                        Console.WriteLine("Digite o novo nome: ");
                        String nomeN = Console.ReadLine();
                        Console.WriteLine("Digite o novo Sobrenome: ");
                        String sobrenomeN = Console.ReadLine();
                        DateTime novoAniversario = RecebeETransformaData();

                        Pessoa pessoaN = new Pessoa(pessoaEscolhida.Id, nomeN, sobrenomeN, novoAniversario);

                        Repositorio.Editar(pessoaN);

                        Console.WriteLine("Pessoa alterada!");
                    }
                }
            }
            VoltarProMenu();
        }

        private static void DeletarPessoa()
        {
            Console.Clear();
            Console.WriteLine("Digite o nome da pessoa que deseja excluir:");
            string[] nomeESobrenome = Console.ReadLine().Split(' ');
            string nome = nomeESobrenome[0];

            var listaDePessoasEncontradas = Repositorio.BuscarTodasPessoas(nome);

            if (listaDePessoasEncontradas.Count() == 0)
            {
                Console.WriteLine("Nenhuma pessoa encontrada");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Pesssoas Encontradas: ");
                foreach (var pessoa in listaDePessoasEncontradas)
                {
                    Console.WriteLine(pessoa.Id + " - " + pessoa._nome + " " + pessoa._sobreNome);
                }


                Console.WriteLine("Digite o numero correspondente a pessoa que deseja excluir: ");
                int escolha = int.Parse(Console.ReadLine());

                foreach (var pessoa in listaDePessoasEncontradas)
                {
                    if (pessoa.Id == escolha)
                    {
                        Repositorio.Deletar(escolha);
                        Console.WriteLine("Pessoa excluída!");
                    }
                }
            }
            VoltarProMenu();
        }

        
        public static void MostrarPessoa()
        {
            Console.Clear();
            var p = new Repositorio();

            if (p != null)
            {
                Console.WriteLine("");
                Console.WriteLine("Lista de amigos!");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("");
                foreach (var pessoa in Repositorio.BuscarTodasPessoas())
                {
                    Console.WriteLine(" - " + pessoa._nome + " , " + pessoa._sobreNome + " aniversaria em: " + pessoa._nascimento);
                }
            }
            else
                Console.WriteLine("Ops, parece que nimguem foi cadastrado ainda!");
            Console.WriteLine(" ");
            VoltarProMenu();
        }

        //                 ---METODOS USUAIS---
        public static DateTime RecebeETransformaData()
        {
            Console.WriteLine("Digite a data de nascimento no formato dd/mm/yyyy: ");
            string data = Console.ReadLine();

            DateTime dataC = new DateTime();
            if (data.Contains("/"))
            {
                string[] vet = data.Split('/');
                int ano = int.Parse(vet[2]);
                int mes = int.Parse(vet[1]);
                int dia = int.Parse(vet[0]);
                dataC = new DateTime(ano, mes, dia);
            }
            else
            {
                Console.WriteLine("Por favor, digite no formato dd/mm/yyyy!!!");
                VoltarProMenu();
            }
            return dataC;
        }       

        public static void VoltarProMenu()
        {
            Console.WriteLine("Aperte V para voltar ao menu.");
            string volta = Console.ReadLine();
            if (volta == "v")
            {
                MenuPrincipal();
            }
            else
            {
                Console.WriteLine("Opcao invalida!");
                VoltarProMenu();
            }
        }
        private static readonly IRepositorio Repositorio = new Repositorio();
    }
}

