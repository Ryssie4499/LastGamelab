using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormalInt : MonoBehaviour, INormalable
{
    public bool selected;
    //public static event Action OnRandomChoice;
    //public int health;
    //public int maxHealth;
    //EnemyNormalInt enemy;
    //Renderer rend;
    UICombat UI;
    CamManager cM;
    private void Start()
    {
        UI = FindObjectOfType<UICombat>();
        cM = GameManager.Instance.CM;
        //enemy = GetComponent<EnemyNormalInt>();
        //health = maxHealth;
    }
    private void Update()
    {
        if (selected)
        {
            UI.CombatCanvas.SetActive(true);
            GameManager.Instance.gameState = GameManager.GameState.inCombat;
            cM.changeToEnemyCam();
        }
        //if (enemy.selected == true)
        //{
        //    if (health > 0)
        //    {
        //        rend = GetComponent<Renderer>();
        //        rend.material.SetFloat("_Power", 2.6f - (2 / maxHealth * health)); // 0.6f -> 2.6f
        //    }
        //    if (health <= 0)
        //    {
        //        OnRandomChoice?.Invoke();
        //        Destroy(gameObject);
        //    }
        //}
    }
    public void NormalInteraction()
    {
        selected = true;
    }



    //private void OnEnable()
    //{
    //    UICombat.OnRightChoice += MakeDamage;
    //    OnRandomChoice += StatsManager.Instance.RandomicChoiceOfEnemy;
    //}
    //private void OnDisable()
    //{
    //    UICombat.OnRightChoice -= MakeDamage;
    //    OnRandomChoice -= StatsManager.Instance.RandomicChoiceOfEnemy;
    //}
    //private void MakeDamage()
    //{
    //    health--;
    //    StatsManager.Instance.TotalEnemyHealth--;
    //}


}
