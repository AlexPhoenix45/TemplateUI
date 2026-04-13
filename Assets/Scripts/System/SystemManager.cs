using System;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public enum GameStatus
    {
        BOOT,
        HOME,
        INGAME,
        MAX,
    }

    public static SystemManager Instance;
    private GameMode[] gameMode = null;
    private GameMode currentGameMode = null;
    private GameStatus currentGameStatus = GameStatus.BOOT;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        gameMode = new GameMode[(int)GameStatus.MAX];
        gameMode[0] = new Boot();
        gameMode[1] = new Home();
        gameMode[2] = new Ingame();
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        ChangeStatus(GameStatus.BOOT);
    }

    private void Update()
    {
        currentGameMode.Update();
    }

    public static void ChangeStatus(GameStatus gameStatus)
    {
        Instance._ChangeStatus(gameStatus);
    }

    private void _ChangeStatus(GameStatus _gameStatus)
    {
        currentGameStatus = _gameStatus;
        currentGameMode = gameMode[(int)_gameStatus];
        
        currentGameMode.Init();
    }
}