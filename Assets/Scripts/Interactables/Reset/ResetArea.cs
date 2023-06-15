using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetArea : MonoBehaviour
{
    [SerializeField] public Transform playerResetPoint;
    [SerializeField] GameObject[] resettableObjects;

    public static ResetArea CurrentResetArea;

    private void OnTriggerEnter(Collider other)
    {
        CurrentResetArea = this;
    }

    public void Reset()
    {
        foreach (var obj in resettableObjects)
        {
            obj.GetComponent<IResettable>()?.Reset();
        }
    }
}
