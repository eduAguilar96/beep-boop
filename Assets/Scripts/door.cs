using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

    public static int buttonCount = 0;
    static int buttonsRequired = 3;

	// Use this for initialization
	void Start () {
        buttonCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (buttonCount >= buttonsRequired) {
            DestroyObject(gameObject);
        }
	}
}
