using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormalInt : MonoBehaviour, INormalable
{
    public bool inRange;
    public void NormalInteraction()
    {
        inRange = true;
    }

    
}
