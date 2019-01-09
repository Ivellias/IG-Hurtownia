using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterSmashedChecker : MonoBehaviour {

	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameObject.GetComponent<Button>().onClick.Invoke();
        }
	}

}
