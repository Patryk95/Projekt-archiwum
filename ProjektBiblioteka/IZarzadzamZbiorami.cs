using System.Windows.Controls;

namespace ProjektArchiwum
{
    interface IZarzadzamZbiorami // Interfejs podpiety do Pismiennicze
    {
        int ZliczamIlePrzejscDoNowejLini(string NazwaPliku);
        void WyswietlZbior(ListBox Lista, string NazwaPliku);
    }
}
