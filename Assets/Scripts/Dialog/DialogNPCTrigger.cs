using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogNPCTrigger : MonoBehaviour
{
    public Button btn;
    public Dialog dialog;

    // Default: hide btn
    private void Start()
    {
        btn.gameObject.SetActive(false);
    }

    // Show btn
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var dialogTriger = btn.GetComponent<DialogTrigger>();

            dialogTriger.dialogue = dialog;

            btn.gameObject.SetActive(true);
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
