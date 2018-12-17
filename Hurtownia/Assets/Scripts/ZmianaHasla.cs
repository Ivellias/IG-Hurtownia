using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZmianaHasla : MonoBehaviour {

    public GameObject nowe;
    public GameObject powtorz;
    public GameObject dotychczasowe;

    public void Zmien()
    {
        nowe.GetComponent<InputField>().text = "";
        powtorz.GetComponent<InputField>().text = "";
        dotychczasowe.GetComponent<InputField>().text = "";
    }


    public void ZmienHaslo()
    {
        foreach (Transform child in transform) child.gameObject.SetActive(true);
    }

    public void WyjscieZmianaHasla()
    {
        foreach (Transform child in transform) child.gameObject.SetActive(false);
    }

}
