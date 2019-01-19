using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DodanieTowaru : MonoBehaviour, IOnStart
{

    private InputField nazwaTowaru;
    private InputField ilosc;
    private InputField cena;
    private Text info;

    public void DodajTowar()
    {
        if(ilosc.text != "" && cena.text != "" && nazwaTowaru.text != "")
        {
            Przedmiot przedmiot = new Przedmiot();
            przedmiot.Nazwa = nazwaTowaru.text;
            przedmiot.Opis = "Dodane przez " + OverSceneHandler.aktualnieZalogowanyUzytkownik.Login;
            przedmiot.CalkowitaIlosc = int.Parse(ilosc.text);
            przedmiot.Cena = float.Parse(cena.text);

            Debug.Log(nazwaTowaru.text + ilosc.text + cena.text);

            string a = PolaczenieBazy.DodajNowyPrzedmiot(przedmiot);
            info.text = a;

            nazwaTowaru.text = "";
            ilosc.text = "";
            cena.text = "";
        }
        else
        {
            info.text = "Należy uzupełnić wszystkie pola.";
        }

    }

    void Start()
    {
        info = transform.GetChild(3).gameObject.GetComponent<Text>();
        nazwaTowaru = gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<InputField>();
        ilosc = gameObject.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<InputField>();
        cena = gameObject.transform.GetChild(0).transform.GetChild(2).gameObject.GetComponent<InputField>();
    }

    float IOnStart.doStartThingsAndReturnHeightOfThisElement()
    {
        return 300f;
    }

}
