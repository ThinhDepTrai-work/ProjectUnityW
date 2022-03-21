using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Door : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask layerMask;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("IsOpen", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("IsOpen", false);
        }
    }


}
