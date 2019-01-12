using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZamowieniaUzytkownika : MonoBehaviour, IOnStart
{

    private PolaczenieBazy baza;
    List<Zamowienie> zamowienia;
    public GameObject prefabZamowienia;

    public float doStartThingsAndReturnHeightOfThisElement()
    {

        //baza = new PolaczenieBazy();
        //zamowienia = baza.ZwrocListeZamowienDoUzytkownika(OverSceneHandler.aktualnieZalogowanyUzytkownik);
        zamowienia = OverSceneHandler.aktualnieZalogowanyUzytkownik.ListaZamowien;

        if (zamowienia == null)
        {
            transform.GetChild(1).gameObject.GetComponent<Text>().text = "Aktualnie masz zamówień.";
        }
        else
        {
            transform.GetChild(1).gameObject.GetComponent<Text>().text = "Twoje zamówienia:";
            Debug.Log("count: " + zamowienia.Count);
            int i = 0;
            foreach(Zamowienie zamowienie in zamowienia)
            {
                GameObject tmp = Instantiate(prefabZamowienia, gameObject.transform.GetChild(0).transform);

                tmp.GetComponent<ObiektZamowieniaUzytkownika>().UstawZamowienie(zamowienie);

                tmp.GetComponent<RectTransform>().anchoredPosition = new Vector2(62f, -356 - (i * 220f));
                i++;
            }
        }

        float wysokosc = 100f;
        if (zamowienia != null) wysokosc += (zamowienia.Count) * 220f;
        return wysokosc;
    }

}
