using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormalInt : MonoBehaviour, INormalable
{
    public bool selected;
    public void NormalInteraction()
    {
        selected = true;
    }
}
