
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnShipEvent : MonoBehaviour
{
    public static ReturnShipEvent instance { get; set; }
    public int EnergyBlock = 0;
    private void Awake()
    {
        if(instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ReturnShip()
    {
        SceneManager.LoadScene("Start");
    }
    
}
