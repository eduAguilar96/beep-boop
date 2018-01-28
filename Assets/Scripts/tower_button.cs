using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower_button : MonoBehaviour {

    private bool turnedOn = false;
    Material m_Material;

    // Use this for initialization
    void Start () {
        turnedOn = false;
        m_Material = GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !turnedOn) {
            turnedOn = true;
            door.buttonCount++;
            DestroyObject(gameObject);
        }
    }
}
