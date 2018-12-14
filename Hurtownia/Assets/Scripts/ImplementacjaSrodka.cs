using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplementacjaSrodka : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(100f, 50f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
