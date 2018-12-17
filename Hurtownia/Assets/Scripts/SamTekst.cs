using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SamTekst : MonoBehaviour, IOnStart {

    public float doStartThingsAndReturnHeightOfThisElement()
    {
        int length = gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text.Length;
        
        return (length / 51 + 1) * 28 + 80;
    }

}
