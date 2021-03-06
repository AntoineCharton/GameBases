﻿using UnityEngine;
using GZ.Utils;
public class CharacterAnimationController : MonoBehaviour
{
    public Animator Animator;
    public IGroundableObject GroundableObject;
    public float LongIdleTime = 5;
    Vector3 lastPosition = Vector3.zero;
    float previousSpeed;

    private float idleTimer = 0;
    void Start()
    {
        GroundableObject = GetComponent<IGroundableObject>() as IGroundableObject;
    }

    // Update is called once per frame
    void Update()
    {
        var speed = (transform.position - lastPosition).magnitude;
        if (speed != 0)
            speed /= Time.deltaTime;
        lastPosition = transform.position;
        var finalspeed = Mathf.Lerp(previousSpeed, speed, 0.5f);
        previousSpeed = speed;
        //Debug.Log(finalspeed + " " + speed);
        Animator.SetFloat("Speed", finalspeed * 10);

        if (finalspeed > 0 && GroundableObject.IsGrounded())
        {
            Animator.SetBool("IsLongIdle", false);
            idleTimer = 0;
        }
        else
            idleTimer += Time.deltaTime;

        if (idleTimer > LongIdleTime)
            Animator.SetBool("IsLongIdle", true);

        if (GroundableObject.IsGrounded())
            Animator.SetBool("IsGrounded", true);
        else
            Animator.SetBool("IsGrounded", false);

    }

    public void Kick()
    {
        Animator.SetBool("Kick", true);
    }

    public void StopKick()
    {
        Animator.SetBool("Kick", false);
    }

    public void Punch()
    {
        Animator.SetBool("Punch", true);
    }

    public void StopPunch()
    {
        Animator.SetBool("Punch", false);
    }

    public void LookAround()
    {
        Animator.SetBool("LookAround", true);
    }

    public void StopLookAround()
    {
        Animator.SetBool("LookAround", false);
    }
}
