using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    #region ---------------------------- Private Variables ----------------------------
    [SerializeField] private PlayerController playerController;
    [SerializeField] Rigidbody2D player;
    #endregion --------------------------------------------------------

    #region ---------------------------- Public Variables ----------------------------
    #endregion --------------------------------------------------------

    #region ---------------------------- Private Methods ----------------------------

    private void Start()
    {
        if (playerController.GetState() == State.GAME)
        {
            ChangeColor();
            StartCoroutine(Rotate());
        }
    }

    private IEnumerator Rotate()
    {
        while (true)
        {
            yield return new WaitForSeconds(0);
            transform.Rotate(0, 0, 5);
        }
    }

    private void ChangeTag(Color col)
    {
        if (col == Color.green)
        {
            gameObject.tag = "Green";
        }
        else if (col == Color.red)
        {
            gameObject.tag = "Red";
        }
        else if (col == Color.blue)
        {
            gameObject.tag = "Blue";
        }
        else if (col == Color.yellow)
        {
            gameObject.tag = "Yellow";
        }
    }

    private void Update()
    {
        if (playerController.GetState() == State.GAME)
        {
            TakeInput();
        }
        if (Input.GetKeyDown("q"))
        {
            Application.Quit();
        }
    }

    private void TakeInput()
    {
        if (Input.GetKey("left"))
        {
            if (transform.position.x > -playerController.GetBoundX())
            {
                MoveLeft();
            }
        }
        else if (Input.GetKey("right"))
        {
            if (transform.position.x < playerController.GetBoundX())
            {
                MoveRight();
            }
        }
    }

    private void MoveLeft()
    {
        Vector2 temp = transform.position;
        temp.x -= playerController.GetVelocity() * Time.deltaTime;
        transform.position = temp;
    }

    private void MoveRight()
    {
        Vector2 temp = transform.position;
        temp.x += playerController.GetVelocity() * Time.deltaTime;
        transform.position = temp;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (gameObject.tag == col.gameObject.tag)
        {
            Destroy(col.gameObject);
            playerController.IncrementScore();
        }
        else
        {
            playerController.GameOver();
        }
    }
    #endregion --------------------------------------------------------

    #region ---------------------------- Public Methods ----------------------------
    public void ChangeColor()
    {
        Color col = playerController.GetColor();
        ChangeTag(col);
        gameObject.GetComponent<Renderer>().material.color = col;
    }
    #endregion --------------------------------------------------------
}