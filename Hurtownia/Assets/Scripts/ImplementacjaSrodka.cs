using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplementacjaSrodka : MonoBehaviour {

	public GameObject samTekst;
	// Use this for initialization
	void Start () {
		samTekst.transform.parent = gameObject.transform;
		Instantiate(samTekst, new Vector3(0, 10, 0), Quaternion.identity);
		UstawWysokosc(WezWysokoscObiektu(samTekst));
		GameObject.Destroy(samTekst, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void UstawWysokosc(float wysokosc){
			gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, wysokosc);
	}
	
	private float WezWysokoscObiektu(GameObject obiekt){
 		RectTransform rt = (RectTransform)obiekt.transform;
 		return rt.rect.height;
	}
}
