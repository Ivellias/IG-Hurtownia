﻿using System.Collections.Generic;
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
    public GameObject rick;
    public GameObject rejestracja;
    public GameObject zarzadzanieTowarem;
    public GameObject koszyk;
    public GameObject zamowieniaUzytkownika;
    public GameObject zamowieniaPracownika;
    public GameObject uzytkownicy;
    public GameObject tworzenieUzytkownika;
    public GameObject dodajTowar;
    public GameObject raport;
    //public GameObject fakturyUzytkownika;
    //public GameObject fakturyAdministratora;

    //tutaj jest lista
    private List<GameObject> listaObiektow = new List<GameObject>();

    void Start()
    {
        listaObiektow = new List<GameObject>();
    }

    public void ZamowieniaUzytkownika(){
        UsunWszystkiePrefaby();
        GameObject prefab = Instantiate(zamowieniaUzytkownika, gameObject.transform);
        float wysokosc = prefab.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();

        UstawWysokosc(wysokosc);
        //DODAJ DO LISTY PREFABOW
        listaObiektow.Add(prefab);
        SprawdzScroll(wysokosc);
    }

    public void ZamowieniaPracownika()
    {
        UsunWszystkiePrefaby();
        GameObject prefab = Instantiate(zamowieniaPracownika, gameObject.transform);
        float wysokosc = prefab.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();

        UstawWysokosc(wysokosc);
        //DODAJ DO LISTY PREFABOW
        listaObiektow.Add(prefab);
        SprawdzScroll(wysokosc);
    }

    public void Uzytkownicy()
    {
        UsunWszystkiePrefaby();
        GameObject prefab = Instantiate(uzytkownicy, gameObject.transform);
        float wysokosc = prefab.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();

        UstawWysokosc(wysokosc);
        //DODAJ DO LISTY PREFABOW
        listaObiektow.Add(prefab);
        SprawdzScroll(wysokosc);
    }

    public void TworzenieUzytkownika()
    {
        UsunWszystkiePrefaby();
        GameObject prefab = Instantiate(tworzenieUzytkownika, gameObject.transform);
        float wysokosc = prefab.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();

        UstawWysokosc(wysokosc);
        //DODAJ DO LISTY PREFABOW
        listaObiektow.Add(prefab);
        SprawdzScroll(wysokosc);
    }

    public void DodajTowar()
    {
        UsunWszystkiePrefaby();
        GameObject prefab = Instantiate(dodajTowar, gameObject.transform);
        float wysokosc = prefab.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();

        UstawWysokosc(wysokosc);
        //DODAJ DO LISTY PREFABOW
        listaObiektow.Add(prefab);
        SprawdzScroll(wysokosc);
    }

    public void Raport()
    {
        UsunWszystkiePrefaby();
        GameObject prefab = Instantiate(raport, gameObject.transform);
        float wysokosc = prefab.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();

        UstawWysokosc(wysokosc);
        //DODAJ DO LISTY PREFABOW
        listaObiektow.Add(prefab);
        SprawdzScroll(wysokosc);
    }

    
	public void FakturyUzytkownika()
    {
        /*
        UsunWszystkiePrefaby();
        GameObject prefab = Instantiate(, gameObject.transform);
        float wysokosc = prefab.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();

        UstawWysokosc(wysokosc);
        //DODAJ DO LISTY PREFABOW
        listaObiektow.Add(prefab);
        SprawdzScroll(wysokosc);
        */
    }

    public void FakturyAdministratora()
    {
        /*
        UsunWszystkiePrefaby();
        GameObject prefab = Instantiate(, gameObject.transform);
        float wysokosc = prefab.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();

        UstawWysokosc(wysokosc);
        //DODAJ DO LISTY PREFABOW
        listaObiektow.Add(prefab);
        SprawdzScroll(wysokosc);
        */
    }

    public void Koszyk()
    {
        UsunWszystkiePrefaby();
        GameObject prefab = Instantiate(koszyk, gameObject.transform);
        float wysokosc = prefab.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();
        UstawWysokosc(wysokosc);
        //DODAJ DO LISTY PREFABOW
        listaObiektow.Add(prefab);
        SprawdzScroll(wysokosc);
    }

    public void ZarzadzanieTowarem()
    {
        UsunWszystkiePrefaby();
        GameObject prefab = Instantiate(zarzadzanieTowarem, gameObject.transform);
        prefab.GetComponent<ZarzadzanieTowarem1>().ustawCoWyszukac(inputWyszukiwania.GetComponent<InputField>().text);
        inputWyszukiwania.GetComponent<InputField>().text = "";
        float wysokosc = prefab.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();
        UstawWysokosc(wysokosc);
        //DODAJ DO LISTY PREFABOW
        listaObiektow.Add(prefab);
        SprawdzScroll(wysokosc);
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
            //tu mina do refaktoryzacji
            prefab.GetComponent<Wyszukiwanie>().ustawCoWyszukac(inputWyszukiwania.GetComponent<InputField>().text);
            inputWyszukiwania.GetComponent<InputField>().text = "";
            float wysokosc = prefab.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();
            UstawWysokosc(wysokosc);
            //DODAJ DO LISTY PREFABOW
            listaObiektow.Add(prefab);
            SprawdzScroll(wysokosc);
        }
    }

    public void Rejestracja()
    {
        UsunWszystkiePrefaby();
        GameObject prefab = Instantiate(rejestracja, gameObject.transform);
        float wysokosc = prefab.GetComponent<IOnStart>().doStartThingsAndReturnHeightOfThisElement();
        UstawWysokosc(wysokosc);
        //DODAJ DO LISTY PREFABOW
        listaObiektow.Add(prefab);
        SprawdzScroll(wysokosc);
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

    public void Rick()
    {
        GameObject prefab = Instantiate(rick, gameObject.transform);
        //DODAJ DO LISTY PREFABOW
        listaObiektow.Add(prefab);
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
        GameObject.FindGameObjectWithTag("Scroll").GetComponent<Scrollbar>().value = 1;
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
