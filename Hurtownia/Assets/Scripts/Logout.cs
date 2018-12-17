using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logout : MonoBehaviour {

    public void Wyloguj()
    {
        SceneManager.LoadScene("EkranGlowny");
        //GameObject.FindGameObjectWithTag("Srodek").GetComponent<ImplementacjaSrodka>().Wylogowano();
        //zrobic zeby byl na zaladowanej scenie komunikat
    }

}
