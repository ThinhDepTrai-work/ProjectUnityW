using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDialogTrigger : MonoBehaviour
{
    public Dialog dialogue;
    public GameObject button;

    public GameObject NPC;

    public GameObject DialogTriggerZone;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialogue, onCompleted);
        button.SetActive(false);
        DialogTriggerZone.SetActive(false);
    }

    public void onCompleted() {
        NPC.GetComponent<Boss>().TriggerRunLeft();
    }
}

