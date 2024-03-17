using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource AU_attack01;
    [SerializeField] AudioSource AU_attack02;
    [SerializeField] AudioSource AU_hurt;
    [SerializeField] AudioSource AU_die;
    [SerializeField] AudioSource AU_fallOnGround;
    [SerializeField] AudioSource AU_jump;
    [SerializeField] AudioSource AU_walk;
    public void PlayAttack01()
    {
        AU_attack01.Play();
    }
    public void StopAttack01()
    {
        AU_attack01.Stop();
    }
    public void AUPlayAttack02()
    {
        AU_attack02.Play();
    }
    public void AUStopAttack02()
    {
        AU_attack02.Stop();
    }
    public void AUPlayHurt()
    {
        AU_hurt.Play();
    }
    public void AUStopHurt()
    {
        AU_hurt.Stop();
    }
    public void AUPlayDie()
    {
        AU_die.Play();
    }
    public void AUStopDie()
    {
        AU_die.Stop();
    }
    public void AUPlayFall()
    {
        AU_fallOnGround.Play();
    }
    public void AUStopFall()
    {
        AU_fallOnGround.Stop();
    }
    public void AUPlayJump()
    {
        AU_jump.Play();
    }
    public void AUStopJump()
    {
        AU_jump.Stop();
    }
    public void AUPlayWalk()
    {
        AU_walk.Play();
    }
    public void AUStopWalk()
    {
        AU_walk.Stop();
    }
}
