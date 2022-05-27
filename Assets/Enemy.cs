using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour
{

    // Inspector
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private DefenseCore _targetCore;
    [SerializeField]
    private int _damage;

    // Memory
    private Vector2 _pathPosition;

    // Public info
    public Collider2D Collider { get; private set; }

    private void Start()
    {
        Collider = GetComponent<Collider2D>();
        if (_targetCore == null)
        {
            _targetCore = FindObjectOfType<DefenseCore>();
        }
    }

    private void Update()
    {
        _pathPosition = NextPathPosition();
        MoveToPath();

        if(Collider.bounds.Intersects(_targetCore.Collider.bounds))
        {
            _targetCore.Damage(_damage);
            Die();
        }
    }

    private Vector2 NextPathPosition()
    {
        return _targetCore.gameObject.transform.position;
    }

    private void MoveToPath()
    {
        transform.up = _pathPosition - new Vector2(transform.position.x, transform.position.y);
        transform.Translate(0, _moveSpeed * Time.deltaTime, 0, Space.Self);
    }

    public void Die()
    {
        Destroy(gameObject);
    }    

}
