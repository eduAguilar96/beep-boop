using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Translate : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = GameObject.Find("spawn1").transform.position;
	}
	
}
