using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Transmmission : MonoBehaviour {

	float tiempo=0.0f;
	float t_inicial=0.0f;
	GameObject player;
	GameObject target;
	bool onTouch =false;
	void Update(){
		tiempo+=Time.deltaTime;

		if(OVRInput.Get(OVRInput.Button.One)==false && onTouch ==false)
			t_inicial=0;
	}

	void OnTriggerStay( Collider victim){
        Debug.Log("Entro al trigger");
        //returns true if the primary button (Typically "A") 
        if (OVRInput.Get(OVRInput.Button.One))
        {
            Debug.Log("A esta presionada");
            if (victim.gameObject.GetComponent<NetworkIdentity>() == true)
            {
                t_inicial = tiempo;
                player = victim.gameObject;
                onTouch = true;
                Debug.Log("Capturo a la victima");
            }
        }
        
        if (victim.gameObject.transform.name == "Dummy1")
        {
            Debug.Log("Esta dentro del target");
            target = victim.gameObject; 
			transmission();
			onTouch = true;
		}
	}

	void onTriggerExit(){
		onTouch = false;
	}

	void transmission(){
		if(tiempo-t_inicial<300.0f && !OVRInput.Get(OVRInput.Button.One)){

			Vector3 pos=player.transform.position;
			Quaternion rot = player.transform.rotation;
			player.transform.SetPositionAndRotation(target.transform.position,target.transform.rotation);
			target.transform.SetPositionAndRotation(pos,rot);
		}
	}
}
