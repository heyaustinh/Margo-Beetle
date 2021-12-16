using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithCamera : MonoBehaviour
{
    [SerializeField] private Transform playerCam;
    [SerializeField] private float rotationSpeed;
    
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion dir = Quaternion.AngleAxis(playerCam.rotation.eulerAngles.y, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, dir, Time.fixedDeltaTime * rotationSpeed);
    }
}
