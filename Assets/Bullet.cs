using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{

    // Inspector
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _lifespan;

    // Memory
    public Enemy Target { get; set; }
    public Collider2D Collider { get; private set; }
    private float _timeTilDeath;

    private void Start()
    {
        Collider = GetComponent<Collider2D>();
        _timeTilDeath = _lifespan;
    }

    private void Update()
    {
        transform.Translate(0, _moveSpeed * Time.deltaTime, 0, Space.Self);

        if (Target != null)
        {
            if (Collider.bounds.Intersects(Target.Collider.bounds))
            {
                Target.Die();
                Destroy(gameObject);
            }
        }

        _timeTilDeath -= _lifespan * Time.deltaTime;
        if (_timeTilDeath <= 0)
        {
            Destroy(gameObject);
        }
    }

}
