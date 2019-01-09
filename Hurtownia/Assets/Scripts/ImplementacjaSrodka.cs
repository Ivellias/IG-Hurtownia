using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImplementacjaSrodka : MonoBehaviour {
	public GameObject samTekst;
    public GameObject scrollBar;
	public GameObject oNas;
    public GameObject kontakt;
    public GameObject logowanie;
    public GameObject wylogowano;
    public GameObject inputWyszukiwania;
    public GameObject wyszukiwanie;
    public GameObject opcje;
    //tutaj jest lista
    private List<GameObject> listaObiektow = new List<GameObject>();

    void Start()
    {
        listaObiektow = new List<GameObject>();
    }

    public void Zamowienia(){
        GameObject go = GameObject.Find("Uzytkownik");
        Uzytkownik uzytkownik = go.GetComponent<Uzytkownik>();
        inputWyszukiwania.GetComponent<InputField>().text = uzytkownik.Login;
        GUI.TextField(new Rect(10, 10, 200, 20), uzytkownik.Login, 25);
	}

	public void Faktury(){

	}

	public void Opcje(){
        UsunWszystkiePrefaby();
        GameObject prefab = Instantiate(opcje, gameObject.transform);
        float wysokosc = prefab.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();
        UstawWysokosc(wysokosc);
        //DODAJ DO LISTY PREFABOW
        listaObiektow.Add(prefab);
        SprawdzScroll(wysokosc);
    }

    public void Wyszukiwanie()
    {
        if(inputWyszukiwania.GetComponent<InputField>().text != "")
        {
            UsunWszystkiePrefaby();
            GameObject prefab = Instantiate(wyszukiwanie, gameObject.transform);
            float wysokosc = prefab.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();

            //tu mina do refaktoryzacji
            prefab.GetComponent<Wyszukiwanie>().ustawCoWyszukac(inputWyszukiwania.GetComponent<InputField>().text);
            inputWyszukiwania.GetComponent<InputField>().text = "";

            UstawWysokosc(wysokosc);
            //DODAJ DO LISTY PREFABOW
            listaObiektow.Add(prefab);
            SprawdzScroll(wysokosc);
        }
    }

    public void ONas(){
        UsunWszystkiePrefaby();
        GameObject prefab = Instantiate(oNas, gameObject.transform);
        float wysokosc = prefab.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();
        UstawWysokosc(wysokosc);
        //DODAJ DO LISTY PREFABOW
        listaObiektow.Add(prefab);
        SprawdzScroll(wysokosc);
    }

    public void Logowanie()
    {
        UsunWszystkiePrefaby();
        GameObject prefab = Instantiate(logowanie, gameObject.transform);
        float wysokosc = prefab.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();
        UstawWysokosc(wysokosc);
        //DODAJ DO LISTY PREFABOW
        listaObiektow.Add(prefab);
        SprawdzScroll(wysokosc);
    }

    public void Wylogowano()
    {
        UsunWszystkiePrefaby();
        GameObject prefab = Instantiate(wylogowano, gameObject.transform);
        float wysokosc = prefab.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();
        UstawWysokosc(wysokosc);
        //DODAJ DO LISTY PREFABOW
        listaObiektow.Add(prefab);
        SprawdzScroll(wysokosc);
    }

    public void Kontakt(){
        UsunWszystkiePrefaby();
        GameObject prefab = Instantiate(kontakt, gameObject.transform);
        float wysokosc = prefab.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();
        UstawWysokosc(wysokosc);
        //DODAJ DO LISTY PREFABOW
        listaObiektow.Add(prefab);
        SprawdzScroll(wysokosc);
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

    private void SprawdzScroll(float wysokosc)
    {
        if (wysokosc <= 500)
        {
            scrollBar.GetComponent<Image>().enabled = false;
            scrollBar.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
        else
        {
            scrollBar.GetComponent<Image>().enabled = true;
            scrollBar.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = true;
        }
    }

	private void UsunWszystkiePrefaby(){
        //xD
		//GameObject.Destroy(zamowienia, 0f);
		//GameObject.Destroy(faktury, 0f);
		//GameObject.Destroy(opcje, 0f);

        //USUN WSZYSTKIE ELEMENTY Z LISTY PREFABOW
        if(listaObiektow.Count != 0){
            foreach (GameObject x in listaObiektow)
            {
                GameObject.Destroy(x, 0f);
            }
            listaObiektow = new List<GameObject>();
        }
        
	}
}
