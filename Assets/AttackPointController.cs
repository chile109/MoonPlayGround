using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPointController : MonoBehaviour
{
    public LayerMask CollisionLayer;
    private float _radius = 0.2f;

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
            hit[0].GetComponent<BoxerController>().OnInjured();
            gameObject.SetActive(false);
        }
    }
}
