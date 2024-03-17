using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAward : MonoBehaviour
{
    public bool awarded = false;
    [SerializeField] GameObject award_trigger;
    private void Awake()
    {
        GameObject award = GameObject.Find("ReturnShipEvent");
        if(award != null )awarded = true;
        if(awarded)
        {
            Debug.Log("Awarded");
            award_trigger.SetActive(true);
        }
    }
}
