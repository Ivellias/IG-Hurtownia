﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logowanie : MonoBehaviour, IOnStart {

    public GameObject tekstOBledzie;
    public GameObject zapomnialem;
    public GameObject textFieldUsername;
    public GameObject textFieldPassword;

    public float doStartThingsAndReturnHeightOfThisElement()
    {

        return 500f;
    }

    public void Zaloguj()
    {
        if (textFieldUsername.GetComponent<InputField>().text == "" || textFieldPassword.GetComponent<InputField>().text == "") { //jesli dane sa bledne
            tekstOBledzie.GetComponent<Text>().enabled = true;
            zapomnialem.GetComponent<Button>().enabled = true;
            zapomnialem.transform.GetChild(0).GetComponent<Text>().enabled = true;
        }
        else
        {
            //zalogowanie...
        }

        //textFieldUsername.GetComponent<InputField>().text //dostanie sie do nazwy uzytkownika
        //textFieldPassword.GetComponent<InputField>().text //dostanie sie do hasla

    }

}