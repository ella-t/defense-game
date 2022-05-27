using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DefenseCore : MonoBehaviour
{
    
    // Public info
    public int Health { get; private set; }
    public Collider2D Collider { get; private set; }

    // Inspector
    [SerializeField]
    private int _startingHealth;

    private void Start()
    {
        Health = _startingHealth;
        Collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Health <= 0)
        {
            print("Aw nuts you done lost the video game");
        }
    }

    public void Damage(int amount)
    {
        Health -= amount;
    }

}
