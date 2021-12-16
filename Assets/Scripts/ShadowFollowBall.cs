using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowFollowBall : MonoBehaviour
{
    [SerializeField] private GameObject katamariBall;
    [SerializeField] private float yOffset;

    [SerializeField] private CharacterGrounder _grounder;

    private SpriteRenderer shadowMain;
    private SpriteRenderer shadowSecondary;
    
    // Start is called before the first frame update

    private void Awake()
    {
        transform.localScale = katamariBall.transform.localScale;

        shadowMain = GetComponent<SpriteRenderer>();
        shadowSecondary = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_grounder.isGrounded)
        {
            shadowMain.enabled = true;
            shadowSecondary.enabled = true;
        }
        else
        {
            shadowMain.enabled = false;
            shadowSecondary.enabled = false;
        }
        float yoffSetScale = katamariBall.transform.localScale.y;
        Vector3 offset = new Vector3(0, -yoffSetScale + .04f, 0);

        transform.position = katamariBall.transform.position + offset;
        transform.localScale = katamariBall.transform.localScale;
        
        
    }
}
