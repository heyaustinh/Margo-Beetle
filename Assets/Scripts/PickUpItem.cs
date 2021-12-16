using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private KatamariBallManager _katamariBallManager;
    
    private const float moveTowardCenterAmount = 0.15f;
    private const float scaleDownAmount = 0.6f;

    public float itemPickUpRadius;
    public float itemPickupReward = 0.03f;
    public string propName;

    [SerializeField] private bool removeColliderOnPickup = false;

    private GameObject particleFX;
    private Collider _collider;

    // Start is called before the first frame update
    void Awake()
    {
        //Will Downcast to specific collider later
        _collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tag == "PickedUp")
        {
            return;
        }

        _collider.isTrigger = CanPickUp();
    }

    bool CanPickUp()
    {
        return _katamariBallManager.GetSize() > itemPickUpRadius;
    }


    void SinkInwardAndScaleColliders()
    {
        Vector3 ballPosition = transform.parent.position;
        Vector3 towardCenter = (ballPosition - transform.position).normalized * moveTowardCenterAmount;

        transform.position += towardCenter;
        
        //Collider toward center
        towardCenter = transform.worldToLocalMatrix.MultiplyVector(towardCenter);

        float shrinkScale = 1.0f - scaleDownAmount;

        var sphere = _collider as SphereCollider;
        if (sphere)
        {
            sphere.radius *= scaleDownAmount;
            sphere.center += towardCenter;
        }

        var capsule = _collider as CapsuleCollider;
        if (capsule)
        {
            capsule.radius *= scaleDownAmount;
            capsule.height *= scaleDownAmount/2;
            capsule.center += towardCenter;
        }

        var box = _collider as BoxCollider;
        if (box)
        {
            box.size *= scaleDownAmount;
            box.center += towardCenter;
        }
    }

    public void OnTriggerEnter(Collider col)
    {

        if (tag == "PickedUp")
        {
            return;
        }
        
        if (!CanPickUp())
        {
            return;
        }
        
        var other = col.gameObject;
        
        GameObject player;
        if (other.tag == "Player")
        {
            player = other;
        }
        else if(other.tag == "PickedUp")
        {
            player = other.transform.parent.gameObject;
        }
        else
        {
            return;
        }
        
        _collider.isTrigger = false;
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        
        transform.SetParent(player.transform);
        SinkInwardAndScaleColliders();
        if (removeColliderOnPickup)
        {
            _collider.enabled = false;
        }
        
        var rigidbody = GetComponent<Rigidbody>();
        if (rigidbody)
        {
            Destroy(rigidbody);
        }
        tag = "PickedUp";
        _katamariBallManager.OnPickUp(this);

        //Trying
        if (other.tag == "Pickups")
        {
            player = other;
        }
        else if(other.tag == "PickedUp")
        {
            player = other.transform.parent.gameObject;
        }
        else
        {
            return;
        }
        
        _collider.isTrigger = false;
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        
        transform.SetParent(player.transform);
        SinkInwardAndScaleColliders();
        if (removeColliderOnPickup)
        {
            _collider.enabled = false;
        }
        if (rigidbody)
        {
            Destroy(rigidbody);
        }
        tag = "PickedUp";
        _katamariBallManager.OnPickUp(this);
    }
}
