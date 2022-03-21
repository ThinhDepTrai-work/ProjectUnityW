using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour
{
    public GameObject board;
    public Animator animator;

    public GameObject canvas;
    public GameObject player;
    public GameObject sleepingP;
    public GameObject likeon;
    public GameObject wakeup;
    public GameObject clock_kun;
    public GameObject sleepDone;

    private void Awake()
    {
        wakeup.SetActive(false);
        canvas = GameObject.Find("SingletonCavas");
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            board.SetActive(true);
        }
    }
    public void StartSleep()
    {
        canvas.SetActive(false);
        player.SetActive(false);
        sleepingP.SetActive(true);
        likeon.SetActive(true);
        animator.SetTrigger("Sleep");
        board.SetActive(false);
        
        StartCoroutine(Sleeping());
    }
    IEnumerator Sleeping()
    {
        
        yield return new WaitForSeconds(6);
        wakeup.SetActive(true);
    }
    public void WakeUp247()
    {
        canvas.SetActive(true);
        player.SetActive(true);
        sleepingP.SetActive(false);
        likeon.SetActive(false);
        wakeup.SetActive(false);
        GameObject.Find("Player").GetComponent<PlayerStatitics>().RefillStamina();
        player.transform.position = sleepDone.transform.position;
        clock_kun = GameObject.Find("GameClock");
        clock_kun.GetComponent<DateTimeSystem>().GoToNextDay();
    }
    public void nope()
    {
       board.SetActive(false);
    }
}
