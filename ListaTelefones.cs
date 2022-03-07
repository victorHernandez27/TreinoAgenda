using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinoAgenda
{
    internal class ListaTelefones
    {
        public Telefone Head { get; set; }
        public Telefone Tail { get; set; }

        public ListaTelefones()
        {
            Head = null;
            Tail = null;
        }

        public void Push(Telefone novoTelefone)
        {
            if (Vazia())
            {
                Head = novoTelefone;
                Tail = novoTelefone;
            }
            else
            {
                Tail.Proximo = novoTelefone;
                Tail = novoTelefone;
            }
        }

        public void Print()
        {
            if (Vazia())
            {
                Console.WriteLine("=====NÃO HÁ TELEFONES CADASTRADOS=====");
            }
            else
            {
                Telefone aux = Head;

                do
                {
                    Console.WriteLine(aux.ToString());
                    aux = aux.Proximo;
                }while (aux != null);
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
