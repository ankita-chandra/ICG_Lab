using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    #region ---------------------------- Private Variables ----------------------------
    [SerializeField] private BarModel barModel = new BarModel();
    #endregion --------------------------------------------------------

    #region ---------------------------- Public Variables ----------------------------
    #endregion --------------------------------------------------------

    #region ---------------------------- Private Methods ----------------------------

    private void Start()
    {
        barModel.speed = 5f;
    }
    #endregion --------------------------------------------------------

    #region ---------------------------- Public Methods ----------------------------
    public float GetSpeed()
    {
        return barModel.speed;
    }
    #endregion --------------------------------------------------------
}