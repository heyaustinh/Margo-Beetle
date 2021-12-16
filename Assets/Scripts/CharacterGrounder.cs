using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounder : MonoBehaviour
{
    public bool isGrounded;

    [SerializeField] private float maxDistanceFromGround;
    [SerializeField] private LayerMask _layerMask;

    private KatamariBallManager _ballManager;

    private void Awake()
    {
        _ballManager = GetComponent<KatamariBallManager>();
    }

    void Update()
    {

        maxDistanceFromGround = _ballManager.GetSize() + .02f; 
        RaycastHit hit;

        isGrounded = (Physics.Raycast(transform.position, Vector3.down, out hit, maxDistanceFromGround, _layerMask));
    }
}
