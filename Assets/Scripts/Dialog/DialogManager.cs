using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Reflection;

public class DialogManager : MonoBehaviour
{
    // Character name
    public Text nameText;
    // Dialog to display
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    public delegate void Callback();
    Callback callback = null;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog, Callback callback)
    {
        StartDialog(dialog);
        this.callback = callback;
    }

    public void StartDialog(Dialog dialogue)
    {
        animator.SetBool("IsOpen", true);
        sentences = new Queue<string>();

        string readFromFilePath = "jar:file://" + Application.persistentDataPath + $"/{dialogue.fileName}.txt";
        string[] fileLines = File.ReadAllLines(readFromFilePath);

        dialogue.sentences = fileLines;

        // Display character name
        nameText.text = dialogue.name;

        // Clear previous sentences
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        // Display the first sentence
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        // Reach the last sentence => end the dialogue
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        // Stop all coroutines before start a new one
        StopAllCoroutines();
        // Text typing animation
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);

        if (callback != null) {
            callback();
        }
    }
}
