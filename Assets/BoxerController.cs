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
    public bool IsSanbag = false;
    public Rack RackStatus = Rack.Idle;
    public Animator BoxerAni;
    public BoxerDataSO data;
    public Rigidbody rb;

    public AttackPointController Punch_APC;
    public AttackPointController Kick_APC;

    private float _attackRatio = 1f; //time between attacks
    private float _damagePerAttack = 2f; //damage each attack deals
    private float _hitPoints = 10f; //when units or buildings suffer damage, they lose hitpoints
    private float _jumpHeight = 1f;
    private float _reachField = 0.5f;
    private float _speed = 5f; //movement speed
    private bool _isAir = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RackStatus = Rack.Idle;
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
        if (IsSanbag)
            return;

        if (Input.GetKeyDown(KeyCode.J))
        {
            PerformPunch();
        }
        else if (Input.GetKey(KeyCode.K))
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

        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right * _speed);

        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left * _speed);

        if (Input.GetKey(KeyCode.W))
            PerformJump();
    }

    void PerformBlocking(bool isBlocking)
    {
        // Debug.Log("PerformBlocking");
        BoxerAni.SetBool("Blocking", isBlocking);
    }

    void PerformPunch()
    {
        // Debug.Log("PerformPunch");
        BoxerAni.SetTrigger("Punch");
        Punch_APC.gameObject.SetActive(true);
    }

    void PerformKick()
    {
        // Debug.Log("PerformKick");
        BoxerAni.SetTrigger("Kick");
        Kick_APC.gameObject.SetActive(true);
    }

    void PerformJump()
    {
        if (!_isAir)
        {
            rb.AddForce(new Vector3(0, _jumpHeight, 0), ForceMode.Impulse);
            // BoxerAni.SetInteger("state", currentState = STATE_JUMP);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("OnCollisionEnter");
        rb.useGravity = false;
        _isAir = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        // Debug.Log("OnCollisionExit");
        rb.useGravity = true;
        _isAir = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        // Debug.Log("OnCollisionStay");
        _isAir = false;
    }

    public void OnInjured()
    {
        StartCoroutine(PerformInjured());
    }

    IEnumerator PerformInjured()
    {
        PerformBlocking(true);
        yield return new WaitForSeconds(1f);
        PerformBlocking(false);
        Debug.Log("PerformInjured");
    }
}
