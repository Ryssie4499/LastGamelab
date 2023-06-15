using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireReset : MonoBehaviour, IResettable
{
    [SerializeField] private GameObject fireWall;
    public void Reset()
    {
        fireWall.SetActive(true);
    }
}
