using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormalInt : MonoBehaviour, INormalable
{
    public bool selected;
    UICombat UI;
    private void Start()
    {
        UI = FindObjectOfType<UICombat>();
    }
    private void Update()
    {
        if (selected)
        {
            UI.CombatCanvas.SetActive(true);
            GameManager.Instance.gameState = GameManager.GameState.inMenu;
        }
    }
    public void NormalInteraction()
    {
        selected = true;
    }
}
