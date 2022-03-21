using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Playables;
using static Constant;

public class SceneManagement : MonoBehaviour
{

    public GameObject player;
    public PlayableDirector loading;
    public Animator transition;
    public AudioManager audioManager;

    bool fromWorldtoHome = false;
    bool fromWorldtoIceCream = false;
    bool fromWorldToHospital = false;
    bool fromWorldToGym = false;
    bool fromHome = false;
    bool fromIce = false;
    bool fromHospital = false;
    bool fromGym = false;
    bool moving = false;


    private void FixedUpdate()
    {
        transition = GameObject.Find("Circle").GetComponent<Animator>();
        if(moving)
        {
            // From AnyWhere to World
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMap") && fromHome)
            {
                player.transform.position = GameObject.FindGameObjectWithTag("EntranceHome").GetComponent<Transform>().position;
                fromHome = false;
                moving = false;
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMap") && fromIce)
            {
                player.transform.position = GameObject.Find("IceEntranceSpawn").GetComponent<Transform>().position;
                fromIce = false;
                moving = false;
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMap") && fromHospital)
            {
                player.transform.position = GameObject.Find("HospitalEntranceSpawn").GetComponent<Transform>().position;
                fromHospital = false;
                moving = false;
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMap") && fromGym)
            {
                player.transform.position = GameObject.Find("GymEntranceSpawn").GetComponent<Transform>().position;
                fromGym = false;
                moving = false;
            }
            // From World To AnyWhere
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Home") && fromWorldtoHome)
            {
                player.transform.position = GameObject.Find("Respawn").GetComponent<Transform>().position;
                fromWorldtoHome = false;
                moving = false;
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Ice_Cream_Store") && fromWorldtoIceCream)
            {
                player.transform.position = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>().position;
                fromWorldtoIceCream = false;
                moving = false;
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Hospital") && fromWorldToHospital)
            {
                player.transform.position = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>().position;
                fromWorldToHospital = false;
                moving = false;
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gym") && fromWorldToGym)
            {
                player.transform.position = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>().position;
                fromWorldToGym = false;
                moving = false;
            }
        }
    }

    private void OnEnable()
    {
        loading.stopped += LoadingDone;
    }
    // Loading Done
    public void LoadingDone(PlayableDirector director)
    {
        StartCoroutine(LoadLevel("Home"));
        audioManager.PlaySound(SoundName.HomeTheme);
        fromWorldtoHome = true;
        moving = true;
    }
    // From Anywhere
    public void FromHomeToWorld()
    {
        StartCoroutine(LoadLevel("MainMap"));
        audioManager.PlaySound(SoundName.IntroTheme);
        fromHome = true;
        moving = true;
    }
    public void FromIceCreamToWorld()
    {
        StartCoroutine(LoadLevel("MainMap"));
        audioManager.PlaySound(SoundName.IntroTheme);
        fromIce = true;
        moving = true;
    }
    public void FromHospitalToWorld()
    {
        StartCoroutine(LoadLevel("MainMap"));
        audioManager.PlaySound(SoundName.IntroTheme);
        fromHospital = true;
        moving = true;
    }
    public void FromGymToWorld()
    {
        StartCoroutine(LoadLevel("MainMap"));
        audioManager.PlaySound(SoundName.IntroTheme);
        fromGym = true;
        moving = true;
    }
    // From World
    public void FromWorldToHome()
    {
        StartCoroutine(LoadLevel("Home"));
        audioManager.PlaySound(SoundName.HomeTheme);
        fromWorldtoHome = true;
        moving = true;
    }
    public void FromWorldToGym()
    {
        StartCoroutine(LoadLevel("Gym"));
        audioManager.PlaySound(SoundName.GymTheme);
        fromWorldToGym = true;
        moving = true;
    }
    public void FromWorldToIceCream()
    {
        StartCoroutine(LoadLevel("Ice_Cream_Store"));
        audioManager.PlaySound(SoundName.IceCreamTheme);
        fromWorldtoIceCream = true;
        moving = true;
    }
    public void FromWorldToHospital()
    {
        StartCoroutine(LoadLevel("Hospital"));
        audioManager.PlaySound(SoundName.HospitalTheme);
        fromWorldToHospital = true;
        moving = true;
    }
    IEnumerator LoadLevel(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneName);
    }
}
