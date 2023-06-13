using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    EnemyNormalInt enemy;
    private void Start()
    {
        enemy = GetComponent<EnemyNormalInt>();
    }
    private void Update()
    {
        health = StatsManager.Instance.EnemyHealth;
        if (enemy.selected == true)
        {
            if (health <= 0 && gameObject != null)
            {
                Debug.Log("Morto");
                Destroy(gameObject);
            }
        }
    }
    
}
