using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SamTekst : MonoBehaviour, IOnStart {

    public float doStartThingsAndReturnHeightOfThisElement()
    {
        int length = gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text.Length;
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(100, (length / 51 + 1) * 28);
        return (length / 51 + 1) * 28 + 80;
    }
	
    public void Start()
    {
        Debug.Log(doStartThingsAndReturnHeightOfThisElement());
    }

}
