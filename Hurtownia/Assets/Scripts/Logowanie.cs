﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logowanie : MonoBehaviour, IOnStart {
    public GameObject tekstOBledzie;
    public GameObject zapomnialem;
    public GameObject textFieldUsername;
    public GameObject textFieldPassword;
    private PolaczenieBazy baza;
    private Uzytkownik uzytkownik;

    private bool zapomniane;

    public float doStartThingsAndReturnHeightOfThisElement()
    {
        return 420f;
    }

    public void Zaloguj()
    {
        baza = new PolaczenieBazy();
        uzytkownik = baza.WyszukajUzytkownika(textFieldUsername.GetComponent<InputField>().text, textFieldPassword.GetComponent<InputField>().text);

        if (textFieldUsername.GetComponent<InputField>().text == "" 
        || textFieldPassword.GetComponent<InputField>().text == "" || uzytkownik == null) { //jesli dane sa bledne
            if (!zapomniane) {
                tekstOBledzie.GetComponent<Text>().enabled = true;
                zapomnialem.GetComponent<Button>().enabled = true;
                zapomnialem.transform.GetChild(0).GetComponent<Text>().enabled = true;
                zapomniane = true;
            }
            textFieldUsername.GetComponent<InputField>().text = "";
            textFieldPassword.GetComponent<InputField>().text = "";
        }
        else
        {
            OverSceneHandler.aktualnieZalogowanyUzytkownik = uzytkownik;

            if (OverSceneHandler.aktualnieZalogowanyUzytkownik.PoziomDostepu == 0)
            {
                //INFO ZE NEI JEST JESZCZE ZATWIERDZONE
            }
                else if (OverSceneHandler.aktualnieZalogowanyUzytkownik.PoziomDostepu == 1)
            {
                SceneManager.LoadScene("ZalogowanyUzytkownik");
            } else if(OverSceneHandler.aktualnieZalogowanyUzytkownik.PoziomDostepu == 2)
            {
                SceneManager.LoadScene("ZalogowanyPracownik");
            } else if(OverSceneHandler.aktualnieZalogowanyUzytkownik.PoziomDostepu == 3)
            {
                SceneManager.LoadScene("ZalogowanyPracownik"); //tu zmienic na admina jak bedzie scena!!!!!!
            }

            
            //zalogowanie...
        }

        //textFieldUsername.GetComponent<InputField>().text //dostanie sie do nazwy uzytkownika
        //textFieldPassword.GetComponent<InputField>().text //dostanie sie do hasla

    }

}
