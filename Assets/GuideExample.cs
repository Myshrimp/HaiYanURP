using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuideExample : MonoBehaviour
{
    [SerializeField] GameObject TriggerZone;
    private void Update()
    {
        if(GetComponent<TriggerReminder>().ReminderIcon.active==true)
        {
            Debug.Log("Reeminder active");
            GetComponent<TriggerReminder>().TriggerDialogue();
            TriggerZone.SetActive(false);
        }
    }
}
