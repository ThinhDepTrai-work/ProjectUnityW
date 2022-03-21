using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarController : MonoBehaviour
{

    // Time variable
    private float timeRemaining;
    private const float timeMax = 1.5f;
    public Slider timeBar;

    // Point variable
    public Text pointShow;
    private int point = 0;

    // Target variable
    public RectTransform target;
    private double minValueTarget = 0.825f;
    private double maxValueTarget = 0.675f;

    // Over Time Announcement
    public Text gameOverShow;
    public Button playButton;
    public bool isEndGame = false;

    public float rnd;
    public Animator animator;


    private void Awake()
    {
        timeRemaining = 0;
        rnd = 0;

    }

    void Update()
    {
        timeBar.value = calculateTimeBarValue();
        Debug.Log(Time.deltaTime);

        if (timeRemaining >= timeMax)
        {
            timeRemaining = 0;
            TargetPosition();
        }
        else if (timeRemaining < timeMax)
        {
            timeRemaining += Time.deltaTime ;
        }

        if(point == 20)
        {
            isEndGame = true;
            Debug.Log(isEndGame);
        }

        if (isEndGame)
        {
            GameObject.Find("GameTrigger").GetComponent<TriggerTheGym>().EndTheGame();
        }
    }

    // Handle reduce time
    float calculateTimeBarValue()
    {
        return (timeRemaining / timeMax);
    }

    // Handle timming click
    public void handleClickPlay()
    {
        if (minValueTarget <= timeRemaining && timeRemaining <= maxValueTarget)
        {
            point += 1;
            pointShow.text = point.ToString();
            rnd += 1;
            animator.SetTrigger("Trigger");
        }
        TargetPosition();
        timeRemaining = 0;
    }

    // Handle change position of target
    public void TargetPosition()
    {
        // Random position target
        int xPosition = Random.Range(170, 430);
        target.anchoredPosition = new Vector3(xPosition, 0, 0);

        minValueTarget = (double)(xPosition/333f) - 0.075;
        maxValueTarget = (double)(xPosition/333f) + 0.075;

    }

}
