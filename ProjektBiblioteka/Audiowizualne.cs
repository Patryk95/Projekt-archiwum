using System.Collections.Generic;

namespace ProjektArchiwum
{
    class Audiowizualne:Oprogramowanie  // Klasa dziedziczy z oprogramowania w celu zaoszczedzenia kodu. Wystepuja w niej wszystkie potrzebne funkcje
    {
        public Audiowizualne() { Slownik = new Dictionary<int,Oprogramowanie>(); }  // Nie ma potrzeby deklaracji slownika, te pole jest dziedziczone z klasy Oprogramowanie
        public Audiowizualne(string Tytul, string Autor,
        double Cena,string DataZakupu,string DataPowstania,string Licencja)   // Konstruktor parametryczny 
        {
            this.Tytul = Tytul;
            this.Autor = Autor;
            this.Rodzaj = Rodzaj;
            this.Cena = Cena;
            this.DataZakupu = DataZakupu;
            this.DataPowstania = DataPowstania;
            this.Licencja = Licencja;
        }
    }
}
