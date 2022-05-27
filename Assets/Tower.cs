using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    // Inspector
    [SerializeField]
    private float _turnSpeed;
    [SerializeField]
    private float _fireRate;
    [SerializeField]
    private float _targetRange;
    [SerializeField]
    private Bullet _projectile;

    // Memory
    private Enemy _target;
    private float _timeToNextFire;

    private void Start()
    {
        _timeToNextFire = 0;
    }

    private void Update()
    {
        CheckForTarget();
        TrackTarget();

        _timeToNextFire -= Time.deltaTime;
        if (_timeToNextFire <= 0)
        {
            if (_target != null)
            {
                _timeToNextFire = _fireRate;
                Bullet bullet = Instantiate(_projectile, transform.position, transform.rotation);
                bullet.Target = _target;
            }
        }

        LoseTarget();
    }

    private void CheckForTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy e in enemies)
        {
            float d = Vector2.Distance(transform.position, e.transform.position);
            if (d <= _targetRange)
            {
                if (_target == null)
                {
                    _target = e;
                }
                else if (d < Vector2.Distance(transform.position, _target.transform.position))
                {
                    _target = e;
                }
            }
        }
    }

    private void TrackTarget()
    {
        if (_target != null)
        {
            transform.up = _target.transform.position - transform.position;
        }
    }

    private void LoseTarget()
    {
        if (_target != null)
        {
            if (Vector2.Distance(transform.position, _target.transform.position) > _targetRange)
            {
                _target = null;
            }
        }
    }

}
