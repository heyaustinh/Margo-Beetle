using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
{
    Idle,
    RollingForward,
    RollingSideWays,
    RollingBackward,
    Impact,
    RotatingRight,
    RotatingLeft
}

public class CharacterAnimator : MonoBehaviour
{
    private CharacterState state;
    private PlayerInput _playerInput;
    private Animator _animator;

    void Awake()
    {
        _playerInput = GetComponentInParent<PlayerInput>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        _animator.SetFloat("VelX",_playerInput.moveHorizontal);
        _animator.SetFloat("VelY",_playerInput.moveVertical);
    }

    private void SetAnimationState(CharacterState state)
    {
        this.state = state;

        switch (state)
        {
            case CharacterState.Idle:
                Debug.Log("Character Idling");
                break;
            case CharacterState.RollingForward:
                Debug.Log("RollingForward");
                break;
            case CharacterState.RollingBackward:
                Debug.Log("Rolling Backwards");
                break;
        }
    }
}
