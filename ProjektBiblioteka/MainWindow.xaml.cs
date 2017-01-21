using System.Windows;
using System.IO;
namespace ProjektArchiwum
{
    /// <summary>
    /// W tym oknie mozliwe jest logowanie, a takze zakladanie konta. Nie ma mozliwosci zalozenia konta o takim samym loginie dwa razy.
    /// Okienko operuje na Visibility. 
    /// </summary>
    public partial class MainWindow : Window
    {
        Uzytkownik NowyUzytkownik = new Uzytkownik();  // Obiekty umozliwiaja uzywanie funkcji w klasach
    
       
        public MainWindow()
        {
            InitializeComponent();
             RamkaLogowania.Visibility = Visibility.Visible;   // Operacje na widocznosci kontrolek
             RamkaRejestracji.Visibility = Visibility.Visible;
             RamkaRejestracjiDane.Visibility = Visibility.Hidden;
        }
        private void Wyjscie(object sender, RoutedEventArgs e)
        { 
            Application.Current.Shutdown();   // Zamkniecie aplikacji
        }
        private void Logowanie(string Login, string Haslo)
        {
            StreamReader Odczyt = new StreamReader("Uzytkownicy.txt");
            int IloscNowychLini = 0;
            string Napis;
            using (Odczyt)               // Odczytywanie zawartosci pliku tekstowego z loginami i haslami
            {
                while ((Napis = Odczyt.ReadLine()) != null)
                {
                    IloscNowychLini++;
                }
                Odczyt.Close();
            }
            StreamReader OdczytZawartosci = new StreamReader("Uzytkownicy.txt"); // Funkcje te pozwalaja na zalogowanie sie
            string[] Tablica = new string[IloscNowychLini];
            for (int i = 0; i < IloscNowychLini; i++)
            {
                Tablica[i] = OdczytZawartosci.ReadLine();
                if (Tablica[i] == Login + Haslo)
                {
                    OknoDodawania NoweOkno = new OknoDodawania();
                    NoweOkno.Show();
                    this.Close();
                    break;
                }
            }
            OdczytZawartosci.Close();
        }
        private void Zaloguj(object sender, RoutedEventArgs e)  // Funkcja sprawdza na poczatku czy pola nie sa puste nastepnie uzyskuje wykorzystuje metode Logowanie
        {
            if(string.IsNullOrEmpty(txtLogin.Text) || string.IsNullOrEmpty(txtHaslo.Password))
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola");
            }
            else
            {
                string Powrot = Directory.GetCurrentDirectory();
                if(!Directory.Exists("Uzytkownicy"))
                {
                    MessageBox.Show("Nie ma jeszcze żadnego użytkownika");
                }
                else
                {
                    Directory.SetCurrentDirectory("Uzytkownicy");
                    if (!File.Exists("Uzytkownicy.txt"))
                    {
                        MessageBox.Show("Nie ma jeszcze żadnego użytkownika");
                    }
                    else
                    {
                       Logowanie(txtLogin.Text, txtHaslo.Password);
                    }
                    Directory.SetCurrentDirectory(Powrot);
                }
             
            }
          
        }

        private void NoweKonto(object sender, RoutedEventArgs e) // Operacje na widocznosci kontrolek, pokazuje kontrolki od rejestracji
        {
            RamkaLogowania.Visibility = Visibility.Hidden;
            RamkaRejestracji.Visibility = Visibility.Hidden;
            RamkaRejestracjiDane.Visibility = Visibility.Visible;
        }

        private void DodajUzytkownika(object sender, RoutedEventArgs e)  // Dodajemy nowego uzytkownika
        {
             if(string.IsNullOrEmpty(txtLoginRejestracja.Text) || string.IsNullOrEmpty(txtHasloRejestracja.Password))
             {
                 MessageBox.Show("Powinieneś uzupełnić wszystkie pola");  // Sprawdza czy pola nie sa puste
             }
             else if(NowyUzytkownik.SprawdzamPoziomHasla(txtHasloRejestracja.Password)==false)  // Sprawdza czy haslo jest odpowiedniej dlugosci
             {
                 MessageBox.Show("Twoje hasło jest mało bezpieczne.Powinno zawierać conajmniej 9 znaków");
             }
             else
             {
                 string Powrot = Directory.GetCurrentDirectory(); 
                 if(!Directory.Exists("Uzytkownicy"))
                 {
                     Directory.CreateDirectory("Uzytkownicy"); 
                 }
                 Directory.SetCurrentDirectory("Uzytkownicy");
                 if(!File.Exists("Uzytkownicy.txt"))
                 {
                     TextWriter Zapis = new StreamWriter("Uzytkownicy.txt", true);
                     NowyUzytkownik.DodajUzytkownika(txtLoginRejestracja.Text, txtHasloRejestracja.Password);
                     ZapisujeDoPliku(Zapis);
                     MessageBox.Show("Rejestracja pomyślna");
                     txtLoginRejestracja.Text = "";
                     txtHasloRejestracja.Password = "";
                 }
                 else
                 {
                     if(NowyUzytkownik.SprawdzamCzyUzytkownikIstnieje(txtLoginRejestracja.Text,txtHasloRejestracja.Password)==true)  // Sprawdza czy dany uzytkownik jest w pliku txt
                     {
                         MessageBox.Show("Taki użytkownik już istnieje!");
                     }
                     else
                     {
                         TextWriter Zapis = new StreamWriter("Uzytkownicy.txt", true);
                         NowyUzytkownik.DodajUzytkownika(txtLoginRejestracja.Text, txtHasloRejestracja.Password); // Ostatni etap rejestracji login i haslo sa zapisane do pliku txt
                         ZapisujeDoPliku(Zapis);
                         MessageBox.Show("Rejestracja pomyślna");
                         txtLoginRejestracja.Text = "";
                         txtHasloRejestracja.Password = "";
                     }
                    
                     
                 }
                 Directory.SetCurrentDirectory(Powrot);
             }
        }
        private void ZapisujeDoPliku(TextWriter Zapis)  // Funkcja zapisuje zawartosci do pliku txt
        {
            using(Zapis)
            {
                Zapis.WriteLine(NowyUzytkownik.ToString());
                Zapis.Close();
            }
        }

        private void Cofnij(object sender, RoutedEventArgs e)  // obsluga widocznosci kontrolek
        {
            RamkaLogowania.Visibility = Visibility.Visible;
            RamkaRejestracji.Visibility = Visibility.Visible;
            RamkaRejestracjiDane.Visibility = Visibility.Hidden;
        }
    }
}
