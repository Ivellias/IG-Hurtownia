using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wyszukiwanie : MonoBehaviour, IOnStart {

    private string doWyszukania;
    private PolaczenieBazy baza;
    List<Przedmiot> przedmioty;
    public GameObject prefabPrzedmiotu;

    public float doStartThingsAndReturnHeightOfThisElement()
    {

        baza = new PolaczenieBazy();
        przedmioty = baza.ZwrocWszystkiePrzedmiotyPoNazwie(doWyszukania);

        if(przedmioty == null)
        {
            transform.GetChild(1).gameObject.GetComponent<Text>().text = "Nie znaleziono takiego przedmiotu!";
        }
        else
        {
            transform.GetChild(1).gameObject.GetComponent<Text>().text = "Wyszukano: " + doWyszukania;
            for(int i = 0; i < przedmioty.Count; i++)
            {
                GameObject tmp = Instantiate(prefabPrzedmiotu, gameObject.transform.GetChild(0).transform);

                //ustawienie wartosci dla danych przedmiotow


                tmp.GetComponent<RectTransform>().position = new Vector3(62f, (-356 - i * (220)), 0f);
            }
        }

        float wysokosc = 100f;
        wysokosc += (przedmioty.Count+1) * 220f; 
        return wysokosc;
    }

    public void ustawCoWyszukac(string a)
    {
        doWyszukania = a;
    }

}
