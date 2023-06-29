using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EemyChecker : MonoBehaviour
{
    [SerializeField] EnemyNormalInt enemy;
    public bool selected;
    private void Update()
    {
        if(enemy != null && enemy.selected)
        {
            selected = true;
        }
        else if (enemy == null || !enemy.selected)
        {
            selected = false;
        }
    }
}
