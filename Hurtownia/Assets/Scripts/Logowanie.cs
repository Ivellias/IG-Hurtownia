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
    private Uzytkownik uzytkownik;

    private Text info;

    private bool zapomniane;

    public float doStartThingsAndReturnHeightOfThisElement()
    {
        return 420f;
    }

    public void Zaloguj()
    {
        uzytkownik = PolaczenieBazy.WyszukajUzytkownika(textFieldUsername.GetComponent<InputField>().text, textFieldPassword.GetComponent<InputField>().text);

        if (textFieldUsername.GetComponent<InputField>().text == "" 
        || textFieldPassword.GetComponent<InputField>().text == "" || uzytkownik == null) { //jesli dane sa bledne
            if (!zapomniane) {
                tekstOBledzie.GetComponent<Text>().enabled = true;
                zapomnialem.GetComponent<Button>().enabled = true;
                zapomnialem.transform.GetChild(0).GetComponent<Text>().enabled = true;
                zapomniane = true;
            }
            tekstOBledzie.GetComponent<Text>().text = "Wpisano błędną nazwę użytkownika lub hasło!";
            textFieldUsername.GetComponent<InputField>().text = "";
            textFieldPassword.GetComponent<InputField>().text = "";
        }
        else
        {
            OverSceneHandler.aktualnieZalogowanyUzytkownik = uzytkownik;

            if (OverSceneHandler.aktualnieZalogowanyUzytkownik.PoziomDostepu == 0)
            {
                if (!zapomniane)
                {
                    tekstOBledzie.GetComponent<Text>().enabled = true;
                    zapomnialem.GetComponent<Button>().enabled = true;
                    zapomnialem.transform.GetChild(0).GetComponent<Text>().enabled = true;
                    zapomniane = true;
                }
                tekstOBledzie.GetComponent<Text>().text = "Twoje konto nie zostało jeszcze zatwierdzone.";
                textFieldUsername.GetComponent<InputField>().text = "";
                textFieldPassword.GetComponent<InputField>().text = "";
            }
                else if (OverSceneHandler.aktualnieZalogowanyUzytkownik.PoziomDostepu == 1)
            {
                SceneManager.LoadScene("ZalogowanyUzytkownik");
            } else if(OverSceneHandler.aktualnieZalogowanyUzytkownik.PoziomDostepu == 2)
            {
                SceneManager.LoadScene("ZalogowanyPracownik");
            } else if(OverSceneHandler.aktualnieZalogowanyUzytkownik.PoziomDostepu == 3)
            {
                SceneManager.LoadScene("ZalogowanyAdministrator"); 
            }

            
            //zalogowanie...
        }

        //textFieldUsername.GetComponent<InputField>().text //dostanie sie do nazwy uzytkownika
        //textFieldPassword.GetComponent<InputField>().text //dostanie sie do hasla

    }

}
