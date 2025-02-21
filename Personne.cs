using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exe_personne
{
    public class Personne
    {
        private string nom;

        public string Nom { get => nom; set => nom = value; }
        public int Age { get; set; }

        public override string ToString()
        {
            return Nom + "," + Age + "ans";
        }
    }
}
