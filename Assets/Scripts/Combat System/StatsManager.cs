using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatsManager : MonoBehaviour
{
    private static StatsManager instance;
    public static StatsManager Instance { get => instance; private set => instance = value; }

    public static event Action OnRandomChoice;
    public int PlayerHealth { get; private set; }
    public int TotalEnemyHealth { get; private set; }
    public int EnemyHealth { get; private set; }
    public int BossHealth { get; private set; }
    public EnemyNormalInt[] enemies;
    int randomicNumber;
    private void Awake()
    {
        instance = this;
        PlayerHealth = 5;
        TotalEnemyHealth = 6;
        EnemyHealth = 2;
        BossHealth = 8;
    }
    private void OnEnable()
    {
        UICombat.OnWrongChoice += TakeDamage;
        UICombat.OnRightChoice += MakeDamage;
        OnRandomChoice += RandomicChoiceOfEnemy;
    }
    private void OnDisable()
    {
        UICombat.OnWrongChoice -= TakeDamage;
        UICombat.OnRightChoice -= MakeDamage;
        OnRandomChoice -= RandomicChoiceOfEnemy;
    }
    private void TakeDamage()
    {
        PlayerHealth--;
    }
    private void MakeDamage()
    {
        EnemyHealth--;
        TotalEnemyHealth--;
        if (EnemyHealth <= 0 && TotalEnemyHealth>0)
            StartCoroutine(timeBeforeRestoreHealth());
    }
    IEnumerator timeBeforeRestoreHealth()
    {
        yield return new WaitForSeconds(0.4f);
        EnemyHealth = 2;
        OnRandomChoice?.Invoke();
    }
    void RandomicChoiceOfEnemy()
    {
        int i = UnityEngine.Random.Range(0, 4);
        if (enemies[i] != null)
        {
            enemies[i].GetComponent<EnemyNormalInt>().selected = true;
        }
        else
        {
            CheckEnemyDeath(randomicNumber);
            enemies[randomicNumber].GetComponent<EnemyNormalInt>().selected = true;
        }
    }
    void CheckEnemyDeath(int i)
    {
        while (enemies[i] == null)
        {
            i = UnityEngine.Random.Range(0, 4);
        }
        if (enemies[i] != null)
            randomicNumber = i;
    }
}