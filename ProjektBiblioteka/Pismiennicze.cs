using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ProjektArchiwum
{
    class Pismiennicze:ZbioryBiblioteczne,IZarzadzamZbiorami
    {
        public string Slad = "";
        private string ISBN;
        private string Wydawnictwo;
        private int Licznik = 1;
        private Dictionary<int,Pismiennicze> Slownik;
        public Pismiennicze() { Slownik = new Dictionary<int, Pismiennicze>(); }  // Deklaracja slownika  i jego jednoczesna inicjalizacja
        public Pismiennicze(string Tytul,string Autor,string Rodzaj
        ,double Cena,string DataZakupu,string DataPowstania,int Regal,string ISBN  // Konstruktor parametryczny uzupelnia pola z klasy abstrakcyjnej i swoje
        ,string Wydawnictwo)
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
        }
        public void DodajDoListy(string Tytul,string Autor,string Rodzaj
        , double Cena, string DataZakupu, string DataPowstania, int Regal, string ISBN  // Metoda dodaje do slownika elementy jednoczesnie zwiekszajac wartosc klucz o 1 za kazdym dodaniem.
        , string Wydawnictwo)
        {
            Slownik.Add(Licznik,new Pismiennicze(Tytul,Autor,Rodzaj,Cena,DataZakupu,DataPowstania,Regal,ISBN,Wydawnictwo));
            Licznik += 1;
        }
        public override string ToString()  // Metoda wypisuje zawartosc slownika
        {
            if (Slownik.Count > 0)
            {
                string Zawartosc = "";
                foreach (var element in Slownik)
                {
                    Zawartosc="Tytuł: " + element.Value.Tytul + ",Autor: " + element.Value.Autor + ",Rodzaj: " + element.Value.Rodzaj + ",Cena: " + element.Value.Cena.ToString()
                    +",DataZakupu: " + element.Value.DataZakupu.ToString() + ",DataPowstania: " + element.Value.DataPowstania.ToString()
                    + ",Regal: " + element.Value.Regal.ToString() + ",ISBN: " + element.Value.ISBN + ",Wydawnictwo: " + element.Value.Wydawnictwo + "\n";
                }
                return Zawartosc;
            }
            else
                return "";
        } 
        public int ZliczamIlePrzejscDoNowejLini(string NazwaPliku)  // Metoda zlicza ilosc wystapien znaku \n i zwraca ta ilosc
        {
            StreamReader Odczyt = new StreamReader(NazwaPliku);
            int IloscNowychLini = 0;
            string Napis;
            using (Odczyt)
            {
                while ((Napis = Odczyt.ReadLine()) != null)
                {
                    IloscNowychLini++;
                }
                Odczyt.Close();
            }
            return IloscNowychLini;
        }
        public void WyswietlZbior(ListBox Lista,string NazwaPliku) // Metoda pozwala wyswietlic zawartosc pliku txt, o danej nazwie w ListBoxie
        {
            if (File.Exists(NazwaPliku))
            {
                StreamReader Odczyt = new StreamReader(NazwaPliku);
                string[] Tablica = new string[ZliczamIlePrzejscDoNowejLini(NazwaPliku)];
                for (int i = 0; i < ZliczamIlePrzejscDoNowejLini(NazwaPliku); i++)
                {
                    Tablica[i] = Odczyt.ReadLine();
                }
                for (int j = 0; j < ZliczamIlePrzejscDoNowejLini(NazwaPliku); j++)
                {
                    Lista.Items.Add(Tablica[j]);
                   
                }
                    Odczyt.Close();
            }
        }
        public void UsunWybranyElementZbioru(string Wartosc,ListBox Lista,string NazwaPliku,int ZaznaczonyWiersz) // Funkcja usuwa na stale zaznaczony wiersz
        {
             if(Lista.Items.Contains(Wartosc)) // Najpierw sprwadzamy czy zaznaczony wiersz istnieje w danym pliku txt
             {
                 string[] Tablica = new string[ZliczamIlePrzejscDoNowejLini(NazwaPliku)];
                 StreamReader OdczytZawartosci = new StreamReader(NazwaPliku);
                 for (int i = 0; i < ZliczamIlePrzejscDoNowejLini(NazwaPliku); i++) // Dokonujemy odczytu a nastepnie uzuplniamy tablice
                 {
                     Tablica[i] = OdczytZawartosci.ReadLine();
                 }
                 OdczytZawartosci.Close();
                 Tablica[ZaznaczonyWiersz] = null; // usuwamy zaznaczony wiersz
                 try
                 {
                     Lista.Items.RemoveAt(ZaznaczonyWiersz);
                     File.WriteAllLines(NazwaPliku, Tablica);   // Odswiezamy liste i plik tekstowy
                     
                 }
                 catch
                 {
                     MessageBox.Show("Nie ma juz nic do usunięcia");
                 }               
             }
        }
        public string Wyszukuje(string Nazwa,string Tytul,string Rodzaj,string Data,string Regal,TextBox Zawartosc)
        {
            
            StreamReader Odczyt = new StreamReader(Nazwa);
            string Zwrot = "";
            string[] Tablica = new string[ZliczamIlePrzejscDoNowejLini(Nazwa)];
            for (int i = 0; i < ZliczamIlePrzejscDoNowejLini(Nazwa); i++)
            {
                Tablica[i] = Odczyt.ReadLine();
            }
            foreach(string element in Tablica)
            {
                if(element.Contains(Tytul) || element.Contains(Rodzaj) || element.Contains(Data) || element.Contains(Regal))
                {
                    Zwrot+="\n"+element;
                }
            }
            Odczyt.Close();
            return Zwrot;
        }
      
    }
}
