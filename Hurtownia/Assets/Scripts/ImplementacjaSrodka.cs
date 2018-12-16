using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImplementacjaSrodka : MonoBehaviour {

	public GameObject samTekst;
	private GameObject przykladowyTekst;
	private GameObject zamowienia;
	private GameObject faktury;
	private GameObject opcje;
	private GameObject oNas;
	private GameObject kontakt;

	void Start () {
	}

	
	public void Zamowienia(){
		zamowienia = UstawPrefab("Zamowienia", "Tekst");
	}

	public void Faktury(){
		faktury = UstawPrefab("Faktury", "Tekst");
	}

	public void Opcje(){
		opcje = UstawPrefab("Opcje", "Tekst");
	}

	public void ONas(){
		oNas = UstawPrefab("O Nas", "Tekst");
	}

	public void Kontakt(){
		kontakt = UstawPrefab("Kontakt", "Tekst");
	}

	private GameObject UstawPrefab(string tytul, string tekst){
		UsunWszystkiePrefaby();
		GameObject prefab = Instantiate(samTekst, gameObject.transform);
		prefab.transform.GetChild(0).GetComponent<Text>().text = tytul;
		prefab.transform.GetChild(1).GetComponent<Text>().text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor" +
		"incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea " +
		"commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint" +
		"occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." + 
		"Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo" +
		"inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo." + 
		"Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, " + 
		"sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. ";
		float wysokosc = prefab.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();
		UstawWysokosc(wysokosc);
		return prefab;
	}

	private void UstawWysokosc(float wysokosc){
		gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, wysokosc);
	}

	private void UsunWszystkiePrefaby(){
		GameObject.Destroy(zamowienia, 0f);
		GameObject.Destroy(faktury, 0f);
		GameObject.Destroy(opcje, 0f);
		GameObject.Destroy(oNas, 0f);
		GameObject.Destroy(kontakt, 0f);
	}
}
