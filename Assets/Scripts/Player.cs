using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]int health;
    [SerializeField]StatusMachine statusMachine;
    public int GetHealth()
    {
        return health;
    }
    public void ChangeHealth(int diff)
    {
        health += diff;
        Debug.Log("player current health:" + health);
    }
    public void GetHit()
    {
        statusMachine.ToGetHit();
    }
    public void Recspawn()
    {
        health = 5;
    }
}
