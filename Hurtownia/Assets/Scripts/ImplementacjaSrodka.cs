using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplementacjaSrodka : MonoBehaviour {

	public GameObject prefab;
	// Use this for initialization
	void Start () {
		gameObject.AddComponent(prefab);
		Instantiate(prefab, new Vector3(150f, 150f, 0), Quaternion.identity);
		UstawWysokosc(1056f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void UstawWysokosc(float wysokosc){
			gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, wysokosc);
	}
}
