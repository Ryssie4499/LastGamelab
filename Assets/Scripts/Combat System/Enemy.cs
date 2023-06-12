using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float maxHealth;
    private void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0 && gameObject != null)
        {
            Debug.Log("Morto");
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        
    }
}
