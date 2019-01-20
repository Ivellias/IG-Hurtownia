using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZamowieniaPracownika : MonoBehaviour, IOnStart
{
    List<Zamowienie> zamowienia;
    public GameObject prefabZamowienia;

    private Zamowienie doWyswietlenia;
    public void UstawDoWyswietlenia(Zamowienie x)
    {
        doWyswietlenia = x;
    }

    public float doStartThingsAndReturnHeightOfThisElement()
    {
        ZamknijSzczegoly();
        zamowienia = PolaczenieBazy.ZwrocWszystkieZamowieniaPoRealizacji();
        Debug.Log(zamowienia.Count);

        if (zamowienia == null)
        {
            transform.GetChild(1).gameObject.GetComponent<Text>().text = "Aktualnie nie ma zamówień.";
        }
        else
        {
            transform.GetChild(1).gameObject.GetComponent<Text>().text = "Zamówienia:";
            Debug.Log("count: " + zamowienia.Count);
            int i = 0;
            foreach (Zamowienie zamowienie in zamowienia)
            {
                GameObject tmp = Instantiate(prefabZamowienia, gameObject.transform.GetChild(0).transform);

                tmp.GetComponent<ObiektZamowieniaPracownika>().UstawZamowienie(zamowienie);
                tmp.GetComponent<ObiektZamowieniaPracownika>().SetParent(this.gameObject);

                tmp.GetComponent<RectTransform>().anchoredPosition = new Vector2(62f, -356 - (i * 220f));
                i++;
            }
        }

        float wysokosc = 100f;
        if (zamowienia != null) wysokosc += (zamowienia.Count) * 220f;
        return wysokosc;
    }

    public void ZamknijSzczegoly()
    {
        foreach (Transform child in transform.GetChild(2).transform)
        {
            child.gameObject.SetActive(false);
        }
        transform.GetChild(2).gameObject.SetActive(false);
    }

    public void WyswietlSzczegoly()
    {
        foreach (Transform child in transform.GetChild(2).transform)
        {
            child.gameObject.SetActive(true);
        }
        transform.GetChild(2).gameObject.SetActive(true);

        transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = doWyswietlenia.ID + " " + doWyswietlenia.DataZakupu + " " + doWyswietlenia.IdUzytkownika;
        transform.GetChild(2).transform.GetChild(5).GetComponent<Button>().enabled = true; ;
        transform.GetChild(2).transform.GetChild(5).GetComponent<Image>().enabled = true; ;
        transform.GetChild(2).transform.GetChild(5).GetChild(0).GetComponent<Text>().enabled = true;
        switch (doWyswietlenia.PostepZamowienia)
        {
            case 0:
                {
                    transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = "Status: W trakcie realizacji";
                    break;
                }
            case 1:
                {
                    transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = "Status: Do odbioru";
                    break;
                }
            case 2:
                {
                    transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = "Status: Zrealizowany";
                    transform.GetChild(2).transform.GetChild(5).GetComponent<Button>().enabled = false;
                    transform.GetChild(2).transform.GetChild(5).GetComponent<Image>().enabled = false;
                    transform.GetChild(2).transform.GetChild(5).GetChild(0).GetComponent<Text>().enabled = false;
                    break;
                }
            default:
                {
                    transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = "Status: Nieznany";
                    break;
                }
        }

        transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "Cena: " + doWyswietlenia.CalkowitaKwotaZakupu.ToString();
        transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().text = "Artykuły: ";
        Debug.Log(doWyswietlenia.ListaPrzedmiotow.Count);
        foreach (Przedmiot przedmiot in doWyswietlenia.ListaPrzedmiotow)
        {
            transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().text = transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().text + przedmiot.Nazwa + " (" + przedmiot.TymczasowaIlosc + "), ";
        }
        GameObject.FindGameObjectWithTag("Scroll").GetComponent<Scrollbar>().value = 1;

    }

    public void ZmienStatus()
    {
        int tmp = doWyswietlenia.PostepZamowienia + 1;
        if (tmp > 2) tmp = 2;
        PolaczenieBazy.ZmienStatusZamowieniaPlusJeden(doWyswietlenia.ID, tmp);


        GameObject.FindGameObjectWithTag("Srodek").GetComponent<ImplementacjaSrodka>().ZamowieniaPracownika();//rysowanie na nowo
    }




}
