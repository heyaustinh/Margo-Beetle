using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float distanceFromKatamari = 0.1f;

    [SerializeField] 
    private Transform _camTarget;
    
    [SerializeField] 
    private float angle, yOffset, orbitSpeed, planeDistance;

    [SerializeField] private bool expandWithKatamari = false;

    private float startingPlaneDistance, desiredPlaneDistance;
    private float startingYOffset, desiredYOffset;
    private float startingSize;
    
    // Start is called before the first frame update
    void Start()
    {
        //Game manager get size
        startingPlaneDistance = planeDistance;
        startingYOffset = yOffset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //desiredPlaneDistance = startingPlaneDistance + katamar
    }

    public void Obrit(float dir)
    {
        angle += dir * orbitSpeed;
    }
}
