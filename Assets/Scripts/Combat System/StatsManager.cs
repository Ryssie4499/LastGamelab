using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatsManager : MonoBehaviour
{
    private static StatsManager instance;
    public static StatsManager Instance { get => instance; private set => instance = value; }

    public int PlayerHealth { get; set; }
    public int TotalEnemyHealth { get; set; }
    public int BossHealth { get; set; }
    UICombat ui;
    public List<EnemyNormalInt> enemies0, enemies1, enemies2;
    int randomicNumber;
    private void Awake()
    {
        instance = this;
        PlayerHealth = 5;
        TotalEnemyHealth = 6;
        BossHealth = 8;
        ui = FindObjectOfType<UICombat>();
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
        if (ui.zona == Area.Bambino)
        {
            for (int i = 0; i < enemies0.Count; i++)
            {
                if (enemies0[i] == null)
                    enemies0.RemoveAt(i);
            }
        }
        else if (ui.zona == Area.Madre)
        {
            for (int i = 0; i < enemies1.Count; i++)
            {
                if (enemies1[i] == null)
                    enemies1.RemoveAt(i);
            }
        }
        else if (ui.zona == Area.Padre)
        {
            for (int i = 0; i < enemies2.Count; i++)
            {
                if (enemies2[i] == null)
                    enemies2.RemoveAt(i);
            }
        }
    }
    public void RandomicChoiceOfEnemy()
    {
        StartCoroutine(timerBeforeChoice());
    }
    IEnumerator timerBeforeChoice()
    {
        yield return new WaitForSeconds(0.1f);
        if (ui.zona == Area.Bambino)
        {
            int i = UnityEngine.Random.Range(0, enemies0.Count - 1);
            enemies0[i].GetComponent<EnemyNormalInt>().selected = true;
            Debug.Log("Chosen " + i);

        }
        else if (ui.zona == Area.Madre)
        {
            int i = UnityEngine.Random.Range(0, enemies1.Count - 1);
            enemies1[i].GetComponent<EnemyNormalInt>().selected = true;
            Debug.Log("Chosen " + i);
        }
        else if (ui.zona == Area.Padre)
        {
            int i = UnityEngine.Random.Range(0, enemies2.Count - 1);
            enemies2[i].GetComponent<EnemyNormalInt>().selected = true;
            Debug.Log("Chosen " + i);
        }
    }
}