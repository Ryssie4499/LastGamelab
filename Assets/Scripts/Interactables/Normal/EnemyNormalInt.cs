using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormalInt : MonoBehaviour, INormalable
{
    public bool selected;
    UICombat UI;
    CamManager cM;
    private void Start()
    {
        UI = FindObjectOfType<UICombat>();
        cM = GameManager.Instance.CM;
    }
    private void Update()
    {
        if (selected)
        {
            UI.CombatCanvas.SetActive(true);
            GameManager.Instance.gameState = GameManager.GameState.inCombat;
            cM.changeToPlayerCam();
        }
    }
    public void NormalInteraction()
    {
        selected = true;
    }
}
