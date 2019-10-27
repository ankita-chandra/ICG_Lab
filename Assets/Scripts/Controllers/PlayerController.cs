using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region ---------------------------- Private Variables ----------------------------
    [SerializeField] private PlayerModel playerModel = new PlayerModel();
    [SerializeField] private GameController gameController;
    [SerializeField] private PlayerView playerView;
    #endregion --------------------------------------------------------

    #region ---------------------------- Public Variables ----------------------------
    #endregion --------------------------------------------------------

    #region ---------------------------- Private Methods ----------------------------

    private void Start()
    {
        playerModel.pos = new Vector2(0, -3f);
        playerModel.vel = 5f;
        playerModel.boundX = 2f;
    }
    #endregion --------------------------------------------------------

    #region ---------------------------- Public Methods ----------------------------
    public void UpdatePlayerVelocity()
    {
        playerModel.vel = 8f;
    }

    public float GetBoundX()
    {
        return playerModel.boundX;
    }

    public float GetVelocity()
    {
        return playerModel.vel;
    }

    public Color GetColor()
    {
        Color temp = Color.white;
        int r = Random.Range(1, 5);
        switch (r)
        {
            case 1:
                temp = Color.red;
                break;

            case 2:
                temp = Color.green;
                break;

            case 3:
                temp = Color.blue;
                break;

            case 4:
                temp = Color.yellow;
                break;
        }
        return temp;
    }

    public void IncrementScore()
    {
        gameController.IncrementScore();
    }

    public IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.2f);
        playerView.ChangeColor();
    }

    public void GameOver()
    {
        gameController.EndGame();
    }

    public State GetState()
    {
        return gameController.GetState();
    }
    #endregion --------------------------------------------------------
}