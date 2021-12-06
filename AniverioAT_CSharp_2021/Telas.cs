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
            Console.WriteLine("Aniversariantes diarios!");
            Console.WriteLine("-------------------------------------------");
            AniversarianteDoDia();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Escolha uma das opcoes abaixo: ");
            Console.WriteLine("1 - Pesquisar Pessoa ");
            Console.WriteLine("2 - Adicionar Pessoas ");
            Console.WriteLine("3 - Editar Pessoa ");
            Console.WriteLine("4 - Deletar ");            
            Console.WriteLine("5 - Sair ");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    BuscaPessoa();
                    break;
                case 2:
                    CadastrarPessoa();
                    break;
                case 3:
                    EditarPessoa();
                    break;
                case 4:
                    DeletarPessoa();
                    break;                
                case 5:
                    Console.WriteLine("Tchau Amigao!");
                    break;
                default:
                    Console.WriteLine("Opcao errada amigao!");
                    break;
            }
        }
        

        private static void DeletarPessoa()
        {
            Console.Clear();
            Console.WriteLine("Entre com o nome da pessoa que deseja deletar:");
            string[] nomeESobrenome = Console.ReadLine().Split(' ');
            string nome = nomeESobrenome[0];

            var listaDePessoasEncontradas = Repositorio.BuscarTodasPessoas(nome);

            if (listaDePessoasEncontradas.Count() == 0)
            {
                Console.WriteLine("Nenhum usuario Encontrado");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Pesssoas Encontradas: ");
                foreach (var pessoa in listaDePessoasEncontradas)
                {
                    Console.WriteLine(pessoa.Id + " - " + pessoa.nome + " " + pessoa.sobreNome);
                }


                Console.WriteLine("Digite o numero correspondente a pessoa que deseja deletar: ");
                int escolha = int.Parse(Console.ReadLine());

                foreach (var pessoa in listaDePessoasEncontradas)
                {
                    if (pessoa.Id == escolha)
                    {
                        Repositorio.Deletar(escolha);
                        Console.WriteLine("Pessoa deletada!");
                    }
                }
            }
            VoltarProMenu();
        }

        private static void EditarPessoa()
        {
            Console.Clear();
            Console.WriteLine("Entre com o nome da pessoa que deseja editar:");
            string[] nomeESobrenome = Console.ReadLine().Split(' ');
            string nome = nomeESobrenome[0];


            var listaDePessoasEncontradas = Repositorio.BuscarTodasPessoas(nome);

            if (listaDePessoasEncontradas.Count() == 0)
            {
                Console.WriteLine("Nenhum usuario Encontrado");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Pesssoas Encontradas: ");

                foreach (var pessoa in listaDePessoasEncontradas)
                {
                    Console.WriteLine(pessoa.Id + " - " + pessoa.nome + " " + pessoa.sobreNome);
                }

                Console.WriteLine("");
                Console.WriteLine("Digite o numero correspondente a pessoa que deseja editar: ");
                int escolha = int.Parse(Console.ReadLine());

                foreach (var pessoa in listaDePessoasEncontradas)
                {
                    if (pessoa.Id == escolha)
                    {
                        Pessoa pessoaVelha = Repositorio.BuscarPessoaPorId(escolha);
                        Console.WriteLine("Entre com o novo nome do meliante: ");
                        String nomeT = Console.ReadLine();
                        Console.WriteLine("Entre com o novo Sobrenome do meliante: ");
                        String sobrenomeT = Console.ReadLine();
                        DateTime aniversarioN = RecebeETransformaData();

                        Pessoa pessoaNova = new Pessoa(pessoaVelha.Id, nomeT, sobrenomeT, aniversarioN);

                        Repositorio.Editar(pessoaNova);

                        Console.WriteLine("Pessoa alterada!");
                    }
                }
            }
            VoltarProMenu();
        }

        private static void AniversarianteDoDia()
        {
            DateTime hj = DateTime.Today;
            var niverToday = Repositorio.BuscarTodasPessoas(hj);
            if (niverToday.Count() == 0)
            {
                Console.WriteLine("Nenhum aniversario hj amigao!!");
            }
            else
            {
                foreach (var pessoa in niverToday)
                {
                    Console.WriteLine(pessoa.Id + " - " + pessoa.nome + " " + pessoa.sobreNome);
                }
            }
        }

        public static void CadastrarPessoa()
        {
            Console.Clear();

            Console.WriteLine("Entre com o nome: ");
            String nome = Console.ReadLine();
            Console.WriteLine("Entre com o sobre nome: ");
            String sobreNome = Console.ReadLine();

            DateTime aniversarioD = RecebeETransformaData();

            var pessoas = Repositorio.BuscarTodasPessoas();

            Pessoa p = new Pessoa(nome, sobreNome, aniversarioD);

            foreach (var pessoa in pessoas)
            {
                Pessoa ultimo = pessoas.Last(x => x.Id == pessoa.Id);
                p.Id = ultimo.Id + 1;
            }

            Console.WriteLine(p);
            Console.WriteLine("");
            Console.WriteLine("Esta tudo certo com a adicao? (s/n) ");
            string opcao = Console.ReadLine();
            if (opcao == "s")
            {
                Console.WriteLine("Ok, adicionando pessoa...");
                Repositorio.Salvar(p);
            }
            else
            {
                CadastrarPessoa();
            }
            VoltarProMenu();
        }

        public static DateTime RecebeETransformaData()
        {
            Console.WriteLine("Entre com a data de nascimento em dd/mm/yyyy: ");
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
                Console.WriteLine("Entre com uma data valida por favor.");
                VoltarProMenu();
            }
            return dataC;
        }

        public static void BuscaPessoa()
        {
            Console.Clear();
            Console.WriteLine("Entre com o nome da pessoa que deseja buscar:");
            string[] nomeESobrenome = Console.ReadLine().Split(' ');
            string nome = nomeESobrenome[0];


            var listaDePessoasEncontradas = Repositorio.BuscarTodasPessoas(nome);

            if (listaDePessoasEncontradas.Count() == 0)
            {
                Console.WriteLine("Nenhum usuario Encontrado");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Pesssoas Encontradas: ");

                foreach (var pessoa in listaDePessoasEncontradas)
                {
                    Console.WriteLine(pessoa.Id + " - " + pessoa.nome + " " + pessoa.sobreNome);
                }

                Console.WriteLine("");
                Console.WriteLine("Digite o numero correspondente a pessoa que deseja ter mais detalhes: ");
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

        public static void VoltarProMenu()
        {
            Console.WriteLine("Aperte x para voltar ao menu.");
            string volta = Console.ReadLine();
            if (volta == "x")
            {
                MenuPrincipal();
            }
            else
            {
                Console.WriteLine("Opcao errada amigo!");
                VoltarProMenu();
            }
        }

        private static IRepositorio Repositorio = new Repositorio();
    }
}

