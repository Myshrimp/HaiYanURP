using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReminder : MonoBehaviour
{
    [SerializeField] public GameObject ReminderIcon;
    [SerializeField] private GameObject Dialogue;
    [SerializeField] private GameObject DialogueText;
    public bool NeedInteract = true;
    public bool NeedMouseButton0 = true;
    public bool NeedDisableInput = true;
    public bool NeedRepeat = true;
    private void Awake()
    {
        ReminderIcon.SetActive(false);
        Dialogue.SetActive(false);
        DialogueText.SetActive(false);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            ReminderIcon.SetActive(true);
            Debug.Log("Player entered");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ReminderIcon.SetActive(true);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ReminderIcon.SetActive(false);
        }
        
    }

    public void TriggerDialogue()
    {
        
            Dialogue.SetActive(true);
            DialogueText.SetActive(true);
        if(NeedDisableInput)
        {
            InputManager.instance.Disable();
        }
        if (!NeedRepeat)
        {
            this.gameObject.SetActive(false);
        }

    }
}
