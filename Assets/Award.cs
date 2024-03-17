using UnityEngine;

public class Award : MonoBehaviour
{
    [SerializeField] GameObject award;
    [SerializeField] Transform awardpos;
    private void Start()
    {
        award.SetActive(false);
    }
    void Update()
    {
        if(GetComponent<Monster>().IsDead())
        {
            award.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
