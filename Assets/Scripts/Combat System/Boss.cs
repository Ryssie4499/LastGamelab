using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health;
    EnemyNormalInt boss;
    private void Start()
    {
        boss = GetComponent<EnemyNormalInt>();
    }
    private void Update()
    {
        health = StatsManager.Instance.BossHealth;
        if (boss.selected == true)
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
