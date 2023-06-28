using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action OnRandomChoice;
    public int health;
    public int maxHealth;

    EnemyNormalInt enemy;
    Renderer rend;
    private void OnEnable()
    {
        UICombat.OnRightChoice += MakeDamage;
    }
    private void OnDisable()
    {
        UICombat.OnRightChoice -= MakeDamage;
    }
    private void Start()
    {
        enemy = GetComponent<EnemyNormalInt>();
        health = maxHealth;
    }
    private void Update()
    {
        if (enemy.selected == true)
        {
            if (health > 0)
            {
                rend = GetComponent<Renderer>();
                rend.material.SetFloat("_Power", 2.6f - (2 / maxHealth * health)); // 0.6f -> 2.6f
            }
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnDestroy()
    {
        if (StatsManager.Instance.enemies.Count > 0)
            OnRandomChoice?.Invoke();
    }
    private void MakeDamage()
    {
        if (enemy.selected)
        {
            health--;
            StatsManager.Instance.TotalEnemyHealth--;
        }
    }


}
