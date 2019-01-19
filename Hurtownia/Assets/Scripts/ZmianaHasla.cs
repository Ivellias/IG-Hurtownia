using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZmianaHasla : MonoBehaviour {

    public GameObject nowe;
    public GameObject powtorz;
    public GameObject dotychczasowe;

    public void Zmien()
    {
        PolaczenieBazy polaczenieBazy = new PolaczenieBazy();
        if(dotychczasowe.GetComponent<InputField>().text.Equals(OverSceneHandler.aktualnieZalogowanyUzytkownik.Haslo)){
            if(nowe.GetComponent<InputField>().text.Equals(powtorz.GetComponent<InputField>().text)){
                polaczenieBazy.ZmienHaslo(OverSceneHandler.aktualnieZalogowanyUzytkownik, nowe.GetComponent<InputField>().text);
            }
            else{
                //hasla nie pokrywaja sie
            }
        }
        else{
            //haslo nie jest identyczne z obecnym
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
