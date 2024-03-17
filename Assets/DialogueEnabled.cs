using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class DialogueEnabled : MonoBehaviour
{
    [SerializeField] GameObject DialogueCue;

    private void Update()
    {
        if (this.GetComponent<TriggerReminder>().ReminderIcon.active==true)
        {
            if(Input.GetKeyDown(KeyCode.F) && this.GetComponent<TriggerReminder>().NeedInteract == true)
            {
                this.GetComponent<TriggerReminder>().TriggerDialogue();            
            }
            else if(this.GetComponent<TriggerReminder>().NeedInteract == false)
            {
                this.GetComponent<TriggerReminder>().TriggerDialogue();
            }
        }
    }
}
