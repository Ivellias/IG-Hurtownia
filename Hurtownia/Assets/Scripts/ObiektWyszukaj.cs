using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObiektWyszukaj : MonoBehaviour {

    private int ilosc;
    private Text iloscText;

    public void ZmienIlosc(int a)
    {
        ilosc += a;
        if (ilosc < 0) ilosc = 0;
        iloscText.text = ilosc.ToString();
    }

    public void Zamow()
    {
        //DODANIE DO KOSZYKA
        ilosc = 0;
        iloscText.text = ilosc.ToString();
    }

	// Use this for initialization
	void Start () {
        ilosc = 0;
        iloscText = transform.GetChild(0).GetComponent<Text>();
	}

}
