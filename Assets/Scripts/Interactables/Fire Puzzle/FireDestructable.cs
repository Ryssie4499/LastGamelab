using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDestructable : MonoBehaviour, IFireable
{
    [SerializeField] private float destroyTime;
    [SerializeField] private ParticleSystem particleSystem;

    public void Fire()
    {
        particleSystem.Play();
        Invoke(nameof(DisableFire), destroyTime);
    }

    private void DisableFire()
    {
        gameObject.SetActive(false);
    }
}
