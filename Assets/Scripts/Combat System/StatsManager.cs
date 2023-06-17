using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    private static StatsManager instance;
    public static StatsManager Instance { get => instance; private set => instance = value; }
    public EnemyNormalInt[] enemies;
    //public int dead;
    public bool dead;
    int randomicNumber;
    public int PlayerHealth { get; private set; }
    public int EnemyHealth { get; private set; }
    public int counter;
    private void Awake()
    {
        instance = this;
        PlayerHealth = 5;
        EnemyHealth = 8;
    }
    private void OnEnable()
    {
        UICombat.OnRightChoice += MakeDamage;
        UICombat.OnWrongChoice += TakeDamage;
    }
    private void OnDisable()
    {
        UICombat.OnRightChoice -= MakeDamage;
        UICombat.OnWrongChoice -= TakeDamage;
    }
    private void TakeDamage()
    {
        PlayerHealth--;
    }
    private void MakeDamage()
    {
        EnemyHealth--;
        counter++;
        
        if (counter % 2 == 0 && counter != 0 && dead == true)
        {
            dead = false;
            int i = 0;
            i = Random.Range(0, 4);
            if (enemies[i] != null)
                enemies[i].GetComponent<EnemyNormalInt>().selected = true;
            else
            {
                CheckEnemyDeath(randomicNumber);
                Debug.Log("Check");
                enemies[randomicNumber].GetComponent<EnemyNormalInt>().selected = true;
            }
        }
    }
    void CheckEnemyDeath(int i)
    {
        while (enemies[i] == null)
        {
            i = Random.Range(0, 4);
        }
        if (enemies[i] != null)
            randomicNumber = i;
    }
}
