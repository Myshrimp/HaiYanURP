using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject[] HealthBar;
    [SerializeField] GameObject[] AdditionalHealthBar;
    [SerializeField] Player player;
    [SerializeField] Transform spawnPoint;
   public static PlayerManager instance;
    private int index=-1;
    private bool isDead = false;
    private bool DeadEvent = false;
    private void Start()
    {
        instance = this;
    }
    public void TakeDamage()
    {
        player.GetComponent<Player>().ChangeHealth(-1);
        index++; 
       
        if (index<HealthBar.Length) { HealthBar[index].SetActive(false);
            if (index == HealthBar.Length - 1) { isDead = true; }
        }
        else index = HealthBar.Length - 1;


    }
    public void Recover()
    {     
        if (index >= 0) { HealthBar[index].SetActive(true); index--; }
        
    }
    private void PlayerDie()
    {
        Debug.Log("Player died");
    }
    public void TpPlayer(Transform TpPoint)
    {
        player.gameObject.transform.position = TpPoint.position;
    }
    public void PlayerSpawn()
    {
        foreach (var bar in HealthBar) bar.SetActive(true);
        index = -1;
        player.GetComponent<Player>().Recspawn();
        TpPlayer(spawnPoint);
    }
}
