using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBarView : MonoBehaviour
{
    #region ---------------------------- Private Variables ----------------------------
    [SerializeField] private GameObject bar1, bar2, bar3, bar4;
    [SerializeField] private SpawnBarController spawnBarController;
    #endregion --------------------------------------------------------

    #region ---------------------------- Public Variables ----------------------------
    #endregion --------------------------------------------------------

    #region ---------------------------- Private Methods ----------------------------
    private GameObject GetRandomObj()
    {
        int r = Random.Range(1, 5);
        GameObject bar = bar1;
        switch (r)
        {
            case 1:
                bar = bar1;
                break;

            case 2:
                bar = bar2;
                break;

            case 3:
                bar = bar3;
                break;
            case 4:
                bar = bar4;
                break;
        }
        return bar;
    }
    #endregion --------------------------------------------------------

    #region ---------------------------- Public Methods ----------------------------
    public void Spawn()
    {
        var obj = Instantiate(GetRandomObj(), spawnBarController.GetSpawnPos(), Quaternion.identity);
        obj.GetComponent<BarView>().barController = spawnBarController.barController;
    }
    #endregion --------------------------------------------------------
}