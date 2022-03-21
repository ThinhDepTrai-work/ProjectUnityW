using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayHandler : MonoBehaviour
{
    public TextMeshProUGUI textm;

    public GameObject customerBoxPrefab;

    private int score;

    private float timeRemaining = 120;

    public bool timerIsRunning = false;

    public TextMeshProUGUI timet;

    public GameObject singleTonCanvas;

    public GameObject gamePlayCanvas;

    public CharacterStat Money;

    private void Awake()
    {
        Transform transform = GameObject.Find("CustomerBox").transform;
        score = 0;
        singleTonCanvas = GameObject.Find("SingletonCavas");
    }

    public void PlayTheGame()
    {
        timerIsRunning = true;
        timeRemaining = 30;
        singleTonCanvas.SetActive(false);
    }

    private void FixedUpdate()
    {
        textm.text = "Score: " + score;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                singleTonCanvas.SetActive(true);
                gamePlayCanvas.SetActive(false);
                GameObject.Find("Player").GetComponent<PlayerStatitics>().GainSomeThing("Money", score * 10);
                GameObject.Find("Player").GetComponent<PlayerStatitics>().GainSomeThing("Stamina", -100);
                GameObject.Find("GameManagement").GetComponent<GameManagement>().setDayJob(GameObject.Find("GameClock").GetComponent<DateTimeSystem>().GetDay());
                score = 0;
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timet.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void GetScore()
    {
        score++;
        Vector3 randomPo = new Vector3(Random.Range(-500,500), 361, 0);
        GameObject newIce = Instantiate(customerBoxPrefab, randomPo, this.transform.rotation) as GameObject;
        newIce.transform.SetParent(GameObject.Find("ListCustomerBox").transform, false);
    }
}
