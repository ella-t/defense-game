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
    [SerializeField]
    private float _towerCooldown;

    // Public info
    public bool Attacking { get; private set; }
    public float AttackTimeRemaining { get; private set; }
    public float MaxAttackTime { get { return _attackTime; } private set { _attackTime = value; } }

    // Memory
    private Collider2D _collider;
    private float _towerCooldownRemaining;

    private void Start()
    {
        AttackTimeRemaining = 0;
        _collider = GetComponent<Collider2D>();
        _towerCooldownRemaining = 0;
    }

    private void Update()
    {
        if (_towerCooldownRemaining <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlaceTower();
            }
        }
        else
        {
            _towerCooldownRemaining -= Time.deltaTime;
        }
        
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

    private void PlaceTower()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (_collider.bounds.Contains(new Vector3(mousePos.x, mousePos.y, transform.position.z)) == false)
        {
            _towerCooldownRemaining = _towerCooldown;
            Instantiate(_tower, new Vector3(mousePos.x, mousePos.y, transform.position.z), Quaternion.identity);
        }
    }

}
