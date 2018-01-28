using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FollowMeCamera : NetworkBehaviour
{
    public float damping = 1;
    Vector3 offset;

    void Start()
    {
        offset = this.transform.position - transform.position;
    }

    void LateUpdate()
    {
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = this.transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);

        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        transform.position = this.transform.position - (rotation * offset);

        transform.LookAt(this.transform);
    }
}