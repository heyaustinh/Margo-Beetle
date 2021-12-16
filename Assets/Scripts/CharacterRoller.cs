using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRoller : MonoBehaviour
{
    private KatamariBallManager _katamariBallManager;
    
    private PlayerInput _playerInput;
    private CharacterGrounder _grounder;
    [SerializeField] 
    private float speed;

    [SerializeField][Range(1.0f, 10f)] private float slowAssistAmount;
    [SerializeField] private Transform cameraTransform;
    
    
    public Rigidbody characterRollerRB;

    private bool isGrounded;

    // Start is called before the first frame update
    void Awake()
    {
        _grounder = GetComponent<CharacterGrounder>();
        _playerInput = GetComponentInParent<PlayerInput>();
        characterRollerRB = GetComponent<Rigidbody>();
        _katamariBallManager = GetComponent<KatamariBallManager>();
    }

    private void Start()
    {
        speed = _katamariBallManager.katamariSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //needs grounded condition
        if (_playerInput.playerMoving && _grounder.isGrounded)
        {
            Move();
        }
        
        if (!_playerInput.playerMoving && _grounder.isGrounded)
        {
            SlowDownAssist();
        }
        
    }
    
    private void Move()
    {
        var flatForward = new Vector3(cameraTransform.transform.forward.x, 0, cameraTransform.transform.forward.z)
            .normalized;
        
        var flatHorizontal = new Vector3(cameraTransform.transform.right.x, 0, cameraTransform.transform.right.z)
            .normalized;
        
        characterRollerRB.AddForce(flatHorizontal * (speed * _playerInput.moveHorizontal), ForceMode.Impulse);
        characterRollerRB.AddForce(flatForward * (speed * _playerInput.moveVertical), ForceMode.Impulse);
    }

    private void SlowDownAssist()
    {
        characterRollerRB.velocity  = characterRollerRB.velocity / slowAssistAmount;
    }
}
