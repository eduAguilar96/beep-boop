using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playerselect : MonoBehaviour {

	public GameObject VRplayer;
	public GameObject PCplayer;
	public NetworkManager mgr;
	void Start ()
	{
		string model = UnityEngine.XR.XRDevice.model != null ? UnityEngine.XR.XRDevice.model : "";
		if (model.IndexOf("Rift") >= 0) {
			mgr.playerPrefab = VRplayer;
            //Camera.main.enabled = false;
		} 

		else
			mgr.playerPrefab = PCplayer;

	}

}
