using System.Collections;
using UnityEngine;

[RequireComponent(typeof(StatusMachine))]
public class AnimController : MonoBehaviour
{
    [SerializeField] private PlayerAnimParams_scr animParams;
    [SerializeField] private Animator animator;
    [SerializeField] private float WaitforSecondAttackTime = 0.6f;
    [SerializeField] float ComboTime = 0.3f;
    private StatusMachine statusMachine;
    private float timer = 0f;
    private float comboKeyFrame = 0f;
    private bool isCombo = false;
    private bool startTimer = false;
    private void Start()
    {
        animParams = new PlayerAnimParams_scr();
        statusMachine = GetComponent<StatusMachine>();
    }
    private void Update()
    {
        string status = statusMachine.GetStatus();
        animator.SetFloat("Y_Velocity",GetComponent<Rigidbody2D>().velocity.y);
        animator.SetBool(animParams.IsOnland.ToString(), statusMachine.IsPlayerOnland());
        if (status==StatusMachine.statusList.Attacking.ToString())
        {
            startTimer = true;
            animator.SetBool(animParams.IsAttack, true);
           
        }
        else
        {         
            animator.SetBool(animParams.IsAttack, false);
        }

        if(startTimer)
        {
            timer += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log(timer);
                if (timer < WaitforSecondAttackTime && timer >= 0.2f &&!isCombo)
                {
                    Debug.Log("Combo pressed");
                    isCombo = true;
                    animator.SetBool("IsCombo", true);
                    Invoke(nameof(CeaseCombo), ComboTime);
                }
            }
        }
        if(timer>=WaitforSecondAttackTime)
        {
            timer = 0;
            startTimer = false;
        }
       if(status==StatusMachine.statusList.Walking.ToString())
        {
            animator.SetBool("IsWalking", true);
        }
        if (status == StatusMachine.statusList.Walking.ToString())
        {
            animator.SetBool("IsWalking",false);
        }
        if(status==StatusMachine.statusList.GetHit.ToString())
        {
            animator.SetBool(animParams.IsHit,true);
        }
        else
        {
            animator.SetBool(animParams.IsHit, false);
        }
        if(statusMachine.isHitBack())
        {
            animator.SetBool("IsHitBack", true);
        }
        else
        {
            animator.SetBool("IsHitBack", false);
        }

    }

    private void CeaseCombo()
    {
        isCombo = false;
        animator.SetBool("IsCombo", false);
    }
    
}
