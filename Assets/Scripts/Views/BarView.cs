using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarView : MonoBehaviour
{
    #region ---------------------------- Private Variables ----------------------------
    [SerializeField] public BarController barController;
    #endregion --------------------------------------------------------

    #region ---------------------------- Public Variables ----------------------------
    #endregion --------------------------------------------------------

    #region ---------------------------- Private Methods ----------------------------
    private void Update()
    {
        MoveDown();
        CheckBoundary();
    }

    private void MoveDown()
    {
        transform.Translate(Vector2.down * Time.deltaTime * barController.GetSpeed());
    }

    private void CheckBoundary()
    {
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
    #endregion --------------------------------------------------------

    #region ---------------------------- Public Methods ----------------------------
    #endregion --------------------------------------------------------
}