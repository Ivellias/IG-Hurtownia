using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplementacjaSrodka : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UstawWysokosc(1056f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void UstawWysokosc(float wysokosc){
			gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, wysokosc);
	}
}
