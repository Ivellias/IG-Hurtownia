using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZmianaHasla : MonoBehaviour {

    public GameObject nowe;
    public GameObject powtorz;
    public GameObject dotychczasowe;
    public GameObject komunikat;

    public void Zmien()
    {
        if (nowe.GetComponent<InputField>().text == "" || powtorz.GetComponent<InputField>().text == "" || dotychczasowe.GetComponent<InputField>().text == "")
        {
            komunikat.GetComponent<Text>().text = "Proszę uzupełnić wszystkie pola.";
        }
        else
        {
            if (nowe.GetComponent<InputField>().text == powtorz.GetComponent<InputField>().text)
            {
                if (dotychczasowe.GetComponent<InputField>().text.Equals(OverSceneHandler.aktualnieZalogowanyUzytkownik.Haslo))
                {
                    if(nowe.GetComponent<InputField>().text == OverSceneHandler.aktualnieZalogowanyUzytkownik.Haslo)
                    {
                        komunikat.GetComponent<Text>().text = "Hasła są identyczne.";
                    }
                    else
                    {
                        PolaczenieBazy.ZmienHaslo(OverSceneHandler.aktualnieZalogowanyUzytkownik, nowe.GetComponent<InputField>().text);
                        komunikat.GetComponent<Text>().text = "Hasło zostało pomyślnie zmienione!";
                        dotychczasowe.GetComponent<InputField>().text = "";
                        nowe.GetComponent<InputField>().text = "";
                        powtorz.GetComponent<InputField>().text = "";
                    } 
                }
                else
                {
                    komunikat.GetComponent<Text>().text = "Aktualne hasło zostało podane niepoprawnie.";
                    dotychczasowe.GetComponent<InputField>().text = "";
                }
            }
            else
            {
                komunikat.GetComponent<Text>().text = "Nowe hasło zostało błędnie powtórzone.";
                nowe.GetComponent<InputField>().text = "";
                powtorz.GetComponent<InputField>().text = "";
            }
        }

    }


    public void ZmienHaslo()
    {
        foreach (Transform child in transform) child.gameObject.SetActive(true);
    }

    public void WyjscieZmianaHasla()
    {
        foreach (Transform child in transform) child.gameObject.SetActive(false);
    }

}
