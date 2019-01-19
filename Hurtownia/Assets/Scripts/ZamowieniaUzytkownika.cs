using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZamowieniaUzytkownika : MonoBehaviour, IOnStart
{
    List<Zamowienie> zamowienia;
    public GameObject prefabZamowienia;

    public float doStartThingsAndReturnHeightOfThisElement()
    {
        zamowienia = PolaczenieBazy.ZwrocListeZamowienDoUzytkownika(OverSceneHandler.aktualnieZalogowanyUzytkownik);
        Debug.Log(zamowienia.Count);
        //zamowienia = OverSceneHandler.aktualnieZalogowanyUzytkownik.ListaZamowien;

        if (zamowienia == null)
        {
            transform.GetChild(1).gameObject.GetComponent<Text>().text = "Aktualnie nie masz zamówień.";
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
