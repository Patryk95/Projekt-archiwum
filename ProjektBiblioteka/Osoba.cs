using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ProjektBiblioteka    // Klasa wykorzystywana w zakladkach
{
    class Osoba
    {
        private string Imie, Nazwisko,NazwaUczelni,NazwaOstatniejKsiazki,DataUrodzenia,Pesel;  // Deklaracja pol
        private int LiczbaKsiazek;
        private Dictionary<int, Osoba> SpisOsob;
        private int Klucz = 1;
        private string Sciezka = Directory.GetCurrentDirectory();
        private const string Nazwa="Osoby";      
        public int Licznik { get; set; }       // Uzywanie wlasciwosci do zwracania i ustawianiaLicznika
        public string[] ListaNazw { get; set; } // Uzywanie wlascicowsci do zwracania i ustawiania ListyNazw
        public int RozmiarListy { get; set; } // Uzywanie wlasciwosci do zwracania i ustawiania Rozmiaru 
        public Osoba() { SpisOsob = new Dictionary<int, Osoba>(); }
        public Osoba(string Imie,string Nazwisko,string NazwaUczelni,string NazwaOstatniejKsiazki,string DataUrodzenia,string Pesel,int LiczbaKsiazek)
        {
            this.Imie = Imie;
            this.Nazwisko = Nazwisko;
            this.NazwaUczelni = NazwaUczelni;
            this.NazwaOstatniejKsiazki = NazwaOstatniejKsiazki;
            this.DataUrodzenia = DataUrodzenia;
            this.Pesel = Pesel;
            this.LiczbaKsiazek = LiczbaKsiazek;
        }
        public void DodajOsobe(string Imie,string Nazwisko,string NazwaUczelni,string NazwaOstatniejKsiazki,string DataUrodzenia,string Pesel,int LiczbaKsiazek) // Funkcja dodaje nowa osobe i tworzy katalog plik tekstowy
        {
            SpisOsob.Add(Klucz, new Osoba(Imie,Nazwisko,NazwaUczelni,NazwaOstatniejKsiazki,DataUrodzenia,Pesel,LiczbaKsiazek));
            Klucz++;
            if (!Directory.Exists(Nazwa))
            {
                Directory.CreateDirectory(Nazwa);
            }
            Directory.SetCurrentDirectory(Nazwa);
            if (!File.Exists(Imie + Nazwisko + ".txt"))
            {
                TextWriter Zapis = new StreamWriter(Imie + Nazwisko + ".txt");  // Zapisywanie do pliku parametrow
                Zapis.WriteLine(SpisOsob[1].Imie);
                Zapis.WriteLine(SpisOsob[1].Nazwisko);
                Zapis.WriteLine(SpisOsob[1].NazwaUczelni);
                Zapis.WriteLine(SpisOsob[1].NazwaOstatniejKsiazki);
                Zapis.WriteLine(SpisOsob[1].DataUrodzenia);
                Zapis.WriteLine(SpisOsob[1].Pesel);
                Zapis.WriteLine(SpisOsob[1].LiczbaKsiazek.ToString());
                Zapis.Close();
                MessageBox.Show("Dodano");
            }
            else
            {
                MessageBox.Show("Taka osoba już istnieje");
            }
            Directory.SetCurrentDirectory(Sciezka);
        }
        
        public string ZwracamSciezke()
        {
            return Sciezka;
        }
        public void PobieramNazwyPlikow()  // Pobiera nazwy plikow z aktualnie otwartego katalogu
        {
            ListaNazw = Directory.GetFiles(Directory.GetCurrentDirectory());  // Przypisuje te nazwy do tablicy
            RozmiarListy = ListaNazw.Length; // Przypisuje polu rozmiar listy rozmiar tablicy
        }
        public string[] UzupelniamTablice(string Nazwa) // Odczytuje plik tekstowy i zwraca tablice.
        {
            StreamReader Odczyt = new StreamReader(Nazwa);
            string[] Tablica = new string[7];
            for(int i=0;i<7;i++)
            {
                Tablica[i] = Odczyt.ReadLine();
            }
            Odczyt.Close();
            return Tablica;
        }
      
    }
}
