﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZarzadzanieTowarem1 : MonoBehaviour, IOnStart
{

    private string doWyszukania;
    List<Przedmiot> przedmioty;
    public GameObject prefabTowaru;
    private Przedmiot doWyswietlenia;

    public float doStartThingsAndReturnHeightOfThisElement()
    {
        Zamknijzarzadzaj();
        przedmioty = PolaczenieBazy.ZwrocWszystkiePrzedmiotyPoNazwie(doWyszukania);

        if (przedmioty == null)
        {
            transform.GetChild(1).gameObject.GetComponent<Text>().text = "Nic nie znaleziono!";
        }
        else
        {
            transform.GetChild(1).gameObject.GetComponent<Text>().text = "Wyszukano: " + doWyszukania;
            if (doWyszukania == "") transform.GetChild(1).gameObject.GetComponent<Text>().text = "Wyszukano wszystkie towary.";
            Debug.Log("count: " + przedmioty.Count);
            int i = 0;
            foreach (Przedmiot przedmiot in przedmioty)
            {
                GameObject tmp = Instantiate(prefabTowaru, gameObject.transform.GetChild(0).transform);
                tmp.GetComponent<ObiektTowar>().SetZarzadzanie(this.gameObject);
                tmp.GetComponent<ObiektTowar>().UstawPrzedmiot(przedmiot);

                tmp.GetComponent<RectTransform>().anchoredPosition = new Vector2(62f, -356 - (i * 220f));
                i++;
            }
        }

        float wysokosc = 100f;
        if (przedmioty != null) wysokosc += (przedmioty.Count) * 220f;
        return wysokosc;
    }

    public void UstawDoWyswietlenia(Przedmiot x)
    {
        doWyswietlenia = x;
    }

    public void WyswietlZarzadzaj()
    {
        foreach (Transform child in transform.GetChild(3).transform)
        {
            child.gameObject.SetActive(true);
        }
        transform.GetChild(3).gameObject.SetActive(true);


        transform.GetChild(3).transform.GetChild(0).transform.GetChild(0).GetComponent<InputField>().text = doWyswietlenia.Nazwa;
        transform.GetChild(3).transform.GetChild(1).transform.GetChild(0).GetComponent<InputField>().text = doWyswietlenia.CalkowitaIlosc.ToString();
        transform.GetChild(3).transform.GetChild(2).transform.GetChild(0).GetComponent<InputField>().text = doWyswietlenia.Cena.ToString();

        GameObject.FindGameObjectWithTag("Scroll").GetComponent<Scrollbar>().value = 1;
    }

    public void Zamknijzarzadzaj()
    {
        foreach (Transform child in transform.GetChild(3).transform)
        {
            child.gameObject.SetActive(false);
        }
        transform.GetChild(3).gameObject.SetActive(false);
    }


    public void UsunTowar()
    {
        PolaczenieBazy.UsunPrzedmiot(doWyswietlenia.ID);
        GameObject.FindGameObjectWithTag("Srodek").GetComponent<ImplementacjaSrodka>().ZarzadzanieTowarem();
    }

    public void Zatwierdz()
    {
        string nazwa = transform.GetChild(3).transform.GetChild(0).transform.GetChild(0).GetComponent<InputField>().text;
        float cena = float.Parse(transform.GetChild(3).transform.GetChild(2).transform.GetChild(0).GetComponent<InputField>().text);
        int ilosc = int.Parse(transform.GetChild(3).transform.GetChild(1).transform.GetChild(0).GetComponent<InputField>().text);
        PolaczenieBazy.ZmienWartosciPrzedmiotu(doWyswietlenia.ID, nazwa, cena, ilosc, doWyswietlenia.Opis);
        GameObject.FindGameObjectWithTag("Srodek").GetComponent<ImplementacjaSrodka>().ZarzadzanieTowarem();
    }


    public void DodajTowar()
    {
        GameObject.FindGameObjectWithTag("Srodek").GetComponent<ImplementacjaSrodka>().DodajTowar();
    }

    public void ustawCoWyszukac(string a)
    {
        doWyszukania = a;
    }

}
