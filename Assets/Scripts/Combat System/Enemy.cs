using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

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
            if (StatsManager.Instance.counter % 2 == 0 && StatsManager.Instance.counter != 0 && gameObject != null && StatsManager.Instance.dead == false/* && StatsManager.Instance.dead == 0*/ || health<= 0)
            {
                Debug.Log("Morto");
                Destroy(gameObject);
                //gameObject.SetActive(false);
                //StartCoroutine(Death());
                //StatsManager.Instance.dead++;
                StatsManager.Instance.dead = true;
            }
        }
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.2f);
        enemy.selected = false;
    }
}
