using System.Collections.Generic;

namespace ProjektArchiwum
{
    class GraficznoPismiennicze:ZbioryBiblioteczne
    {
        private string ISBN, Wydawnictwo,Typ;
        private int Licznik = 1;
        private Dictionary<int,GraficznoPismiennicze> Slownik;
        public GraficznoPismiennicze() { Slownik = new Dictionary<int, GraficznoPismiennicze>(); }  // Deklaracja i inicjalizacja slownika
        public GraficznoPismiennicze(string Tytul, string Autor, string Rodzaj
        ,double Cena,string DataZakupu,string DataPowstania,int Regal,string ISBN
        ,string Wydawnictwo,string Typ)
        {
            this.Tytul = Tytul;
            this.Autor = Autor;
            this.Rodzaj = Rodzaj;
            this.Cena = Cena;
            this.DataZakupu = DataZakupu;
            this.DataPowstania = DataPowstania;
            this.Regal = Regal;
            this.ISBN = ISBN;
            this.Wydawnictwo = Wydawnictwo;
            this.Typ = Typ;
        }
        public void DodajDoListy(string Tytul,string Autor,string Rodzaj  // Dodajemy do slownika wartosci
        , double Cena, string DataZakupu, string DataPowstania, int Regal, string ISBN
        , string Wydawnictwo,string Typ)
        {
            Slownik.Add(Licznik,new GraficznoPismiennicze(Tytul,Autor,Rodzaj,Cena,DataZakupu,DataPowstania,Regal,ISBN,Wydawnictwo,Typ));
            Licznik += 1;
        }
        public override string ToString() // Metoda wypisuje zawartosc slownika
        {
            if (Slownik.Count > 0)
            {
                string Zawartosc = "";
                foreach (var element in Slownik)
                {
                    Zawartosc="Tytuł: " + element.Value.Tytul + ",Autor: " + element.Value.Autor + ",Rodzaj: " + element.Value.Rodzaj + ",Cena: " + element.Value.Cena.ToString()
                    +",DataZakupu: " + element.Value.DataZakupu.ToString() + ",DataPowstania: " + element.Value.DataPowstania.ToString()
                    + ",Regal: " + element.Value.Regal.ToString() + ",ISBN: " + element.Value.ISBN + ",Wydawnictwo: " + element.Value.Wydawnictwo + ",Typ: "+element.Value.Typ+"\n";
                }
                return Zawartosc;
            }
            else
                return "";
        } 
    }
}
