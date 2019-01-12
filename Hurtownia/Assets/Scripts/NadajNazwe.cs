using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NadajNazwe : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = OverSceneHandler.aktualnieZalogowanyUzytkownik.Imie + " " + OverSceneHandler.aktualnieZalogowanyUzytkownik.Nazwisko;
	}
	
}
