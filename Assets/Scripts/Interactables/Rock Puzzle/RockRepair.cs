using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockRepair : MonoBehaviour, IRockable, IResettable
{
    [SerializeField] private GameObject brokenWall;
    [SerializeField] private GameObject unBrokenWall;
    [SerializeField] private ParticleSystem particleSystem;
    private bool isRepaired;

    private void Start()
    {
        ResetState();
    }

    public void Reset()
    {
        ResetState();
    }

    public void Rock()
    {
        if(isRepaired) return;

        isRepaired = true;

        brokenWall.SetActive(false);
        unBrokenWall.SetActive(true);

        if(particleSystem != null)
            particleSystem.Play();
    }

    private void ResetState()
    {
        isRepaired = false;
        brokenWall.SetActive(true);
        unBrokenWall.SetActive(false);
    }
}
