using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

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
        Uzytkownik nowyUzytkownik = new Uzytkownik();
        nowyUzytkownik.Login = nazwaUzytkownika.text;
        nowyUzytkownik.NazwaFirmy = nazwaFirmy.text;
        nowyUzytkownik.Adres = adres.text;

        int val = 0;
        if(Int32.TryParse(nip.text, out val)){
            nowyUzytkownik.NIP = Int32.Parse(nip.text);
        }
        else{
            //dodac tekst o zlym formacie czy cos
        }

        if(Int32.TryParse(regon.text, out val)){
            nowyUzytkownik.REGON = Int32.Parse(regon.text);
        }
        else{
            //dodac tekst o zlym formacie czy cos
        }

        if(!krs.text.Equals(null)){
            if(Int32.TryParse(krs.text, out val)){
                nowyUzytkownik.KRS = Int32.Parse(krs.text);
            }
            else{
                //dodac tekst o zlym formacie czy cos
            }
        }

        if(!email.text.Equals(null)){
            nowyUzytkownik.Mail = email.text;
        }

        if(haslo.text.Equals(powtorzHaslo.text)){
            nowyUzytkownik.Haslo = haslo.text;
        }
        else{
            //dodac tekst o zlym formacie czy cos
        }

        PolaczenieBazy polaczenieBazy = new PolaczenieBazy();
        string wiadomoscZwrotna = polaczenieBazy.DodajNowegoUzytkownika(nowyUzytkownik);
        email.text = wiadomoscZwrotna;

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
