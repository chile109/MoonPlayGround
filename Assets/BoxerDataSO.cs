using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewBoxerData", menuName = "Unity Moon/Boxer Data")]
public class BoxerDataSO : ScriptableObject
{
    [Header("Constitution")]
    public GameObject associatedPrefab;
    public float AttackRatio = 1f; //time between attacks
    public int DamagePerAttack = 2; //damage each attack deals
    public int HitPoints = 100; //when units or buildings suffer damage, they lose hitpoints
    public float JumpHeight = 1f;
    public float ReachField = 0.5f;
    public float Speed = 5f; //movement speed
}
