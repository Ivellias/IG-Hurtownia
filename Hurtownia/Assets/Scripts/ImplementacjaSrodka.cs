using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImplementacjaSrodka : MonoBehaviour {

	public GameObject samTekst;
	private GameObject przykladowyTekst;
	private GameObject oNas;
	// Use this for initialization
	void Start () {
		UsunWszystkiePrefaby();
		ZainicjalizujPrzykladowyTekst();
	}

	public void ONas(){
		UsunWszystkiePrefaby();
		oNas = Instantiate(samTekst, gameObject.transform);
		oNas.transform.GetChild(0).GetComponent<Text>().text = "O nas";
		oNas.transform.GetChild(1).GetComponent<Text>().text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor" +
		"incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea " +
		"commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint" +
		"occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." + 
		"Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo" +
		"inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo." + 
		"Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, " + 
		"sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. ";
		float wysokosc = oNas.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();
		UstawWysokosc(wysokosc);
	}

	private void UstawWysokosc(float wysokosc){
		gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, wysokosc);
	}

	private void ZainicjalizujPrzykladowyTekst(){
		przykladowyTekst = Instantiate(samTekst, gameObject.transform);
		float wysokosc = przykladowyTekst.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();
		UstawWysokosc(wysokosc);
	}

	private void UsunWszystkiePrefaby(){
		GameObject.Destroy(przykladowyTekst, 0f);
		GameObject.Destroy(oNas, 0f);
	}
}
