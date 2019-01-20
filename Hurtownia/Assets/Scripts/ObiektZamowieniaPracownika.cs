using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObiektZamowieniaPracownika : MonoBehaviour
{

    private Zamowienie zamowienie;
    private GameObject parent;
    public void SetParent(GameObject x)
    {
        parent = x;
    }

    public void UstawZamowienie(Zamowienie doUstawienia)
    {
        zamowienie = doUstawienia;
        transform.GetChild(0).gameObject.GetComponent<Text>().text = "id: " + zamowienie.ID + "  " + zamowienie.DataZakupu;
        transform.GetChild(1).gameObject.GetComponent<Text>().text = "Cena: " + zamowienie.CalkowitaKwotaZakupu;
        switch (zamowienie.PostepZamowienia)
        {
            case 0:
                {
                    transform.GetChild(2).gameObject.GetComponent<Text>().text = "Status: W trakcie realizacji";
                    break;
                }
            case 1:
                {
                    transform.GetChild(2).gameObject.GetComponent<Text>().text = "Status: Do odbioru";
                    break;
                }
            case 2:
                {
                    transform.GetChild(2).gameObject.GetComponent<Text>().text = "Status: Zrealizowany";
                    break;
                }
            default:
                {
                    transform.GetChild(2).gameObject.GetComponent<Text>().text = "Status: Nieznany";
                    break;
                }
        }

        if(zamowienie.PostepZamowienia == 2)
        {
            transform.GetChild(4).GetChild(0).GetComponent<Text>().enabled = false;
            transform.GetChild(4).GetComponent<Button>().enabled = false;
            transform.GetChild(4).GetComponent<Image>().enabled = false;
        }

    }

    public void Szczegoly()
    {
        parent.GetComponent<ZamowieniaPracownika>().UstawDoWyswietlenia(zamowienie);
        parent.GetComponent<ZamowieniaPracownika>().WyswietlSzczegoly();
    }

    public void ZmienStatus()
    {
        PolaczenieBazy.ZmienStatusZamowieniaPlusJeden(zamowienie.ID, zamowienie.PostepZamowienia+1);


        GameObject.FindGameObjectWithTag("Srodek").GetComponent<ImplementacjaSrodka>().ZamowieniaPracownika();//rysowanie na nowo
    }

}
