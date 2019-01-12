using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObiektZamowieniaUzytkownika : MonoBehaviour
{

    private Zamowienie zamowienie;

    public void UstawZamowienie(Zamowienie doUstawienia)
    {
        zamowienie = doUstawienia;
        transform.GetChild(0).gameObject.GetComponent<Text>().text = "id: "+zamowienie.ID + "  " + zamowienie.DataZakupu;
        transform.GetChild(1).gameObject.GetComponent<Text>().text = "Cena: " + zamowienie.CalkowitaKwotaZakupu;
        //swich(zamowienie.status)
        transform.GetChild(2).gameObject.GetComponent<Text>().text = "Status: BRAK STATUSU";
    }

    public void Szczegoly()
    {

    }

    // Use this for initialization
    void Start()
    {

    }

}
