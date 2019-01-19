using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObiektUzytkownik : MonoBehaviour
{

    private Uzytkownik uzytkownik;

    private GameObject poleSzczegoly;
    public void SetPoleSzczegoly(GameObject x)
    {
        poleSzczegoly = x;
    }

    public void UstawUzytkownika(Uzytkownik doUstawienia)
    {
        uzytkownik = doUstawienia;

        

        switch (uzytkownik.PoziomDostepu)
        {
            case 0:
                {
                    transform.GetChild(0).GetComponent<Text>().text = "!!! Prośba o dołączenie";
                    transform.GetChild(1).GetComponent<Text>().text = uzytkownik.Login;
                    transform.GetChild(2).GetComponent<Image>().enabled = false;
                    break;
                }
            case 1:
                {
                    transform.GetChild(0).GetComponent<Text>().text = uzytkownik.Login;
                    transform.GetChild(1).GetComponent<Text>().text = "NIP: "+ uzytkownik.NIP.ToString();
                    transform.GetChild(2).GetComponent<Image>().enabled = false;
                    break;
                }
            case 2:
                {
                    transform.GetChild(0).GetComponent<Text>().text = uzytkownik.Login;
                    transform.GetChild(1).GetComponent<Text>().text = "ID pracownika: " + uzytkownik.ID;
                    transform.GetChild(2).GetComponent<Image>().enabled = false;
                    break;
                }
            case 3:
                {
                    transform.GetChild(0).GetComponent<Text>().text = uzytkownik.Login;
                    transform.GetChild(1).GetComponent<Text>().text = "ID pracownika: " + uzytkownik.ID;
                    transform.GetChild(2).GetComponent<Image>().enabled = true;
                    break;
                }
            default:
                {
                    transform.GetChild(2).gameObject.GetComponent<Text>().text = "Status: BRAK STATUSU";
                    break;
                }
        }

    }

    public void Szczegoly()
    {
        poleSzczegoly.GetComponent<Uzytkownicy>().UstawDoWyswietlenia(uzytkownik);
        poleSzczegoly.GetComponent<Uzytkownicy>().WyswietlSzczegoly();
    }


}
