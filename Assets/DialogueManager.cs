using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private void Awake()
    {
        instance = this; 
    }
    public void TriggerDialogue(GameObject Dialogue,GameObject DialogueText)
    {
        Dialogue.SetActive(true);
        DialogueText.SetActive(true);
        InputManager.instance.Disable();
    }
}
