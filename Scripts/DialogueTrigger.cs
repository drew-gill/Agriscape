using UnityEngine;
using System.Collections;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void triggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }

}
