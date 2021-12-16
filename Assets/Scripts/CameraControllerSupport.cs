using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraControllerSupport : MonoBehaviour
{

    private CinemachineFreeLook _freeLook;
    [SerializeField] private PlayerInput _playerInput;
    
    //We couldn't go a project without a string :(
    private string mouseXInputString, mouseYInputString;
    private string controllerXInputString, controllerYInputString;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        _freeLook = GetComponent<CinemachineFreeLook>();

        mouseXInputString = "Mouse X";
        mouseYInputString = "Mouse Y";
        
        controllerXInputString = "Right Stick Horizontal";
        controllerYInputString = "Right Stick Vertical";
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerInput.playerMovingMouse)
        {
            _freeLook.m_YAxis.m_InvertInput = true;
            _freeLook.m_XAxis.m_InputAxisName = mouseXInputString;
            _freeLook.m_YAxis.m_InputAxisName = mouseYInputString;
        }
        else if (_playerInput.playerRotatingCam)
        {
            _freeLook.m_YAxis.m_InvertInput = false;
            _freeLook.m_XAxis.m_InputAxisName = controllerXInputString;
            _freeLook.m_YAxis.m_InputAxisName = controllerYInputString;
           
        }
    }
}
