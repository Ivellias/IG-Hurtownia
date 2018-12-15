using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplementacjaSrodka : MonoBehaviour {

	public GameObject samTekst;
	// Use this for initialization
	void Start () {
		UstawWysokosc(ZainicjalizujObiekty());
		UsunObiekty();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void UstawWysokosc(float wysokosc){
			gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, wysokosc);
	}

	private float ZainicjalizujObiekty(){
		GameObject tmp = Instantiate(samTekst, gameObject.transform);
		float wysokosc = tmp.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();
		return wysokosc;
	}

	private void UsunObiekty(){
				GameObject.Destroy(samTekst, 0f);
	}
}
