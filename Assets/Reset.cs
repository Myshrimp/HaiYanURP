
using UnityEngine;

public class Reset : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform boundary_left;
    [SerializeField] Transform boundary_right;
    [SerializeField] Transform playerpos_y;
    public void SceneReset()
    {
        player.transform.localPosition = new Vector2(Random.Range(-231f,-222f), -199.7f);
        transform.localPosition = new Vector2(Random.Range(-231f, -222f), -199.77f);
    }
}
