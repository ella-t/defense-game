using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class PlayerAttackAnim : MonoBehaviour
{

    // Memory
    private ParticleSystem _particles;
    private PlayerControl _player;
    private float _intensity;

    private void Start()
    {
        _particles = GetComponent<ParticleSystem>();
        _player = FindObjectOfType<PlayerControl>();
        _intensity = 1.0f;
    }

    private void Update()
    {
        _intensity = Mathf.Lerp(0, 1, _player.AttackTimeRemaining / _player.MaxAttackTime);

        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (_player.Attacking)
            _particles.Play();
        else
            _particles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }


}
