using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleSizeUI : MonoBehaviour
{
    private GameManager _gameManager;
    
    [SerializeField] private Image sizeShape;
    [SerializeField] private KatamariBallManager _ballManager;

    //Need to have a game manager pass this field in
    [SerializeField] private float desiredSizeIncrease;
    private float startingSize;
    
    void Start()
    {
        //Expensive but I think this may be a better way to keep from being serialize dependent
        _gameManager = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>();
        
        desiredSizeIncrease = _gameManager.desiredSize;
        startingSize = _ballManager.GetSize();
    }
    void Update()
    {
        //This broken
        float curSize = _ballManager.GetSize();;
        sizeShape.rectTransform.localScale =
            Vector3.Lerp(Vector3.zero + (Vector3.one*.2f), Vector3.one, (curSize - startingSize) / desiredSizeIncrease);
    }
}
