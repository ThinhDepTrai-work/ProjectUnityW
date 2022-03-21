using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public GameObject canvas;
    public PlayableDirector load;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }
    private void OnEnable()
    {
        load.stopped += LoadingDone;
    }
    void LoadingDone(PlayableDirector director)
    {
        canvas.SetActive(true);
    }
}
