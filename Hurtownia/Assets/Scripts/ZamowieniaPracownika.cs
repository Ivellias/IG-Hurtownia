using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZamowieniaPracownika : MonoBehaviour, IOnStart
{

    private PolaczenieBazy baza;
    List<Zamowienie> zamowienia;
    public GameObject prefabZamowienia;

    public float doStartThingsAndReturnHeightOfThisElement()
    {

        baza = new PolaczenieBazy();
        zamowienia = baza.ZwrocWszystkieZamowieniaPoRealizacji();
        Debug.Log(zamowienia.Count);

        if (zamowienia == null)
        {
            transform.GetChild(1).gameObject.GetComponent<Text>().text = "Aktualnie nie ma zamówień.";
        }
        else
        {
            transform.GetChild(1).gameObject.GetComponent<Text>().text = "Zamówienia:";
            Debug.Log("count: " + zamowienia.Count);
            int i = 0;
            foreach (Zamowienie zamowienie in zamowienia)
            {
                GameObject tmp = Instantiate(prefabZamowienia, gameObject.transform.GetChild(0).transform);

                tmp.GetComponent<ObiektZamowieniaPracownika>().UstawZamowienie(zamowienie);

                tmp.GetComponent<RectTransform>().anchoredPosition = new Vector2(62f, -356 - (i * 220f));
                i++;
            }
        }

        float wysokosc = 100f;
        if (zamowienia != null) wysokosc += (zamowienia.Count) * 220f;
        return wysokosc;
    }

}
