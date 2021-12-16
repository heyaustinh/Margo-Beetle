using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepper : MonoBehaviour
{
    private AudioSource footStepSource;
    [SerializeField] private AudioClip[] footstepClips;
    
    // Start is called before the first frame update
    void Awake()
    {
        footStepSource = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FootStep()
    {
        AudioClip clip = GetRandomClip();
        footStepSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        return footstepClips[UnityEngine.Random.Range(0, footstepClips.Length)];
    }
}
