using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{

    float currentTime = 0f;
    float startTimming = 3f;

    public Text countDownText;
    public Button PlayButton;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTimming;
        PlayButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        countDownText.text = currentTime.ToString("0");

        if (currentTime < 0)
        {
            countDownText.text = "";
            PlayButton.interactable = true;
        }
    }
}
