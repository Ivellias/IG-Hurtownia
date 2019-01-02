using System.Collections;
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

    public float doStartThingsAndReturnHeightOfThisElement()
    {
        return 420f;
    }

    public void Zaloguj()
    {
        baza = new PolaczenieBazy();
        uzytkownik = baza.WyszukajUzytkownika(textFieldUsername.GetComponent<InputField>().text, textFieldPassword.GetComponent<InputField>().text);

        if (textFieldUsername.GetComponent<InputField>().text == "" 
        || textFieldPassword.GetComponent<InputField>().text == "" || uzytkownik.ID == null) { //jesli dane sa bledne
            tekstOBledzie.GetComponent<Text>().enabled = true;
            zapomnialem.GetComponent<Button>().enabled = true;
            zapomnialem.transform.GetChild(0).GetComponent<Text>().enabled = true;
        }
        else
        {
            SceneManager.LoadScene("ZalogowanyUzytkownik");
            //zalogowanie...
        }

        //textFieldUsername.GetComponent<InputField>().text //dostanie sie do nazwy uzytkownika
        //textFieldPassword.GetComponent<InputField>().text //dostanie sie do hasla

    }

}
