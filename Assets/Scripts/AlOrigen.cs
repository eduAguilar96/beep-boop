using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class AlOrigen : NetworkBehaviour
{

    public GameObject camarafea1, camarafea2, camarafea3;

    // Use this for initialization
    void Start () {
        Cursor.visible = true;
        string model = UnityEngine.XR.XRDevice.model != null ? UnityEngine.XR.XRDevice.model : "";
        if (model.IndexOf("Rift") >= 0)
        {
            transform.position = new Vector3(0, 34.6f, 0);
            //Camera.main.enabled = false;
        }
        else {
            camarafea1.SetActive(false);
            camarafea2.SetActive(false);
            camarafea3.SetActive(false);
        }
    }

    private void Update()
    {
        string model = UnityEngine.XR.XRDevice.model != null ? UnityEngine.XR.XRDevice.model : "";
        if (model.IndexOf("Rift") >= 0)
        {
            GameObject[] jugadores;
            jugadores = GameObject.FindGameObjectsWithTag("Player");
            Debug.Log(jugadores.Length);
            for (int i = 0; i < jugadores.Length; i++)
            {
                if (jugadores[i].GetComponentInChildren<Light>() == true)
                    jugadores[i].GetComponentInChildren<Light>().enabled = false;
                if (jugadores[i].GetComponent<NetworkIdentity>().isLocalPlayer)
                {
                    jugadores[i].gameObject.SetActive(false);
                }
            }
        }
    }


}
