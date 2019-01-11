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
            Debug.Log("count: "+przedmioty.Count);
            int i= 0;
            foreach(Przedmiot przedmiot in przedmioty)
            {
                GameObject tmp = Instantiate(prefabPrzedmiotu, gameObject.transform.GetChild(0).transform);

                tmp.GetComponent<ObiektWyszukaj>().UstawPrzedmiot(przedmiot);

                tmp.GetComponent<RectTransform>().anchoredPosition = new Vector2(62f, -356 - (i * 220f));
                i++;
            }
        }

        float wysokosc = 100f;
        if(przedmioty != null) wysokosc += (przedmioty.Count) * 220f;
        return wysokosc;
    }

    public void ustawCoWyszukac(string a)
    {
        doWyszukania = a;
    }

}
