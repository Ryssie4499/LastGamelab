using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    private static StatsManager instance;
    public static StatsManager Instance { get => instance; private set => instance = value; }
    public int PlayerHealth { get; private set; }
    public int EnemyHealth { get; private set; }
    private void Awake()
    {
        instance = this;
        PlayerHealth = 5;
        EnemyHealth = 2;
    }
    private void OnEnable()
    {
        UIManager.OnRightChoice += MakeDamage;
        UIManager.OnWrongChoice += TakeDamage;
    }
    private void OnDisable()
    {
        UIManager.OnRightChoice -= MakeDamage;
        UIManager.OnWrongChoice -= TakeDamage;
    }
    private void TakeDamage()
    {
        PlayerHealth--;
        
        Debug.Log(PlayerHealth);

        if (PlayerHealth <= 0)
        {
            Debug.Log("GameOver");
        }
    }
    private void MakeDamage()
    {
        EnemyHealth--;
        
        Debug.Log(EnemyHealth);

        if (EnemyHealth <= 0)
        {
            Debug.Log("Win");
        }
    }
}
