using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFatherActive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GetComponentInParent<Dialogue>().isDialogueFinished()==true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInParent<Dialogue>().isDialogueFinished() ==true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
