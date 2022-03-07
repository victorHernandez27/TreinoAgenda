using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinoAgenda
{
    internal class ListaContatos
    {
        public Contato Head { get; set; }
        public Contato Tail { get; set; }

        public ListaContatos()
        {
            Head = null;
            Tail = null;
        }

        public void Push(Contato novoContato)
        {
            if (Vazia())
            {
                Head = novoContato;
                Tail = novoContato;
            }
            else
            {
                if (String.Compare(novoContato.Nome, Tail.Nome) >= 0)
                {
                    Tail.Proximo = novoContato;
                    novoContato.Anterior = Tail;
                    Tail = novoContato;
                }
                else
                {
                    if(String.Compare(novoContato.Nome, Head.Nome) <= 0)
                    {
                        novoContato.Proximo = Head;
                        Head.Anterior = novoContato;
                        Head = novoContato;
                    }
                    else
                    {
                        Contato aux = Head;
                        do
                        {
                            if(String.Compare(novoContato.Nome,aux.Nome) >= 0)
                            {
                                aux= aux.Proximo;
                            }
                            else
                            {
                                novoContato.Proximo = aux;
                                novoContato.Anterior= aux.Anterior;
                                novoContato.Anterior.Proximo = novoContato;
                                aux.Anterior = novoContato;
                                aux = aux.Proximo;
                            }

                        }while (aux != null);
                    }
                }
            }
            Console.WriteLine("=====NOVO CONTATO ADICIONADO=====");
        }

        public void Print()
        {
            if (Vazia())
            {
                Console.WriteLine("=====AGENDA VAZIA=====");
            }
            else
            {
                Console.WriteLine("=====MEUS CONTATOS======");
                Contato aux = Head;

                do
                {
                    Console.WriteLine(aux.ToString());
                    aux.ListaTelefones.Print();
                    aux = aux.Proximo;
                    Console.ReadKey();
                }while (aux != null);

                Console.WriteLine("----------------------------");
            }
        }

        public void BuscarContato(string nomeBusca)
        {
            if(nomeBusca == null)
            {
                Console.WriteLine("Não exites contato cadastrado com esse nome!");
            }
            else
            {
                Contato aux = Head;
                do
                {
                    if (aux.Nome.ToLower().Contains(nomeBusca.ToString()))
                    {
                        Console.WriteLine(aux.ToString());
                        aux.ListaTelefones.Print();
                    }
                    aux = aux.Proximo;
                }while(aux != null);

                Console.WriteLine("----------------------------");
            }
        }

        public void Pop(Contato apagar)
        {
            if (apagar != null)
            {
                if (Head == apagar)
                {
                    Head = Head.Proximo;
                }
                else if (Tail == apagar)
                {
                    apagar.Anterior.Proximo = apagar.Proximo;
                    Tail = apagar.Anterior;
                }
                else
                {
                    apagar.Anterior.Proximo = apagar.Proximo;
                    apagar.Proximo.Anterior = apagar.Anterior;
                }
                if (Head == null)
                    Tail = null;
                Console.WriteLine(">>>>>>CONTATO APAGADO<<<<<<");
            }
            else
            {
                Console.WriteLine("Nenhum contato com este nome encontrado");
            }
        }

        public Contato Encontrar(string nome)
        {
            Contato aux = Head;
            Contato aux1 = Head;
            int contador = 0;
            do
            {
                if (aux.Nome.ToLower().Contains(nome.ToLower()))
                {
                    aux1 = aux;
                    contador++;
                }
                aux = aux.Proximo;
            } while (aux != null);

            if (contador > 1)
                return Escolha(nome);
            else if (contador == 1)
                return aux1;
            else
                return aux;
        }

        public Contato Escolha(string nome)
        {
            int opc, cont = 0;
            Contato aux = Head;
            for (int i = 1; i <= NElementos(); i++)
            {
                if (aux.Nome.ToLower().Contains(nome.ToLower()))
                {
                    cont++;
                    Console.WriteLine(aux.ToString());

                }
                aux = aux.Proximo;
            }

            do
            {
                Console.WriteLine("Selecione qual deseja de 1 a {0}", cont);
                opc = int.Parse(Console.ReadLine());
            } while ((opc < 1) || (opc > cont));

            aux = Head;
            cont = 1;
            for (int i = 1; i <= NElementos(); i++)
            {
                if (opc == cont)
                {
                    break;
                }
                else
                {
                    cont++;
                    aux = aux.Proximo;
                }
            }
            return aux;
        }

        public int NElementos()
        {
            int qtd = 0;
            Contato aux = Head;
            do
            {
                qtd++;
                aux = aux.Proximo;
            } while (aux != null);
            return qtd;
        }

        public void Editar(Contato alterar)
        {
            Console.Clear();
            if (alterar != null)
            {
                Console.WriteLine(">>>>>>ALTERANDO CONTATO<<<<<<");
                int opc;
                Console.WriteLine(alterar.ToString());
                alterar.ListaTelefones.Print();
                Console.Write("Que informação deseja alterar: \n1-Nome\n1-E-mail\n1-Telefone");
                Console.Write("\nOpção: ");
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.Write("Digite o novo nome: ");
                        Push(new Contato(Console.ReadLine().Trim(), alterar.Email, alterar.ListaTelefones));
                        Pop(alterar);
                        Console.WriteLine("======NOME ALTERADO======");
                        break;
                    case 2:
                        Console.Write("Digite o novo E-mail: ");
                        alterar.Email = Console.ReadLine().Trim();
                        Console.WriteLine("======EMAIL ALTERADO======");
                        break;
                    case 3:
                        int tipo;
                        string tipoescolhido;
                        alterar.ListaTelefones.Print();
                        do
                        {
                            Console.WriteLine("Qual telefone deseja alterar: \n1-Celular\n1-Residencial\n1-Trabalho\n1-Recado");
                            tipo = int.Parse(Console.ReadLine());
                            switch (tipo)
                            {
                                case 1:
                                    tipoescolhido = "Celular";
                                    break;
                                case 2:
                                    tipoescolhido = "Residencial";
                                    break;
                                case 3:
                                    tipoescolhido = "Trabalho";
                                    break;
                                case 4:
                                    tipoescolhido = "Recado";
                                    break;
                                default:
                                    Console.WriteLine("Tipo de telefone invalido! \nDigite novamente");
                                    tipoescolhido = "Invalido";
                                    break;
                            }
                        } while ((tipo > 4) || (tipo < 1));

                        Telefone tells = alterar.ListaTelefones.Head;
                        do
                        {
                            if (string.Equals(tells.Tipo, tipoescolhido))
                            {
                                Console.WriteLine("Digite o novo DDD do {0}: ", tipoescolhido);
                                tells.DDD = int.Parse(Console.ReadLine());
                                Console.WriteLine("Digite o novo numero {0}: ", tipoescolhido);
                                tells.Numero = int.Parse(Console.ReadLine());
                                Console.Clear();
                                Console.WriteLine("======{0} ALTERADO======", tipoescolhido.ToUpper());
                            }
                            tells = tells.Proximo;
                        } while (tells != null);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Nenhum contato com este nome encontrado");
            }
        }

        public bool Vazia()
        {
            if((Head == null) && (Tail == null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
