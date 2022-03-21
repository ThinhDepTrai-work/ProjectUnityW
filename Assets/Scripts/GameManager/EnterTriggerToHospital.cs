using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterTriggerToHospital : MonoBehaviour
{
    public GameObject board;
    public Button button;

    private void Start()
    {
        board.SetActive(false);
    }
    private void Awake()
    {
        var sceneManage = GameObject.Find("GameManagement").GetComponent<SceneManagement>();
        button.onClick.AddListener(sceneManage.FromWorldToHospital);
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
