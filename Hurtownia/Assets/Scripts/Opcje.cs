using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opcje : MonoBehaviour, IOnStart {

    public GameObject zmianaHasla;

    public float doStartThingsAndReturnHeightOfThisElement()
    {
        zmianaHasla.GetComponent<ZmianaHasla>().WyjscieZmianaHasla();
        return 400f;
    }

}
