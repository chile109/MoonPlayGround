using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rack
{
    Idle,
    Blocking,
    Punch,
    Kick,
    Jump,
    Hurt,
}

public class BoxerController : MonoBehaviour
{
    public Rack RackStatus = Rack.Idle;
    public Animator BoxerAni;
    public BoxerDataSO data;

    private float _attackRatio = 1f; //time between attacks
    private float _damagePerAttack = 2f; //damage each attack deals
    private float _hitPoints = 10f; //when units or buildings suffer damage, they lose hitpoints
    private float _jumpHeight = 1f;
    private float _reachField = 0.5f;
    private float _speed = 5f; //movement speed

    void Start()
    {
        _attackRatio = data.AttackRatio;
        _damagePerAttack = data.DamagePerAttack;
        _hitPoints = data.HitPoints;
        _jumpHeight = data.JumpHeight;
        _reachField = data.ReachField;
        _speed = data.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            PerformPunch();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            PerformBlocking(true);
        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            PerformBlocking(false);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            PerformKick();
        }
    }

    void PerformBlocking(bool isBlocking)
    {
        Debug.Log("PerformBlocking");
        BoxerAni.SetBool("Blocking", isBlocking);
    }

    void PerformPunch()
    {
        Debug.Log("PerformPunch");
        BoxerAni.SetTrigger("Punch");
    }

    void PerformKick()
    {
        Debug.Log("PerformKick");
        BoxerAni.SetTrigger("Kick");
    }

    void PerformJump()
    {

    }
}
