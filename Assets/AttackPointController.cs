using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPointController : MonoBehaviour
{
    public LayerMask CollisionLayer;
    private float _radius = 0.2f;
    private int _damage = 0;

    public void Init(int damage)
    {
        _damage = damage;
    }
    // Update is called once per frame
    void Update()
    {
        CheckCollision();
    }

    private void CheckCollision()
    {
        var hit = Physics.OverlapSphere(gameObject.transform.position, _radius, CollisionLayer);

        if (hit.Length > 0)
        {
            hit[0].GetComponent<BoxerController>().OnInjured(_damage);
            gameObject.SetActive(false);
        }
    }
}
