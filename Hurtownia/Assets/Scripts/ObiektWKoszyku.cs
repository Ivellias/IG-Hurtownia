using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObiektWKoszyku : MonoBehaviour
{

    private int ilosc;
    private Text iloscText;
    private Przedmiot trzymany;
    public GameObject parent;

    public void ZmienIlosc(int a)
    {
        ilosc += a;
        if (ilosc < 0) ilosc = 0;
        if (ilosc > trzymany.CalkowitaIlosc) ilosc = trzymany.CalkowitaIlosc; //ewentualnie jakies powiadomienie ze nie ma wiecej w magazynie
        iloscText.text = ilosc.ToString();
        trzymany.TymczasowaIlosc = ilosc;
        transform.GetChild(6).GetComponent<Text>().text = "Cena: " + trzymany.Cena * trzymany.TymczasowaIlosc + "zł";
        OverSceneHandler.UaktualnijIlosc(trzymany.ID, trzymany.TymczasowaIlosc);
        parent.GetComponent<Koszyk>().UaktualnijCene();
    }

    public void UstawPrzedmiot(Przedmiot doUstawienia)
    {
        iloscText = transform.GetChild(0).GetComponent<Text>();
        trzymany = doUstawienia;
        transform.GetChild(2).GetComponent<Text>().text = doUstawienia.Nazwa;
        transform.GetChild(6).GetComponent<Text>().text = "Cena: " + doUstawienia.Cena*doUstawienia.TymczasowaIlosc + "zł";
        ilosc = trzymany.TymczasowaIlosc;
        iloscText.text = ilosc.ToString();
    }

    public Przedmiot ZwrocPrzedmiot()
    {
        return trzymany;
    }

    public void Usun()
    {
        parent.GetComponent<Koszyk>().UsunPrzedmiot(trzymany.ID);
    }


}
