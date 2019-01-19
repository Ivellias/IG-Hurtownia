using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObiektUzytkownik : MonoBehaviour
{

    private Uzytkownik uzytkownik;

    private Uzytkownicy poleSzczegoly;
    public void SetPoleSzczegoly(Uzytkownicy x)
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
                    transform.GetChild(2).gameObject.GetComponent<Text>().text = "Status: BRAK STATUSU";
                    break;
                }
        }

    }

    public void Szczegoly()
    {
        poleSzczegoly.UstawDoWyswietlenia(uzytkownik);
        poleSzczegoly.WyswietlSzczegoly();
    }


}
