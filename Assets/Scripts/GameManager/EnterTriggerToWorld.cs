using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterTriggerToWorld : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject board;
    public Button button;

    private void Start()
    {
        board.SetActive(false);
    }
    private void Awake()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Hospital"))
        {
            var sceneManage = GameObject.Find("GameManagement").GetComponent<SceneManagement>();
            button.onClick.AddListener(sceneManage.FromHospitalToWorld);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Home"))
        {
            var sceneManage = GameObject.Find("GameManagement").GetComponent<SceneManagement>();
            button.onClick.AddListener(sceneManage.FromWorldToHome);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Ice_Cream_Store"))
        {
            var sceneManage = GameObject.Find("GameManagement").GetComponent<SceneManagement>();
            button.onClick.AddListener(sceneManage.FromIceCreamToWorld);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gym"))
        {
            var sceneManage = GameObject.Find("GameManagement").GetComponent<SceneManagement>();
            button.onClick.AddListener(sceneManage.FromGymToWorld);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            board.SetActive(true);
        }
    }
    public void nope()
    {
        board.SetActive(false);
    }
}
