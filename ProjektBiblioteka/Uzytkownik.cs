using ProjektArchiwium;
using System.Collections.Generic;
using System.IO;

namespace ProjektArchiwum
{
    class Uzytkownik:IZarzadzamUzytkownikami // Dziedziczy metody z interfejsu umozliwiajace sprawdzenie czy dany uzytkownik istnieje, a takze sprawdzenie czy Haslo nie zawiera znaku pustego null
    {
        private string Login;
        private string Haslo;
        private List<Uzytkownik> ListaUzytkownikow;                              
        public Uzytkownik() { ListaUzytkownikow = new List<Uzytkownik>(); } // Deklaracja listy uzytkownikow i jej jednoczesna inicjalizacja
        public Uzytkownik(string Login, string Haslo)
        {
            this.Login = Login;
            this.Haslo = Haslo;
        }
        public void DodajUzytkownika(string Login,string Haslo)  // Funcja dodaje uzytkownika do listy
        {
            ListaUzytkownikow.Add(new Uzytkownik(Login, Haslo));
        }
        public bool SprawdzamPoziomHasla(string Haslo) // Funkcja z interfejsu, sprawdza czy haslo jest odpowiedniej dlugosci
        {
            if(Haslo.Length>8)
            {
                return true;
            }
            else
                return false;
        }
        public override string ToString()    // Nadpisywanie metody ToString(), wypisuje wszystkich uzytkownikow 
        {
            string Napis = "";
            if (ListaUzytkownikow.Count > 0)
            {
                foreach (var element in ListaUzytkownikow)
                {
                    Napis= element.Login + element.Haslo;
                }
                return Napis;
            }
            else
                return "";
        }
        public bool SprawdzamCzyUzytkownikIstnieje(string Login,string Haslo)  // Metody weryfikuje czy dany uzytkownik istnieje w pliku txt
        {
            StreamReader Odczyt = new StreamReader("Uzytkownicy.txt");
            string Napis=Odczyt.ReadToEnd();
            if (Napis.Contains(Login))
            {
                Odczyt.Close();
                Login = "";
                Haslo = "";
                return true;
            }
               
            else
            {
                Odczyt.Close();
                return false;
            }
            
        }
       

        
    }
}
