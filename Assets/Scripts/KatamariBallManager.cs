using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Assertions.Must;
using Random = System.Random;

public class KatamariBallManager : MonoBehaviour
{
    //Talks with game manager
    private GameManager _gameManager;
    
    private float pickUpReward = 0.03f;
    private const float pickUpInfluence = 0.03f;
    private const float pickUpSpeedIncrease = 0.05f;

    private SphereCollider katamariCollider;
    private Transform katarmiBall;
    
    public float katamariSpeed;
    public float katamariRadius;

    public float totalPickUpSize;

    [SerializeField] private float startingRadius;

    [SerializeField] private AudioClip collectSound;
    
    [SerializeField] private DisplayItemPickupUI _displayItemPickupUI;

    void Awake()
    {
        _gameManager = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>();
        
        katamariCollider = GetComponent<SphereCollider>();
        katarmiBall = GetComponent<Transform>();
        katamariSpeed = _gameManager.startingSpeed;
        startingRadius = _gameManager.startingSize;
        katamariRadius = startingRadius;
    }

    private void Start()
    {
        initScale();
    }
    
    public float GetSize()
    {
        return katamariCollider.radius + totalPickUpSize;
    }

    public void OnPickUp(PickUpItem pickUpItem)
    {
        pickUpReward = pickUpItem.itemPickupReward;
        
        katamariCollider.radius += pickUpItem.itemPickUpRadius * pickUpReward;
        Vector3 newRadius = new Vector3(katamariCollider.radius, katamariCollider.radius, katamariCollider.radius);
        
        //Didn't really like it scaling everything, Could create a secondary object holder clone that sources the 
        //rotation and position but that seems silly
        //katarmiBall.localScale = newRadius/2;

        totalPickUpSize += pickUpItem.itemPickUpRadius * pickUpInfluence;
        katamariSpeed += pickUpItem.itemPickUpRadius * pickUpSpeedIncrease;

        Camera.main.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(.75f, 1.2f);
        Camera.main.GetComponent<AudioSource>().PlayOneShot(collectSound, 0.3f);
        
        _displayItemPickupUI.OnPickup(pickUpItem.propName);
    }

    void initScale()
    {
        Vector3 localScaleStarting = new Vector3(startingRadius, startingRadius, startingRadius);
        
        katarmiBall.localScale = localScaleStarting;
        //katamariCollider.radius = startingRadius;
    }
}
