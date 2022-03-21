using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogNPCFirstTimeTrigger : MonoBehaviour
{
    public Button btn;
    public Dialog dialog;
    public Dialog firstTimeDialog;

    // Default: hide btn
    private void Start()
    {
        btn.gameObject.SetActive(false);

        if (!GameObject.Find("GameManagement").GetComponent<GameManagement>().firstTime)
        {
            btn.onClick.AddListener(() =>
            {
                GameObject.Find("GameManagement").GetComponent<GameManagement>().getTheFirstTime();
            });
        }
               
    }

    // Show btn
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (!GameObject.Find("GameManagement").GetComponent<GameManagement>().firstTime)
            {
                var dialogTriger = btn.GetComponent<DialogTrigger>();

                dialogTriger.dialogue = firstTimeDialog;

                btn.gameObject.SetActive(true);
            } else
            {
                var dialogTriger = btn.GetComponent<DialogTrigger>();

                dialogTriger.dialogue = dialog;

                btn.gameObject.SetActive(true);
            }   
        }
    }

    // Hide btn
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            btn.gameObject.SetActive(false);
        }
    }
}
