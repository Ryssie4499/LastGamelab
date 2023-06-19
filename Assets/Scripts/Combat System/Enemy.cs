using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    EnemyNormalInt enemy;
    Renderer rend;
    private void Start()
    {
        enemy = GetComponent<EnemyNormalInt>();
    }
    private void Update()
    {
        health = StatsManager.Instance.EnemyHealth;
        if (enemy.selected == true)
        {
            if (health == 1)
            {
                rend = GetComponent<Renderer>();
                rend.material.SetFloat("_Power", 1.7f);
            }
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
