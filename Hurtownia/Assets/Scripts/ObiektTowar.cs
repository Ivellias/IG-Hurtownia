using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObiektTowar : MonoBehaviour
{

    private int ilosc;
    private Text iloscText;
    private Przedmiot trzymany;
    private GameObject zarzadzanie;
    public void SetZarzadzanie(GameObject x)
    {
        zarzadzanie = x;
    }

    public void ZmienIlosc(int a)
    {
        ilosc += a;
        if (ilosc < 0) ilosc = 0;
        if (ilosc > trzymany.CalkowitaIlosc) ilosc = trzymany.CalkowitaIlosc; //ewentualnie jakies powiadomienie ze nie ma wiecej w magazynie
        iloscText.text = ilosc.ToString();
    }

    public void Zarzadzaj()
    {
        zarzadzanie.GetComponent<ZarzadzanieTowarem1>().UstawDoWyswietlenia(trzymany);
        zarzadzanie.GetComponent<ZarzadzanieTowarem1>().WyswietlZarzadzaj();
    }

    public void UstawPrzedmiot(Przedmiot doUstawienia)
    {
        trzymany = doUstawienia;
        transform.GetChild(1).GetComponent<Text>().text = doUstawienia.Nazwa;
        transform.GetChild(4).GetComponent<Text>().text = "Cena: " + doUstawienia.Cena + "zl";
        transform.GetChild(2).GetComponent<Text>().text = "Ilość: " + doUstawienia.CalkowitaIlosc;
        Debug.Log(doUstawienia.Cena + " " + doUstawienia.CalkowitaIlosc);
    }

    // Use this for initialization
    void Start()
    {
        ilosc = 0;
        iloscText = transform.GetChild(0).GetComponent<Text>();
    }

}
