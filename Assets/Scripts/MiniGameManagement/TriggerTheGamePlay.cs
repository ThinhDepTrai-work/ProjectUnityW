using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerTheGamePlay : MonoBehaviour
{
    public GameObject board;
    public Button button;

    public GameObject gameCanvas;


    private void Awake()
    {
        board.SetActive(false);
    }

    public void StartGame()
    {
        gameCanvas.SetActive(true);
        GameObject.Find("GamePlay").GetComponent<GameplayHandler>().PlayTheGame();
        board.SetActive(false);
    }

    public void nope()
    {
        board.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            board.SetActive(true);
        }
    }
}
