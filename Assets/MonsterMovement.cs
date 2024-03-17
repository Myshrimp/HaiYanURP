
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] Transform leftBound_Patrol;
    [SerializeField] Transform rightBound_Patrol;
    public bool targeted = false;
    public float Direction = 1f;
    public bool isBoss=false;
    public void Move(float direction)
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + speed * direction * Time.deltaTime, gameObject.transform.position.y);
    }
    private void Update()
    {
        if(isBoss) { return; }
        if (!targeted)
        {
            Patrol();
        }
       
    }
    private void Patrol()
    {
        if(gameObject.transform.position.x>=rightBound_Patrol.position.x)
        {
            Direction = -1;
        }
        if (gameObject.transform.position.x <= leftBound_Patrol.position.x)
        {
            Direction = 1;
        }
        Move(Direction);
    }
  
}
