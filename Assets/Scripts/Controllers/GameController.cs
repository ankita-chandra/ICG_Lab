using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region ---------------------------- Private Variables ----------------------------
    [SerializeField] private GameModel gameModel = new GameModel();
    [SerializeField] private SpawnBarController spawnBarController;
    [SerializeField] private GameView gameView;
    [SerializeField] private PlayerController playerController;
    private State state;
    #endregion --------------------------------------------------------

    #region ---------------------------- Public Variables ----------------------------
    #endregion --------------------------------------------------------

    #region ---------------------------- Private Methods ----------------------------

    private void Start()
    {
        Screen.fullScreen = false;
        state = State.REST;
        gameModel.score = 0;
        gameModel.incrementValue = 2;
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && state != State.GAME)
        {
            gameView.StartGame();
        }
    }

    private void DisplayScore()
    {
        gameView.DisplayScore();
    }

    private void CheckScore()
    {
        if (gameModel.score % 10 == 0)
        {
            spawnBarController.UpdateSpeed();
        }
    }
    #endregion --------------------------------------------------------

    #region ---------------------------- Public Methods ----------------------------
    public void IncrementScore()
    {
        gameModel.score += gameModel.incrementValue;
        CheckScore();
        DisplayScore();
        StartCoroutine(playerController.ChangeColor());
    }

    public int GetScore()
    {
        return gameModel.score;
    }

    public void EndGame()
    {
        state = State.OVER;
        gameView.GameOverPanel();
    }

    public State GetState()
    {
        return state;
    }

    public void ChangeStateToGame()
    {
        state = State.GAME;
    }
    #endregion --------------------------------------------------------
}