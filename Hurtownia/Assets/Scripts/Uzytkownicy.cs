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
        ZamknijSzczegoly();

        uzytkownicy = PolaczenieBazy.ZwrocListeWszystkichUzytkownikow();

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
                tmp.GetComponent<ObiektUzytkownik>().SetPoleSzczegoly(this.gameObject);

                tmp.GetComponent<RectTransform>().anchoredPosition = new Vector2(62f, -268f - (i * 105f));
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
        
        foreach (Transform child in transform.GetChild(3).transform)
        {
            child.gameObject.SetActive(false);
        }
        transform.GetChild(3).gameObject.SetActive(false);
    }

    public void WyswietlSzczegoly()
    {
        
        foreach (Transform child in transform.GetChild(3).transform)
        {
            child.gameObject.SetActive(true);
        }
        transform.GetChild(3).gameObject.SetActive(true);

        if(doWyswietlenia.PoziomDostepu > 0)
        {
            transform.GetChild(3).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Degrad";
            transform.GetChild(3).transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = "Awansuj";
        }

        if(doWyswietlenia.PoziomDostepu == 3)
        {
            transform.GetChild(3).transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Button>().enabled = false;
            transform.GetChild(3).transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Image>().enabled = false;
            transform.GetChild(3).transform.GetChild(1).transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().enabled = false;
        }
        else
        {
            transform.GetChild(3).transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Button>().enabled = true;
            transform.GetChild(3).transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Image>().enabled = true;
            transform.GetChild(3).transform.GetChild(1).transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().enabled = true;
        }

        transform.GetChild(3).transform.GetChild(2).GetComponent<Text>().text = doWyswietlenia.Login + " (" + doWyswietlenia.NazwaFirmy + ")";
        transform.GetChild(3).transform.GetChild(3).GetComponent<Text>().text = "Adres: " + doWyswietlenia.Adres;
        transform.GetChild(3).transform.GetChild(4).GetComponent<Text>().text = "E-mail: " + doWyswietlenia.Mail;
        transform.GetChild(3).transform.GetChild(5).GetComponent<Text>().text = "NIP: " + doWyswietlenia.NIP;
        transform.GetChild(3).transform.GetChild(6).GetComponent<Text>().text = "REGON: " + doWyswietlenia.REGON;
        transform.GetChild(3).transform.GetChild(7).GetComponent<Text>().text = "KRS: " + doWyswietlenia.KRS;
    }


    public void Odrzuc()
    {
        int tmp = 0;

        PolaczenieBazy.ZmienDaneUzytkownika(doWyswietlenia.ID, doWyswietlenia.Login, doWyswietlenia.Haslo, doWyswietlenia.NazwaFirmy, doWyswietlenia.Adres
            , doWyswietlenia.Imie, doWyswietlenia.Nazwisko, doWyswietlenia.Mail, doWyswietlenia.NIP, doWyswietlenia.REGON, doWyswietlenia.KRS, tmp);

        ZamknijSzczegoly();
        GameObject.FindGameObjectWithTag("Srodek").GetComponent<ImplementacjaSrodka>().Uzytkownicy();
    }

    public void Akceptuj()
    {
        int tmp = doWyswietlenia.PoziomDostepu + 1;
        if (tmp > 3) tmp = 3;

        PolaczenieBazy.ZmienDaneUzytkownika(doWyswietlenia.ID, doWyswietlenia.Login, doWyswietlenia.Haslo, doWyswietlenia.NazwaFirmy, doWyswietlenia.Adres
            , doWyswietlenia.Imie, doWyswietlenia.Nazwisko, doWyswietlenia.Mail, doWyswietlenia.NIP, doWyswietlenia.REGON, doWyswietlenia.KRS, tmp);

        ZamknijSzczegoly();
        GameObject.FindGameObjectWithTag("Srodek").GetComponent<ImplementacjaSrodka>().Uzytkownicy();
    }

    public void StworzUzytkownika()
    {
        GameObject.FindGameObjectWithTag("Srodek").GetComponent<ImplementacjaSrodka>().TworzenieUzytkownika();
    }

}
