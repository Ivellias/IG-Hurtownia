using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rejestracja : MonoBehaviour, IOnStart {

    private InputField nazwaUzytkownika;
    private InputField nazwaFirmy;
    private InputField adres;
    private InputField nip;
    private InputField regon;
    private InputField krs;
    private InputField email;
    private InputField haslo;
    private InputField powtorzHaslo;

    float IOnStart.doStartThingsAndReturnHeightOfThisElement()
    {
        return 400f;
    }

    public void Zarejestruj()
    {
        // nazwaUzytkownika.text;      // to jest co jest aktualnei w srodku


        //wykasowanie wszystkiego DODAC WARUNEK ZE TYLKO JAK SIE POWIEDZIE REJESTRACJA
        nazwaUzytkownika.text = "";
        nazwaFirmy.text = "";
        adres.text = "";
        nip.text = "";
        regon.text = "";
        krs.text = "";
        email.text = "";
        haslo.text = "";
        powtorzHaslo.text = "";

    }

	void Start () {
        nazwaUzytkownika = gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<InputField>();
        nazwaFirmy = gameObject.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<InputField>();
        adres = gameObject.transform.GetChild(0).transform.GetChild(2).gameObject.GetComponent<InputField>();
        nip = gameObject.transform.GetChild(0).transform.GetChild(3).gameObject.GetComponent<InputField>();
        regon = gameObject.transform.GetChild(0).transform.GetChild(4).gameObject.GetComponent<InputField>();
        krs = gameObject.transform.GetChild(0).transform.GetChild(5).gameObject.GetComponent<InputField>();
        email = gameObject.transform.GetChild(0).transform.GetChild(6).gameObject.GetComponent<InputField>();
        haslo = gameObject.transform.GetChild(0).transform.GetChild(7).gameObject.GetComponent<InputField>();
        powtorzHaslo = gameObject.transform.GetChild(0).transform.GetChild(8).gameObject.GetComponent<InputField>();
    }
}
