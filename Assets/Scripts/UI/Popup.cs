using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] GameObject objectToEnable;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            objectToEnable.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            objectToEnable.SetActive(false);
    }
}
