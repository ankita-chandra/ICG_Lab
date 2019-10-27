using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBarController : MonoBehaviour
{
    #region ---------------------------- Private Variables ----------------------------
    [SerializeField] private SpawnBarModel spawnBarModel = new SpawnBarModel();
    [SerializeField] private PlayerController playerController;
    [SerializeField] private SpawnBarView spawnBarView;
    [SerializeField] private GameController gameController;
    #endregion --------------------------------------------------------

    #region ---------------------------- Public Variables ----------------------------
    [SerializeField] public BarController barController;
    #endregion --------------------------------------------------------

    #region ---------------------------- Private Methods ----------------------------

    private void Start()
    {
        spawnBarModel.spawnPos = new Vector2(0, 6f);
        spawnBarModel.spawnSpeed = 1.7f;
        StartCoroutine(SpawnBar());
    }

    private IEnumerator SpawnBar()
    {
        while (true)
        {
            if (gameController.GetState() == State.GAME)
            {
                spawnBarView.Spawn();
            }
            yield return new WaitForSeconds(spawnBarModel.spawnSpeed);
        }
    }
    #endregion --------------------------------------------------------

    #region ---------------------------- Public Methods ----------------------------
    public Vector2 GetSpawnPos()
    {
        return spawnBarModel.spawnPos;
    }

    public void UpdateSpeed()
    {
        spawnBarModel.spawnSpeed = 1.3f;
        playerController.UpdatePlayerVelocity();
    }
    #endregion --------------------------------------------------------
}