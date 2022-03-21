using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimeLineManagement : MonoBehaviour
{

    public PlayableDirector gameIntro;
    public PlayableDirector scriptPlayer;
    public PlayableDirector bossGone;

    public GameObject script;
    public GameObject intro;
    public GameObject bossGo;
    public GameObject canvas;

    public GameObject player;
    public CinemachineVirtualCamera cinemachine;
    // Start is called before the first frame update
    void Start()
    {
        if (gameIntro != null)
        {
            //scriptPlayer.Stop();
            script.SetActive(false);
            gameIntro.Play();
        }
    }
    private void OnEnable()
    {
        gameIntro.stopped += playScripts;
        scriptPlayer.stopped += playGame;
        bossGone.stopped += continuteGame;
    }
    private void playScripts(PlayableDirector director)
    {
        intro.SetActive(false);
        script.SetActive(true);
        scriptPlayer.Play();
    }
    private void playGame(PlayableDirector director)
    {
        SceneManager.LoadScene("Loading");
    }
    private void continuteGame(PlayableDirector director)
    {
        canvas.SetActive(true);
    }
    public void bossDone()
    {
        canvas.SetActive(false);
        bossGo.SetActive(true);
        bossGone.Play();
    }
}
