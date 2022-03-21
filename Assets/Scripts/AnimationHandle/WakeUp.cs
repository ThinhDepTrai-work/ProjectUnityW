using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WakeUp : MonoBehaviour
{
    public GameObject player;
    public GameObject sleepPlayer;
    public GameObject sleepBed;
    public Button button;

    public void WakeTheFUp()
    {
        sleepBed.SetActive(false);
        sleepPlayer.SetActive(false);
        player.SetActive(true);
        button.gameObject.SetActive(false);
    }
}
