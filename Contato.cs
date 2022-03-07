using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinoAgenda
{
    internal class Contato
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public ListaTelefones ListaTelefones { get; set; }

        public Contato Proximo { get; set; }
        public Contato Anterior { get; set; }

        public Contato(string nome, string email, ListaTelefones listaTelefones)
        {
            Nome = nome;
            Email = email;
            ListaTelefones = listaTelefones;
            Anterior = null;
            Proximo = null;
        }

        public override string ToString()
        {
            return "\nNome: "+Nome+"\nEmail: "+ Email+"\nTelefones:";
        }
    }
}
