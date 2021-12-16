using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerUIElement;
    [SerializeField] private Color warningColor;
    [SerializeField] private Color cautionColor;
    private Text timeText;
    private GameManager _gameManager;

    private float UItimeremaing;

    private float cautionTime;
    private float warningTime;

    // Start is called before the first frame update
    private void Awake()
    {
        _gameManager = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>();

        UItimeremaing = _gameManager.timeRemaining;

        cautionTime = UItimeremaing * .66f;
        warningTime = UItimeremaing * .33f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UItimeremaing = _gameManager.timeRemaining;
        int minutes = Mathf.FloorToInt(UItimeremaing / 60f);
        int seconds = Mathf.FloorToInt(UItimeremaing % 60f);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (UItimeremaing < cautionTime)
        {
            timerUIElement.color = cautionColor;
        }
        if(UItimeremaing < warningTime)
        {
            timerUIElement.color = warningColor;
        }

        timerUIElement.text = niceTime;
    }
}
