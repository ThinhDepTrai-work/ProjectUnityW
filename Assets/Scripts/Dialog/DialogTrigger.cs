using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialogue;
    public GameObject button;

    public void Start()
    {
        button.SetActive(false);
    }

    public void TriggerDialogue()
    {
        button.SetActive(false);
        FindObjectOfType<DialogManager>().StartDialog(dialogue);
        
    }
}
