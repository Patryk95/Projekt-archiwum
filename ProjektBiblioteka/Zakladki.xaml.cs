using ProjektArchiwum;
using System;
using System.IO;
using System.Windows;

namespace ProjektBiblioteka
{
    /// <summary>
    /// W tym okienku mozemy korzystać z czegos na zasadzie karty bibliotecznej. 
    /// Mozna dodawac,a takze przegladac wszystkie stworzone karty. 
    /// </summary>
    public partial class Zakladki : Window
    {
        Osoba NowaOsoba = new Osoba();
        public Zakladki()
        {
            InitializeComponent();
            RamkaDanych.Visibility = Visibility.Visible;
            RamkaPrzyciskow.Visibility = Visibility.Visible;
            NowaOsoba.Licznik = 0;
            Directory.SetCurrentDirectory(NowaOsoba.ZwracamSciezke());
        }

        private void Cofnij(object sender, RoutedEventArgs e)
        {
            OknoDodawania Okno = new OknoDodawania();
            Okno.Show();
            this.Close();
        }

        private void Dodaj(object sender, RoutedEventArgs e) // Funkcja dodajaca nowa osobe
        {
           
            if(string.IsNullOrEmpty(txtImie.Text) || string.IsNullOrEmpty(txtNazwisko.Text) || string.IsNullOrEmpty(txtNazwaUczelni.Text)
              || string.IsNullOrEmpty(txtOstatnioWypozyczono.Text) || string.IsNullOrEmpty(txtDataUrodzenia.Text)
              || string.IsNullOrEmpty(txtPesel.Text) || string.IsNullOrEmpty(txtLiczbaKsiazek.Text))
            {
                MessageBox.Show("Wszystkie pola powinny zostać uzupełnione");  // Sprawdzanie czy wszystkie potrzebne pola zostaly uzupelnione
            }
            else
            {
                try
                { 
                    Directory.SetCurrentDirectory(NowaOsoba.ZwracamSciezke());
                    NowaOsoba.DodajOsobe(txtImie.Text, txtNazwisko.Text, txtNazwaUczelni.Text, txtOstatnioWypozyczono.Text, txtDataUrodzenia.Text, txtPesel.Text, Convert.ToInt32(txtLiczbaKsiazek.Text));
                    txtImie.Text="";
                    txtNazwisko.Text="";
                    txtNazwaUczelni.Text="";
                    txtOstatnioWypozyczono.Text="";
                    txtDataUrodzenia.Text="";
                    txtPesel.Text = ""; 
                    txtLiczbaKsiazek.Text="";

                }
                catch(Exception k)
                {
                    MessageBox.Show(k.Message);
                }

            }
        }

        private void PrzegladajZakladki(object sender, RoutedEventArgs e) //Funkcja otwierajaca mozliwosci przegladania zakladek
        {
            RamkaNawigacji.Visibility = Visibility.Hidden;   
            if(Directory.Exists("Osoby"))                               // Odrazu uzupelniane sa wartosci w polach przy otwarciu tej opcji . 1 osoba z folderu
            {
                Directory.SetCurrentDirectory(NowaOsoba.ZwracamSciezke());
                RamkaDanych.Visibility = Visibility.Hidden;
                RamkaPrzyciskow.Visibility = Visibility.Hidden;
                Ramka.Visibility = Visibility.Visible;
                RamkaWyswietlania.Visibility = Visibility.Visible;
                Directory.SetCurrentDirectory("Osoby");
                NowaOsoba.PobieramNazwyPlikow();
                string[] Tablica = NowaOsoba.UzupelniamTablice(NowaOsoba.ListaNazw[0]);
                UzupelniamPola(Tablica);
                Directory.SetCurrentDirectory(NowaOsoba.ZwracamSciezke());
                
            }
            else
            {
                MessageBox.Show("Nie ma jeszcze żadnych osób");
            }

        }
        private void UzupelniamPola(string[] Tablica) // Funkcja uzupelniajaca po kolei pola
        {
            txtWyswImie.Text = Tablica[0];
            txtWyswNazwisko.Text = Tablica[1];
            txtWyswNazwaUczelni.Text = Tablica[2];
            txtWyswOstatnioWypozyczono.Text = Tablica[3];
            txtWyswDataUrodzenia.Text = Tablica[4];
            txtWyswPesel.Text = Tablica[5];
            txtWyswLiczbaKsiazek.Text = Tablica[6];
            
            
        }

        private void CofnijDoDodaj(object sender, RoutedEventArgs e) // Sterowanie widocznosciami
        {
            NowaOsoba.Licznik = 0;   
            RamkaDanych.Visibility = Visibility.Visible;
            RamkaPrzyciskow.Visibility = Visibility.Visible;
            Ramka.Visibility = Visibility.Hidden;
            RamkaWyswietlania.Visibility = Visibility.Hidden;
            RamkaNawigacji.Visibility = Visibility.Hidden;
        }

        private void CofnijDoMenu(object sender, RoutedEventArgs e)  // Cofa do Menu glownego
        {
            NowaOsoba.Licznik = 0;
            OknoDodawania Okno = new OknoDodawania();
            Okno.Show();
            this.Close();
        }

        private void PokazNastepny(object sender, RoutedEventArgs e)  // Umozliwa odczytanie kolejnej osoby z pliku tekstowego
        {
            NowaOsoba.Licznik++;
            try
            {
                if (NowaOsoba.Licznik >= 1 || NowaOsoba.Licznik < NowaOsoba.RozmiarListy)
                {
                    RamkaNawigacji.Visibility = Visibility.Visible;
                    Directory.SetCurrentDirectory("Osoby");
                    string[] TablicaPomocnicza = NowaOsoba.UzupelniamTablice(NowaOsoba.ListaNazw[NowaOsoba.Licznik]);
                    UzupelniamPola(TablicaPomocnicza);
                    Directory.SetCurrentDirectory(NowaOsoba.ZwracamSciezke());
                }
            }
            catch
            {
                Directory.SetCurrentDirectory(NowaOsoba.ZwracamSciezke());
                --NowaOsoba.Licznik;
                MessageBox.Show("Nie ma więcej osób");
        
            }
          
          
        }

        private void PokazWczesniejszy(object sender, RoutedEventArgs e) // Umozliwia odczytanie wczesniejszej osoby z pliku tekstowego
        {
           if(NowaOsoba.Licznik>0)
           {
               NowaOsoba.Licznik--;
               if(NowaOsoba.Licznik==0)
               {
                   RamkaNawigacji.Visibility = Visibility.Hidden;
               }
               Directory.SetCurrentDirectory("Osoby");
               string[] TablicaPomocnicza = NowaOsoba.UzupelniamTablice(NowaOsoba.ListaNazw[NowaOsoba.Licznik]);
               UzupelniamPola(TablicaPomocnicza);
               Directory.SetCurrentDirectory(NowaOsoba.ZwracamSciezke());
           }
        }
    }
}
