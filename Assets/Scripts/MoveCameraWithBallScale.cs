using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MoveCameraWithBallScale : MonoBehaviour
{
    
    [SerializeField] private KatamariBallManager _ballManager;
    private float pickUpSize;
    private CinemachineFreeLook freeLook;
    
    [SerializeField] private CinemachineFreeLook.Orbit[] originalOrbits;
    
    // Start is called before the first frame update
    void Awake()
    {
        pickUpSize = _ballManager.totalPickUpSize;
        freeLook = GetComponent<CinemachineFreeLook>();
        originalOrbits = new CinemachineFreeLook.Orbit[freeLook.m_Orbits.Length];

        for (int i = 0; i < freeLook.m_Orbits.Length; i++)
        {
            originalOrbits[i].m_Height = freeLook.m_Orbits[i].m_Height;
            originalOrbits[i].m_Radius = freeLook.m_Orbits[i].m_Radius;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        pickUpSize = _ballManager.totalPickUpSize;

        freeLook.m_Orbits[0].m_Radius = originalOrbits[0].m_Radius + (_ballManager.totalPickUpSize * 3f) ;
        freeLook.m_Orbits[1].m_Radius = originalOrbits[1].m_Radius + (_ballManager.totalPickUpSize * 3f) ;
        freeLook.m_Orbits[2].m_Radius = originalOrbits[2].m_Radius + (_ballManager.totalPickUpSize * 3f)  ;
    }
}
