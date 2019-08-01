using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    //public Text nameText;
    public GameObject dialogueUI;
    public Text dialogueText;

    //public bool DialogueEnabled;

    void Start() {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        //nameText.text = dialogue.name;
        //DialogueEnabled = true;
        dialogueUI.SetActive(true);
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        //StopAllCoroutines();
        //StartCoroutine(SentenceCrawl(sentence));
    }

    //Animate Letters
    IEnumerator SentenceCrawl (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        dialogueUI.SetActive(false);
        //Debug.Log("Convo Ended");
    }
}
