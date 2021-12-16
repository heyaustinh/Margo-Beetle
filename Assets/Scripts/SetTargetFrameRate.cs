using UnityEngine;
 
public class SetTargetFrameRate : MonoBehaviour 
{
    public int targetFrameRate = 90;
 
    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }
}