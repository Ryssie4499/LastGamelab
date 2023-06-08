using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDestructable : MonoBehaviour, IFireable
{
    [SerializeField] private float destroyTime;

    public void Fire()
    {
        Invoke(nameof(DisableFire), destroyTime);
    }

    private void DisableFire()
    {
        gameObject.SetActive(false);
    }
}
