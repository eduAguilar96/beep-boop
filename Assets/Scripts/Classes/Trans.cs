using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trans : MonoBehaviour
{

    float tiempo = 0.0f;
    float t_inicial = 0.0f;
    GameObject player;
    GameObject target;
    bool onTouch = false;

    void Update()
    {
        tiempo += Time.deltaTime;
        Debug.Log(tiempo);
        if (OVRInput.Get(OVRInput.Button.One) == false && onTouch==false)
        {
            t_inicial = 0;
        }
    }

    void OnTriggerStay(Collider victim)
    {
        //returns true if the primary button (Typically "A") 
        if (OVRInput.Get(OVRInput.Button.One) == true)
        {
            if (victim.gameObject.GetComponent<Light>() == true)
            {
                t_inicial = tiempo;
                player = victim.gameObject;

            }
        }
        if (victim.gameObject.GetComponent<Rigidbody>() == true)
        {
            onTouch = true;
            target = victim.gameObject;
            transmission();
        }
    }

    void OnTriggerExit(Collider other)
    {
        onTouch = false;
    }

    void transmission()
    {
        if (tiempo - t_inicial < 10.0f && !OVRInput.Get(OVRInput.Button.One))
        {
            Vector3 pos = player.transform.position;
            Quaternion rot = player.transform.rotation;
            //robotStuff=player.transform;
            player.transform.SetPositionAndRotation(target.transform.position, target.transform.rotation);
            target.transform.SetPositionAndRotation(pos, rot);
            Debug.Log("s " + t_inicial);
            t_inicial = 0;
        }
    }
}
