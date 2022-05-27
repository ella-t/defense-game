using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerControl : MonoBehaviour
{

    // Inspector
    [SerializeField]
    private float _attackTime;
    [SerializeField]
    private Tower _tower;

    // Public info
    public bool Attacking { get; private set; }
    public float AttackTimeRemaining { get; private set; }
    public float MaxAttackTime { get { return _attackTime; } private set { _attackTime = value; } }

    private void Start()
    {
        AttackTimeRemaining = 0;
    }

    private void Update()
    {
        if (Attacking)
        {
            AttackTimeRemaining -= Time.deltaTime;
            if (AttackTimeRemaining <= 0 || Input.GetMouseButton(0) == false)
            {
                Attacking = false;
            }
        }    
    }

    private void OnMouseDown()
    {
        AttackTimeRemaining = _attackTime;
        Attacking = true;
    }

}
