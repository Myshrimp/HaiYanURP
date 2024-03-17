using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueRiser : MonoBehaviour
{
    [SerializeField] GameObject Dialogue;
    [SerializeField] GameObject DialogueText;
    public bool ShouldRise = false;
    private void Awake()
    {
        Dialogue.SetActive(false);
        DialogueText.SetActive(false);
    }


}
