using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCharAtBallGroundPoint : MonoBehaviour
{
    
    [SerializeField] private GameObject playerBall;
    private SphereCollider ballCollider;
    private RaycastHit _hit;
    [SerializeField] private LayerMask _mask;

    private float characterYOffset;
    private float characterZOffet;
    
    // Start is called before the first frame update
    void Awake()
    {
        ballCollider = playerBall.GetComponent<SphereCollider>();
    }

    private void Update()
    {
        float distanceToGround = ballCollider.radius + .02f;
        Vector3 dirToGround = playerBall.transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(playerBall.transform.position, Vector3.down, out _hit, distanceToGround, _mask))
        {
            characterYOffset = Vector3.Distance(playerBall.transform.position, _hit.point);
            // Debug.DrawLine(playerBall.transform.position, _hit.point, Color.red);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Gives ample space as ball grows and shrinks
        characterZOffet = (ballCollider.radius/2) + .5f;
        
        //Don't like bruting in the negatives but hey math
        Vector3 adjustedPos = new Vector3(0,-characterYOffset, -characterZOffet);

        transform.localPosition = adjustedPos;
    }
}
