using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wyszukiwanie : MonoBehaviour, IOnStart {

    private string doWyszukania; 

    public float doStartThingsAndReturnHeightOfThisElement()
    {
        float wysokosc = 100f;
        wysokosc += (transform.childCount+1) * 220f; 

        //tu ma pytac baze danych o mozliwosci


        return wysokosc;
    }

    public void ustawCoWyszukac(string a)
    {
        doWyszukania = a;
    }

}
