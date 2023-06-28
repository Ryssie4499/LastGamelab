using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGroup : MonoBehaviour
{

    [SerializeField] List<EnemyNormalInt> enemies;
    public bool inCombat;
    // Start is called before the first frame update


    public void CheckSelectedGroup()
    {
        foreach (var enemy in enemies)
        {
            if (enemy.selected)
            {
                inCombat = true;
                return;
            }
            else
            {
                inCombat = false;
            }
        }
    }
}
