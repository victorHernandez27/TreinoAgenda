using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinoAgenda
{
    internal class Telefone
    {
        public string Tipo { get; set; }
        public int DDD { get; set; }
        public int Numero { get; set; }
        public Telefone Proximo { get; set; }
        public Telefone Anterior { get; set; }

        public Telefone(string tipo, int dDD, int numero)
        {
            Tipo = tipo;
            DDD = dDD;
            Numero = numero;
            Anterior = null;
            Proximo = null;
        }

        public override string ToString()
        {
            return Tipo + ": ("+ DDD+ ")" + Numero;
        }
    }   

}
