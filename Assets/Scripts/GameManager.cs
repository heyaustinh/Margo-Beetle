using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Paused,
    Timeout,
    Won,
    Gameover,
    Playing
}
public class GameManager : MonoBehaviour
{
    //State Management
    public static GameManager manager;
    public GameState state;
    
    //Time management
    public float timeRemaining;
    private int minutes;
    private int seconds;
    
    public bool infiniteTime; 
    
    //Size management
    public float desiredSize;
    public float startingSize;

    //Player management
    public float startingSpeed;

    private KatamariBallManager _ballManager;
    
    //menuManager
    [SerializeField] private GameObject optionsMenu;
    
    //menuAudio
    [SerializeField] private AudioSource levelMusicSource;


    [SerializeField] private AudioSource pauseMusicSwitch;
    [SerializeField] private AudioSource pauseFXSource;
    [SerializeField] private AudioClip pauseFXClip;

    // Start is called before the first frame update
    void Awake()
    {
        levelMusicSource.Play();
        
        if (timeRemaining < 0)
        {
            infiniteTime = true;
        }
        manager = this;
    }

    private void Start()
    {
        SetState(GameState.Playing);
    }

    // Update is called once per frame
    void Update()
    {
        CountTimer();
        HandleState();
    }

    void HandleState()
    {
        switch (state)
        {
            case GameState.Playing:
                //Win condition?
               if (timeRemaining == 0)
               {
                   SetState(GameState.Timeout);
               }

               if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7"))
               {
                   SetState(GameState.Paused);
               }
               break;
            
            case GameState.Paused:
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7"))
                {
                    SetState(GameState.Playing);
                }
                break;
        }
    }
    
    void CountTimer()
    {
        timeRemaining -= Time.deltaTime;
    }

    public void SetState(GameState state)
    {
        CancelInvoke("DecideGamover");
        this.state = state;

        switch (state)
        {
            case GameState.Playing:
                pauseMusicSwitch.volume = 0f;
                levelMusicSource.volume = .1f;
                Time.timeScale = 1;
                optionsMenu.SetActive(false);
                break;
            case GameState.Paused:
                //play audio clip
                levelMusicSource.volume = 0f;
                pauseMusicSwitch.volume = .4f;
                pauseFXSource.PlayOneShot(pauseFXClip);
                //slowdown music
                Time.timeScale = 0;
                optionsMenu.SetActive(true);
                break;
            case GameState.Timeout:
                //Handle UI?
                Invoke("DecideGameover", 3);
                break;
            case GameState.Gameover:
            case GameState.Won:
                //Other things
                Invoke("NextScene", 4);
                break;
        }

    }

    void NextScene()
    {
        if (state == GameState.Won)
        {
            int nextLevel = 1 + SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void DecideGameover()
    {
        if (WinCondition())
        {
            SetState(GameState.Won);
        }
        else
        {
            SetState(GameState.Gameover);
        }
    }

    bool WinCondition()
    {
        return _ballManager.GetSize() - startingSize >= desiredSize;
    }
}
