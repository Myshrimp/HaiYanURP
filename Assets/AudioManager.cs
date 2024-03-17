using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
   public void PlayClick()
    {
        GetComponent<AudioSource>().Play();
    }
}
