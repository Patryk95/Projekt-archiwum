using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBiblioteka
{
    class StanBiblioteki
    {
        private int Licznik = 1;
        private Dictionary<int,ZbioryBiblioteczne> Slownik;
        public StanBiblioteki() { Slownik = new Dictionary<int, ZbioryBiblioteczne>(); } 
        public void DodajDoListy(string Tytul,string Autor,string Rodzaj
        ,double Cena)
        {
            Slownik.Add(Licznik,new Pismiennicze());
            Licznik += 1;
        }
    }
}
