using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health;
    public int maxHealth;
    UICombat ui;
    EnemyNormalInt boss;
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
        ui = FindObjectOfType<UICombat>();
        boss = GetComponent<EnemyNormalInt>();
        health = maxHealth;
    }
    private void Update()
    {
        if (boss.selected == true)
        {
            //if (health > 0)
            //{
            //    rend = GetComponent<Renderer>();
            //    rend.material.SetFloat("_Power", 2.6f - (2 / maxHealth * health)); // 0.6f -> 2.6f
            //}
            if (health <= 0)
            {
                GameManager.Instance.gameState = GameManager.GameState.inGame;
                ui.CombatCanvas.SetActive(false);
                ui.bossLife.SetActive(false);
                ui.shadowLife.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
    private void MakeDamage()
    {
        if (boss.selected == true)
        {
            StatsManager.Instance.BossHealth--;
            health--;
        }
    }
}
