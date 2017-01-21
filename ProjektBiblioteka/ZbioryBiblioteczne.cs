namespace ProjektArchiwum
{
    abstract class ZbioryBiblioteczne  // Klasa abstrakcyjna, dziedzicza z niej klasy(Pismiennicze,Oprogramowanie,Audiowizualne,GraficznoPismiennnicze) 
    {                                  // Umozliwia to unikniecia powtarzania sie tych samych pol w innych klasach.
        protected string Tytul,Autor,Rodzaj;
        protected double Cena;
        protected string DataZakupu, DataPowstania;
        protected int Regal;
        
    }
   
}
