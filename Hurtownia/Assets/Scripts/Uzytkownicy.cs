using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uzytkownicy : MonoBehaviour, IOnStart
{
    List<Uzytkownik> uzytkownicy;
    public GameObject prefabUzytkownika;
    private Uzytkownik doWyswietlenia;

    public float doStartThingsAndReturnHeightOfThisElement()
    {

        //baza = new PolaczenieBazy();
        //uzytkownicy = baza ZWROC WSZYSTKICH UZYTKOWNIKOW

        if (uzytkownicy == null)
        {

        }
        else
        {
            Debug.Log("count: " + uzytkownicy.Count);
            int i = 0;
            foreach (Uzytkownik uzytkownik in uzytkownicy)
            {
                GameObject tmp = Instantiate(prefabUzytkownika, gameObject.transform.GetChild(0).transform);

                tmp.GetComponent<ObiektUzytkownik>().UstawUzytkownika(uzytkownik);
                tmp.GetComponent<ObiektUzytkownik>().SetPoleSzczegoly(this);

                tmp.GetComponent<RectTransform>().anchoredPosition = new Vector2(62f, -268f - (i * 110f));
                i++;
            }
        }

        float wysokosc = 100f;
        if (uzytkownicy != null) wysokosc += (uzytkownicy.Count) * 110f;
        return wysokosc;
    }


    public void UstawDoWyswietlenia(Uzytkownik x)
    {
        doWyswietlenia = x;
    }

    public void ZamknijSzczegoly()
    {
        foreach (Transform child in transform.GetChild(1).transform)
        {
            child.gameObject.SetActiveRecursively(false);
        }
    }

    public void WyswietlSzczegoly()
    {





    }


    public void Odrzuc()
    {

    }

    public void Akceptuj()
    {

    }

    public void StworzUzytkownika()
    {

    }

}
