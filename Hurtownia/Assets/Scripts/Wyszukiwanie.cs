using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wyszukiwanie : MonoBehaviour, IOnStart {


    public float doStartThingsAndReturnHeightOfThisElement()
    {
        float wysokosc = 100f;
        wysokosc += (transform.childCount+1) * 220f; 




        return wysokosc;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
