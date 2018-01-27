using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

public class PlayerController : MonoBehaviour {
    public int m_PlayerNumber = 1;
    [SerializeField] float movementSpeed= 5.0f;// Used to identify which tank belongs to which player.  This is set by this tank's manager.
    [SerializeField] float turnSpeed = 45.0f;
    [SerializeField] float cameraDistance = 16f;
    [SerializeField] float cameraHeight = 16f;
    Rigidbody localRigidBody;
    Transform mainCamera;
    Vector3 cameraOffset;

    public int m_LocalID = 1;
    
    // Use this for initialization
    void Start () {
        localRigidBody = GetComponent<Rigidbody>();
        cameraOffset = new Vector3(0f, cameraHeight, -cameraDistance);
        mainCamera = Camera.main.transform;
        MoveCamera();
	}
    // Update is called once per frame
    private void FixedUpdate()
    {
        float turnAmount = CrossPlatformInputManager.GetAxis("Horizontal"+ m_PlayerNumber.ToString());
        float moveAmount = CrossPlatformInputManager.GetAxis("Vertical"+ m_PlayerNumber.ToString());
        Vector3 deltaTranslation = transform.position + transform.forward * movementSpeed * moveAmount * Time.deltaTime;
        localRigidBody.MovePosition(deltaTranslation);
        Quaternion deltaRotation = Quaternion.Euler(turnSpeed * new Vector3(0, turnAmount, 0) * Time.deltaTime);
        localRigidBody.MoveRotation(localRigidBody.rotation * deltaRotation);
        MoveCamera();
    }
    
    void MoveCamera()
    {
        mainCamera.position = transform.position;
        mainCamera.rotation = transform.rotation;
        mainCamera.Translate(cameraOffset);
        mainCamera.LookAt(transform);
    }
}
