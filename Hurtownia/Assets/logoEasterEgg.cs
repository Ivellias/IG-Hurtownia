using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logoEasterEgg : MonoBehaviour {

    private int kanter;
	// Use this for initialization
	void Start () {
        kanter = 0;
	}
	
    public void Wywolaj()
    {
        kanter++;
        if(kanter%5 == 0)
        {
            GetComponent<Animator>().Play("ObrocSie");
        }
        if(kanter == 84)
        {
            kanter = 0;
            GameObject.FindGameObjectWithTag("Srodek").GetComponent<ImplementacjaSrodka>().Rick();
        }
    }



}
