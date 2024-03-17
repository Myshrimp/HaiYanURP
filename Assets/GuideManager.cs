using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization;
using UnityEngine;

public class GuideManager : MonoBehaviour
{
   public static GuideManager instance;
    private bool guide_finished=false;
    public List<GuideExample> guides;
    private void Awake()
    {
        guides = new List<GuideExample>();
        instance = this;
    }
    public bool isGuideFinished()
    {
        if(guides.Count==0)guide_finished = true;
        return guide_finished;
    }
    public void EndGuide(GuideExample guide)
    {
        guides.Remove(guide);
        Debug.Log("guide removed!");
    }
}
