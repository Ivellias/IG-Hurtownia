using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObiektZamowieniaUzytkownika : MonoBehaviour
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
        transform.GetChild(0).gameObject.GetComponent<Text>().text = "id: "+zamowienie.ID + "  " + zamowienie.DataZakupu;
        transform.GetChild(1).gameObject.GetComponent<Text>().text = "Cena: " + zamowienie.CalkowitaKwotaZakupu;
        switch(zamowienie.PostepZamowienia){
            case 0:
                {
                    transform.GetChild(2).gameObject.GetComponent<Text>().text = "Status: W trakcie realizacji";
                    break;
                }
            case 1:
                {
                    transform.GetChild(2).gameObject.GetComponent<Text>().text = "Status: Gotowy do odbioru";
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

    }

    public void Szczegoly()
    {
        parent.GetComponent<ZamowieniaUzytkownika>().UstawDoWyswietlenia(zamowienie);
        parent.GetComponent<ZamowieniaUzytkownika>().WyswietlSzczegoly();
    }


}
