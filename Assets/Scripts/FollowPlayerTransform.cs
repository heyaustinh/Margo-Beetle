using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerTransform : MonoBehaviour
{
    [SerializeField] private Transform playerTarget;
    // Start is called before the first frame update
    void Awake()
    {
        playerTarget.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerTarget.position = transform.position;
    }
}
