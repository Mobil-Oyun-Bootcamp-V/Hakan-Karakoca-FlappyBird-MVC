using System;
using System.Collections;
using System.Collections.Generic;
using Player.Scripts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameStates
    { 
        Prepare,
        InGame,
        EndGame
    }

    public static GameManager gameManager;
    private GameStates _currentGameState;

    public GameStates CurrentGameStates
    {
        get { return _currentGameState; }
        set
        {
            switch (value)
            {
                case GameStates.Prepare:
                    break;
                case GameStates.InGame:
                    break;
                case GameStates.EndGame:
                    break;
            }

            _currentGameState = value;
        }
    }
    
    public PlayerModel _model;
    public PlayerView _view;
    public PlayerController _controller;

    public GameObject background1;
    public GameObject background2;
    
    private Rigidbody2D b1Physic;
    private Rigidbody2D b2Physic;
    
    public float backgroundSpeed;
    private float backgroundLength;
    
    public GameObject obstackle;
    private GameObject[] obstackles;
    public int obstackleCount;

    int counter=0;
    float tempTime = 0;

    void Start()
    {
        _controller = new PlayerController(_view);
        
        
       //arkaplan rigidbody yüklenir.
       //Obstackle'lar oluşturulur.
       
        b1Physic = background1.GetComponent<Rigidbody2D>();
        b2Physic = background2.GetComponent<Rigidbody2D>();

        b1Physic.velocity = new Vector2(backgroundSpeed, 0);
        b2Physic.velocity = new Vector2(backgroundSpeed, 0);

        backgroundLength = background1.GetComponent<BoxCollider2D>().size.x;

        obstackles = new GameObject[obstackleCount];
        for (int i = 0; i < obstackles.Length; i++)
        {
            obstackles[i] = Instantiate(obstackle, new Vector2(30, 5), Quaternion.identity);
            Rigidbody2D obstacklePhysic = obstackles[i].AddComponent<Rigidbody2D>();
            obstacklePhysic.gravityScale = 0;
            obstacklePhysic.velocity = new Vector2(backgroundSpeed, 0);
        }
    }

    private void InMainGame()
    {
        _currentGameState = GameStates.InGame;
    }
    private void InEndGame()
    {
        _currentGameState = GameStates.EndGame;
    }
    private void Update()
    {
        switch (CurrentGameStates)
        {
            case GameStates.Prepare:
                _view.OnGameStart += InMainGame;
                break;
            case GameStates.InGame:
                _view.OnGameOver += InEndGame;
                break;
            case GameStates.EndGame:
                break;
        }
    }
}
