using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Koszyk : MonoBehaviour, IOnStart
{

    List<Przedmiot> przedmioty;
    public GameObject prefabPrzedmiotu;
    public GameObject Cena;

    public void Zamow()
    {
        //DOPIERO JAK BEDA ZAMOWIENIA
        Zamowienie zamowienie = new Zamowienie();
        zamowienie.CalkowitaKwotaZakupu = OverSceneHandler.ObliczLacznaCene();
        zamowienie.ListaPrzedmiotow = OverSceneHandler.koszyk;
        zamowienie.IdUzytkownika = OverSceneHandler.aktualnieZalogowanyUzytkownik.ID;
        zamowienie.IloscZakupionychPrzedmiotow = OverSceneHandler.koszyk.Count;
        OverSceneHandler.koszyk = new List<Przedmiot>();
        zamowienie.DataZakupu = System.DateTime.Now.ToString("M/d/yyyy");
        
        PolaczenieBazy.DodajNoweZamowienie(zamowienie);
        RysujKoszyk();

    }

    public void UsunPrzedmiot(int id)
    {
        Przedmiot tmp = null;
        foreach(Przedmiot przed in OverSceneHandler.koszyk)
        {
            if (przed.ID == id) tmp = przed;
        }
        if(tmp!= null) OverSceneHandler.koszyk.Remove(tmp);
        UaktualnijCene();
        RysujKoszyk();
    }

    public void UaktualnijCene()
    {
        float cena = OverSceneHandler.ObliczLacznaCene();
        Debug.Log("aktualizacja ceny" + OverSceneHandler.koszyk.Count + " cena:" + cena);
        Cena.GetComponent<Text>().text = "Cena: " + cena.ToString()+"zł";
    }

    public float doStartThingsAndReturnHeightOfThisElement()
    {
        RysujKoszyk();
        float wysokosc = 164f;
        if (przedmioty != null) wysokosc += (przedmioty.Count) * 220f;
        return wysokosc;
    }

    private void UsunWyswietlanie()
    {
        Debug.Log(transform.GetChild(0).transform.childCount);
        foreach (Transform child in transform.GetChild(0).transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void RysujKoszyk()
    {
        UsunWyswietlanie();
        przedmioty = OverSceneHandler.koszyk;

        if (OverSceneHandler.koszyk.Count == 0)
        {
            Debug.Log("koszyk pusty");
            transform.GetChild(1).gameObject.GetComponent<Text>().text = "Twój koszyk jest pusty!";
            Cena.GetComponent<Text>().text = "";
            transform.GetChild(3).gameObject.GetComponent<Image>().enabled = false;
            transform.GetChild(3).gameObject.transform.GetChild(0).GetComponent<Text>().enabled = false;
        }
        else
        {
            transform.GetChild(1).gameObject.GetComponent<Text>().text = "Twój koszyk:";
            Debug.Log("count: " + przedmioty.Count);
            int i = 0;
            float cena = 0f;
            foreach (Przedmiot przedmiot in przedmioty)
            {
                cena += przedmiot.TymczasowaIlosc * przedmiot.Cena;
                GameObject tmp = Instantiate(prefabPrzedmiotu, gameObject.transform.GetChild(0).transform);

                tmp.GetComponent<ObiektWKoszyku>().UstawPrzedmiot(przedmiot);
                tmp.GetComponent<ObiektWKoszyku>().parent = this.gameObject;

                tmp.GetComponent<RectTransform>().anchoredPosition = new Vector2(62f, -410 - (i * 220f));
                i++;
            }
            Cena.GetComponent<Text>().text = "Cena: " + cena.ToString()+"zł";
            transform.GetChild(3).gameObject.GetComponent<Image>().enabled = true;
            transform.GetChild(3).gameObject.transform.GetChild(0).GetComponent<Text>().enabled = true;

        }

    }

}
