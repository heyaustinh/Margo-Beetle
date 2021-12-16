using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool playerControlsActive = false;
    public bool playerMovingMouse, playerMoving, playerRotatingCam;
    public float moveHorizontal, moveVertical, rotHorizontal, rotVertical;
    
    void Start()
    {
        playerControlsActive = true;
    }
    
    void Update()
    {
        if (!playerControlsActive)
        {
            return;
        }
        
        CheckControllerConditions();
        SetInputFloats();
    }

    void CheckControllerConditions()
    {
        playerMoving = Mathf.Abs(Input.GetAxis("Horizontal")) > 0 || Mathf.Abs(Input.GetAxis("Vertical"))> 0;
        playerMovingMouse = Mathf.Abs(Input.GetAxis("Mouse X")) > 0 || Mathf.Abs(Input.GetAxis("Mouse Y")) > 0;
        playerRotatingCam = Mathf.Abs(Input.GetAxis("Right Stick Horizontal")) > 0.3 || Mathf.Abs(Input.GetAxis("Right Stick Vertical")) > 0.3;
    }

    void ClearInputs()
    {
        moveHorizontal = 0f;
        moveVertical = 0f;
        rotHorizontal = 0f; 
        rotVertical = 0f;
    }

    void SetInputFloats()
    {
        Vector2 leftStickInput, mouseInput, rightStickInput;
        
        if (playerMoving)
        {
            leftStickInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            moveHorizontal = leftStickInput.x;
            moveVertical = leftStickInput.y;
        }
        else if (playerMovingMouse)
        {
            mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            rotHorizontal = mouseInput.x;
            rotVertical = mouseInput.y;
        }
        else if (playerRotatingCam)
        {
            rightStickInput = new Vector2(Input.GetAxis("Right Stick Horizontal"), Input.GetAxis("Right Stick Vertical"));
            rotHorizontal = rightStickInput.x;
            rotVertical = rightStickInput.y;
        }
        else
        {
            ClearInputs();
        }
    }
}
