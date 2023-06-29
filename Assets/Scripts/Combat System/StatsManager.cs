using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatsManager : MonoBehaviour
{
    private static StatsManager instance;
    public static StatsManager Instance { get => instance; private set => instance = value; }

    public int PlayerHealth { get; private set; }
    public int TotalEnemyHealth { get; set; }
    public int BossHealth { get; set; }
    public List<EnemyNormalInt> enemies;
    int randomicNumber;
    private void Awake()
    {
        instance = this;
        PlayerHealth = 5;
        TotalEnemyHealth = 6;
        BossHealth = 8;
    }
    private void OnEnable()
    {
        UICombat.OnWrongChoice += TakeDamage;
        Enemy.OnRandomChoice += RandomicChoiceOfEnemy;
    }
    private void OnDisable()
    {
        UICombat.OnWrongChoice -= TakeDamage;
        Enemy.OnRandomChoice -= RandomicChoiceOfEnemy;
    }
    private void TakeDamage()
    {
        PlayerHealth--;
    }
    private void Update()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
                enemies.RemoveAt(i);
        }
        
    }
    public void RandomicChoiceOfEnemy()
    {
        StartCoroutine(timerBeforeChoice());
    }
    IEnumerator timerBeforeChoice()
    {
        yield return new WaitForSeconds(0.1f);
        int i = UnityEngine.Random.Range(0, enemies.Count-1);
        enemies[i].GetComponent<EnemyNormalInt>().selected = true;
        Debug.Log("Chosen " + i);
    }
}