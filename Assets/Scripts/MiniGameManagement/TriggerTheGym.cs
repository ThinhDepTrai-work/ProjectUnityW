using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTheGym : MonoBehaviour
{
    public GameObject board;
    public GameObject canvas;
    public GameObject gameCanvas;
    public GameObject player;
    public GameObject gamePlayer;
    public Animator gym;

    private void Awake()
    {
        canvas = GameObject.Find("SingletonCavas");
        player = GameObject.Find("Player");
        board.SetActive(false);
    }

    public void EnterTheGame()
    {
        canvas.SetActive(false);
        board.SetActive(false);
        gameCanvas.SetActive(true);
        player.SetActive(false);
        gamePlayer.SetActive(true);
        gym.SetBool("Puch", true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            board.SetActive(true);
        }
    }
    IEnumerator openBoard()
    {
        yield return new WaitForSeconds(1);
    }
    public void EndTheGame()
    {
        gameCanvas.SetActive(false);
        canvas.SetActive(true);
        player.SetActive(true);
        gamePlayer.SetActive(false);
        gym.SetBool("Puch", false);
        GameObject.Find("Player").GetComponent<PlayerStatitics>().GainSomeThing("Money", -50);
        GameObject.Find("Player").GetComponent<PlayerStatitics>().GainSomeThing("Strength", 10);
        GameObject.Find("Player").GetComponent<PlayerStatitics>().GainSomeThing("Stamina", -100);
        GameObject.Find("GameManagement").GetComponent<GameManagement>().setDayGym(GameObject.Find("GameClock").GetComponent<DateTimeSystem>().GetDay());
    }
    public void nope()
    {
        board.SetActive(false );
    }
}
