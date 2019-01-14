using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opcje : MonoBehaviour, IOnStart {

    public GameObject zmianaHasla;

    public float doStartThingsAndReturnHeightOfThisElement()
    {
        zmianaHasla.GetComponent<ZmianaHasla>().WyjscieZmianaHasla();

        transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = "Nazwa: " + OverSceneHandler.aktualnieZalogowanyUzytkownik.Login + " (" + OverSceneHandler.aktualnieZalogowanyUzytkownik.Imie + " " + OverSceneHandler.aktualnieZalogowanyUzytkownik.Nazwisko + ")";
        transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().text = "Adres e-mail: " + OverSceneHandler.aktualnieZalogowanyUzytkownik.Mail;
        transform.GetChild(0).GetChild(2).gameObject.GetComponent<Text>().text = "Adres: " + OverSceneHandler.aktualnieZalogowanyUzytkownik.Adres;
        transform.GetChild(0).GetChild(3).gameObject.GetComponent<Text>().text = "NIP: " + OverSceneHandler.aktualnieZalogowanyUzytkownik.NIP;
        transform.GetChild(0).GetChild(4).gameObject.GetComponent<Text>().text = "REGON: " + OverSceneHandler.aktualnieZalogowanyUzytkownik.REGON;
        transform.GetChild(0).GetChild(5).gameObject.GetComponent<Text>().text = "KRS: " + OverSceneHandler.aktualnieZalogowanyUzytkownik.KRS; 



        return 400f;
    }

}
