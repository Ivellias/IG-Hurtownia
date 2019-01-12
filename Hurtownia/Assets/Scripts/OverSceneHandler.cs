using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OverSceneHandler {

    public static string przyklad = "";

    public static Uzytkownik aktualnieZalogowanyUzytkownik;



    //Koszyk
    public static List<Przedmiot> koszyk = new List<Przedmiot>();

    public static void DodajDoKoszyka(Przedmiot przedmiot)
    {
        bool szukaj = true;
        foreach(Przedmiot kosz in koszyk)
        {
            if(kosz.ID == przedmiot.ID && szukaj)
            {
                szukaj = false;
                kosz.TymczasowaIlosc += przedmiot.TymczasowaIlosc;
                if (kosz.TymczasowaIlosc > kosz.CalkowitaIlosc) kosz.TymczasowaIlosc = kosz.CalkowitaIlosc;
            }
        }
        if (szukaj) koszyk.Add(przedmiot);
    }

    public static void UaktualnijIlosc(int id, int ilosc)
    {
        foreach(Przedmiot przedmiot in koszyk)
        {
            if (przedmiot.ID == id) przedmiot.TymczasowaIlosc = ilosc;
        }
    }

    public static float ObliczLacznaCene()
    {
        float suma = 0f;
        foreach(Przedmiot przed in koszyk)
        {
            suma += przed.TymczasowaIlosc * przed.Cena;
        }
        return suma;
    }

}
