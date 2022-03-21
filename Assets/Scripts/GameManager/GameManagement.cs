using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    public static GameManagement gameManager { get; private set; }

    public GameObject player;
    public GameObject Canvas;

    private CinemachineVirtualCamera cinemachine;
    public DateTime JobDone;
    public DateTime GymDone;

    public bool firstTime = false;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        cinemachine = GameObject.FindGameObjectWithTag("Cinemachine").GetComponent<CinemachineVirtualCamera>();
        cinemachine.Follow = player.transform;
    }
    private void Update()
    {

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Ice_Cream_Store"))
        {
            if (JobDone == GameObject.Find("GameClock").GetComponent<DateTimeSystem>().GetDay())
            {
                GameObject.Find("GameTrigger").SetActive(false);
            }
            else
            {
                GameObject.Find("GameTrigger").SetActive(true);
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gym"))
        {
            if (GymDone == GameObject.Find("GameClock").GetComponent<DateTimeSystem>().GetDay())
            {
                GameObject.Find("GameTrigger").SetActive(false);
            }
            else
            {
                GameObject.Find("GameTrigger").SetActive(true);
            }
        }
    }
    public void setDayJob(DateTime date)
    {
        this.JobDone = date;
    }
    public void setDayGym(DateTime date)
    {
        this.GymDone = date;
    }
    public void getTheFirstTime()
    {
        this.firstTime = true;
    }

}
