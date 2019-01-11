using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObiektWyszukaj : MonoBehaviour {

    private int ilosc;
    private Text iloscText;
    private Przedmiot trzymany;

    public void ZmienIlosc(int a)
    {
        ilosc += a;
        if (ilosc < 0) ilosc = 0;
        if (ilosc > trzymany.CalkowitaIlosc) ilosc = trzymany.CalkowitaIlosc; //ewentualnie jakies powiadomienie ze nie ma wiecej w magazynie
        iloscText.text = ilosc.ToString();
    }

    public void Zamow()
    {
        if (ilosc > 0) {
            trzymany.TymczasowaIlosc = ilosc;
            //nie sprawdza czy juz taki jest w koszyku

            OverSceneHandler.koszyk.Add(trzymany);
            GameObject.FindGameObjectWithTag("Koszyk").GetComponent<Animator>().Play("koszykShake");
        }

        ilosc = 0;
        iloscText.text = ilosc.ToString();
    }

    public void UstawPrzedmiot(Przedmiot doUstawienia)
    {
        trzymany = doUstawienia;
        transform.GetChild(2).GetComponent<Text>().text = doUstawienia.Nazwa;
        transform.GetChild(7).GetComponent<Text>().text = "Cena: " + doUstawienia.Cena + "zl";
    }

	// Use this for initialization
	void Start () {
        ilosc = 0;
        iloscText = transform.GetChild(0).GetComponent<Text>();
	}

}
