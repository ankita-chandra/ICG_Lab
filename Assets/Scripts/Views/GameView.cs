using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameView : MonoBehaviour
{
    #region ---------------------------- Private Variables ----------------------------
    [SerializeField] private GameController gameController;
    [SerializeField] private Text score;
    [SerializeField] private GameObject gameOverPanel, startPanel;
    #endregion --------------------------------------------------------

    #region ---------------------------- Public Variables ----------------------------
    #endregion --------------------------------------------------------

    #region ---------------------------- Private Methods ----------------------------

    private void Start()
    {
        score.text = "0";
    }
    #endregion --------------------------------------------------------

    #region ---------------------------- Public Methods ----------------------------
    public void DisplayScore()
    {
        score.text = "" + gameController.GetScore();
    }

    public void GameOverPanel()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void StartGame()
    {
        if (gameController.GetState() == State.OVER)
        {
            SceneManager.LoadScene("Game");
        }
        if (gameController.GetState() == State.REST)
        {
            startPanel.SetActive(false);
            gameOverPanel.SetActive(false);
            Time.timeScale = 1;
        }
        gameController.ChangeStateToGame();
    }
    #endregion --------------------------------------------------------
}