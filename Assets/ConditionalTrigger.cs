using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalTrigger : MonoBehaviour
{
    private bool isTriggerValid=false;
    public bool onObjectDisappear = false;
    public bool onTriggerActivate = false;
    [SerializeField] GameObject gameobj;
    [SerializeField] GameObject[] ToActivate;
    private void Start()
    {
        foreach (var obj in ToActivate)
        {
            obj.SetActive(false);
        }
    }
    private void Update()
    {
        if(onTriggerActivate && isTriggerValid)
        {
            foreach(var obj in ToActivate)
            {
                obj.SetActive(true);
            }
            gameObject.SetActive(false);
        }
        if(onObjectDisappear)
        {
            if(!gameobj.activeSelf) {
            isTriggerValid = true;
            }
        }
    }
    public void Reset()
    {
        isTriggerValid=false;
    }
}
