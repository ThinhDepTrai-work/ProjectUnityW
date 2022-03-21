using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogButtonTrigger : MonoBehaviour
{
    public Button btn;

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
