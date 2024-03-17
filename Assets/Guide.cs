using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    [SerializeField] GameObject Dialogue;
    [SerializeField] GameObject DialogueText;
    public void RiseGuide()
    {
        DialogueManager.instance.TriggerDialogue(Dialogue, DialogueText);
    }
    private void Awake()
    {
        Dialogue.SetActive(false);
        DialogueText.SetActive(false);
    }
}
