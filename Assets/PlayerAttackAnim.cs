using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(Collider2D))]
public class PlayerAttackAnim : MonoBehaviour
{

    // Inspector
    [SerializeField]
    private float _moveSpeed;

    // Memory
    private ParticleSystem _particles;
    private PlayerControl _player;
    private float _intensity;
    private Collider2D _collider;

    private void Start()
    {
        _particles = GetComponent<ParticleSystem>();
        _player = FindObjectOfType<PlayerControl>();
        _intensity = 1.0f;
        _collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        _intensity = Mathf.Lerp(0, 1, _player.AttackTimeRemaining / _player.MaxAttackTime);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (_player.Attacking)
        {
            if (_particles.isPlaying == false)
            {
                _particles.Play();
                transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
            }

            //transform.position = Vector3.Lerp(transform.position, new Vector3(mousePos.x, mousePos.y, transform.position.z), _moveSpeed * Time.deltaTime);
            Vector3 moveDir = (new Vector3(mousePos.x, mousePos.y, transform.position.z) - transform.position).normalized;
            transform.Translate(moveDir * _moveSpeed * Time.deltaTime);

            CheckEnemyCollision();
        }
        else
        {
            if (_particles.isPlaying)
            {
                _particles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            }
        }

    }

    private void CheckEnemyCollision()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy e in enemies)
        {
            if (e != null)
            {
                if (_collider.bounds.Intersects(e.Collider.bounds))
                {
                    e.Die();
                    continue;
                }
            }
        }
    }


}
