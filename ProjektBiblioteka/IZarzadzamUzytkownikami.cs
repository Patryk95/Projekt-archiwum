
namespace ProjektArchiwium
{
    interface IZarzadzamUzytkownikami // Podpiety do uzytkownikow
    {
        bool SprawdzamPoziomHasla(string Haslo);
        bool SprawdzamCzyUzytkownikIstnieje(string Login,string Haslo);
    }
}
