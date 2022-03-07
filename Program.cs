using System;

namespace TreinoAgenda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListaContatos listaContatos = new ListaContatos();
            int opc;
            do
            {
                opc = Menu();

                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        listaContatos.Push(Cadastro()); 
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("=====BUSCAR DE CONTATO=====");
                        if (listaContatos.Vazia())
                        {
                            Console.WriteLine("=====AGENDA VAZIA=====");
                        }
                        else
                        {
                            listaContatos.BuscarContato(BucarContato());
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        if (listaContatos.Vazia())
                        {
                            Console.WriteLine("=====AGENDA VAZIA=====");
                        }
                        else
                        {
                            listaContatos.Pop(listaContatos.Encontrar(BucarContato()));
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        if (listaContatos.Vazia())
                        {
                            Console.WriteLine("=====AGENDA VAZIA=====");
                        }
                        else
                        {
                            listaContatos.Editar(listaContatos.Encontrar(BucarContato()));
                        }
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        listaContatos.Print();
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Saindo...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção Inválida!Tente Novamente!");
                        Console.ReadKey();
                        break;
                }

            }while (opc != 6);
        }

        public static int Menu()
        {
            int opcMenu;
            Console.Clear();
            Console.WriteLine("=====MENU PRINCIPAL=====");
            Console.WriteLine("\n1-Cadastrar Contato\n2-Localizar Contato\n3-Remover Contato\n4-Editar Contato\n5-Imprimir Contatos\n6-Sair");
            opcMenu = int.Parse(Console.ReadLine());

            return opcMenu;
        }

        public static Contato Cadastro()
        {
            string nome, email;
            Console.WriteLine("=====Cadastro de Contato=====");
            Console.WriteLine("Nome: ");
            nome = Console.ReadLine().Trim();
            Console.WriteLine("E-mail: ");
            email = Console.ReadLine().Trim();

            ListaTelefones listaTelefones = new ListaTelefones();
            int tipo, ddd, numero, adicional=0;
            string tipoTelefone;

            do
            {
                do
                {
                    Console.WriteLine("Digite o Tipo do Telefone:\n1-Celular\n2-Residencial\n3-Trabalho\n4-Recado");
                    tipo = int.Parse(Console.ReadLine());

                    if ((tipo < 1) || (tipo > 4))
                    {
                        Console.WriteLine("\nOpção Invalida!Digite Novamente!\n");
                    }

                } while ((tipo < 1) || (tipo > 4));

                switch (tipo)
                {
                    case 1:
                        tipoTelefone = "Celular";
                        break;
                    case 2:
                        tipoTelefone = "Residencial";
                        break;
                    case 3:
                        tipoTelefone = "Trabalho";
                        break;
                    case 4:
                        tipoTelefone = "Recado";
                        break;
                    default:
                        tipoTelefone = "Invalido";
                        break;
                }

                do
                {
                    Console.WriteLine("DDD:");
                    ddd = int.Parse(Console.ReadLine());

                    if (ddd < 1)
                    {
                        Console.WriteLine("\nDDD Invalido\nDigite Novamente!\n");
                    }
                } while (ddd < 1);
                Console.WriteLine("Numero:");
                numero = int.Parse(Console.ReadLine());
                listaTelefones.Push(new Telefone(tipoTelefone, ddd, numero));
                Console.WriteLine("Deseja adicionar mais números?(1-Sim) | (2-Não)");
                adicional = int.Parse(Console.ReadLine());              

            } while (adicional == 1);

            return new Contato(nome, email, listaTelefones);
        }

        public static string BucarContato()
        {
            string nomeBusca;
            Console.WriteLine("Nome::");
            nomeBusca = Console.ReadLine().ToLower();

            return nomeBusca;
        }
    }
}
