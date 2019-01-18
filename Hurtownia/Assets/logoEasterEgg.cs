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
        if(kanter == 3)
        {
            GetComponent<Animator>().Play("ObrocSie");
            kanter = 0;
        }
    }



}
