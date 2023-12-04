using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    Animator _animation;

    private void Awake()
    {
        //on yukleme
        _animation = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    public void Fire()
    {
        _animation.SetTrigger("Fire");
        _animation.SetBool("attack", false);
    }

    public void AttackStart()
    {
        _animation.SetBool("attack",true);
        //_animation.ResetTrigger("Fire");
    }

    public void MovementStart()
    {
        _animation.SetBool("movement", true);
        //_animation.ResetTrigger("Fire");
    }

    public void IdleStart()
    {
        _animation.SetBool("movement", false);
        //_animation.ResetTrigger("Fire");
    }

    
}
