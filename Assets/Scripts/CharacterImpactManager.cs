using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CharacterImpactManager : MonoBehaviour
{

    [SerializeField] private AudioSource crashSource;
    [SerializeField] private float impactSpeedThreshold;
    [SerializeField] private AudioClip impactSFX;
    [SerializeField] private float impactForce;
    private CharacterRoller _roller;
    private Rigidbody playerRB;

    private float currentSpeed;

    private bool canImpact;
    
    private void Awake()
    {
        _roller = GetComponent<CharacterRoller>();
        playerRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        currentSpeed = playerRB.velocity.magnitude; ;
        canImpact = currentSpeed > impactSpeedThreshold;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (canImpact && other.gameObject.tag == "Impactable" || canImpact && other.gameObject.tag == "Pickups" )
        {
            Vector3 dir = other.contacts[0].point - transform.position;
            dir = -dir.normalized;
            playerRB.AddForce(dir*impactForce);
            playerRB.AddForce(Vector3.up*impactForce);

            crashSource.pitch = UnityEngine.Random.Range(.8f, 1.2f);
            crashSource.PlayOneShot(impactSFX);
        }
    }
}
