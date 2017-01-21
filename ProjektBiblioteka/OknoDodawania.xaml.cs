using System;
using System.Windows;
using System.Windows.Media;
using System.IO;
using ProjektBiblioteka;
namespace ProjektArchiwum
{
    /// <summary>
    /// W tym oknie wykonywane sa podstawowe operacje aplikacji. Mozemy dodawac zbiorybiblioteczne i wyswietla sie ono zaraz po zalogowaniu.
    /// Mozemy takze przechodzic do nastepnego opcji takich jak wyswietlanie zbiorow. 
    /// W tym oknie korzystamy wiele razy z visibility ukrywajac i pokazujac dane kontrolki w celu oszczedzenia tworzenia nie potrzebnych okien.
    /// 
    ///
    /// </summary>
    public partial class OknoDodawania : Window
    {
        Pismiennicze NowePismiennicze = new Pismiennicze();                    // Tworzenie obiektow po to w celu mozliwosci uzywania metod w ich klasach. 
        GraficznoPismiennicze NoweGrafPis = new GraficznoPismiennicze();
        Oprogramowanie NoweOprogramowanie=new Oprogramowanie();
        Audiowizualne NoweAudiowizualne = new Audiowizualne();
        public OknoDodawania()
        {
            InitializeComponent();
            
        }

        private void DodajPismiennicze(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(txtTytul.Text) || string.IsNullOrEmpty(txtAutor.Text) || string.IsNullOrEmpty(txtRodzaj.Text)
              || string.IsNullOrEmpty(txtCena.Text) || string.IsNullOrEmpty(txtDataZakupu.Text) || string.IsNullOrEmpty(txtDataPowstania.Text) || string.IsNullOrEmpty(txtRegal.Text) 
              || string.IsNullOrEmpty(txtISBN.Text)
              || string.IsNullOrEmpty(txtWydawnictwo.Text))   // Sprawdzamy czy wpisane przez nas pola nie sa puste
              {
                  MessageBox.Show("Powinienes wypelnic wszystkie pola");
              }
            else if(txtISBN.Text.Length<11)      // Sprawdzamy czy ISBN ma conajmniej 10 znakow.
            {
                MessageBox.Show("ISBN powiniene mieć conajmniej 10 znaków");
            }
            else
            {
                try
                {
                    if(!File.Exists("Pismiennicze.txt"))  // Sprawdzamy czy plik nie istnieje
                    {
                        TextWriter ZapisujeDoPliku = new StreamWriter("Pismiennicze.txt",true);  // Jezeli nie istnieje zapisujemy do pliku tekstowego wpisane przez nas wartosci w polach.
                        using(ZapisujeDoPliku)
                        {
                            NowePismiennicze.DodajDoListy(txtTytul.Text, txtAutor.Text, txtRodzaj.Text, Convert.ToDouble(txtCena.Text), txtDataZakupu.Text
                            , txtDataPowstania.Text, Convert.ToInt32(txtRegal.Text), txtISBN.Text, txtWydawnictwo.Text);
                            ZapisujeDoPliku.WriteLine(DateTime.Today.Year.ToString() + ":" + DateTime.Today.Month.ToString()
                            + ":" + DateTime.Today.DayOfWeek.ToString() + ",  " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "\n");
                            ZapisujeDoPliku.WriteLine(NowePismiennicze.ToString());
                            MessageBox.Show("Dodano");
                            ResetujeZawartosci();  // Funkcja resetuje zaawrtosci wpisane przez uzytkownika
                        }
                    }
                    else
                    {
                        TextWriter ZapisujeDoPliku = new StreamWriter("Pismiennicze.txt", true);
                        using (ZapisujeDoPliku)
                        {
                            NowePismiennicze.DodajDoListy(txtTytul.Text, txtAutor.Text, txtRodzaj.Text, Convert.ToDouble(txtCena.Text), txtDataZakupu.Text
                            , txtDataPowstania.Text, Convert.ToInt32(txtRegal.Text), txtISBN.Text, txtWydawnictwo.Text);
                            ZapisujeDoPliku.WriteLine(DateTime.Today.Year.ToString() + ":" + DateTime.Today.Month.ToString()
                         + ":" + DateTime.Today.DayOfWeek.ToString() + ",  " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "\n");
                            ZapisujeDoPliku.WriteLine(NowePismiennicze.ToString());
                            MessageBox.Show("Dodano");
                            ResetujeZawartosci();
                        }
                    }
                   
                }
                catch(Exception k)
                {
                    MessageBox.Show(k.Message);  // Lapie wyjatek w przypadku gdy wpisana wartosc do pola np Cena czy regal nie jest liczba tylko znakiem np 'a'
                }
                
            }
        }

        private void WyswietlPismiennicze(object sender, RoutedEventArgs e) // Funkcja zmienia tlo i ukrywa odkrywa potrzebne kontrolki
        {
            Tlo.Background = Brushes.White;
            RamkaPismiennicze.Visibility = Visibility.Visible;
            RamkaGraficznoPis.Visibility = Visibility.Hidden;
            RamkaOprogramowanie.Visibility = Visibility.Hidden;
            RamkaAudiowizualne.Visibility = Visibility.Hidden;
            RamkaWyszukiwania.Visibility = Visibility.Hidden;
           
        }

        private void Wyjscie(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();                        // Wylaczenie aplikacji
        }

        private void WyswietlGraficzne(object sender, RoutedEventArgs e) // Funkcja zmienia tlo i ukrywa odkrywa potrzebne kontrolki
        {
            Tlo.Background = Brushes.White;
            RamkaPismiennicze.Visibility = Visibility.Hidden;
            RamkaGraficznoPis.Visibility = Visibility.Visible;
            RamkaOprogramowanie.Visibility = Visibility.Hidden;
            RamkaAudiowizualne.Visibility = Visibility.Hidden;
            RamkaWyszukiwania.Visibility = Visibility.Hidden;
        }
        private void ResetujeZawartosci() // Funcka wypelnia pola znakami pustymi
        {
            txtTytul.Text = "";
            txtAutor.Text = "";
            txtRodzaj.Text = "";
            txtCena.Text = "";
            txtDataZakupu.Text = "";
            txtDataPowstania.Text = "";
            txtRegal.Text = "";
            txtISBN.Text = "";
            txtWydawnictwo.Text = "";
            txtTytulGP.Text = "";
            txtAutorGP.Text = "";
            txtRodzajGP.Text = "";
            txtCenaGP.Text = "";
            txtDataZakupuGP.Text = "";
            txtDataPowstaniaGP.Text = "";
            txtRegalGP.Text = "";
            txtISBNGP.Text = "";
            txtWydawnictwoGP.Text = "";
            txtTyp.Text = "";
            txtTytulOprogramowanie.Text = "";
            txtAutorOprogramowanie.Text = "";
            txtCenaOprogramowanie.Text = "";
            txtDataZakupuOprogramowanie.Text = "";
            txtDataPowstaniaOprogramowanie.Text = "";
            txtLicencjaOprogramowanie.Text = "";
            txtTytulAudio.Text = "";
            txtAutorAudio.Text = "";
            txtCenaAudio.Text = "";
            txtDataZakupuAudio.Text = "";
            txtDataPowstaniaAudio.Text = "";
            txtLicencjaAudio.Text = "";



        }

        private void Cofnij(object sender, RoutedEventArgs e)  // Otwieramy okno logowania zamykajac jednoczesnie aktualnie otwarte
        {
            MainWindow Okno = new MainWindow();
            Okno.Show();
            this.Close();
        }

        private void DodajPismGraficzne(object sender, RoutedEventArgs e)  // Dodaje nowy zbior biblioteczny
        {
           
            if(string.IsNullOrEmpty(txtTytulGP.Text) || string.IsNullOrEmpty(txtAutorGP.Text) || string.IsNullOrEmpty(txtRodzajGP.Text)
              || string.IsNullOrEmpty(txtCenaGP.Text) || string.IsNullOrEmpty(txtDataZakupuGP.Text) || string.IsNullOrEmpty(txtDataPowstaniaGP.Text) || string.IsNullOrEmpty(txtRegalGP.Text) 
              || string.IsNullOrEmpty(txtISBNGP.Text)
              || string.IsNullOrEmpty(txtWydawnictwoGP.Text) || string.IsNullOrEmpty(txtTyp.Text)) //Sprawdza czy wszystkie pola sa wypelnione
              {
                  MessageBox.Show("Powinienes wypelnic wszystkie pola");
              }
            else if(txtISBNGP.Text.Length<11)  // Sprawdza  czy ISBN jest prawidlowy
            {
                MessageBox.Show("ISBN powiniene mieć conajmniej 10 znaków");
            }
            else
            {
                try
                {
                    if(!File.Exists("GrafPis.txt"))  // Zapisuje do plik txt wartosci z pol
                    {
                        TextWriter ZapisujeDoPliku = new StreamWriter("GrafPis.txt",true);
                        using(ZapisujeDoPliku)
                        {
                            NoweGrafPis.DodajDoListy(txtTytulGP.Text, txtAutorGP.Text, txtRodzaj.Text, Convert.ToDouble(txtCenaGP.Text), txtDataZakupuGP.Text
                            , txtDataPowstaniaGP.Text, Convert.ToInt32(txtRegalGP.Text), txtISBNGP.Text, txtWydawnictwoGP.Text,txtTyp.Text);
                            ZapisujeDoPliku.WriteLine(DateTime.Today.Year.ToString() + ":" + DateTime.Today.Month.ToString()
                         + ":" + DateTime.Today.DayOfWeek.ToString() + ",  " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "\n");
                            ZapisujeDoPliku.WriteLine(NoweGrafPis.ToString());
                            MessageBox.Show("Dodano");
                            ResetujeZawartosci();
                        }
                    }
                    else   // Zapisuje do plik txt wartosci z pol
                    {
                        TextWriter ZapisujeDoPliku = new StreamWriter("GrafPis.txt", true);
                        using (ZapisujeDoPliku)
                        {
                            NoweGrafPis.DodajDoListy(txtTytulGP.Text, txtAutorGP.Text, txtRodzaj.Text, Convert.ToDouble(txtCenaGP.Text), txtDataZakupuGP.Text
                            , txtDataPowstaniaGP.Text, Convert.ToInt32(txtRegalGP.Text), txtISBNGP.Text, txtWydawnictwoGP.Text,txtTyp.Text);
                            ZapisujeDoPliku.WriteLine(DateTime.Today.Year.ToString() + ":" + DateTime.Today.Month.ToString()
                                         + ":" + DateTime.Today.DayOfWeek.ToString() + ",  " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "\n");
                            ZapisujeDoPliku.WriteLine(NoweGrafPis.ToString());
                            MessageBox.Show("Dodano");
                            ResetujeZawartosci();
                        }
                    }
                   
                }
                catch(Exception k)
                {
                    MessageBox.Show(k.Message);
                }
                
            }
        }

        private void DodajOprogramowanie(object sender, RoutedEventArgs e)
        {
           
              if(string.IsNullOrEmpty(txtTytulOprogramowanie.Text) || string.IsNullOrEmpty(txtAutorOprogramowanie.Text) || string.IsNullOrEmpty(txtCenaOprogramowanie.Text)
              || string.IsNullOrEmpty(txtDataZakupuOprogramowanie.Text) || string.IsNullOrEmpty(txtDataPowstaniaOprogramowanie.Text) || string.IsNullOrEmpty(txtLicencjaOprogramowanie.Text))
              {
                  MessageBox.Show("Powinienes wypelnic wszystkie pola");
              }
              else
              {
                  try
                  {
                      if (!File.Exists("Oprogramowanie.txt"))   // Zapisuje do plik txt wartosci z pol
                      {
                          TextWriter ZapisujeDoPliku = new StreamWriter("Oprogramowanie.txt", true);
                          using (ZapisujeDoPliku)
                          {
                              NoweOprogramowanie.DodajDoListy(txtTytulOprogramowanie.Text, txtAutorOprogramowanie.Text, Convert.ToDouble(txtCenaOprogramowanie.Text), txtDataZakupuOprogramowanie.Text
                              , txtDataPowstaniaOprogramowanie.Text, txtLicencjaOprogramowanie.Text);
                              ZapisujeDoPliku.WriteLine(DateTime.Today.Year.ToString() + ":" + DateTime.Today.Month.ToString()
                                              + ":" + DateTime.Today.DayOfWeek.ToString() + ",  " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "\n");
                              ZapisujeDoPliku.WriteLine(NoweOprogramowanie.ToString());
                              MessageBox.Show("Dodano");
                              ResetujeZawartosci();
                          }
                      }
                      else   // Zapisuje do plik txt wartosci z pol
                      {
                          TextWriter ZapisujeDoPliku = new StreamWriter("Oprogramowanie.txt", true);
                          using (ZapisujeDoPliku)
                          {
                              NoweOprogramowanie.DodajDoListy(txtTytulOprogramowanie.Text, txtAutorOprogramowanie.Text, Convert.ToDouble(txtCenaOprogramowanie.Text), txtDataZakupuOprogramowanie.Text
                             , txtDataPowstaniaOprogramowanie.Text, txtLicencjaOprogramowanie.Text);
                              ZapisujeDoPliku.WriteLine(DateTime.Today.Year.ToString() + ":" + DateTime.Today.Month.ToString()
                                                + ":" + DateTime.Today.DayOfWeek.ToString() + ",  " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "\n");
                              ZapisujeDoPliku.WriteLine(NoweOprogramowanie.ToString());
                              MessageBox.Show("Dodano");
                              ResetujeZawartosci();
                          }
                      }

                  }
                  catch (Exception k)
                  {
                      MessageBox.Show(k.Message);
                  }
              }
        }

        private void WyswietlOprogramowanie(object sender, RoutedEventArgs e)  // Funkcja zajmuje sie odkrywaniem i ukrywaniem okienek
        {
            Tlo.Background = Brushes.White;
            RamkaPismiennicze.Visibility = Visibility.Hidden;
            RamkaGraficznoPis.Visibility = Visibility.Hidden;
            RamkaOprogramowanie.Visibility = Visibility.Visible;
            RamkaAudiowizualne.Visibility = Visibility.Hidden;
            RamkaWyszukiwania.Visibility = Visibility.Hidden;
           
        }

        private void WyswietlAudiowizualne(object sender, RoutedEventArgs e) // Funkcja zajmuje sie odkrywaniem i ukrywaniem okienek
        {
            Tlo.Background = Brushes.White;
            RamkaPismiennicze.Visibility = Visibility.Hidden;
            RamkaGraficznoPis.Visibility = Visibility.Hidden;
            RamkaOprogramowanie.Visibility = Visibility.Hidden;
            RamkaAudiowizualne.Visibility = Visibility.Visible;
            RamkaWyszukiwania.Visibility = Visibility.Hidden;
        }

        private void DodajAudio(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtTytulAudio.Text) || string.IsNullOrEmpty(txtAutorAudio.Text) || string.IsNullOrEmpty(txtCenaAudio.Text)
              || string.IsNullOrEmpty(txtDataZakupuAudio.Text) || string.IsNullOrEmpty(txtDataPowstaniaAudio.Text) || string.IsNullOrEmpty(txtLicencjaAudio.Text))
            {
                MessageBox.Show("Powinienes wypelnic wszystkie pola");  // Sprawdza czy wszystkie potrzebne pola sa wypelnione
            }
            else
            {
                try
                {
                    if (!File.Exists("Audiowizualne.txt")) // Zapisuje wpisane wartosci do pliku tekstowego
                    {
                        TextWriter ZapisujeDoPliku = new StreamWriter("Audiowizualne.txt", true);
                        using (ZapisujeDoPliku)
                        {
                            NoweAudiowizualne.DodajDoListy(txtTytulAudio.Text, txtAutorAudio.Text, Convert.ToDouble(txtCenaAudio.Text), txtDataZakupuAudio.Text
                            , txtDataPowstaniaAudio.Text, txtLicencjaAudio.Text);
                            ZapisujeDoPliku.WriteLine(DateTime.Today.Year.ToString() + ":" + DateTime.Today.Month.ToString()
                                            + ":" + DateTime.Today.DayOfWeek.ToString() + ",  " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "\n");
                            ZapisujeDoPliku.WriteLine(NoweAudiowizualne.ToString());
                            MessageBox.Show("Dodano");
                            ResetujeZawartosci();
                        }
                    }
                    else
                    {
                        TextWriter ZapisujeDoPliku = new StreamWriter("Audiowizualne.txt", true);  // Zapisuje wpisane wartosci do pliku tekstowego
                        using (ZapisujeDoPliku)
                        {
                            NoweAudiowizualne.DodajDoListy(txtTytulAudio.Text, txtAutorAudio.Text, Convert.ToDouble(txtCenaAudio.Text), txtDataZakupuAudio.Text
                            , txtDataPowstaniaAudio.Text, txtLicencjaAudio.Text);
                            ZapisujeDoPliku.WriteLine(DateTime.Today.Year.ToString() + ":" + DateTime.Today.Month.ToString()
                                            + ":" + DateTime.Today.DayOfWeek.ToString() + ",  " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "\n");
                            ZapisujeDoPliku.WriteLine(NoweAudiowizualne.ToString());
                            MessageBox.Show("Dodano");
                            ResetujeZawartosci();
                        }
                    }

                }
                catch (Exception k)
                {
                    MessageBox.Show(k.Message);
                }
            }
        }

        private void ZmienPlansze(object sender, RoutedEventArgs e) // Funkcja zajmuje sie odkrywaniem i ukrywaniem okienek
        {
            RamkaPismiennicze.Visibility = Visibility.Hidden;
            RamkaGraficznoPis.Visibility = Visibility.Hidden;
            RamkaOprogramowanie.Visibility = Visibility.Hidden;
            RamkaAudiowizualne.Visibility = Visibility.Hidden;
            PanelWyboru.Visibility = Visibility.Hidden;
            RamkaWyswietlaniaZbiorow.Visibility = Visibility.Visible;
            PrzyciskDoUsuwania.Visibility = Visibility.Visible;
            RamkaWyszukiwania.Visibility = Visibility.Hidden;
        }

        private void PowrotDoPlanszyDodawania(object sender, RoutedEventArgs e) // Funkcja zajmuje sie odkrywaniem i ukrywaniem okienek
        {
            PanelWyboru.Visibility = Visibility.Visible;
            RamkaWyswietlaniaZbiorow.Visibility = Visibility.Hidden;
            PrzyciskDoUsuwania.Visibility = Visibility.Hidden;
            RamkaWyszukiwania.Visibility = Visibility.Hidden;
        }

        private void WyswietlZbioryPismiennicze(object sender, RoutedEventArgs e)  // Czysci zawartosci w ListBoxie , a nastepnie dodaje odswiezone
        {
            NowePismiennicze.Slad = "Pismiennicze.txt";  
            Zbiory.Items.Clear();
            if (Zbiory.Items.Count <= 0) 
            NowePismiennicze.WyswietlZbior(Zbiory,"Pismiennicze.txt");
           
        }

        private void WyswietlZbioryGraficznoPismiennicze(object sender, RoutedEventArgs e) // Czysci zawartosci w ListBoxie , a nastepnie dodaje odswiezone
        {
            NowePismiennicze.Slad = "GrafPis.txt";  
            Zbiory.Items.Clear();
            if (Zbiory.Items.Count <= 0)
                NowePismiennicze.WyswietlZbior(Zbiory, "GrafPis.txt");
           
        }

        private void WyswietlZbioryOprogramowanie(object sender, RoutedEventArgs e) // Czysci zawartosci w ListBoxie , a nastepnie dodaje odswiezone
        {
            NowePismiennicze.Slad = "Oprogramowanie.txt";  
            Zbiory.Items.Clear();
            if (Zbiory.Items.Count <= 0)
                NowePismiennicze.WyswietlZbior(Zbiory, "Oprogramowanie.txt");
           
        }

        private void WyswietlZbioryAudiowizualne(object sender, RoutedEventArgs e) // Czysci zawartosci w ListBoxie , a nastepnie dodaje odswiezone
        {
            NowePismiennicze.Slad = "Audiowizualne.txt";   
            Zbiory.Items.Clear();
            if (Zbiory.Items.Count <= 0)
                NowePismiennicze.WyswietlZbior(Zbiory, "Audiowizualne.txt");
            
        }

        private void UsunWybrany(object sender, RoutedEventArgs e) // Usuwa z listy zaznaczony wiersz, gdy nic nie zaznaczymy wyrzuca komunikat
        {
             int ZaznaczonyWiersz = Zbiory.SelectedIndex;
             if(ZaznaczonyWiersz!=-1)
             {
                 string Wartosc = (string)Zbiory.SelectedValue;
                 NowePismiennicze.UsunWybranyElementZbioru(Wartosc, Zbiory, NowePismiennicze.Slad, ZaznaczonyWiersz);
             }
             else
             {
                 MessageBox.Show("Nic nie zostało zaznaczone");

             }
        }

        private void Znajdz(object sender, RoutedEventArgs e) // Operacja na widocznosci
        {
            Tlo.Background = Brushes.White;
            PanelWyboru.Visibility = Visibility.Visible;
            RamkaWyswietlaniaZbiorow.Visibility = Visibility.Hidden;
            PrzyciskDoUsuwania.Visibility = Visibility.Hidden;
            RamkaPismiennicze.Visibility = Visibility.Hidden;
            RamkaGraficznoPis.Visibility = Visibility.Hidden;
            RamkaOprogramowanie.Visibility = Visibility.Hidden;
            RamkaAudiowizualne.Visibility = Visibility.Hidden;
            RamkaWyszukiwania.Visibility = Visibility.Visible;
        }

        private void PotwierdzParametry(object sender, RoutedEventArgs e)
        {
          
            if (string.IsNullOrEmpty(txtZnajdzTytul.Text) || string.IsNullOrEmpty(txtZnajdzRodzaj.Text) || string.IsNullOrEmpty(txtZnajdzDateZakupu.Text) ||
            string.IsNullOrEmpty(txtZnajdzRegal.Text) || string.IsNullOrEmpty(cmbZnajdzKategorie.Text))
            {
                MessageBox.Show("Powinienes wypełnić wszystkie parametry");
            }   
            else
            {
                 
                if(cmbZnajdzKategorie.SelectedIndex==0)
                {
                    if(File.Exists("Pismiennicze.txt"))
                    {
                        Zawartosc.Text = NowePismiennicze.Wyszukuje("Pismiennicze.txt", txtZnajdzTytul.Text, txtZnajdzRodzaj.Text, txtZnajdzDateZakupu.Text, txtZnajdzRegal.Text,Zawartosc);
                    }
                    else
                    {
                        MessageBox.Show("Nie ma żadnego elementu w tej kategori");
                    }
                }
                else if (cmbZnajdzKategorie.SelectedIndex == 1)
                {
                    if (File.Exists("GrafPis.txt"))
                    {
                        Zawartosc.Text = NowePismiennicze.Wyszukuje("GrafPis.txt", txtZnajdzTytul.Text, txtZnajdzRodzaj.Text, txtZnajdzDateZakupu.Text, txtZnajdzRegal.Text,Zawartosc);
                    }
                    else
                    {
                        MessageBox.Show("Nie ma żadnego elementu w tej kategori");
                    }
                }
                else if (cmbZnajdzKategorie.SelectedIndex == 2)
                {
                    if (File.Exists("Oprogramowanie.txt"))
                    {
                        Zawartosc.Text = NowePismiennicze.Wyszukuje("Oprogramowanie.txt", txtZnajdzTytul.Text, txtZnajdzRodzaj.Text, txtZnajdzDateZakupu.Text, txtZnajdzRegal.Text,Zawartosc);
                    }
                    else
                    {
                        MessageBox.Show("Nie ma żadnego elementu w tej kategori");
                    }
                }
                else if (cmbZnajdzKategorie.SelectedIndex == 3)
                {
                    if (File.Exists("Audiowizualne.txt"))
                    {
                        Zawartosc.Text = NowePismiennicze.Wyszukuje("Audiowizualne.txt", txtZnajdzTytul.Text, txtZnajdzRodzaj.Text, txtZnajdzDateZakupu.Text, txtZnajdzRegal.Text, Zawartosc);
                    }
                    else
                    {
                        MessageBox.Show("Nie ma żadnego elementu w tej kategori");
                    }
                }
                
            }
            
          
        }

        private void UruchomZakladki(object sender, RoutedEventArgs e)
        {
            Zakladki Zakladka = new Zakladki();
            Zakladka.Show();
            this.Close();
        }

       

        }
    }

