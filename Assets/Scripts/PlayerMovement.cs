using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] Animation clip;
	[SerializeField] GameObject attackzone;
	[SerializeField] float WaitforSecondAttackTime=0.1f;
	[SerializeField] float attackCoolDown = 0.5f;
	[SerializeField] float attackCoolDownOffSet = 0.1f;
	[SerializeField] bool SecondAttack=true;
	[SerializeField] float ComboKeyPressedMoment = 0f;
	private bool readyToAttack = true;
	private float timer = 0;

    public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	private bool isAttack=false;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
    private void Start()
    {
        attackzone.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
        if (InputManager.instance.IsDisabled()) return;
        int horizontal = 0;
		if (Input.GetKey(KeyCode.A)) { horizontal = -1; Debug.Log("Key A pressed" + horizontal); }
		if (Input.GetKey(KeyCode.D)) horizontal = 1;	
		horizontalMove = horizontal * runSpeed;
		Debug.Log(horizontalMove);
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (InputManager.instance.GetKeyDownSpace())
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		if (InputManager.instance.GetCrouch())
		{
			crouch = true;
		} else if (InputManager.instance.GetCrouchUp())
		{
			crouch = false;
		}

		if(Input.GetKeyDown(KeyCode.Mouse0) &&readyToAttack)
		{
			StartAttack();
            readyToAttack = false;
        }

	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
	

	void StopAttack()
	{
		isAttack = false;	
		attackzone.SetActive(false);
    }
	void StartAttack()
	{
		isAttack = true;
		Invoke(nameof(ReadyToAttack), attackCoolDown+attackCoolDownOffSet);
        attackzone.SetActive(true);
        StartCoroutine(StopAttack_IE());
    }

	IEnumerator StopAttack_IE()
	{
		yield return new WaitForSeconds(attackCoolDown);
		StopAttack();
		StopCoroutine(StopAttack_IE());
	}
	public bool IsPlayerAttack()
	{
		return isAttack;
	}
	private void ReadyToAttack()
	{
		readyToAttack = true;
	}
}
