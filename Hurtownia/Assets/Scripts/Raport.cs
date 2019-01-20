using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raport : MonoBehaviour, IOnStart
{
    public float doStartThingsAndReturnHeightOfThisElement()
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector2(5f, 202f);
        int ilosc = 0;
        int artykuly = 0;
        float utarg = 0f;
        List<Zamowienie> listaZamowien = PolaczenieBazy.ZwrocWszystkieZamowieniaPoRealizacji();
        foreach(Zamowienie zamowienie in listaZamowien)
        {
            if(zamowienie.PostepZamowienia == 2)
            {
                ilosc++;
                artykuly += zamowienie.IloscZakupionychPrzedmiotow;
                utarg += zamowienie.CalkowitaKwotaZakupu;
            }
        }

        //ostatni meisiac - zapytanie sql nowe
        transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = "Całkowity utarg: " + utarg + " zł";
        transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = "Ilość zrealizowanych zamówień: " + ilosc;
        transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = "Ilość sprzedanych artykułów: " + artykuly;

        
        transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = "Całkowity utarg: " + utarg + " zł";
        transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = "Ilość zrealizowanych zamówień: " + ilosc;
        transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "Ilość sprzedanych artykułów: " + artykuly;



        return 400f;
    }

}
