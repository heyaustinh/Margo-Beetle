using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    [SerializeField] private Vector3 playerTransformOffset;
    private Transform playerPos;

    [SerializeField] private Transform ballPosition;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ballPosition.position + playerTransformOffset;
    }
}
