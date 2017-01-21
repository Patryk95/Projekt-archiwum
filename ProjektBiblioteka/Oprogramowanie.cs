using System.Collections.Generic;

namespace ProjektArchiwum
{
    class Oprogramowanie:ZbioryBiblioteczne
    {
        protected string Licencja;
        protected int Licznik = 1;
        protected Dictionary<int,Oprogramowanie> Slownik;
        public Oprogramowanie() { Slownik = new Dictionary<int, Oprogramowanie>(); } // Deklaracja slownika z jednoczesna inicjalizacja
        public Oprogramowanie(string Tytul, string Autor,
        double Cena,string DataZakupu,string DataPowstania,string Licencja)
        {
            this.Tytul = Tytul;
            this.Autor = Autor;
            this.Rodzaj = Rodzaj;
            this.Cena = Cena;
            this.DataZakupu = DataZakupu;
            this.DataPowstania = DataPowstania;
            this.Licencja = Licencja;
        }
        public void DodajDoListy(string Tytul, string Autor
        ,double Cena, string DataZakupu, string DataPowstania,  // Metoda dodajaca elementy do slownika
        string Licencja)
        {
            Slownik.Add(Licznik, new Oprogramowanie(Tytul, Autor, Cena, DataZakupu, DataPowstania,Licencja));
            Licznik += 1;
        }
        public override string ToString()  // Metoda wypisujaca elementy
        {
            if (Slownik.Count > 0)
            {
                string Zawartosc = "";
                foreach (var element in Slownik)
                {
                    Zawartosc ="Tytuł: " + element.Value.Tytul + ",Autor: " + element.Value.Autor + ",Cena: " + element.Value.Cena.ToString()
                    + ",DataZakupu: " + element.Value.DataZakupu.ToString() + ",DataPowstania: " + element.Value.DataPowstania.ToString()
                    +  ",Licencja: "+element.Value.Licencja+"\n";
                }
                return Zawartosc;
            }
            else
                return "";
        } 


    }   
}
