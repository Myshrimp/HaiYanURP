using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    // Start is called before the first frame update
    [SerializeField] GameObject[] destroyObj;
    [SerializeField] GameObject[] instantiateObj;
    void Start()
    {
        Instance = this;
    }

    public void AddDestroy(GameObject gameobj)
    {
        destroyObj.Append(gameObject);
    }
    public void AddInstantiate(GameObject gameobj)
    {
        instantiateObj.Append(gameObject);
    }
    public void DestroyGameObject(GameObject gameobj)
    {
       Destroy(gameobj);
    }
    public void InstantiateGameObject(GameObject gameobj,Transform pos)
    {
        Instantiate(gameobj,pos);
    }

}
